using ICSharpCode.SharpZipLib.Zip;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK.GKICMP.Common
{
    public class Compress
    {
        #region 解压文件
        /// <summary>
        /// 解压文件
        /// </summary>
        /// <param name="fileFromUnZip">解压前的文件路径（绝对路径）</param>
        /// <param name="fileToUnZip">解压后的文件目录（绝对路径）</param>
        public static void UnpackFile(string fileFromUnZip, string fileToUnZip)
        {
            //获取压缩类型
            string unType = fileFromUnZip.Substring(fileFromUnZip.LastIndexOf(".") + 1, 3).ToLower();
            switch (unType)
            {
                case "rar":
                    UnRar(fileFromUnZip, fileToUnZip);
                    break;
                case "zip":
                    UnZip(fileFromUnZip, fileToUnZip);
                    break;
            }
        }
        //解压rar格式的文件
        private static void UnRar(string fileFromUnZip, string fileToUnZip)
        {
            using (Process Process1 = new Process())// 开启一个进程 执行解压工作
            {
                string ServerDir = ConfigurationManager.AppSettings["UnpackFile"].ToString();//rar工具的安装路径   必须要安装 WinRAR     //例于：C:\Program Files (x86)\WinRAR\RAR.exe
                Process1.StartInfo.UseShellExecute = false;
                Process1.StartInfo.RedirectStandardInput = true;
                Process1.StartInfo.RedirectStandardOutput = true;
                Process1.StartInfo.RedirectStandardError = true;
                Process1.StartInfo.CreateNoWindow = true;
                Process1.StartInfo.FileName = ServerDir;
                Process1.StartInfo.Arguments = " x -inul -y " + fileFromUnZip + " " + fileToUnZip;
                Process1.Start();//解压开始  
                Process1.WaitForExit();
                Process1.Close();
            }
        }
        // 解压zip 文件
        //public static void UnZip(string fileFromUnZip, string fileToUnZip)
        //{
        //    ZipInputStream inputStream = new ZipInputStream(File.OpenRead(fileFromUnZip));
        //    ZipEntry theEntry = new ZipEntry("cc");
        //    while ((theEntry = inputStream.GetNextEntry()) != null)
        //    {
        //        fileToUnZip += "/";
        //        string fileName = Path.GetFileName(theEntry.Name);
        //        string path = Path.GetDirectoryName(fileToUnZip) + "/";
        //        // Directory.CreateDirectory(path);//生成解压目录
        //        if (fileName != String.Empty)
        //        {
        //            FileStream streamWriter = File.Create(path + fileName);//解压文件到指定的目录 
        //            int size = 2048;
        //            byte[] data = new byte[2048];
        //            while (true)
        //            {
        //                size = inputStream.Read(data, 0, data.Length);
        //                if (size > 0)
        //                {
        //                    streamWriter.Write(data, 0, size);
        //                }
        //                else
        //                {
        //                    break;
        //                }
        //            }
        //            streamWriter.Close();
        //        }
        //    }
        //    inputStream.Close();
        //}
        #endregion
        #region 解压

        /// <summary>   
        /// 解压功能(解压压缩文件到指定目录)   
        /// </summary>   
        /// <param name="fileToUnZip">待解压的文件</param>   
        /// <param name="zipedFolder">指定解压目标目录</param>   
        /// <param name="password">密码</param>   
        /// <returns>解压结果</returns>   
        public static bool UnZip(string fileToUnZip, string zipedFolder, string password)
        {
            bool result = true;
            FileStream fs = null;
            ZipInputStream zipStream = null;
            ZipEntry ent = null;
            string fileName;

            //if (!File.Exists(fileToUnZip))
            //{
            //    System.IO.File.Delete(fileToUnZip);
            //} 

            if (!Directory.Exists(zipedFolder))
                Directory.CreateDirectory(zipedFolder);

            try
            {
                zipStream = new ZipInputStream(File.OpenRead(fileToUnZip));
                if (!string.IsNullOrEmpty(password)) zipStream.Password = password;
                while ((ent = zipStream.GetNextEntry()) != null)
                {
                    if (!string.IsNullOrEmpty(ent.Name))
                    {
                        fileName = Path.Combine(zipedFolder, ent.Name);
                        fileName = fileName.Replace('/', '\\');//change by Mr.HopeGi   

                        if (fileName.EndsWith("\\"))
                        {
                            Directory.CreateDirectory(fileName);
                            continue;
                        }

                        fs = File.Create(fileName);
                        int size = 2048;
                        byte[] data = new byte[size];
                        while (true)
                        {
                            size = zipStream.Read(data, 0, data.Length);
                            if (size > 0)
                                fs.Write(data, 0, data.Length);
                            else
                                break;
                        }
                    }
                }
            }
            catch
            {
                result = false;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                }
                if (zipStream != null)
                {
                    zipStream.Close();
                    zipStream.Dispose();
                }
                if (ent != null)
                {
                    ent = null;
                }
                GC.Collect();
                GC.Collect(1);
            }
            return result;
        }

        /// <summary>   
        /// 解压功能(解压压缩文件到指定目录)   
        /// </summary>   
        /// <param name="fileToUnZip">待解压的文件</param>   
        /// <param name="zipedFolder">指定解压目标目录</param>   
        /// <returns>解压结果</returns>   
        public static bool UnZip(string fileToUnZip, string zipedFolder)
        {
            bool result = UnZip(fileToUnZip, zipedFolder, null);
            return result;
        }
        public static string uncompress(string rarfilepath, string filepath)
        {
            try
            {
                string rar;
                RegistryKey reg;
                string args;
                ProcessStartInfo startInfo;
                Process process;
                reg = Registry.ClassesRoot.OpenSubKey("applications/WinRar.exe/Shell/Open/Command");//WinRar位置  
                rar = reg.GetValue("").ToString();
                reg.Close();
                rar = rar.Substring(1, rar.Length - 7);
                args = " X " + rarfilepath + " " + filepath;
                startInfo = new ProcessStartInfo();
                startInfo.FileName = rar;
                startInfo.Arguments = args;
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process = new Process();
                process.StartInfo = startInfo;
                process.Start();
                return "success";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        } 

        #endregion  
    }
}
