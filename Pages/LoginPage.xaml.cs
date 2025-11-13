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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace yakovleva_pr7.Pages
{
    public partial class LoginPage : Page
    {
        Doctor doc;
        public LoginPage()
        {
            InitializeComponent();
            doc = new Doctor();
            DataContext = doc;
            doc.LoadDoctors();
        }
        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                doc.Login(doc.Id.ToString(), doc.Password);
                NavigationService.Navigate(new MainPage(doc));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }
    }
}
