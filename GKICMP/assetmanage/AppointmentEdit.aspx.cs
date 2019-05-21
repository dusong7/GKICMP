/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2016年12月28日 16时34分38秒
** 描    述:      教室基本操作类
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Configuration;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;


using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.assetmanage
{
    public partial class AppointmentEdit : PageBase
    {
        public ClassRoomDAL classDAL = new ClassRoomDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public TeacherDAL teacherDAL = new TeacherDAL();
        public AppointmentDAL appointmentDAL = new AppointmentDAL();


        #region 参数集合
        public int AID
        {
            get
            {
                return GetQueryString<int>("id", -1);
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
                CommonFunction.BindEnum<CommonEnum.DorState>(this.ddl_MRID, "-2");

                DataTable dtPro = classDAL.Table((int)CommonEnum.Deleted.未删除, (int)CommonEnum.IsorNot.是); //
                CommonFunction.DDlTypeBind(this.ddl_MRID, dtPro, "CRID", "RoomName", "-2");



                if (AID != -1)
                {
                    InfoBind();
                }
                else 
                {
                    this.lbl_TeacherName.Text = UserRealName;
                }
            }
        }
        #endregion


        #region 初始化用户数据
        /// <summary>
        /// 初始化用户数据
        /// </summary>
        private void InfoBind()
        {
            AppointmentEntity model = appointmentDAL.GetObjByID(AID);
            if (model != null)
            {
                this.ddl_MRID.SelectedValue = Convert.ToString(model.MRID);
                this.txt_BeginDate.Text = Convert.ToString(model.BeginDate.ToString("yyyy-MM-dd"));
                this.txt_begin.Text = Convert.ToString(model.BeginDate.ToString("hh:mm"));
                this.txt_end.Text = Convert.ToString(model.EndDate.ToString("hh:mm"));
                this.txt_AppointmentDesc.Text = model.AppointmentDesc.ToString();
                this.lbl_TeacherName.Text = model.AppUserName;
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
                AppointmentEntity model = new AppointmentEntity();
                model.AID = AID;
                model.AppUser = UserID;//预约人
                model.MRID = Convert.ToInt32(this.ddl_MRID.SelectedValue.ToString());
                model.AppointmentDesc = this.txt_AppointmentDesc.Text.ToString().Trim();

                // model.Isdel = (int)CommonEnum.Deleted.未删除;
                if (Convert.ToDateTime(this.txt_end.Text) <= Convert.ToDateTime(this.txt_begin.Text))
                {
                    ShowMessage("时段选择错误");
                    return;
                }
                model.BeginDate = Convert.ToDateTime(this.txt_BeginDate.Text + " " + this.txt_begin.Text + ":00");//
                model.EndDate = Convert.ToDateTime(this.txt_BeginDate.Text + " " + this.txt_end.Text + ":00");//


                int result = appointmentDAL.Edit(model);
                if (result == 0)
                {
                    ShowMessage();
                    int log = AID == -1 ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, (AID == -1 ? "添加" : "修改") + "预约信息", UserID));
                }
                else if (result == -2)
                {
                    ShowMessage("所选时间冲突，请重新选择");
                    return;
                }
                else
                {
                    ShowMessage("提交失败");
                    return;
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                return;
            }
        }
        #endregion
    }
}