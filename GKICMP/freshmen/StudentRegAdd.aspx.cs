/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月12日 09点30分
** 描   述:       学生信息管理编辑页面
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Text;
using System.Web.UI.WebControls;

namespace GKICMP.freshmen
{
    public partial class StudentRegAdd : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public StudentDAL studentDAL = new StudentDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public SysData1DAL sysData1DAL = new SysData1DAL();



        #region 参数集合
        public string UID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        #endregion

        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DdlBind();
                BindInfo();
            }
        }
        #endregion


        #region 流动人口选择
        protected void ddl_pid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_pid.SelectedValue != "136")
            {
                this.ddl_IsFlow.Visible = false;
            }
            else
            {
                this.ddl_IsFlow.Visible = true;
            }
            DataTable dt1 = sysData1DAL.GetTable((int)CommonEnum.IsorNot.否, 2, Convert.ToInt32(this.ddl_pid.SelectedValue));
            CommonFunction.DDlTypeBind(this.ddl_IsFlow, dt1, "SDID", "DataName", "-999");
        }
        #endregion


        #region 下拉框绑定
        public void DdlBind()
        {
            DataTable dt1 = sysData1DAL.GetTable((int)CommonEnum.IsorNot.否, 2, -2);
            CommonFunction.DDlTypeBind(this.ddl_pid, dt1, "SDID", "DataName", "-2");
            DataTable dt = departmentDAL.GetZNBM((int)CommonEnum.DepType.普通班级, (int)CommonEnum.IsorNot.否);
            CommonFunction.DDlTypeBind(this.ddl_DepID, dt, "DID", "DepName", "-2");
            CommonFunction.BindEnum<CommonEnum.MZ>(this.ddl_Nation, "-2");
            CommonFunction.BindEnum<CommonEnum.ZZMM>(this.ddl_Politics, "-2");
            CommonFunction.BindEnum<CommonEnum.HKLX>(this.ddl_RegistType, "-2");
            //  CommonFunction.BindEnum<CommonEnum.XB>(this.ddl_UserSex, "-2");
            CommonFunction.BindEnum<CommonEnum.IsorNot>(this.rbl_IsField);
            CommonFunction.BindEnum<CommonEnum.IsorNot>(this.rbl_IsLeftBehind);
            CommonFunction.BindEnum<CommonEnum.IsorNot>(this.rbl_IsOnly);
            this.rbl_IsOnly.SelectedIndex = 0;
            this.rbl_IsLeftBehind.SelectedIndex = 0;
            this.rbl_IsField.SelectedIndex = 0;
            this.ddl_Usuate.Items.Add(new ListItem("正常", "0"));
            this.ddl_Usuate.Items.Add(new ListItem("未审核", "1"));
            this.ddl_Usuate.Items.Add(new ListItem("录取未报道", "4"));
            this.ddl_Usuate.Items.Add(new ListItem("禁用", "-1"));
            this.ddl_Usuate.Items.Add(new ListItem("驳回", "-2"));
            this.ddl_Usuate.Items.Add(new ListItem("招生", "11"));
            this.ddl_Usuate.Items.Add(new ListItem("复学", "12"));
            this.ddl_Usuate.Items.Add(new ListItem("转入", "13"));
            this.ddl_Usuate.Items.Add(new ListItem("毕业", "21"));
            this.ddl_Usuate.Items.Add(new ListItem("结业", "22"));
            this.ddl_Usuate.Items.Add(new ListItem("休学", "23"));
            this.ddl_Usuate.Items.Add(new ListItem("退学", "24"));
            this.ddl_Usuate.Items.Add(new ListItem("开除", "25"));
            this.ddl_Usuate.Items.Add(new ListItem("死亡", "26"));
            this.ddl_Usuate.Items.Add(new ListItem("转出", "27"));
            this.ddl_Usuate.Items.Add(new ListItem("辍学", "28"));
        }
        #endregion


        #region 初始化用户数据
        public void BindInfo()
        {
            SysUserEntity model = sysUserDAL.GetObjByID(UID);
            if (model != null)
            {
                this.lbl_RealName.Text = model.RealName;
                this.lbl_UserSex.Text = CommonFunction.CheckEnum<CommonEnum.XB>(model.UserSex);
                this.txt_BirthDay.Text = model.BirthDay.ToString("yyyy-MM");
                this.lbl_IDCard.Text = model.IDCard;
                this.ddl_Nation.SelectedValue = model.Nation.ToString();
                this.ddl_DepID.SelectedValue = model.DepID.ToString();
                this.ddl_Usuate.SelectedValue = model.UState.ToString();
                this.hf_UserSex.Value = model.UserSex.ToString();
                //this.lbl_RealName.Enabled = false;
                //this.lbl_UserSex.Enabled = false;
                //this.txt_BirthDay.Enabled = false;
                //this.lbl_IDCard.Enabled = false;
                //this.ddl_Nation.Enabled = false;
            }
            StudentEntity model1 = studentDAL.GetObjByID(UID);
            if (model1 != null)
            {
                this.txt_CardNum.Text = model1.CardNum;
                this.txt_CellPhone.Text = model1.CellPhone;
                this.txt_EntranceDate.Text = model1.EnterDate.ToString("yyyy-MM-dd");
                this.txt_GEnrollment.Text = model1.GEnrollment;
                this.txt_Guardian.Text = model1.Guardian;
                this.txt_GuardNum.Text = model1.GuardNum;
                //this.txt_IsFlow.Text = model1.IsFlow.ToString();
                this.txt_LoinDate.Text = model1.LoinDate.ToString("yyyy-MM-dd");
                this.txt_PEnrollment.Text = model1.PEnrollment;
                this.txt_PlaceOrigion.Text = model1.PlaceOrigin;
                this.txt_RegisteredPlace.Text = model1.RegisteredPlace;
                this.txt_UsedName.Text = model1.UsedName;
                this.ddl_Politics.SelectedValue = model1.Politics.ToString();
                this.ddl_RegistType.SelectedValue = model1.RegistType.ToString();
                this.rbl_IsField.SelectedValue = model1.IsField.ToString();
                this.rbl_IsLeftBehind.SelectedValue = model1.IsLeftBehind.ToString();
                this.rbl_IsOnly.SelectedValue = model1.IsOnly.ToString();
                if (model1.Photos != "")
                {
                    this.Image1.ImageUrl = this.hf_UpFile.Value = model1.Photos;
                    this.Image1.Visible = true;
                }
                this.ddl_pid.SelectedValue = model1.IsFlow;
                if (Convert.ToInt32(model1.IsFlow) > 137)
                {
                    this.ddl_IsFlow.Visible = true;
                    this.ddl_pid.SelectedValue = "136";
                    DataTable dt1 = sysData1DAL.GetTable((int)CommonEnum.IsorNot.否, 2, 136);
                    CommonFunction.DDlTypeBind(this.ddl_IsFlow, dt1, "SDID", "DataName", "-999");
                    this.ddl_IsFlow.SelectedValue = model1.IsFlow;
                }
            }
        }
        #endregion


        #region 提交
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                StudentEntity model = new StudentEntity();
                model.BirthDay = Convert.ToDateTime(this.txt_BirthDay.Text);
                model.CardNum = this.txt_CardNum.Text.Trim();
                model.CellPhone = this.txt_CellPhone.Text.Trim();
                model.ClaID = Convert.ToInt32(this.ddl_DepID.SelectedValue);
                model.EnterDate = Convert.ToDateTime(this.txt_EntranceDate.Text);
                model.GEnrollment = this.txt_GEnrollment.Text.Trim();
                model.Guardian = this.txt_Guardian.Text.Trim();
                model.GuardNum = this.txt_GuardNum.Text.Trim();
                model.IDCard = this.lbl_IDCard.Text.Trim();
                model.Isdel = Convert.ToInt32(CommonEnum.IsorNot.否);
                model.IsField = Convert.ToInt32(this.rbl_IsField.SelectedValue);
                model.IsFlow = this.ddl_pid.SelectedValue == "136" ? this.ddl_IsFlow.SelectedValue : this.ddl_pid.SelectedValue;
                model.IsLeftBehind = Convert.ToInt32(this.rbl_IsLeftBehind.SelectedValue);
                model.IsOnly = Convert.ToInt32(this.rbl_IsOnly.SelectedValue);
                model.LoinDate = Convert.ToDateTime(this.txt_LoinDate.Text);
                model.Nation = Convert.ToInt32(this.ddl_Nation.SelectedValue);
                model.PEnrollment = this.txt_PEnrollment.Text.Trim();
                model.PlaceOrigin = this.txt_PlaceOrigion.Text.Trim();
                model.Politics = Convert.ToInt32(this.ddl_Politics.SelectedValue);
                model.RealName = this.lbl_RealName.Text.Trim();
                model.RegisteredPlace = this.txt_RegisteredPlace.Text.Trim();
                model.RegistType = Convert.ToInt32(this.ddl_RegistType.SelectedValue);
                model.StID = UID;
                model.UsedName = this.txt_UsedName.Text.Trim();
                model.UserSex = Convert.ToInt32(this.hf_UserSex.Value);
                model.UState = Convert.ToInt32(this.ddl_Usuate.SelectedValue);
                //附件上传
                int upsize = 4000000;
                try
                {
                    upsize = Convert.ToInt32(ConfigurationManager.AppSettings["upsize"].ToString());
                }
                catch (Exception) { }
                AccessoryEntity accessinfo = CommonFunction.upfile(0, 1, hf_UpFile, "ImageUrl");
                if (accessinfo.AccessID == "-2")
                {
                    //刚才上传的文件删除
                    CommonFunction.delfile(hf_UpFile.Value.ToString());
                    ShowMessage(accessinfo.AccessName);
                    return;
                }
                else
                {
                    if (this.fl_UpFile.HasFile)
                        model.Photos = accessinfo.AccessUrl;
                    else
                        model.Photos = this.hf_UpFile.Value;
                }

                int result = studentDAL.Edit(model);
                if (result == 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_修改, "修改学生：" + this.lbl_RealName.Text + "的信息", UserID));
                    ShowMessage();
                    //ClientScript.RegisterStartupScript(GetType(), "Message", "<script>alert('提交成功');window.location='StudentManage.aspx'</script>");
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


        #region 返回

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "Message", "<script>window.location='StudentManage.aspx'</script>");
        }
        #endregion
    }
}