using System;
using System.Data;
using System.Web.UI.WebControls;
using GK.GKICMP.Entities;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;

namespace GKICMP.app
{
    public partial class OverTimeEdit : PageBaseApp
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        //public LeaveDAL leaveDAL = new LeaveDAL();
        public LeaveAuditDAL auditDAL = new LeaveAuditDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        //public ClassDAL classDAL = new ClassDAL();
        public SysUser_TypeDAL typeDAL = new SysUser_TypeDAL();
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
                //DataTable dt = sysDataDAL.GetList((int)CommonEnum.IsorNot.否,(int)CommonEnum.DataType.加班类型);
                ////CommonFunction.BindEnum<CommonEnum.AduitState>(this.ddl_OType, "-2");
                //CommonFunction.DDlDataBaseBind(this.ddl_OType, (int)CommonEnum.BaseDataType.加班类型, "-2");
                this.demo7.InnerHtml = DateTime.Now.ToString("yyyy-MM-dd");
                this.hf_begin.Value = DateTime.Now.ToString("yyyy-MM-dd");
                DataBindList();
                DataBindList1();
                this.hf_LID.Value = Guid.NewGuid().ToString();

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
                model.ODays = decimal.Parse(this.txt_ODays.Text);


                //string aa = this.hf_begin.Value.Substring(0, 10);
                //string bb = this.hf_begin.Value.Substring(11, 2) == "上午" ? " 07:00:00" : " 13:00:00";
                model.BeginDate = Convert.ToDateTime(this.hf_begin.Value);
                //model.BeginDate = Convert.ToDateTime(this.hf_begin.Value.Substring(0, 10) + this.hf_begin.Value.Substring(11, 2) == "上午" ? " 07:00:00" : " 13:00:00");
                //string cc = this.hf_end.Value.Substring(0, 10);
                //string dd = this.hf_end.Value.Substring(11, 2) == "上午" ? " 13:00:00" : " 18:00:00";
                //model.EndDate = Convert.ToDateTime(this.hf_end.Value);
                model.EndDate = Convert.ToDateTime(this.hf_begin.Value);

                model.OType = int.Parse(this.hf_OType.Value);
                model.OMark = this.hf_LeaveMark.Value;
                model.OState = (int)CommonEnum.AduitState.未审核;

                if (this.hf_UID.Value == "")
                {
                    ShowMessage("请选择参与人");
                    return;
                }
                string users = this.hf_UID.Value;

                model.Isdel = (int)CommonEnum.IsorNot.否;

                int result = overTimeDAL.Edit(model, isadd, users);
                if (result == 0)
                {
                    int log = OID == "" ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log,( OID == "" ? "添加" : "修改") + "申请人为【" + UserID + "】的加班信息【移动端操作】", UserID));
                    RegisterStartupScript("false", "<script>alert('提交成功');window.location.href='OverTime.aspx'</script>");
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
            this.demo7.InnerHtml = this.hf_begin.Value;
            //this.demo8.InnerHtml = this.hf_end.Value;
            this.dxseclet.InnerHtml = this.hf_UIDNames.Value;
            this.div_OMark.InnerHtml = this.hf_LeaveMark.Value;
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


        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {
            DataTable dt = typeDAL.GetList((int)CommonEnum.HumanType.加班审核人);
            this.rp_listshr.DataSource = dt;
            this.rp_listshr.DataBind();
        }
        #endregion

        #region MyRegion
        protected void btn_Hqqjts_Click(object sender, EventArgs e)
        {
            DataBindList();
            //GetVacationHour();
        }
        #endregion


        #region 选择收件人绑定
        public void DataBindList1()
        {
            DataTable dt;
            dt = new DepartmentDAL().GetList((int)CommonEnum.Deleted.未删除, (int)CommonEnum.DepType.职能部门);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.rpmodule.DataSource = dt;
                this.rpmodule.DataBind();
            }
        }
        #endregion
        protected void rpmodule_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Repeater rpnextModule = (Repeater)e.Item.FindControl("rpnextModule");
            HiddenField hf_DID = (HiddenField)e.Item.FindControl("hf_DID");
            DataTable dt = sysUserDAL.GetSysUserByDepid((int)CommonEnum.UserType.老师, Convert.ToInt32(hf_DID.Value));
            if (dt != null && dt.Rows.Count > 0)
            {
                rpnextModule.DataSource = dt;
                rpnextModule.DataBind();
            }
        }
    }
}