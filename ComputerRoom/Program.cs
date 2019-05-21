using BBT.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerRoom
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
            string g = Win32API.INIGetStringValue("./Config.ini", "Desktop", "URL", "");
            if (g != "")
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
            else
            {
                Application.Run(new Register());
            }
        }
    }
}
