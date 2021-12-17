using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShillohHillsCollege.Core.Util
{
    public class helper
    {
        public static string GenerateRandomString(int stringSize = 8)
        {
            string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string small_alphabets = "abcdefghijklmnopqrstuvwxyz";
            string numbers = "1234567890";

            string characters = numbers;
            characters += alphabets + small_alphabets + numbers;
            int length = stringSize;
            string otp = string.Empty;
            for (int i = 0; i < length; i++)
            {
                string character = string.Empty;
                do
                {
                    int index = new Random().Next(0, characters.Length);
                    character = characters.ToCharArray()[index].ToString();
                } while (otp.IndexOf(character) != -1);
                otp += character;
            }

            return otp;
        }

        public static bool IsPrincipalGrtThanPaid(decimal principalAmt, decimal amountPaid)
        {
            bool result = false;

            if(principalAmt > amountPaid)
            {
                result = true;
            }

            return result;
        }

        public static string FormatDate(string dateVal)
        {
            string result = "";

            if (!string.IsNullOrEmpty(dateVal))
            {
                if (dateVal.Contains('/'))
                {
                    var spltDate = dateVal.Split('/');
                    result = $"{spltDate[2]}-{spltDate[1]}-{spltDate[0]}";
                }
            }

            return result;
        }

        public static string FormatDateV2(DateTime dateVal)
        {
            string result = "";

            result = dateVal.ToString("yyyy-MM-dd");
            return result;
        }


        public static string EncodeToBase64(string plainText)
        {
            byte[] toEncodeAsBytes = Encoding.ASCII.GetBytes(plainText);
            string returnValue = System.Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }

        public static string DecodeFromBase64(string cipher)
        {
            byte[] encodedDataAsBytes = Convert.FromBase64String(cipher);
            string returnValue = Encoding.ASCII.GetString(encodedDataAsBytes);
            return returnValue;
        }

        //public static string RemoveLastCharacter(string info)
        //{
        //    //var rmvlStr = 
        //}


    }
}
