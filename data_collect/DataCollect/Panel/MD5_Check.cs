using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
namespace DataCollect.Panel
{
    class MD5_Check
    {
       
        public string Randomstr(int len)
        {
            
       
            List<string> strList = new List<string>();//创建一个存放A到Z，0到9的字符串列表
            for (int i = 65; i <= 90; i++)
            {
                char aa = (char)i;
                strList.Add(aa.ToString());//把A到Z放到列表中
            }
            char[] number = new char[10];//把0到9字符存入字符数组中
            for (int i = 48; i <= 57; i++)
            {
                char aa = (char)i;
                strList.Add(aa.ToString());//把A到Z放到列表中
                number[i - 48] = aa;
            }

            string resultStr = null;
            for (int i = 0; i < len; i++)
            {
                Random random = new Random();
                int index = random.Next(strList.Count);
                resultStr = resultStr + strList[index];
                strList.RemoveAt(index);
            }


            return resultStr;
 
        }
        public string md5creat(string str)
        {
            string cl = str;// + "12345678901234567890123456789012";
            string pwd = "";
            MD5 md5 = MD5.Create();//实例化一个md5对像
            // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
            // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
           // System.Text.ASCIIEncoding ASCII = new System.Text.ASCIIEncoding();
          // pwd = ASCII.GetString(s);
            for (int i = 0; i < s.Length; i++)
            {
                // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符 

                pwd = pwd + s[i].ToString("X2");

            }
            return pwd;

        }


    }
}
