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

namespace ComputerRoom
{
    public partial class Register : Form
    {
        public string Mac = BBT.Common.ComGUID.GetNetworkAdpaterID();
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
                ws.Url = this.txt_Name.Text + "/WebService.asmx";
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
                    string file = "./Config.ini";
                    if (BBT.Common.Win32API.INIWriteValue(file, "Desktop", "URL", this.txt_Name.Text))
                    {
                        MessageBox.Show("注册成功！");
                        CheckIn login = new CheckIn();
                        login.Show();
                        this.Close();
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
                    MessageBox.Show(val);
                    return;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                MessageBox.Show("请填写正确的服务器地址," + ex.Message);
                return;
            }
        }

        #region 开机启动
        public void Set()
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
                //MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void Register_Load(object sender, EventArgs e)
        {
            Set();
        }
    }
}
