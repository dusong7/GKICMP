/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月12日 09点30分
** 描   述:       车辆申请编辑页面
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.Data;
using System.Text;
using System.Web.UI.WebControls;

namespace GKICMP.vehicle
{
    public partial class VehicleApplyEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public Vehicle_ApplyDAL applyDAL = new Vehicle_ApplyDAL();
        public VehicleDAL vehicleDAL = new VehicleDAL();


        #region 参数集合
        public string ApplyID
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
                DataTable dt = vehicleDAL.GetTable((int)CommonEnum.IsorNot.否);
                dt.Columns.Add("VehicleNames", System.Type.GetType("System.String"), "VehicleName+'('+VehicleCode+')'");
                this.ddl_VHID.DataValueField = "VHID";
                this.ddl_VHID.DataTextField = "VehicleNames";
                this.ddl_VHID.DataSource = dt;
                this.ddl_VHID.DataBind();
                this.ddl_VHID.Items.Insert(0, new ListItem("--请选择--", "-2"));

                if (ApplyID != "")
                {
                    BindInfo();
                }
            }
        }
        #endregion


        #region 初始化用户数据
        public void BindInfo()
        {
            Vehicle_ApplyEntity model = applyDAL.GetObjByID(ApplyID);
            if (model != null)
            {
                this.txt_ApplyDesc.Text = model.ApplyDesc;
                this.txt_BeginAddress.Text = model.BeginAddress;
                this.txt_BeginDate.Text = model.BeginDate.ToString("yyyy-MM-dd HH:mm");
                this.txt_EndAddress.Text = model.EndAddress;
                this.txt_EndDate.Text = model.EndDate.ToString("yyyy-MM-dd HH:mm");
                this.txt_PeerCount.Text = model.PeerCount.ToString();
                this.ddl_VHID.SelectedValue = model.VHID.ToString();
            }
        }
        #endregion


        #region 提交
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                Vehicle_ApplyEntity model = new Vehicle_ApplyEntity();
                model.ApplyDesc = this.txt_ApplyDesc.Text.Trim();
                model.ApplyID = ApplyID;
                model.ApplyUser = UserID;
                model.BeginAddress = this.txt_BeginAddress.Text.Trim();
                model.BeginDate = Convert.ToDateTime(this.txt_BeginDate.Text);
                model.EndAddress = this.txt_EndAddress.Text.Trim();
                model.EndDate = Convert.ToDateTime(this.txt_EndDate.Text);
                model.Isdel = (int)CommonEnum.IsorNot.否;
                model.PeerCount = Convert.ToInt32(this.txt_PeerCount.Text);
                model.SysUid = "";
                model.VHID = Convert.ToInt32(this.ddl_VHID.SelectedValue.ToString());
                model.VState = (int)CommonEnum.PraState.申请中;
                int result = applyDAL.Edit(model);
                if (result == 0)
                {
                    ShowMessage();
                    int log = ApplyID == "" ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, (ApplyID == "" ? "添加" : "修改") + "车辆申请的信息", UserID));
                }
                else
                {
                    ShowMessage("保存失败");
                    return;
                }
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