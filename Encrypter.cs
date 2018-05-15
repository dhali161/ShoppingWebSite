using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace FinalGroupProject
{
    public class Encrypter
    {
        /// <summary>
        /// It encrypts the plain text using MD5 algorithm
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public static string EncryptText(string plainText)
        {
            // declare the required objects
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            ASCIIEncoding ascii = new ASCIIEncoding();
            StringBuilder str = new StringBuilder();
            byte[] hash = new byte[32];

            // encrypt the plain text
            hash = md5.ComputeHash(ascii.GetBytes(plainText));

            // repeat the encryption for 100 times
            for (int i = 0; i < 100; i++)
                hash = md5.ComputeHash(hash);

            // loop through the hash and convert each encrypted character to hexadecimal
            // and append it to the string builder object
            for (int i = 0; i < hash.Length; i++)
            {
                str.Append(hash[i].ToString("X2"));
            }

            return str.ToString();
        }

    }
}