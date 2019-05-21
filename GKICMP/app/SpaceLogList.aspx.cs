/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年11月4日 17时31分12秒
** 描    述:      学生活动管理
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.app
{
    public partial class SpaceLogList : PageBaseApp
    {
        public StudentActivityDAL actDAL = new StudentActivityDAL();

        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //ViewState["ActName"] = CommonFunction.GetCommoneString(this.txt_Name.Text.ToString());
                //DataBindList();
            }
        }
        #endregion


        #region 数据绑定
        public void DataBindList()
        {
            //int recordCount = -1;
            //StudentActivityEntity model = new StudentActivityEntity();
            //model.Isdel = (int)CommonEnum.Deleted.未删除;
            //model.ActName = (string)ViewState["ActName"];
            //model.ActType = -2;

            //DataTable dt = actDAL.GetPaged(PagerAPP.PageSize, PagerAPP.CurrentPageIndex, ref recordCount, model, Convert.ToDateTime("1900-01-01"), Convert.ToDateTime("9999-12-31"));
            //if (dt != null && dt.Rows.Count > 0)
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
        protected void lbtn_Search_Click(object sender, EventArgs e)
        {
            //PagerAPP.CurrentPageIndex = 1;
            //ViewState["ActName"] = CommonFunction.GetCommoneString(this.txt_Name.Text.ToString());
            //DataBindList();
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