using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using GK.GKICMP.Common;

namespace DDService
{
    public class DDUtils
    {
        public List<JArray> CUserList = new List<JArray>();

        #region Post请求 Get请求 获取AccessToken
        private string PostData(string url, string postData)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] data = encoding.GetBytes(postData);
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);

            myRequest.Method = "POST";
            myRequest.ContentType = "text/xml";
            //myRequest.ContentType = "application/x-www-form-urlencoded";
            myRequest.ContentLength = data.Length;
            Stream newStream = myRequest.GetRequestStream();

            newStream.Write(data, 0, data.Length);
            newStream.Close();

            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
            string content = reader.ReadToEnd();
            reader.Close();
            return content;
        }

        private string GetData(string url)
        {
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
            myRequest.Method = "GET";
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
            string content = reader.ReadToEnd();
            reader.Close();
            return content;
        }

        public string GetAccessToken()
        {
            string accessget = GetData(string.Format("https://oapi.dingtalk.com/gettoken?appkey={0}&appsecret={1}", ParaUtils.appkey, ParaUtils.appsecret));

            JObject ja = (JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(accessget);

            return ja["access_token"].ToString();
        } 
        #endregion


        #region 获取钉钉通讯录总员工数
        public int GetFactoryEmployeeCount()
        {
            //onlyActive 0：包含未激活钉钉的人员数量 1：不包含未激活钉钉的人员数量
            int result = 0;
            string accesstoken = GetAccessToken();//获取AccessToken
            JObject returndata = (JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(GetData("https://oapi.dingtalk.com/user/get_org_user_count?onlyActive=0&access_token=" + accesstoken));
            if (returndata["errmsg"].ToString() == "ok")
            {
                result = Convert.ToInt32(returndata["count"].ToString());
            }

            FileStream jdh = new FileStream(@"d:\DDKQ.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter kdl = new StreamWriter(jdh);
            kdl.BaseStream.Seek(0, SeekOrigin.End);
            kdl.WriteLine("钉钉通讯录总人数：" + result);
            kdl.Flush();
            kdl.Close();
            jdh.Close();

            return result;

        }
        #endregion

        #region 分页查询企业在职员工userid列表  最大能获取50个  方法2
        public void ToBuildUserList(int i, int tt)
        {
            string accesstoken = GetAccessToken();//获取AccessToken
            JObject postdata = new JObject();
            postdata.Add("access_token", accesstoken);
            postdata.Add("status_list", "2,3,5");    //2 试用期；3 正式；5 待离职；-1 无状态
            postdata.Add("offset", tt);      //分页游标，从0开始
            postdata.Add("size", 50);        //分页大小，最大20
            JObject returndata = (JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(PostData("https://oapi.dingtalk.com/topapi/smartwork/hrm/employee/queryonjob?access_token=" + accesstoken, postdata.ToString()));
            if (returndata != null)
            {
                JArray RecordArray = (JArray)returndata["result"]["data_list"];
                CUserList.Add(RecordArray);

                FileStream jh = new FileStream(@"d:\DDKQ.txt", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter kl = new StreamWriter(jh);
                kl.BaseStream.Seek(0, SeekOrigin.End);
                kl.WriteLine("第" + tt + "到" + (tt + 49) + "条ID,总数为" + CUserList[i].Count + " 钉钉ID：" + CUserList[i]);
                kl.Flush();
                kl.Close();
                jh.Close();
            }
            else
            {
                FileStream bn = new FileStream(@"d:\DDKQ.txt", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter pl = new StreamWriter(bn);
                pl.BaseStream.Seek(0, SeekOrigin.End);
                pl.WriteLine("未获取到钉钉ID,原因：" + returndata);
                pl.Flush();
                pl.Close();
                bn.Close();
            }

        }
        #endregion

        //获取考勤数据
        public void GetAttendance(DateTime BeginDate, DateTime EndDate, JArray UserList)
        {

            try
            {
                string accesstoken = ConfigurationManager.AppSettings["AccessToken"];
                string expires = ConfigurationManager.AppSettings["AccessTokenExpires"];

                if (string.IsNullOrEmpty(accesstoken) || string.IsNullOrEmpty(expires) || Convert.ToDateTime(expires) < DateTime.Now)
                {
                    accesstoken = GetAccessToken();
                    var _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    _config.AppSettings.Settings["AccessToken"].Value = accesstoken;
                    _config.AppSettings.Settings["AccessTokenExpires"].Value = DateTime.Now.AddSeconds(7000).ToString("yyyy-MM-dd HH:mm:ss"); ;
                    _config.Save(ConfigurationSaveMode.Modified);
                }

                JObject postdata = new JObject();
                postdata.Add("access_token", accesstoken);
                postdata.Add("checkDateFrom", BeginDate.ToString("yyyy-MM-dd HH:mm:ss"));
                postdata.Add("checkDateTo", EndDate.ToString("yyyy-MM-dd HH:mm:ss"));
                postdata.Add("userIds", UserList);

                JObject returndata = (JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(PostData("https://oapi.dingtalk.com/attendance/listRecord?access_token=" + accesstoken, postdata.ToString()));

                if (returndata["errmsg"].ToString() == "ok")
                {
                    AnalysisAttendance((JArray)returndata["recordresult"]);//对考勤数据分析并插入到表中
                }
            }
            catch (Exception ex)
            {
                //FileStream fs = new FileStream(@"f:\DDKQ.txt", FileMode.OpenOrCreate, FileAccess.Write);
                //StreamWriter sw = new StreamWriter(fs);
                //sw.BaseStream.Seek(0, SeekOrigin.End);
                //sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":" + ex.Message);
                //sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":" + ex.InnerException.Message);
                //sw.Flush();
                //sw.Close();
                //fs.Close();
            }

        }

        //获取考勤数据 2
        public void ToGetAttendance(DateTime BeginDate, DateTime EndDate, List<JArray> CUserList, int i)
        {
            try
            {
                string accesstoken = "";
                string expires = "";
                accesstoken = GetAccessToken();
                expires = DateTime.Now.AddSeconds(7000).ToString("yyyy-MM-dd HH:mm:ss");

                JObject postdata = new JObject();
                postdata.Add("access_token", accesstoken);
                //postdata.Add("checkDateFrom", "2018-12-17 07:00:00");
                postdata.Add("checkDateFrom", BeginDate.ToString("yyyy-MM-dd HH:mm:ss"));
                postdata.Add("checkDateTo", EndDate.ToString("yyyy-MM-dd HH:mm:ss"));
                //postdata.Add("userIds", UserList);
                postdata.Add("userIds", CUserList[i]);

                JObject returndata = (JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(PostData("https://oapi.dingtalk.com/attendance/listRecord?access_token=" + accesstoken, postdata.ToString()));
                string ttt = returndata["recordresult"].ToString();//
                if (returndata["errmsg"].ToString() == "ok" && returndata["recordresult"].ToString() != "[]")
                {
                    AnalysisAttendance((JArray)returndata["recordresult"]);//对考勤数据分析并插入到表中
                }
                else
                {
                    FileStream cs = new FileStream(@"d:\DDKQ.txt", FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter kj = new StreamWriter(cs);
                    kj.BaseStream.Seek(0, SeekOrigin.End);
                    kj.WriteLine("在" + BeginDate.ToString("yyyy-MM-dd HH:mm:ss") + "到" + EndDate.ToString("yyyy-MM-dd HH:mm:ss") + "时间段内执行报错,未获取到考勤打卡记录：" + " 具体信息： " + returndata);
                    kj.Flush();
                    kj.Close();
                    cs.Close();
                }
            }
            catch (Exception ex)
            {
                FileStream fs = new FileStream(@"d:\DDKQ.txt", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.BaseStream.Seek(0, SeekOrigin.End);
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":" + ex.Message);
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":" + ex.InnerException.Message);
                sw.Flush();
                sw.Close();
                fs.Close();
            }

        }


        //数据插入执行
        //https://open-doc.dingtalk.com/microapp/serverapi2/kbsdmi
        #region 数据插入执行
        //public void AnalysisAttendance(JArray RecordArray)
        //{

        //    FileStream fs = new FileStream(@"f:\DDKQ.txt", FileMode.OpenOrCreate, FileAccess.Write);
        //    StreamWriter sw = new StreamWriter(fs);
        //    sw.BaseStream.Seek(0, SeekOrigin.End);
        //    sw.WriteLine("成功" + RecordArray.Count);
        //    sw.Flush();
        //    sw.Close();
        //    fs.Close();

        //    foreach (JObject RecordData in RecordArray)
        //    {
        //        try
        //        {
        //            string userId = RecordData["userId"].ToString();
        //            checkType checkType = (checkType)Enum.Parse(typeof(checkType), RecordData["checkType"].ToString());
        //            sourceType sourceType = (sourceType)Enum.Parse(typeof(sourceType), RecordData["sourceType"].ToString());
        //            string userCheckTime = TimeToDate(RecordData["userCheckTime"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");

        //            string addsql = "insert into Tb_AttendRecord ([ARID],[UserNum],[MachineCode],[RecordDate],[AttendType],[IsAnalysis],[AttendDesc],[OutType],[AttImg]) values (NewID(),'" + userId
        //              + "','" + (int)sourceType
        //              + "','" + userCheckTime
        //              + "','" + 0
        //              + "','" + (int)checkType
        //              + "','" + (int)checkType
        //              + "','" + 0
        //              + "','" + ""
        //              + "')";
        //            DoSql(addsql);
        //            //DoSql("insert into [Attendence] values ('" + userId + "','" + userCheckTime + "','" + (int)sourceType + "','" + (int)checkType + "')");
        //        }
        //        catch
        //        {
        //            //有些数据返回的不全
        //        }
        //    }
        //} 
        #endregion
        //数据插入执行 2
        public void AnalysisAttendance(JArray RecordArray)
        {
            FileStream fs = new FileStream(@"d:\DDKQ.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.BaseStream.Seek(0, SeekOrigin.End);
            sw.WriteLine("在" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "  成功获取考勤打卡条数：" + RecordArray.Count);
            sw.Flush();
            sw.Close();
            fs.Close();

            foreach (JObject RecordData in RecordArray)
            {
                string userCheckTime = "";
                checkType checkType = (checkType)Enum.Parse(typeof(checkType), "OnDuty");//考勤类型 OnDuty
                sourceType sourceType = (sourceType)Enum.Parse(typeof(sourceType), "DING_ATM");//打卡类型 DING_ATM

                try
                {
                    //有些数据返回的不全  需要判断
                    string userId = RecordData["userId"].ToString();//钉钉ID
                    if (RecordData.Property("checkType") != null)
                    {
                        checkType = (checkType)Enum.Parse(typeof(checkType), RecordData["checkType"].ToString());//考勤类型 OnDuty
                    }
                    if (RecordData.Property("sourceType") != null)
                    {
                        sourceType = (sourceType)Enum.Parse(typeof(sourceType), RecordData["sourceType"].ToString());//打卡类型
                    }
                    if (RecordData.Property("userCheckTime") != null)
                    {
                        userCheckTime = TimeToDate(RecordData["userCheckTime"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                    }

                    //checkType checkType = (checkType)Enum.Parse(typeof(checkType), RecordData["checkType"].ToString());//考勤类型
                    //sourceType sourceType = (sourceType)Enum.Parse(typeof(sourceType), RecordData["sourceType"].ToString());//打卡类型
                    //userCheckTime = TimeToDate(RecordData["userCheckTime"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                    ////string outsideRemark = RecordData["outsideRemark"].ToString();  //打卡备注


                    DataTable asmodel = DoSqlDT("select * from Tb_AttendSet where IsUse=1");
                    DateTime begindate = DateTime.Now, enddate = DateTime.Now;
                    int isanalysis = 0;//打卡结果类型
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

                    string addsql = "insert into Tb_AttendRecord ([ARID],[UserNum],[MachineCode],[RecordDate],[AttendType],[IsAnalysis],[AttendDesc],[OutType],[AttImg]) values (NewID(),'" + userId
                       + "','" + (int)sourceType
                       + "','" + userCheckTime
                       + "','" + (int)CommonEnum.AttendType.钉钉打卡  //5表示钉钉打卡
                       + "','" + isanalysis
                       + "','" + (int)checkType
                       + "','" + 0
                       + "','" + ""
                       + "')";
                    DoSql(addsql);

                    FileStream gs = new FileStream(@"d:\DDKQ.txt", FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter df = new StreamWriter(gs);
                    df.BaseStream.Seek(0, SeekOrigin.End);
                    df.WriteLine("钉钉ID：" + userId + "          打卡时间：" + userCheckTime + "\n");
                    df.Flush();
                    df.Close();
                    gs.Close();

                }
                catch (Exception ex)
                {
                    FileStream fc = new FileStream(@"d:\DDKQ.txt", FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter tg = new StreamWriter(fc);
                    tg.BaseStream.Seek(0, SeekOrigin.End);
                    tg.WriteLine("执行插入错误原因：" + ex.Message + "\n");
                    tg.Flush();
                    tg.Close();
                    fc.Close();
                    //有些数据返回的不全
                }
            }
        }



        #region 枚举
        public enum sourceType
        {
            ATM = 1,//考勤机
            BEACON = 2,//蓝牙
            DING_ATM = 3,//钉钉考勤机
            USER = 4,//用户打卡
            BOSS = 5,//老板改签
            APPROVE = 6,//审批系统
            SYSTEM = 7,//考勤系统
            AUTO_CHECK = 8//自动打卡
        }

        public enum timeResult
        {
            Normal = 1,//正常
            Early = 2,//早退
            Late = 3,//迟到
            SeriousLate = 4,//严重迟到
            Absenteeism = 5,//旷工迟到
            NotSigned = 6,//未打卡
        }

        public enum checkType
        {
            //上班
            OnDuty = 1,
            //下班
            OffDuty = 2
        }

        #endregion


        private DataTable DoSqlDT(string sql)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(ParaUtils.connectstring))
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
            using (SqlConnection conn = new SqlConnection(ParaUtils.connectstring))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conn.Close();
            }
        }

        private DateTime TimeToDate(string time)
        {
            long jsTimeStamp = long.Parse(time);
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); // 当地时区
            DateTime dt = startTime.AddMilliseconds(jsTimeStamp);
            return dt;
        }
    }
}
