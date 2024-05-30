using System.Linq;
using System.Windows;
using GymLibrary;

namespace GymApp
{
    public partial class LoginWindow : Window
    {
        private JsonRepository<User> userRepository;

        public User LoggedInUser { get; private set; }

        public LoginWindow()
        {
            InitializeComponent();
            userRepository = new JsonRepository<User>("users.json");
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var username = UsernameTextBox.Text;
            var password = PasswordBox.Password;
            LoggedInUser = userRepository.GetAll().FirstOrDefault(user => user.Username == username && user.Password == password);

            if (LoggedInUser != null)
            {
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Неправильное имя пользователя или пароль.");
            }
        }
    }
}
