using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.IO;

namespace yakovleva_pr7
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronimic { get; set; }
        public string Specialization { get; set; }
        public string Password { get; set; }
        
        private Dictionary<int, string> ids = new Dictionary<int, string>();
        private static bool isLoaded = false;
        public Doctor() { }

        public Random rnd = new Random();

        public void LoadDoctors()
        {
            string[] doctorFiles = Directory.GetFiles(Directory.GetCurrentDirectory(), "D_*.json");

            foreach (string file in doctorFiles)
            {
                string jsonString = File.ReadAllText(file);
                Doctor doctor = JsonSerializer.Deserialize<Doctor>(jsonString);
                ids[doctor.Id] = doctor.Password;
            }
        }
        public void Registration(string name, string surname, string patronimic, string specialization, string password, string confPass)
        {
            if (name == "" || surname == "" || patronimic == "" || specialization == "" || password == "" || confPass == "")
                throw new ArgumentException("Все поля должны быть заполнены");
            
            if (password != confPass)
                throw new ArgumentException ("Пароли не совпадают");
              
            int id;
            do { id = rnd.Next(10000, 100000); }
            while (ids.ContainsKey(id));
            Id = id;
            Name = name;
            Surname = surname;
            Patronimic = patronimic;
            Specialization = specialization;
            Password = password;
            ids[id] = password;
            
        }

        public void Login(string id, string password)
        {
            if (id == "" && password == "")
                throw new ArgumentException("Все поля должны быть заполнены");

            if (!int.TryParse(id, out int ID))
                throw new FormatException("Некорректный ввод ID");

            if (!ids.ContainsKey(ID) || ids[ID] != password)
                throw new ArgumentException("Неверный логин или пароль");


            var path = $"D_{ID}.json"; 
            if (!File.Exists(path))
                throw new FileNotFoundException("Пользователь не найден");

            var jsonString = File.ReadAllText(path);
            Doctor doctor = JsonSerializer.Deserialize<Doctor>(jsonString);

            this.Id = doctor.Id;
            this.Name = doctor.Name;
            this.Surname = doctor.Surname;
            this.Patronimic = doctor.Patronimic;
            this.Specialization = doctor.Specialization;
            this.Password = doctor.Password;
        }
    }
}
