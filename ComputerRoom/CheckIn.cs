using BBT.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerRoom
{
    public partial class CheckIn : Form
    {
        System.Threading.Timer Thread_Time;
        public DateTime time = DateTime.Now;
        public string URL = Win32API.INIGetStringValue("./Config.ini", "Desktop", "URL", "");
        public string Mac = GetNetworkAdpaterID();
        public CheckIn()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }
        private void CheckIn_Load(object sender, EventArgs e)
        {

        }

        #region 登记事件
        private void btn_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                string val = "";
                JFDJ.WebService ws = new JFDJ.WebService();
                ws.Url = URL + "/WebService.asmx";
                string json = "[{\"Mac\":\"" + Mac
                    + "\",\"SysID\":\"" + this.txt_Name.Text
                    + "\",\"Psw\":\"" + this.txt_Psw.Text
                    + "\"}]";
                if (ws.JFDJ(json, "GKDZ", out val))
                {
                    MessageBox.Show("登记成功");
                    this.btn_Submit.Enabled = false;
                    time = DateTime.Now;
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("登记失败，请稍候再试。错误原因【" + val + "】");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("无法连接服务器");
                return;
            }

        }
        #endregion

        #region 打开主面板
        private void open_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }
        #endregion

        #region 程序退出
        private void exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定要退出登记吗？", "确认退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                //if (this.btn_Register.Visible)
                //{
                //    WebReference.WebService ws = new WebReference.WebService();
                //    ws.Url = URL + "/WebService.asmx";
                //    ws.RemoveCheck(CRID, "GKDZ");
                //}
                this.notifyIcon1.Visible = false;
                this.Close();
                this.Dispose();
                Application.Exit();
            }
        }
        #endregion

        #region 设置右键菜单单选
        ///<summary>  
        /// 设置右键菜单单选    
        /// </summary>        
        /// <param name="cms">参数-右键可选项类</param> 
        public void IsCheckedControl(ToolStripMenuItem cms)
        {
            //这里写父容器的集合 --可自动判断。这里我采用手写。提高效率              
            //不是当前项的取消选择 
            foreach (ToolStripMenuItem item in this.set.DropDownItems)
            {
                if (item.Name == cms.Name)
                {
                    item.Checked = true; //设选中状态为true      
                }
                else
                {
                    item.Checked = false; //设选中状态为false 
                }
            }
        }

        #endregion 设置右键菜单单选

        #region 登记按钮控制超过30分钟后可再次登记
        public void Thread_Timer_Method(object o)
        {
            //label1.Text = Convert.ToString((++num));
            getTimes();
            TimeSpan ts = (DateTime.Now - time);
            if (ts.Minutes > 30)
            {
                this.btn_Submit.Enabled = true;
                // CRID = "";
                // isregister = 0;
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.Activate();
            }
            //上传桌面截图
            // UpLoadPIC();
            // System.Threading.Thread.Sleep(5000);
        }
        #endregion

        #region 获取电脑空闲时间，达到设定时间后自动关机
        private void getTimes()
        {
            long result = GetLastInput.GetLastInputTime();
            int t = int.Parse(Win32API.INIGetStringValue("./Config.ini", "Desktop", "ShutT", "60"));
            //this.lbl_Time.Text = result.ToString();
            if (result / (t * 1000 * 60) > 0)
            {
                Process.Start("shutdown.exe", "-s");
            }
        }
        #endregion

        #region 设置自动关机时间，默认60分钟
        /// <summary>
        /// 设置30分钟
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setTime_Click(object sender, EventArgs e)
        {
            IsCheckedControl(this.setTime);
            setTimes("30");
        }
        /// <summary>
        /// 设置60分钟
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setTime1_Click(object sender, EventArgs e)
        {
            IsCheckedControl(this.setTime1);
            setTimes("60");
        }
        /// <summary>
        /// 设置90分钟
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setTime2_Click(object sender, EventArgs e)
        {
            IsCheckedControl(this.setTime2);
            setTimes("90");
        }
        private void setTimes(string times)
        {
            if (Win32API.INIWriteValue("./Config.ini", "Desktop", "ShutT", times))
            {
                MessageBox.Show("设置成功");
            }
            else
            {
                MessageBox.Show("设置失败");
            }
        }

        #endregion 设置自动关机时间，默认60分钟

        #region 最小化窗体
        private void CheckIn_MinimumSizeChanged(object sender, EventArgs e)
        {
            this.Hide();
        }
        #endregion

        #region 双击图标打开窗体
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }
        #endregion

        #region 窗体关闭事件
        private void CheckIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)//当用户点击窗体右上角X按钮或(Alt + F4)时 发生          
            {
                e.Cancel = true;
                this.ShowInTaskbar = false;
                // this.myIcon.Icon = this.Icon;
                this.Hide();
            }
        }
        #endregion

        #region 获取mac地址
        public static string GetNetworkAdpaterID()
        {
            try
            {
                string mac = "";
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                    if ((bool)mo["IPEnabled"] == true)
                    {
                        mac = mo["MacAddress"].ToString();
                        break;
                    }
                moc = null;
                mc = null;
                return mac.Trim().Replace(":", "");
            }
            catch (Exception e)
            {
                return "error:" + e.Message;
            }
        }
        #endregion
    }
}
