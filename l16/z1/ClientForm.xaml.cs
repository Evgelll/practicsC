using System.Windows;
using System.Windows.Controls;

namespace z1
{
    public partial class ClientForm : Window
    {
        public ClientModel Client { get; private set; }

        public ClientForm(ClientModel client = null)
        {
            InitializeComponent();
            Client = client ?? new ClientModel();

            if (client != null)
            {
                FullNameTextBox.Text = client.FullName;
                ContactTextBox.Text = client.Contact;
                InteractionHistoryTextBox.Text = client.InteractionHistory;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FullNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(ContactTextBox.Text) ||
                string.IsNullOrWhiteSpace(InteractionHistoryTextBox.Text) ||
                ClientTypeComboBox.SelectedItem == null) 
            {
                MessageBox.Show("Все поля должны быть заполнены, включая тип клиента.");
                return;
            }

            Client.FullName = FullNameTextBox.Text;
            Client.Contact = ContactTextBox.Text;
            Client.InteractionHistory = InteractionHistoryTextBox.Text;
            Client.ClientType = (ClientTypeComboBox.SelectedItem as ComboBoxItem)?.Content.ToString(); 

            DialogResult = true;
            Close();
        }
    }
}