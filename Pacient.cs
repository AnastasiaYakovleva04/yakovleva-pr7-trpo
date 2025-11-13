using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace yakovleva_pr7
{
    public class Pacient : INotifyPropertyChanged
    {
        private int _id = 0;
        public int Id 
        {
            get => _id;
            set { _id = value; OnPropertyChanged(); } 
        }

        private string _name = "";
        public string Name 
        { 
            get => _name; 
            set { _name = value; OnPropertyChanged(); } 
        }

        private string _surname = "";
        public string Surname 
        { 
            get => _surname; 
            set { _surname = value; OnPropertyChanged(); } 
        }

        private string _patronimic = "";
        public string Patronimic 
        { 
            get => _patronimic; 
            set { _patronimic = value; OnPropertyChanged(); } 
        }

        private DateTime _birthday = new DateTime(1920, 01, 01);
        public DateTime Birthday 
        { 
            get => _birthday;
            set { _birthday = value; OnPropertyChanged(); } 
        }

        private string _phoneNumber = "";
        public string PhoneNumber
        {
            get => _phoneNumber;
            set { _phoneNumber = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Dictionary<int, Pacient> pacients = new Dictionary<int, Pacient>();
        public List<AppointmentStory> AppointmentStories { get; set; } = new List<AppointmentStory>();
        public Random rnd = new Random();
        public static Regex regexPhone = new Regex(@"^(\+7|8) \(\d{3}\) \d{3}-\d{2}-\d{2}$");

        //загрузка пациентов из json файлов
        public void LoadPacients()
        {
            string pacientDir = "Pacients";
            if (!Directory.Exists(pacientDir)) 
                return;

            string[] pacientFiles = Directory.GetFiles(pacientDir, "P_*.json");
            foreach (string file in pacientFiles)
            {
                var jsonString = File.ReadAllText(file);
                Pacient pacient = JsonSerializer.Deserialize<Pacient>(jsonString);
                pacients[pacient.Id] = pacient;
            }
        }

        //поиск пациента по id
        public void SearchPacient()
        {
            if (pacients.ContainsKey(Id))
            {
                var foundPacient = pacients[Id];
                Name = foundPacient.Name;
                Surname = foundPacient.Surname;
                Patronimic = foundPacient.Patronimic;
                Birthday = foundPacient.Birthday;
            }
            else
                throw new ArgumentException("Пациент с таким ID не найден");
        }

        //сохранение изменений при редактировании информации о пациенте
        public void SaveChanges()
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Surname))
                throw new ArgumentException("Имя и фамилия обязательны");

            if (!regexPhone.IsMatch(PhoneNumber))
                throw new ArgumentException("Поле номер телефона должен быть формата 'X (XXX) XXX-XX-XX'");

            pacients[Id] = this;

            var jsonString = JsonSerializer.Serialize(this);
            var path = Path.Combine("Pacients", $"P_{Id}.json");
            File.WriteAllText(path, jsonString, Encoding.UTF8);
        }

        //сброс информации о пациенте
        public void Reset()
        {
            Name = Surname = Patronimic = "";
            Birthday = DateTime.MinValue;
        }
    }
}
