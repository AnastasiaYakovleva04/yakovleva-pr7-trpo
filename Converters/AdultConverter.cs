using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace yakovleva_pr7.Converters
{
    public class AdultConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime birthday)
            {
                var today = DateTime.Today;
                var age = today.Year - birthday.Year;
                if (birthday.Date > today.AddYears(-age)) 
                    age--;

                return age >= 18 ? "совершеннолетний" : "несовершеннолетний";
            }
            return "";
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
