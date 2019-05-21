/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2017年06月16日 08时09分40秒
** 描    述:      学生体质健康的基本操作类
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Data;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using System.Text;
using GK.GKICMP.Entities;

namespace GKICMP.studentmanage
{
    public partial class StuPhysicalEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public Teacher_JournalDAL journalDAL = new Teacher_JournalDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public TeacherDAL teacherDAL = new TeacherDAL();
        public Stu_PhysicalDAL stu_PhysicalDAL = new Stu_PhysicalDAL();
        public GradeDAL GradeDAL = new GradeDAL();

        #region 参数集合
        public string SPID
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
                //CommonFunction.BindEnum<CommonEnum.XQ>(this.ddl_Term, "-2");
                ////CommonFunction.BindEnum<CommonEnum.IsorNot>(this.ddl_DentalCaries, "-2");
                CommonFunction.BindEnum<CommonEnum.XQ>(this.ddl_Term, "-2");
                if (DateTime.Now.Month > 8)
                {
                    this.txt_EYear.Text = DateTime.Now.Year + "-" + (DateTime.Now.Year + 1);
                    this.ddl_Term.SelectedValue = ((int)CommonEnum.XQ.上学期).ToString();
                    //  this.ddl_Term.Enabled = false;
                }
                else
                {
                    this.txt_EYear.Text = (DateTime.Now.Year - 1) + "-" + DateTime.Now.Year;
                    this.ddl_Term.SelectedValue = ((int)CommonEnum.XQ.下学期).ToString();
                    // this.ddl_Term.Enabled = false;
                }

                CommonFunction.BindEnum<CommonEnum.IsorNot>(this.ddl_DentalCaries1);
                this.ddl_DentalCaries1.SelectedIndex = 0;

                // BandData();
              // GetBandData();

