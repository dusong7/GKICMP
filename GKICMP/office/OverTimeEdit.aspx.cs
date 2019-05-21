using System;
using System.Data;
using System.Web.UI.WebControls;
using GK.GKICMP.Entities;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;

namespace GKICMP.office
{
    public partial class OverTimeEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        //public LeaveDAL leaveDAL = new LeaveDAL();
        public LeaveAuditDAL auditDAL = new LeaveAuditDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        //public ClassDAL classDAL = new ClassDAL();
        public SysUser_TypeDAL sysUser_TypeDAL = new SysUser_TypeDAL();
        public OverTimeDAL overTimeDAL = new OverTimeDAL();

        #region 参数集合
        /// <summary>
        /// 加班ID OID
        /// </summary>
        public string OID
        {
            get
            {
                return GetQueryString<string>("id", "");
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
               
                CommonFunction.DDlDataBaseBind(this.ddl_OType, (int)CommonEnum.BaseDataType.加班类型, "-2");
                this.txt_Begin.Text = DateTime.Now.ToString("yyyy-MM-dd");
                if (OID != "")
                {
                    this.hf_LID.Value = OID.ToString();
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
                OverTimeEntity model = new OverTimeEntity();
                int isadd = OID == "" ? 0 : 1;
                model.OID = this.hf_LID.Value.ToString();
                model.ApplyUser = UserID;
                model.ApplyDate = DateTime.Now;
                model.ODays = decimal.Parse(this.ddl_OType.SelectedValue);
                model.BeginDate = Convert.ToDateTime(this.txt_Begin.Text.Trim());
                model.EndDate = Convert.ToDateTime(this.txt_Begin.Text.Trim());
                //model.EndDate = Convert.ToDateTime(this.txt_End.Text.Trim() );
                model.OType = int.Parse(this.ddl_OType.SelectedValue);
                model.OMark = this.txt_OMark.Text;
                model.OState = (int)CommonEnum.AduitState.未审核;
                if (this.txt_Users.Text == "")
                {
                    ShowMessage("请选择参与人");
                    return;
                }
                string users = this.txt_Users.Text;
                model.Isdel = (int)CommonEnum.IsorNot.否;

                int result = overTimeDAL.Edit(model, isadd, users);
                if (result == 0)
                {
                    int log =OID == "" ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, OID == "" ? "添加" : "修改" + "申请人为【" + UserRealName + "】的加班信息", UserID));
                    ShowMessage();
                }
                else if (result == -2)
                {
                    ShowMessage("结束日期已经有加班");
                    return;
                }
                else if (result == -3)
                {
                    ShowMessage("这段时间已有加班");
                    return;
                }
                else if (result == -4)
                {
                    ShowMessage("开始日期已有加班");
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
            OverTimeEntity model = overTimeDAL.GetObjByID(OID);
            if (model != null)
            {
                this.txt_Begin.Text = model.BeginDate.ToString("yyyy-MM-dd HH:mm");
                //this.txt_End.Text = model.EndDate.ToString("yyyy-MM-dd HH:mm");
                //this.txt_ODays.Text = model.ODays.ToString();
                this.ddl_OType.SelectedValue = model.OType.ToString();
                this.txt_OMark.Text = model.OMark;
                this.txt_Users.Text = model.UsersID;
                GetAuditUser();
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


        //#region 获取请假天数
        //private void GetVacationHour()
        //{
        //    TimeSpan ts;
        //    DateTime begin;
        //    DateTime end;
        //    string ddlbegin;
        //    string ddlend;
        //    decimal vcount = 0;
        //    if (this.txt_Begin.Text != "" && this.txt_End.Text != "")
        //    {
        //        begin = Convert.ToDateTime(this.txt_Begin.Text);
        //        end = Convert.ToDateTime(this.txt_End.Text);
        //        ddlbegin = this.ddl_Begin.SelectedItem.ToString();
        //        ddlend = this.ddl_End.SelectedItem.ToString();
        //        if (Convert.ToDateTime(this.txt_End.Text + " " + this.ddl_End.SelectedValue + ":00:00") > Convert.ToDateTime(this.txt_Begin.Text + " " + this.ddl_Begin.SelectedValue + " :00:00"))
        //        {
        //            vcount = vacationDAL.GetCount(begin, end, ddlbegin, ddlend);
        //            if (ddlbegin == "上午")
        //            {
        //                if (ddlend == "上午")
        //                {
        //                    ts = end.AddDays(0.5) - begin;

        //                }
        //                else
        //                {
        //                    ts = end.AddDays(1) - begin;
        //                }
        //            }
        //            else
        //            {
        //                if (ddlend == "上午")
        //                {
        //                    ts = end - begin;
        //                }
        //                else
        //                {
        //                    ts = end.AddDays(0.5) - begin;
        //                }
        //            }
        //            this.txt_ODays.Text = (Convert.ToDecimal(ts.TotalDays) - vcount / 2).ToString();
        //        }
        //        else
        //        {
        //            this.txt_Begin.Text = "";
        //            this.txt_End.Text = "";
        //            this.txt_ODays.Text = "";
        //            ShowMessage("请假结束时间不能小于请假开始时间，请重新录入");
        //            return;
        //        }
        //    }
        //}
        //#endregion


        //#region
        //protected void txt_Begin_TextChanged(object sender, EventArgs e)
        //{
        //    GetVacationHour();
        //}
        //protected void txt_End_TextChanged(object sender, EventArgs e)
        //{
        //    GetVacationHour();
        //}
        //#endregion
    }
}