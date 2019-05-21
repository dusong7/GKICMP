/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      yzr
** 创建日期:     2017年06月16日
** 描 述:       司机列表页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Data;
using System.Web.UI.WebControls;

namespace GKICMP.vehicle
{
    public partial class DriverManage : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public DriverDAL driverDAL = new DriverDAL();


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonFunction.BindEnum<CommonEnum.Vtype>(this.ddl_SType, "-2");
                GetCondition();
                DataBindList();
            }
        }
        #endregion


        #region 获取查询条件
        public void GetCondition()
        {
            ViewState["CellPhone"] = CommonFunction.GetCommoneString(this.txt_CellPhone.Text.Trim());
            ViewState["DriverCode"] = CommonFunction.GetCommoneString(this.txt_DriverCode.Text.Trim());
            ViewState["RealName"] = CommonFunction.GetCommoneString(this.txt_RealName.Text.Trim());
            ViewState["SType"] = this.ddl_SType.SelectedValue;
        }
        #endregion


        #region 数据绑定
        public void DataBindList()
        {
            int recordCount = 0;
            DriverEntity model = new DriverEntity();
            model.DriverCode = ViewState["DriverCode"].ToString();
            model.CellPhone = ViewState["CellPhone"].ToString();
            model.RealName = ViewState["RealName"].ToString();
            model.SType = Convert.ToInt32(ViewState["SType"].ToString());
            DataTable dt = driverDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.tr_null.Visible = false;
            }
            else
            {
                this.tr_null.Visible = true;
            }
            rp_List.DataSource = dt;
            Pager.RecordCount = recordCount;
            rp_List.DataBind();
        }
        #endregion


        #region 查询
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            Pager.CurrentPageIndex = 1;
            GetCondition();
            DataBindList();
        }
        #endregion


        #region 分页
        public void Pager_PageChanged(object sender, EventArgs e)
        {
            DataBindList();
        }
        #endregion


        #region 删除
        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                string ids = this.hf_CheckIDS.Value.TrimEnd(',');
                int result = driverDAL.DeleteByID(ids);
                if (result > 0)
                {
                    ShowMessage("删除成功");
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除司机信息", UserID));
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
                ShowMessage(ex.Message);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
            }
        }
        #endregion  
       
    }
}