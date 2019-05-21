/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2016年10月15日 13时56分24秒
** 描    述:      教师学习培训管理
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
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GKICMP.teachermanage
{
       

    public partial class TeacherLearnDetail : PageBase
    {
        public Teacher_TrainDAL teacher_TrainDAL = new Teacher_TrainDAL();
        public SysDataDAL SysDataDAL = new SysDataDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public TeacherDAL teacherDAL = new TeacherDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public BaseDataDAL baseDataDAL = new BaseDataDAL();

        #region 参数集合
        /// <summary>
        /// 参数集合
        /// </summary>
        public string TTID
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
                if (TTID != "")
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

            Teacher_TrainEntity model = teacher_TrainDAL.GetObjByID(TTID);
            if (model != null)
            {
                this.ltl_TeacherName.Text = model.RealName.ToString();

                TeacherEntity tmodel = teacherDAL.GetObjByID(model.TID);
                //this.ltl_DepName.Text = ""; 
                this.ltl_TSex.Text = tmodel.TSex.ToString() == "1" ? "男" : "女";
                this.ltl_CardNO.Text = tmodel.IDCardNum.ToString();

                this.ltl_Year.Text = model.TYear.ToString();
                this.ltl_THours.Text = model.THours.ToString();
                this.ltl_TStartDate.Text = Convert.ToDateTime(model.TStartDate).ToString("yyyy-MM-dd");
                this.ltl_TEndDate.Text = Convert.ToDateTime(model.TEndDate).ToString("yyyy-MM-dd");

                this.ltl_TrainAddress.Text = model.TrainAddress.ToString();
                this.ltl_TType.Text = model.TTypeName.ToString();
                this.ltl_TrainContent.Text = model.TrainContent.ToString();
                this.ltl_TDesc.Text = model.TDesc.ToString();

               
                
              
            }
        }
        #endregion
    }
}