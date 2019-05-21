/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      lfz
** 创建日期:    2017年2月25日 09时17分
** 描 述:       课程选择页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;


namespace GKICMP.electiver
{
    public partial class ElectiverCourse : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public GradeLevelDAL gradeLevelDAL = new GradeLevelDAL();
        public Electiver_CourseDAL electiver_CourseDAL = new Electiver_CourseDAL();
        public Electiver_CourseGradeDAL electiver_CourseGradeDAL = new Electiver_CourseGradeDAL();
        public ECourseDAL eCourseDAL = new ECourseDAL();
        #region 参数集合
        /// <summary>
        /// UID
        /// </summary>
        public int EleID
        {
            get
            {
                return GetQueryString<int>("id", 0);
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CourseBind();
            }
        }
        public void CourseBind() 
        {
            DataTable dt = electiver_CourseDAL.GetList(EleID);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.tr_null.Visible = false;
            }
            else
            {
                this.tr_null.Visible = true;
            }
            this.rp_List.DataSource = dt;
            this.rp_List.DataBind();
        }
        #region 删除课程信息
        /// <summary>
        /// 删除请假审核人
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_Delete_Click(object sender, EventArgs e)
        {
            LinkButton ibtn = (LinkButton)sender;
            try
            {
                int istrue = electiver_CourseDAL.DeleteBat(ibtn.CommandArgument.ToString());
                if (istrue > 0)
                {
                    ShowMessage("删除成功");
                    CourseBind();
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
        #region 刷新页面
        /// <summary>
        /// 刷新页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtn_inquiry_Click(object sender, ImageClickEventArgs e)
        {
            CourseBind();
        }
        #endregion
    }
}