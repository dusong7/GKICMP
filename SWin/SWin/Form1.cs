using SWin.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
namespace SWin
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ScreenGet();
        }
       
        private void test()
        {

        }
        private void ScreenGet()
        {
            //string Opath = @"D:/Windows/CreenPhotos/";
            //if (Directory.Exists(Opath) == false)//如果不存在就创建file文件夹
            //{
            //    Directory.CreateDirectory(Opath);
            //}
            Image baseImage = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics g = Graphics.FromImage(baseImage);
            g.CopyFromScreen(new Point(0, 0), new Point(0, 0), Screen.AllScreens[0].Bounds.Size);
            g.Dispose();
            //  baseImage.Save("baseImage.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            baseImage.Save(DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            //MemoryStream ms = new MemoryStream();
            //baseImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            //byte[] bmpBytes = ms.ToArray();
        }


        private void tm_Set_Tick(object sender, EventArgs e)
        {
            getTimes();
            ScreenGet();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getTimes();
        }

        private void getTimes()
        {
            long result = GetLastInput.GetLastInputTime();
            this.lbl_Time.Text = result.ToString();
            if (result / 36000 > 0)
            {
                Process.Start("shutdown.exe", "-s");
            }
        }


    }
}
