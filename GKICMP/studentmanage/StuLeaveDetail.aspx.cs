/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月16日 08时30分53秒
** 描    述:      学生考勤详细页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Web.UI.WebControls;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Data;

namespace GKICMP.studentmanage
{
    public partial class StuLeaveDetail : PageBase
    {
        public StuAttendDAL stuAttendDAL = new StuAttendDAL();


        #region 参数集合
        public int DID
        {
            get
            {
                return GetQueryString<int>("did", -1);
            }
        }
        public int Month
        {
            get
            {
                return GetQueryString<int>("months", -1);
            }
        }
        public int attendtype
        {
            get
            {
                return GetQueryString<int>("attendtype", -1);
            }
        }
        #endregion


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.hf_attendtype.Value = attendtype.ToString();
                this.lbl_attenttype.Text = CommonFunction.CheckEnum<CommonEnum.AttendState>(this.hf_attendtype.Value) + "天数";
                GetCondition();
                DataBindList();
            }
        }
        #endregion


        #region 获取查询条件
        public void GetCondition()
        {
            ViewState["LeaveUser"] = CommonFunction.GetCommoneString(this.txt_LeaveUser.Text);
            ViewState["DIDName"] = CommonFunction.GetCommoneString(this.txt_DIDName.Text.Trim());
            ViewState["begin"] = this.txt_Begin.Text == "" ? "1900-01-01" : this.txt_Begin.Text;
            ViewState["end"] = this.txt_End.Text == "" ? "9999-12-31" : this.txt_End.Text;
        }
        #endregion


        #region 数据绑定
        public void DataBindList()
        {
            int recordCount = 0;
            DataTable dt = stuAttendDAL.GetPagedByDID(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, Month, DID, attendtype, ViewState["LeaveUser"].ToString(), ViewState["DIDName"].ToString(), Convert.ToDateTime(ViewState["begin"].ToString()), Convert.ToDateTime(ViewState["end"].ToString()));
            if (dt != null && dt.Rows.Count > 0)
            {
                this.tr_null.Visible = false;
            }
            else
            {
                this.tr_null.Visible = true;
            }
            rp_List.DataSource = dt;
            Pager.RecordCount = recordCount;
            rp_List.DataBind();
        }
        #endregion


        #region 分页
        public void Pager_PageChanged(object sender, EventArgs e)
        {
            DataBindList();
        }
        #endregion

        #region 查询
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            GetCondition();
            DataBindList();
        }
        #endregion
    }
}