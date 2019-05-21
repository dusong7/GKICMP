/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2016年10月15日 13时56分24秒
** 描    述:      考勤打卡管理界面
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

namespace GKICMP.office
{
    public partial class OverTimeList : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public OverTimeDAL overTimeDAL = new OverTimeDAL();

        #region 参数集合
        public string TID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        public string Begin
        {
            get
            {
                return GetQueryString<string>("Begin", "");
            }
        }
        public string End
        {
            get
            {
                return GetQueryString<string>("End", "");
            }
        }
        #endregion

        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataBindList();
            }
        }
        #endregion


        #region 数据绑定
        public void DataBindList()
        {
            //AttendRecordEntity model = new AttendRecordEntity();
         
           
            DateTime begin = Convert.ToDateTime(Begin);
            DateTime end = Convert.ToDateTime(End);
            DataTable dt = overTimeDAL.GetStatistcs(begin, end, TID);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.tr_null.Visible = false;
            }
            else
            {
                this.tr_null.Visible = true;
            }

            this.rp_List.DataSource = dt;
            this.rp_List.DataBind();
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