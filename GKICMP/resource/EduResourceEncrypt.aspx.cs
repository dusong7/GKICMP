/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      lfz
** 创建日期:    2017年5月25日
** 描 述:       新闻栏目编辑页面
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

using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using System.Configuration;
using System.Data;
using GK.GKICMP.DAL;


namespace GKICMP.resource
{
    public partial class EduResourceEncrypt : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public EduResourceDAL eduResourceDAL = new EduResourceDAL();
        #region 参数集合
        public int Erid
        {
            get
            {
                return GetQueryString<int>("id", 0);
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            
            int result = eduResourceDAL.AddEncrypt(Erid,this.txt_ERPwd.Text==""?"": CommonFunction.Encrypt(this.txt_ERPwd.Text));
            if (result > 0)
            {
                ShowMessage();
            }
            else 
            {
                ShowMessage("提交失败");
                return;
            }
        }
    }
}