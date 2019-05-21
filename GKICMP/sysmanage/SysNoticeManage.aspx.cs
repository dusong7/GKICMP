/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2017年03月02日 09点30分
** 描   述:       系统通知页面
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
    public partial class SysNoticeManage : PageBase
    {
        public SysNoticeDAL sysNoticeDAL = new SysNoticeDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["SendUser"] = CommonFunction.GetCommoneString(this.txt_CreateUser.Text.Trim());//
                ViewState["NContent"] = CommonFunction.GetCommoneString(this.txt_NContent.Text.Trim());//
                ViewState["Begin"] = this.txt_Begin.Text == "" ? "1900-01-01" : this.txt_Begin.Text.ToString();  //开始时间
                ViewState["End"] = this.txt_End.Text == "" ? "9999-12-31" : this.txt_End.Text.ToString();     //结束时间

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
            SysNoticeEntity model = new SysNoticeEntity((string)ViewState["SendUser"], (string)ViewState["NContent"]);
            model.Begin = Convert.ToDateTime(ViewState["Begin"].ToString());
            model.End = Convert.ToDateTime(ViewState["End"].ToString());

            DataTable dt = sysNoticeDAL.PagedList(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
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
            ViewState["SendUser"] = CommonFunction.GetCommoneString(this.txt_CreateUser.Text.Trim());//
            ViewState["NContent"] = CommonFunction.GetCommoneString(this.txt_NContent.Text.Trim());//
            ViewState["Begin"] = this.txt_Begin.Text == "" ? "1900-01-01" : this.txt_Begin.Text.ToString();  //开始时间
            ViewState["End"] = this.txt_End.Text == "" ? "9999-12-31" : this.txt_End.Text.ToString();     //结束时间
            DataBindList();
        }
        #endregion


    }
}