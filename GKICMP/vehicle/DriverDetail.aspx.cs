/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      yzr
** 创建日期:      2017年01月26日 16时05分25秒
** 描    述:     司机信息详细页面
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
    public partial class DriverDetail : PageBase
    {
        public DriverDAL driverDAL = new DriverDAL();


        #region 参数集合
        public int DID
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
                DriverEntity model = driverDAL.GetObjByID(DID);
                if (model != null)
                {
                    this.lbl_Birthday.Text = model.BirthDay.ToString("yyyy-MM-dd");
                    this.lbl_Cellphone.Text = model.CellPhone;
                    this.lbl_DDesc.Text = model.DDesc;
                    this.lbl_DriverCode.Text = model.DriverCode;
                    this.lbl_FristGetDate.Text = model.FristGetDate.ToString("yyyy-MM-dd");
                    this.lbl_RealName.Text = model.RealName;
                    this.lbl_SType.Text = CommonFunction.CheckEnum<CommonEnum.Vtype>(model.SType);
                    this.lbl_UserSex.Text = CommonFunction.CheckEnum<CommonEnum.XB>(model.UserSex);
                }
            }
        }
        #endregion
    }
}