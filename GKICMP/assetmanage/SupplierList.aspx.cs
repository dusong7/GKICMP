/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      殷志瑞
** 创建日期:    2016年11月09日
** 描 述:       供应商列表页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;

namespace ICMP.assetmanage
{
    public partial class SupplierList : PageBase
    {
        public SupplierDAL supplierDAL = new SupplierDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();


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
                GetCondition();
                DataBindList();
            }
        }
        #endregion


        #region 获取查询条件
        /// <summary>
        /// 获取查询条件
        /// </summary>
        private void GetCondition()
        {
            ViewState["SupplierName"] = CommonFunction.GetCommoneString(this.txt_SupplierName.Text.Trim());
            ViewState["LinkUser"] = CommonFunction.GetCommoneString(this.txt_LinkUser.Text.Trim());
            ViewState["LinkPhone"] = CommonFunction.GetCommoneString(this.txt_LinkPhone.Text.Trim());
        }
        #endregion


        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        public void DataBindList()
        {
            int recordCount = 0;
            SupplierEntity model = new SupplierEntity();
            model.SupplierName = ViewState["SupplierName"].ToString();
            model.LinkUser = ViewState["LinkUser"].ToString();
            model.LinkPhone = ViewState["LinkPhone"].ToString();
            model.Isdel = (int)CommonEnum.Deleted.未删除;
            DataTable dt = supplierDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
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


        #region 删除
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            string ids = this.hf_CheckIDS.Value;
            try
            {
                ids = ids.TrimEnd(',').TrimStart(',');
                int istrue = supplierDAL.DeleteBat(ids, (int)CommonEnum.Deleted.删除);
                if (istrue > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除供应商信息", UserID));
                    ShowMessage();
                }
                else
                {
                    ShowMessage("删除失败");
                    return;
                }
                DataBindList();
                this.hf_CheckIDS.Value = "";
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                ShowMessage(ex.Message);
            }
        }
        #endregion


        #region 查询
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            Pager.CurrentPageIndex = 1;
            GetCondition();
            DataBindList();
        }
        #endregion


        #region 分页
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>  
        protected void Pager_PageChanged(object sender, EventArgs e)
        {
            DataBindList();
        }
        #endregion
    }
}