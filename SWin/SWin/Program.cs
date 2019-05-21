using GK.GKICMP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using Microsoft.Win32;

namespace SWin
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Set();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string g = Win32API.INIGetStringValue("./Config.ini", "Desktop", "MAC", "") ;
            if (g == "")
            {
                Application.Run(new ComputerRegister());
            }
            else
            {
                //DataTable dt = ;
                ComputersEntity model = new ComputersDAL().GetObjByMac(g);
                if (model != null)
                {
                    Application.Run(new Login());
                }
                else
                {
                    Application.Run(new ComputerRegister());
                }
            }
        }
       
    }
}
