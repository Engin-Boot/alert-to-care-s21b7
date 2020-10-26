using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GuiClient.ValidationRules
{
    public class PhoneNumberValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var phone = value as string;
            const string s2 = @"\d{10}";
            if (string.IsNullOrEmpty(phone))
            { return new ValidationResult(false, " Phone Number cannot be Empty."); }

            if (Regex.IsMatch(phone, s2))
                return new ValidationResult(true, "");
            return new ValidationResult(false, " Format : 9876543210");
        }

        //private bool IsPhoneNumber()
        //{
        //    const string s2 = @"\d{10}";
        //    const string s3 = @"\d{5}([- ]*)\d{6}";
        //    return Regex.IsMatch(phone, s3, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250))
        //        ? 
        //        : / 01552-784512
        //    return false;
        //}
    }
}
