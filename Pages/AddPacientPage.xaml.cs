using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для AddPacientPage.xaml
    /// </summary>
    public partial class AddPacientPage : Page
    {
        Doctor doc;
        Pacient pac;
        ObservableCollection<Pacient> _pacientList;

        public AddPacientPage(Doctor doc, ObservableCollection<Pacient> pacientList)
        {
            InitializeComponent();
            this.doc = doc;
            _pacientList = pacientList; 
            pac = new Pacient();
            pac.LoadPacients();
            DataContext = pac;
        }

        private void AddPacientBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newPac = doc.AddPacient(pac.Name, pac.Surname, pac.Patronimic, pac.PhoneNumber, pac.Birthday);
                MessageBox.Show($"Пациент добавлен. ID: {newPac.Id}", "Успешно");

                _pacientList.Add(newPac);
                pac.pacients[newPac.Id] = newPac;
                NavigationService.GoBack();
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
