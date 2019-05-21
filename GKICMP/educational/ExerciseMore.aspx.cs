/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年08月11日 13时55分15秒
** 描    述:      题目选择管理页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;

using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using GK.GKICMP.DAL;
using System.Data;
using System.Web.UI.WebControls;

namespace GKICMP.educational
{
    public partial class ExerciseMore : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public ExerciseDAL exerciseDAL = new ExerciseDAL();
        public CourseDAL courseDAL = new CourseDAL();


        #region 参数集合
        public int NJ
        {
            get
            {
                return GetQueryString<int>("nj", -1);
            }
        }
        public int XQ
        {
            get
            {
                return GetQueryString<int>("xq", -1);
            }
        }
        public int KC
        {
            get
            {
                return GetQueryString<int>("kc", -1);
            }
        }
        #endregion


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonFunction.BindEnum<CommonEnum.ExerciseType>(this.ddl_EType, "-2");
                CommonFunction.BindEnum<CommonEnum.DifficultyType>(this.ddl_Difficulty, "-2");
                GetCondition();
                DataBindList();
            }
        }
        #endregion


        #region 获取查询条件
        public void GetCondition()
        {
            ViewState["Difficulty"] = this.ddl_Difficulty.SelectedValue;
            ViewState["EType"] = this.ddl_EType.SelectedValue;
        }
        #endregion


        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        public void DataBindList()
        {
            int recordCount = 0;
            ExerciseEntity model = new ExerciseEntity();
            model.CID = KC;
            model.Difficulty = Convert.ToInt32(ViewState["Difficulty"].ToString());
            model.EType = Convert.ToInt32(ViewState["EType"].ToString());
            model.GradeID = NJ;
            model.Term = XQ;
            model.Isdel = (int)CommonEnum.IsorNot.否;
            DataTable dt = exerciseDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.tr_null.Visible = false;
            }
            else
            {
                this.tr_null.Visible = true;
            }
            rp_List.DataSource = dt;
            Pager.RecordCount = recordCount;
            rp_List.DataBind();
        }
        #endregion

        #region 分页事件
        /// <summary>
        /// 分页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Pager_PageChanged(object sender, EventArgs e)
        {
            DataBindList();
        }
        #endregion
        
        #region 查询
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            Pager.CurrentPageIndex = 1;
            GetCondition();
            DataBindList();
        }
        #endregion
    }
}