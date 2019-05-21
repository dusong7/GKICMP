/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      gxl
** 创建日期:    2017年08月15日 08时30分
** 描 述:       缴费项目管理页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;

namespace GKICMP.payment
{
    public partial class PayRegistrationDetail : PageBase
    {
        public PayRegistrationDAL payRegistrationDAL = new PayRegistrationDAL();

        #region 参数集合
        public string PRID
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
                if (PRID != "")
                {
                    InfoBind();
                }
            }
        }
        #endregion

        #region 初始化用户数据
        /// <summary>
        /// 初始化用户数据
        /// </summary>
        private void InfoBind()
        {
            PayRegistrationEntity model = payRegistrationDAL.GetObjByID(PRID);
            if (model != null)
            {
                this.ltl_StuName.Text = model.StuName; ;
                this.ltl_PIID.Text = model.PName.ToString();
                this.ltl_RegCount.Text = Convert.ToString(model.RegCount);
                this.ltl_RegDate.Text = model.RegDate.ToString("yyyy-MM-dd");


            }
        }
        #endregion

    }
}