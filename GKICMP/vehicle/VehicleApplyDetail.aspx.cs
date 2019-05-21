/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      yzr
** 创建日期:      2017年01月26日 16时05分25秒
** 描    述:     车辆信息详细页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using System.Data;

namespace GKICMP.vehicle
{
    public partial class VehicleApplyDetail : PageBase
    {
        public DriverDAL driverDAL = new DriverDAL();
        public VehicleDAL vehicleDAL = new VehicleDAL();
        public Vehicle_ApplyDAL applyDAL = new Vehicle_ApplyDAL();
        public Vehicle_AduitDAL aduitDAL = new Vehicle_AduitDAL();


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
                Vehicle_ApplyEntity model = applyDAL.GetObjByID(ApplyID);
                if (model != null)
                {
                    this.lbl_ApplyDate.Text = model.ApplyDate.ToString("yyyy-MM-dd");
                    this.lbl_ApplyDesc.Text = model.ApplyDesc;
                    this.lbl_ApplyUser.Text = model.ApplyUserName;
                    this.lbl_BeginAddress.Text = model.BeginAddress;
                    this.lbl_BeginDate.Text = model.BeginDate.ToString("yyyy-MM-dd HH:mm");
                    this.lbl_EndAddress.Text = model.EndAddress;
                    this.lbl_EndDate.Text = model.EndDate.ToString("yyyy-MM-dd HH:mm");
                    this.lbl_PeerCount.Text = model.PeerCount.ToString();
                    this.lbl_VAState.Text = CommonFunction.CheckEnum<CommonEnum.PraState>(model.VState);
                    VehicleEntity model1 = vehicleDAL.GetObjByID(model.VHID);
                    if (model1 != null)
                    {
                        this.lbl_BuyDate.Text = model1.BuyDate.ToString("yyyy-MM-dd");
                        this.lbl_CSeatNum.Text = model1.CSeatNum.ToString();
                        this.lbl_Vcash.Text = model1.Vcash.ToString();
                        this.lbl_VConfig.Text = model1.VConfig;
                        this.lbl_VDesc.Text = model1.VDesc;
                        this.lbl_VehicleName.Text = model1.VehicleName;
                        this.lbl_Vstate.Text = CommonFunction.CheckEnum<CommonEnum.VState>(model1.VState);
                        this.lbl_Vtype.Text = model1.VtypeName;
                        this.lbl_VehicleCode.Text = model1.VehicleCode;
                    }
                    DriverEntity model2 = driverDAL.GetObjByID(model.DID);
                    if (model2 != null)
                    {
                        this.lbl_Birthday.Text = model2.BirthDay.ToString("yyyy-MM-dd");
                        this.lbl_Cellphone.Text = model2.CellPhone;
                        this.lbl_DDesc.Text = model2.DDesc;
                        this.lbl_DriverCode.Text = model2.DriverCode;
                        this.lbl_FristGetDate.Text = model2.FristGetDate.ToString("yyyy-MM-dd");
                        this.lbl_RealName.Text = model2.RealName;
                        this.lbl_SType.Text = CommonFunction.CheckEnum<CommonEnum.Vtype>(model2.SType);
                        this.lbl_UserSex.Text = CommonFunction.CheckEnum<CommonEnum.XB>(model2.UserSex);
                    }
                    Vehicle_AduitEntity model3 = aduitDAL.GetObjByID(ApplyID);
                    if (model3 != null)
                    {
                        this.lbl_AduitDate.Text = model3.AduitDate.ToString("yyyy-MM-dd");
                        this.lbl_AduitMess.Text = model3.AduitMess;
                        this.lbl_AduitUser.Text = model3.AduitUserName;
                    }
                }
            }
        }
        #endregion
    }
}