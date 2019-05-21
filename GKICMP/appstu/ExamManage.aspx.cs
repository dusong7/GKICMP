/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      樊紫红
** 创建日期:    2018年01月03日 15点58分
** 描 述:       通知公告页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;

namespace GKICMP.appstu
{
    public partial class ExamManage : PageBaseApp
    {
        public ExamDAL examDAL = new ExamDAL();

        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //ViewState["ExamName"] = CommonFunction.GetCommoneString(this.txt_Name.Text.ToString().Trim());
            }
        }
        #endregion


        #region 数据绑定
        private void DataBindList()
        {
            //int recordCount = -1;
            //ExamEntity model = new ExamEntity();
            //model.GID = -2;
            //model.EYear = "";
            //model.Term = -2;
            //model.ExamName = ViewState["ExamName"].ToString();
            //model.BeginDate = Convert.ToDateTime("1900-01-01");
            //model.EndDate = Convert.ToDateTime("9999-12-31");
            //DataTable dt = examDAL.GetMyPaged(PagerAPP.PageSize, PagerAPP.CurrentPageIndex, ref recordCount, model, UserID);
            //if (dt.Rows.Count > 0 && dt != null)
            //{
            //    this.ul_null.Visible = false;
            //}
            //else
            //{
            //    this.ul_null.Visible = true;
            //}
            //this.rp_List.DataSource = dt;
            //PagerAPP.RecordCount = recordCount;
            //this.rp_List.DataBind();
        }
        #endregion


        #region 查询事件
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            //ViewState["ExamName"] = CommonFunction.GetCommoneString(this.txt_Name.Text.ToString().Trim());
            DataBindList();
        } 
        #endregion

        //#region 分页事件
        //protected void PagerAPP_PageChanged(object sender, EventArgs args)
        //{
        //    DataBindList();
        //} 
        //#endregion
    }
}