/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月07日 09点30分
** 描   述:      排课计划
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

namespace GKICMP.educationals
{
    public partial class TeacherPlaneManage : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public TeacherPlaneDAL teacherPlaneDAL = new TeacherPlaneDAL();
        public ScheduleSetDAL scheduleSetDAL = new ScheduleSetDAL();
        public TeacherPlane_InfoDAL teacherPlaneInfoDAL = new TeacherPlane_InfoDAL();
        public ScheduleCourseDAL scheduleCourseDAL = new ScheduleCourseDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public static string message = "";


        #region 参数集合
        /// <summary>
        /// 班级ID
        /// </summary>
        public int ClaID
        {
            get
            {
                return GetQueryString<int>("id", -1);
            }
        }

        /// <summary>
        /// Depth
        /// </summary>
        public int Deep
        {
            get
            {
                return GetQueryString<int>("deep", -1);
            }
        }
        #endregion


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
                if (Deep != -1 && Deep != 0)
                {
                    this.taboperation.Visible = true;
                }
                else
                {
                    this.taboperation.Visible = false;
                }
                this.hf_DID.Value = ClaID.ToString();
                DepartmentEntity model = departmentDAL.GetObj(ClaID);
                if (model != null)
                {
                    this.lbl_ClaidName.Text = model.OtherName;
                }
                DataBindList();
            }
        }
        #endregion


        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {
            int recordCount = 0;
            int totalCount = 0;
            TeacherPlaneEntity model = new TeacherPlaneEntity();
            model.ClaID = ClaID;
            //DataTable dt = teacherPlaneDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model, ref totalCount);
            DataTable dt = teacherPlaneDAL.GetPaged(int.MaxValue, 1, ref recordCount, model, ref totalCount);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.tr_null.Visible = false;
            }
            else
            {
                this.tr_null.Visible = true;
            }
            this.rp_List.DataSource = dt;
            //Pager.RecordCount = recordCount;
            this.ltl_TotelHour.Text = totalCount.ToString();
            rp_List.DataBind();
            this.hf_CheckIDS.Value = "";
            // ScheduleSetEntity smodel = scheduleSetDAL.GetObjByID();

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
                int result = teacherPlaneDAL.DeleteByID(ids);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除排课计划信息", UserID));
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

     
    }
}