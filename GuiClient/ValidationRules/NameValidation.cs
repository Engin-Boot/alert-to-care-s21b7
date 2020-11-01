using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace GuiClient.ValidationRules
{
    public class NameValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var name = value as string;
            const string s1 = @"!|@|#|\$|%|\?|\>|\<|\*";
            if (string.IsNullOrEmpty(name))
            {
                return new ValidationResult(false, " This field cannot be Empty.");
            }

            return Regex.IsMatch(name, s1, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250))
                ? new ValidationResult(false, " This field cannot contain Special Characters.")
                : new ValidationResult(true, "");
        }
    }
}