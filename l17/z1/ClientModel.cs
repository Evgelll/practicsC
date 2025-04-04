using System.ComponentModel;

public class ClientModel : INotifyPropertyChanged
{
    private string _fullName;
    private string _contact;
    private string _interactionHistory;
    private string _clientType;

    public string FullName
    {
        get => _fullName;
        set
        {
            _fullName = value;
            OnPropertyChanged(nameof(FullName));
        }
    }

    public string Contact
    {
        get => _contact;
        set
        {
            _contact = value;
            OnPropertyChanged(nameof(Contact));
        }
    }

    public string InteractionHistory
    {
        get => _interactionHistory;
        set
        {
            _interactionHistory = value;
            OnPropertyChanged(nameof(InteractionHistory));
        }
    }

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