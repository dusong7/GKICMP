/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年10月27日 16时20分58秒
** 描    述:      报销详情编辑
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;

namespace GKICMP.invoice
{
    public partial class InvoiceInfoEdit : PageBase
    {
        public Invoice_InfoDAL infoDAL = new Invoice_InfoDAL();

        #region 参数集合
        /// <summary>
        /// 报销ID
        /// </summary>
        public string IID
        {
            get
            {
                return GetQueryString<string>("iid", "");
            }
        }
        #endregion


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
                this.hf_IID.Value = IID.ToString();
                this.txt_INum.Text = infoDAL.GetMaxINum(IID).ToString();
            }
        } 
        #endregion
    }
}