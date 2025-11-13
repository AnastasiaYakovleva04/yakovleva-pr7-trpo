using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yakovleva_pr7
{
    public class AppointmentStory
    {
        public DateTime Date { get; set; } = DateTime.Today;
        public int DoctorId { get; set; } = 0;
        public string Diagnosis { get; set; } = "";
        public string Recommendations { get; set; } = "";
    }
}
