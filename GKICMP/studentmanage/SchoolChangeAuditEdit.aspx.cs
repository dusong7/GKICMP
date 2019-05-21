/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年9月8日 15时22分53秒
** 描    述:      学生变动信息审核编辑列表页面
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

namespace GKICMP.studentmanage
{
    public partial class SchoolChangeAuditEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SchoolChangeDAL changeDAL = new SchoolChangeDAL();

        #region 参数集合
        /// <summary>
        /// 异动ID
        /// </summary>
        public string TID
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
                SchoolChangeEntity model = new SchoolChangeEntity();
                model.TID = TID.TrimEnd(',').TrimStart(',');
                model.AduitUser = UserID;
                model.AduitDesc = this.txt_AduitDesc.Text.ToString();
                if (this.rdo_AduitState.SelectedValue == "1")
                {
                    model.AduitState = (int)CommonEnum.AduitState.通过;
                }
                else
                {
                    model.AduitState = (int)CommonEnum.AduitState.驳回;
                }

                int result = changeDAL.UpdateAduit(model);
                if (result > 0)
                {
                    ShowMessage();
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "审核学生变动信息", UserID));
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
                return;
            }
        }
        #endregion
    }
}