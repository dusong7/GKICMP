/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      殷志瑞
** 创建日期:    2017年06月03日
** 描 述:       已发通知公告页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;
using System.Web.UI.WebControls;

using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using GK.GKICMP.DAL;

namespace GKICMP.oamanage
{
    public partial class AfficheManage : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public AfficheDAL afficheDAL = new AfficheDAL();
        public SysDataDAL sysDataDAL = new SysDataDAL();


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = sysDataDAL.GetList((int)CommonEnum.IsorNot.否, (int)CommonEnum.DataType.通知公告);
                CommonFunction.DDlTypeBind(this.ddl_AType, dt, "SDID", "DataName", "-2");
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
            model.IsRead = -2;
            DateTime begin = Convert.ToDateTime(ViewState["begin"].ToString());
            DateTime end = Convert.ToDateTime(ViewState["end"].ToString());
            DataTable dt = afficheDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model, begin, end, 1, UserID);
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
            //this.hf_Page.Value = "";
            Pager.CurrentPageIndex = 1;

            GetCondition();
            DataBindList();
        }
        #endregion


        #region 分页
        protected void Pager_PageChanged(object sender, EventArgs e)
        {
            DataBindList();
        }
        #endregion


        #region 撤销
        protected void lbtn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lb = (LinkButton)sender;
                string aid = lb.CommandArgument.ToString();
                string user = lb.CommandName.ToString();
                int result = afficheDAL.DeleteByID(aid, user);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "撤销通知通告信息", UserID));
                    ShowMessage("撤销成功");
                }
                else
                {
                    ShowMessage("撤销失败");
                    return;
                }
                DataBindList();
                this.hf_CheckIDS.Value = "";
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                ShowMessage(ex.Message);
            }
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
            string aa = string.Format("<script language=javascript>window.open('AfficheDetail.aspx?id={0}&flag=1&users={1}', '_self')</script>", id, users);
            Response.Write(aa);
        }
        #endregion


        #region 添加
        protected void btn_Add_Click(object sender, EventArgs e)
        {
            string aa = string.Format("<script language=javascript>window.open('AfficheEdit.aspx', '_self')</script>");
            Response.Write(aa);
        }
        #endregion
    }
}