using BBT.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MachineRoom
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

            if (!Directory.Exists("c:/gkdz/jf"))//如果不存在就创建file文件夹
            {
                Directory.CreateDirectory("c:/gkdz/jf");
            }
            Process instance = RunningInstance();
            if (instance != null)
            {
                if (instance.MainWindowHandle.ToInt32() == 0) //是否托盘化  
                {
                    HandleRunningInstance(instance);
                    return;
                }
                //1.2 已经有一个实例在运行  
                HandleRunningInstance(instance);
                return;
            }

            string g = Win32API.INIGetStringValue("C:/gkdz/jf/Config.ini", "Desktop", "URL", "");
            if (g != "")
            {
                try
                {
                    string mac = BBT.Common.ComGUID.GetNetworkAdpaterID();
                    JFDJ.WebService ws = new JFDJ.WebService();
                    ws.Url = g + "/WebService.asmx";
                    string val = "";
                    if (ws.JFYZ(mac, "GKDZ", out val))
                    {
                        Application.Run(new CheckIn());
                    }
                    else
                    {
                        Application.Run(new Register());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Application.Run(new Register());
                }
            }
            else
            {
                Application.Run(new Register());
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
            //IntPtr hwnd = FindWindow("BBT", "班班通设备使用登记系统");
            ShowWindowAsync(instance.MainWindowHandle, 9); //调用api函数，正常显示窗口  
            SetForegroundWindow(instance.MainWindowHandle); //将窗口放置最前端  
        }
        [DllImport("User32.dll")]
        private static extern bool ShowWindowAsync(System.IntPtr hWnd, int cmdShow);
        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(System.IntPtr hWnd);
        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        private extern static IntPtr FindWindow(string lpClassName, string lpWindowName);
    }
}
