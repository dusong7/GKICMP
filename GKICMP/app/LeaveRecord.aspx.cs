using System;
using System.Web.UI.WebControls;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Data;
using System.Configuration;

namespace GKICMP.app
{
    public partial class LeaveRecord : PageBaseApp
    {
        public LeaveDAL leaveDAL = new LeaveDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public AttendVacationDAL vacationDAL = new AttendVacationDAL();
        public SysUser_TypeDAL typeDAL = new SysUser_TypeDAL();
        public LeaveAuditDAL auditDAL = new LeaveAuditDAL();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //DataBindList();
                this.hf_LID.Value = Guid.NewGuid().ToString();
            }
        }

        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.hf_LeaveMark.Value == "")
                {
                    ShowMessage("请录入事由");
                    return;
                }
                LeaveEntity model = new LeaveEntity();
                model.LID = this.hf_LID.Value;
                model.LeaveUser = UserID;
                model.LFlag = (int)CommonEnum.LFlag.外出备案;
                model.LType =-2;
                model.IsOK = 1;
                string aa = this.hf_begin.Value.Substring(0, 10);
                model.BeginDate = Convert.ToDateTime(aa );
                string cc = this.hf_end.Value.Substring(0, 10);
                model.EndDate = Convert.ToDateTime(cc);
                if (model.BeginDate < Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00"))
                {
                    ShowMessage("开始日期不能小于当前日期");
                    return;
                }
                if (model.EndDate < model.BeginDate)
                {
                    ShowMessage("结束日期不能小于开始日期");
                    return;
                }
                model.LeaveDays = Convert.ToDecimal(this.txt_LeaveDays.Text);
                if (model.LeaveDays <= 0)
                {
                    ShowMessage("外出天数要大于0天");
                    return;
                }
                model.LeaveMark = this.hf_LeaveMark.Value;
                model.LeaveState = (int)CommonEnum.AduitState.通过;
                model.LeaveFile = "";
                model.IsTeacher = (int)CommonEnum.IsorNot.是;
                model.Isdel = (int)CommonEnum.IsorNot.否;
                //上传图片
                int upsize = 4000000;
                try
                {
                    upsize = Convert.ToInt32(ConfigurationManager.AppSettings["upsize"].ToString());
                }
                catch (Exception) { }
                AccessoryEntity accessinfo = CommonFunction.upfileTest(0, 1, hf_file, "FileBox");

                model.LeaveFile = accessinfo.AccessUrl;

                int result = leaveDAL.EditAPP(model, "", "");
                if (result == 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, "添加外出备案信息", UserID));
                    RegisterStartupScript("false", "<script>alert('提交成功');window.location.href='LeaveRecordList.aspx'</script>");
                }
                else if (result == -2)
                {
                    ShowMessage("结束日期已经有登记");
                    return;
                }
                else if (result == -3)
                {
                    ShowMessage("这段时间已有登记");
                    return;
                }
                else if (result == -4)
                {
                    ShowMessage("开始日期已有登记");
                    return;
                }
                else if (result == -5)
                {
                    ShowMessage("结束日期已有外出登记");
                    return;
                }
                else if (result == -6)
                {
                    ShowMessage("这段时间已有外出登记");
                    return;
                }
                else if (result == -7)
                {
                    ShowMessage("结束日期已有外出登记");
                    return;
                }
              
                else
                {
                    ShowMessage("保存失败");
                    return;
                }
            }
            catch (Exception error)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, error.Message, UserID));
                ShowMessage(error.Message);
            }
        }
        #region 获取请假天数
        private void GetVacationHour()
        {
            DateTime begin;
            DateTime end;
            if (this.hf_begin.Value.Substring(0, 10) != "" && this.hf_end.Value.Substring(0, 10) != "")
            {
                begin = Convert.ToDateTime(this.hf_begin.Value.Substring(0, 10));
                end = Convert.ToDateTime(this.hf_end.Value.Substring(0, 10));

                if (Convert.ToDateTime(this.hf_begin.Value.Substring(0, 10)) < Convert.ToDateTime(this.hf_end.Value.Substring(0, 10)))
                {
                    this.demo7.InnerHtml = this.hf_begin.Value;
                    this.demo8.InnerHtml = this.hf_end.Value;
                    this.txt_LeaveDays.Text = ((end - begin).TotalDays+1).ToString();
                }
                else
                {
                    this.demo7.InnerHtml = "";
                    this.demo8.InnerHtml = "";
                    //this.result1.InnerText = "";
                    //this.result.InnerText = "";
                    this.hf_begin.Value = "";
                    this.hf_end.Value = "";
                    this.txt_LeaveDays.Text = "";
                    ShowMessage("结束时间不能小于请假开始时间，请重新录入");
                    return;
                }
            }
        }
        #endregion

        #region MyRegion
        protected void btn_Hqqjts_Click(object sender, EventArgs e)
        {
            //DataBindList();
            GetVacationHour();
        }
        #endregion
    }
}