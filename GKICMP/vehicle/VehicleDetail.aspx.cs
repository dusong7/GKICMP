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
    public partial class VehicleDetail : PageBase
    {
        public VehicleDAL vehicleDAL = new VehicleDAL();


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
                VehicleEntity model = vehicleDAL.GetObjByID(VHID);
                if (model != null)
                {
                    this.lbl_BuyDate.Text = model.BuyDate.ToString("yyyy-MM-dd");
                    this.lbl_CSeatNum.Text = model.CSeatNum.ToString();
                    this.lbl_Vcash.Text = model.Vcash.ToString();
                    this.lbl_VConfig.Text = model.VConfig;
                    this.lbl_VDesc.Text = model.VDesc;
                    this.lbl_VehicleName.Text = model.VehicleName;
                    this.lbl_VState.Text = CommonFunction.CheckEnum<CommonEnum.VState>(model.VState);
                    this.lbl_Vtype.Text = model.VtypeName;
                    this.lbl_VehicleCode.Text = model.VehicleCode;
                }
            }
        }
        #endregion
    }
}