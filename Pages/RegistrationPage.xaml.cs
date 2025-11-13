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
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        Doctor doc;
        public RegistrationPage()
        {
            InitializeComponent();
            doc = new Doctor();
            DataContext = doc;
            doc.LoadDoctors();
        }
        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                doc.Registration(doc.Name, doc.Surname, doc.Patronimic, doc.Specialization, doc.Password, doc.ConfirmPassword);
                MessageBox.Show($"Вы зарегистрированы. Ваш ID = {doc.Id}", "Успешно");
                NavigationService.Navigate(new MainPage(doc));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
