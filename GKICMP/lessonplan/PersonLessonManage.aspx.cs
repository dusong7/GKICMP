/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年10月26日 10时10分46秒
** 描    述:      我的备课页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Data;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.lessonplan
{
    public partial class PersonLessonManage : PageBase
    {
        public LessonPlan_DetailDAL detailDAL = new LessonPlan_DetailDAL();
        public BaseDataDAL baseDataDAL = new BaseDataDAL();

        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dtType = baseDataDAL.GetList((int)CommonEnum.BaseDataType.备课类型, -1);
                CommonFunction.DDlTypeBind(this.ddl_LType, dtType, "SDID", "DataName", "-2");
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
        }
        #endregion


        #region 数据绑定
        private void DataBindList()
        {
            int recordCount = -1;
            DataTable dt = detailDAL.GetPersonPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, (string)ViewState["LName"], (string)ViewState["AContent"], Convert.ToInt32(ViewState["LType"].ToString()), UserID);
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


        #region 备课事件
        protected void lbtn_Bill_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            string ispre = lbtn.CommandName.ToString();

            string param = lbtn.CommandArgument.ToString();
            string[] paramstr = param.Split(',');

            Response.Write("<script language=javascript>window.open('LessonEdit.aspx?ldid=" + paramstr[0].ToString() + "&lid=" + paramstr[1].ToString() + "&ltype=" + paramstr[2].ToString() + "&isprepare=" + ispre + "&flag=2" + "', '_self')</script>");
        }
        #endregion
    }
}