using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;  
namespace DataCollect.Panel
{
    class AES_Helper
    {
        ///// <summary>  
        ///// 256位AES加密  
        ///// </summary>  
        ///// <param name="toEncrypt"></param>  
        ///// <returns></returns>  
        //public  string Encrypt(string toEncrypt)
        //{
        //    // 256-AES key      
        //    byte[] keyArray =  {
        //                         0x60, 0x3d, 0xeb, 0x10, 0x15, 0xca, 0x71, 0xbe,
        //                         0x2b, 0x73, 0xae, 0xf0, 0x85, 0x7d, 0x77, 0x81,
        //                         0x1f, 0x35, 0x2c, 0x07, 0x3b, 0x61, 0x08, 0xd7,
        //                         0x2d, 0x98, 0x10, 0xa3, 0x09, 0x14, 0xdf, 0xf4
        //                        };
        //    byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

        //    RijndaelManaged rDel = new RijndaelManaged();
        //    rDel.Key = keyArray;
        //    rDel.Mode = CipherMode.ECB;
        //    rDel.Padding = PaddingMode.Zeros;

        //    ICryptoTransform cTransform = rDel.CreateEncryptor();
        //    byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

        //    return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        //}

        /// <summary>  
        /// 256位AES解密  
        /// </summary>  
        /// <param name="str">要解密的字符串</param>  
        /// <param name="key_32">长度为32的字符串密钥</param>  
        /// <returns>解密后的字符串</returns>
        public string Decrypt(string str,string key_32)
        {
            // AES key      
            byte[] keyArray = Encoding.Default.GetBytes(key_32);

            byte[] toEncryptArray = new byte[16];
            string[] bufstr=new string[16];
            string[] strs= new string[16];
            for (int i = 0; i < 16; i++)
            {
                bufstr[i] = str.Substring(i*2,2);
                toEncryptArray[i] = (byte)Convert.ToInt32(bufstr[i],16);
            
            }
            RijndaelManaged rDel = new RijndaelManaged();
            rDel.Key = keyArray;
            rDel.Mode = CipherMode.ECB;
            rDel.Padding = PaddingMode.Zeros;

            ICryptoTransform cTransform = rDel.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            strs = UTF8Encoding.UTF8.GetString(resultArray).Split('\0');
            return strs[0];
        }  
 

    }
}
