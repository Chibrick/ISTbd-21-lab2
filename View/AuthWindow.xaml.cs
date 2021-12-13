using CourseWork.ViewModel;
using System.Windows;

namespace CourseWork.View
{
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
            DataContext = new AuthVM();
        }

        private void Button_regist(object sender, RoutedEventArgs e)
        {
            RegistrWindow registrWindow = new RegistrWindow();
            registrWindow.Show();
            Hide();
        }
    }
}
