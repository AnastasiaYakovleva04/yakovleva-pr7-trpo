using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace yakovleva_pr7.ValidationRules
{
    public class IsNumberRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();

            if (!int.TryParse(input, out int intValue))
                return new ValidationResult(false, "Поле должно содержать только цифры");

            return ValidationResult.ValidResult;
        }
    }
}
