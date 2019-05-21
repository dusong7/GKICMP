using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Configuration;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Diagnostics;
using SWin.Common;

namespace SWin
{
    public partial class Login : Form
    {
        public int isregister = 0;
        public string CRID = "";
        public DateTime time = DateTime.Now;
        public string GUID = Win32API.INIGetStringValue("./Config.ini", "Desktop", "Guid", "") ;
        public string MAC = Win32API.INIGetStringValue("./Config.ini", "Desktop", "MAC", "");
        System.Threading.Timer Thread_Time;
       // public string CRID = Guid.NewGuid().ToString();
        public Login()
        {
            InitializeComponent();
        }

        #region 窗体加载事件
        private void Login_Load(object sender, EventArgs e)
        {

           // UpLoadPIC();
            //this.label6.Text = "当前时间：" + DateTime.Now;
            DataTable dt = new CourseDAL().GetList();
            this.cb_Course.DataSource = dt;
            this.cb_Course.ValueMember = "CID";
            this.cb_Course.DisplayMember = "CourseName";
            DataTable dtc = new TeachMaterial_ChapterDAL().GetList(int.Parse(this.cb_Course.SelectedValue.ToString()), -2);
            this.cb_ChapterName.DataSource = dtc;
            this.cb_ChapterName.ValueMember = "TCID";
            this.cb_ChapterName.DisplayMember = "ChapterName";
            Thread_Time = new System.Threading.Timer(Thread_Timer_Method, null, 0, 5000);
            //this.comboBox1.DataBindings;
        } 
        #endregion
        public void Thread_Timer_Method(object o)
        {
            //label1.Text = Convert.ToString((++num));
            getTimes();
            TimeSpan ts = (DateTime.Now - time);
            if (ts.Minutes > 30)
            {
                this.btn_Register.Enabled = true;
                CRID = "";
                isregister = 0;
            }
            //上传桌面截图
            UpLoadPIC();
           // System.Threading.Thread.Sleep(5000);
        }  
        #region 登录事件
        private void btn_Register_Click(object sender, EventArgs e)
        {
            try
            {
                ComputerRegEntity model = new ComputerRegEntity();
                CRID=model.CRID = Guid.NewGuid().ToString(); ;
                model.Guid = MAC;
                model.SysID = this.cb_Accounts.Text;
                model.CID = int.Parse(this.cb_Course.SelectedValue.ToString());
                model.ChapterName = this.cb_ChapterName.Text;
                model.RegType = (int)CommonEnum.RegType.自动登记;
                if (this.cb_Accounts.Text == "") 
                {
                    MessageBox.Show("帐号不能为空");
                    return;
                }
                model.UserName = this.cb_Accounts.Text;
                if (DateTime.Now.Month > 8 || DateTime.Now.Month < 3)
                {
                    model.XTerm = (int)CommonEnum.XQ.上学期;
                    model.Xyear = DateTime.Now.Year + "-" + (DateTime.Now.Year + 1); ;
                }
                else
                {
                    model.Xyear = (DateTime.Now.Year - 1) + "-" + DateTime.Now.Year;
                    model.XTerm = (int)CommonEnum.XQ.下学期;
                }
                //添加登记记录
                int result = new ComputerRegDAL().Edit(model);
                if (result > 0)
                {
                    MessageBox.Show("登记成功");
                    this.btn_Register.Enabled = false;
                    isregister = 1;
                    UpLoadPIC();
                    time = DateTime.Now;
                }
                else 
                {
                    MessageBox.Show("登记失败，请稍候再试");
                }
                //设置登记状态
              
                //System.Timers.Timer myTimer = new System.Timers.Timer(10000);
                //System.Timers.Timer myTimer = new System.Timers.Timer(1800000);
                //myTimer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEvent);
                //myTimer.Interval = 10000;
                //myTimer.Enabled = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        /// <summary>
        /// 超时改变登记按钮状态，同时重置变量
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        //private  void OnTimedEvent(object source, System.Timers.ElapsedEventArgs e)
        //{
        //   // this.btn_Register.Enabled = true;
        //    CRID = "";
        //    isregister = 0;

        //}
        #region 学科选择变更事件
        private void cb_Course_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataTable dtc = new TeachMaterial_ChapterDAL().GetList(int.Parse(this.cb_Course.SelectedValue.ToString()), -2);
            this.cb_ChapterName.DataSource = dtc;
            this.cb_ChapterName.ValueMember = "TCID";
            this.cb_ChapterName.DisplayMember = "ChapterName";


        } 
        #endregion


        //private void timer1_Tick(object sender, EventArgs e)
        //{
            
        //    //getTimes();
        //    //TimeSpan ts = (DateTime.Now - time);
        //    //if (ts.Minutes > 30)
        //    //{
        //    //    this.btn_Register.Enabled = true;
        //    //    CRID = "";
        //    //    isregister = 0;
        //    //}
        //    ////上传桌面截图
        //    //UpLoadPIC();
            
        //}

        #region 获取电脑空闲时间，达到设定时间后自动关机
        private void getTimes()
        {
            long result = GetLastInput.GetLastInputTime();
            int t = int.Parse(Win32API.INIGetStringValue("./Config.ini", "Desktop", "ShutT","60"));
            //this.lbl_Time.Text = result.ToString();
            if (result /(t *1000*60)> 0)
            {
                Process.Start("shutdown.exe", "-s");
            }
        } 
        #endregion


        #region 捕获桌面截图，并上传
        /// <summary>
        /// 上传截图
        /// </summary>
        private void UpLoadPIC()
        {
            //this.label6.Text = "当前时间：" + DateTime.Now;
            string a = ScreenGet();
            byte[] b = Convert.FromBase64String(a);
            System.IO.MemoryStream stream = new System.IO.MemoryStream(b);
            Image myImage = Image.FromStream(stream, true);
            stream.Close();
            //pictureBox2.Image = myImage;
            //pictureBox2.Refresh();
            try
            {
                WebService.WebService ws = new WebService.WebService();
                ws.Url = Win32API.INIGetStringValue("./Config.ini", "Desktop", "URL", "") + "/WebService.asmx";
                int result = ws.UploadScreen(MAC, a, isregister, CRID);
            }
            catch (Exception)
            {
               
            }
            //MessageBox.Show(result.ToString());
        }
        /// <summary>
        /// 捕获桌面截图
        /// </summary>
        /// <returns></returns>
        private string ScreenGet()
        {
            Image baseImage = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics g = Graphics.FromImage(baseImage);
            g.CopyFromScreen(new Point(0, 0), new Point(0, 0), Screen.AllScreens[0].Bounds.Size);
            g.Dispose();
            MemoryStream ms = new MemoryStream();
            baseImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            ms.Position = 0;
            return Convert.ToBase64String(ms.ToArray());
            #region 测试方法注释
            //string Opath = @"D:/Windows/CreenPhotos/";
            //if (Directory.Exists(Opath) == false)//如果不存在就创建file文件夹
            //{
            //    Directory.CreateDirectory(Opath);
            //}
            //Image baseImage = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            //Graphics g = Graphics.FromImage(baseImage);
            //g.CopyFromScreen(new Point(0, 0), new Point(0, 0), Screen.AllScreens[0].Bounds.Size);
            //g.Dispose();
            //baseImage.Save("baseImage.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            //baseImage.Save(Opath + DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            //MemoryStream ms = new MemoryStream();
            //baseImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            //ms.Position = 0; 
            //byte[] bmpBytes = ms.ToArray();
            //return ms.ToArray();
            //return Convert.ToBase64String(ms.ToArray()); 
            #endregion
        } 
        #endregion

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)//当用户点击窗体右上角X按钮或(Alt + F4)时 发生          
            {
                e.Cancel = true;
                this.ShowInTaskbar = false;
               // this.myIcon.Icon = this.Icon;
                this.Hide();
            }       
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
        }

