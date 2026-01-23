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
using MaterialDesignThemes.Wpf;

namespace yakovleva_pr7
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new LoginPage());
            if (ThemeHelper.Current == "Styles/Theme/LigthTheme.xaml")
                ThemeIcon.Kind = PackIconKind.BedTime;
            else
                ThemeIcon.Kind = PackIconKind.WbSunny;
        }
        private void ChangeTheme_Click(object sender, RoutedEventArgs e)
        {
            if (ThemeHelper.Current == "Styles/Theme/LigthTheme.xaml")
                ThemeIcon.Kind = PackIconKind.WbSunny;
            else
                ThemeIcon.Kind = PackIconKind.NightLight;
            ThemeHelper.Toggle();
        }
    }
}