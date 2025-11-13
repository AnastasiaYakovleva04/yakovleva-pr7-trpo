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
using yakovleva_pr7.Pages;

namespace yakovleva_pr7
{
    public partial class MainWindow : Window
    {
        //public Doctor doc;
        //public Pacient pacAdd;  
        //public Pacient pacWork;
        //public SystemStatus sys;

        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new LoginPage());
        }
    }
}