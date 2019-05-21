/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      殷志瑞
** 创建日期:    2016年11月10日
** 描 述:       资产调拨管理页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using System.Web.UI.HtmlControls;

namespace GKICMP.assetmanage
{
    public partial class AssetAllocationManage : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public Asset_AllocationDAL assetAllocationDAL = new Asset_AllocationDAL();


        #region 参数集合
        public int Flag
        {
            get
            {
                return GetQueryString<int>("flag", -1);
            }
        }
        #endregion


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.hf_Flag.Value = Flag.ToString();
                if (Flag == 1)
                {
                    this.ltl_OutDep.Text = "调出单位：";
                    this.ltl_Date.Text = "调拨日期：";
                    this.td_acceptdep.Visible = false;
                    this.ltl_Data.Text = "调拨日期";
                }
                else
                {
                    this.div.Visible = false;
                    this.ltl_OutDep.Text = "接收部门：";
                    this.ltl_Date.Text = "退回日期：";
                    this.ltl_Data.Text = "退回日期";
                    this.td_acceptuser.Visible = false;
                    this.td_indep.Visible = false;
                    this.td_outdep.Visible = false;
                    this.td_outuser.Visible = false;
                }
                GetCondition();
                DataBindList();
            }
        }
        #endregion


        #region 获取查询条件
        public void GetCondition()
        {
            ViewState["AcceptUser"] = CommonFunction.GetCommoneString(this.txt_AcceptUser.Text.Trim());
            ViewState["OutUser"] = CommonFunction.GetCommoneString(this.txt_OutUser.Text.Trim());
            ViewState["OutDep"] = CommonFunction.GetCommoneString(this.txt_OutDep.Text.Trim());
            ViewState["begin"] = this.txt_Begin.Text == "" ? "1900-01-01" : this.txt_Begin.Text;
            ViewState["end"] = this.txt_End.Text == "" ? "9999-12-31" : this.txt_End.Text;
        }
        #endregion


        #region 数据绑定
        public void DataBindList()
        {

            int recordCount = 0;
            Asset_AllocationEntity model = new Asset_AllocationEntity();
            model.AcceptUser = ViewState["AcceptUser"].ToString();
            model.OutUser = ViewState["OutUser"].ToString();
            DateTime begin = Convert.ToDateTime(ViewState["begin"].ToString());
            DateTime end = Convert.ToDateTime(ViewState["end"].ToString());
            model.OutDep = ViewState["OutDep"].ToString();
            model.AFlag = Flag;
            DataTable dt = assetAllocationDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model, begin, end);
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

            for (int i = 0; i < rp_List.Items.Count; i++)
            {
                if (Flag == 1)
                {
                    HtmlTableCell td_acceptdep1 = (HtmlTableCell)rp_List.Items[i].FindControl("td_acceptdep1");
                    td_acceptdep1.Visible = false;
                }
                else
                {
                    HtmlTableCell td_acceptuser1 = (HtmlTableCell)rp_List.Items[i].FindControl("td_acceptuser1");
                    HtmlTableCell td_indep1 = (HtmlTableCell)rp_List.Items[i].FindControl("td_indep1");
                    HtmlTableCell td_outdep1 = (HtmlTableCell)rp_List.Items[i].FindControl("td_outdep1");
                    HtmlTableCell td_outuser1 = (HtmlTableCell)rp_List.Items[i].FindControl("td_outuser1");
                    td_acceptuser1.Visible = false;
                    td_indep1.Visible = false;
                    td_outdep1.Visible = false;
                    td_outuser1.Visible = false;
                }
            }
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


        #region 删除
        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                string ids = this.hf_CheckIDS.Value.TrimEnd(',');
                int result = assetAllocationDAL.DeleteByID(ids, (int)CommonEnum.IsorNot.是);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除资产调拨信息", UserID));
                    ShowMessage("删除成功");
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
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                ShowMessage(ex.Message);
            }
        }
        #endregion


        #region 分页
        public void Pager_PageChanged(object sender, EventArgs e)
        {
            DataBindList();
        }
        #endregion
    }
}