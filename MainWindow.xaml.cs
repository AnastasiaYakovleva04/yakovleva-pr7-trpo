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
        //нажатие на кнопку регистрации
        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                doc.Registration(doc.Name, doc.Surname, doc.Patronimic, doc.Specialization, doc.Password, doc.ConfirmPassword);
                MessageBox.Show($"Вы зарегистрированы. Ваш ID = {doc.Id}", "Успешно");
                var jsonString = JsonSerializer.Serialize(doc);
                var path = $"D_{doc.Id}.json";
                File.WriteAllText(path, jsonString, Encoding.UTF8);
                ClearTextBoxes(RegPanel);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //нажатие на кнопку входа
        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                doc.Login(doc.Id.ToString(), doc.Password);
                MessageBox.Show("Вход выполнен", "Успешно");
                DataContext = null;
                DataContext = doc;
                ClearTextBoxes(RegPanel);
                ClearTextBoxes(LoginPanel);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //очистка текстбоксов с грида
        private void ClearTextBoxes(Grid panel)
        {
            foreach (TextBox textBox in panel.Children.OfType<TextBox>())
                textBox.Clear();
        }
    }
}