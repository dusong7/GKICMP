/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      殷志瑞
** 创建日期:    2017年08月15日 08时30分
** 描 述:       在编工资详细页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;

namespace GKICMP.app
{
    public partial class PersonWageManage : PageBaseApp
    {
        public WageDAL wageDAL = new WageDAL();


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                WageEntity model = wageDAL.GetByTID(UserID);
                if (model != null)
                {
                    this.ltl_TIDName.Text = model.TIDName;
                    this.ltl_WMonth.Text = model.WMonth.ToString();
                    this.ltl_WYear.Text = model.WYear.ToString();
                    if (model.WFlag == (int)CommonEnum.WFlag.在编)
                    {
                        this.ltl_Accumulation.Text = model.Accumulation.ToString();
                        this.ltl_ActualWages.Text = model.ActualWages.ToString();
                        this.ltl_Allowance.Text = model.Allowance.ToString();
                        this.ltl_AssessWage.Text = model.AssessWage.ToString();
                        this.ltl_BasicPay.Text = model.BasicPay.ToString();
                        this.ltl_Income.Text = model.Income.ToString();
                        this.ltl_Insurance.Text = model.Insurance.ToString();
                        this.ltl_MedicalFee.Text = model.MedicalFee.ToString();
                        this.ltl_PostWage.Text = model.PostWage.ToString();
                        this.ltl_RentalFee.Text = model.RentalFee.ToString();
                        this.ltl_Rewarding.Text = model.Rewarding.ToString();
                        this.ltl_SalaryScale.Text = model.SalaryScale.ToString();
                        this.ltl_Serious.Text = model.Serious.ToString();
                        this.ltl_ShouldWage.Text = model.ShouldWage.ToString();
                        this.ltl_TeachNursing.Text = model.TeachNursing.ToString();
                        this.ltl_Unemployment.Text = model.Unemployment.ToString();
                        this.ltl_Union.Text = model.Union.ToString();
                        this.ltl_WDesc.Text = model.WDesc;
                        this.ltl_Withhold.Text = model.Withhold.ToString();
                        this.d3.Visible = false;
                        this.d4.Visible = false;
                    }
                    else
                    {
                        this.ltl_jbgz.Text = model.Allowance.ToString();
                        this.ltl_gwgz.Text = model.PostWage.ToString();
                        this.ltl_xlgz.Text = model.SalaryScale.ToString();
                        this.ltl_syjxgz.Text = model.BasicPay.ToString();
                        this.ltl_yfgz.Text = model.ShouldWage.ToString();
                        this.ltl_ylbx.Text = model.Insurance.ToString();
                        this.ltl_zfgjj.Text = model.Accumulation.ToString();
                        this.ltl_sybx.Text = model.Unemployment.ToString();
                        this.ltl_dbjz.Text = model.Serious.ToString();
                        this.ltl_yb.Text = model.MedicalFee.ToString();
                        this.ltl_dkxj.Text = model.Withhold.ToString();
                        this.ltl_ghkc.Text = model.Union.ToString();
                        this.ltl_sfgz.Text = model.ActualWages.ToString();
                        this.d2.Visible = false;
                        this.d4.Visible = false;
                    }
                }
                else
                {
                    this.d1.Visible = false;
                    this.d2.Visible = false;
                    this.d3.Visible = false;
                }
            }
        }
        #endregion
    }
}