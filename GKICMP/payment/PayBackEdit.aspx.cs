/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年8月15日 09时29分01秒
** 描    述:      退费编辑页面
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

namespace GKICMP.payment
{
    public partial class PayBackEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public PayBackDAL payBackDAL = new PayBackDAL();


        #region 参数集合
        public string PRID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        public string StuID
        {
            get
            {
                return GetQueryString<string>("stuid", "");
            }
        }
        #endregion


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #endregion


        #region 提交
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                PayBackEntity model = new PayBackEntity();
                model.BackCount = Convert.ToDecimal(this.txt_PayCount.Text);
                model.PBID = -1;
                model.PRID = PRID;
                model.BackUser = StuID;
                model.IsAudit = (int)CommonEnum.PraState.申请中;
                model.CreateUser = UserID;
                model.Isdel = (int)CommonEnum.IsorNot.否;
                int result = payBackDAL.Edit(model);
                if (result == 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, "添加退费信息", UserID));
                    ShowMessage();
                }
                else if (result == -2)
                {
                    ShowMessage("退费金额超过缴费金额，请检查重新退费");
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