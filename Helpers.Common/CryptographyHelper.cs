using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.Common
{
    public static class CryptographyHelper
    {
        public static byte[] Encrypt(string str, byte[] key, byte[] iv)
        {
            if (str == null || str == string.Empty)
            {
                throw new ArgumentNullException($"Encript string is empty: {str}");
            }
            if (key == null || key.Length <= 0)
            {
                throw new ArgumentNullException("Encript key is not correct");
            }
            if (iv == null || iv.Length <= 0)
            {
                throw new ArgumentNullException("Encript iv is not correct");
            }
            byte[] encrypted;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(str);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            return encrypted;
        }
        public static string Decrypt(byte[] str, byte[] key, byte[] iv)
        {
            if (str == null)
            {
                throw new ArgumentNullException($"Encript string is empty: {str}");
            }
            if (key == null || key.Length <= 0)
            {
                throw new ArgumentNullException("Encript key is not correct");
            }
            if (iv == null || iv.Length <= 0)
            {
                throw new ArgumentNullException("Encript iv is not correct");
            }
            string text = null;
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msDecrypt = new MemoryStream(str))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            text = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            return text;
        }
    }
}
