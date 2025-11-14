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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public ObservableCollection<Pacient> Pacients { get; set; } = new();
        public Pacient? SelectedPacient { get; set; }
        Doctor doc;
        Pacient pac;
        SystemStatus sys { get; set; } = new();
        public MainPage(Doctor doc)
        {
            InitializeComponent();
            this.doc = doc;
            pac = new Pacient();

            sys.UpdateCounts();
            pac.LoadPacients();
            foreach (Pacient pacient in pac.pacients.Values)
                Pacients.Add(pacient);
            DataContext = this;
            DocInfoPanel.DataContext = doc;
            SystemStatusPanel.DataContext = sys;
        }

        private void AddPacientBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPacientPage(doc, Pacients));
        }

        private void EditPacientBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedPacient == null)
            {
                MessageBox.Show("Пациент не выбран");
                return;
            }
            NavigationService.Navigate(new EditPacientPage(Pacients, SelectedPacient));
        }

        private void StartAddmissionBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedPacient == null)
            {
                MessageBox.Show("Пациент не выбран");
                return;
            }
            NavigationService.Navigate(new AddmissionPacientPage(SelectedPacient, doc));
        }
    }
}
