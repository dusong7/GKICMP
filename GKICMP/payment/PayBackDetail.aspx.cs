/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      殷志瑞
** 创建日期:    2017年08月15日 08时30分
** 描 述:       退费管理详细页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GKICMP.payment
{
    public partial class PayBackDetail : PageBase
    {
        public PayRegistrationDAL payRegistartionDAL = new PayRegistrationDAL();
        public PayBackDAL payBackDAL = new PayBackDAL();


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
                    PayRegistrationEntity model = payRegistartionDAL.GetObjByID(PRID);
                    if (model != null)
                    {
                        this.ltl_StuName.Text = model.StuName; ;
                        this.ltl_PIID.Text = model.PName.ToString();
                        this.ltl_RegCount.Text = Convert.ToString(model.RegCount);
                        this.ltl_RegDate.Text = model.RegDate.ToString("yyyy-MM-dd");
                        DataTable dt = payBackDAL.GetTable(PRID, model.StID);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            this.tr_null.Visible = false;
                        }
                        else
                        {
                            this.tr_null.Visible = true;
                        }
                        rp_List.DataSource = dt;
                        rp_List.DataBind();
                    }
                }
            }
        }
        #endregion
    }
}