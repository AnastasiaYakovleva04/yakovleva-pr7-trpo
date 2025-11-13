using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace yakovleva_pr7
{
    public class SystemStatus:INotifyPropertyChanged
    {

        private int _doctorsCount = 0;
        public int DoctorsCount
        {
            get => _doctorsCount;
            set { _doctorsCount = value; OnPropertyChanged(); }
        }

        private int _pacientsCount = 0;
        public int PacientsCount
        {
            get => _pacientsCount;
            set { _pacientsCount = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void UpdateCounts()
        {
            string doctorsDir = "Doctors";
            if (Directory.Exists(doctorsDir))
            {
                string[] doctorFiles = Directory.GetFiles(doctorsDir, "D_*.json");
                DoctorsCount = doctorFiles.Length;
            }
            else
                DoctorsCount = 0;

            string pacientsDir = "Pacients";
            if (Directory.Exists(pacientsDir))
            {
                string[] pacientFiles = Directory.GetFiles(pacientsDir, "P_*.json");
                PacientsCount = pacientFiles.Length;
            }
            else
                PacientsCount = 0;
        }
    }
}
