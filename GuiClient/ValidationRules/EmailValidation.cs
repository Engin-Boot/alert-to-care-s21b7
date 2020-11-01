using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace GuiClient.ValidationRules
{
    public class EmailValidation:ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {

            var email = value as string;
            //const string s1 = @"^([\w]+\.+[\w]+@[\w]+\.[a-zA-Z]{3})$";
            const string s3 = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            //const string s2 = @"^[\w]+@+[\w]+\.[a-zA-Z]{3}$";

            if (string.IsNullOrEmpty(email))
            {return new ValidationResult(false, " Email cannot be Empty.");}
            return Regex.IsMatch(email, s3, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)) 
                ? new ValidationResult(true,"") 
                : new ValidationResult(false, " Format : abc@xyz.com");
        }
    }
}
