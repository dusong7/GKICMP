using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK.GKICMP.Entities;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using System.Configuration;
using System.IO;

namespace GKICMP.office
{
    public partial class LeaveEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public LeaveDAL leaveDAL = new LeaveDAL();
        public LeaveAuditDAL auditDAL = new LeaveAuditDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        //public ClassDAL classDAL = new ClassDAL();
        public SysUser_TypeDAL sysUser_TypeDAL = new SysUser_TypeDAL();
        public AttendVacationDAL vacationDAL = new AttendVacationDAL();


        #region 参数集合
        /// <summary>
        /// 请假ID LID
        /// </summary>
        public string LID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }

        /// <summary>
        /// Flag 1：学生 2：其他
        /// </summary>
        public int Flag
        {
            get
            {
                return GetQueryString<int>("flag", -1);
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
                if (Flag == 1)
                {
                    CommonFunction.BindEnum<CommonEnum.StuLeaveType>(this.ddl_LType, "-99");
                    this.trSubject.Visible = false;
                }
                else
                {
                    CommonFunction.DDlDataBaseBind(this.ddl_LType, (int)CommonEnum.BaseDataType.请假类型, "-999");
                    //CommonFunction.BindEnum<CommonEnum.LType>(this.ddl_LType, "-99");
                }
                CommonFunction.BindEnum<CommonEnum.IsorNot>(this.rbl_IsorNo);

                this.rbl_IsorNo.SelectedIndex = 1;
                if (LID != "")
                {
                    this.hf_LID.Value = LID.ToString();
                    BindInfo();
                }
                else
                {
                    this.hf_LID.Value = Guid.NewGuid().ToString();
                }
            }
        }
        #endregion


        #region 提交
        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                LeaveEntity model = new LeaveEntity();
                int isadd = LID == "" ? 0 : 1;
                model.LID = this.hf_LID.Value.ToString();
                model.LeaveUser = UserID;
                model.LType = Convert.ToInt32(this.ddl_LType.SelectedValue);
                model.LFlag = Convert.ToInt32(CommonEnum.LFlag.请假);
                model.LeaveState = Convert.ToInt32(CommonEnum.AduitState.未审核);
                model.LeaveMark = this.txt_LeaveMark.Text;
                string begin = " " + this.ddl_Begin.SelectedValue.ToString() + ":00:00";
                string end = " " + this.ddl_End.SelectedValue.ToString() + ":00:00";
                model.BeginDate = Convert.ToDateTime(this.txt_Begin.Text.Trim() + begin);
                model.EndDate = Convert.ToDateTime(this.txt_End.Text.Trim() + end);
                if (LID == "")
                {
                    if (model.BeginDate < DateTime.Now)
                    {
                        ShowMessage("请假开始日期不能小于当前日期");
                        return;
                    }
                    if (model.EndDate < model.BeginDate)
                    {
                        ShowMessage("请假结束日期不能小于请假开始日期");
                        return;
                    }
                }
                model.LeaveDays = Convert.ToDecimal(this.txt_LeaveDays.Text);
                if (model.LeaveDays <= 0)
                {
                    ShowMessage("请假天数要大于0天");
                    return;
                }
                model.Isdel = Convert.ToInt32(CommonEnum.Deleted.未删除);
                model.IsOK = Convert.ToInt32(this.rbl_IsorNo.SelectedValue);
                if (Flag == 1)
                {
                    model.IsTeacher = (int)CommonEnum.IsorNot.否;
                }
                else
                {
                    model.IsTeacher = (int)CommonEnum.IsorNot.是;
                }
                //上传图片
                int upsize = 4000000;
                try
                {
                    upsize = Convert.ToInt32(ConfigurationManager.AppSettings["upsize"].ToString());
                }
                catch (Exception) { }
                AccessoryEntity accessinfo = CommonFunction.upfile(0, 1, hf_file, "ImageUrl");
                if (accessinfo.AccessID == "-2")
                {
                    //刚才上传的文件删除
                    CommonFunction.delfile(hf_file.Value.ToString());
                    ShowMessage(accessinfo.AccessName);
                    return;
                }
                else
                {
                    if (this.fl_UpFile.HasFile)
                        model.LeaveFile = accessinfo.AccessUrl;
                    else
                        model.LeaveFile = this.hf_Url.Value;
                }

                //if (Flag == 1)//学生添加审核人
                //{
                //    SysUserEntity smodel = sysUserDAL.GetObjByID(UserID);
                //    if (smodel != null)
                //    {
                //        ClassEntity cmodel = classDAL.GetObjByID(smodel.DepID);
                //        if (cmodel != null)
                //        {
                //            Leave_AuditEntity lmodel = new Leave_AuditEntity();
                //            lmodel.LID = this.hf_LID.Value.ToString();
                //            if (cmodel.DutyUser != null && cmodel.DutyUser.ToString() != "")
                //            {
                //                lmodel.AuditUser = cmodel.DutyUser.ToString();
                //            }
                //            else
                //            {
                //                ShowMessage("您目前所在的班级未设置班主任，请联系系统管理员处理之后再提交请假申请");
                //                return;
                //            }
                //            lmodel.AuditResult = (int)CommonEnum.AduitState.未审核;
                //            int sresult = auditDAL.AuditEdit(lmodel);
                //            if (sresult != 0)
                //            {
                //                ShowMessage("添加请假审核人信息失败，请重新提交");
                //                return;
                //            }
                //        }
                //    }
                //}

                int result = leaveDAL.Edit(model, isadd, this.ddl_Begin.SelectedItem.ToString(), this.ddl_End.SelectedItem.ToString());
                if (result == 0)
                {
                    int log = LID == "" ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, LID == "" ? "添加" : "修改" + "请假人为【" + UserID + "】的信息", UserID));
                    ShowMessage();
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
        protected void BindInfo()
        {
            LeaveEntity model = leaveDAL.GetObjByID(LID);
            if (model != null)
            {
                this.txt_Begin.Enabled = false;
                this.txt_End.Enabled = false;
                this.ddl_Begin.Enabled = false;
                this.ddl_End.Enabled = false;
                this.txt_Begin.Text = model.BeginDate.ToString("yyyy-MM-dd");
                this.txt_End.Text = model.EndDate.ToString("yyyy-MM-dd");
                this.ddl_Begin.SelectedValue = model.BeginDate.ToString("HH");
                this.ddl_End.SelectedValue = model.EndDate.ToString("HH");
                this.txt_LeaveDays.Text = model.LeaveDays.ToString();
                this.txt_LeaveMark.Text = model.LeaveMark;
                this.hf_Url.Value = model.LeaveFile;
                this.rbl_IsorNo.SelectedValue = model.IsOK.ToString();
                this.ddl_LType.SelectedValue = model.LType.ToString();
                AccessBind();
                GetAuditUser();
            }
        }
        #endregion


        #region 附件下载、删除
        protected void rpaccess_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string accessid = e.CommandArgument.ToString().Trim();
            string name = Path.GetFileNameWithoutExtension(accessid);

            if (!CommonFunction.UpLoadFunciotn(accessid, name))
            {
                ShowMessage("下载文件不存在，请联系系统管理员");
                return;
            }

        }
        #endregion


        #region 附件绑定
        /// <summary>
        /// 附件绑定
        /// </summary>
        /// <param name="rpcontr"></param>
        /// <param name="objid"></param>
        /// <param name="flag"></param>
        public void AccessBind()
        {
            DataTable ds = leaveDAL.GetTable(LID);
            rp_File.DataSource = ds;
            rp_File.DataBind();
        }
        #endregion


        #region 获取附件名称
        /// <summary>
        /// 获取附件名称
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string getFileName(string obj)
        {
            return Path.GetFileNameWithoutExtension(obj);
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
            GetAuditUser();
        }
        #endregion


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


        #region 获取请假天数
        private void GetVacationHour()
        {
            TimeSpan ts;
            DateTime begin;
            DateTime end;
            string ddlbegin;
            string ddlend;
            decimal vcount = 0;
            if (this.txt_Begin.Text != "" && this.txt_End.Text != "")
            {
                begin = Convert.ToDateTime(this.txt_Begin.Text);
                end = Convert.ToDateTime(this.txt_End.Text);
                ddlbegin = this.ddl_Begin.SelectedItem.ToString();
                ddlend = this.ddl_End.SelectedItem.ToString();
                if (Convert.ToDateTime(this.txt_End.Text + " " + this.ddl_End.SelectedValue + ":00:00") > Convert.ToDateTime(this.txt_Begin.Text + " " + this.ddl_Begin.SelectedValue + " :00:00"))
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
                    this.txt_LeaveDays.Text = (Convert.ToDecimal(ts.TotalDays) - vcount / 2).ToString();
                }
                else
                {
                    this.txt_Begin.Text = "";
                    this.txt_End.Text = "";
                    this.txt_LeaveDays.Text = "";
                    ShowMessage("请假结束时间不能小于请假开始时间，请重新录入");
                    return;
                }
            }
        }
        #endregion


        #region
        protected void txt_Begin_TextChanged(object sender, EventArgs e)
        {
            GetVacationHour();
        }
        protected void txt_End_TextChanged(object sender, EventArgs e)
        {
            GetVacationHour();
        }
        protected void ddl_Begin_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetVacationHour();
        }
        protected void ddl_End_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetVacationHour();
        }
        #endregion
    }
}