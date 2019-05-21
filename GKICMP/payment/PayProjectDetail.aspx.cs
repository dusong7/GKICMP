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
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GKICMP.payment
{
    public partial class PayProjectDetail : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public PayProjectDAL payProjectDAL = new PayProjectDAL();
        public PayItemDAL payItemDAL = new PayItemDAL();
        public PayProject_ItemDAL payProject_ItemDAL = new PayProject_ItemDAL();


        #region 参数集合
        public string PPID
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
                if (PPID != "")
                {
                    BindInfo();
                }
            }
        }
        #endregion


        #region 初始化用户数据
        public void BindInfo()
        {
            PayProjectEntity model = payProjectDAL.GetObjByID(PPID);
            if (model != null)
            {

                this.ltl_PayCount.Text = model.PayCount.ToString();
                this.ltl_ProjectName.Text = model.ProjectName;

                //缴费项绑定
                DataTable pmodel = payProject_ItemDAL.GetByPPID(PPID);
                if (pmodel != null && pmodel.Rows.Count > 0)
                {
                    this.tr_null.Visible = false;
                }
                else
                {
                    this.tr_null.Visible = true;
                }
                rp_List.DataSource = pmodel;
                rp_List.DataBind();

            }

        }
        #endregion



    }
}