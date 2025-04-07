using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Threading.Tasks;
using CRM.Models;
using CRM.Services;
using System.Windows.Input;
using System.IO.Pipes;
using System.IO;
using System.Diagnostics;

namespace CRM.ViewModels
{
    public class CRMViewModel : INotifyPropertyChanged
    {
        private readonly ClientRepository _clientRepository;
        private readonly AuthService _authService;
        private bool _isLoading;
        private UserModel _currentUser;
        private bool _isRunning;
        private const string PipeName = "CRMOrderPipe";

        public ObservableCollection<ClientModel> Clients { get; set; }
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
        public ICommand SaveClientsCommand { get; }

        public CRMViewModel()
        {
            _clientRepository = new ClientRepository();
            _authService = new AuthService();
            Clients = new ObservableCollection<ClientModel>();
            _isRunning = true;

            AddClientCommand = new RelayCommand(AddClient, () => IsAdmin);
            EditClientCommand = new RelayCommand(EditClient, () => SelectedClient != null);
            DeleteClientCommand = new RelayCommand(DeleteClient, () => SelectedClient != null && IsAdmin);
            SaveClientsCommand = new RelayCommand(async () => await SaveClientsAsync(), () => true);
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            Debug.WriteLine($"Вызов LoginAsync: username={username}");
            var user = await _authService.AuthenticateUserAsync(username, password);
            if (user != null)
            {
                Debug.WriteLine("Пользователь аутентифицирован");
                CurrentUser = user;
                Task.Run(() => ListenForOrderNotificationsAsync());
                return true;
            }
            Debug.WriteLine("Аутентификация не удалась");
            return false;
        }

        public async Task<bool> RegisterAsync(string username, string password, UserRole role)
        {
            return await _authService.RegisterUserAsync(username, password, role);
        }

        public async Task LoadDataAsync()
        {
            IsLoading = true;
            Debug.WriteLine("Начало загрузки данных");
            try
            {
                var clients = await _clientRepository.GetAllClientsAsync();
                Clients.Clear();
                foreach (var client in clients)
                {
                    Clients.Add(client);
                }
                Debug.WriteLine("Данные успешно загружены");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Ошибка загрузки данных: {ex.Message}");
                throw;
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async Task SaveClientsAsync()
        {
            IsLoading = true;
            try
            {
                foreach (var client in Clients)
                {
                    await _clientRepository.UpdateClientAsync(client);
                }
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async Task ListenForOrderNotificationsAsync()
        {
            Debug.WriteLine("Запуск слушателя Named Pipes...");
            while (_isRunning)
            {
                try
                {
                    using (var pipeClient = new NamedPipeClientStream(".", PipeName, PipeDirection.In))
                    {
                        Debug.WriteLine("Ожидание подключения к Named Pipe...");
                        await pipeClient.ConnectAsync(5000);
                        if (pipeClient.IsConnected)
                        {
                            Debug.WriteLine("Подключение к Named Pipe установлено");
                            using (var reader = new StreamReader(pipeClient))
                            {
                                string message = await reader.ReadLineAsync();
                                if (!string.IsNullOrEmpty(message))
                                {
                                    Debug.WriteLine($"Получено сообщение: {message}");
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
                    Debug.WriteLine("Тайм-аут подключения к Named Pipe, повторная попытка...");
                    await Task.Delay(5000);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Ошибка в Named Pipe: {ex.Message}");
                    await Task.Delay(5000);
                }
            }
        }

        private void AddClient()
        {
            var client = new ClientModel();
            if (ShowEditDialog(client))
            {
                _clientRepository.AddClientAsync(client);
                Clients.Add(client);
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
                    ClientType = SelectedClient.ClientType,
                    InteractionHistory = SelectedClient.InteractionHistory
                };
                if (ShowEditDialog(clone))
                {
                    _clientRepository.UpdateClientAsync(clone);
                    SelectedClient.FullName = clone.FullName;
                    SelectedClient.PhoneNumber = clone.PhoneNumber;
                    SelectedClient.Email = clone.Email;
                    SelectedClient.ClientType = clone.ClientType;
                    SelectedClient.InteractionHistory = clone.InteractionHistory;
                }
            }
        }

        private void DeleteClient()
        {
            if (SelectedClient != null && MessageBox.Show("Удалить клиента?", "Подтверждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _clientRepository.DeleteClientAsync(SelectedClient);
                Clients.Remove(SelectedClient);
            }
        }

        private bool ShowEditDialog(ClientModel client)
        {
            var dialog = new ClientEditWindow(client, ClientTypes) { Owner = Application.Current.MainWindow };
            return dialog.ShowDialog() == true;
        }

        public void Shutdown()
        {
            _isRunning = false;
            Debug.WriteLine("Приложение завершило работу");
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