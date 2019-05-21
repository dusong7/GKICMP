/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      yzr
** 创建日期:      2017年06月14日 13时43分25秒
** 描    述:      著作列表页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Data;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using System.Web.UI.WebControls;

namespace GKICMP.teachermanage
{
    public partial class TeacherJournalManage : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public Teacher_JournalDAL journalDAL = new Teacher_JournalDAL();


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonFunction.BindEnum<CommonEnum.IsorNot>(this.ddl_IsReport, "-2");
                CommonFunction.BindEnum<CommonEnum.JournalType>(this.ddl_JournalType, "-2");
                CommonFunction.BindEnum<CommonEnum.SubjectField>(this.ddl_SubjectArea, "-2");
                GetCondition();
                DataBindList();
            }
        }
        #endregion


        #region 获取查询条件
        public void GetCondition()
        {
            ViewState["TidName"] = CommonFunction.GetCommoneString(this.txt_TidName.Text.Trim());
            ViewState["IsReport"] = this.ddl_IsReport.SelectedValue;
            ViewState["JournalType"] = this.ddl_JournalType.SelectedValue;
            ViewState["SubjectArea"] = this.ddl_SubjectArea.SelectedValue;
            ViewState["begin"] = this.txt_Begin.Text == "" ? "1900-01-01" : this.txt_Begin.Text;
            ViewState["end"] = this.txt_End.Text == "" ? "9999-12-31" : this.txt_End.Text;
        }
        #endregion


        #region 数据绑定
        public void DataBindList()
        {
            int recordCount = 0;
            Teacher_JournalEntity model = new Teacher_JournalEntity();
            model.TidName = ViewState["TidName"].ToString();
            model.IsReport = Convert.ToInt32(ViewState["IsReport"].ToString());
            model.JournalType = Convert.ToInt32(ViewState["JournalType"].ToString());
            model.SubjectArea = ViewState["SubjectArea"].ToString();
            DateTime begin = Convert.ToDateTime(ViewState["begin"].ToString());
            DateTime end = Convert.ToDateTime(ViewState["end"].ToString());
            model.Isdel = Convert.ToInt32(CommonEnum.IsorNot.否);
            DataTable dt = journalDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model, begin, end);
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
        protected void btn_Query_Click(object sender, EventArgs e)
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


        #region 上报(单条)
        protected void lbtn_Report_Click(object sender, EventArgs e)
        {
            ShowMessage("暂不支持");
            //try
            //{
            //    LinkButton lbtn = (LinkButton)sender;
            //    string ids = lbtn.CommandArgument.ToString();
            //    int result = journalDAL.Update(ids, (int)CommonEnum.IsorNot.是);
            //    if (result > 0)
            //    {
            //        sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志, "上报著作信息", UserID));
            //        ShowMessage("上报成功");
            //    }
            //    else
            //    {
            //        ShowMessage("上报失败");
            //        return;
            //    }
            //    DataBindList();
            //    this.hf_CheckIDS.Value = "";
            //}
            //catch (Exception ex)
            //{
            //    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
            //    ShowMessage(ex.Message);
            //}
        }
        #endregion


        #region 多条上报
        protected void btn_Report_Click(object sender, EventArgs e)
        {
            ShowMessage("暂不支持");
            //try
            //{
            //    string ids = this.hf_CheckIDS.Value.TrimEnd(',');
            //    int result = journalDAL.Update(ids, (int)CommonEnum.IsorNot.是);
            //    if (result > 0)
            //    {
            //        sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志, "上报著作信息", UserID));
            //        ShowMessage("上报成功");
            //    }
            //    else
            //    {
            //        ShowMessage("上报失败");
            //        return;
            //    }
            //    DataBindList();
            //    this.hf_CheckIDS.Value = "";
            //}
            //catch (Exception ex)
            //{
            //    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
            //    ShowMessage(ex.Message);
            //}
        }
        #endregion


        #region 删除
        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                string ids = this.hf_CheckIDS.Value.TrimEnd(',');
                int result = journalDAL.DeleteByID(ids, (int)CommonEnum.Deleted.删除);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除著作信息", UserID));
                    ShowMessage("删除成功");
                }
                else
                {
                    ShowMessage("删除失败");
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


        #region 复选框是否可用
        public string Istrue(object isreport)
        {
            if (Convert.ToInt32(isreport.ToString()) == Convert.ToInt32(CommonEnum.IsorNot.是))
            {
                return "disabled";
            }
            else
            {
                return "";
            }
        }
        #endregion
    }
}