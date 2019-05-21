/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:       樊紫红
** 创建日期:     2017年11月28日 10：28
** 描 述:        活动专题详细页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
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

namespace GKICMP.schoolwork
{
    public partial class StudentActTheme : PageBase
    {
        public StudentActivityDAL studentActivityDAL = new StudentActivityDAL();
        public SpaceLogDAL logDAL = new SpaceLogDAL();

        #region 参数集合
        /// <summary>
        /// 活动ID
        /// </summary>
        public string SAID
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
                StudentActivityEntity model = studentActivityDAL.GetObjByID(SAID);
                if (model != null)
                {
                    this.ltl_ActName.Text = model.ActName;
                    this.ltl_ABegin.Text = model.ABegin == null ? "" : model.ABegin.ToString("yyyy-MM-dd");
                    this.ltl_AEnd.Text = model.AEnd == null ? "" : model.AEnd.ToString("yyyy-MM-dd");
                    this.ltl_ActUserName.Text = model.ActUsersName;
                    this.ltl_ActContent.Text = model.ActContent;
                    this.img_LogoUrl.ImageUrl = model.LogoUrl == null ? "" : model.LogoUrl;
                }
                DataBindList();
            }
        }
        #endregion


        #region 绑定活动日志
        private void DataBindList()
        {
            DataTable dt = logDAL.GetList(SAID, 2);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.rp_List.DataSource = dt;
                this.rp_List.DataBind();
            }
        } 
        #endregion
    }
}