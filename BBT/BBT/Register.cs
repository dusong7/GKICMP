using BBT.Common;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Xml;

namespace BBT
{
    public partial class BBT_Register : Form
    {
        public string MAC = BBT.Common.ComGUID.GetNetworkAdpaterID();
        public string file = "C:/gkdz/Config.ini";
        public string Url = BBT.Common.Win32API.INIGetStringValue("C:/gkdz/Config.ini", "Desktop", "URL", "");
        public string IP = BBT.Common.ComGUID.GetNetworkIP();
        public BBT_Register()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void BBT_Register_Load(object sender, EventArgs e)
        {
           // this.lbl_Message.Text = "本机ip:" + IP + ";物理地址:" + MAC;
            this.lbl_IP.Text = IP;
            this.lbl_Mac.Text = MAC;
            //附小特列
            //Register();
        }

        #region 取消
        private void ntn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        #endregion

        #region 窗体最小化
        private void BBT_Register_MinimumSizeChanged(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false;
            notifyIcon1.Visible = true;
        } 
        #endregion

        #region 窗体关闭
        private void BBT_Register_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)//当用户点击窗体右上角X按钮或(Alt + F4)时 发生          
            {
                e.Cancel = true;
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
                notifyIcon1.Visible = true;
                //this.Hide();
            }
        }
        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }
        #endregion

        #region 双击图标事件
        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            //this.Show();
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
            }
        }
        #endregion

        #region 退出事件
        private void Exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定要退出吗？", "确认退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                //int reult = new ComputerRegDAL().DeleteReg(CRID);
                this.notifyIcon1.Visible = false;
                this.Close();
                this.Dispose();
                Application.Exit();
                System.Environment.Exit(0);  
            }
        }
        #endregion

        

        #region 注册事件
        private void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {

                // string app = ConfigurationManager.AppSettings["URL"];
                if (this.txt_Url.Text == "")
                {
                    MessageBox.Show("请填写服务地址");
                    return;
                }
                if (this.txt_Name.Text == "")
                {
                    MessageBox.Show("请填写设备名称");
                    return;
                }
                WebReference.WebService ws = new WebReference.WebService();
                string url = (this.txt_Url.Text.IndexOf("http") > 0 ? this.txt_Url.Text : ("http://" + this.txt_Url.Text));
                ws.Url = url + "/WebService.asmx";
                if (ws.Register(MAC, "GKDZ"))
                {
                    if (BBT.Common.Win32API.INIWriteValue(file, "Desktop", "Mac", MAC) && BBT.Common.Win32API.INIWriteValue(file, "Desktop", "URL", url))
                    {
                        MessageBox.Show("注册成功");
                        CheckIn login = new CheckIn();
                        login.Show();
                        this.Close();
                        this.notifyIcon1.Visible = false;
                    }
                }
                else
                {
                    string msg = "";
                    if (ws.CompAdd(MAC, IP, this.txt_Name.Text, 1,"GKDZ", out msg))
                    {
                        if (BBT.Common.Win32API.INIWriteValue(file, "Desktop", "Mac", MAC) && BBT.Common.Win32API.INIWriteValue(file, "Desktop", "URL", url))
                        {
                            MessageBox.Show("已自动添加设备，请联系管理员绑定班级");
                            CheckIn login = new CheckIn();
                            login.Show();
                            this.Close();
                            this.notifyIcon1.Visible = false;
                        }
                    }
                    else
                    {
                        this.lbl_Message.Text = "自动添加失败。错误信息：" + msg;
                        return;
                    }

                }
            }
            catch (Exception ex)
            {
                this.lbl_Message.Text = "请填写正确的服务器地址," + ex.Message;
                return;
            }
        } 
        #endregion
        public void Register()
        {
            try
            {
                WebReference.WebService ws = new WebReference.WebService();
                string url = "http://fxoa.whjhedu.cn/yghd";
                ws.Url = url + "/WebService.asmx";
                if (ws.Register(MAC, "GKDZ"))
                {
                    if (BBT.Common.Win32API.INIWriteValue(file, "Desktop", "Mac", MAC) && BBT.Common.Win32API.INIWriteValue(file, "Desktop", "URL", url))
                    {
                        //MessageBox.Show("注册成功");
                        CheckIn login = new CheckIn();
                        login.Show();
                        this.Close();
                        this.notifyIcon1.Visible = false;
                    }
                }
                else
                {
                    string msg = "";
                    if (ws.CompAdd(MAC, IP, this.txt_Name.Text, 1, "GKDZ", out msg))
                    {
                        if (BBT.Common.Win32API.INIWriteValue(file, "Desktop", "Mac", MAC) && BBT.Common.Win32API.INIWriteValue(file, "Desktop", "URL", url))
                        {
                            //MessageBox.Show("已自动添加设备，请联系管理员绑定班级");
                            CheckIn login = new CheckIn();
                            login.Show();
                            this.Close();
                            this.notifyIcon1.Visible = false;
                        }
                    }
                    else
                    {
                        this.lbl_Message.Text = "自动添加失败。错误信息：" + msg;
                        return;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("自动注册出错："+ex.Message);
            }
        }
    }
}