        private void Login_MinimumSizeChanged(object sender, EventArgs e)
        {
            this.Hide();
        }

        #region 退出程序
        private void exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定要退出登记吗？如退出会将登记记录清空", "确认退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                int reult = new ComputerRegDAL().DeleteReg(CRID);
                this.notifyIcon1.Visible = false;
                this.Close();
                this.Dispose();
                Application.Exit();
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

        #region 设置自动关机时间，默认60分钟
        /// <summary>
        /// 设置30分钟
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setTime_Click(object sender, EventArgs e)
        {
            IsCheckedControl(this.setTime);
            if (Win32API.INIWriteValue("./Config.ini", "Desktop", "ShutT", "30"))
            {
                MessageBox.Show("设置成功");
            }
            else
            {
                MessageBox.Show("设置失败");
            }
        }
        /// <summary>
        /// 设置60分钟
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setTime1_Click(object sender, EventArgs e)
        {
            IsCheckedControl(this.setTime1);
            if (Win32API.INIWriteValue("./Config.ini", "Desktop", "ShutT", "60"))
            {
                MessageBox.Show("设置成功");
            }
            else
            {
                MessageBox.Show("设置失败");
            }
        }
        /// <summary>
        /// 设置90分钟
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setTime2_Click(object sender, EventArgs e)
        {
            IsCheckedControl(this.setTime2);
            if (Win32API.INIWriteValue("./Config.ini", "Desktop", "ShutT", "90"))
            {
                MessageBox.Show("设置成功");
            }
            else
            {
                MessageBox.Show("设置失败");
            }
        }
        #endregion 设置自动关机时间，默认60分钟

    }
}
