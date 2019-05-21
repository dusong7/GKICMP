/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      刘福洲
** 创建日期:      2017年6月1日 13时56分24秒
** 描    述:      教师合同管理界面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
******************************************************************/
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GKICMP.resource
{
    public partial class EduResourceAudit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public EduResourceDAL eduResourceDAL = new EduResourceDAL();
        #region 参数集合
        /// <summary>
        /// CID 评论留言ID
        /// </summary>
        public int Erid
        {
            get
            {
                return GetQueryString<int>("id", 0);
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
            if (!IsPostBack)
            {
                CommonFunction.BindEnum<CommonEnum.IsorNot>(this.ddl_IsExcellent, "-2");//是否公开
                CommonFunction.BindEnum<CommonEnum.NewsAuditState>(this.ddl_AuditState, "-2");//是否公开
               
            }
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
                EduResourceEntity model = new EduResourceEntity();
                model.Erid = Erid;
                model.IsExcellent = int.Parse(this.ddl_IsExcellent.SelectedValue);
                model.AuditState = int.Parse(this.ddl_AuditState.SelectedValue);
                model.AuditUser = UserID;
                model.AuditDate = DateTime.Now;
                int result = eduResourceDAL.Audit(model);
                if (result > 0)
                {
                    ShowMessage();
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "审核", UserID));
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
                return;
            }
        }
        #endregion
    }
}