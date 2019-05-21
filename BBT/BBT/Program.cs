using BBT.Common;
using BBT.Model;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BBT
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!Directory.Exists("c:/gkdz"))//如果不存在就创建file文件夹
            {
                Directory.CreateDirectory("c:/gkdz");
            }
            Process instance = RunningInstance();  
            if (instance !=null )  
            {
                if (instance.MainWindowHandle.ToInt32() == 0) //是否托盘化  
                {
                    MessageBox.Show("123");
                    HandleRunningInstance(instance);
                    return;
                }
                //1.2 已经有一个实例在运行  
                HandleRunningInstance(instance);  
                return;  
            }
            string g = Win32API.INIGetStringValue("C:/gkdz/Config.ini", "Desktop", "URL", "");
            //MessageBox.Show(Application.StartupPath);
            if (g == "")
            {
                Set();
                Application.Run(new BBT_Register());
            }
            else
            {
                try
                {
                    //Set();
                    WebReference.WebService ws = new WebReference.WebService();
                    ws.Url = g + "/WebService.asmx";
                    string MAC = Win32API.INIGetStringValue("C:/gkdz/Config.ini", "Desktop", "Mac", "");
                    if (ws.Register(MAC, "GKDZ"))
                    {
                        Application.Run(new CheckIn());
                    }
                    else
                    {
                        //Set();
                        Application.Run(new BBT_Register());
                    }
                }
                catch (Exception ex )
                {
                    MessageBox.Show(ex.Message);
                    Application.Run(new BBT_Register());
                }
            }
        }
         private static Process RunningInstance()  
        {  
            Process current = Process.GetCurrentProcess();  
            Process[] processes = Process.GetProcessesByName(current.ProcessName);  
            //遍历与当前进程名称相同的进程列表   
            foreach (Process process in processes)  
            {  
                //如果实例已经存在则忽略当前进程   
                if (process.Id != current.Id)  
                {  
                    //保证要打开的进程同已经存在的进程来自同一文件路径  
                    if (Assembly.GetExecutingAssembly().Location.Replace("/", "\\") == current.MainModule.FileName)  
                    {  
                        //返回已经存在的进程  
                        return process;  
                    }  
                }  
            }  
            return null;  
        }  
        //3.已经有了就把它激活，并将其窗口放置最前端  
        private static void HandleRunningInstance(Process instance)  
        {
            ShowWindowAsync(instance.MainWindowHandle, 1);
            SetForegroundWindow(instance.MainWindowHandle);
            //IntPtr hwnd = FindWindow("BBT", "班班通设备使用登记系统");
            //if (ShowWindowAsync(instance.MainWindowHandle, 1)) //调用api函数，正常显示窗口  
            //    MessageBox.Show("1");
            //else
            //    MessageBox.Show("11");
            //if (SetForegroundWindow(instance.MainWindowHandle)) //将窗口放置最前端  
            //    MessageBox.Show("2");
            //else
            //    MessageBox.Show("22");

        }
        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
        public static extern int SystemParametersInfo(int uAction, int uParam, IntPtr lpvParam, int fuWinIni);
        [DllImport("User32.dll")]  
        private static extern bool ShowWindowAsync(System.IntPtr hWnd, int cmdShow);
  
        [DllImport("User32.dll")]  
        private static extern bool SetForegroundWindow(System.IntPtr hWnd);
        
        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        private extern static IntPtr FindWindow(string lpClassName, string lpWindowName);

        #region 开机启动
        public static void Set()
        {
            //string StartupPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.CommonStartup);
            ////获得文件的当前路径
            //string dir = Directory.GetCurrentDirectory();
            ////获取可执行文件的全部路径
            //string exeDir = dir + @"\BBT.exe.lnk";
            //System.IO.File.Copy(exeDir, StartupPath + @"\BBT.exe.lnk", true);
            try
            {
                string path = Application.ExecutablePath;
                RegistryKey rk = Registry.LocalMachine;
                RegistryKey rk2 = rk.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
                rk2.SetValue("BBT", path);
                rk2.Close();
                rk.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
    }
}
