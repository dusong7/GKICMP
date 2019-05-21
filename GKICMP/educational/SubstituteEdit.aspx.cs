/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年08月17日 09时44分17秒
** 描    述:      考试科目添加
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using System.Data;

namespace GKICMP.educational
{
    public partial class SubstituteEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SubstituteDAL subDAL = new SubstituteDAL();
        public TeacherPlaneDAL planeDAL = new TeacherPlaneDAL();
        public ScheduleCourseDAL scheduleCourseDAL = new ScheduleCourseDAL();
        #region 参数集合
        /// <summary>
        /// subid
        /// </summary>
        public int SubID
        {
            get
            {
                return GetQueryString<int>("id", -1);
            }
        }
        public int JC
        {
            get
            {
                return GetQueryString<int>("jc", -1);
            }
        }
        public string RQ
        {
            get
            {
                return GetQueryString<string>("date", "");
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
                this.txt_BeginTime.Text = RQ;
                this.txt_BeginTime.Enabled = false;
                this.txt_SubName.Text = "第" + JC.ToString().Substring(JC.ToString().Length - 1) + "节";
                this.txt_SubName.Enabled = false;
                DataTable dt = scheduleCourseDAL.getTeaByClass(JC,UserID);
                CommonFunction.DDlTypeBind(this.ddl_SubUser, dt, "TID", "TName", "-999");
               // DataTable course=scheduleCourseDAL.
                //if (SubID != -1)
                //{
                //    InfoBind();
                //}
            }
        }
        #endregion


        #region 初始化用户数据
        /// <summary>
        /// 初始化用户数据
        /// </summary>
        private void InfoBind()
        {
            SubstituteEntity model = subDAL.GetObjByID(SubID);
            if (model != null)
            {
                //this.ddl_SubType.SelectedValue = model.SubType.ToString();
                //this.ddl_SubCoruse.SelectedValue = model.SubCoruse.ToString();
                //this.txt_BeginTime.Text = model.SubBegin.ToString("yyyy-MM-dd");
                //this.txt_EndTime.Text = model.SubEnd.ToString("yyyy-MM-dd");
                //this.ddl_SubUser.SelectedValue = model.SubUser.ToString();
                //this.txt_SubName.Text = model.SubName.ToString();
                //this.txt_SubCount.Text = model.SubCount.ToString();
                //this.txt_ApplyReason.Text = model.ApplyReason.ToString();
            }
        }
        #endregion


        #region 提交事件
        /// <summary>
        /// 提交事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                //SubstituteEntity model = new SubstituteEntity();
                //model.SubID = SubID;
                //model.ApplyUser = UserID;
                //model.ApplyReason = this.txt_ApplyReason.Text.ToString().Trim();
                //if (this.txt_BeginTime.Text.ToString() != "" && this.txt_EndTime.Text.ToString() != "")
                //{
                //    try
                //    {
                //        if (Convert.ToDateTime(this.txt_BeginTime.Text.ToString()) < DateTime.Now)
                //        {
                //            ShowMessage("代课开始时间不可小于当前时间");
                //            return;
                //        }
                //        else if (Convert.ToDateTime(this.txt_BeginTime.Text.ToString()) > Convert.ToDateTime(this.txt_EndTime.Text.ToString()))
                //        {
                //            ShowMessage("代课结束日期不可小于代课开始日期");
                //            return;
                //        }
                //        else
                //        {
                //            model.SubBegin = Convert.ToDateTime(this.txt_BeginTime.Text.ToString());
                //            model.SubEnd = Convert.ToDateTime(this.txt_EndTime.Text.ToString());
                //        }
                //    }
                //    catch (Exception exc)
                //    {
                //        ShowMessage(exc.Message);
                //        sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志, exc.Message, UserID));
                //        return;
                //    }
                //}
                //else
                //{
                //    ShowMessage("代课日期不可为空");
                //    return;
                //}
                //model.SubUser = this.ddl_SubUser.SelectedValue.ToString();
                //if (this.txt_SubCount.Text != "")
                //{
                //    try
                //    {
                //        model.SubCount = Convert.ToInt32(this.txt_SubCount.Text.ToString());
                //    }
                //    catch
                //    {
                //        ShowMessage("节数输入有误，请修改后重新提交");
                //        return;
                //    }
                //}
                //else
                //{
                //    model.SubCount = 0;
                //}
                //model.SubState = (int)CommonEnum.PraState.申请中;
                //model.SubCoruse = Convert.ToInt32(this.ddl_SubCoruse.SelectedValue.ToString());
                //model.SubName = this.txt_SubName.Text.ToString();
                //model.SubType = Convert.ToInt32(this.ddl_SubType.SelectedValue.ToString());
                //model.Isdel = (int)CommonEnum.Deleted.未删除;

                //int result = subDAL.Edit(model);
                //if (result > 0)
                //{
                //    ShowMessage();
                //    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志, ((SubID == -1 ? "添加" : "修改") + (this.ddl_SubType.SelectedValue.ToString() == "1" ? "调课" : "代课")) + "信息", UserID));
                //}
                //else
                //{
                //    ShowMessage("提交失败");
                //    return;
                //}
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                return;
            }
        }
        #endregion
    }
}