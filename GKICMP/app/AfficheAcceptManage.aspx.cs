/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      殷志瑞
** 创建日期:    2017年06月03日
** 描 述:       通知公告页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using GK.GKICMP.DAL;
using System.Data;
using System.Web.UI.WebControls;

namespace GKICMP.app
{
    public partial class AfficheAcceptManage : PageBaseApp
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public AfficheDAL afficheDAL = new AfficheDAL();
        public SysDataDAL sysDataDAL = new SysDataDAL();


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //DataTable dt = sysDataDAL.GetList((int)CommonEnum.IsorNot.否, (int)CommonEnum.DataType.通知公告);
                //GetCondition();
                //DataBindList();
            }
        }
        #endregion


        #region 获取查询条件
        public void GetCondition()
        {
            //ViewState["AfficheTitle"] = CommonFunction.GetCommoneString(this.txt_Name.Text.Trim());
            //ViewState["AType"] = -2;
            //ViewState["IsRead"] = -2;
            //ViewState["begin"] = "1900-01-01";
            //ViewState["end"] = "9999-12-31";
        }
        #endregion


        #region 数据绑定
        public void DataBindList()
        {
            //int recordCount = 0;
            //AfficheEntity model = new AfficheEntity();
            //model.AfficheTitle = ViewState["AfficheTitle"].ToString();
            //model.AType = Convert.ToInt32(ViewState["AType"].ToString());
            //model.IsRead = Convert.ToInt32(ViewState["IsRead"].ToString());
            //DateTime begin = Convert.ToDateTime(ViewState["begin"].ToString());
            //DateTime end = Convert.ToDateTime(ViewState["end"].ToString());
            //DataTable dt = afficheDAL.GetPaged(PagerAPP.PageSize, PagerAPP.CurrentPageIndex, ref recordCount, model, begin, end, 2, UserID);
            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    this.ul_null.Visible = false;
            //}
            //else
            //{
            //    this.ul_null.Visible = true;
            //}
            //rp_List.DataSource = dt;
            //PagerAPP.RecordCount = recordCount;
            //rp_List.DataBind();
        }
        #endregion


        #region 查询
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            
            //PagerAPP.CurrentPageIndex = 1;
            //GetCondition();
            //DataBindList();
        }
        #endregion


        #region 分页
        public void Pager_PageChanged(object sender, EventArgs e)
        {
            DataBindList();
        }
        #endregion
    }
}