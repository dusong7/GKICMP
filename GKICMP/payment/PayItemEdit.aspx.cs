/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年8月15日 09时29分01秒
** 描    述:      缴费项编辑页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Data;
using System.Linq;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using System.Text.RegularExpressions;

namespace GKICMP.payment
{
    public partial class PayItemEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public PayItemDAL payItemDAL = new PayItemDAL();


        #region 参数集合
        public int PIID
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
                //CommonFunction.BindEnum<CommonEnum.IsorNot>(this.rbl_IsDisable);
                //this.rbl_IsDisable.SelectedIndex = 0;

                if (PIID != -1)
                {
                    BindInfo();
                }
            }
        }
        #endregion

        #region 初始化用户数据
        public void BindInfo()
        {
            PayItemEntity model = payItemDAL.GetObjByID(PIID);
            if (model != null)
            {
                this.txt_Begin.Text = model.BeginDate.ToString("yyyy-MM-dd");
                this.txt_PayCount.Text = model.PayCount.ToString();
                this.txt_PayName.Text = model.PayName;

                //this.rbl_IsDisable.SelectedValue = model.IsDisable.ToString();
                //this.txt_End.Text = model.EndDate.ToString("yyyy-MM-dd");
            }

        }
        #endregion

        #region 提交
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                PayItemEntity model = new PayItemEntity();
                model.PayName = this.txt_PayName.Text.Trim();
                model.Isdel = (int)CommonEnum.IsorNot.否;
                model.PayCount = Convert.ToDecimal(this.txt_PayCount.Text);
                model.PIID = PIID;
                model.BeginDate = Convert.ToDateTime(this.txt_Begin.Text);
                model.IsDisable = (int)CommonEnum.IsorNot.否;
                //model.EndDate = Convert.ToDateTime(this.txt_End.Text);
                //model.IsDisable = Convert.ToInt32(this.rbl_IsDisable.SelectedValue);
                int result = payItemDAL.Edit(model);
                if (result == 0)
                {
                    int log = PIID == -1 ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    ShowMessage();
                    sysLogDAL.Edit(new SysLogEntity(log, PIID == -1 ? "添加" : "修改" + "缴费项名称为：" + this.txt_PayName.Text + "的信息", UserID));
                }
                else if (result == -2)
                {
                    ShowMessage("缴费项名称已存在，请重新录入");
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
                ShowMessage(ex.Message);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
            }
        }
        #endregion


       
    }
}