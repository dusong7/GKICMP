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

namespace GKICMP.teachermanage
{
    public partial class AttendRecordSelectCD : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public AttendRecordDAL attendRecordDAL = new AttendRecordDAL();

        #region 参数集合
        public string TID
        {
            get
            {
                return GetQueryString<string>("id","");
            }
        }
        public int IsAnalysis
        {
            get
            {
                return GetQueryString<int>("IsAnalysis", -1);
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
                GetCondition();
                DataBindList();
              
              
            }
        }
        #endregion


        #region 获取查询条件
        public void GetCondition()
        {
           
        }
        #endregion


        #region 数据绑定
        public void DataBindList()
        {
            int recordCount = -1;
            //AttendRecordEntity model = new AttendRecordEntity();
            string UserNum= TID;
            int IsAnaly = Convert.ToInt32(IsAnalysis);
            DateTime begin = Convert.ToDateTime(Begin);
            DateTime end = Convert.ToDateTime(End);
            DataTable dt = attendRecordDAL.GetPagedSelect(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, UserNum, IsAnaly, begin, end);
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

        #region 分页
        protected void Pager_PageChanged(object sender, EventArgs e)
        {
            DataBindList();
        }
        #endregion

        #region 查询
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            Pager.CurrentPageIndex = 1;
            GetCondition();
            DataBindList();
        }
        #endregion


        #region 获取分析结果
        public string GetIsanayName(object sender)
        {
            if (sender.ToString() == "")
            {
                return "<span style='color:red;'>未分析</span>";
            }
            else
            {
                return sender.ToString();
            }
        }
        #endregion
        

    }
}