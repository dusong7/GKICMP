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
    public partial class EducationDetail : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public TeacherEducationDAL teacherEducation = new TeacherEducationDAL();
        public BaseDataDAL baseDataDAL = new BaseDataDAL();
        public TeacherDAL teacherDAL = new TeacherDAL();

        #region 参数集合
        /// <summary>
        /// TID 用户ID ==教师ID
        /// </summary>
        public string TEID
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


        #region 初始化用户数据
        /// <summary>
        /// 初始化用户数据
        /// </summary>
        private void InfoBind()
        {
            Teacher_EducationEntity tmodel = teacherEducation.GetObjByID(TEID);
            if (tmodel != null)
            {
                this.ltl_Education.Text = CommonFunction.CheckEnum<CommonEnum.XL>(tmodel.Education.ToString());
                this.ltl_IsTeach.Text = tmodel.IsTeach.ToString() == "-2" ? "" : CommonFunction.CheckEnum<CommonEnum.IsorNot>(tmodel.IsTeach.ToString());

                this.ltl_DegreeLevel.Text = tmodel.DegreeLevel.ToString() == "-2" ? "" : CommonFunction.CheckEnum<CommonEnum.XWCC>(tmodel.DegreeLevel.ToString());
                this.ltl_DegreeName.Text = tmodel.DegreeName.ToString() == "-2" ? "" : CommonFunction.CheckEnum<CommonEnum.XWLB>(tmodel.DegreeName.ToString());
                this.ltl_StudyType.Text = tmodel.StudyType.ToString() == "-2" ? "" : CommonFunction.CheckEnum<CommonEnum.XXFS>(tmodel.StudyType.ToString());


                BaseDataEntity ec = baseDataDAL.GetList(tmodel.EduCountry);
                if (ec != null)
                {
                    this.ltl_EduCountry.Text = ec.DataName; //国家
                }

                BaseDataEntity gc = baseDataDAL.GetList(tmodel.GradeCountry);
                if (gc != null)
                {
                    this.ltl_GradeCountry.Text = gc.DataName; //国家
                }

                BaseDataEntity ct = baseDataDAL.GetList(tmodel.CompanyType);
                if (ct != null)
                {
                    this.ltl_CompanyType.Text = ct.DataName; //在学单位类别
                }



                this.ltl_InDate.Text = tmodel.InDate.ToString("yyyy-MM-dd") == "1900-01-01" ? "" : tmodel.InDate.ToString("yyyy-MM");
                this.ltl_OutDate.Text = tmodel.OutDate.ToString("yyyy-MM-dd") == "1900-01-01" ? "" : tmodel.OutDate.ToString("yyyy-MM");
                this.ltl_GrantDate.Text = tmodel.GrantDate.ToString("yyyy-MM-dd") == "1900-01-01" ? "" : tmodel.GrantDate.ToString("yyyy-MM");

                this.ltl_EduSchool.Text = tmodel.EduSchool == null ? "" : tmodel.EduSchool.ToString();
                this.ltl_EMajor.Text = tmodel.EMajor == null ? "" : tmodel.EMajor.ToString();
                this.ltl_GradeSchool.Text = tmodel.GradeSchool == null ? "" : tmodel.GradeSchool.ToString();

                TeacherEntity model = teacherDAL.GetObjByID(tmodel.TID);
                if (model != null)
                {
                    this.ltl_RealName.Text = model.RealName.ToString();
                    this.ltl_TSex.Text = CommonFunction.CheckEnum<CommonEnum.XB>(model.TSex.ToString());

                }

            }
        }
        #endregion



    }
}