/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年01月22日 15时40分25秒
** 描    述:      教师管理页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Web;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;


namespace GKICMP.teachermanage
{
    public partial class TeacherEdit : PageBase
    {
        public TeacherDAL teacherDAL = new TeacherDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public BaseDataDAL baseDataDAL = new BaseDataDAL();
        public CourseDAL courseDAL = new CourseDAL();
        public string Role = "";
      
        #region 参数集合
        /// <summary>
        /// TID
        /// </summary>
        public string TID
        {
            get
            {
                return GetQueryString<string>("id", UserID);
            }
        }
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
                    
                    this.div_top.Visible = true;
                    this.txt_IDCardNum.Enabled = false;
                   // this.txt_JoinSchool.Enabled = false;
                    //this.txt_Birthday.Enabled = false;
                    //this.ddl_TSex.Enabled = false;
                   // this.ddl_CardType.Enabled = false;
                   // this.txt_JodDate.Enabled = false;
                }
                DDLBind();
                //TeacherEntity model = teacherDAL.GetObjByID(TID != "" ? TID : UserID);
                //if (model != null)
                //{
                //    this.ltl_RealName.Text = model.RealName;
                //}

                //if (TID != "")
                //{
                    InfoBind();
                //}
                if (this.txt_Nationality.Text == "")
                {
                    this.txt_Nationality.Text = "中国";
                }
                if (this.ddl_EmploymentType.SelectedValue == "-2")
                {
                    this.ddl_EmploymentType.SelectedValue = "3";
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
            CommonFunction.BindEnum<CommonEnum.IsorNot>(this.ddl_IsSeries1);
            this.ddl_IsSeries1.SelectedIndex = 0;
            CommonFunction.BindEnum<CommonEnum.IsorNot>(this.ddl_IsSpecialEdu1);
            this.ddl_IsSpecialEdu1.SelectedIndex = 0;
            CommonFunction.BindEnum<CommonEnum.IsorNot>(this.ddl_IsTeaStu1);
            this.ddl_IsTeaStu1.SelectedIndex = 0;
            CommonFunction.BindEnum<CommonEnum.IsorNot>(this.ddl_IsGrassService1);
            this.ddl_IsGrassService1.SelectedIndex = 0;

            //CommonFunction.BindEnum<CommonEnum.IsorNot>(this.rdo_Section);//学段
            CommonFunction.BindEnum<CommonEnum.IsorNot>(this.rdo_IsTea);//教学岗
            this.rdo_IsTea.SelectedValue = "1";

            CommonFunction.BindEnum<CommonEnum.MandarinType>(this.ddl_Mandarin, "-2");//普通话水平

            CommonFunction.BindEnum<CommonEnum.TeaQualiType>(this.ddl_TeaQualiType, "-2");//教师资格种类

            DataTable dtCourse = courseDAL.GetList();
            CommonFunction.DDlTypeBind(this.ddl_TCourse, dtCourse, "CID", "CourseName", "-2");
           
            CommonFunction.DDlTypeBind(this.ddl_TeaQualCourse, dtCourse, "CID", "CourseName", "-999");
            ddl_TeaQualCourse.Items.Insert(0, new ListItem("无", "-99"));
            CommonFunction.BindEnum<CommonEnum.IsorNot>(this.ddl_IsCountyLevel1);
            this.ddl_IsCountyLevel1.SelectedIndex = 0;
            CommonFunction.BindEnum<CommonEnum.IsorNot>(this.ddl_IsHealthTeahcer1);
            this.ddl_IsHealthTeahcer1.SelectedIndex = 0;
            CommonFunction.BindEnum<CommonEnum.IsorNot>(this.ddl_IsFulltime1);
            this.ddl_IsFulltime1.SelectedIndex = 0;
            CommonFunction.BindEnum<CommonEnum.IsorNot>(this.ddl_IsSpecialTrain1);
            this.ddl_IsSpecialTrain1.SelectedIndex = 0;
            CommonFunction.BindEnum<CommonEnum.IsorNot>(this.ddl_IsSpecialTea1);
            this.ddl_IsSpecialTea1.SelectedIndex = 0;
            CommonFunction.BindEnum<CommonEnum.IsorNot>(this.rdo_IsFull);
            this.rdo_IsFull.SelectedIndex = 1;
            //CommonFunction.DDlDataBaseBind(this.ddl_MaritalStatus, (int)CommonEnum.BaseDataType.婚姻状况);
            //CommonFunction.DDlDataBaseBind(this.ddl_TeaType, (int)CommonEnum.BaseDataType.教职工类别);
            //CommonFunction.DDlDataBaseBind(this.ddl_CardType, (int)CommonEnum.BaseDataType.身份证件类型);
            DataTable HS = baseDataDAL.GetList((int)CommonEnum.BaseDataType.婚姻状况, -1);
            CommonFunction.DDlTypeBind(this.ddl_MaritalStatus, HS, "SDID", "DataName", "-2");

            DataTable TT = baseDataDAL.GetList((int)CommonEnum.BaseDataType.教职工类别, -1);
            CommonFunction.DDlTypeBind(this.ddl_TeaType, TT, "SDID", "DataName", "-2");

            DataTable CT = baseDataDAL.GetList((int)CommonEnum.BaseDataType.身份证件类型, -1);
            CommonFunction.DDlTypeBind(this.ddl_CardType, CT, "SDID", "DataName", "-999");

            DataTable TS = baseDataDAL.GetList((int)CommonEnum.BaseDataType.教职工来源, -1);
            CommonFunction.DDlTypeBind(this.ddl_TeaSource, TS, "SDID", "DataName", "-2");

            CommonFunction.BindEnum<CommonEnum.TeaState>(this.ddl_TeaState, "-2");
            CommonFunction.BindEnum<CommonEnum.XB>(this.ddl_TSex, "-2");
            CommonFunction.BindEnum<CommonEnum.EmploymentForm>(this.ddl_EmploymentType, "-2");
            CommonFunction.BindEnum<CommonEnum.MZ>(this.ddl_TNation, "-2");
            CommonFunction.BindEnum<CommonEnum.ZZMM>(this.ddl_Politics, "-2");
            CommonFunction.BindEnum<CommonEnum.HealthStatus>(this.ddl_HealthStatus, "-2");
            CommonFunction.BindEnum<CommonEnum.ContractState>(this.ddl_ContractState, "-2");
            CommonFunction.BindEnum<CommonEnum.InformationLevel>(this.ddl_InformationLevel, "-2");
            CommonFunction.BindEnum<CommonEnum.ProfessGradeType>(this.ddl_GradeType, "-2");
            CommonFunction.BindEnum<CommonEnum.CurrentProfessional>(this.ddl_CurrentProfessional, "-2");//现任专业技术资格

            //薪级绑定
            this.ddl_SalaryGrade.Items.Add(new ListItem("--请选择--", "-2"));
            for (int i = 0; i <= 65; i++)
            {
                this.ddl_SalaryGrade.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            this.ddl_SalaryGrade.SelectedIndex = 0;

            //CommonFunction.BindEnum<CommonEnum.IsorNot>(this.ddl_IsSpecialEdu, "-2");
            //CommonFunction.BindEnum<CommonEnum.IsorNot>(this.ddl_IsTeaStu, "-2");
            //CommonFunction.BindEnum<CommonEnum.IsorNot>(this.ddl_IsGrassService, "-2");
            //CommonFunction.BindEnum<CommonEnum.IsorNot>(this.ddl_IsCountyLevel, "-2");
            //CommonFunction.BindEnum<CommonEnum.IsorNot>(this.ddl_IsHealthTeahcer, "-2");
            //CommonFunction.BindEnum<CommonEnum.IsorNot>(this.ddl_IsSeries, "-2");
            //CommonFunction.BindEnum<CommonEnum.IsorNot>(this.ddl_IsFulltime, "-2");
            //CommonFunction.BindEnum<CommonEnum.IsorNot>(this.ddl_IsSpecialTrain, "-2");
            //CommonFunction.BindEnum<CommonEnum.IsorNot>(this.ddl_IsSpecialTea, "-2");

            StringBuilder sb = new StringBuilder("");
            string b = PostRoleBand();
            sb.Append("<script type='text/javascript'>");
            sb.Append(" $(function () {");
            sb.Append(" $('#PostRole').combotree({");
            sb.Append(" data:[");
            sb.Append(b);
            sb.Append("],");
            sb.Append("multiple: true,");
            sb.Append("multiline: true,");
            sb.Append("});");
            sb.Append(" }); </script>");
            this.ltl_ggjb.Text = sb.ToString();
        }
        #endregion


        public string PostRoleBand()
        {
            DataTable dt;
            dt = baseDataDAL.GetList((int)CommonEnum.BaseDataType.教师职务角色, -1);
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
                    name += "{\"id\":\"" + dt.Rows[i]["SDID"].ToString() +
                       "\",\"text\":\"" + dt.Rows[i]["DataName"].ToString() + "\",";
                    //调用递归方法
                    name += InitChild(int.Parse(dt.Rows[i]["SDID"].ToString()));
                    name += "},";
                }
            }
            sb.Append(name.ToString().TrimEnd(','));
            return sb.ToString();

        }
        public string InitChild(int parentID)
        {
            DataTable dt = baseDataDAL.GetList((int)CommonEnum.BaseDataType.教师职务角色, parentID); ;
            StringBuilder sb = new StringBuilder();
            string name = "";
            if (dt == null)
            {
            }
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    name += "{\"id\":\"" + dt.Rows[i]["SDID"].ToString() +
                       "\",\"text\":\"" + dt.Rows[i]["DataName"].ToString() + "\"},";
                }
            }
            sb.Append("\"children\":[");
            sb.Append(name.ToString().TrimEnd(','));
            sb.Append("]");
            return sb.ToString();
        }


        #region 初始化用户数据
        /// <summary>
        /// 初始化用户数据
        /// </summary>
        private void InfoBind()
        {
            TeacherEntity tmodel = teacherDAL.GetObjByID(TID);
            if (tmodel != null)
            {
                this.hf_TID.Value = TID;
                this.ltl_RealName.Text = tmodel.RealName;
               

                this.ddl_IsSpecialEdu1.SelectedValue = tmodel.IsSpecialEdu.ToString();
                this.ddl_IsTeaStu1.SelectedValue = tmodel.IsTeaStu.ToString();
                this.ddl_IsGrassService1.SelectedValue = tmodel.IsGrassService.ToString();
                this.ddl_IsCountyLevel1.SelectedValue = tmodel.IsCountyLevel.ToString();
                this.ddl_IsHealthTeahcer1.SelectedValue = tmodel.IsHealthTeahcer.ToString();

                this.ddl_IsFulltime1.SelectedValue = tmodel.IsFulltime.ToString();
                this.ddl_IsSpecialTrain1.SelectedValue = tmodel.IsSpecialTrain.ToString();
                this.ddl_IsSpecialTea1.SelectedValue = tmodel.IsSpecialTea.ToString();
                this.ddl_IsSeries1.Text = tmodel.IsSeries.ToString();

                this.ddl_EmploymentType.SelectedValue = tmodel.EmploymentType.ToString();
                this.ddl_TeaState.SelectedValue = tmodel.TeaState.ToString();
                this.ddl_TNation.SelectedValue = tmodel.TNation.ToString();
                this.ddl_Politics.Text = tmodel.Politics.ToString();
                this.ddl_HealthStatus.SelectedValue = tmodel.HealthStatus.ToString();
                this.ddl_TSex.SelectedValue = tmodel.TSex.ToString();//性别

                this.ddl_TeaType.SelectedValue = tmodel.TeaType.ToString(); //教职工类别
                this.ddl_MaritalStatus.SelectedValue = tmodel.MaritalStatus.ToString(); //婚姻状态
                this.ddl_CardType.SelectedValue = tmodel.CardType.ToString(); //身份证件类型
                this.ddl_TeaSource.SelectedValue = tmodel.TeaSource.ToString(); //教职工来源

                this.ddl_TCourse.SelectedValue = tmodel.TCourse.ToString();

                this.ddl_ContractState.Text = tmodel.ContractState.ToString();
                this.ddl_InformationLevel.Text = tmodel.InformationLevel.ToString();

                this.txt_Birthday.Text = tmodel.Birthday.ToString("yyyy-MM-dd") == "0001-01-01" ? "" : tmodel.Birthday.ToString("yyyy-MM-dd");
                this.txt_JodDate.Text = tmodel.JodDate.ToString("yyyy-MM-dd") == "0001-01-01" ? "" : tmodel.JodDate.ToString("yyyy-MM-dd");
                this.txt_JoinSchool.Text = tmodel.JoinSchool.ToString("yyyy-MM-dd") == "0001-01-01" ? "" : tmodel.JoinSchool.ToString("yyyy-MM-dd");

                DataTable dt1 = teacherDAL.GetRole(TID);
                if (dt1.Rows.Count > 0)
                {
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        Role += dt1.Rows[i]["RID"].ToString() + ",";
                    }
                    Role = Role.Trim(','); ;//职务角色
                }

                if (tmodel.PartyTme.ToString("yyyy-MM-dd") == "1900-01-01" || tmodel.PartyTme.ToString("yyyy-MM-dd") == "0001-01-01")
                {
                    this.txt_PartyTme.Text = "";
                }
                else
                {
                    this.txt_PartyTme.Text = tmodel.PartyTme.ToString("yyyy-MM-dd");//入党时间
                }

                if (tmodel.GrassStartDate.ToString("yyyy-MM-dd") == "1900-01-01" || tmodel.GrassStartDate.ToString("yyyy-MM-dd") == "0001-01-01")
                {
                    this.txt_GrassStartDate.Text = "";
                }
                else
                {
                    this.txt_GrassStartDate.Text = tmodel.GrassStartDate.ToString("yyyy-MM-dd");
                }

                if (tmodel.GrassEndDate.ToString("yyyy-MM-dd") == "1900-01-01" || tmodel.GrassEndDate.ToString("yyyy-MM-dd") == "0001-01-01")
                {
                    this.txt_GrassEndDate.Text = "";
                }
                else
                {
                    this.txt_GrassEndDate.Text = tmodel.GrassEndDate.ToString("yyyy-MM-dd");
                }

                //this.txt_GrassStartDate.Text = tmodel.GrassStartDate.ToString() == "1990/1/1 0:00:00" ? "" : tmodel.GrassStartDate.ToString("yyyy-MM-dd");
                //this.txt_GrassEndDate.Text = tmodel.GrassEndDate.ToString() == "1900/1/1 0:00:00" ? "" : tmodel.GrassEndDate.ToString("yyyy-MM-dd");
                this.txt_OldName.Text = tmodel.OldName == null ? "" : tmodel.OldName.ToString();
                this.txt_TeacherCode.Text = tmodel.TeacherCode == null ? "" : tmodel.TeacherCode.ToString();
                this.txt_Nationality.Text = tmodel.Nationality == null ? "" : tmodel.Nationality.ToString();
                this.txt_IDCardNum.Text = tmodel.IDCardNum == null ? "" : tmodel.IDCardNum.ToString();
                this.txt_PlaceOrigin.Text = tmodel.PlaceOrigin == null ? "" : tmodel.PlaceOrigin.ToString();
                this.txt_OneNative.Text = tmodel.OneNative == null ? "" : tmodel.OneNative.ToString();
                this.ddl_GradeType.SelectedValue = tmodel.GradeType.ToString();//专业技术岗位等级分类
                this.ddl_ProfessGrade.SelectedValue = tmodel.ProfessGrade.ToString();
                this.ddl_SalaryGrade.SelectedValue = tmodel.SalaryGrade.ToString();
                this.ddl_CurrentProfessional.SelectedValue = tmodel.CurrentProfessional.ToString();
                this.rdo_IsFull.SelectedValue = tmodel.IsFull.ToString();
                if (tmodel.GradeType != -2 && tmodel.ProfessGrade == -2)
                {
                    DataTable dt = baseDataDAL.GetList((int)CommonEnum.BaseDataType.专业技术岗位等级, tmodel.GradeType);
                    CommonFunction.DDlTypeBind(this.ddl_ProfessGrade, dt, "SDID", "DataName", "-2");
                }
                else
                {
                    DataTable dt = baseDataDAL.GetList((int)CommonEnum.BaseDataType.专业技术岗位等级, tmodel.GradeType);
                    CommonFunction.DDlTypeBind(this.ddl_ProfessGrade, dt, "SDID", "DataName", "-2");
                    this.ddl_ProfessGrade.SelectedValue = tmodel.ProfessGrade.ToString();//专业技术岗位等级
                }
                //学段
                this.ddl_Section.SelectedValue = tmodel.Section.ToString();
                //string xd= XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "XD");

                //if (xd.IndexOf(',') < 0)
                //{
                //    this.ddl_Section.SelectedValue = xd;
                //    //this.ddl_Section.Enabled = false;
                //}

                this.rdo_IsTea.SelectedValue = tmodel.IsTea.ToString();//是否教学岗
                this.txt_GradeDate.Text = tmodel.GradeDate.ToString("yyyy-MM-dd") == "0001-01-01" ? "" : tmodel.GradeDate.ToString("yyyy-MM-dd") == "1900-01-01" ? "" : tmodel.GradeDate.ToString("yyyy-MM-dd");//取得时间
                this.ddl_Mandarin.SelectedValue = tmodel.Mandarin.ToString();//普通话水平
                this.ddl_TeaQualiType.SelectedValue = tmodel.TeaQualiType.ToString();
                this.txt_TeaQualCode.Text = tmodel.TeaQualCode;
                this.ddl_TeaQualCourse.SelectedValue = tmodel.TeaQualCourse.ToString();
                this.txt_TeaQualDate.Text = tmodel.TeaQualDate.ToString("yyyy-MM-dd") == "0001-01-01" ? "" : tmodel.TeaQualDate.ToString("yyyy-MM-dd");
                this.txt_TeaQualRegDate.Text = tmodel.TeaQualRegDate.ToString("yyyy-MM-dd") == "0001-01-01" ? "" : tmodel.TeaQualRegDate.ToString("yyyy-MM-dd");
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
                TeacherEntity model = new TeacherEntity();
                model.TID = TID ;
                model.IsSpecialEdu = Convert.ToInt32(this.ddl_IsSpecialEdu1.SelectedValue.ToString());
                model.IsTeaStu = Convert.ToInt32(this.ddl_IsTeaStu1.SelectedValue.ToString());
                model.IsGrassService = Convert.ToInt32(this.ddl_IsGrassService1.SelectedValue.ToString());
                model.IsCountyLevel = Convert.ToInt32(this.ddl_IsCountyLevel1.SelectedValue.ToString());
                model.IsHealthTeahcer = Convert.ToInt32(this.ddl_IsHealthTeahcer1.SelectedValue.ToString());

                model.IsSeries = Convert.ToInt32(this.ddl_IsSeries1.SelectedValue.ToString());
                model.IsFulltime = Convert.ToInt32(this.ddl_IsFulltime1.SelectedValue.ToString());
                model.IsSpecialTrain = Convert.ToInt32(this.ddl_IsSpecialTrain1.SelectedValue.ToString());
                model.IsSpecialTea = Convert.ToInt32(this.ddl_IsSpecialTea1.SelectedValue.ToString());

                model.EmploymentType = Convert.ToInt32(this.ddl_EmploymentType.SelectedValue.ToString());
                model.TeaState = Convert.ToInt32(this.ddl_TeaState.SelectedValue.ToString());
                model.TNation = Convert.ToInt32(this.ddl_TNation.SelectedValue.ToString());
                model.Politics = Convert.ToInt32(this.ddl_Politics.SelectedValue.ToString());
                model.HealthStatus = Convert.ToInt32(this.ddl_HealthStatus.SelectedValue.ToString());
                model.TSex = Convert.ToInt32(this.ddl_TSex.SelectedValue.ToString());//性别

                model.TeaType = Convert.ToInt32(this.ddl_TeaType.SelectedValue.ToString()); //教职工类别
                model.MaritalStatus = Convert.ToInt32(this.ddl_MaritalStatus.SelectedValue.ToString()); //婚姻状态
                model.CardType = Convert.ToInt32(this.ddl_CardType.SelectedValue.ToString()); //身份证件类型
                model.TeaSource = Convert.ToInt32(this.ddl_TeaSource.SelectedValue.ToString());//教职工来源


                model.ContractState = Convert.ToInt32(this.ddl_ContractState.SelectedValue.ToString());
                model.InformationLevel = Convert.ToInt32(this.ddl_InformationLevel.SelectedValue.ToString());
                model.Birthday = Convert.ToDateTime(this.txt_Birthday.Text.ToString());
                model.JodDate = Convert.ToDateTime(this.txt_JodDate.Text.ToString());
                model.JoinSchool = Convert.ToDateTime(this.txt_JoinSchool.Text.ToString());

                model.TCourse = int.Parse(this.ddl_TCourse.SelectedValue);
                model.GrassStartDate = this.txt_GrassStartDate.Text == "" ? Convert.ToDateTime("1900-01-01") : Convert.ToDateTime(this.txt_GrassStartDate.Text.ToString());
                model.GrassEndDate = this.txt_GrassEndDate.Text == "" ? Convert.ToDateTime("1900-01-01") : Convert.ToDateTime(this.txt_GrassEndDate.Text.ToString());
                //model.GrassStartDate = Convert.ToDateTime(this.txt_GrassStartDate.Text.ToString());
                //model.GrassEndDate = Convert.ToDateTime(this.txt_GrassEndDate.Text.ToString());
                model.OldName = this.txt_OldName.Text.ToString();
                model.TeacherCode = this.txt_TeacherCode.Text.ToString();
                model.Nationality = this.txt_Nationality.Text.ToString();

                model.IDCardNum = this.txt_IDCardNum.Text.ToString();
                model.PlaceOrigin = this.txt_PlaceOrigin.Text.ToString();
                model.OneNative = this.txt_OneNative.Text.ToString();
                model.PartyTme = this.txt_PartyTme.Text.ToString() == "" ? Convert.ToDateTime("1900-01-01") : Convert.ToDateTime(this.txt_PartyTme.Text.ToString());
                model.PostRole = this.hf_PostRole.Value.ToString();//职务角色
                model.PostName = this.hf_PostRoleName.Value.ToString();
                model.SalaryGrade = Convert.ToInt32(this.ddl_SalaryGrade.SelectedValue.ToString());
                model.CurrentProfessional = Convert.ToInt32(this.ddl_CurrentProfessional.SelectedValue.ToString());
                model.GradeType = Convert.ToInt32(this.ddl_GradeType.SelectedValue.ToString());
                model.ProfessGrade = Convert.ToInt32(this.ddl_ProfessGrade.SelectedValue.ToString());
                // model.IsReport = (int)CommonEnum.IsorNot.否;
                model.IsFull =int.Parse( this.rdo_IsFull.SelectedValue);

                model.IsTea = int.Parse(this.rdo_IsTea.SelectedValue);//是否教学岗
                model.GradeDate =this.txt_GradeDate.Text==""?Convert.ToDateTime("1900-01-01"): Convert.ToDateTime( this.txt_GradeDate.Text);//取得时间
                model.Mandarin =int.Parse( this.ddl_Mandarin.SelectedValue);//普通话水平
                model.TeaQualiType = int.Parse(this.ddl_TeaQualiType.SelectedValue);
                model.TeaQualCode = this.txt_TeaQualCode.Text;
                model.TeaQualCourse = int.Parse(this.ddl_TeaQualCourse.SelectedValue);
                model.TeaQualDate = Convert.ToDateTime( this.txt_TeaQualDate.Text);
                model.TeaQualRegDate =Convert.ToDateTime(  this.txt_TeaQualRegDate.Text);
                model.Section = int.Parse(this.ddl_Section.SelectedValue);
                model.IsRetire = (int)CommonEnum.IsorNot.否;
                int result = teacherDAL.Update(model);
                if (result > 0)
                {
                    // ShowMessage();
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_修改, "修改教师姓名为：【" + this.ltl_RealName.Text + "】的教师信息", UserID));
                    if (Flag == 1)
                        Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('提交成功！');window.location='TeacherEdit.aspx?flag=1';", true);
                    else
                        Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('提交成功！');window.location='TeacherManage.aspx';", true);
                }
                else
                {
                    ShowMessage("提交失败");
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
        protected void btn_return_Click(object sender, EventArgs e)
        {
            Response.Redirect("TeacherManage.aspx");
        }
        #endregion


        #region 根据岗位等级分类查询岗位等级
        /// <summary>
        /// 根据岗位等级分类查询岗位等级
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddl_GradeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = baseDataDAL.GetList((int)CommonEnum.BaseDataType.专业技术岗位等级, Convert.ToInt32(this.ddl_GradeType.SelectedValue.ToString()));
            CommonFunction.DDlTypeBind(this.ddl_ProfessGrade, dt, "SDID", "DataName", "-2");
        }
        #endregion
    }
}