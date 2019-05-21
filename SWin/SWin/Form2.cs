using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace SWin
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            InitClient();
        }

        SerialPort spSend;//spSend,spReceive用虚拟串口连接，它们之间可以相互传输数据。spSend发送数据
        SerialPort spReceive; //spReceive接受数据
        delegate void UpdateTextEventHandler(string text);//委托，此为重点
        UpdateTextEventHandler updateText;

        public void InitClient() //窗体控件已经初始化
        {

            updateText = new UpdateTextEventHandler(UpdateTextBox);//实例化委托对象
            spSend.Open(); //SerialPort对象在程序结束前必须关闭，在此说明
            spReceive.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(spReceive_DataReceived);
            spReceive.Open();

        }

        public void btnSend_Click(object sender, EventArgs e)
        {

            spSend.WriteLine(txtSend.Text);
        }

        public void spReceive_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string readString = spReceive.ReadExisting();
            this.Invoke(updateText, new string[] { readString });
        }

        private void UpdateTextBox(string text)
        {

            txtReceive.Text = text;

        }

   
    }
}
