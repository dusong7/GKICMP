/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年10月28日 11时24分01秒
** 描    述:      报销详情页面
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
    public partial class InvoiceDetail : PageBase
    {
        public InvoiceDAL invoiceDAL = new InvoiceDAL();
        public Invoice_InfoDAL infoDAL = new Invoice_InfoDAL();
        public AccessoryDAL accessoryDAL = new AccessoryDAL();
        public LeaveAuditDAL auditDAL = new LeaveAuditDAL();


        #region　参数集合
        /// <summary>
        /// 报销ID
        /// </summary>
        public string IID
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
                InfoBind();
                AuditInfoBind();
            }
        }
        #endregion


        #region 初始化用户数据
        private void InfoBind()
        {
            InvoiceEntity model = invoiceDAL.GetObjByID(IID);
            if (model != null)
            {
                this.ltl_AccountUnit.Text = model.AccountUnit.ToString();
                this.ltl_CreateDate.Text = model.CreateDate.ToString("yyyy-MM-dd");
                this.ltl_AduitUser.Text = model.AduitUser.ToString();
                this.ltl_InvoiceDesc.Text = model.InvoiceDesc.ToString();
                this.ltl_InvModel.Text = model.ModelName.ToString();
                this.ltl_InvType.Text = model.TypeName.ToString();
                this.ltl_IsSign.Text = model.IsSign == 1 ? "是" : "否";
                this.ltl_TotelCash.Text = model.TotelCash.ToString();
                DataBindList();
                AccessBind(rp_File, IID, (int)CommonEnum.AccessoryType.报销附件);
            }
        }
        #endregion


        #region 附件下载、删除
        /// <summary>
        /// 附件下载、删除
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void rpaccess_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string accessid = e.CommandArgument.ToString().Trim();
            AccessoryEntity attainfo = accessoryDAL.GetObjByID(accessid);
            string path = attainfo.AccessUrl;

            if (!CommonFunction.UpLoadFunciotn(attainfo.AccessUrl, attainfo.AccessName))
            {
                ShowMessage("下载文件不存在，请联系系统管理员！");
                return;
            }
        }
        #endregion


        #region 绑定报销详情数据
        private void DataBindList()
        {
            DataTable dt = infoDAL.GetDataByIID(IID);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.tr_null1.Visible = false;
            }
            else
            {
                this.tr_null1.Visible = true;
            }
            rp_List1.DataSource = dt;
            rp_List1.DataBind();
        }
        #endregion


        #region 附件绑定
        /// <summary>
        /// 附件绑定
        /// </summary>
        /// <param name="rpcontr"></param>
        /// <param name="objid"></param>
        /// <param name="flag"></param>
        public void AccessBind(Repeater rpcontr, string objid, int flag)
        {
            DataTable ds = accessoryDAL.GetList(flag, objid);
            rpcontr.DataSource = ds;
            rpcontr.DataBind();
        }
        #endregion


        #region 绑定审核信息
        private void AuditInfoBind()
        {
            DataTable dt = auditDAL.GetList(IID);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.tr_null.Visible = false;
            }
            else
            {
                this.tr_null.Visible = true;
            }
            this.rp_List.DataSource = dt;
            this.rp_List.DataBind();
        } 
        #endregion
    }
}