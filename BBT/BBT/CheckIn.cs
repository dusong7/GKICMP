
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

using BBT.Common;
using System.Deployment.Application;
namespace BBT
{
    public partial class CheckIn : Form
    {
        public int isregister = 0;
        public string CRID = "";
        public DateTime time = DateTime.Now;
        System.Threading.Timer Thread_Time;
        public string MAC = BBT.Common.ComGUID.GetNetworkAdpaterID();
        public string path = "C:/gkdz/Config.ini";
        public string Url = BBT.Common.Win32API.INIGetStringValue("C:/gkdz/Config.ini", "Desktop", "URL", "");
        public string IP = BBT.Common.ComGUID.GetNetworkIP();
        public DataTable dtsource = null;
        public DataTable dtc = null;
        public string gid = "";
        int isclass = 0;
        public CheckIn()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void CheckIn_Load(object sender, EventArgs e)
        {
            this.lbl_IP.Text = IP;
            this.lbl_Mac.Text = MAC;
            BaseDateBind();
            try
            {
                this.lbl_Version.Text = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            }
            catch
            {
                this.lbl_Version.Text = "未知版本";
            }
            Thread_Time = new System.Threading.Timer(Thread_Timer_Method, null, 0, 5000);
        }

        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void BaseDateBind()
        {
            try
            {
                WebReference.WebService ws = new WebReference.WebService();
                ws.Url = Url + "/WebService.asmx";
                dtsource = ws.BaseData(MAC, "GKDZ");
                if (dtsource != null && dtsource.Rows.Count > 0)
                {

                    //var s = from t in dtsource.AsEnumerable() group t by new { t1 = t.Field<string>("CourseID"), t2 = t.Field<string>("CourseName") } into m
                    //            select new
                    //            {
                    //                CourseID = m.Key.t1,
                    //                CourseName = m.Key.t2,
                    //            };

                    DataTable dc = new DataTable();
                    dc.Columns.Add("CourseID", typeof(string));
                    dc.Columns.Add("CourseName", typeof(string));
                   
                    foreach (DataRow dr in dtsource.Rows)
                    {
                        if (dc.Select("CourseID='" + dr["CourseID"]+"'").Length <= 0)
                         {
                            List<string> list = new List<string>();
                            list.Add(dr["CourseID"].ToString());
                            list.Add(dr["CourseName"].ToString());
                            dc.Rows.Add(list.ToArray());
                        }
                        else
                        {
                            isclass = 1;
                        }
                    }

                    this.cb_Course.DataSource = dc;
                    this.cb_Course.ValueMember = "CourseID";
                    this.cb_Course.DisplayMember = "CourseName";
                    
                    TeacherBind();
                    //if()

                    dtc = ws.CData(int.Parse(this.cb_Course.SelectedValue.ToString()), (isclass == 1 ? -2 : int.Parse(dtsource.Rows[0]["GID"].ToString())), "GKDZ");
                    if (dtc != null && dtc.Rows.Count > 0)
                    {
                        this.cb_ChapterName.DataSource = dtc;
                        this.cb_ChapterName.ValueMember = "TCID";
                        this.cb_ChapterName.DisplayMember = "ChapterName";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("无法连接服务器，请稍候再试" + ex.Message);
                return;
            }
        }
        /// <summary>
        /// 教师绑定
        /// </summary>
        private void TeacherBind()
        {
            DataRow[] drs = dtsource.Select("CourseID=" + this.cb_Course.SelectedValue);
            DataTable teac = new DataTable();
            teac.Columns.Add("TID", typeof(string));
            teac.Columns.Add("TName", typeof(string));
            foreach (DataRow dr in drs)
            {
                if (teac.Select("TID='" + dr["TeacherID"]+"'").Length <= 0)
                {
                    teac.Rows.Add(dr["TeacherID"], dr["UserName"]);
                }
            }
            this.cb_Accounts.DataSource = teac;
            this.cb_Accounts.ValueMember = "TID";
            this.cb_Accounts.DisplayMember = "TName";
        }

        #region 学科选择变更事件
        /// <summary>
        /// 章节绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_Course_SelectionChangeCommitted(object sender, EventArgs e)
        {
            WebReference.WebService ws = new WebReference.WebService();
            ws.Url = Url + "/WebService.asmx";
            dtc = ws.CData(int.Parse(this.cb_Course.SelectedValue.ToString()), (isclass == 1 ? -2 : int.Parse(dtsource.Rows[0]["GID"].ToString())), "GKDZ");
            if (dtc != null)
            {
                this.cb_ChapterName.DataSource = dtc;
                this.cb_ChapterName.ValueMember = "TCID";
                this.cb_ChapterName.DisplayMember = "ChapterName";
            }
            TeacherBind();
        }
        #endregion
        #endregion

        #region 窗体关闭
        private void CheckIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)//当用户点击窗体右上角X按钮或(Alt + F4)时 发生          
            {
                //if (WindowState == FormWindowState.Minimized)
                //{
                //    //隐藏任务栏区图标
                //    this.ShowInTaskbar = false;
                //    //图标显示在托盘区
                //    notifyIcon1.Visible = true;
                //}
                e.Cancel = true;
                this.ShowInTaskbar = false;
                notifyIcon1.Visible = true;
                this.WindowState = FormWindowState.Minimized;

                this.Hide();
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
                //    ws.Url = Url + "/WebService.asmx";
                //    ws.RemoveCheck(CRID, "GKDZ");
                //}
                this.notifyIcon1.Visible = false;
                this.Close();
                this.Dispose();
                Application.Exit();
                System.Environment.Exit(0);  
            }
        } 
        #endregion

