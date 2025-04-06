using System.ComponentModel;
using System.Collections.Generic;

namespace CRM.Models
{
    public class ClientModel : INotifyPropertyChanged
    {
        private string _fullName;
        private string _phoneNumber;
        private string _email;
        private string _clientType;
        private List<string> _interactionHistory;

        public string FullName
        {
            get => _fullName;
            set { _fullName = value; OnPropertyChanged(nameof(FullName)); }
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set { _phoneNumber = value; OnPropertyChanged(nameof(PhoneNumber)); }
        }

        public string Email
        {
            get => _email;
            set { _email = value; OnPropertyChanged(nameof(Email)); }
        }

        public string ClientType
        {
            get => _clientType;
            set { _clientType = value; OnPropertyChanged(nameof(ClientType)); }
        }

        public List<string> InteractionHistory
        {
            get => _interactionHistory;
            set { _interactionHistory = value; OnPropertyChanged(nameof(InteractionHistory)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ClientModel()
        {
            InteractionHistory = new List<string>();
        }
    }
}