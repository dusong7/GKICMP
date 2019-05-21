/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2017年01月26日 16时05分25秒
** 描    述:      教师管理页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using System.Data;

namespace GKICMP.teachermanage
{
    public partial class TeacherDetail : PageBase
    {
        public TeacherDAL teacherDAL = new TeacherDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public BaseDataDAL baseDataDAL = new BaseDataDAL();
        public string Role = "";

        #region 参数集合
        /// <summary>
        /// TID 用户ID ==教师ID
        /// </summary>
        public string TID
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
                InfoBind();
            }
        }
        #endregion


        #region 绑定数据
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void InfoBind()
        {
            TeacherEntity model = teacherDAL.GetObjByID(TID);
            if (model != null)
            {
                this.ltl_RealName.Text = model.RealName == null ? "" : model.RealName.ToString();//姓名

                this.ltl_IsSpecialEdu.Text = CommonFunction.CheckEnum<CommonEnum.IsorNot>(model.IsSpecialEdu.ToString());
                this.ltl_IsTeaStu.Text = CommonFunction.CheckEnum<CommonEnum.IsorNot>(model.IsTeaStu.ToString());
                this.ltl_IsGrassService.Text = CommonFunction.CheckEnum<CommonEnum.IsorNot>(model.IsGrassService.ToString());
                this.ltl_IsCountyLevel.Text = CommonFunction.CheckEnum<CommonEnum.IsorNot>(model.IsCountyLevel.ToString());

                this.ltl_IsHealthTeahcer.Text = CommonFunction.CheckEnum<CommonEnum.IsorNot>(model.IsHealthTeahcer.ToString());
                this.ltl_IsSeries.Text = CommonFunction.CheckEnum<CommonEnum.IsorNot>(model.IsSeries.ToString());
                this.ltl_IsFulltime.Text = CommonFunction.CheckEnum<CommonEnum.IsorNot>(model.IsFulltime.ToString());
                this.ltl_IsSpecialTrain.Text = CommonFunction.CheckEnum<CommonEnum.IsorNot>(model.IsSpecialTrain.ToString());

                this.ltl_IsSpecialTea.Text = CommonFunction.CheckEnum<CommonEnum.IsorNot>(model.IsSpecialTea.ToString());


                this.ltl_TNation.Text = CommonFunction.CheckEnum<CommonEnum.MZ>(model.TNation.ToString());
                this.ltl_Politics.Text = CommonFunction.CheckEnum<CommonEnum.ZZMM>(model.Politics.ToString());

                this.ltl_HealthStatus.Text = CommonFunction.CheckEnum<CommonEnum.HealthStatus>(model.HealthStatus.ToString());
                this.ltl_TeaState.Text = CommonFunction.CheckEnum<CommonEnum.TeaState>(model.TeaState.ToString());
                this.ltl_TSex.Text = CommonFunction.CheckEnum<CommonEnum.XB>(model.TSex.ToString());
                //this.ltl_TeaType.Text = model.TeaType.ToString(); //教职工类别
                //this.ltl_MaritalStatus.Text = model.MaritalStatus.ToString(); //婚姻状态
                //this.ltl_CardType.Text=  model.CardType.ToString(); //身份证件类型
                //this.ltl_TeaSource.Text = model.TeaSource.ToString();//教职工来源
                BaseDataEntity hs = baseDataDAL.GetList(model.TeaType);
                if (hs != null)
                {
                    this.ltl_TeaType.Text = hs.DataName; //教职工类别
                }

                BaseDataEntity tt = baseDataDAL.GetList(model.MaritalStatus);
                if (tt != null)
                {
                    this.ltl_MaritalStatus.Text = tt.DataName; //婚姻状态
                }
                BaseDataEntity ct = baseDataDAL.GetList(model.CardType);
                if (ct != null)
                {
                    this.ltl_CardType.Text = ct.DataName; //身份证件类型
                }

                BaseDataEntity ts = baseDataDAL.GetList(model.TeaSource);
                if (ts != null)
                {
                    this.ltl_TeaSource.Text = ts.DataName; //教职工来源
                }
                this.ltl_EmploymentType.Text = CommonFunction.CheckEnum<CommonEnum.EmploymentForm>(model.EmploymentType.ToString());
                this.ltl_ContractState.Text = CommonFunction.CheckEnum<CommonEnum.ContractState>(model.ContractState.ToString());
                this.ltl_InformationLevel.Text = CommonFunction.CheckEnum<CommonEnum.InformationLevel>(model.InformationLevel.ToString());
                this.ltl_Birthday.Text = model.Birthday.ToString() == "0001/1/1 0:00:00" ? "" : model.Birthday.ToString("yyyy-MM-dd");
                this.ltl_JodDate.Text = model.JodDate.ToString() == "0001/1/1 0:00:00" ? "" : model.JodDate.ToString("yyyy-MM-dd");
                this.ltl_JoinSchool.Text = model.JoinSchool.ToString() == "0001/1/1 0:00:00" ? "" : model.JoinSchool.ToString("yyyy-MM-dd");
                this.ltl_GrassStartDate.Text = model.GrassStartDate.ToString() == "0001/1/1 0:00:00" ? "" : model.GrassStartDate.ToString("yyyy-MM-dd");
                this.ltl_GrassEndDate.Text = model.GrassEndDate.ToString() == "0001/1/1 0:00:00" ? "" : model.GrassEndDate.ToString("yyyy-MM-dd");
                this.ltl_OldName.Text = model.OldName == null ? "" : model.OldName.ToString();
                this.ltl_TeacherCode.Text = model.TeacherCode == null ? "" : model.TeacherCode.ToString();
                this.ltl_Nationality.Text = model.Nationality == null ? "" : model.Nationality.ToString();
                this.ltl_IDCardNum.Text = model.IDCardNum == null ? "" : model.IDCardNum.ToString();
                this.ltl_PlaceOrigin.Text = model.PlaceOrigin == null ? "" : model.PlaceOrigin.ToString();
                this.ltl_OneNative.Text = model.OneNative == null ? "" : model.OneNative.ToString();
                this.ltl_PartyTme.Text = model.PartyTme == null ? "" : (model.PartyTme.ToString("yyyy-MM-dd") == "1900-01-01" ? "" : model.PartyTme.ToString("yyyy-MM-dd"));
                this.ltl_PostRoleName.Text = model.PostRole == null ? "" : model.PostRole.ToString();

                ////根据TID获取教师职务角色名称
                //DataTable dt1 = teacherDAL.GetRoleTable(TID);
                //if (dt1 != null && dt1.Rows.Count > 0)
                //{
                //    for (int i = 0; i < dt1.Rows.Count; i++)
                //    {
                //        Role += dt1.Rows[i]["RoleNames"].ToString() + ",";
                //    }
                //    this.ltl_PostRoleName.Text = Role.Trim(','); ;//职务角色
                //}
                //else {
                //    this.ltl_PostRoleName.Text = null;
                //}

                this.ltl_SalaryGrade.Text =  model.SalaryGrade.ToString();
                this.ltl_CurrentProfessional.Text =  CommonFunction.CheckEnum<CommonEnum.CurrentProfessional>(model.CurrentProfessional);
                this.ltl_GradeType.Text = CommonFunction.CheckEnum<CommonEnum.ProfessGradeType>(model.GradeType);
                this.ltl_ProfessGrade.Text = model.ProfessGradeName.ToString();


                //学段
               // this.ltl_Section. = model.Section.ToString();
                //string xd = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "XD");

                //if (xd.IndexOf(',') < 0)
                //{
                //    this.ltl_Section.Enabled = false;
                //}

                this.ltl_IsTea.Text = model.IsTea.ToString()=="1"?"是":"否";//是否教学岗
                this.ltl_GradeDate.Text = model.GradeDate.ToString("yyyy-MM-dd") == "0001-01-01" ? "" : model.GradeDate.ToString("yyyy-MM-dd") == "1900-01-01" ? "" : model.GradeDate.ToString("yyyy-MM-dd");//取得时间
                this.ltl_Mandarin.Text = model.Mandarin.ToString() == "-2" ? "" : CommonFunction.CheckEnum<CommonEnum.MandarinType>(model.Mandarin.ToString());//普通话水平
                this.ltl_TeaQualiType.Text = CommonFunction.CheckEnum<CommonEnum.TeaQualiType>( model.TeaQualiType.ToString());
                this.ltl_TeaQualCode.Text = model.TeaQualCode;
                this.ltl_TeaQualCourse.Text = model.TeaQualCourseName.ToString();
                this.ltl_TeaQualDate.Text = model.TeaQualDate.ToString("yyyy-MM-dd") == "0001-01-01" ? "" : model.TeaQualDate.ToString("yyyy-MM-dd") == "1900-01-01" ? "" : model.TeaQualDate.ToString("yyyy-MM-dd");
                this.ltl_TeaQualRegDate.Text = model.TeaQualRegDate.ToString("yyyy-MM-dd") == "0001-01-01" ? "" : model.TeaQualRegDate.ToString("yyyy-MM-dd") == "1900-01-01" ? "" : model.TeaQualRegDate.ToString("yyyy-MM-dd");


            }
        }
        #endregion
    }
}