        #region 登记事件
        private void btn_Register_Click(object sender, EventArgs e)
        {
            try
            {
                //ComputerRegEntity model = new ComputerRegEntity();
                //CRID = model.CRID = Guid.NewGuid().ToString(); ;
                //model.Guid = MAC;
                //model.SysID = this.cb_Accounts.Text;
                //model.CID = int.Parse(this.cb_Course.SelectedValue.ToString());
                //model.ChapterName = this.cb_ChapterName.Text;
                //model.RegType = (int)CommonEnum.RegType.自动登记;
                //if (this.cb_Accounts.Text == "")
                //{
                //    MessageBox.Show("帐号不能为空");
                //    return;
                //}
                //model.UserName = this.cb_Accounts.Text;

                CRID =  Guid.NewGuid().ToString();
                if (this.cb_Course.Text=="")
                //if (this.cb_Course.SelectedValue == null || this.cb_Course.SelectedValue.ToString() == "")
                {
                    MessageBox.Show("请选择学科");
                    return;
                }
                if (this.cb_ChapterName.Text=="")
               // if (this.cb_ChapterName.SelectedValue == null || this.cb_ChapterName.SelectedValue.ToString() == "")
                {
                    MessageBox.Show("请选择课题");
                    return;
                }
                if (this.cb_Accounts.Text=="")
                //if (this.cb_Accounts.SelectedValue == null || this.cb_Accounts.SelectedValue.ToString() == "")
                {
                    MessageBox.Show("请选择帐号");
                    return;
                }

                string json = "[{\"CRID\":\"" + CRID + "\",\"Guid\":\"" + MAC
                    + "\",\"SysID\":\"" + (this.cb_Accounts.SelectedValue == null ? this.cb_Accounts.Text : this.cb_Accounts.SelectedValue.ToString())
                    + "\",\"CID\":\"" + int.Parse(this.cb_Course.SelectedValue==null?this.cb_Course.Text:this.cb_Course.SelectedValue.ToString())
                    + "\",\"ChapterName\":\"" + this.cb_ChapterName.Text
                    + "\",\"RegType\":\"" + (int)CommonEnum.RegType.自动登记
                    + "\"}]";

                WebReference.WebService ws = new WebReference.WebService();
                ws.Url = Url + "/WebService.asmx";
              //  int result = new ComputerRegDAL().Edit(model);
                string msg = "";
                if (ws.CompCheck(json, "GKDZ",out msg))
                {
                    time = DateTime.Now;
                    MessageBox.Show("登记成功");
                    this.btn_Register.Enabled = false;

                    //窗体最小化到系统托盘
                    this.WindowState = FormWindowState.Minimized;
                    this.ShowInTaskbar = false;
                    notifyIcon1.Visible = true;

                    isregister = 1;
                    UpLoadPIC();
                }
                else
                {
                    MessageBox.Show("登记失败。"+msg);
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

                MessageBox.Show("无法连接服务器"+ex.Message);
            }
        } 
        #endregion

        #region 登记按钮控制超过30分钟后可再次登记
        public void Thread_Timer_Method(object o)
        {
            getTimes();
            TimeSpan ts = (DateTime.Now - time);
            if (ts.Minutes >=45)
            {
                
                CRID = "";
                isregister = 0;
               
                time = DateTime.Now;

                this.Invoke((MethodInvoker)delegate()
                {
                    this.Show();
                    this.WindowState = FormWindowState.Normal;
                    this.Activate();
                    this.btn_Register.Enabled = true;
                    this.ShowInTaskbar = true;
                    //这里写操作
                });
            }
            //上传桌面截图
            UpLoadPIC();
        } 
        #endregion

        #region 捕获桌面截图，并上传
        /// <summary>
        /// 上传截图
        /// </summary>
        private void UpLoadPIC()
        {
            string a = ScreenGet();
            //byte[] b = Convert.FromBase64String(a);
            //System.IO.MemoryStream stream = new System.IO.MemoryStream(b);
            //Image myImage = Image.FromStream(stream, true);
            //stream.Close();
            //pictureBox2.Image = myImage;
            //pictureBox2.Refresh();
            try
            {
                WebReference.WebService ws = new WebReference.WebService();
                ws.Url = Url + "/WebService.asmx";
                int result = ws.UploadScreen(MAC, a, isregister, CRID);
            }
            catch (Exception ex )
            {
                MessageBox.Show("无法连接服务器"+ex.Message);
                Thread_Time.Dispose();
                return;
            }
            //MessageBox.Show(result.ToString());
        }
        //private void UpLoadPIC()
        //{
        //    //this.label6.Text = "当前时间：" + DateTime.Now;
        //    //string a = ScreenGet();
        //    byte[] b = ScreenGet();
        //    System.IO.MemoryStream stream = new System.IO.MemoryStream(b);
        //    Image myImage = Image.FromStream(stream, true);
        //    stream.Close();
        //    //pictureBox2.Image = myImage;
        //    //pictureBox2.Refresh();
        //    try
        //    {
        //        WebReference.WebService ws = new WebReference.WebService();
        //        ws.Url = Win32API.INIGetStringValue("./Config.ini", "Desktop", "URL", "") + "/WebService.asmx";
        //        int result = ws.UploadScreen(MAC, a, isregister, CRID);
        //    }
        //    catch (Exception)
        //    {

        //    }
        //    //MessageBox.Show(result.ToString());
        //}

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
        //private byte[] ScreenGet()
        //{
        //    Image baseImage = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
        //    Graphics g = Graphics.FromImage(baseImage);
        //    g.CopyFromScreen(new Point(0, 0), new Point(0, 0), Screen.AllScreens[0].Bounds.Size);
        //    g.Dispose();
        //    MemoryStream ms = new MemoryStream();
        //    baseImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        //    ms.Position = 0;
        //    return ms.ToArray();

        //    #region 测试方法注释
        //    //string Opath = @"D:/Windows/CreenPhotos/";
        //    //if (Directory.Exists(Opath) == false)//如果不存在就创建file文件夹
        //    //{
        //    //    Directory.CreateDirectory(Opath);
        //    //}
        //    //Image baseImage = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
        //    //Graphics g = Graphics.FromImage(baseImage);
        //    //g.CopyFromScreen(new Point(0, 0), new Point(0, 0), Screen.AllScreens[0].Bounds.Size);
        //    //g.Dispose();
        //    //baseImage.Save("baseImage.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        //    //baseImage.Save(Opath + DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        //    //MemoryStream ms = new MemoryStream();
        //    //baseImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        //    //ms.Position = 0; 
        //    //byte[] bmpBytes = ms.ToArray();
        //    //return ms.ToArray();
        //    //return Convert.ToBase64String(ms.ToArray()); 
        //    #endregion
        //}
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
            if (Win32API.INIWriteValue(path, "Desktop", "ShutT", times))
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
            //this.Hide();
            //this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            notifyIcon1.Visible = true;

            this.WindowState = FormWindowState.Minimized;
            this.Hide();
            //return;
            ////判断是否选择的是最小化按钮
            //if (WindowState == FormWindowState.Minimized)
            //{
            //    //隐藏任务栏区图标
            //    this.ShowInTaskbar = false;
            //    //图标显示在托盘区
            //    notifyIcon1.Visible = true;
            //}
            //return;
        }
        #endregion

