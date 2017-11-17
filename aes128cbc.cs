using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Blowfish
{
    public class AES
    {
        /// <summary>  

        /// AES加密  

        /// </summary>  

        /// <param name="encryptStr">明文</param>  

        /// <param name="key">密钥</param>  

        /// <returns></returns>  

        public static string Encrypt(string encryptStr, string key)

        {

            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(key);

            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(encryptStr);


            RijndaelManaged rDel = new RijndaelManaged();

            rDel.Key = keyArray;

            rDel.IV = keyArray;

            rDel.Mode = CipherMode.CBC;

            rDel.Padding = PaddingMode.PKCS7;


            ICryptoTransform cTransform = rDel.CreateEncryptor();

            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);


            return Convert.ToBase64String(resultArray, 0, resultArray.Length);

        }


        /// <summary>  

        /// AES解密  

        /// </summary>  

        /// <param name="decryptStr">密文</param>  

        /// <param name="key">密钥</param>  

        /// <returns></returns>  

        public static string Decrypt(string decryptStr, string key)

        {

            byte[] keyArray = UTF8Encoding.UTF8.GetBytes(key);

            byte[] toEncryptArray = Convert.FromBase64String(decryptStr);


            RijndaelManaged rDel = new RijndaelManaged();

            rDel.Key = keyArray;

            rDel.IV = keyArray;

            rDel.Mode = CipherMode.CBC;

            rDel.Padding = PaddingMode.PKCS7;


            ICryptoTransform cTransform = rDel.CreateDecryptor();

            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);


            return UTF8Encoding.UTF8.GetString(resultArray);

        }
    }
}







