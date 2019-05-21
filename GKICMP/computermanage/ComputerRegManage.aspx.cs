/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      lfz
** 创建日期:     2017年03月03日
** 描 述:       基础数据编辑页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Data;
using System.Web.UI.WebControls;
using System.Text;


namespace GKICMP.computermanage
{
    public partial class ComputerRegManage : PageBase
    {
        public ComputerRegDAL computerRegDAL = new ComputerRegDAL();
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
            ViewState["UserName"] = CommonFunction.GetCommoneString(this.txt_UserName.Text.ToString().Trim());
            //ViewState["SchoolName"] = CommonFunction.GetCommoneString(this.txt_SchoolName.Text.ToString().Trim());
            ViewState["BeginDate"] = this.txt_BeginDate.Text == "" ? "1900-01-01" : this.txt_BeginDate.Text.ToString();
            ViewState["EndDate"] = this.txt_EndDate.Text == "" ? "9999-12-31" : this.txt_EndDate.Text.ToString();

        }
        #endregion


        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {
            int recordCount = -1;
            ComputerRegEntity model = new ComputerRegEntity();
            model.SysID = (string)ViewState["UserName"];
            DataTable dt = computerRegDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model, Convert.ToDateTime(ViewState["BeginDate"].ToString()), Convert.ToDateTime(ViewState["EndDate"].ToString()));
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


        #region 删除事件
        /// <summary>
        /// 删除事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lbtn = (LinkButton)sender;
                string id = lbtn.CommandArgument.ToString();

                int result = computerRegDAL.DeleteBat(id);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除班班通使用统计信息", UserID));
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
                return;
            }
        }
        #endregion


        #region 详情跳转
        /// <summary>
        /// 详情跳转
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_Detail_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            string id = lbtn.CommandArgument.ToString();
            string aa = string.Format("<script language=javascript>window.open('ComputerRegDetail.aspx?id={0}', '_self')</script>", id);
            Response.Write(aa);
        }
        #endregion


        #region 导出
        protected void btn_OutPut_Click(object sender, EventArgs e)
        {
            try
            {
                int recordCount = -1;
                ComputerRegEntity model = new ComputerRegEntity();

                model.SysID = (string)ViewState["UserName"];
                DataTable dt = computerRegDAL.GetPaged(40000, 1, ref recordCount, model, Convert.ToDateTime(ViewState["BeginDate"].ToString()), Convert.ToDateTime(ViewState["EndDate"].ToString()));
               

                if (dt != null && dt.Rows.Count > 0)
                {
                    StringBuilder str = new StringBuilder("");
                    str.Append("<table border='1' cellpadding='0' cellspaccing='0'><tr><th>姓名</th><th>学科</th><th>课题</th><th>MAC计算机名</th><th>IP地址</th><th>登记形式</th><th>登记时间</th></tr>");
                    foreach (DataRow row in dt.Rows)
                    {
                        str.Append("<tr>");
                        str.AppendFormat("<td>{0}</td>", row["UserName"]);
                        str.AppendFormat("<td>{0}</td>", row["CName"]);
                        str.AppendFormat("<td>{0}</td>", row["ChapterName"]);
                        str.AppendFormat("<td>{0}</td>", row["ComputerName"]);
                        str.AppendFormat("<td>{0}</td>", row["IP"]);
                        str.AppendFormat("<td>{0}</td>", CommonFunction.CheckEnum<CommonEnum.RegType>(row["RegType"]));
                        str.AppendFormat("<td>{0}</td>", Convert.ToDateTime(row["RegDate"]).ToString("yyyy-MM-dd HH:mm:ss"));
                        str.Append("</tr>");
                    }
                    str.Append("</table>");
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_导出, "导出使用登记信息", UserID));
                    CommonFunction.ExportExcel("使用登记", str.ToString());
                }
                else
                {
                    ShowMessage("暂无数据导出");
                    return;
                }
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                ShowMessage(ex.Message);
            }
        }
        #endregion
    }
}