/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年10月30日 11时14分01秒
** 描    述:      报销归档编辑页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.invoice
{
    public partial class InvoiceFileEdit : PageBase
    {
        public InvoiceDAL invoiceDAL = new InvoiceDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SysDataDAL sysDataDAL = new SysDataDAL();

        #region 参数集合
        /// <summary>
        /// 报销ID集合
        /// </summary>
        public string IIDS
        {
            get
            {
                return GetQueryString<string>("iids", "");
            }
        }
        #endregion


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dtType = sysDataDAL.GetList((int)CommonEnum.Deleted.未删除, (int)CommonEnum.DataType.报销分类);
                CommonFunction.DDlTypeBind(this.ddl_InvType, dtType, "SDID", "DataName", "-2");//报销分类
            }
        }
        #endregion


        #region 提交事件
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                int result = invoiceDAL.Update(IIDS, Convert.ToInt32(this.ddl_InvType.SelectedValue.ToString()));
                if (result > 0)
                {
                    ShowMessage();
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "归档报销信息", UserID));
                }
                else
                {
                    ShowMessage("提交失败");
                    return;
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                return;
            }
        }
        #endregion
    }
}