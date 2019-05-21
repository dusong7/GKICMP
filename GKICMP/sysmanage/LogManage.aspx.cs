/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      CZZ
** 创建日期:      2017年03月02日 09点30分
** 描   述:       系统日志页面
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
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GKICMP.sysmanage
{
    public partial class LogManage : PageBase
    {

        public SysLogDAL sysLogDAL = new SysLogDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonFunction.BindEnum<CommonEnum.LogType>(this.ddl_LogType, "-2");
                ViewState["CreateUser"] = CommonFunction.GetCommoneString(this.txt_CreateUser.Text.Trim());//姓名
                ViewState["Begin"] = "1900-01-01";
                ViewState["End"] = "9999-12-31";
                DataBindList();
            }

        }
        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {
            int recordCount = -1;
            SysLogEntity model = new SysLogEntity((string)ViewState["CreateUser"], int.Parse(this.ddl_LogType.SelectedValue));
            model.Begin = Convert.ToDateTime(ViewState["Begin"].ToString());
            model.End = Convert.ToDateTime(ViewState["End"].ToString());
            model.LogFlag = 1;
            DataTable dt = sysLogDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.tr_null.Visible = false;
            }
            else
            {
                this.tr_null.Visible = true;
            }
            this.rp_List.DataSource = dt;
            Pager.RecordCount = recordCount;
            rp_List.DataBind();
            this.hf_CheckIDS.Value = "";
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


        #region 查询事件
        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Query_Click(object sender, EventArgs e)
        {
            Pager.CurrentPageIndex = 1;
            ViewState["CreateUser"] = CommonFunction.GetCommoneString(this.txt_CreateUser.Text.Trim());//姓名

            DataBindList();
        }
        #endregion



    }
}