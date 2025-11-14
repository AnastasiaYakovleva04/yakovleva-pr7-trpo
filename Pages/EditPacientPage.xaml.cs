using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
    /// Логика взаимодействия для EditPacientPage.xaml
    /// </summary>
    public partial class EditPacientPage : Page
    {
        private ObservableCollection<Pacient> _pacientList;
        private Pacient _originalPac;
        private Pacient _editingPac; 

        public EditPacientPage(ObservableCollection<Pacient> PacientList, Pacient pac)
        {
            _pacientList = PacientList;
            _originalPac = pac;

            _editingPac = new Pacient
            {
                Id = pac.Id,
                Name = pac.Name,
                Surname = pac.Surname,
                Patronimic = pac.Patronimic,
                Birthday = pac.Birthday,
                PhoneNumber = pac.PhoneNumber,
            };

            InitializeComponent();
            DataContext = _editingPac;
        }

        private void SaveChangesPacientBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _originalPac.Name = _editingPac.Name;
                _originalPac.Surname = _editingPac.Surname;
                _originalPac.Patronimic = _editingPac.Patronimic;
                _originalPac.Birthday = _editingPac.Birthday;
                _originalPac.PhoneNumber = _editingPac.PhoneNumber;

                _originalPac.SaveChanges();

                MessageBox.Show("Изменения сохранены", "Успешно");
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void ResetPacientBtn_Click(object sender, RoutedEventArgs e)
        {
            _editingPac.Reset();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
