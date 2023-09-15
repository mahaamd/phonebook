using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace test
{
    public static class CheckRegex
    {// o9 11 680 30 55
        // for fax +1-907-555-1234
        public static bool IsValid(this string x,DataType inputValue)
        {

        //Address,
        //CompanyName,


            bool isValid = true;
            if (inputValue == DataType.Mobile)
            {
                string regex = @"[0][9][0-9]{9}";
                isValid = Regex.IsMatch(x, regex);
            }
            else if (inputValue == DataType.Fax)
            {
                string regex = @"[+][1][-]\d{3}[-]\d{3}[-]\d{4}";
                isValid = Regex.IsMatch(x, regex);
            }
            else if (inputValue == DataType.Age)
            {
                string regex = @"\d+";
                isValid = Regex.IsMatch(x, regex);
            }
            else if (inputValue == DataType.Tell)
            {
                string regex = @"[0][0-9]{2}[0-9]{8}";
                isValid = Regex.IsMatch(x, regex);
            }
            else if (DataType.Name == inputValue)
            {
                string regex = @"[a-zA-Z]{3,}";
                isValid = Regex.IsMatch(x, regex);
            }
            else if (inputValue == DataType.Family)
            {
                string regex = @"[a-zA-Z]{2,}";
                isValid = Regex.IsMatch(x, regex);
            }
            else if (inputValue == DataType.ShomareSabt)
            {
                string regex = @"[0-9]+";
                isValid = Regex.IsMatch(x, regex);
            }
            else if (inputValue == DataType.Code)
            {
                string regex = @"[0-9]+";
                isValid = Regex.IsMatch(x, regex);
            }
            return isValid;
        }
    }
}
