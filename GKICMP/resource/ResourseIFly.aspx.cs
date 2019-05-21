/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年01月19日 09时41分19秒
** 描    述:      智慧云平台对接
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Text.RegularExpressions;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Web.UI.WebControls;

namespace GKICMP.resource
{
    public partial class ResourseIFly : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int years=DateTime.Now.Year-2014;
                for (int i = 0; i < years; i++)
                {
                    this.ddl_Year.Items.Add(new ListItem((DateTime.Now.Year - i).ToString(), (DateTime.Now.Year - i).ToString()));
                }
                //string uid = "18226530705";
                string login = SysUserName+"_zhxy_ifly123!@#";
                string token = MD5(login);
                string url = "http://zh.jyj.wuhu.gov.cn/manage/login_fromAnhuiPlatform.action?appName=zhxy&loginName=" + SysUserName + "&token=" + token;
                Response.Write(" <script type='text/JavaScript'>window.open('" + url + "','_blank'); </script>");
                //  Page.ClientScript.RegisterStartupScript(Page.GetType(), "IFLY", "window.open('" + url + "', '')", true);
                //  Response.Redirect(url, false);
                DataBindList();
                //string json = "{\"code\":0,\"data\":{\"currentPage\":1,\"datalist\":[{\"courseWareNum\":1,\"crtDttm\":1512316800000,\"indexCd\":\"0001000100040001000100040002\",\"lastupDttm\":1512316800000,\"learnGuideNum\":0,\"minPeriod\":0,\"minVideoNum\":0,\"preInfoId\":1150943,\"preInfoName\":\"10* 幸福是什么   【第1课时】\",\"prepareFileId\":1361627,\"schoolId\":\"2034020016000000001\",\"schoolYear\":2017,\"shareFlg\":0,\"teachDesignNum\":1,\"teachThinkNum\":0,\"testPaperNum\":0,\"writer\":\"2034020016000000263\"},{\"courseWareNum\":0,\"crtDttm\":1511452800000,\"indexCd\":\"0001000100040001000100030005\",\"lastupDttm\":1511452800000,\"learnGuideNum\":0,\"minPeriod\":0,\"minVideoNum\":0,\"preInfoId\":1150941,\"preInfoName\":\"词语盘点   【第1课时】\",\"prepareFileId\":1361623,\"schoolId\":\"2034020016000000001\",\"schoolYear\":2017,\"shareFlg\":0,\"teachDesignNum\":1,\"teachThinkNum\":0,\"testPaperNum\":1,\"writer\":\"2034020016000000263\"}],\"pageSize\":10,\"totalCount\":2,\"totalPages\":1},\"msg\":\"成功\"}";
            }
        }
        public String MD5(string str)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bytValue, bytHash;
            bytValue = System.Text.Encoding.UTF8.GetBytes(str);
            bytHash = md5.ComputeHash(bytValue);
            md5.Clear();
            string sTemp = "";
            for (int i = 0; i < bytHash.Length; i++)
            {
                sTemp += bytHash[i].ToString("X").PadLeft(2, '0');
            }
            return sTemp.ToLower();
        }
        #region 获取的json数据绑定
        public void DataBindList()
        {
            string urlr = "http://zh.jyj.wuhu.gov.cn/rest/smartCampusResouceWs.json?loginName=" + SysUserName + "&course=" + this.ddl_Course.SelectedValue + "&year=" + this.ddl_Year.SelectedValue + "&appName=zhxy&curPage=" + Pager.CurrentPageIndex;
            string json = WeixinQYAPI.RequestUrl(urlr);
            if (WeixinQYAPI.Json(json, "code") == "0")
            {
                List(json);
            }
            else 
            {
                ShowMessage(WeixinQYAPI.Json(json, "msg"));
            }
           
        }
        public void List(string json)
        {
            try
            {
                Dictionary<string, object> dic = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
                //获取具体数据部分
                object obj = dic["data"];
                //将数据部分再次转换为json字符串
                string jsondata = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                //获取数据中的  不同类型的数据   
                Dictionary<string, object> dicc = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(jsondata);

                //chalssinfo 
                object objclass = dicc["datalist"];
                string jsonclass = Newtonsoft.Json.JsonConvert.SerializeObject(objclass);
                DataTable tclass = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(jsonclass);
                if (tclass != null && tclass.Rows.Count > 0)
                {
                    this.tr_null.Visible = false;
                }
                this.rp_List.DataSource = tclass;
                this.rp_List.DataBind();
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                ShowMessage("获取数据失败");
                return;
            }
            //otherinfo 
            //object objother = dicc["otherinfo"];
            //string jsonother = Newtonsoft.Json.JsonConvert.SerializeObject(objother);
            //DataTable tother = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(jsonother);

            //string url = "";
            //string json = WeixinQYAPI.RequestUrl(url);
            //List<string> jobInfoList = JsonConvert.DeserializeObject<List<Info>>(json);

            //foreach (string jobInfo in jobInfoList)
            //{
            //    Console.WriteLine("UserName:" + jobInfo.id);
            //}
        } 
        #endregion
        #region 分页事件
        /// <summary>
        /// 分页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Pager_PageChanged(object sender, EventArgs e)
        {
            DataBindList();
        }
        #endregion
        public string GetDate(object obj)
        {
            //DateTime dt1 = Convert.ToDateTime("1970-01-01 00:00:00");
            //TimeSpan ts = DateTime.Now - dt1;
            //return Math.Ceiling(ts.TotalSeconds).ToString();
            long jsTimeStamp = long.Parse(obj.ToString());
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970,1,1)); // 当地时区
            DateTime dt = startTime.AddMilliseconds(jsTimeStamp);
            return dt.ToString("yyyy-MM-dd HH:mm:ss");
        }

        protected void btn_Search_Click(object sender, EventArgs e)
        {
            DataBindList();
        }
    }
}