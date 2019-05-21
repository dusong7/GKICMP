/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      LFZ
** 创建日期:    2017年01月03日
** 描 述:       政务详情页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Data;

namespace GKICMP.oamanage
{
    public partial class EgovernmentTR : PageBase
    {
        Egovernment_FlowDAL egovernment_FlowDAL = new Egovernment_FlowDAL();
        SysLogDAL sysLogDAL = new SysLogDAL();
        #region 页面加载
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
            Egovernment_FlowEntity model = new Egovernment_FlowEntity();
            model.ETitle = ViewState["ETitle"].ToString();
            model.Begin = Convert.ToDateTime(ViewState["Begin"]);
            model.End = Convert.ToDateTime(ViewState["End"]);
            model.AcceptUser = UserID;
            DataTable dt = egovernment_FlowDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model, 2);
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
        public string getVaule(object state)
        {
            string result = "true";
            if ((int)state == 1)
            {

            }
            else
            {
                result = "false";
            }
            return result;
        }


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


        #region 获取政务状态
        /// <summary>
        /// 获取政务状态
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public string getState(object state)
        {
            string value = "";
            if (state.ToString() == "0")
            {
                value = "<span style='color:red'>未处理</span>";
            }
            else if (state.ToString() == "1")
            {
                value = "<span style='color:blue'>批转中</span>";
            }
            else if (state.ToString() == "2")
            {
                value = "已处理";
            }
            else if (state.ToString() == "5")
            {
                value = "<span style='color:#48bd81'>已阅</span>";
            }
            else
            {
                value = "";
            }
            return value;
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
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除已收公文", UserID));
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
                Response.Write("<script language=javascript>window.open('EgovernmentDetail.aspx?type=2&flag=1&ID=" + id + "', '_self')</script>");
            }
            if (name == "PZ")
            {
                //aa = string.Format("<script language=javascript>window.open('Auditing.aspx?Type=1&ID={0}', '_self')</script>", id);
                Response.Write("<script language=javascript>window.open('EgovernmentDetail.aspx?type=2&flag=3&ID=" + id + "', '_self')</script>");
            }
            if (name == "YY")
            {
                //aa = string.Format("<script language=javascript>window.open('Auditing.aspx?Type=1&ID={0}', '_self')</script>", id);
                Response.Write("<script language=javascript>window.open('EgovernmentDetail.aspx?type=2&flag=2&ID=" + id + "', '_self')</script>");
            }
        }
    }
}