using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace yakovleva_pr7.ValidationRules
{
    public class OnlyLettersRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();

            foreach (char c in input)
            {
                if (!char.IsLetter(c))
                    return new ValidationResult(false, "Поле должно содержать только буквы");
            }

            return ValidationResult.ValidResult;
        }
    }
}
