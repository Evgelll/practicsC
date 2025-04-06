using System.ComponentModel;

namespace CRM.Models
{
    public class OrderModel : INotifyPropertyChanged
    {
        private int _orderId;
        private string _description;
        private decimal _amount;

        public int OrderId
        {
            get => _orderId;
            set { _orderId = value; OnPropertyChanged(nameof(OrderId)); }
        }

        public string Description
        {
            get => _description;
            set { _description = value; OnPropertyChanged(nameof(Description)); }
        }

        public decimal Amount
        {
            get => _amount;
            set { _amount = value; OnPropertyChanged(nameof(Amount)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}