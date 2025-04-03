using System.Windows;
using TextEditorApp.ViewModels;
namespace TextEditorApp.Views;

using System.Windows;

public partial class LoginWindow : Window
{
    private readonly LoginViewModel _viewModel = new();

    public LoginWindow()
    {
        InitializeComponent();
        DataContext = _viewModel;
    }

    private void LoginButton_Click(object sender, RoutedEventArgs e)
    {
        string password = PasswordBox.Password;
        string userRole = _viewModel.GetUserRole(password);

        if (_viewModel.TryLogin(password))
        {
            MainWindow mainWindow = new(userRole);
            mainWindow.Show();
            Close();
        }
        else
        {
            MessageBox.Show("Неверные учетные данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
