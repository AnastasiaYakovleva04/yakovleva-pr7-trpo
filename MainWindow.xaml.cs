using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace yakovleva_pr7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Doctor doc;

        public MainWindow()
        {
            doc = new Doctor();
            InitializeComponent();
            DataContext = doc;
            doc.LoadDoctors();
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            var name = NameTextBox.Text;
            var surname = SurnameTextBox.Text;
            var patronimic = PatronimicTextBox.Text;
            var specialization = SpecTextBox.Text;
            var password = PassTextBox.Text;
            var confirmPassword = ConfirmPassTextBox.Text;
            try
            {
                doc.Registration(name, surname, patronimic, specialization, password, confirmPassword);
                MessageBox.Show($"Вы зарегистрированы. Ваш ID = {doc.Id}", "Успешно");
                var jsonString = JsonSerializer.Serialize(doc);
                var path = $"D_{doc.Id}.json";
                File.WriteAllText(path, jsonString, Encoding.UTF8);
                NameTextBox.Text = "";
                SurnameTextBox.Text = "";
                PatronimicTextBox.Text = "";
                SpecTextBox.Text = "";
                PassTextBox.Clear();
                ConfirmPassTextBox.Clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            var id = IDTextBox.Text;
            var password = PassLoginTextBox.Text;
            try
            {
                doc.Login(id, password);
                MessageBox.Show("Вход выполнен", "Успешно");
                IDTextBox.Clear();
                PassLoginTextBox.Clear();
                DataContext = null;
                DataContext = doc;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}