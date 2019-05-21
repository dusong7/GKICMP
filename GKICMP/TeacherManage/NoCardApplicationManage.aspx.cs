/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2017年05月17日 09点30分
** 描   述:      招标详情
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using GK.GKICMP.DAL;


namespace GKICMP.teachermanage
{
    public partial class NoCardApplicationManage : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public Teacher_HolidayDAL teacher_HolidayDAL = new Teacher_HolidayDAL();
        public NoCardApplyDAL noCardApplyDAL = new NoCardApplyDAL();

        public SysDataDAL sysDataDAL = new SysDataDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonFunction.BindEnum<CommonEnum.PraState>(this.ddl_NoCardState, "-2");
                DDLBind();
                DataBindList();
            }
        }

        #region 下拉框绑定
        /// <summary>
        /// 下拉框绑定
        /// </summary>
        private void DDLBind()
        {
            ViewState["NoCardApplyUser"] = CommonFunction.GetCommoneString(this.txt_NoCardApplyUser.Text.ToString().Trim());
            ViewState["NoCardState"] = this.ddl_NoCardState.SelectedValue;
            ViewState["begin"] = this.txt_SDate.Text == "" ? "1900-01-01" : this.txt_SDate.Text;  //开始时间
            ViewState["end"] = this.txt_EDate.Text == "" ? "9999-12-31" : this.txt_EDate.Text;     //结束时间
        }
        #endregion


        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {
            int recordCount = -1;
            NoCardApplyEntity model = new NoCardApplyEntity();
            model.NoCardState = Convert.ToInt32(ViewState["NoCardState"].ToString());
            model.NoCardApplyUser = ViewState["NoCardApplyUser"].ToString();
            DateTime begin = Convert.ToDateTime(ViewState["begin"].ToString());
            DateTime end = Convert.ToDateTime(ViewState["end"].ToString());
            int flag = 1; //1为补卡综合查询 2为补卡审核查询
            model.NoCardAuditUser = UserID;
            DataTable dt = noCardApplyDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model, begin, end,flag);
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
        protected void btn_Query_Click(object sender, EventArgs e)
        {
            Pager.CurrentPageIndex = 1;
            DDLBind();
            DataBindList();
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
            string ids = this.hf_CheckIDS.Value.ToString();
            try
            {
                ids = ids.TrimEnd(',').TrimStart(',');
                int result = noCardApplyDAL.DeleteBat(ids);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除考勤补卡信息", UserID));
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
                ShowMessage(ex.Message);
                return;
            }
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

        #region 导出事件
        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_OutPut_Click(object sender, EventArgs e)
        {
            int recordCount = -1;
            StringBuilder str = new StringBuilder();
            NoCardApplyEntity model = new NoCardApplyEntity();
            model.NoCardState = Convert.ToInt32(ViewState["NoCardState"].ToString());
            model.NoCardApplyUser = ViewState["NoCardApplyUser"].ToString();
            DateTime begin = Convert.ToDateTime(ViewState["begin"].ToString());
            DateTime end = Convert.ToDateTime(ViewState["end"].ToString());
            int flag = 1; //1为补卡综合查询 2为补卡审核查询
            model.NoCardAuditUser = UserID;
            DataTable dt = noCardApplyDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model, begin, end,flag);
            if (dt == null)
            {
                ShowMessage("暂无数据导出！");
                return;
            }
            str.Append(@"<table border='1' cellpadding='0' cellspacing='0' >
                                     <tr>
                                        <th><strong>申请人</strong></th>
                                        <th><strong>补卡时间点</strong></th>
                                        <th><strong>审核人</strong></th>
                                        <th><strong>审核状态</strong></th>
                                        </tr>");

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    str.Append("<tr>");
                    str.AppendFormat("<td>{0}</td>", row["NoCardApplyUserName"]);
                    str.AppendFormat("<td>{0}</td>", Convert.ToDateTime(row["NoCardApplyDate"].ToString()).ToString("yyyy-MM-dd"));
                    str.AppendFormat("<td>{0}</td>", row["NoCardAuditUserName"]);
                    str.AppendFormat("<td>{0}</td>", CommonFunction.CheckEnum<CommonEnum.PraState>(row["NoCardState"]));
                    str.Append("</tr>");
                }
            }
            CommonFunction.ExportExcel("考勤补卡信息表", str.ToString());
            sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_导出, "导出考勤补卡信息表", UserID));
        }
        #endregion


    }
}