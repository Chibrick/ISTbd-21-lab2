using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CourseWork.View
{
    /// <summary>
    /// Логика взаимодействия для RegistrWindow.xaml
    /// </summary>
    public partial class RegistrWindow : Window
    {



        public RegistrWindow()
        {
            InitializeComponent();

        }

        private void Registration(object sender, RoutedEventArgs e)
        {
            string login = Nickname.Text.Trim();
            string Pass = Password.Text.Trim();
            string Pass2 = Password2.Text.Trim();

            if (login.Length > 15)
            {
                Nickname.ToolTip = "So long login!";
                Nickname.Background = Brushes.LightPink;
            }
            else
            {
                Nickname.ToolTip = "";
                Nickname.Background = Brushes.Transparent;
            }
            if (Pass != Pass2)
            {
                Password2.ToolTip = "Passwords don't match!";
                Password2.Background = Brushes.LightPink;
            }
            else
            {
                Password2.ToolTip = "";
                Password2.Background = Brushes.Transparent;
            }

            using (Model.Data.ApplicationContext db = new())
            {
                Model.User user = new Model.User(login, Pass);
                if (Model.Data.Service.UserService.CheckUser(login, Pass))
                {
                    MessageBox.Show("Объект уже есть");
                }
                else
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    MessageBox.Show("Registration was successful");
                }
            }
        }

        private void Button_autorization(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            Hide();
        }
    }
}
