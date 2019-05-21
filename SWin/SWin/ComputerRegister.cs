
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using GK.GKICMP.Common;
using System.Configuration;
using System.Xml;
using Microsoft.Win32;
//using GK.GKICMP.Common;

namespace SWin
{
    public partial class ComputerRegister : Form
    {
       
        public ComputerRegister()
        {
            InitializeComponent();
        }

        private void ComputerRegister_Load(object sender, EventArgs e)
        {

            //Set();
            DESCryptoServiceProvider DesCSP = new DESCryptoServiceProvider();
            this.txt_Mac.Text = GetMacByNetworkInterface()[0];
            this.txt_Code.Text = ComGUID.Value();
            ///获取本地的IP地址
            string AddressIP = string.Empty;
            foreach (IPAddress _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    AddressIP = _IPAddress.ToString();
                }
            }
            this.txt_IP.Text = AddressIP;
            this.txt_ServerName.Text = "http://";

        }
        public  void Set()
        {
            try
            {
                string path = Application.ExecutablePath;
                RegistryKey rk = Registry.LocalMachine;
                RegistryKey rk2 = rk.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
                rk2.SetValue("SWin", path);
                rk2.Close();
                rk.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        ///<summary>
        /// 通过WMI读取系统信息里的网卡MAC
        ///</summary>
        ///<returns></returns>
        //返回描述本地计算机上的网络接口的对象(网络接口也称为网络适配器)。
        public NetworkInterface[] NetCardInfo()
        {
            return NetworkInterface.GetAllNetworkInterfaces();
        }

        ///<summary>
        /// 通过NetworkInterface读取网卡Mac
        ///</summary>
        ///<returns></returns>
        public List<string> GetMacByNetworkInterface()
        {
            List<string> macs = new List<string>();
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface ni in interfaces)
            {
                macs.Add(ni.GetPhysicalAddress().ToString());
            }
            return macs;
        }


        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Register_Click(object sender, EventArgs e)
        {
            try
            {
                int num = 0;
                WebService.WebService ws = new WebService.WebService();
                ws.Url = this.txt_ServerName.Text + "/WebService.asmx";
                string conn = ws.Conn("GKDZ");
                if (conn != "")
                {
                    string cc = ConfigurationManager.AppSettings["ConnectionString"];
                    UpdateConfig("ConnectionString", conn);
                    //string ip = this.txt_IP.Text.Trim();
                    //string comname = this.txt_ComName.Text.Trim();
                    //string mac = this.txt_Mac.Text.Trim();
                    //string id = this.txt_Code.Text.Trim();
                    ComputersDAL a = new ComputersDAL();
                    a.Search(this.txt_Mac.Text, ref num);
                    if (num > 0)
                    {
                        //写入配置信息
                        string file = "./Config.ini";
                        if (GK.GKICMP.Common.Win32API.INIWriteValue(file, "Desktop", "GUID", this.txt_Code.Text) && GK.GKICMP.Common.Win32API.INIWriteValue(file, "Desktop", "Mac", this.txt_Mac.Text) && GK.GKICMP.Common.Win32API.INIWriteValue(file, "Desktop", "URL", this.txt_ServerName.Text))
                        {
                            MessageBox.Show("注册成功！");

                            Login login = new Login();
                            login.Show();
                            this.Hide();
                        }
                        else { MessageBox.Show("注册失败，请稍候再试！"); }

                    }
                    else
                    {
                        MessageBox.Show("请先在平台中添加设备，并注意MAC地址是否正确！");
                    }
                }
                else
                {
                    MessageBox.Show("请填写正确的服务器地址；");
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                MessageBox.Show("请填写正确的服务器地址," + ex.Message);
            }
            
        }

        private void UpdateConfig(string key, string value)
        {
            // 通过Xml方式（需using System.xml;)  
            XmlDocument doc = new XmlDocument();
            doc.Load(Application.ExecutablePath + ".config");
            XmlNode node = doc.SelectSingleNode(@"//add[@key='" + key + "']"); // 定位到add节点  
            XmlElement element = (XmlElement)node;
            element.SetAttribute("value", value); // 赋值  
            doc.Save(Application.ExecutablePath + ".config");
            ConfigurationManager.RefreshSection("appSetting"); // 刷新节点  

            // 利用Configuration  
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[key].Value = value;
            config.Save(ConfigurationSaveMode.Full);
            ConfigurationManager.RefreshSection("appSettings");
        }  

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ntn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            //this.txt_ComName.Text = this.txt_ServerName.Text = "";
        }

      

        private void ComputerRegister_MinimumSizeChanged(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ComputerRegister_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)//当用户点击窗体右上角X按钮或(Alt + F4)时 发生          
            {
                e.Cancel = true;
                this.ShowInTaskbar = false;
                // this.myIcon.Icon = this.Icon;
                this.Hide();
            }       
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定要退出吗？", "确认退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                //int reult = new ComputerRegDAL().DeleteReg(CRID);
                this.notifyIcon1.Visible = false;
                this.Close();
                this.Dispose();
                Application.Exit();
            }
        }
    }
}
