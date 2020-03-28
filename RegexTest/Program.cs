using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegexTest
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * 13812345678 - 11 digits
             * 
             * 137,138,139 china mobile
             * 130,131, china unicom
             * 180,189, china telecom
             * define a method: 
             * input: phonenumber, 
             * output:
             *  china unicom: 138-1234-5678
             *  or "invalid phone number"
             * 
             * 
             */

            Console.WriteLine(ParsePhoneNumber("13812345678"));
            Console.WriteLine(ParsePhoneNumber("18912345678"));
            Console.WriteLine(ParsePhoneNumber("18"));
            Console.WriteLine(ParsePhoneNumber("18812345678"));
            Console.WriteLine(ParsePhoneNumber("1891234567890"));
            Console.WriteLine(ParsePhoneNumber("hello"));

            ValidateEmail("jichen3@microsoft.com");
            ValidateEmail("jie.chen.prc@m._.mail.gmail.com");

        }

        private static void ValidateEmail(string email)
        {
            string pattern = @"^([\w.-]+)@([\w]+(.)?)+((.(\w){2,3})+)$";

            Regex reg = new Regex(pattern, RegexOptions.IgnoreCase);
            bool r = reg.IsMatch(email);

            Console.WriteLine($"{email} is valid email? {r}" );
            
        }

        static string ParsePhoneNumber(string phoneNumber)
        {
            string pattern = @"\b(1((3[01789])|(8[09])))(\d{4})(\d{4}\b)";
            //string pattern = @"\b(1\d{2})(\d{4})(\d{4})";
            var reg = new Regex(pattern);
            string vendor = "";
            string phoneNumber2 = "";
            MatchCollection mc = reg.Matches(phoneNumber);
            if (mc.Count == 1)
            {
                phoneNumber2 = $"{mc[0].Groups[1].Value}-{mc[0].Groups[5].Value}-{mc[0].Groups[6].Value}";
                switch (mc[0].Groups[1].Value.ToString())
                {
                    case "130":
                    case "131":
                        vendor = "China Unicom";
                        break;
                    case "137":
                    case "138":
                    case "139":
                        vendor = "China Mobile";
                        break;
                    case "180":
                    case "189":
                        vendor = "China Telecom";
                        break;
                    default:
                        vendor = "Unknown Vendor";
                        break;
                }
                return vendor + ": " + phoneNumber2;
            }
            else
            {
                return "invalid phone number";
            }


        }
    }
}
