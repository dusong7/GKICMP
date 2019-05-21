/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      殷志瑞
** 创建日期:    2017年08月15日 08时30分
** 描 述:       缴费项目管理页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.payment
{
    public partial class PayProjectManage : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public PayItemDAL payItemDAL = new PayItemDAL();
        public PayProjectDAL payProjectDAL = new PayProjectDAL();


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonFunction.BindEnum<CommonEnum.IsorNot>(this.ddl_IsDisable, "-2");

                GetCondition();
                DataBindList();
            }
        }
        #endregion


        #region 获取查询条件
        public void GetCondition()
        {
            ViewState["ProjectName"] = CommonFunction.GetCommoneString(this.txt_ProjectName.Text.Trim());
            //ViewState["begin"] = this.txt_Begin.Text == "" ? "1900-01-01" : this.txt_Begin.Text;
            //ViewState["End"] = this.txt_End.Text == "" ? "9999-12-31" : this.txt_End.Text;
            ViewState["IsDisable"] = this.ddl_IsDisable.SelectedValue;
        }
        #endregion


        #region 数据绑定
        public void DataBindList()
        {
            int recordCount = 0;
            PayProjectEntity model = new PayProjectEntity();
            model.IsDisable = Convert.ToInt32(ViewState["IsDisable"].ToString());
            model.Isdel = Convert.ToInt32(CommonEnum.IsorNot.否);
            model.ProjectName = ViewState["ProjectName"].ToString();

            DataTable dt = payProjectDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
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

        #region 分页
        public void Pager_PageChanged(object sender, EventArgs e)
        {
            DataBindList();
        }
        #endregion

        #region 删除
        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                string ids = this.hf_CheckIDS.Value.TrimEnd(',');
                int result = payProjectDAL.DeleteBat(ids, (int)CommonEnum.Deleted.删除);
                if (result > 0)
                {
                    ShowMessage("删除成功");
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除缴费项目信息", UserID));
                }
                else
                {
                    ShowMessage("删除失败");
                    return;
                }
                DataBindList();
                this.hf_CheckIDS.Value = "";
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
            }
        }
        #endregion

        #region 停用
        protected void lbtn_IsDisable_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lb = (LinkButton)sender;
                string id = lb.CommandArgument.ToString();
                int result = payProjectDAL.UpdateByID(id, (int)CommonEnum.IsorNot.是);
                if (result > 0)
                {
                    ShowMessage("停用成功");
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "停用缴费项信息", UserID));
                }
                else
                {
                    ShowMessage("停用失败");
                    return;
                }
                DataBindList();
                this.hf_CheckIDS.Value = "";
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
            }
        }
        #endregion

        protected void lbtn_Set_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            string eid = lbtn.CommandArgument.ToString();
            string op = lbtn.CommandName.ToString();
            if (op == "set")
                //Response.Redirect("PayEdit.aspx?eid=" + eid, true);

                Response.Write("<script language=javascript>window.open('PayEdit.aspx?ID=" + eid + "', '_self')</script>");


        }

        protected void btn_Add_Click(object sender, EventArgs e)
        {
            //Response.Write("<script language=javascript>window.open('PayEdit.aspx', '_self')</script>");
            string aa = ("<script language=javascript>window.open('PayEdit.aspx', '_self')</script>");
            Response.Write(aa);
        }
    }
}