/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年10月26日 14时48分46秒
** 描    述:      备课综合查询页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Data;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;


namespace GKICMP.lessonplan
{
    public partial class LessonComprehensive : PageBase
    {
        public LessonPlan_DetailDAL detailDAL = new LessonPlan_DetailDAL();
        public BaseDataDAL baseDataDAL = new BaseDataDAL();
        public SysSetConfigDAL configDAL = new SysSetConfigDAL();

        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dtType = baseDataDAL.GetList((int)CommonEnum.BaseDataType.备课类型, -1);
                CommonFunction.DDlTypeBind(this.ddl_LType, dtType, "SDID", "DataName", "-2");

                CommonFunction.BindEnum<CommonEnum.XQ>(this.ddl_TID, "-2");

                SysSetConfigEntity smodel = configDAL.GetObjByID();
                if (smodel != null)
                {
                    this.txt_LYear.Text = smodel.EYear;
                    this.ddl_TID.SelectedValue = smodel.NowTerm.ToString();
                }
                GetCondition();
                DataBindList();
            }
        }
        #endregion


        #region 获取查询条件
        private void GetCondition()
        {
            ViewState["LName"] = CommonFunction.GetCommoneString(this.txt_LName.Text.ToString().Trim());
            ViewState["LType"] = this.ddl_LType.SelectedValue.ToString();
            ViewState["AContent"] = CommonFunction.GetCommoneString(this.txt_AContent.Text.ToString().Trim());
            ViewState["LYear"] = CommonFunction.GetCommoneString(this.txt_LYear.Text.ToString().Trim());
            ViewState["TID"] = this.ddl_TID.SelectedValue.ToString();
        }
        #endregion


        #region 数据绑定
        private void DataBindList()
        {
            int recordCount = -1;
            DataTable dt = detailDAL.GetSerachPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, (string)ViewState["LName"], (string)ViewState["AContent"], Convert.ToInt32(ViewState["LType"].ToString()), (string)ViewState["LYear"], Convert.ToInt32(ViewState["TID"].ToString()));
            if (dt != null && dt.Rows.Count > 0)
            {
                this.tr_null.Visible = false;
            }
            else
            {
                this.tr_null.Visible = true;
            }
            this.rp_List.DataSource = dt;
            Pager.RecordCount = recordCount;
            this.rp_List.DataBind();
        }
        #endregion


        #region 查询事件
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            Pager.CurrentPageIndex = 1;
            GetCondition();
            DataBindList();
        }
        #endregion


        #region 分页事件
        protected void Pager_PageChanged(object sender, EventArgs e)
        {
            DataBindList();
        }
        #endregion
    }
}