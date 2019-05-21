/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      樊紫红
** 创建日期:    2017年11月24日 10时29分
** 描 述:       我的作业管理页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.appstu
{
    public partial class HomeWorkDetail : PageBaseApp
    {
        public HomeWorkDAL homeWorkDAL = new HomeWorkDAL();

        #region 参数集合
        public string HWID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        #endregion


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HomeWorkEntity model = homeWorkDAL.GetObjByID(HWID);
                if (model != null)
                {
                    this.lbl_CID.Text = model.CidName;
                    this.lbl_CompleteTime.Text = model.CompleteTime.ToString();
                    this.lbl_HomeWork.Text = model.HomeWork;
                    this.lbl_CreateDate.Text = model.CreateDate.ToString("yyyy-MM-dd HH:mm");
                }
            }
        } 
        #endregion
    }
}