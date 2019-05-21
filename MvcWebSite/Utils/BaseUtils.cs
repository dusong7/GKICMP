using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace MvcWebSite.Utils
{
    public class BaseUtils
    {
        private static readonly string KEY = "gk.sismp";
        public string InitContent(string content)
        {
            string result = "";
            content = content.Replace("<br/>", "$%^%$");
            content = content.Replace("&nbsp;", "");
            bool isend = false;
            while (content.Length > 0 && !isend)
            {
                int first = content.IndexOf("<");
                if (first >= 0)
                {
                    result = result + content.Substring(0, first);
                    //content = content.Substring(first);
                    int last = content.IndexOf(">");
                    if (last < 0)
                    {
                        isend = true;
                    }
                    content = content.Substring(last + 1);
                }
                else
                {
                    content = "";
                }
            }
            result = result.Replace("$%^%$", "<br/>");
            return result;
        }

        public string Encrypt(string encryptString)
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

    }
}