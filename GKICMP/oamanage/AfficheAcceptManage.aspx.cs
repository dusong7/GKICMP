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

namespace GKICMP.oamanage
{
    public partial class AfficheAcceptManage : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public AfficheDAL afficheDAL = new AfficheDAL();
        public SysDataDAL sysDataDAL = new SysDataDAL();


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
               if(!IsPostBack)
               {
                   DataTable dt = sysDataDAL.GetList((int)CommonEnum.IsorNot.否, (int)CommonEnum.DataType.通知公告);
                   CommonFunction.DDlTypeBind(this.ddl_AType, dt, "SDID", "DataName", "-2");
                   CommonFunction.BindEnum<CommonEnum.IsorNot>(this.ddl_IsRead, "-2");
                   GetCondition();
                   DataBindList();
               }
        }
        #endregion


        #region 获取查询条件
        public void GetCondition()
        {
            ViewState["AfficheTitle"] = CommonFunction.GetCommoneString(this.txt_AfficheTitle.Text.Trim());
            ViewState["AType"] = this.ddl_AType.SelectedValue;
            ViewState["IsRead"] = this.ddl_IsRead.SelectedValue;
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
            model.AType = Convert.ToInt32(ViewState["AType"].ToString());
            model.IsRead = Convert.ToInt32(ViewState["IsRead"].ToString());
            DateTime begin = Convert.ToDateTime(ViewState["begin"].ToString());
            DateTime end = Convert.ToDateTime(ViewState["end"].ToString());
            DataTable dt = afficheDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model, begin, end, 2, UserID);
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
    }
}