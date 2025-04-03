using System.ComponentModel;

public class Client : INotifyPropertyChanged
{
    private string _clientType = "Обычный клиент"; 

    public string FullName { get; set; }
    public string Contact { get; set; }
    public string InteractionHistory { get; set; }

    public string ClientType
    {
        get => _clientType;
        set
        {
            _clientType = value;
            OnPropertyChanged(nameof(ClientType));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}