        #region 双击图标打开窗体
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.ShowInTaskbar == false)
            {
                notifyIcon1.Visible = true;
                this.ShowInTaskbar = false;
                this.Show();
                this.Activate();
                this.WindowState = FormWindowState.Normal;
            }

            //if (WindowState == FormWindowState.Minimized)
            //{
            //    //还原窗体显示    
            //    WindowState = FormWindowState.Normal;
            //    //激活窗体并给予它焦点
            //    this.Activate();
            //    //任务栏区显示图标
            //    this.ShowInTaskbar = true;
            //    //托盘区图标隐藏
            //    notifyIcon1.Visible = false;
            //}


            ////if (this.Visible)
            ////    this.Hide();
            ////else
            ////{
            //    this.Show();
            //    //this.Show();
            //    if (this.WindowState == FormWindowState.Minimized)
            //    {
            //        //notifyIcon1.Visible = false;
            //        //this.Focus();
            //        this.WindowState = FormWindowState.Normal;
            //        this.ShowInTaskbar = true;
            //    }
            ////}
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

        #region 获取电脑空闲时间，达到设定时间后自动关机
        /// <summary>
        /// 获取电脑空闲时间，达到设定时间后自动关机
        /// </summary>
        private void getTimes()
        {
            long result = GetLastInput.GetLastInputTime();
            int t = int.Parse(Win32API.INIGetStringValue(path, "Desktop", "ShutT", "60"));
            //this.lbl_Time.Text = result.ToString();
            if (result / (t * 1000 * 60) > 0)
            {
                Process.Start("shutdown.exe", "-s");
            }
        }
        #endregion

        private void CheckIn_SizeChanged(object sender, EventArgs e)
        {
            //当窗体最小化时，隐藏到系统托盘中
            if (WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                notifyIcon1.Visible = true;

                this.WindowState = FormWindowState.Minimized;
                this.Hide();
                //this.Hide();
                //this.notifyIcon1.Visible = true;
            }
        }
    }
}
