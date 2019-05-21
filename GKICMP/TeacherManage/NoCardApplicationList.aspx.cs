/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2017年05月17日 09点30分
** 描   述:      招标详情
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using GK.GKICMP.DAL;

namespace GKICMP.teachermanage
{
    public partial class NoCardApplicationList : PageBase
    {

        public SysLogDAL sysLogDAL = new SysLogDAL();
        public Teacher_HolidayDAL teacher_HolidayDAL = new Teacher_HolidayDAL();
        public NoCardApplyDAL noCardApplyDAL = new NoCardApplyDAL();

        public SysDataDAL sysDataDAL = new SysDataDAL();

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
                GetConditon();
                DataBindList();
            }
        }
        #endregion


        #region 获取查询条件
        /// <summary>
        /// 获取查询条件
        /// </summary>
        public void GetConditon()
        {
            ViewState["NoCardApplyUser"] = CommonFunction.GetCommoneString(this.txt_NoCardApplyUser.Text.ToString().Trim());
            ViewState["begin"] = this.txt_SDate.Text == "" ? "1900-01-01" : this.txt_SDate.Text;  //开始时间
            ViewState["end"] = this.txt_EDate.Text == "" ? "9999-12-31" : this.txt_EDate.Text;     //结束时间
        }
        #endregion


        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        public void DataBindList()
        {
            int recordCount = -1;
            NoCardApplyEntity model = new NoCardApplyEntity();
            model.NoCardApplyUser = ViewState["NoCardApplyUser"].ToString();
            DateTime begin = Convert.ToDateTime(ViewState["begin"].ToString());
            DateTime end = Convert.ToDateTime(ViewState["end"].ToString());
            model.NoCardState =Convert.ToInt32(GK.GKICMP.Common.CommonEnum.PraState.申请中);
            model.NoCardAuditUser = UserID;
            int flag = 2; //1为补卡综合查询 2为补卡审核查询
            DataTable dt = noCardApplyDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model, begin, end,flag);
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
            this.rp_List.DataBind();
            this.hf_CheckIDS.Value = "";
        }
        #endregion


        #region 查询
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            Pager.CurrentPageIndex = 1;
            GetConditon();
            DataBindList();
        }
        #endregion


        #region 分页
        protected void Pager_PageChanged(object sender, EventArgs e)
        {
            DataBindList();
        }
        #endregion

    }
}