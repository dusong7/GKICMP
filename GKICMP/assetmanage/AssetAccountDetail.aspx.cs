/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      201611月11日 9时55分47秒
** 描    述:     资产盘点详细页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.IO;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using GK.GKICMP.Common;


namespace GKICMP.assetmanage
{
    public partial class AssetAccountDetail : PageBase
    {
        public Asset_AccountDAL accountDAL = new Asset_AccountDAL();
        public Asset_Account_InfoDAL infoDAL = new Asset_Account_InfoDAL();


        #region 参数集合
        public string AAID
        {
            get
            {
                return GetQueryString<string>("id","");
            }
        }
        #endregion


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Asset_AccountEntity model = accountDAL.GetObjByID(AAID);
                if (model != null)
                {
                    this.ltl_AccBegin.Text = model.AccBegin.ToString("yyyy-MM-dd");
                    this.ltl_AccDesc.Text = model.AccDesc;
                    this.ltl_AccDuty.Text = model.AccdutyName;
                    this.ltl_AccEnd.Text = model.AccEnd.ToString("yyyy-MM-dd");
                    this.ltl_AccGroup.Text = model.AccGroup;
                    this.ltl_CreateDate.Text = model.CreateDate.ToString("yyyy-MM-dd");
                    this.ltl_CreaterUser.Text = model.CreateruserName;
                    this.ltl_AAFlag.Text = model.AAFlag == 1 ? "全部盘点" : "部门盘点";
                    this.ltl_DepID.Text = model.DepID == -2 ? "无" : model.DepartName;
                    BindInfo(model.AAID);
                }
            }
        }
        #endregion


        #region 获取资产详细信息数据
        public void BindInfo(string  aaid)
        {
            DataTable dt1 = infoDAL.GetPaged(aaid, (int)CommonEnum.AIType.有账无物);
            if (dt1 != null && dt1.Rows.Count > 0)
            {
                this.tr_null1.Visible = false;
            }
            else
            {
                this.tr_null1.Visible = true;
            }
            rp_List1.DataSource = dt1;
            rp_List1.DataBind();
            DataTable dt2 = infoDAL.GetPaged(aaid, (int)CommonEnum.AIType.有物无账);
            if (dt2 != null && dt2.Rows.Count > 0)
            {
                this.tr_null2.Visible = false;
            }
            else
            {
                this.tr_null2.Visible = true;
            }
            rp_List2.DataSource = dt2;
            rp_List2.DataBind();
        }
        #endregion


        #region 导出word
        protected void btn_Download_Click(object sender, EventArgs e)
        {
            //设置Http的头信息,编码格式  
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Charset = "gb2312";
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ClearHeaders();
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
            HttpContext.Current.Response.ContentType = "application/ms-word";
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=资产盘点详细信息.doc");
            //关闭控件的视图状态  ,如果仍然为true，RenderControl将启用页的跟踪功能，存储与控件有关的跟踪信息
            this.EnableViewState = false;
            //将要下载的页面输出到HtmlWriter  
            StringWriter writer = new StringWriter();
            HtmlTextWriter htmlWriter = new HtmlTextWriter(writer);
            this.RenderControl(htmlWriter);
            //提取要输出的内容  
            string pageHtml = writer.ToString();
            int startIndex = pageHtml.IndexOf("<div class=\"listcent pad0\" id=\"mainContent\">");
            int endIndex = pageHtml.LastIndexOf("</div>");
            int lenth = endIndex - startIndex;
            pageHtml = pageHtml.Substring(startIndex, lenth);
            //输出
            HttpContext.Current.Response.Write(pageHtml.ToString());
            HttpContext.Current.Response.End();
        } 
        #endregion
    }
}