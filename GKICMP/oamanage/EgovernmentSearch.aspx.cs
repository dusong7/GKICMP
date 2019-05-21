/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      LFZ
** 创建日期:    2017年01月03日
** 描 述:       政务归档页面
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
    public partial class EgovernmentSearch : PageBase
    {
        Egovernment_FlowDAL egovernment_FlowDAL = new Egovernment_FlowDAL();
        EgovernmentDAL egovernmentDAL = new EgovernmentDAL();
        SysDataDAL sysDataDAL = new SysDataDAL();
        SysLogDAL sysLogDAL = new SysLogDAL();
        #region 页面加载
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = sysDataDAL.GetList((int)CommonEnum.Deleted.未删除, (int)CommonEnum.DataType.公文归档);
                CommonFunction.DDlTypeBind(this.ddl_State, dt, "SDID", "DataName", "-2");
                // CommonFunction.DDlDataBaseBind(this.ddl_State, (int)CommonEnum.DataType.公文归档);
                BindWhere();
                BindInfo();
            }
        }
        #endregion

        #region 查询条件
        public void BindWhere()
        {
            ViewState["ETitle"] = this.txt_ETitle.Text;
            ViewState["Begin"] = this.txt_Begin.Text == "" ? "1900-01-01 00:00:01" : this.txt_Begin.Text;
            ViewState["End"] = this.txt_End.Text == "" ? "9999-12-31 23:59:59" : this.txt_End.Text;
        }
        #endregion

        #region 数据绑定
        public void BindInfo()
        {
            int recordCount = -1;
            EgovernmentEntity model = new EgovernmentEntity();
            model.Etitle = ViewState["ETitle"].ToString();
            model.Begin = Convert.ToDateTime(ViewState["Begin"]);
            model.End = Convert.ToDateTime(ViewState["End"]);
            model.Etype = int.Parse(this.ddl_State.SelectedValue);
            DataTable dt = egovernmentDAL.GDList(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.tr_null.Visible = false;
            }
            else
            {
                this.tr_null.Visible = true;
            }
            this.rp_List.DataSource = dt;
            Pager.RecordCount = recordCount;
            rp_List.DataBind();
            this.hf_CheckIDS.Value = "";
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
            BindInfo();
        }
        #endregion

        #region 查询事件
        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            Pager.CurrentPageIndex = 1;
            BindWhere();
            BindInfo();
        }
        #endregion

        #region 删除事件
        /// <summary>
        /// 删除事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                string ids = this.hf_CheckIDS.Value.ToString();
                ids = ids.TrimEnd(',').TrimStart(',');
                int result = egovernment_FlowDAL.DeleteBat(ids);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除宿舍楼信息", UserID));
                    ShowMessage("删除成功");
                }
                else
                {
                    ShowMessage("删除失败");
                    return;
                }
                BindInfo();
                this.hf_CheckIDS.Value = "";
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                return;
            }
        }
        #endregion
        protected void lbtn_Detail_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            string id = lbtn.CommandArgument.ToString();
            string name = lbtn.CommandName.ToString();
            if (name == "XQ")
            {
                //aa = string.Format("<script language=javascript>window.open('Auditing.aspx?Type=1&ID={0}', '_self')</script>", id);
                Response.Write("<script language=javascript>window.open('EgovernmentGDDetail.aspx?flag=1&ID=" + id + "', '_self')</script>");
            }
            //if (name == "PZ")
            //{
            //    //aa = string.Format("<script language=javascript>window.open('Auditing.aspx?Type=1&ID={0}', '_self')</script>", id);
            //    Response.Write("<script language=javascript>window.open('EgovernmentDetail.aspx?flag=2&ID=" + id + "', '_self')</script>");
            //}
        }
    }
}