using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MachineRoom
{
    public partial class Register : Form
    {
        public string IP = BBT.Common.ComGUID.GetNetworkIP();
        public string Mac = BBT.Common.ComGUID.GetNetworkAdpaterID();
        public string Path = "C:/gkdz/jf/Config.ini";
        public Register()
        {
            InitializeComponent();
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                //int num = 0;
                JFDJ.WebService ws = new JFDJ.WebService();
                string url = (this.txt_Url.Text.IndexOf("http") > 0 ? this.txt_Url.Text : ("http://" + this.txt_Url.Text));
                ws.Url = url + "/WebService.asmx";
                string val = "";
                if (ws.JFYZ(Mac, "GKDZ", out val))
                {
                    //string conn = ;

                    //string cc = Common.CommonFunction.Decrypt(System.Configuration.ConfigurationManager.ConnectionStrings["YGHD"].ConnectionString);
                    //UpdateConfig("ConnectionString", conn);
                    ////string ip = this.txt_IP.Text.Trim();
                    ////string comname = this.txt_ComName.Text.Trim();
                    ////string mac = this.txt_Mac.Text.Trim();
                    ////string id = this.txt_Code.Text.Trim();
                    ////ComputersDAL a = new ComputersDAL();
                    //DataTable dt = new ComputerRegDAL().Search(this.txt_Mac.Text);
                    //if (dt != null && dt.Rows.Count > 0)
                    //{
                    //写入配置信息
                    if (BBT.Common.Win32API.INIWriteValue(Path, "Desktop", "URL", url))
                    {
                        MessageBox.Show("注册成功！");
                       
                        CheckIn login = new CheckIn();
                        login.Show();
                        this.Hide();
                    }
                    else { MessageBox.Show("注册失败，请稍候再试！"); }

                    //}
                    //else
                    //{
                    //    MessageBox.Show("请先在平台中添加设备，并注意MAC地址是否正确！");
                    //}
                }
                else
                {
                    string msg = "";
                    if (ws.CompAdd(Mac, IP, this.txt_Name.Text,2, "GKDZ", out msg))
                    {
                        if (BBT.Common.Win32API.INIWriteValue(Path, "Desktop", "URL", url))
                        {
                            MessageBox.Show("已自动添加设备，请联系管理员绑定机房");
                            //this.Close();
                            CheckIn login = new CheckIn();
                            login.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        this.lbl_Message.Text = "自动添加失败。错误信息：" + msg;
                        return;
                    }
                    //MessageBox.Show(val);
                    //return;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                MessageBox.Show("请填写正确的服务器地址," + ex.Message);
                return;
            }
        }

        private void Register_Load(object sender, EventArgs e)
        {
            this.lbl_IP.Text = IP;
            this.lbl_Mac.Text = Mac;
           // Set();
        }
    }
}
