/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      殷志瑞
** 创建日期:    2017年6月8日 18时04分
** 描 述:       排课基础设置管理
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;

namespace GKICMP.educationals
{
    public partial class BaseSet : PageBase
    {
        public ScheduleSetDAL setDAL = new ScheduleSetDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public TeacherPlaneDAL teacherPlaneDAL = new TeacherPlaneDAL();


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
                InfoBind();
            }
        }
        #endregion


        #region 提交事件
        /// <summary>
        /// 提交事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int count = teacherPlaneDAL.GetCount();
                ScheduleSetEntity model = new ScheduleSetEntity();
                model.CourseDay = Convert.ToInt32(this.txt_CourseDay.Text.ToString().Trim());
                model.MorningPitch = Convert.ToInt32(this.txt_MorningPitch.Text.Trim());
                model.AfterPitch = Convert.ToInt32(this.txt_AfterPitch.Text.Trim());
                model.EveningPitch = Convert.ToInt32(this.txt_EveningPitch.Text.Trim());
                model.NoTimetable = this.hf_timetable.Value.TrimEnd('|');
                model.IsMorningRead = 0;
                model.IsOptional = 0;
                model.IsSingle = 0;
                model.IsWeekly = 0;
                if ((model.AfterPitch + model.MorningPitch + model.EveningPitch) * model.CourseDay >= count)
                {
                    int result = setDAL.Edit(model);
                    if (result == 0)
                    {
                        sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, "添加排课基础设置", UserID));
                        ClientScript.RegisterStartupScript(GetType(), "Message", "<script>alert('提交成功');window.location='BaseSet.aspx'</script>");
                    }
                    else
                    {
                        ShowMessage("保存失败");
                        return;
                    }
                }
                else
                {
                    ShowMessage("设置一个班级的课程总数小于现有一个班级的课程总数：" + count + "，请重新设置班级课程总数或者删除班级计划");
                    return;
                }
                this.hf_timetable.Value = "";
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                ShowMessage(ex.Message);
            }
        }
        #endregion


        #region 初始化用户数据
        /// <summary>
        /// 初始化用户数据
        /// </summary>
        private void InfoBind()
        {
            ScheduleSetEntity model = setDAL.GetObjByID();
            if (model != null)
            {
                this.txt_CourseDay.Text = model.CourseDay.ToString();
                this.txt_MorningPitch.Text = model.MorningPitch.ToString();
                this.txt_AfterPitch.Text = model.AfterPitch.ToString();
                this.txt_EveningPitch.Text = model.EveningPitch.ToString();
                this.hf_timetable.Value = model.NoTimetable;
            }
        }
        #endregion
    }
}