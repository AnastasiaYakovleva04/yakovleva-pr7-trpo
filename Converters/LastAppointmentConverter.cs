using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace yakovleva_pr7.Converters
{
    public class LastAppointmentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is System.Collections.ObjectModel.ObservableCollection<AppointmentStory> stories)
            {
                if (stories.Count == 0)
                    return "Первый прием в клинике";

                var lastAppointment = stories.OrderByDescending(s => s.Date).FirstOrDefault();
                if (lastAppointment != null)
                {
                    var days = (DateTime.Now - lastAppointment.Date).Days;
                    return $"{days} дней назад";
                }
            }
            return "Первый прием в клинике";
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
