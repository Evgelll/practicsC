using System.Windows;
using System.Windows.Controls;

namespace z1;
public partial class RegisterForm : Window
{
    private UserService _userService;

    public RegisterForm(UserService userService)
    {
        InitializeComponent();
        _userService = userService;
    }

    private void RegisterButton_Click(object sender, RoutedEventArgs e)
    {
        var username = UsernameTextBox.Text;
        var password = PasswordBox.Password;

        var selectedRole = (RoleComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(selectedRole))
        {
            MessageBox.Show("Все поля должны быть заполнены.");
            return;
        }

        _userService.Register(username, password, selectedRole);
        MessageBox.Show("Регистрация прошла успешно!");
        this.Close();
    }
}