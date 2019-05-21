/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      殷志瑞
** 创建日期:     2017年03月03日
** 描 述:       基础数据编辑页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.Data;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace GKICMP.app
{
    public partial class cszybz : PageBaseApp
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public HomeWorkDAL homeWorkDAL = new HomeWorkDAL();
        public GradeDAL gradeDAL = new GradeDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public string agentId = "";
        public string corpId = "";
        public string CorpSecret = "";
        public string nonceStr = "GKDZ";
        public string signature = "";
        public string timestamp = "";
        public string accessToken = "";
        public string jsApiTicket = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetConfig();
                DataBindList();
            }

        }



        #region 获取jsapi签名验证处理
        private void GetConfig()
        {
            WeiXinInfoEntity model = XMLHelper.Get("~/QYWX.xml", "Notice", 1);
            corpId = model.CorpID;
            CorpSecret = model.Secret;
            agentId = model.Agent;
            accessToken = WeixinQYAPI.GetAccess_Token(corpId, CorpSecret);
            string ticket = WeixinQYAPI.RequestUrl(string.Format("https://qyapi.weixin.qq.com/cgi-bin/get_jsapi_ticket?access_token={0}", accessToken.Trim()));
            jsApiTicket = WeixinQYAPI.Json(ticket, "ticket");
            timestamp = timeStamp();
            string url = Request.Url.AbsoluteUri;
            string signature1 = "jsapi_ticket=" + jsApiTicket.Trim() + "&noncestr=" + nonceStr + "&timestamp=" + timestamp.Trim() + "&url=" + url.Trim();
            signature = FormsAuthentication.HashPasswordForStoringInConfigFile(signature1, "SHA1").ToLower();
        }
        #endregion


        #region 时间戳的随机数
        /// <summary>
        /// 时间戳的随机数
        /// </summary>
        /// <returns></returns>
        public static string timeStamp()
        {
            DateTime dt1 = Convert.ToDateTime("1970-01-01 00:00:00");
            TimeSpan ts = DateTime.Now - dt1;
            return Math.Ceiling(ts.TotalSeconds).ToString();
        }
        #endregion


        #region 绑定班级
        public void DataBindList()
        {
            DataTable dt = gradeDAL.GetGradeByUID(UserID);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.rpmodule.DataSource = dt;
                this.rpmodule.DataBind();
            }
        }


        protected void rpmodule_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Repeater rpnextModule = (Repeater)e.Item.FindControl("rpnextModule");
            HiddenField hf_GID = (HiddenField)e.Item.FindControl("hf_GID");
            DataTable dt = departmentDAL.GetClassByGID(Convert.ToInt32(hf_GID.Value), UserID);
            if (dt != null && dt.Rows.Count > 0)
            {
                rpnextModule.DataSource = dt;
                rpnextModule.DataBind();
            }
        }
        #endregion
    }
}