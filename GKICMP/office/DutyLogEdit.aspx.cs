/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月12日 09点30分
** 描   述:       值班日志页面
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.Data;
using System.Text;

namespace GKICMP.office
{
    public partial class DutyLogEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public TeacherDAL teacherDAL = new TeacherDAL();
        public SystTempDAL systTempDAL = new SystTempDAL();
        SchoolLogDAL schoolLogDAL = new SchoolLogDAL();


        #region 参数集合
        public int LogID
        {
            get
            {
                return GetQueryString<int>("id", -1);
            }
        }
        #endregion


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (LogID == -1)
                {          
                    StringBuilder sb1 = new StringBuilder();
                    sb1.Append("<script type='text/javascript'>");
                    sb1.Append("$(function () {$('#Series').combotree('setValues',['");
                    sb1.Append(UserID);
                    sb1.Append("']);})</script>");
                    this.ltl_xz.Text = sb1.ToString();
                }
                else
                {
                    BindInfo();
                }
                CommonFunction.BindEnum<CommonEnum.XQ>(this.ddl_Term, "-99");
                if (DateTime.Now > Convert.ToDateTime(DateTime.Now.ToString("yyyy") + "-09-01"))
                {
                    this.ddl_Term.SelectedIndex = 0;
                }
                else
                {
                    this.ddl_Term.SelectedIndex = 1;
                }
                SystTempEntity model = systTempDAL.GetObjByID(1);
                if (model != null)
                {
                    StringBuilder str = new StringBuilder();
                    //str.AppendFormat("<p style='color:#e36c09;height:30px;padding-top:10px;'>{0}<p>", model.TempName);
                    //str.AppendFormat("<span style ='height:20px;'>{0}<span>", model.TempContent);
                    str.AppendFormat( model.TempContent);
                    this.txt_Content.Text = str.ToString();
                }
            }
        }
        #endregion


        #region 提交
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                SchoolLogEntity model = new SchoolLogEntity();
                model.LogID = LogID;
                model.LogContent = this.txt_Content.Text.Trim();
                model.STerm = Convert.ToInt32(this.ddl_Term.SelectedValue);
                model.SYear = this.txt_SYear.Text.Trim();
                model.Weather = this.txt_Weather.Text.Trim();
                model.CreateUser = UserID;
                model.DutyUser = this.hf_TID.Value;
                //if (this.Series.Text == "")
                //{
                //    ShowMessage("请选择值班人员");
                //    return;
                //}
                //model.DutyUser = this.Series.Text;

                if (this.hf_TID.Value.Length <= 0)
                {
                    ShowMessage("请选择值班人员");
                    return;
                }
                int result = schoolLogDAL.Edit(model);
                if (result == 0)
                {
                    int log = LogID == -1 ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, LogID == -1 ? "添加" : "修改" + "值班日志信息", UserID));
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<script>alert('提交成功');window.location='DutyLogManage.aspx'</script>");
                }
                else if (result == -2)
                {
                    ShowMessage("本学年度下的学期的值班日志已经添加，请不要重复添加");
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
        public void BindInfo()
        {
            SchoolLogEntity model = schoolLogDAL.GetObjByID(LogID);
            if (model != null)
            {
                string a = "";
                this.txt_Content.Text = model.LogContent;
                this.txt_SYear.Text = model.SYear;
                this.ddl_Term.SelectedValue = model.STerm.ToString();
                this.hf_TID.Value = model.DutyUser;
                //this.Series.Text = model.DutyUser;
                //this.Series.Enabled = false;

                string[] arr = model.DutyUser.Split(',');
                for (int i = 0; i < arr.Length; i++)
                {
                    a += "\"" + arr[i].ToString() + "\",";
                }
                StringBuilder sb1 = new StringBuilder();
                sb1.Append("<script type='text/javascript'>");
                sb1.Append("$(function () {$('#Series').combotree('setValues',[");
                sb1.Append(a.TrimEnd(','));
                sb1.Append("]);})</script>");
                this.ltl_xz.Text = sb1.ToString();
            }
        }
        #endregion

    }
}