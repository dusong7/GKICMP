/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      殷志瑞
** 创建日期:    2017年3月14日 13:51
** 描 述:       资源平台管理页面
** 修改人:      樊紫红
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using GK.GKICMP.Common;
using GK.GKICMP.DAL;

using System;
using System.Data;

namespace GKICMP.resourcesite
{
    public partial class Res_Left : PageBase
    {
        public EduResourceDAL eduResourceDAL = new EduResourceDAL();


        #region 页面初始化
        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataBindListByZy();
            }
        }
        #endregion


        #region 最新资源绑定
        public void DataBindListByZy()
        {
            DataTable dt = eduResourceDAL.GetPagedZyptByFlag(1);//1 精品资源
            if (dt != null && dt.Rows.Count > 0)
            {
                this.tr_null2.Visible = false;
            }
            else
            {
                this.tr_null2.Visible = true;
            }
            this.rp_jpList.DataSource = dt;
            this.rp_jpList.DataBind();

            DataTable dt1 = eduResourceDAL.GetPagedZyptByFlag(2);//最新资源
            if (dt != null && dt.Rows.Count > 0)
            {
                this.tr_null1.Visible = false;
            }
            else
            {
                this.tr_null1.Visible = true;
            }
            this.rp_zxList.DataSource = dt1;
            this.rp_zxList.DataBind();

        }
        #endregion
    }
}