/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月08日 09点30分
** 描   述:       分数等级管理
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using System.Data;
using GK.GKICMP.Entities;
using System.Web.UI.WebControls;

namespace GKICMP.educational
{
    public partial class ScoreLeaveManage : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public ScoreLevelDAL scoreLeaveDAL = new ScoreLevelDAL();
        public GradeDAL gradeDAL = new GradeDAL();
        public CourseDAL courseDAL = new CourseDAL();


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dtGrade = gradeDAL.GetListAll((int)CommonEnum.IsorNot.否);
                CommonFunction.DDlTypeBind(this.ddl_GID, dtGrade, "GID", "ShortGName", "-2");
                CommonFunction.BindEnum<CommonEnum.SLName>(this.ddl_SLName, "-2");
                DataTable dtCourse = courseDAL.GetList();
                CommonFunction.DDlTypeBind(this.ddl_CourseName, dtCourse, "CID", "CourseName", "-2");
                GetCondition();
                DataBindList();
            }
        }
        #endregion


        #region 删除
        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                string ids = this.hf_CheckIDS.Value.TrimEnd(',');
                int result = scoreLeaveDAL.DeleteByID(ids);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除分数等级信息", UserID));
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



        #region 获取查询条件
        public void GetCondition()
        {
            ViewState["GID"] = this.ddl_GID.SelectedValue;
            ViewState["CID"] = this.ddl_CourseName.SelectedValue;
            ViewState["SLName"] = Convert.ToInt32(this.ddl_SLName.SelectedValue) == -2 ? "" : Convert.ToInt32(this.ddl_SLName.SelectedValue) == (int)CommonEnum.SLName.不合格 ? CommonEnum.SLName.不合格.ToString() : Convert.ToInt32(this.ddl_SLName.SelectedValue) == (int)CommonEnum.SLName.合格 ? CommonEnum.SLName.合格.ToString() : Convert.ToInt32(this.ddl_SLName.SelectedValue) == (int)CommonEnum.SLName.良好 ? CommonEnum.SLName.良好.ToString() : CommonEnum.SLName.优秀.ToString();
        }
        #endregion


        #region 数据绑定
        public void DataBindList()
        {
            int recordCount = 0;
            ScoreLevelEntity model = new ScoreLevelEntity();
            model.GID = Convert.ToInt32(ViewState["GID"].ToString());
            model.SLName = ViewState["SLName"].ToString();
            model.CID = Convert.ToInt32(ViewState["CID"].ToString());
            DataTable dt = scoreLeaveDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.tr_null.Visible = false;
            }
            else
            {
                this.tr_null.Visible = true;
            }
            //this.rp_List.DataSource = dt;
            //this.rp_List.DataBind();

            this.rp_List.DataSource = dt;
            Pager.RecordCount = recordCount;
            rp_List.DataBind();
            this.hf_CheckIDS.Value = "";

        }
        #endregion


        #region 分页
        public void Pager_PageChanged(object sender, EventArgs e)
        {
            DataBindList();
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
    }
}