using BookManagement.BLL.Services;
using BookManagement.DAL.Models;
using System.Windows;

namespace BookManagement_NguyenDucHuan
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }
        private UserService _userService;
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            UserService userService = new();
            var user = userService.CheckUserLogin(EmailTextBox.Text, PasswordTextBox.Text);

            if (user != null)
            {
                if (user.Role == 1 || user.Role == 2)
                {

                    AutoCloseMessage autoCloseMessageBox = new AutoCloseMessage("Login successful", 1);
                    autoCloseMessageBox.ShowDialog();
                    MainWindow mainScreen = new();
                    mainScreen.User = user;
                    mainScreen.Show();
                    this.Hide();
                }
                else
                {
                    AutoCloseMessage autoCloseMessageBox = new AutoCloseMessage("You have no permission to access system!", 1);
                    autoCloseMessageBox.ShowDialog();
                }
            }
            else
            {
                AutoCloseMessage autoCloseMessageBox = new AutoCloseMessage("Wrong Email or Password", 1);
                autoCloseMessageBox.ShowDialog();
            }
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}