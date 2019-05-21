using GK.GKICMP.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GKICMP.test
{
    public partial class tcptest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                string strHTML = "";//用来保存获得的HTML代码
                //string json = "{\"score\":\"123456\"}";

                //string result = WeixinQYAPI.Post(string.Format("http://localhost:51711/score/post"), json);


                try
                {

                    TcpClient clientSocket = new TcpClient();
                    Uri URI = new Uri("http://tc.whsedu.cn");
                    clientSocket.Connect("tc.whsedu.cn", 8523);
                    //clientSocket.Connect("10.168.7.121", 8523);
                   // Encoding encoding = Encoding.Default;
                    NetworkStream ntwStream = clientSocket.GetStream();
                    if (ntwStream.CanWrite)
                    {
                        //Byte[] bytSend = Encoding.UTF8.GetBytes("\"score\":\"sqm=abcdefg&type=tran_value_cloud&xsorgm=01&key=dm&01=1538&csydm=01&csyvalue=1538&csrq=2018/7/6&DM=G320311200506294656&MC=程昱尧&XXDM=20180414163748&NJDM=21&BJDM=1701&KH=5&XB=1&CSNY=2005/6/29&BMI=21&BMICJ=100&BMIDJ=正常&ZF=58&ZFDJ=不及格&cloud=1\"");
                        Byte[] bytSend = Encoding.UTF8.GetBytes("sqm=abcdefg&type=tran_value_cloud&xsorgm=01&key=dm&01=1538&csydm=01&csyvalue=1538&csrq=2018/7/6&DM=G320311200506294656&MC=程昱尧&XXDM=20180414163748&NJDM=21&BJDM=1701&KH=5&XB=1&CSNY=2005/6/29&BMI=21&BMICJ=100&BMIDJ=正常&ZF=58&ZFDJ=不及格&cloud=1");
                        //Byte[] bytSend = Encoding.UTF8.GetBytes("内容");
                        ntwStream.Write(bytSend, 0, bytSend.Length);
                    }
                    //byte[] bytes = new Byte[1024];
                    //string data = string.Empty;
                    //int length = ntwStream.Read(bytes, 0, bytes.Length);
                    //if (length > 0)
                    //{
                    //    data = Encoding.Default.GetString(bytes, 0, length);
                    //    Console.WriteLine("{0:HH:mm:ss}->接收数据(from {1}", DateTime.Now, data);
                    //}

                    //3.关闭对象
                    ntwStream.Close();
                    clientSocket.Close();

                    ////byte[] request = encoding.GetBytes("{\"score\":\"789\"}");
                    ////clientSocket.Client.Send(request);
                    ////获取要保存的网络流
                    ////Stream readStream = clientSocket.GetStream();
                    ////StreamReader sr = new StreamReader(readStream, Encoding.Default);
                    ////strHTML = sr.ReadToEnd();


                    ////ntwStream.Close();
                    ////clientSocket.Close();
                    ////if (strHTML.IndexOf('{') > 1)
                    ////    strHTML = strHTML.Remove(0, strHTML.IndexOf('{'));
                }
                catch
                {

                }
                //return strHTML;
            }
        }
    }
}