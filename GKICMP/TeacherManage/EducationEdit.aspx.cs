/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      fsc
** 创建日期:    2017年02月27日
** 描 述:       用户编辑页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using GK.GKICMP.Common;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Data;
using System.Text;

namespace GKICMP.teachermanage
{
    public partial class EducationEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public TeacherEducationDAL teacherEducation = new TeacherEducationDAL();
        public BaseDataDAL baseDataDAL = new BaseDataDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public TeacherDAL teacherDAL = new TeacherDAL();

        #region 参数集合
        /// <summary>
        /// TEID
        /// </summary>
        public string TEID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }

        /// <summary>
        /// TID
        /// </summary>
        public string TID
        {
            get
            {
                return GetQueryString<string>("tid", "");
            }
        }


        /// <summary>
        /// TID
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.hf_SelectedValue.Value = TID;
                DDLBind();
               // BandDepart();

                if (Flag == 1)
                {

                    this.Series.Text = UserID;
                    this.Series.Enabled = false;
                }
                if (TID != "")
                {
                    this.Series.Text = TID;
                    this.Series.Enabled = false;
                } 
                //SetValue(TID);
                if (TEID != "")
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
            DataTable HS = baseDataDAL.GetList((int)CommonEnum.BaseDataType.国家, -1);
            CommonFunction.DDlTypeBind(this.ddl_EduCountry, HS, "SDID", "DataName", "-999");

            DataTable TT = baseDataDAL.GetList((int)CommonEnum.BaseDataType.国家, -1);
            CommonFunction.DDlTypeBind(this.ddl_GradeCountry, TT, "SDID", "DataName", "-999");

            DataTable CT = baseDataDAL.GetList((int)CommonEnum.BaseDataType.在学单位类别, -1);
            CommonFunction.DDlTypeBind(this.ddl_CompanyType, CT, "SDID", "DataName", "-2");

            CommonFunction.BindEnum<CommonEnum.XL>(this.ddl_Education, "-2");//获得学历

            CommonFunction.BindEnum<CommonEnum.IsorNot>(this.rbl_IsTeach);
            CommonFunction.BindEnum<CommonEnum.XWCC>(this.ddl_DegreeLevel, "-2");//学位层次
            CommonFunction.BindEnum<CommonEnum.XWLB>(this.ddl_DegreeName, "-2");//学位名称
            CommonFunction.BindEnum<CommonEnum.XXFS>(this.ddl_StudyType, "-2");//学习方式

            this.rbl_IsTeach.SelectedIndex = 1;
            this.ddl_GradeCountry.SelectedIndex = 0;
            this.ddl_EduCountry.SelectedIndex = 0;
        }
        #endregion

        private void SetValue(string TID)
        {
            // ClientScript.RegisterStartupScript(this.GetType(), "", "<script>disable();</script>");
            StringBuilder sb1 = new StringBuilder();
            sb1.Append("<script type='text/javascript'>");
            sb1.Append("$(function () {$('#Series').combotree('setValue', '");
            sb1.Append(TID);
            sb1.Append("');");
            sb1.Append("$('#Series').combotree('disable');");
            sb1.Append("})</script>");
            this.ltl_xz.Text = sb1.ToString();
        }

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
        //            //this.hf_SelectedValue.Value += dt.Rows[i]["UID"].ToString() + ',';
        //            name += "{\"id\":\"" + dt.Rows[i]["UID"].ToString() +
        //               "\",\"text\":\"" + dt.Rows[i]["RealName"].ToString() + "\"},";
        //        }
        //    }
        //    //sb.Append(name.ToString().TrimEnd(','));
        //    //sb.Append("\"children\":[");
        //    sb.Append(name.ToString().TrimEnd(','));
        //    //sb.Append("]");
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
            sb.Append(" $('#Series').combotree({");
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
            Teacher_EducationEntity tmodel = teacherEducation.GetObjByID(TEID);
            if (tmodel != null)
            {
                //this.TeacherName.Value = tmodel.TName;

                //SetValue(tmodel.TID);//绑定教师姓名
                //this.hf_SelectedValue.Value = tmodel.TID;

                this.Series.Text = tmodel.TID;
                this.Series.Enabled = false;


                this.ddl_Education.SelectedValue = tmodel.Education.ToString();
                this.rbl_IsTeach.SelectedValue = tmodel.IsTeach.ToString();
                this.ddl_DegreeLevel.SelectedValue = tmodel.DegreeLevel.ToString();
                this.ddl_DegreeName.SelectedValue = tmodel.DegreeName.ToString();

                this.ddl_StudyType.SelectedValue = tmodel.StudyType.ToString();
                this.ddl_CompanyType.SelectedValue = tmodel.CompanyType.ToString();
                this.ddl_EduCountry.Text = tmodel.EduCountry.ToString();
                this.ddl_GradeCountry.SelectedValue = tmodel.GradeCountry.ToString();

                this.txt_InDate.Text = tmodel.InDate.ToString("yyyy-MM-dd") == "1900-01-01" ? "" : tmodel.InDate.ToString("yyyy-MM");
                this.txt_OutDate.Text = tmodel.OutDate.ToString("yyyy-MM-dd") == "1900-01-01" ? "" : tmodel.OutDate.ToString("yyyy-MM");
                this.txt_GrantDate.Text = tmodel.GrantDate.ToString("yyyy-MM-dd") == "1900-01-01" ? "" : tmodel.GrantDate.ToString("yyyy-MM");

                this.txt_EduSchool.Text = tmodel.EduSchool == null ? "" : tmodel.EduSchool.ToString();
                this.txt_EMajor.Text = tmodel.EMajor == null ? "" : tmodel.EMajor.ToString();
                this.txt_GradeSchool.Text = tmodel.GradeSchool == null ? "" : tmodel.GradeSchool.ToString();
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

                Teacher_EducationEntity model = new Teacher_EducationEntity();
                model.TEID = TEID;
                //if (this.hf_SelectedValue.Value == "")
                //{
                //    ShowMessage("教师姓名不能为空");
                //    return;
                //}
                //model.TID = this.hf_SelectedValue.Value;

                if (this.Series.Text == "")
                {
                    ShowMessage("请选择教师");
                    return;
                }
                model.TID = this.Series.Text;


                //model.TID = this.hf_UID.Value;//教师
                model.Education = Convert.ToInt32(this.ddl_Education.SelectedValue.ToString());
                model.IsTeach = Convert.ToInt32(this.rbl_IsTeach.SelectedValue.ToString());
                model.DegreeLevel = Convert.ToInt32(this.ddl_DegreeLevel.SelectedValue.ToString());
                model.DegreeName = Convert.ToInt32(this.ddl_DegreeName.SelectedValue.ToString());

                model.StudyType = Convert.ToInt32(this.ddl_StudyType.SelectedValue.ToString());
                model.CompanyType = Convert.ToInt32(this.ddl_CompanyType.SelectedValue.ToString());
                model.EduCountry = Convert.ToInt32(this.ddl_EduCountry.SelectedValue.ToString());
                model.GradeCountry = Convert.ToInt32(this.ddl_GradeCountry.SelectedValue.ToString());


                model.InDate = this.txt_InDate.Text == "" ? Convert.ToDateTime("1900/1/1 0:00:00") : Convert.ToDateTime(this.txt_InDate.Text.Trim());
                model.OutDate = this.txt_OutDate.Text == "" ? Convert.ToDateTime("1900/1/1 0:00:00") : Convert.ToDateTime(this.txt_OutDate.Text.Trim());
                model.GrantDate = this.txt_GrantDate.Text == "" ? Convert.ToDateTime("1900/1/1 0:00:00") : Convert.ToDateTime(this.txt_GrantDate.Text.Trim());

                //model.InDate = Convert.ToDateTime(this.txt_InDate.Text.Trim());
                //model.OutDate = Convert.ToDateTime(this.txt_OutDate.Text.Trim());
                //model.GrantDate = Convert.ToDateTime(this.txt_GrantDate.Text.Trim());

                model.EduSchool = this.txt_EduSchool.Text.ToString();
                model.EMajor = this.txt_EMajor.Text.ToString();
                model.GradeSchool = this.txt_GradeSchool.Text.ToString();

                model.CreateUser = UserID;
                model.Isdel = (int)CommonEnum.Deleted.未删除;
                model.IsReport = (int)CommonEnum.IsorNot.否;

                int result = teacherEducation.Edit(model);
                if (result == 0)
                {
                    ShowMessage();
                    sysLogDAL.Edit(new SysLogEntity(TEID == "" ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改, (TEID == "" ? "添加" : "修改") + "学历名称为：" + this.txt_GradeSchool.Text + "的信息", UserID));
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
            }
        }
        #endregion
    }
}