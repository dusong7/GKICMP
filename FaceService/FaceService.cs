using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FaceService
{
    public partial class FaceService : ServiceBase
    {
        private static string logpath = AppDomain.CurrentDomain.BaseDirectory + "log.txt";
        private CHCNetSDK.MSGCallBack m_falarmData = null;
        public string connectstring = "Data Source=192.168.202.25;User ID=sa;Password=admin@123;Initial Catalog=GK_YGHD;";
        private List<Device> devicelist = new List<Device>();
        private static object locker = new object();

        private class Device
        {
            public string IP { get; set; }
            public int ID { get; set; }
            public int OutType { get; set; }
        }

        public FaceService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Log("Service Start Date:" + GetDate());
            //获取摄像机表
            DataTable devicedt = DoSqlDT("select * from [Tb_AttendMachine] where [AttendType]=3");
            foreach (DataRow dr in devicedt.Rows)
            {
                devicelist.Add(new Device
                {
                    IP = dr["IPUrl"].ToString(),
                    ID = Convert.ToInt32(dr["MachineCode"]),
                    OutType = Convert.ToInt32(dr["OutType"]),
                });
            }
            //获取nvr
            if (CHCNetSDK.NET_DVR_Init())
            {

                CHCNetSDK.NET_DVR_SetConnectTime(5000, 1);
                CHCNetSDK.NET_DVR_SetReconnect(10000, 1);
                Log("Init Success Date:" + GetDate());
                string DVRIPAddress = "192.168.50.250"; //设备IP地址或者域名
                Int16 DVRPortNumber = 8000;//设备服务端口号
                string DVRUserName = "admin";//设备登录用户名
                string DVRPassword = "gkdz3821930";//设备登录密码

                CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo = new CHCNetSDK.NET_DVR_DEVICEINFO_V30();
                int m_lUserID = CHCNetSDK.NET_DVR_Login_V30(DVRIPAddress, DVRPortNumber, DVRUserName, DVRPassword, ref DeviceInfo);
                if (m_lUserID < 0)
                {
                    //登陆失败
                    uint mes = CHCNetSDK.NET_DVR_GetLastError();
                    Log("Login Failed Error Number:" + mes + " Date:" + GetDate());
                }
                else
                {
                    Log("Login Success Date:" + GetDate());

                    m_falarmData = new CHCNetSDK.MSGCallBack(MsgCallback);
                    CHCNetSDK.NET_DVR_SetDVRMessageCallBack_V30(m_falarmData, IntPtr.Zero);

                    CHCNetSDK.NET_DVR_SETUPALARM_PARAM struAlarmParam = new CHCNetSDK.NET_DVR_SETUPALARM_PARAM();

                    struAlarmParam.dwSize = (uint)Marshal.SizeOf(struAlarmParam);

                    long lHandle = CHCNetSDK.NET_DVR_SetupAlarmChan_V30(m_lUserID);

                    if (lHandle > -1)
                    {
                        Log("Alarm Success Date:" + GetDate());
                        while (1 == 1)
                        {
                            Thread.Sleep(1000);
                        }
                    }
                    else
                    {
                        Log("Alarm Failed Date:" + GetDate());
                    }

                }
            }
            else
            {
                Log("Init Failed Date:" + GetDate());
            }
        }



        private void MsgCallback(int lCommand, ref CHCNetSDK.NET_DVR_ALARMER pAlarmer, IntPtr pAlarmInfo, uint dwBufLen, IntPtr pUser)
        {
            //通过lCommand来判断接收到的报警信息类型，不同的lCommand对应不同的pAlarmInfo内容
            switch (lCommand)
            {
                case CHCNetSDK.COMM_SNAP_MATCH_ALARM://人脸对比报警信息
                    ProcessCommAlarm_FaceMatch(ref pAlarmer, pAlarmInfo, dwBufLen, pUser);
                    break;
                default:
                    break;
            }
        }


        private void ProcessCommAlarm_FaceMatch(ref CHCNetSDK.NET_DVR_ALARMER pAlarmer, IntPtr pAlarmInfo, uint dwBufLen, IntPtr pUser)
        {
            CHCNetSDK.NET_VCA_FACESNAP_MATCH_ALARM struFaceMatchAlarm = new CHCNetSDK.NET_VCA_FACESNAP_MATCH_ALARM();
            struFaceMatchAlarm = (CHCNetSDK.NET_VCA_FACESNAP_MATCH_ALARM)Marshal.PtrToStructure(pAlarmInfo, typeof(CHCNetSDK.NET_VCA_FACESNAP_MATCH_ALARM));

            //报警时间：年月日时分秒
            string strTimeYear = ((struFaceMatchAlarm.struSnapInfo.dwAbsTime >> 26) + 2000).ToString();
            string strTimeMonth = ((struFaceMatchAlarm.struSnapInfo.dwAbsTime >> 22) & 15).ToString("d2");
            string strTimeDay = ((struFaceMatchAlarm.struSnapInfo.dwAbsTime >> 17) & 31).ToString("d2");
            string strTimeHour = ((struFaceMatchAlarm.struSnapInfo.dwAbsTime >> 12) & 31).ToString("d2");
            string strTimeMinute = ((struFaceMatchAlarm.struSnapInfo.dwAbsTime >> 6) & 63).ToString("d2");
            string strTimeSecond = ((struFaceMatchAlarm.struSnapInfo.dwAbsTime >> 0) & 63).ToString("d2");
            string strTime = strTimeYear + "-" + strTimeMonth + "-" + strTimeDay + " " + strTimeHour + ":" + strTimeMinute + ":" + strTimeSecond;

            //string filepath = AppDomain.CurrentDomain.BaseDirectory;
            string filename = "";
            //保存图片
            //if (struFaceMatchAlarm.dwSnapPicLen > 0 && struFaceMatchAlarm.pSnapPicBuffer != null && Convert.ToInt32(struFaceMatchAlarm.byPicTransType) == 0)
            //{
            //    filename = strTimeYear + "_" + strTimeMonth + "_" + strTimeDay + "_" + strTimeHour + strTimeMinute + strTimeSecond + "_" + Guid.NewGuid().ToString() + ".jpg";

            //    byte[] byData = new byte[(int)struFaceMatchAlarm.dwSnapPicLen];
            //    Marshal.Copy((IntPtr)struFaceMatchAlarm.pSnapPicBuffer, byData, 0, (int)struFaceMatchAlarm.dwSnapPicLen);

            //    Bytes2File(byData, filepath + filename);
            //}

            string username = System.Text.Encoding.Default.GetString(struFaceMatchAlarm.struBlackListInfo.struBlackListInfo.struAttribute.byName);
            string deviceip = struFaceMatchAlarm.struSnapInfo.struDevInfo.struDevIP.sIpV4;
            try
            {
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

                DataTable userdt = DoSqlDT("select * from [Tb_SysUser] where [FaceNum]='" + username.Replace("\n", "").Replace("\t", "").Replace("\r", "").Replace("\0", "").Trim() + "'");
                if (userdt.Rows.Count > 0)
                {
                    string userid = userdt.Rows[0]["UID"].ToString();
                    Device device = devicelist.FirstOrDefault(t => t.IP == deviceip);
                    string addsql = "Insert Into Tb_AttendRecord ([ARID],[UserNum],[MachineCode],[RecordDate],[AttendType],[IsAnalysis],[AttendDesc],[OutType],[AttImg]) values (NEWID(),'" + userid + "','" + device.ID + "','" + strTime + "','0','" + isanalysis + "','','" + device.OutType + "','" + filename + "')";
                    DoSql(addsql);
                    Log("Match Success User:" + username + " Date:" + GetDate());
                }

            }
            catch
            {

            }
        }

        private string GetDate()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void Log(string message)
        {
            lock (locker)
            {
                FileStream fs = new FileStream(logpath, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.BaseStream.Seek(0, SeekOrigin.End);
                sw.WriteLine(message);
                sw.Flush();
                sw.Close();
                fs.Close();
            }
        }

        private void Bytes2File(byte[] buff, string savepath)
        {
            if (System.IO.File.Exists(savepath))
            {
                System.IO.File.Delete(savepath);
            }

            FileStream fs = new FileStream(savepath, FileMode.CreateNew);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(buff, 0, buff.Length);
            bw.Close();
            fs.Close();
        }



        private DataTable DoSqlDT(string sql)
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

        private void DoSql(string sql)
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
            Log("Service Stop Date:" + GetDate());
        }
    }
}
