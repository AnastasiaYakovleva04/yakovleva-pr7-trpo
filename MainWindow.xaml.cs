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
        public Pacient pacAdd;  
        public Pacient pacWork;
        public SystemStatus sys;

        public MainWindow()
        {
            Directory.CreateDirectory("Doctors");
            Directory.CreateDirectory("Pacients");

            doc = new Doctor();
            pacAdd = new Pacient();
            pacWork = new Pacient();
            sys = new SystemStatus();

            InitializeComponent();
            AddPacPanel.IsEnabled = EditPacPanel.IsEnabled = SearchPacPanel.IsEnabled = false;

            DataContext = doc;
            DocInfoPanel.DataContext = null;
            AddPacPanel.DataContext = pacAdd;
            EditPacPanel.DataContext = SearchPacPanel.DataContext = PacInfoPanel.DataContext = pacWork;
            SystemStatusPanel.DataContext = sys;

            pacWork.Reset();
            doc.LoadDoctors();
            pacAdd.LoadPacients();
            pacWork.LoadPacients();
            sys.UpdateCounts();
        }
        //нажатие на кнопку регистрации
        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                doc.Registration(doc.Name, doc.Surname, doc.Patronimic, doc.Specialization, doc.Password, doc.ConfirmPassword);
                MessageBox.Show($"Вы зарегистрированы. Ваш ID = {doc.Id}", "Успешно");
                ClearTextBoxes(RegPanel);
                sys.UpdateCounts();
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
                ClearTextBoxes(RegPanel);
                ClearTextBoxes(LoginPanel);
                DocInfoPanel.DataContext = doc;
                AddPacPanel.IsEnabled = EditPacPanel.IsEnabled = SearchPacPanel.IsEnabled = true;
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
        //добавить пациента
        private void AddPacientBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newPac = doc.AddPacient(pacAdd.Name, pacAdd.Surname, pacAdd.Patronimic,
                                 pacAdd.Birthday, pacAdd.LastAppointment, doc.Id,
                                 pacAdd.Diagnosis, pacAdd.Recomendations);
                MessageBox.Show($"Пациент добавлен. ID: {newPac.Id}", "Успешно");

                pacAdd.pacients[newPac.Id] = newPac;
                pacWork.pacients[newPac.Id] = newPac;
                pacAdd.Reset();
                sys.UpdateCounts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //сохранить изменения при редактировании
        private void SaveChangesPacientBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                pacWork.SaveChanges();
                MessageBox.Show("Изменения сохранены", "Успешно");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //поиск пациента
        private void SearchPacientBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                pacWork.SearchPacient();
                MessageBox.Show("Пациент найден", "Успешно");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //сброс редактирования
        private void ResetPacientBtn_Click(object sender, RoutedEventArgs e)
        {
            pacWork.Reset();
        }
    }
}