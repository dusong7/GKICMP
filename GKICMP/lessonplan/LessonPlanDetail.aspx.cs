/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年10月25日 17时06分46秒
** 描    述:      备课计划详情页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using System.Data;

namespace GKICMP.lessonplan
{
    public partial class LessonPlanDetail : PageBase
    {
        public BaseDataDAL baseDataDAL = new BaseDataDAL();
        public LessonPlanDAL planDAL = new LessonPlanDAL();
        public LessonPlan_DetailDAL detailDAL = new LessonPlan_DetailDAL();


        #region 参数集合
        /// <summary>
        /// 备课计划ID
        /// </summary>
        public string LID
        {
            get
            {
                return GetQueryString<string>("lid", "");
            }
        }

        /// <summary>
        /// 备课类型 社团活动  体验课程
        /// </summary>
        public int LType
        {
            get
            {
                return GetQueryString<int>("ltype", -1);
            }
        }
        #endregion


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BaseDataEntity bmodel = baseDataDAL.GetList(LType);
                if (bmodel != null)
                {
                    if (bmodel.DataName == "社团活动")
                    {
                        this.ltl_TeacherName.Text = "指导教师";
                    }
                    else
                    {
                        this.ltl_TeacherName.Text = "执教教师";
                    }
                }
                InfoBind();
                DataBindList();
            }
        }
        #endregion


        #region 备课数据绑定
        private void InfoBind()
        {
            LessonPlanEntity model = planDAL.GetObjByID(LID);
            this.ltl_LName.Text = model.LName.ToString();
            this.ltl_LYear.Text = model.LYear.ToString();
            this.ltl_TID.Text = GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.XQ>(model.TID);
            this.ltl_CID.Text = model.CampusName;
            this.ltl_LType.Text = model.TypeName;
            this.ltl_Teacher.Text = model.TeacherName;
            this.ltl_CreateUser.Text = model.CreateUserName;
            this.ltl_CreateDate.Text = model.CreateDate.ToString("yyyy-MM-dd");
        } 
        #endregion


        #region 数据绑定
        private void DataBindList()
        {
            DataTable dt = detailDAL.GetList(LID);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.tr_null.Visible = false;
            }
            else
            {
                this.tr_null.Visible = true;
            }
            this.rp_List.DataSource = dt;
            this.rp_List.DataBind();
        }
        #endregion
    }
}