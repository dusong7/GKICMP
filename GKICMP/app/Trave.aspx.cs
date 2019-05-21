using System;
using System.Web.UI.WebControls;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Data;
using System.Configuration;

namespace GKICMP.app
{
    public partial class Trave : PageBaseApp
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
                model.LFlag = (int)CommonEnum.LFlag.外出登记;
                model.LType = 0;
                string aa = this.hf_begin.Value.Substring(0, 10);
                string bb = this.hf_begin.Value.Substring(11, 2) == "上午" ? " 07:00:00" : " 13:00:00";
                model.BeginDate = Convert.ToDateTime(aa + bb);
                //model.BeginDate = Convert.ToDateTime(this.hf_begin.Value.Substring(0, 10) + this.hf_begin.Value.Substring(11, 2) == "上午" ? " 07:00:00" : " 13:00:00");
                string cc = this.hf_end.Value.Substring(0, 10);
                string dd = this.hf_end.Value.Substring(11, 2) == "上午" ? " 13:00:00" : " 18:00:00";
                model.EndDate = Convert.ToDateTime(cc + dd);
                //model.EndDate = Convert.ToDateTime(this.hf_end.Value.Substring(0, 10) + this.hf_end.Value.Substring(11, 2) == "上午" ? " 13:00:00" : "18:00:00");
                if (model.BeginDate < Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00"))
                {
                    ShowMessage("请假开始日期不能小于当前日期");
                    return;
                }
                if (model.EndDate < model.BeginDate)
                {
                    ShowMessage("请假结束日期不能小于请假开始日期");
                    return;
                }
                model.LeaveDays = Convert.ToDecimal(this.txt_LeaveDays.Text);
                if (model.LeaveDays <= 0)
                {
                    ShowMessage("外出登记天数要大于0天");
                    return;
                }
                model.LeaveMark = this.hf_LeaveMark.Value;
                model.LeaveState = (int)CommonEnum.AduitState.未审核;
                model.LeaveFile = "";
                model.IsTeacher = (int)CommonEnum.IsorNot.是;
                model.Isdel = (int)CommonEnum.IsorNot.否;
                model.IsOK = Convert.ToInt32(this.r1.Checked == true ? this.r1.Value : this.r2.Value);
                //上传图片
                int upsize = 4000000;
                try
                {
                    upsize = Convert.ToInt32(ConfigurationManager.AppSettings["upsize"].ToString());
                }
                catch (Exception) { }
                AccessoryEntity accessinfo = CommonFunction.upfile(0, 1, hf_file, "FileBox");

                model.LeaveFile = accessinfo.AccessUrl;

                int result = leaveDAL.EditAPP(model, this.hf_begin.Value.Substring(11, 2), this.hf_end.Value.Substring(11, 2));
                if (result == 0)
                {

                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, "添加外出信息", UserID));
                    //ShowMessage("提交成功");
                    RegisterStartupScript("false", "<script>alert('提交成功');window.location.href='PeopleTrave.aspx'</script>");
                }
                else if (result == -2)
                {
                    ShowMessage("结束日期已经有假期");
                    return;
                }
                else if (result == -3)
                {
                    ShowMessage("这段时间已有假期");
                    return;
                }
                else if (result == -4)
                {
                    ShowMessage("开始日期已有假期");
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
                else if (result == -8)
                {
                    ShowMessage("审核人为空，请选择审核人");
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

        #region 删除请假审核人
        /// <summary>
        /// 删除请假审核人
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_Delete_Click(object sender, EventArgs e)
        {
            LinkButton ibtn = (LinkButton)sender;
            int istrue = auditDAL.DeleteBat(ibtn.CommandArgument.ToString());
            if (istrue > 0)
            {
                ShowMessage("删除成功");
                GetAuditUser();
            }
            else
            {
                ShowMessage("删除失败");
                return;
            }
        }
        #endregion


        #region 绑定审核人信息
        /// <summary>
        /// 绑定审核人信息
        /// </summary>
        private void GetAuditUser()
        {

            DataTable dt = auditDAL.GetList(this.hf_LID.Value.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                this.ltl_Name.Visible = false;
            }
            else
            {
                this.ltl_Name.Visible = true;
            }

            this.rp_List.DataSource = dt;
            rp_List.DataBind();
        }
        #endregion


        #region 动态绑定审核人
        /// <summary>
        /// 动态绑定联系人
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            DataBindList();
            GetAuditUser();
            this.lbl_LeaveDays.Text = "外出天数";
            this.lbl_sh.Text = "外出审核人";
        }
        #endregion


        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {
            DataTable dt = typeDAL.GetList((int)CommonEnum.HumanType.外出审核人);
            this.rp_listshr.DataSource = dt;
            this.rp_listshr.DataBind();
        }
        #endregion


        #region 获取请假天数
        public void GetVacationHour()
        {
            TimeSpan ts;
            DateTime begin = Convert.ToDateTime(this.hf_begin.Value.Substring(0, 10));
            DateTime end = Convert.ToDateTime(this.hf_end.Value.Substring(0, 10));
            string ddlbegin = this.hf_begin.Value.Substring(11, 2);
            string ddlend = this.hf_end.Value.Substring(11, 2);
            decimal vcount = 0;
            if (this.hf_begin.Value != "" && this.hf_end.Value != "")
            {
                if (Convert.ToDateTime(end.ToString("yyyy-MM-dd") + " " + (ddlend == "上午" ? " 13:00:00" : " 18:00:00")) > Convert.ToDateTime(begin.ToString("yyyy-MM-dd") + " " + (ddlbegin == "上午" ? " 07:00:00" : " 13:00:00")))
                {
                    vcount = vacationDAL.GetCount(begin, end, ddlbegin, ddlend);
                    if (ddlbegin == "上午")
                    {
                        if (ddlend == "上午")
                        {
                            ts = end.AddDays(0.5) - begin;

                        }
                        else
                        {
                            ts = end.AddDays(1) - begin;
                        }
                    }
                    else
                    {
                        if (ddlend == "上午")
                        {
                            ts = end - begin;
                        }
                        else
                        {
                            ts = end.AddDays(0.5) - begin;
                        }
                    }
                    this.demo7.InnerHtml = this.hf_begin.Value;
                    this.demo8.InnerHtml = this.hf_end.Value;
                    //this.result.InnerText = this.hf_begin.Value;
                    //this.result1.InnerText = this.hf_end.Value;
                    this.txt_LeaveDays.Text = (Convert.ToDecimal(ts.TotalDays) - vcount / 2).ToString();
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
                    ShowMessage("结束时间不能小于开始时间，请重新录入");
                    return;
                }
            }
        }
        #endregion

        #region MyRegion
        protected void btn_Hqqjts_Click(object sender, EventArgs e)
        {
            DataBindList();
            GetVacationHour();
        }
        #endregion



    }
}