/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年8月15日 13时49分01秒
** 描    述:      日志审核页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.spacemanage
{
    public partial class SpaceLogAuditEdit : PageBase
    {
        public SpaceLogDAL logDAL = new SpaceLogDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();


        #region 参数集合
        /// <summary>
        /// IDS 日志ID集合
        /// </summary>
        public string IDS
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        } 
        #endregion


        #region 页面初始化
        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

        } 
        #endregion


        #region 提交事件
        /// <summary>
        /// 提交事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                string eids = IDS.TrimEnd(',').TrimStart(',');
                SpaceLogEntity model = new SpaceLogEntity();
                if (this.rdo_AuditState.SelectedValue.ToString() == "1")
                {
                    model.AduitState = (int)CommonEnum.AduitState.通过;
                }
                else
                {
                    model.AduitState = (int)CommonEnum.AduitState.驳回;
                }
                model.IsAduit = (int)CommonEnum.IsorNot.是;
                int result = logDAL.LogAudit(eids, model);
                if (result > 0)
                {
                    ShowMessage();
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "审核空间日志信息", UserID));
                }
                else
                {
                    ShowMessage("提交失败");
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