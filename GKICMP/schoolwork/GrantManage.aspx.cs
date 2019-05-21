/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      lfz
** 创建日期:      2016年11月21日 16时12分29秒
** 描    述:      助学金详情页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Data;
using System.Text;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;


namespace GKICMP.schoolwork
{
    public partial class GrantManage : PageBase
    {
        public GrantDAL grantDAL = new GrantDAL();
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


        #region 获取查询条件
        /// <summary>
        /// 获取查询条件
        /// </summary>
        private void GetCondition()
        {
            ViewState["BName"] = CommonFunction.GetCommoneString(this.txt_BName.Text.ToString().Trim());
            ViewState["Begin"] = this.txt_Begin.Text == "" ? "1990-01-01" : this.txt_Begin.Text;
            ViewState["End"] = this.txt_End.Text == "" ? "9999-12-31" : this.txt_End.Text;
        }
        #endregion


        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {
            int recordCount = -1;
            GrantEntity model = new GrantEntity((string)ViewState["BName"], Convert.ToDateTime(ViewState["Begin"]), Convert.ToDateTime(ViewState["End"]), (int)CommonEnum.Deleted.未删除);
            DataTable dt = grantDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
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
            DataBindList();
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
                int result = grantDAL.DeleteBat(ids, (int)CommonEnum.Deleted.删除);
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


        #region 导出
        protected void btn_OutPut_Click(object sender, EventArgs e)
        {
            int recordCount = -1;
            StringBuilder str = new StringBuilder();
            GrantEntity model = new GrantEntity((string)ViewState["BName"], Convert.ToDateTime(ViewState["Begin"]), Convert.ToDateTime(ViewState["End"]), (int)CommonEnum.Deleted.未删除);
            DataTable dt = grantDAL.GetPaged(99999, Pager.CurrentPageIndex, ref recordCount, model);
            if (dt == null && dt.Rows.Count == 0)
            {
                ShowMessage("暂无数据导出！");
                return;
            }
            str.Append(@"<table border='1' cellpadding='0' cellspacing='0' >
                            <tr>  
                                <th><strong>学生姓名</strong></th>                                
                                <th><strong>助学金类型</strong></th>
                                <th><strong>申请时间</strong></th>
                                <th><strong>审核时间</strong></th>
                                <th><strong>审核人</strong></th>
                                <th><strong>审核状态</strong></th>  
                            </tr>");
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    str.Append("<tr>");
                    str.AppendFormat("<td style='vnd.ms-excel.numberformat:@'>{0}</td>", row["UserName"]);
                    str.AppendFormat("<td>{0}</td>", CommonFunction.CheckEnum<CommonEnum.GrantType>(row["GType"]));
                    str.AppendFormat("<td>{0}</td>", row["CreateDate"].ToString() == "" ? "" : Convert.ToDateTime(row["CreateDate"]).ToString("yyyy-MM-dd"));
                    str.AppendFormat("<td>{0}</td>", row["AduitDate"].ToString() == "" ? "" : Convert.ToDateTime(row["AduitDate"]).ToString("yyyy-MM-dd"));
                    str.AppendFormat("<td>{0}</td>", row["AduitUserName"]);
                    str.AppendFormat("<td>{0}</td>", CommonFunction.CheckEnum<CommonEnum.AduitState>(row["AduitState"]));
                    str.Append("</tr>");

                }
            }
            CommonFunction.ExportExcel("学生助学金信息", str.ToString());
            sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_导出, "导出助学金信息", UserID));
        }
        #endregion
    }
}