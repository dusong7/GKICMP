/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      lfz
** 创建日期:      2017年08月16日 16时54分10秒
** 描    述:      调代课操作类
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.educational
{
    public partial class DKAuditList : PageBase
    {
        public SubstituteDAL subDAL = new SubstituteDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();


        #region 页面初始化
        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCondition();
                DataBindList();
            }
        }
        #endregion


        #region 查询条件
        /// <summary>
        /// 查询条件
        /// </summary>
        private void GetCondition()
        {
            //ViewState["SubType"] = this.ddl_SubType.SelectedValue.ToString();
            ViewState["SubUser"] = CommonFunction.GetCommoneString(this.txt_SubUser.Text.ToString().Trim());
            ViewState["BeginDate"] = this.txt_BeginDate.Text == "" ? "1900-01-01" : this.txt_BeginDate.Text.ToString().Trim();
            ViewState["EndDate"] = this.txt_EndDate.Text == "" ? "9999-12-31" : this.txt_EndDate.Text.ToString().Trim();
        }
        #endregion


        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {
            int recordCount = -1;
            SubstituteEntity model = new SubstituteEntity();
            model.SubUser = (string)ViewState["SubUser"];
            model.SubBegin = Convert.ToDateTime(ViewState["BeginDate"].ToString());
            model.SubEnd = Convert.ToDateTime(ViewState["EndDate"].ToString());
            model.Isdel = (int)CommonEnum.Deleted.未删除;
            model.SubType = 2;
            model.SubState = (int)CommonEnum.PraState.申请中;
            DataTable dt = subDAL.GetPagedAudit(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
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
            this.rp_List.DataBind();
            this.hf_CheckIDS.Value = "";
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
            GetCondition();
            DataBindList();
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
            DataBindList();
        }
        #endregion

        protected void lbtn_Detail_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lbtn = (LinkButton)sender;
                string subid = lbtn.CommandArgument.ToString();

                int result = subDAL.Audit(int.Parse(subid),(int)CommonEnum.PraState.驳回,UserID);
                if (result > 0)
                {
                    ShowMessage("提交成功");
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "审核代课信息（驳回操作）", UserID));
                }
                else
                {
                    ShowMessage("提交失败");
                    return;
                }
                GetCondition();
                DataBindList();
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
            }
        }
    }
}