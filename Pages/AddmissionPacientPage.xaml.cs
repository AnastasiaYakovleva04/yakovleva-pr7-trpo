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
    /// Логика взаимодействия для AddmissionPacientPage.xaml
    /// </summary>
    public partial class AddmissionPacientPage : Page
    {
        Pacient pac;
        Doctor doc;
        AppointmentStory pacAS;
        public ObservableCollection<AppointmentStory> PacientAppointmentStory { get; set; } = new();
        public AddmissionPacientPage(Pacient pac, Doctor doc)
        {
            InitializeComponent();

            this.doc = doc;
            this.pac = pac;
            pacAS = new AppointmentStory();

            foreach (AppointmentStory appointment in pac.AppointmentStories)
                PacientAppointmentStory.Add(appointment);

            DataContext = this;
            PacInfoPanel.DataContext = pac;
            AddmissionPanel.DataContext = pacAS;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void SaveAddmissionBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                doc.Addmission(pac, pacAS.Date, doc.Id, pacAS.Diagnosis, pacAS.Recommendations);
                NavigationService.GoBack();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }
    }
}
