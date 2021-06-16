using System.Windows;
using System.Data.Entity;
using System.Linq;

namespace TrafficPolice
{
    /// <summary>
    /// Логика взаимодействия для LoginF.xaml
    /// </summary>
    public partial class LoginF : Window
    {
        public LoginF()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            using (MyDBconnection bconnection = new MyDBconnection())
            {
                bconnection.Staffs.Load();
                var Staff = bconnection.Staffs.Where(x => x.Login == LoginTbox.Text.ToString() && x.Password == PasswordTbox.Password.ToString());
                if (Staff.Count() != 1) { MessageBox.Show("Такого пользователя не существует"); LoginClass.key = false; return; } else { LoginClass.key = true; LoginClass.LoginName = LoginTbox.Text.ToString(); LoginClass.LoginPassword = PasswordTbox.Password.ToString(); ; Close(); }
            }
        }
    }
}
