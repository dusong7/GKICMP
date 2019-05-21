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
    public partial class TeacherAssessmentDetail : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public Teacher_AssessmentDAL teacherAssessment = new Teacher_AssessmentDAL();
        public BaseDataDAL baseDataDAL = new BaseDataDAL();


        #region 参数集合
        /// <summary>
        /// TAID
        /// </summary>
        public string TAID
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
            Teacher_AssessmentEntity tmodel = teacherAssessment.GetObjByID(TAID);
            if (tmodel != null)
            {
                this.ltl_TID.Text = tmodel.TName;
                //this.ltl_TID.Text = tmodel.TID == null ? "" : tmodel.TID.ToString();
                this.ltl_TSYear.Text = tmodel.TSYear.ToString() == "1990/1/1 0:00:00" ? "" : tmodel.TSYear.ToString("yyyy");

                //BaseDataEntity ec = baseDataDAL.GetList(tmodel.AssResult);
                //if (ec != null)
                //{
                //    this.ltl_AssResult.Text = ec.DataName; //考核结果
                //}
                this.ltl_AssResult.Text = CommonFunction.CheckEnum<CommonEnum.KHJG>(tmodel.AssResult.ToString());

                //this.ltl_AduitState.Text = CommonFunction.CheckEnum<CommonEnum.AduitState>(tmodel.AduitState.ToString());

                this.ltl_TSDesc.Text = tmodel.TSDesc.ToString();//备注
                

                

            }
        }
        #endregion

    }
}