                if (SPID != "")
                {
                    InfoBind();
                }
            }
        }
        #endregion

        #region 绑定学生姓名
        private void SetValue(string TID)
        {
            StringBuilder sb1 = new StringBuilder();
            sb1.Append("<script type='text/javascript'>");
            sb1.Append("$(function () {$('#Series').combotree('setValue', '");
            sb1.Append(TID);
            sb1.Append("');");
            sb1.Append("$('#Series').combotree('disable');");
            sb1.Append("})</script>");
            this.ltl_xz.Text = sb1.ToString();
        }
        #endregion

        #region 绑定学生
        /// <summary>
        /// 绑定学生
        /// </summary>
        private void BandData()
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
            this.ltl_Content.Text = sb.ToString();
        }

        /// <summary>
        /// 绑定普通班级信息
        /// </summary>
        /// <returns></returns>
        private string MList()
        {
            DataTable dt;
            dt = departmentDAL.GetZNBM((int)CommonEnum.DepType.普通班级, (int)CommonEnum.IsorNot.否);
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
        /// 绑定普通班级人员信息
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
        public string InitChild(string parentID)
        {
            DataTable dt = teacherDAL.GetByDepID(int.Parse(parentID), (int)CommonEnum.UserType.学生, (int)CommonEnum.IsorNot.否);
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
            Stu_PhysicalEntity model = stu_PhysicalDAL.GetObjByID(SPID);
            if (model != null)
            {
                //SetValue(model.StuID);//绑定学生姓名
                //this.hf_TID.Value = model.StuID;

                this.Series.Text = model.StuID;
                this.Series.Enabled = false;

                this.txt_EYear.Text = model.EYear.ToString();
                this.ddl_Term.SelectedValue = model.Term.ToString();
                //this.ddl_DentalCaries.SelectedValue = model.DentalCaries.ToString();
                this.ddl_DentalCaries1.SelectedValue = model.DentalCaries.ToString();
                this.txt_StuWeight.Text = Convert.ToString(model.StuWeight);
                this.txt_StuHeight.Text = Convert.ToString(model.StuHeight);
                this.txt_Bust.Text = Convert.ToString(model.Bust);
                this.txt_Vitalcapacity.Text = Convert.ToString(model.Vitalcapacity);
                this.txt_LVision.Text = Convert.ToString(model.LVision);
                this.txt_RVision.Text = Convert.ToString(model.RVision);
                this.txt_Lhearing.Text = Convert.ToString(model.Lhearing);
                this.txt_Rhearing.Text = Convert.ToString(model.Rhearing);
                //StringBuilder sb1 = new StringBuilder();
                //sb1.Append("<script type='text/javascript'>");
                //sb1.Append("$(function () {$('#Series').combotree('setValues',['");
                //sb1.Append(this.hf_TID.Value.Trim(','));
                //sb1.Append("']);})</script>");
                //this.ltl_xz.Text = sb1.ToString();
            }
        }
        #endregion


        #region 提交
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                Stu_PhysicalEntity model = new Stu_PhysicalEntity();
                model.SPID = SPID;
                //if (this.hf_TID.Value == "")
                //{
                //    ShowMessage("教师姓名不能为空");
                //    return;
                //}
                //model.StuID = this.hf_TID.Value;

                //if (this.Series.Text == "" || this.Series.Text.Length < 10)
                if (this.Series.Text == "")
                { 
                    ShowMessage("请选择学生"); 
                    return; 
                }
                model.StuID = this.Series.Text;

                model.Term = Convert.ToInt32(this.ddl_Term.SelectedValue.ToString());
                //model.DentalCaries = Convert.ToInt32(this.ddl_DentalCaries.SelectedValue.ToString());
                model.DentalCaries = Convert.ToInt32(this.ddl_DentalCaries1.SelectedValue.ToString());
                model.EYear = this.txt_EYear.Text.Trim();

                model.StuWeight = Convert.ToDecimal(this.txt_StuWeight.Text.Trim());
                model.StuHeight = Convert.ToDecimal(this.txt_StuHeight.Text.Trim());
                model.Bust = Convert.ToDecimal(this.txt_Bust.Text.Trim());
                model.Vitalcapacity = Convert.ToDecimal(this.txt_Vitalcapacity.Text.Trim());
                model.LVision = Convert.ToDecimal(this.txt_LVision.Text.Trim());

                model.RVision = Convert.ToDecimal(this.txt_RVision.Text.Trim());
                model.Lhearing = Convert.ToDecimal(this.txt_Lhearing.Text.Trim());
                model.Rhearing = Convert.ToDecimal(this.txt_Rhearing.Text.Trim());
                model.CreateUser = UserID;
               

                DataTable dt = departmentDAL.GetZNBM((int)CommonEnum.DepType.普通班级, (int)CommonEnum.IsorNot.否);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (this.hf_TID.Value == dt.Rows[i]["DID"].ToString())
                    {
                        ShowMessage("部门不可选做教师");
                        return;
                    }
                }
                

                int result = stu_PhysicalDAL.Edit(model);
                if (result == -2)
                {
                    ShowMessage("每学年每学期下每位学生只能录入一条体质健康信息");
                    return;
                    
                }
                else if (result == -1)
{
                    ShowMessage("保存失败");
                    return;
                    
                }
                else
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, SPID == "" ? "添加" : "修改" + "学生健康体质信息", UserID));
                    ShowMessage();
                }
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, ex.Message, UserID));
                ShowMessage(ex.Message);
            }
        }
        #endregion


        #region 绑定年级下的班级的学生(三级菜单)
        /// <summary>
        /// 绑定年级下的班级的学生(三级菜单)
        /// </summary>
        private void GetBandData()
        {
            StringBuilder sb = new StringBuilder("");
            string a = GList();
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
            this.ltl_Content.Text = sb.ToString();
        }

        /// <summary>
        /// 获取未毕业未删除的年级名称
        /// </summary>
        /// <returns></returns>
        private string GList()
        {
            //获取未毕业未删除的年级名称
            DataTable dd = GradeDAL.GetListAll((int)CommonEnum.IsorNot.否);
            string dname = string.Empty;
            if (dd == null)
            {
                dname = "[]";
            }
            StringBuilder sb = new StringBuilder();
            if (dd.Rows.Count > 0)
            {
                for (int x = 0; x < dd.Rows.Count; x++)
                {
                    dname += "{\"id\":\"" + dd.Rows[x]["GID"].ToString() +
                      "\",\"text\":\"" + dd.Rows[x]["GradeName"].ToString() + "\",";
                    //调用递归方法
                    dname += InitGrade(dd.Rows[x]["GID"].ToString());
                    dname += "},";

                }
            }
            sb.Append(dname.ToString().TrimEnd(','));
            return sb.ToString();


        }

        /// <summary>
        /// 绑定年级下的班级
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
        public string InitGrade(string parentID)
        {
            //DataTable df = teacherDAL.GetByDepID(int.Parse(parentID), (int)CommonEnum.DepType.普通班级, (int)CommonEnum.IsorNot.否);
            DataTable dt = departmentDAL.GetPTBJ(int.Parse(parentID), (int)CommonEnum.DepType.普通班级, (int)CommonEnum.IsorNot.否);
            StringBuilder sb = new StringBuilder();
            string name = "";
            if (dt == null)
            {
                //name = "[]";
            }
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    name += "{\"id\":\"" + dt.Rows[i]["DID"].ToString() +
                       "\",\"text\":\"" + dt.Rows[i]["DepName"].ToString() + "\",";
                    //调用递归方法
                    name += InitGChild(dt.Rows[i]["DID"].ToString());
                    name += "},";
                }
            }
            sb.Append("\"children\":[");
            sb.Append(name.ToString().TrimEnd(','));
            sb.Append("]");
            return sb.ToString();
        }


        /// <summary>
        /// 绑定普通班级下的学生
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
        public string InitGChild(string parentID)
        {
            DataTable dt = teacherDAL.GetByDepID(int.Parse(parentID), (int)CommonEnum.UserType.学生, (int)CommonEnum.IsorNot.否);
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


    }
}