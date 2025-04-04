using System.Windows;
using System.Windows.Controls;

namespace z1;

public partial class LoginForm : Window
{
    private UserService _userService;

    public LoginForm(UserService userService)
    {
        InitializeComponent();
        _userService = userService;
    }

    private void LoginButton_Click(object sender, RoutedEventArgs e)
    {
        var username = UsernameTextBox.Text;
        var password = PasswordBox.Password;

        if (_userService.Authenticate(username, password, out var role))
        {
            MessageBox.Show($"Добро пожаловать, {username}! Ваша роль: {role}");

            this.Close();
        }
        else
        {
            MessageBox.Show("Неверное имя пользователя или пароль.");
        }
    }

    private void RegisterButton_Click(object sender, RoutedEventArgs e)
    {
        var registerForm = new RegisterForm(_userService);
        registerForm.ShowDialog();
    }
}