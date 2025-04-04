using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Threading;
using z1;

public class CRMViewModel : INotifyPropertyChanged
{
    private readonly ClientService _clientService;
    private bool _isLoading;

    public ObservableCollection<ClientModel> Clients => _clientService.Clients;
    public bool IsLoading
    {
        get => _isLoading;
        set
        {
            _isLoading = value;
            OnPropertyChanged(nameof(IsLoading));
        }
    }

    public ICommand AddClientCommand { get; }
    public ICommand EditClientCommand { get; }
    public ICommand DeleteClientCommand { get; }

    public CRMViewModel()
    {
        _clientService = new ClientService();
        IsLoading = false;
        LoadClientsAsync();
        AddClientCommand = new RelayCommand(AddClient);
        EditClientCommand = new RelayCommand(EditClient, CanEditOrDeleteClient);
        DeleteClientCommand = new RelayCommand(DeleteClient, CanEditOrDeleteClient);

        
    }

    public async void LoadClientsAsync()
    {
        IsLoading = true;
        await _clientService.LoadClientsAsync();  // Используем асинхронный метод
        IsLoading = false;
    }

    private void AddClient(object parameter)
    {
        var newClient = new ClientModel();
        var clientForm = new ClientForm(newClient);
        if (clientForm.ShowDialog() == true)
        {
            _clientService.AddClient(newClient);
        }
    }


    private void EditClient(object parameter)
    {
        if (parameter is ClientModel selectedClient)
        {
            var clientForm = new ClientForm(selectedClient);
            if (clientForm.ShowDialog() == true)
            {
                _clientService.EditClient(selectedClient);
            }
        }
    }

    private void DeleteClient(object parameter)
    {
        if (parameter is ClientModel selectedClient)
        {
            _clientService.DeleteClient(selectedClient);
        }
    }

    private bool CanEditOrDeleteClient(object parameter)
    {
        return parameter is ClientModel;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}