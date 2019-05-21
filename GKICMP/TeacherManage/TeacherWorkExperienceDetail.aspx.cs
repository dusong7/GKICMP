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
    public partial class TeacherWorkExperienceDetail : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public TeacherEducationDAL teacherEducation = new TeacherEducationDAL();
        public BaseDataDAL baseDataDAL = new BaseDataDAL();
        public Teacher_WorkExperienceDAL teachworkExperient = new Teacher_WorkExperienceDAL();
        public TeacherDAL teacherDAL = new TeacherDAL();

        #region 参数集合
        /// <summary>
        /// TWEID
        /// </summary>
        public string TWEID
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
            Teacher_WorkExperienceEntity tmodel = teachworkExperient.GetObjByID(TWEID);
            if (tmodel != null)
            {
                BaseDataEntity ec = baseDataDAL.GetList(tmodel.TType);
                if (ec != null)
                {
                    this.ltl_TType.Text = ec.DataName; //
                }
                //this.ltl_TType.Text = tmodel.TType.ToString();
                this.ltl_TStartDate.Text = tmodel.TStartDate.ToString() == "1990/1/1 0:00:00" ? "" : tmodel.TStartDate.ToString("yyyy-MM-dd");
                this.ltl_TEndDate.Text = tmodel.TEndDate.ToString() == "1990/1/1 0:00:00" ? "" : tmodel.TEndDate.ToString("yyyy-MM-dd");
                this.ltl_TrainContent.Text = tmodel.TrainContent == null ? "" : tmodel.TrainContent.ToString();
                this.ltl_TrainAddress.Text = tmodel.TrainAddress == null ? "" : tmodel.TrainAddress.ToString();

                TeacherEntity model = teacherDAL.GetObjByID(tmodel.TID);
                if (model != null)
                {
                    this.ltl_RealName.Text = model.RealName.ToString();
                    this.ltl_IDCardNum.Text = model.IDCardNum.ToString();
                    this.ltl_TSex.Text = CommonFunction.CheckEnum<CommonEnum.XB>(model.TSex.ToString());

                }
            }
        }
        #endregion
    }
}