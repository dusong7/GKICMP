/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2016年10月15日 13时56分24秒
** 描    述:      教师合同管理界面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Configuration;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;


using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;

namespace GKICMP.teachermanage
{
    public partial class TeacherClassHourEdit : PageBase
    {
        public Teacher_ClassHourDAL teacher_ClassHourDAL = new Teacher_ClassHourDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SysDataDAL sysDataDAL = new SysDataDAL();
        public GradeDAL gradeDAL = new GradeDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public BaseDataDAL baseDataDAL = new BaseDataDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public TeacherDAL teacherDAL = new TeacherDAL();

        #region 参数集合
        /// <summary>
        /// THID 课时ID
        /// </summary>
        public string THID
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
                DDLBind();
              //  BandDepart(); //绑定教师
                if (THID != "")
                {
                    InfoBind();
                }
            }
        }
        #endregion


        #region 下拉框绑定
        /// <summary>
        /// 下拉框绑定
        /// </summary>
        private void DDLBind()
        {
            DataTable dtType = gradeDAL.GetListAll((int)CommonEnum.Deleted.未删除);//所属年级
            CommonFunction.DDlTypeBind(this.ddl_GradeID, dtType, "GID", "GradeName", "-2");

            DataTable dtSub = sysDataDAL.GetList((int)CommonEnum.Deleted.未删除, (int)CommonEnum.DataType.学科);
            CommonFunction.DDlTypeBind(this.ddl_MainSubject, dtSub, "SDID", "DataName", "-2");

            DataTable dtPartSub = sysDataDAL.GetList((int)CommonEnum.Deleted.未删除, (int)CommonEnum.DataType.学科);
            CommonFunction.DDlTypeBind(this.ddl_PartSubject, dtPartSub, "SDID", "DataName", "-2");

            //CommonFunction.BindEnum<CommonEnum.XQ>(this.ddl_Semester, "-2");

            CommonFunction.BindEnum<CommonEnum.XQ>(this.ddl_Semester, "-2");
            if (DateTime.Now.Month > 8)
            {
                this.txt_SchoolYear.Text = DateTime.Now.Year + "-" + (DateTime.Now.Year + 1);
                this.ddl_Semester.SelectedValue = ((int)CommonEnum.XQ.上学期).ToString();
                //  this.ddl_Term.Enabled = false;
            }
            else
            {
                this.txt_SchoolYear.Text = (DateTime.Now.Year - 1) + "-" + DateTime.Now.Year;
                this.ddl_Semester.SelectedValue = ((int)CommonEnum.XQ.下学期).ToString();
                // this.ddl_Term.Enabled = false;
            }

        }
        #endregion

        #region 绑定教师姓名
        private void SetValue(string TID)
        {
            StringBuilder sb1 = new StringBuilder();
            sb1.Append("<script type='text/javascript'>");
            sb1.Append("$(function () {$('#TeacherName').combotree('setValue', '");
            sb1.Append(TID);
            sb1.Append("');");
            sb1.Append("$('#TeacherName').combotree('disable');");
            sb1.Append("})</script>");
            this.ltl_xz.Text = sb1.ToString();
        }
        #endregion

        //#region 教师绑定
        ///// <summary>
        ///// 教师绑定
        ///// </summary>
        //private void BandDepart()
        //{
        //    StringBuilder sb = new StringBuilder("");
        //    string a = DepartList();
        //    sb.Append("<script type='text/javascript'>");
        //    sb.Append(" $(function () {");
        //    sb.Append(" $('#TeacherName').combotree({");
        //    sb.Append(" data:[");
        //    sb.Append(a);
        //    sb.Append("],");
        //    sb.Append("multiple: false,");
        //    sb.Append("multiline: false,");
        //    sb.Append("});");
        //    sb.Append(" }); </script>");

        //    this.ltl_JQ.Text = sb.ToString();

        //}
        //private string DepartList()
        //{
        //    DataTable dt;
        //    dt = sysUserDAL.GetSysUserByType((int)CommonEnum.UserType.老师, (int)CommonEnum.Deleted.未删除);
        //    string name = string.Empty;
        //    StringBuilder sb = new StringBuilder();
        //    if (dt.Rows.Count > 0)
        //    {
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            name += "{\"id\":\"" + dt.Rows[i]["UID"].ToString() +
        //               "\",\"text\":\"" + dt.Rows[i]["RealName"].ToString() + "\"},";
        //        }
        //    }
        //    sb.Append(name.ToString().TrimEnd(','));
        //    return sb.ToString();
        //}
        //#endregion

        #region 带部门的教师绑定
        /// <summary>
        /// 带部门的教师绑定
        /// </summary>
        private void BandDepart()
        {
            StringBuilder sb = new StringBuilder("");
            string a = MList();
            sb.Append("<script type='text/javascript'>");
            sb.Append(" $(function () {");
            sb.Append(" $('#TeacherName').combotree({");
            sb.Append(" data: [ ");
            sb.Append(a);
            sb.Append("],");
            sb.Append("multiple: false,");
            sb.Append("lines: true,");
            sb.Append("});");
            sb.Append(" }); </script>");
            this.ltl_JQ.Text = sb.ToString();
        }

        /// <summary>
        /// 绑定职能部门信息
        /// </summary>
        /// <returns></returns>
        private string MList()
        {
            DataTable dt;
            dt = departmentDAL.GetZNBM((int)CommonEnum.DepType.职能部门, (int)CommonEnum.IsorNot.否);
            string name = string.Empty;
            if (dt == null)
            {
                name = "[]";
            }
            StringBuilder sb = new StringBuilder();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    name += "{\"id\":\"" + dt.Rows[i]["DID"].ToString() +
                       "\",\"text\":\"" + dt.Rows[i]["DepName"].ToString() + "\",";
                    //调用递归方法
                    name += InitChild(dt.Rows[i]["DID"].ToString());
                    name += "},";
                }
            }
            sb.Append(name.ToString().TrimEnd(','));
            return sb.ToString();
        }

        /// <summary>
        /// 绑定职能部门人员信息
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
        public string InitChild(string parentID)
        {
            DataTable dt = teacherDAL.GetByDepID(int.Parse(parentID), (int)CommonEnum.UserType.老师, (int)CommonEnum.IsorNot.否);
            StringBuilder sb = new StringBuilder();
            string name = "";
            if (dt == null)
            {
                //
            }

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    name += "{\"id\":\"" + dt.Rows[i]["UID"].ToString() +
                       "\",\"text\":\"" + dt.Rows[i]["RealName"].ToString() + "\"},";
                }
            }
            sb.Append("\"children\":[");
            sb.Append(name.ToString().TrimEnd(','));
            sb.Append("]");
            return sb.ToString();
        }
        #endregion

        #region 初始化用户数据
        /// <summary>
        /// 初始化用户数据
        /// </summary>
        private void InfoBind()
        {
            Teacher_ClassHourEntity model = teacher_ClassHourDAL.GetObjByID(THID);
            if (model != null)
            {
                //this.txt_TeacherName.Text = model.RealName.ToString();
                //this.hf_TID.Value = model.TID.ToString();
                //SetValue(model.TID);//绑定教师姓名
                //this.hf_SelectedValue.Value = model.TID;
                this.Series.Text = model.TID;
                this.Series.Enabled = false;

                this.ddl_GradeID.SelectedValue = model.GradeID.ToString();
                this.ddl_MainSubject.SelectedValue = model.MainSubject.ToString();
                this.ddl_PartSubject.SelectedValue = model.PartSubject.ToString();
                //this.ddl_MainSubject.SelectedItem.Text = model.MainSubject.ToString();
                //this.ddl_PartSubject.SelectedItem.Text = model.PartSubject.ToString();

                this.txt_MainHours.Text = model.MainHours.ToString();
                this.txt_PartHours.Text = model.PartHours.ToString();
                this.txt_Executive.Text = model.Executive.ToString();
                this.txt_SchoolYear.Text = model.SchoolYear.ToString();
                this.ddl_Semester.SelectedValue = model.Semester.ToString();
                this.txt_SubDesc.Text = model.SubDesc.ToString();
                this.txt_THDesc.Text = model.THDesc.ToString();
                //this.hf_IDCard.Value = model.IDCard.ToString();
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
                Teacher_ClassHourEntity model = new Teacher_ClassHourEntity();
                model.THID = THID.ToString();
                //if (this.hf_SelectedValue.Value == "")
                //{
                //    ShowMessage("教师姓名不能为空");
                //    return;
                //}
                ////model.TID = this.hf_TID.Value;
                //model.TID = this.hf_SelectedValue.Value;//教师
                if (this.Series.Text == "")
                {
                    ShowMessage("请选择教师");
                    return;
                }
                model.TID = this.Series.Text;

                model.GradeID = Convert.ToInt32(this.ddl_GradeID.SelectedValue);
                model.MainHours = Convert.ToInt32(this.txt_MainHours.Text.ToString());
                model.PartHours = Convert.ToInt32(this.txt_PartHours.Text.ToString());

                //model.MainSubject = this.ddl_MainSubject.SelectedItem.Text;
                //model.PartSubject = this.ddl_PartSubject.SelectedItem.Text;
                model.MainSubject = this.ddl_MainSubject.SelectedValue;
                model.PartSubject = this.ddl_PartSubject.SelectedValue;

                model.Executive = Convert.ToInt32(this.txt_Executive.Text.ToString());
                model.SchoolYear = this.txt_SchoolYear.Text.ToString();//学年度
                model.Semester = Convert.ToInt32(this.ddl_Semester.SelectedValue);
                model.SubDesc = this.txt_SubDesc.Text.ToString();
                model.THDesc = this.txt_THDesc.Text.ToString();
                model.Isdel = (int)CommonEnum.Deleted.未删除;
                model.IsReport = (int)CommonEnum.IsorNot.否;//是否上报
                //model.IDCard = this.hf_IDCard.Value.ToString();

                int result = teacher_ClassHourDAL.Edit(model);
                if (result == 0)
                {
                    ShowMessage();
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_修改, "修改教师课时信息", UserID));
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