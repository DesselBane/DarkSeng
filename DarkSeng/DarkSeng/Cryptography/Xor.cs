using System;
using System.Text;

namespace DarkSeng.Cryptography
{
    public class Xor
    {
        /// <summary>
        /// Xor encrypts or decrypts a given text with the given password
        /// </summary>
        /// <param name="password"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static byte[] Cipher(byte[] password, byte[] content)
        {
            byte[] encryptedContent = new byte[content.Length];

            for (int i = 0, pwCount = 0; i < content.Length; i++, pwCount++)
            {
                if (pwCount == password.Length) pwCount = 0;

                encryptedContent[i] = (byte)(content[i] ^ password[pwCount]);
            }

            return encryptedContent;
        }

        /// <summary>
        /// Overload for Xor encryption. Uses Unicode encoding.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static byte[] Cipher(string password, string content)
        {
            return Cipher(Encoding.Unicode.GetBytes(password), Encoding.Unicode.GetBytes(content));
        }
    }
}
