using System.Windows;

namespace CRMApp
{
    public partial class ClientForm : Window
    {
        public Client Client { get; private set; }

        public ClientForm(Client client = null)
        {
            InitializeComponent();
            Client = client ?? new Client();

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
                string.IsNullOrWhiteSpace(InteractionHistoryTextBox.Text))
            {
                MessageBox.Show("Все поля должны быть заполнены.");
                return;
            }

            Client.FullName = FullNameTextBox.Text;
            Client.Contact = ContactTextBox.Text;
            Client.InteractionHistory = InteractionHistoryTextBox.Text;

            DialogResult = true;
            Close();
        }
    }
}