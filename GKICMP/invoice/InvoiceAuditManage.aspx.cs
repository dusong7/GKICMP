/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年10月30日 9时13分01秒
** 描    述:      报销审核管理页面
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
    public partial class InvoiceAuditManage : PageBase
    {
        public InvoiceDAL invoiceDAL = new InvoiceDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SysDataDAL sysDataDAL = new SysDataDAL();

        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dtModel = sysDataDAL.GetList((int)CommonEnum.Deleted.未删除, (int)CommonEnum.DataType.报销方式);
                DataTable dtType = sysDataDAL.GetList((int)CommonEnum.Deleted.未删除, (int)CommonEnum.DataType.报销分类);
                CommonFunction.DDlTypeBind(this.ddl_InvType, dtType, "SDID", "DataName", "-2");//报销分类
                CommonFunction.DDlTypeBind(this.ddl_InvModel, dtModel, "SDID", "DataName", "-2");//报销方式
                GetCondition();
                DataBindList();
            }
        }
        #endregion


        #region 获取查询条件
        private void GetCondition()
        {
            ViewState["InvType"] = this.ddl_InvType.SelectedValue.ToString();
            ViewState["InvModel"] = this.ddl_InvModel.SelectedValue.ToString();
            ViewState["BeginDate"] = this.txt_Begin.Text == "" ? "1900-01-01" : this.txt_Begin.Text.ToString().Trim();
            ViewState["EndDate"] = this.txt_End.Text == "" ? "9999-12-31" : this.txt_End.Text.ToString().Trim();
            ViewState["UserName"] = CommonFunction.GetCommoneString(this.txt_CreateUser.Text.ToString().Trim());
        }
        #endregion


        #region 数据绑定
        private void DataBindList()
        {
            int recordCount = -1;
            InvoiceEntity model = new InvoiceEntity(Convert.ToInt32(ViewState["InvType"].ToString()), Convert.ToInt32(ViewState["InvModel"].ToString()), (int)CommonEnum.Deleted.未删除);
            DataTable dt = invoiceDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model, Convert.ToDateTime(ViewState["BeginDate"].ToString()), Convert.ToDateTime(ViewState["EndDate"].ToString()), 1, (string)ViewState["UserName"]);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.tr_null.Visible = false;
            }
            else
            {
                this.tr_null.Visible = true;
            }
            this.rp_List.DataSource = dt;
            Pager.RecordCount = recordCount;
            this.rp_List.DataBind();
            this.hf_CheckIDS.Value = "";
        }
        #endregion


        #region 查询事件
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            Pager.CurrentPageIndex = 1;
            GetCondition();
            DataBindList();
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