/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2016年10月15日 13时56分24秒
** 描    述:      奖励管理界面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
******************************************************************/
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace GKICMP.studentmanage
{
    public partial class StuPhysicalDetail : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public TeacherDAL teacherDAL = new TeacherDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public BaseDataDAL baseDataDAL = new BaseDataDAL();
        public Teacher_RewardDAL teacher_RewardDAL = new Teacher_RewardDAL();
        public Stu_PhysicalDAL stu_PhysicalDAL = new Stu_PhysicalDAL();
     
        #region 参数集合
        /// <summary>
        /// 参数集合
        /// </summary>
        public string SPID
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
                if (SPID != "")
                {
                    InfoBind();
                }
            }
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
                this.ltl_StuName.Text = model.RealName; ;
                this.ltl_EYear.Text = model.EYear.ToString();
                this.ltl_Term.Text = CommonFunction.CheckEnum<CommonEnum.XQ>(model.Term.ToString());
                this.ltl_DentalCaries.Text = CommonFunction.CheckEnum<CommonEnum.IsorNot>(model.DentalCaries.ToString());
                this.ltl_StuWeight.Text = Convert.ToString(model.StuWeight);
                this.ltl_StuHeight.Text = Convert.ToString(model.StuHeight);
                this.ltl_Bust.Text = Convert.ToString(model.Bust);
                this.ltl_Vitalcapacity.Text = Convert.ToString(model.Vitalcapacity);
                this.ltl_LVision.Text = Convert.ToString(model.LVision);
                this.ltl_RVision.Text = Convert.ToString(model.RVision);
                this.ltl_Lhearing.Text = Convert.ToString(model.Lhearing);
                this.ltl_Rhearing.Text = Convert.ToString(model.Rhearing);

               

            }
        }
        #endregion
    }
}