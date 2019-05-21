/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      殷志瑞
** 创建日期:    2017年6月11日 10:00
** 描 述:       资产调拨编辑页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using System.Text;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace GKICMP.assetmanage
{
    public partial class AssetAllocationEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public Asset_AllocationDAL assetAllocationDAL = new Asset_AllocationDAL();
        public Asset_Account_InfoDAL infoDAL = new Asset_Account_InfoDAL();


        #region 参数集合
        public string AAID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        public int Flag
        {
            get
            {
                return GetQueryString<int>("flag", -1);
            }
        }
        #endregion


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.hf_Flag.Value = Flag.ToString();
                if (Flag == 1)
                {
                    this.ltl_bt.Text = "资产调拨信息";
                    this.div2.Visible = false;
                }
                else
                {
                    this.ltl_bt.Text = "资产退回信息";
                    this.div1.Visible = false;
                }
                if (AAID == "")
                {
                    this.hf_AAID.Value = Guid.NewGuid().ToString();
                }
                else
                {
                    this.hf_AAID.Value = AAID.ToString();
                    BindInfo();
                }
            }
        }
        #endregion


        #region 提交
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                int isadd = AAID == "" ? -1 : 1;
                Asset_AllocationEntity model = new Asset_AllocationEntity();
                if (Flag == 1)
                {
                    model.AcceptUser = this.txt_AcceptUser.Text.Trim();
                    model.AllocationDate = Convert.ToDateTime(this.txt_AllocationDate.Text);
                    model.InDep = this.txt_InDep.Text.Trim();
                    model.OutDep = this.txt_OutDep.Text.Trim();
                    model.OutUser = this.txt_OutUser.Text.Trim();
                    model.AFlag = (int)CommonEnum.AFlag.调拨;
                }
                else
                {
                    model.AcceptUser = "";
                    model.OutDep = "";
                    model.OutUser = "";
                    model.AllocationDate = Convert.ToDateTime(this.txt_data.Text);
                    model.AFlag = (int)CommonEnum.AFlag.退回;
                    model.InDep = this.txt_AcceptDep.Text.Trim();
                }
                model.AAID = this.hf_AAID.Value;
                model.CreaterUser = UserID;
                model.Isdel = (int)CommonEnum.IsorNot.否;
                model.AllDesc = this.txt_AllDesc.Text.Trim();
                int result = assetAllocationDAL.Edit(model, isadd);
                if (result == 0)
                {
                    int log = AAID == "" ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, AAID == "" ? "添加" : "修改" + (Flag == 1 ? "资产调拨" : "资产退回") + "信息", UserID));
                    ShowMessage();
                }
                else
                {
                    ShowMessage("保存失败");
                    return;
                }
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                ShowMessage(ex.Message);
            }
        }
        #endregion


        #region 初始化用户数据
        public void BindInfo()
        {
            Asset_AllocationEntity model = assetAllocationDAL.GetObjByID(AAID);
            if (model != null)
            {
                if (Flag == 1)
                {
                    this.txt_AcceptUser.Text = model.AcceptUser;
                    this.txt_OutDep.Text = model.OutDep;
                    this.txt_OutUser.Text = model.OutUser;
                    this.txt_AllocationDate.Text = model.AllocationDate.ToString("yyyy-MM-dd");
                    this.txt_InDep.Text = model.InDep;
                }
                else
                {
                    this.txt_data.Text = model.AllocationDate.ToString("yyyy-MM-dd");
                    this.txt_AcceptDep.Text = model.InDep;
                }                      
                this.txt_AllDesc.Text = model.AllDesc; 
                DataBindList();
            }
        }
        #endregion



        #region 刷新
        protected void btnsear_Click(object sender, ImageClickEventArgs e)
        {
            DataBindList();
        }
        #endregion


        #region 绑定资产信息
        public void DataBindList()
        {
            DataTable dt = infoDAL.GetPaged(this.hf_AAID.Value, Flag == 1 ? (int)CommonEnum.AIType.调拨 : (int)CommonEnum.AIType.退回);
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
        #endregion


        #region 删除资产信息
        protected void imbtn_Delete_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton imbtn = (ImageButton)sender;
                int aaiid = Convert.ToInt32(imbtn.CommandArgument.ToString());
                int result = infoDAL.DeleteByID(aaiid);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除资产详细信息", UserID));
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<script>alert('删除成功');</script>");
                }
                else
                {
                    ShowMessage("删除失败");
                    return;
                }
                DataBindList();
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                ShowMessage(ex.Message);
            }
        }
        #endregion
    }
}