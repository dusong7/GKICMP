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
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.payment
{
    public partial class PayRegistrationManage : PageBase
    {

        public SysLogDAL sysLogDAL = new SysLogDAL();
        public PayItemDAL payItemDAL = new PayItemDAL();
        public PayProjectDAL payProjectDAL = new PayProjectDAL();
        public PayRegistrationDAL payRegistrationDAL = new PayRegistrationDAL();

        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = payProjectDAL.GetTable((int)CommonEnum.Deleted.未删除, (int)CommonEnum.IsorNot.否);
                CommonFunction.DDlTypeBind(this.ddl_PIID, dt, "PPID", "ProjectName", "-2");

                GetCondition();
                DataBindList();
            }
        }
        #endregion


        #region 获取查询条件
        public void GetCondition()
        {
            ViewState["StID"] = CommonFunction.GetCommoneString(this.txt_StuName.Text.Trim());
            ViewState["Begin"] = this.txt_BeginDate.Text == "" ? "1900-01-01" : this.txt_BeginDate.Text;
            ViewState["End"] = this.txt_EndDate.Text == "" ? "9999-12-31" : this.txt_EndDate.Text;
            ViewState["PIID"] = this.ddl_PIID.SelectedValue;
        }
        #endregion


        #region 数据绑定
        public void DataBindList()
        {
            int recordCount = 0;
            PayRegistrationEntity model = new PayRegistrationEntity(Convert.ToDateTime(ViewState["Begin"]), Convert.ToDateTime(ViewState["End"]));
            model.PIID = ViewState["PIID"].ToString();
            model.Isdel = Convert.ToInt32(CommonEnum.IsorNot.否);
            model.StID = ViewState["StID"].ToString();

            DataTable dt = payRegistrationDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
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
                int result = payRegistrationDAL.DeleteBat(ids, (int)CommonEnum.Deleted.删除);
                if (result > 0)
                {
                    ShowMessage("删除成功");
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除缴费登记信息", UserID));
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