/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      殷志瑞
** 创建日期:    2017年6月7日 18时04分
** 描 述:       排课计划
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using System.Text;
using GK.GKICMP.Entities;

namespace GKICMP.educational
{
    public partial class CourseHourEdit : PageBase
    {
        public Course_HourDAL course_HourDAL = new Course_HourDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public CourseDAL courseDAL = new CourseDAL();
        #region 参数集合
        /// <summary>
        /// TPID 排课计划ID
        /// </summary>
        public int CHID
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
                DataTable dtCourse = courseDAL.GetList();
                CommonFunction.DDlTypeBind(this.ddl_CourseName, dtCourse, "CID", "CourseName", "-2");
                if (CHID != 0) 
                {
                    InfoBind();
                }
            }
        }
        #region 初始化用户数据
        /// <summary>
        /// 初始化用户数据
        /// </summary>
        private void InfoBind()
        {
            Course_HourEntity model = course_HourDAL.GetObjByID(CHID);
            if (model != null)
            {
                this.ddl_CourseName.SelectedValue = model.CID.ToString();
                this.txt_GID.Text = model.GID.ToString();
                this.txt_CHours.Text = model.CHours.ToString();
            }
        }
        #endregion
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                Course_HourEntity model = new Course_HourEntity();
                model.CHID = CHID;
                model.CID = int.Parse(this.ddl_CourseName.SelectedValue);
                model.Gids = this.txt_GID.Text;
                model.CHours = decimal.Parse(this.txt_CHours.Text);
                model.CreateDate = DateTime.Now;
                model.CreateUser = UserID;
                int result = course_HourDAL.Edit(model);
                if (result == 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, (CHID == 0 ? "添加" : "编辑") + "课程系数信息", UserID));
                    ShowMessage();
                }
                else if (result == -1)
                {
                    ShowMessage("所选择年级与课程在系统中已有，请勿重复添加");
                    return;
                }
                else
                {
                    ShowMessage("提交失败");
                    return;
                }

            }
            catch (Exception error)
            {
                  sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加,error.Message , UserID));
                  ShowMessage(error.Message);
                  return;
            }
        }
    }
}