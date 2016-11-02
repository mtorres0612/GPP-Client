using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GPPUtilities
{
    public class Utility
    {
        public static string Encrypt(string ToEncrypt)
        {
            string password;
            TripleDESCryptoServiceProvider des;
            MD5CryptoServiceProvider hashmd5;
            byte[] pwdhash, buff;

            //"Project Title" = Private key
            password = "Gpp!N+3rf@c3";

            hashmd5 = new MD5CryptoServiceProvider();
            pwdhash = hashmd5.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(password));
            hashmd5 = null;


            des = new TripleDESCryptoServiceProvider();


            des.Key = pwdhash;
            des.Mode = CipherMode.ECB;
            buff = System.Text.ASCIIEncoding.ASCII.GetBytes(ToEncrypt);


            return Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buff, 0, buff.Length));
        }

        public static string Decrypt(string ToDecrypt)
        {
            if (ToDecrypt == "")
                return "";

            byte[] pwdhash, buff;
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            //"Project Title" = Private key
            string password = "Gpp!N+3rf@c3";
            buff = Convert.FromBase64String(ToDecrypt);
            pwdhash = hashmd5.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(password));

            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            des.Key = pwdhash;
            des.Mode = CipherMode.ECB;

            return System.Text.ASCIIEncoding.ASCII.GetString(des.CreateDecryptor().TransformFinalBlock(buff, 0, buff.Length));


        }

        public static bool CheckForStrongPassword(string password)
        {
            //Passwords will contain at least (1) upper case letter
            //Passwords will contain at least (1) lower case letter
            //Passwords will contain at least (1) number or special character
            //Passwords will contain at least (8) characters in length
            //Password maximum length should not be arbitrarily limited

            if (Regex.IsMatch(password, @"(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$"))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public static string ConvertStringToQuery(string Sentence)
        {
            return Sentence.Replace("'", "''");
        }
    }
}
