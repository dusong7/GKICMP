using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace BBT.Common
{
    public class CommonFunction
    {
        #region 加密、解密
        private static readonly string KEY = "gk.sismp";

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="encryptString">被加密的字符串</param>
        /// <returns></returns>
        public static string Encrypt(string encryptString)
        {
            try
            {
                using (MemoryStream encryptStream = new MemoryStream())
                {
                    DESCryptoServiceProvider desProvider = new DESCryptoServiceProvider();

                    desProvider.IV = ASCIIEncoding.UTF8.GetBytes(KEY);
                    desProvider.Key = ASCIIEncoding.UTF8.GetBytes(KEY);

                    using (CryptoStream cryptoStream = new CryptoStream(encryptStream, desProvider.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        byte[] encryptBuffer = Encoding.UTF8.GetBytes(encryptString);

                        cryptoStream.Write(encryptBuffer, 0, encryptBuffer.Length);
                        cryptoStream.FlushFinalBlock();
                        cryptoStream.Close();
                    }

                    StringBuilder encryptBuilder = new StringBuilder();

                    foreach (byte encryptByte in encryptStream.ToArray())
                    {
                        encryptBuilder.AppendFormat("{0:X2}", encryptByte);
                    }

                    encryptStream.Close();
                    return encryptBuilder.ToString();
                }
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="decryptString">被解密的字符串</param>
        /// <returns></returns>
        public static string Decrypt(string decryptString)
        {
            try
            {
                using (MemoryStream decryptStream = new MemoryStream())
                {
                    DESCryptoServiceProvider desProvider = new DESCryptoServiceProvider();

                    desProvider.IV = ASCIIEncoding.ASCII.GetBytes(KEY);
                    desProvider.Key = ASCIIEncoding.ASCII.GetBytes(KEY);

                    using (CryptoStream cryptoStream = new CryptoStream(decryptStream, desProvider.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        int decryptStringCount = decryptString.Length / 2;
                        byte[] decryptBuffer = new byte[decryptStringCount];

                        for (int x = 0; x < decryptStringCount; x++)
                        {
                            int i = (Convert.ToInt32(decryptString.Substring(x * 2, 2), 16));
                            decryptBuffer[x] = (byte)i;
                        }

                        cryptoStream.Write(decryptBuffer, 0, decryptBuffer.Length);
                        cryptoStream.FlushFinalBlock();
                        cryptoStream.Close();
                    }

                    decryptStream.Close();
                    return Encoding.UTF8.GetString(decryptStream.ToArray());
                }
            }
            catch
            {
                return string.Empty;
            }
        }


        #endregion
    }
}
