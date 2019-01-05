using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ExcelRead
{
    /// <summary>
    /// DES 加密和解秘
    /// </summary>
    class Encryption_Decryption
    {
        public static byte[] Key
        {
            set { Key = value; }
            get
            {
                return new byte[] { 71, 72, 83, 84, 85, 96, 97, 78,
                10,4,6,7,8,9,0,33,
                71, 72, 83, 84, 85, 96, 97, 78};
            }
        }
        public static byte[] IV
        {
            set { IV = value; }
            get { return new byte[] { 71, 72, 83, 84, 85, 96, 97, 78 }; }
        }

        //<3、 加密操作 >
        //加密的原料是明文字节流，
        //TripleDES算法对字节流进行加密，
        //返回的是加密后的字节流。
        //同时要给定加密使用的key和IV。
        // 把字符串明文转换成utf-8编码的字节流

        /// <summary>
        /// 将一个明文的二进制流转换成一个加密的二进制流
        /// </summary>
        /// <param name="strArray">一个明文的二进制数据流，其实也就是你要加密的字符串的二进制形式的数据流</param>
        /// <returns>返回一个加密后是二进制数据流</returns>
        public static byte[] EncryptString(byte[] strArray)
        {
            //建立一个MemoryStream,这里面存放加密后的数据流
            MemoryStream mStream = new MemoryStream();
            //使用MemoryStream和key,IV新建一个CryptoStream对象  
            CryptoStream cStream = new CryptoStream(mStream, 
                new TripleDESCryptoServiceProvider().CreateEncryptor(Key, IV),
                CryptoStreamMode.Write);
            //将加密后的字节流写入到MemoryStream
            cStream.Write(strArray, 0, strArray.Length);
            //把缓冲区中的最后状态更新到MemoryStream，并清除cStream的缓存区
            cStream.FlushFinalBlock();
            // 把解密后的数据流转成字节流
            byte[] ret = mStream.ToArray();
            //关闭两个streams
            cStream.Close();
            mStream.Close();
            return ret;
        }



        //<4、 解密操作 >
        //解密操作解密上面步骤生成的密文byte[]，需要使用到加密步骤使用的同一组Key和IV。


        /// <summary>
        /// 将一个加密后的二进制数据流进行解密，产生一个明文的二进制数据流
        /// </summary>
        /// <param name="EncryptedDataArray">加密后的数据流</param>
        /// <returns>一个已经解密的二进制流</returns>
        public static byte[] DecryptTextFromMemory(byte[] EncryptedDataArray)
        {
            // 建立一个MemoryStream，这里面存放加密后的数据流
            MemoryStream msDecrypt = new MemoryStream(EncryptedDataArray);
            // 使用MemoryStream 和key、IV新建一个CryptoStream 对象
            CryptoStream csDecrypt = new CryptoStream(msDecrypt,
                new TripleDESCryptoServiceProvider().CreateDecryptor(Key, IV),
                CryptoStreamMode.Read);
            // 根据密文byte[]的长度（可能比加密前的明文长），新建一个存放解密后明文的byte[]
            byte[] DecryptDataArray = new byte[EncryptedDataArray.Length];
            // 把解密后的数据读入到DecryptDataArray
            csDecrypt.Read(DecryptDataArray, 0, DecryptDataArray.Length);
            msDecrypt.Close();
            csDecrypt.Close();
            return DecryptDataArray;
        }

        //加密操作 utf-8码
        public static String MingToMi(string strMing)
        {
            byte[] byteArrMi = Encryption_Decryption.EncryptString(
                      Encoding.UTF8.GetBytes(strMing));
             string strMi = Encoding.UTF8.GetString(byteArrMi);
            return strMi;
        }
    }
}
