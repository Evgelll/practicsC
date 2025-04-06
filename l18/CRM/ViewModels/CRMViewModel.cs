using System.Collections.ObjectModel;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows;
using System.Threading.Tasks;
using CRM.Models;
using CRM.Services;
using Newtonsoft.Json;
using System.IO;
using System.IO.Pipes;

namespace CRM.ViewModels
{
    public class CRMViewModel : INotifyPropertyChanged
    {
        private readonly ClientService _clientService;
        private readonly AuthService _authService;
        private bool _isLoading;
        private UserModel _currentUser;
        private const string DataFilePath = "crm_data.json";
        private const string PipeName = "CRMOrderPipe";
        private bool _isRunning;
        private FileSystemWatcher _fileWatcher;

        public ObservableCollection<ClientModel> Clients { get; set; }
        public ObservableCollection<OrderModel> Orders { get; set; }
        public ObservableCollection<string> ClientTypes { get; } = new ObservableCollection<string>
        {
            "Физическое лицо",
            "Юридическое лицо",
            "VIP"
        };

        public UserModel CurrentUser
        {
            get => _currentUser;
            set { _currentUser = value; OnPropertyChanged(nameof(CurrentUser)); OnPropertyChanged(nameof(IsAdmin)); }
        }

        public bool IsAdmin => CurrentUser?.Role == UserRole.Admin.ToString();

        private ClientModel _selectedClient;

        public ClientModel SelectedClient
        {
            get => _selectedClient;
            set
            {
                _selectedClient = value;
                OnPropertyChanged(nameof(SelectedClient));
            }
        }

        public bool IsLoading
        {
            get => _isLoading;
            set { _isLoading = value; OnPropertyChanged(nameof(IsLoading)); }
        }

        public ICommand AddClientCommand { get; }
        public ICommand EditClientCommand { get; }
        public ICommand DeleteClientCommand { get; }

        public CRMViewModel()
        {
            _clientService = new ClientService();
            _authService = new AuthService();
            Clients = new ObservableCollection<ClientModel>();
            Orders = new ObservableCollection<OrderModel>();

            AddClientCommand = new RelayCommand(AddClient, () => IsAdmin);
            EditClientCommand = new RelayCommand(EditClient, () => SelectedClient != null);
            DeleteClientCommand = new RelayCommand(DeleteClient, () => SelectedClient != null && IsAdmin);

            _isRunning = true;
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            var user = await _authService.AuthenticateUserAsync(username, password);
            if (user != null)
            {
                CurrentUser = user;
                Task.Run(() => ListenForOrderNotificationsAsync());
                SetupFileWatcher();
                return true;
            }
            return false;
        }

        public async Task LoadDataAsync()
        {
            IsLoading = true;
            try
            {
                var (clients, orders) = await LoadDataCoreAsync();
                await Task.Delay(1000);

                foreach (var client in clients)
                {
                    Clients.Add(client);
                }
                foreach (var order in orders)
                {
                    Orders.Add(order);
                }
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async Task<(ObservableCollection<ClientModel> clients, ObservableCollection<OrderModel> orders)> LoadDataCoreAsync()
        {
            var loadedClients = await _clientService.LoadClientsAsync();
            var loadedOrders = new ObservableCollection<OrderModel>();

            if (File.Exists(DataFilePath))
            {
                string json = await File.ReadAllTextAsync(DataFilePath);
                var data = JsonConvert.DeserializeObject<CRMData>(json);
                foreach (var order in data.Orders)
                {
                    loadedOrders.Add(order);
                }
            }
            else
            {
                loadedOrders.Add(new OrderModel { OrderId = 1, Description = "Заказ 1", Amount = 1000m });
                loadedOrders.Add(new OrderModel { OrderId = 2, Description = "Заказ 2", Amount = 2000m });
                await SaveDataAsync();
            }

            return (loadedClients, loadedOrders);
        }

        private async Task ListenForOrderNotificationsAsync()
        {
            while (_isRunning)
            {
                try
                {
                    using (var pipeClient = new NamedPipeClientStream(".", PipeName, PipeDirection.In))
                    {
                        await pipeClient.ConnectAsync(5000);
                        if (pipeClient.IsConnected)
                        {
                            using (var reader = new StreamReader(pipeClient))
                            {
                                string message = await reader.ReadLineAsync();
                                if (!string.IsNullOrEmpty(message))
                                {
                                    Application.Current.Dispatcher.Invoke(() =>
                                    {
                                        MessageBox.Show($"Новая заявка: {message}", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                                    });
                                }
                            }
                        }
                    }
                }
                catch (TimeoutException)
                {
                    await Task.Delay(5000);
                }
                catch
                {
                    await Task.Delay(5000);
                }
            }
        }

        private void SetupFileWatcher()
        {
            string fullPath = Path.GetFullPath(DataFilePath);
            string directory = Path.GetDirectoryName(fullPath);
            string fileName = Path.GetFileName(fullPath);

            if (string.IsNullOrEmpty(directory))
            {
                directory = Directory.GetCurrentDirectory();
            }

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            _fileWatcher = new FileSystemWatcher
            {
                Path = directory,
                Filter = fileName,
                NotifyFilter = NotifyFilters.LastWrite,
                EnableRaisingEvents = true
            };
            _fileWatcher.Changed += async (s, e) => await OnFileChangedAsync();
        }

        private async Task OnFileChangedAsync()
        {
            _fileWatcher.EnableRaisingEvents = false;
            await Task.Delay(100);

            try
            {
                if (File.Exists(DataFilePath))
                {
                    string json = await File.ReadAllTextAsync(DataFilePath);
                    var data = JsonConvert.DeserializeObject<CRMData>(json);
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        Orders.Clear();
                        foreach (var order in data.Orders)
                        {
                            Orders.Add(order);
                        }
                        MessageBox.Show("Заказы обновлены", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    });
                }
            }
            finally
            {
                _fileWatcher.EnableRaisingEvents = true;
            }
        }

        public async Task<bool> RegisterAsync(string username, string password, UserRole role)
        {
            return await _authService.RegisterUserAsync(username, password, role);
        }

        private void AddClient()
        {
            var client = new ClientModel();
            if (ShowEditDialog(client))
            {
                _clientService.AddClient(Clients, client);
            }
        }

        private void EditClient()
        {
            if (SelectedClient != null)
            {
                var clone = new ClientModel
                {
                    FullName = SelectedClient.FullName,
                    PhoneNumber = SelectedClient.PhoneNumber,
                    Email = SelectedClient.Email,
                    ClientType = SelectedClient.ClientType
                };
                if (ShowEditDialog(clone))
                {
                    _clientService.UpdateClient(SelectedClient, clone);
                }
            }
        }

        private void DeleteClient()
        {
            if (SelectedClient != null && MessageBox.Show("Удалить клиента?", "Подтверждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _clientService.DeleteClient(Clients, SelectedClient);
            }
        }

        private async Task SaveDataAsync()
        {
            var data = new CRMData
            {
                Clients = Clients,
                Orders = Orders
            };
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            await File.WriteAllTextAsync(DataFilePath, json);
        }

        private bool ShowEditDialog(ClientModel client)
        {
            var dialog = new ClientEditWindow(client, ClientTypes) { Owner = Application.Current.MainWindow };
            return dialog.ShowDialog() == true;
        }

        public void Shutdown()
        {
            _isRunning = false;
            _fileWatcher?.Dispose();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter) => _canExecute == null || _canExecute();
        public void Execute(object parameter) => _execute();
    }
}