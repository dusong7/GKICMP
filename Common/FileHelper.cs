using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK.GKICMP.Common
{
    /// <summary>
    /// 文件帮助类
    /// </summary>
    public class FileHelper
    {
        /// <summary>
        /// 取得文件名而去除路径
        /// </summary>
        /// <param name="filePathName"></param>
        /// <returns></returns>
        public static String GetFileNameWithoutPath(String filePathName)
        {
            String[] dirs = filePathName.Split('\\');
            return dirs[dirs.Length - 1];
        }

        /// <summary>
        /// 判断文件目录是否存在
        /// </summary>
        /// <param name="folder"></param>
        /// <returns></returns>
        public static bool IsFodlerExist(String folder)
        {
            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(folder);
                return directoryInfo.Exists;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 判断文件是否存在
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool IsFileExist(String filePath)
        {
            return File.Exists(filePath);
        }

        /// <summary>
        /// 拷贝文件具体函数
        /// </summary>
        /// <param name="fileFrom"></param>
        /// <param name="fileTo"></param>
        public static void CopyFile(String fileFrom, String fileTo)
        {
            String[] folders = fileTo.Split('\\');

            String dir = folders[0];
            for (int i = 1; i < folders.Length - 1; i++)
            {
                dir += "\\" + folders[i];

                MakeWhenFolderNotExist(dir);
            }

            File.Copy(fileFrom, fileTo);
        }

        /// <summary>
        /// 如果路径不存在即创建这个路径
        /// </summary>
        /// <param name="folder"></param>
        public static void MakeWhenFolderNotExist(String folder)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(folder);
            if (directoryInfo.Exists == false)
            {
                directoryInfo.Create();
            }
        }

        /// <summary>
        /// 如果文件不存在即创建这个文件
        /// </summary>
        /// <param name="filePath"></param>
        public static void MakeWhenFileNotExist(String filePath)
        {
            if (!File.Exists(filePath))
            {
                FileStream f = File.Create(filePath);
                f.Close();
            }
        }

        /// <summary>
        /// 取得文件扩展名
        /// </summary>
        /// <param name="root"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public static String GetFileExtension(String root, String file)
        {
            FileInfo fileInfo = new FileInfo(root + "\\" + file);
            return fileInfo.Extension;
        }

        /// <summary>
        /// 删除指定的文件
        /// </summary>
        /// <param name="root"></param>
        /// <param name="file"></param>
        public static void DeleteFile(String root, String file)
        {
            DeleteFile(root + "\\" + file);
        }

        /// <summary>
        /// 删除指定的文件
        /// </summary>
        /// <param name="filePath"></param>
        public static void DeleteFile(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            if (fileInfo.Exists)
            {
                fileInfo.Delete();
            }
        }

        /// <summary>
        /// 获得指定目录下的所有文件和文件夹的名称
        /// </summary>
        /// <param name="dirPath"></param>
        /// <returns></returns>
        public static string GetFileNameByFixedDir(string dirPath)
        {
            string returnVal = "";  //返回值

            FileInfo fi;
            DirectoryInfo dir;

            //针对当前目录建立目录引用对象
            DirectoryInfo dirInfo = new DirectoryInfo(dirPath);

            //循环判断当前目录下的文件和目录
            foreach (FileSystemInfo fsi in dirInfo.GetFileSystemInfos())
            {

                //如果是文件
                if (fsi is FileInfo)
                {
                    fi = (FileInfo)fsi;
                    returnVal += fi.Name + ",";
                }

                //否则是目录
                else
                {
                    dir = (DirectoryInfo)fsi;
                    returnVal += dir.Name + ",";
                }
            }
            if (returnVal != "" && returnVal.EndsWith(","))
            {
                returnVal = returnVal.Substring(0, returnVal.Length - 1);
            }

            return returnVal;
        }

        /// <summary>
        /// 在指定的路径下获得所有指定类型的文件
        /// </summary>
        /// <param name="path">获取文件所在的路径</param>
        /// <param name="fileType">要获取的文件类型</param>
        /// <returns></returns>
        public static FileInfo[] GetAllFilsByType(string path, string fileType)
        {
            if (!IsFodlerExist(path))
            {
                throw new Exception("指定的路径：" + path + " 不存在");
            }

            DirectoryInfo di = new DirectoryInfo(path);
            return di.GetFiles("*." + fileType.Trim('.'));
        }

        /// <summary>
        /// 读取指定文件的内容
        /// </summary>
        /// <param name="fileName">待读取的文件所在的物理地址</param>
        /// <returns>文件内容</returns>
        public static string ReadFileContent(string fileName)
        {
            StreamReader objReader = new StreamReader(fileName, Encoding.Default);

            return objReader.ReadToEnd();
        }

        /// <summary>
        /// 按照指定的路径信息、文件名称以及内容创建文件
        /// </summary>
        /// <param name="pathInfo">路径信息</param>
        /// <param name="fileName">文件名称</param>
        /// <param name="content">文件内容</param>
        /// <param name="deleteExistFile">是否删除已经存在的文件</param>
        public static void CreateFileWithContent(string pathInfo, string fileName, string content, bool deleteExistFile)
        {
            MakeWhenFolderNotExist(pathInfo);

            string path = pathInfo.TrimEnd('/').TrimEnd('\\') + "/" + fileName;

            if (IsFileExist(path) && deleteExistFile)
            {
                DeleteFile(path);
            }

            MakeWhenFileNotExist(path);

            StreamWriter sw = File.AppendText(path);
            sw.WriteLine(content);
            sw.Flush();
            sw.Close();
        }
    }
}
