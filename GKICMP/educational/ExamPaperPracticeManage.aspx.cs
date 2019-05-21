/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年08月11日 13时55分15秒
** 描    述:      练习管理列表页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;

using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using GK.GKICMP.DAL;
using System.Data;

namespace GKICMP.educational
{

    public partial class ExamPaperPracticeManage : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public ExamPaper_PracticeDAL practiceDAL = new ExamPaper_PracticeDAL();


        #region 页面初始化
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
        public void GetCondition()
        {
            ViewState["PaperName"] = CommonFunction.GetCommoneString(this.txt_PaperName.Text.Trim());
            ViewState["begin"] = this.txt_BeginDate.Text == "" ? "1900-01-01 00:00:00" : this.txt_BeginDate.Text;
            ViewState["end"] = this.txt_EndDate.Text == "" ? "9999-12-31 23:59:59" : this.txt_EndDate.Text;
        }
        #endregion

        #region 数据绑定
        public void DataBindList()
        {
            int recordCount = 0;
            DateTime begin = Convert.ToDateTime(ViewState["begin"].ToString());
            DateTime end = Convert.ToDateTime(ViewState["end"].ToString());
            string name = ViewState["PaperName"].ToString();
            DataTable dt = practiceDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, begin, end, name);
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
                int result = practiceDAL.DeleteByID(ids, (int)CommonEnum.IsorNot.是);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除练习信息", UserID));
                    ShowMessage("删除成功");
                }
                else
                {
                    ShowMessage("删除失败");
                    return;
                }
                this.hf_CheckIDS.Value = "";
                DataBindList();
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