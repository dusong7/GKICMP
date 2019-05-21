/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年03月02日 09点30分
** 描   述:       选课课程管理页面
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.Data;

namespace GKICMP.electiver
{
    public partial class ECourseManage : PageBase
    {
        public SysDataDAL sysDataDAL = new SysDataDAL();
        public ECourseDAL ecourseDAL = new ECourseDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public BaseDataDAL baseDataDAL = new BaseDataDAL();



        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = sysDataDAL.GetList((int)CommonEnum.IsorNot.否, (int)CommonEnum.DataType.课程类别);
                CommonFunction.DDlTypeBind(this.ddl_CourseType, dt, "SDID", "DataName", "-2");
                DataTable dt1 = baseDataDAL.GetList((int)CommonEnum.BaseDataType.课程等级, -1);
                CommonFunction.DDlTypeBind(this.ddl_CourseGrade, dt1, "SDID", "DataName", "-2");
                GetCondition();
                DataBindList();
            }
        }
        #endregion


        #region 获取查询条件
        public void GetCondition()
        {
            ViewState["CourseOther"] = CommonFunction.GetCommoneString(this.txt_CourseOther.Text.Trim());
            ViewState["CourseName"] = CommonFunction.GetCommoneString(this.txt_CourseName.Text.Trim());
            ViewState["CourseGrade"] = this.ddl_CourseGrade.SelectedValue;
            ViewState["CourseType"] = this.ddl_CourseType.SelectedValue;
        }
        #endregion

        #region 数据绑定
        public void DataBindList()
        {
            int recordCount = 0;
            ECourseEntity model = new ECourseEntity();
            model.CourseOther = ViewState["CourseOther"].ToString();
            model.CourseName = ViewState["CourseName"].ToString();
            model.CourseGrade = Convert.ToInt32(ViewState["CourseGrade"].ToString());
            model.CourseType = Convert.ToInt32(ViewState["CourseType"].ToString());
            model.Isdel = (int)CommonEnum.IsorNot.否;
            DataTable dt = ecourseDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
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
        protected void btn_Search_Click(object sender, EventArgs e)
        {
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
                int result = ecourseDAL.DeleteByID(ids, (int)CommonEnum.Deleted.删除);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除选课课程信息", UserID));
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