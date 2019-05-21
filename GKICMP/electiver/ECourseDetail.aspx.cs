/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      yzr
** 创建日期:    2017年02月27日
** 描 述:       选课课程详细页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using GK.GKICMP.Common;
using System;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Data;

namespace GKICMP.electiver
{
    public partial class ECourseDetail : PageBase
    {
        public ECourseDAL ecourseDAL = new ECourseDAL();

        #region 参数集合
        public int CID
        {
            get
            {
                return GetQueryString<int>("id", -1);
            }
        }
        #endregion

        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ECourseEntity model = ecourseDAL.GetObjByID(CID);
                if (model != null)
                {
                    this.ltl_CourseDesc.Text = model.CourseDesc;
                    this.ltl_CourseGrade.Text = model.CourseGradeName;
                    this.ltl_CourseType.Text = model.CourseTypeName;
                    this.ltl_CourseName.Text = model.CourseName;
                    this.ltl_CourseOther.Text = model.CourseOther;
                }
            }
        }
        #endregion
    }
}