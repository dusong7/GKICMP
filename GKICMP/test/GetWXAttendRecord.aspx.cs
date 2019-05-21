
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using System.Web.Script.Serialization;
using System.Collections;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace GKICMP.test
{
    public partial class GetWXAttendRecord : System.Web.UI.Page
    {
        public SysUserDAL sysUserDAL = new SysUserDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                //InfoBind();

            }
        }
        public void InfoBind()
        {
            DataTable dtRecord = new DataTable();
            int begin = DateTimeToUnixInt(Convert.ToDateTime(this.txt_Begin.Text));
            int end = DateTimeToUnixInt(Convert.ToDateTime(this.txt_End.Text));
            string userlist = "";
            DataTable dtulist = sysUserDAL.GetUserID();
            
            if (dtulist != null && dtulist.Rows.Count > 0 )
            {
                foreach (DataRow dr in dtulist.Rows) 
                {
                    userlist += "\"" + dr["UserID"] + "\",";
                }
                //if (dtulist.Rows.Count > 100)
                //{
                //    for (int i = 0; i < 100; i++)
                //    {
                //        userlist += "\"" + dtulist.Rows[i]["UserID"] + "\",";
                       
                //    }
                //    dtRecord = GetAttendRecord(begin, end, userlist.TrimEnd(','));
                //}
                //else 
                //{
                //    for (int i = 0; i < 100; i++)
                //    {
                //        userlist += "\"" + dtulist.Rows[i]["UserID"] + "\",";
                //    }
                //}
            }

            List<Attend> dt = GetAttendRecord(begin, end, userlist.TrimEnd(','));
            if (dt != null && dt.Count > 0) 
            {

                this.tr_null.Visible = false;
            }
            this.rp_List.DataSource = dt;
            this.rp_List.DataBind();
        }
        public string GetM(object obj)
        {
            string[] s = (string[])obj;
            if (s != null & s.Length > 0)
            {

                return s[0];
            }
            else
                return "";
        }

        public string GetTime(object obj)
        {
            long jsTimeStamp = long.Parse(obj.ToString());
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)); // 当地时区
            DateTime dt = startTime.AddMilliseconds(jsTimeStamp*1000);
            return dt.ToString("yyyy-MM-dd HH:mm:ss");
        }


        //#region 查询事件
        ///// <summary>
        ///// 查询事件
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void btn_Search_Click(object sender, EventArgs e)
        //{
        //    Pager.CurrentPageIndex = 1;
        //    InfoBind();
        //}
        //#endregion


        #region 分页事件
        /// <summary>
        /// 分页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Pager_PageChanged(object sender, EventArgs e)
        {
            InfoBind();
        }
        #endregion
        public List<Attend> GetAttendRecord(int begin,int end,string userlist) 
        {
            List<Attend> list = new List<Attend>();
             DataTable dataTable = new DataTable();  //实例化
            DataTable result;
            string access_Token = WeixinQYAPI.GetToken(1, "Attend");
            string url = "https://qyapi.weixin.qq.com/cgi-bin/checkin/getcheckindata?access_token=" + access_Token;
            string param = "{\"opencheckindatatype\": 3, \"starttime\": " + begin + ", \"endtime\": " + end + ",\"useridlist\": [" + userlist + "]}";
            string json  = WeixinQYAPI.Post(url, param);
            if (WeixinQYAPI.Json(json, "errcode") == "0")
            {
                //Dictionary<string, object> dic = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
                ////获取具体数据部分
                //object obj = dic["checkindata"];
                ////将数据部分再次转换为json字符串
                //string jsondata = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                ////获取数据中的  不同类型的数据   
                //Dictionary<string, object> dicc = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(jsondata);

                ////chalssinfo 
                //object objclass = dicc["mediaids"];
                //string jsonclass = Newtonsoft.Json.JsonConvert.SerializeObject(objclass);
                //DataTable tclass = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(jsonclass);

              


                Dictionary<string, object> dic = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
                //获取具体数据部分
                object obj = dic["checkindata"];
                //将数据部分再次转换为json字符串
                string jsondata = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                ////获取数据中的  不同类型的数据   
                //Dictionary<string, object> dicc = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(jsondata);

                ////chalssinfo 
                //object objclass = dicc["datalist"];
                //string jsonclass = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                //JArray jo = (JArray)JsonConvert.DeserializeObject(jsonclass);
                //jo.ToObject<List<Attend>>();
                //Dictionary<string, object> dicc = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonclass);
                //object objclass = dicc["mediaids"];
                //string jsonm = Newtonsoft.Json.JsonConvert.SerializeObject(jsonclass);
                //jsonm=jsonm.Replace("[","");
                //jsonm = jsonm.Replace("]", "");


                //string jsonclass = "[{\"userid\":\"123999999\",\"groupname\":\"打卡测试\",\"checkin_type\":\"上班打卡\",\"exception_type\":\"时间异常\",\"checkin_time\":1523846521,\"location_title\":\"安徽明辉智能科技有限公司\",\"location_detail\":\"安徽省芜湖市镜湖区高新技术产业开发区郁金香花园\",\"wifiname\":\"未连接到公司指定WiFi\",\"notes\":\"\",\"wifimac\":\"\",\"mediaids\":\"\"}]";

                list = JSONStringToList<Attend>(obj.ToString());



                //dataTable = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(jsondata);
                //JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                //javaScriptSerializer.MaxJsonLength = Int32.MaxValue; //取得最大数值
                //ArrayList arrayList = javaScriptSerializer.Deserialize<ArrayList>(json);
                //if (arrayList.Count > 0)
                //{
                //    foreach (Dictionary<string, object> dictionary in arrayList)
                //    {
                //        if (dictionary.Keys.Count<string>() == 0)
                //        {
                //            result = dataTable;
                //            return result;
                //        }
                //        //Columns
                //        if (dataTable.Columns.Count == 0)
                //        {
                //            foreach (string current in dictionary.Keys)
                //            {
                //                dataTable.Columns.Add(current, dictionary[current].GetType());
                //            }
                //        }
                //        //Rows
                //        DataRow dataRow = dataTable.NewRow();
                //        foreach (string current in dictionary.Keys)
                //        {
                //            dataRow[current] = dictionary[current];
                //        }
                //        dataTable.Rows.Add(dataRow); //循环添加行到DataTable中
                //    }
                //}
                
            }
            //result = dataTable;
            //return result;


            return list;
        }
        public  int DateTimeToUnixInt(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }
        public static List<T> JSONStringToList<T>(string JsonStr)
        {
            JavaScriptSerializer Serializer = new JavaScriptSerializer();
            //设置转化JSON格式时字段长度
            List<T> objs = Serializer.Deserialize<List<T>>(JsonStr);
            return objs;
        }
    }
    public class Attend 
    {
        public string userid { get; set; }
        public string groupname { get; set; }
        public string checkin_type { get; set; }
        public string exception_type { get; set; }
        public string checkin_time { get; set; }
        public string location_title { get; set; }
        public string location_detail { get; set; }
        public string wifiname { get; set; }
        public string notes { get; set; }
        public string wifimac { get; set; }
        public string[] mediaids { get; set; }

    }
}