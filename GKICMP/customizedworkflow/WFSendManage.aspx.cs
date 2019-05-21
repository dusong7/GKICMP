/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月07日 09点30分
** 描   述:      排课计划
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using System.Data;
using GK.GKICMP.Entities;
using PaikeTest;
using PaikeTest.Model;
using PaikeTest.Utils;
using System.Collections.Generic;
using System.Threading;
using System.Web;

namespace GKICMP.customizedworkflow
{
    public partial class WFSendManage : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();


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
                DataBindList();
            }

        }
        #endregion


        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {
            int recordCount = -1;
            DataTable dt = new WF_CustomizedDAL().GetSendPagedList(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, UserID);
            dt.Columns.Add("CStateName", Type.GetType("System.String"));
            foreach (DataRow dr in dt.Rows)
            {
                dr["CStateName"] = Enum.GetName(typeof(CommonEnum.CState), Convert.ToInt32(dr["CState"]));
            }
            if (dt != null && dt.Rows.Count > 0)
            {
                this.tr_null.Visible = false;
            }
            else
            {
                this.tr_null.Visible = true;
            }
            Pager.RecordCount = recordCount;
            this.rp_List.DataSource = dt;
            rp_List.DataBind();
        }
        #endregion


        #region 分页事件
        /// <summary>
        /// 分页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Pager_PageChanged(object sender, EventArgs e)
        {
            DataBindList();
        }
        #endregion


        #region 删除事件
        /// <summary>
        /// 删除事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {


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