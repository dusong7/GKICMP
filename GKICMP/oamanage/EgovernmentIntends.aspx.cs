
/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      lfz
** 创建日期:      2016年11月21日 16时12分29秒
** 描    述:      政务页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;

namespace GKICMP.oamanage
{
    public partial class EgovernmentIntends : PageBase
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
            ViewState["Begin"] = this.txt_Begin.Text == "" ? "1900-01-01" : this.txt_Begin.Text;
            ViewState["End"] = this.txt_End.Text == "" ? "9999-12-31" : this.txt_End.Text;
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
            DataTable dt = egovernment_FlowDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model, 0);//拟办：0，
            //DataTable dt = egovernment_FlowDAL.GetFJX(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
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
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除公文信息", "123"));
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

        #region 提交事件
        /// <summary>
        /// 提交事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                string ids = this.hf_CheckIDS.Value.ToString();
                ids = ids.TrimEnd(',').TrimStart(',');
                int result = egovernment_FlowDAL.UpdateBat(ids);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "提交成功", UserID));
                    ShowMessage("提交成功");
                }
                else
                {
                    ShowMessage("提交失败");
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
        public string GetAcceptName(object name, object count)
        {
            int counts = count == null ? 0 : Convert.ToInt32(count);

            if (counts < 2)
            {
                return name.ToString();
            }
            else
            {
                string[] a = name.ToString().Split(',');
                return a[0] + "等" + count.ToString() + "人";
            }

        }
        protected void btn_Add_Click(object sender, EventArgs e)
        {
            string aa = string.Format("<script  language=javascript>window.open('EgovernmentEdit.aspx', '_self')</script>");
            Response.Write(aa);
        }

        #region 操作事件
        protected void lbtn_Detail_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            string id = lbtn.CommandArgument.ToString();
            string name = lbtn.CommandName.ToString();
            if (name == "XQ")
            {
                //aa = string.Format("<script language=javascript>window.open('Auditing.aspx?Type=1&ID={0}', '_self')</script>", id);
                Response.Write("<script language=javascript>window.open('EgovernmentDetail.aspx?flag=1&ID=" + id + "', '_self')</script>");
            }
            if (name == "BJ")
            {
                //aa = string.Format("<script language=javascript>window.open('Auditing.aspx?Type=1&ID={0}', '_self')</script>", id);
                Response.Write("<script language=javascript>window.open('EgovernmentEdit.aspx?ID=" + id + "', '_self')</script>");
            }
        }
        #endregion

        //protected void btn_Add_Click(object sender, EventArgs e)
        //{
        //    string aa = string.Format("<script  language=javascript>window.open('EgovernmentEdit.aspx', '_self')</script>");
        //    Response.Write(aa);
        //}
    }
}