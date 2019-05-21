using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace GKService
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }


        protected override void OnStart(string[] args)
        {

            FileStream fs = new FileStream(@"d:\service.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.BaseStream.Seek(0, SeekOrigin.End);
            sw.WriteLine("WindowsService: Service Start" + DateTime.Now.ToString() + "\n");
            sw.Flush();
            sw.Close();
            fs.Close();

            DataTable tftmodel = DoSqlDT("select * from Tb_AttendMachine where attendtype=0");
            foreach (DataRow dr in tftmodel.Rows)
            {
                Thread tft = new Thread(delegate()
                {
                    TFT(dr["IPUrl"].ToString(), Convert.ToInt32(dr["PotCode"].ToString()));
                });

                tft.Name = "TFTThread:" + (threadlist.Count + 1);
                threadlist.Add(tft);
                tft.IsBackground = true;
                tft.Start();
            }

        }


        public string TFTIP = "";
        public int TFTPort = 0;
        public bool isfirst = true;
        public static object locker = new object();
        List<Thread> threadlist = new List<Thread>();
        public string connectstring = "Data Source=(local);User ID=sa;Password=123456;Initial Catalog=GK_JHXX;";
        //public string connectstring = "Data Source=192.168.10.20;User ID=yghd;Password=123456;Initial Catalog=GK_YGHD;";
        //public string connectstring = "Data Source=121.41.12.236;User ID=sa;Password=gkdz.123;Initial Catalog=GK_YGHD;";


        private void axCZKEM1_OnAttTransactionEx(string sEnrollNumber, int iIsInValid, int iAttState, int iVerifyMethod, int iYear, int iMonth, int iDay, int iHour, int iMinute, int iSecond, int iWorkCode)
        {
            try
            {
                FileStream fs = new FileStream(@"d:\service.txt", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.BaseStream.Seek(0, SeekOrigin.End);
                sw.WriteLine("WindowsService:iVerifyMethod:" + iVerifyMethod + " iIsInValid:" + iIsInValid + " isfirst:" + isfirst + "  DateTime: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " Attend:" + sEnrollNumber + "\n");
                sw.Flush();
                sw.Close();
                fs.Close();

                if (!isfirst)
                {
                    //根据sEnrollNumber获取usernum
                    DataTable ardt = DoSqlDT("select * from [Tb_AttendMachine] where IPUrl='" + this.TFTIP + "' and PotCode='" + this.TFTPort + "'");

                    if (ardt.Rows.Count > 0)
                    {
                        //判断其特征
                        DataTable userdt = DoSqlDT("select * from Tb_SysUser where Isdel=0 and CardNum='" + sEnrollNumber + "'");
                    
                        if (userdt.Rows.Count > 0)
                        {
                            string userid = userdt.Rows[0]["UID"].ToString();

                            DataTable asmodel = DoSqlDT("select * from Tb_AttendSet where IsUse=1");

                            DateTime begindate = DateTime.Now, enddate = DateTime.Now;

                            int isanalysis = 0;
                            foreach (DataRow dr in asmodel.Rows)
                            {
                                begindate = Convert.ToDateTime(dr["MBegin"]);
                                enddate = Convert.ToDateTime(dr["MEnd"]);
                                begindate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " " + begindate.ToString("HH:mm:ss"));
                                enddate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " " + enddate.ToString("HH:mm:ss"));
                                if (DateTime.Now > begindate && DateTime.Now < enddate)
                                {
                                    isanalysis = Convert.ToInt32(dr["AType"]);
                                    break;
                                }
                            }

                            string addsql = "Insert Into Tb_AttendRecord ([ARID],[UserNum],[MachineCode],[RecordDate],[AttendType],[IsAnalysis],[AttendDesc],[OutType],[AttImg]) values (NEWID(),'" + userid + "','" + ardt.Rows[0]["MachineCode"].ToString() + "','" + Convert.ToDateTime(iYear.ToString() + "-" + iMonth.ToString() + "-" + iDay.ToString() + " " + iHour.ToString() + ":" + iMinute.ToString() + ":" + iSecond.ToString()) + "','0','" + isanalysis + "','','" + ardt.Rows[0]["OutType"].ToString() + "','')";
                            DoSql(addsql);

                            try
                            {
                                string mess = "";
                                if (isanalysis == 0)
                                {
                                    mess = "考勤打卡成功【其他】,时间：" + Convert.ToDateTime(iYear.ToString() + "-" + iMonth.ToString() + "-" + iDay.ToString() + " " + iHour.ToString() + ":" + iMinute.ToString() + ":" + iSecond.ToString()) + ",打卡方式：指纹,备注：";
                                }
                                else
                                {
                                    mess = "考勤打卡成功【" + DoSqlDT("select * from Tb_SysData where SDID=" + isanalysis).Rows[0]["DataName"].ToString() + "】,时间：" + Convert.ToDateTime(iYear.ToString() + "-" + iMonth.ToString() + "-" + iDay.ToString() + " " + iHour.ToString() + ":" + iMinute.ToString() + ":" + iSecond.ToString()) + ",打卡方式：指纹,备注：";
                                }

                                XMLData xmldata = GetAgent("~/QYWX.xml", "Main", 1);
                                string token = GetAccess_Token(xmldata.CorpID, "");
                                string msg = SendMessage(token, userid, xmldata.Agent, mess);

                            }
                            catch
                            {

                            }
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                FileStream fs = new FileStream(@"d:\service.txt", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.BaseStream.Seek(0, SeekOrigin.End);
                sw.WriteLine("WindowsService: Service Exception" + ex.Message + "\n");
                sw.Flush();
                sw.Close();
                fs.Close();

            }

        }



        public static string GetAccess_Token(string CorpID, string CorpSecret)
        {
            string access_Token = RequestUrl(string.Format("https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid={0}&corpsecret={1}", CorpID, CorpSecret));
            return Json(access_Token, "access_token");

        }


        #region get事件
        /// <summary>
        /// get事件
        /// </summary>
        /// <param name="urlString"></param>
        /// <returns></returns>
        public static string RequestUrl(string urlString)
        {
            //定义局部变量
            HttpWebRequest httpWebRequest = null;
            HttpWebResponse httpWebRespones = null;
            Stream stream = null;
            string htmlString = string.Empty;
            //请求页面
            try
            {
                httpWebRequest = WebRequest.Create(urlString) as HttpWebRequest;
            }
            //处理异常
            catch (Exception ex)
            {
                throw new Exception("建立页面请求时发生错误！", ex);
            }
            httpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 2.0.50727; Maxthon 2.0)";
            //获取服务器的返回信息
            try
            {
                httpWebRespones = (HttpWebResponse)httpWebRequest.GetResponse();
                stream = httpWebRespones.GetResponseStream();
            }
            //处理异常
            catch (Exception ex)
            {
                //throw new Exception("接受服务器返回页面时发生错误！", ex);
                return htmlString = "操作超时";
            }
            StreamReader streamReader = new StreamReader(stream, Encoding.UTF8);
            //读取返回页面
            try
            {
                htmlString = streamReader.ReadToEnd();
            }
            //处理异常
            catch (Exception ex)
            {
                throw new Exception("读取页面数据时发生错误！", ex);
            }
            //释放资源返回结果
            streamReader.Close();
            stream.Close();
            return htmlString;
        }
        #endregion

        #region 截取Json字符串
        /// <summary>
        /// 截取Json字符串
        /// </summary>
        /// <param name="json"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Json(string json, string key)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(json))
            {
                key = "\"" + key.Trim('"') + "\"";
                int index = json.IndexOf(key) + key.Length + 1;
                if (index > key.Length + 1)
                {
                    //先截逗号，若是最后一个，截“｝”号，取最小值
                    int end = json.IndexOf(',', index);
                    if (end == -1)
                    {
                        end = json.IndexOf('}', index);
                    }

                    result = json.Substring(index, end - index);
                    result = result.Trim(new char[] { '"', ' ', '\'' }); //过滤引号或空格
                }
            }
            return result;
        }
        #endregion


        public static string Post(string url, string param)
        {
            string strURL = url;
            System.Net.HttpWebRequest request;
            request = (System.Net.HttpWebRequest)WebRequest.Create(strURL);
            request.Method = "POST";
            request.ContentType = "application/json;charset=UTF-8";
            string paraUrlCoded = param;
            byte[] payload;
            payload = System.Text.Encoding.UTF8.GetBytes(paraUrlCoded);
            request.ContentLength = payload.Length;
            Stream writer = request.GetRequestStream();
            writer.Write(payload, 0, payload.Length);
            writer.Close();
            System.Net.HttpWebResponse response;
            response = (System.Net.HttpWebResponse)request.GetResponse();
            System.IO.Stream s;
            s = response.GetResponseStream();
            string StrDate = "";
            string strValue = "";
            StreamReader Reader = new StreamReader(s, Encoding.UTF8);
            while ((StrDate = Reader.ReadLine()) != null)
            {
                strValue += StrDate + "\r\n";
            }
            return strValue;
        }

        public static string SendMessage(string access_token, string touser, string agentid, string content)
        {
            string json = "{\"touser\":\"" + touser + "\",\"msgtype\":\"text\",\"agentid\":\"" + agentid + "\",\"text\":{\"content\":\"" + content + "\"}}";
            string result = Post(string.Format("https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token={0}", access_token), json);
            return Json(result, "errmsg");
        }

        private void TFT(string ip, int port)
        {
            //    zkemkeeper.CZKEMClass axCZKEM1 = new zkemkeeper.CZKEMClass();
            //    bool isconnect = false;
            //    isconnect = axCZKEM1.Connect_Net(ip, port);
            //    if (isconnect)
            //    {
            //        if (axCZKEM1.RegEvent(1, 65535))
            //        {
            //            axCZKEM1.OnAttTransactionEx += new zkemkeeper._IZKEMEvents_OnAttTransactionExEventHandler(axCZKEM1_OnAttTransactionEx);

            //        }
            //        //axCZKEM1.EnableDevice(1, false);
            //        while (true)
            //        {
            //            Thread.Sleep(1000);

            //            try
            //            {
            //                lock (locker)
            //                {
            //                    TFTIP = ip;
            //                    TFTPort = port;
            //                    if (axCZKEM1.ReadRTLog(1))
            //                    {
            //                        if (!axCZKEM1.GetRTLog(1))
            //                        {
            //                            isfirst = false;
            //                            //axCZKEM1.EnableDevice(1, true);

            //                        }
            //                        while (axCZKEM1.GetRTLog(1))
            //                        {
            //                            FileStream fs = new FileStream(@"d:\service.txt", FileMode.OpenOrCreate, FileAccess.Write);
            //                            StreamWriter sw = new StreamWriter(fs);
            //                            sw.BaseStream.Seek(0, SeekOrigin.End);
            //                            sw.WriteLine("WindowsService: Thread:" + Thread.CurrentThread.Name + "DateTime" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\n");
            //                            sw.Flush();
            //                            sw.Close();
            //                            fs.Close();
            //                        }
            //                    }
            //                    else
            //                    {
            //                        if (axCZKEM1.Connect_Net(ip, port))
            //                        {
            //                            isfirst = true;
            //                            //axCZKEM1.EnableDevice(1, false);
            //                        }

            //                    }
            //                }

            //                //FileStream fs = new FileStream(@"d:\service.txt", FileMode.OpenOrCreate, FileAccess.Write);
            //                //StreamWriter sw = new StreamWriter(fs);
            //                //sw.BaseStream.Seek(0, SeekOrigin.End);
            //                //sw.WriteLine("WindowsService: Thread:" + Thread.CurrentThread.Name + "DateTime" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\n");
            //                //sw.Flush();
            //                //sw.Close();
            //                //fs.Close();
            //            }
            //            catch (Exception ex)
            //            {
            //                FileStream fs = new FileStream(@"d:\service.txt", FileMode.OpenOrCreate, FileAccess.Write);
            //                StreamWriter sw = new StreamWriter(fs);
            //                sw.BaseStream.Seek(0, SeekOrigin.End);
            //                sw.WriteLine("WindowsService: Service Exception" + ex.Message + "\n");
            //                sw.Flush();
            //                sw.Close();
            //                fs.Close();

            //            }
            //        }


            //    }

        }

        public class XMLData
        {
            public string Agent;
            public string Secret;
            public string CorpID;
        }


        public static XMLData GetAgent(string filename, string agent, int type)
        {
            XMLData xmldata = new XMLData(); ;
            try
            {
                XmlDocument doc = new XmlDocument();
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.IgnoreComments = true;//忽略文档里面的注释
                string path = "";

                filename = filename.Replace("/", "\\");
                filename = filename.Replace("~", "");
                if (filename.StartsWith("\\"))
                {
                    filename = filename.TrimStart('\\');
                }
                path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename);

                XmlReader reader = XmlReader.Create(path, settings);
                doc.Load(reader);
                reader.Close();
                XmlNode wx = doc.SelectSingleNode("WX");
                XmlElement wxxe = (XmlElement)wx;

                if (int.Parse(wxxe.GetAttribute("IsOpen")) == 1)
                {
                    xmldata.CorpID = wxxe.GetAttribute("CorpID");
                    XmlNode xn;
                    if (type == 1)
                        xn = doc.SelectSingleNode("WX/Agent[@name=\"" + agent + "\"]");
                    else
                        xn = doc.SelectSingleNode("WX/TXL");
                    XmlElement ag = (XmlElement)xn;
                    xmldata.Agent = ag.GetAttribute("id");
                    if (xn != null)
                    {
                        XmlNodeList xnl = xn.ChildNodes;
                        xmldata.Secret = xnl.Item(0).InnerText;
                    }
                }
            }
            catch (Exception)
            {
            }
            return xmldata;
        }

        public DataTable DoSqlDT(string sql)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectstring))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                conn.Open();
                adapter.Fill(dt);
                adapter.Dispose();
                conn.Close();
            }

            return dt;
        }

        public void DoSql(string sql)
        {
            using (SqlConnection conn = new SqlConnection(connectstring))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conn.Close();
            }
        }

        protected override void OnStop()
        {
            FileStream fs = new FileStream(@"d:\service.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.BaseStream.Seek(0, SeekOrigin.End);
            sw.WriteLine("WindowsService: Service Stopped" + DateTime.Now.ToString() + "\n");
            sw.Flush();
            sw.Close();
            fs.Close();
        }



        



    }
}
