using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chifers_K
{
    class Monoalphaptic
    {
        public static string Encrypt(string plainText, string keyy)
        {
            char[] chars = new char[plainText.Length];
            for (int i = 0; i < plainText.Length; i++)
            {
                if (plainText[i] == ' ')
                {
                    chars[i] = ' ';
                }

                else
                {
                    int j = plainText[i] - 97;
                    chars[i] = keyy[j];
                }
            }

            return new string(chars);
        }


        public static string reverse(string cipherText)
        {
            char[] charArray = cipherText.ToCharArray();
            Array.Reverse(charArray);

            return new string(charArray);
        }


        public static string Decrypt(string cipherText, string key)
        {
            char[] chars = new char[cipherText.Length];
            for (int i = 0; i < cipherText.Length; i++)
            {
                if (cipherText[i] == ' ')
                {
                    chars[i] = ' ';
                }
                else
                {
                    int j = key.IndexOf(cipherText[i]) + 97;
                    chars[i] = (char)j;
                }
            }
            return new string(chars);
        }
    }
}
