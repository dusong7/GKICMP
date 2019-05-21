/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月12日 09点30分
** 描   述:       车辆编辑页面
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
    public partial class VehicleEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public VehicleDAL vehicleDAL = new VehicleDAL();
        public SysDataDAL sysDataDAL = new SysDataDAL();


        #region 参数集合
        public int VHID
        {
            get
            {
                return GetQueryString<int>("id", -1);
            }
        }
        #endregion


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = sysDataDAL.GetList((int)CommonEnum.IsorNot.否, (int)CommonEnum.DataType.车辆类型);
                CommonFunction.BindEnum<CommonEnum.VState>(this.ddl_VState, "-2");
                CommonFunction.DDlTypeBind(this.ddl_Vtype, dt, "SDID", "DataName", "-2");
                if (VHID != -1)
                {
                    BindInfo();
                }
            }
        }
        #endregion


        #region 初始化用户数据
        public void BindInfo()
        {
            VehicleEntity model = vehicleDAL.GetObjByID(VHID);
            if (model != null)
            {
                this.txt_BuyDate.Text = model.BuyDate.ToString("yyyy-MM-dd");
                this.txt_CSeatNum.Text = model.CSeatNum.ToString();
                this.txt_Vcash.Text = model.Vcash.ToString();
                this.txt_VConfig.Text = model.VConfig;
                this.txt_VDesc.Text = model.VDesc;
                this.txt_VehicleName.Text = model.VehicleName;
                this.ddl_VState.Text = model.VState.ToString();
                this.ddl_Vtype.Text = model.Vtype.ToString();
                this.txt_VehicleCode.Text = model.VehicleCode;
            }
        }
        #endregion


        #region 提交
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                VehicleEntity model = new VehicleEntity();
                model.BuyDate = Convert.ToDateTime(this.txt_BuyDate.Text);
                model.CreateUser = UserID;
                model.CSeatNum = Convert.ToInt32(this.txt_CSeatNum.Text);
                model.Isdel = (int)CommonEnum.IsorNot.否;
                model.Vcash = Convert.ToDecimal(this.txt_Vcash.Text);
                model.VConfig = this.txt_VConfig.Text.Trim();
                model.VDesc = this.txt_VDesc.Text.Trim();
                model.VehicleName = this.txt_VehicleName.Text.Trim();
                model.VHID = VHID;
                model.VState = Convert.ToInt32(this.ddl_VState.SelectedValue);
                model.Vtype = Convert.ToInt32(this.ddl_Vtype.SelectedValue);
                model.VehicleCode = this.txt_VehicleCode.Text.Trim();
                int result = vehicleDAL.Edit(model);
                if (result == 0)
                {
                    int log = VHID == -1 ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, (VHID == -1 ? "添加" : "修改") + "车辆名称为：" + this.txt_VehicleName.Text + "的信息", UserID));
                    ShowMessage();
                }
                else if (result == -2)
                {
                    ShowMessage("车牌照已存在，不能重复添加");
                    return;
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
    }
}