/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      殷志瑞
** 创建日期:    2017年06月03日
** 描 述:       已收通知公告页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using GK.GKICMP.DAL;
using System.Data;
using System.Web.UI.WebControls;
using System.Text;


namespace GKICMP.oamanage
{
    public partial class AfficheResearchManage : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public AfficheDAL afficheDAL = new AfficheDAL();
        public SysDataDAL sysDataDAL = new SysDataDAL();


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                GetCondition();
                DataBindList();
            }
        }
        #endregion


        #region 获取查询条件
        public void GetCondition()
        {
            int sdid = 0;
            DataTable rt = sysDataDAL.GetList((int)CommonEnum.IsorNot.否, (int)CommonEnum.DataType.通知公告);
            foreach (DataRow dr in rt.Rows)
            {
                string bb = dr["DataName"].ToString();
                if (dr["DataName"].ToString() == "教研活动")
                {
                    sdid = Convert.ToInt32(dr["SDID"].ToString());
                }
            }
            ViewState["AType"] = sdid;//教研通知


            ViewState["AfficheTitle"] = CommonFunction.GetCommoneString(this.txt_AfficheTitle.Text.Trim());
            ViewState["SendUser"] = CommonFunction.GetCommoneString(this.txt_SendUser.Text.Trim());
            ViewState["begin"] = this.txt_SDate.Text == "" ? "1900-01-01" : this.txt_SDate.Text;
            ViewState["end"] = this.txt_EDate.Text == "" ? "9999-12-31" : this.txt_EDate.Text;
        }
        #endregion


        #region 数据绑定
        public void DataBindList()
        {
            int recordCount = 0;
            AfficheEntity model = new AfficheEntity();
            model.AfficheTitle = ViewState["AfficheTitle"].ToString();
            model.SendUser = ViewState["SendUser"].ToString();
            model.AType = Convert.ToInt32(ViewState["AType"].ToString());
            DateTime begin = Convert.ToDateTime(ViewState["begin"].ToString());
            DateTime end = Convert.ToDateTime(ViewState["end"].ToString());
            DataTable dt = afficheDAL.GetPagedList(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model, begin, end);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.tr_null.Visible = false;
            }
            else
            {
                this.tr_null.Visible = true;
            }
            rp_List.DataSource = dt;
            Pager.RecordCount = recordCount;
            rp_List.DataBind();
            this.hf_CheckIDS.Value = "";
        }
        #endregion


        #region 查询
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            Pager.CurrentPageIndex = 1;
            GetCondition();
            DataBindList();
        }
        #endregion

        #region 通知公告查看
        /// <summary>
        /// 公告查看
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_View_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            string id = lbtn.CommandArgument.ToString();
            string users = lbtn.CommandName.ToString();
            string aa = string.Format("<script language=javascript>window.open('AfficheDetail.aspx?id={0}&flag=2&users={1}', '_self')</script>", id, users);
            Response.Write(aa);
        }
        #endregion


        #region 分页
        protected void Pager_PageChanged(object sender, EventArgs e)
        {
            DataBindList();
        }
        #endregion


        #region 导出事件
        /// <summary>
        /// 导出事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_OutPut_Click(object sender, EventArgs e)
        {
            int recordCount = -1;
            StringBuilder str = new StringBuilder();
            AfficheEntity model = new AfficheEntity();
            model.AfficheTitle = ViewState["AfficheTitle"].ToString();
            model.SendUser = ViewState["SendUser"].ToString();
            model.AType = Convert.ToInt32(ViewState["AType"].ToString());
            DateTime begin = Convert.ToDateTime(ViewState["begin"].ToString());
            DateTime end = Convert.ToDateTime(ViewState["end"].ToString());
            DataTable dt = afficheDAL.GetPagedList(2000, 1, ref recordCount, model, begin, end);

            str.Append(@"<table border='1' cellpadding='0' cellspacing='0' >
                                     <tr>
                                        <th><strong>教研标题</strong></th>
                                        <th><strong>发送人</strong></th>
                                        <th><strong>教研内容</strong></th>
                                        <th><strong>发送日期</strong></th>
                                        <th><strong>参与人</strong></th>
                                        <th><strong>不参与人</strong></th>
                                     </tr>");
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    str.Append("<tr>");
                    str.AppendFormat("<td>{0}</td>", row["AfficheTitle"]);
                    str.AppendFormat("<td>{0}</td>", row["SenduserName"]);
                    str.AppendFormat("<td>{0}</td>", row["AContent"]);
                    str.AppendFormat("<td>{0}</td>", row["SendDate"].ToString() == "" ? "" : Convert.ToDateTime(row["SendDate"]).ToString("yyyy-MM-dd HH:mm"));
                    str.AppendFormat("<td>{0}</td>", row["YD"]);
                    str.AppendFormat("<td>{0}</td>", row["WD"]);
                    str.Append("</tr>");
                }
            }
            CommonFunction.ExportExcel("教研活动导出", str.ToString());


        }
        #endregion


    }
}