/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      殷志瑞
** 创建日期:    2017年6月8日 18时04分
** 描 述:       代课安排
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace GKICMP.educationals
{
    public partial class AbsentManage : PageBase
    {
        public LeaveDAL leaveDAL = new LeaveDAL();
        public static string EYear;
        public static int term;


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonFunction.DDlDataBaseBind(this.ddl_LType, (int)CommonEnum.BaseDataType.请假类型, "-999");
                this.ddl_LType.Items.Add(new ListItem("外出", "0"));
                //CommonFunction.BindEnum<CommonEnum.LType>(this.ddl_LType, "-2");
                GetCondition();
                DataBindList();
            }
        }
        #endregion


        #region 获取查询条件
        public void GetCondition()
        {
            ViewState["LeaveUserName"] = CommonFunction.GetCommoneString(this.txt_LeaveUser.Text.Trim());
            ViewState["BeginDate"] = this.txt_SDate.Text == "" ? "1900-01-01" : this.txt_SDate.Text;
            ViewState["EndDate"] = this.txt_EDate.Text == "" ? "9999-12-31" : this.txt_EDate.Text;
            ViewState["LType"] = this.ddl_LType.SelectedValue;
        }
        #endregion


        #region 绑定数据
        public void DataBindList()
        {
            int recordCount = 0;
            LeaveEntity model = new LeaveEntity();
            model.LeaveUserName = ViewState["LeaveUserName"].ToString();
            model.BeginDate = Convert.ToDateTime(ViewState["BeginDate"].ToString());
            model.EndDate = Convert.ToDateTime(ViewState["EndDate"].ToString());
            model.LType = Convert.ToInt32(ViewState["LType"].ToString());
            model.Isdel = Convert.ToInt32(CommonEnum.Deleted.未删除);
            model.LeaveState = (int)CommonEnum.AduitState.通过;
            GetTerm(out EYear, out term);
            DataTable dt = leaveDAL.GetPagedDKAP(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model, term, EYear);
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
            GetCondition();
            DataBindList();
        }
        #endregion


        #region 分页
        public void Pager_PageChanged(object sender, EventArgs e)
        {
            DataBindList();
        }
        #endregion


        #region 添加跳转
        protected void lbtn_SubArrange_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            string lid = lbtn.CommandArgument.ToString();
            string aa = string.Format("<script language=javascript>window.open('AbsentEdit.aspx?id={0}', '_self')</script>", lid);
            Response.Write(aa);
        }
        #endregion

        #region 详情
        protected void lbtn_SubDetail_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            string lid = lbtn.CommandArgument.ToString();
            string aa = string.Format("<script language=javascript>window.open('AbsentEdit.aspx?id={0}', '_self')</script>", lid);
            Response.Write(aa);
        }
        #endregion


        #region 获取当前学期
        private static void GetTerm(out string EYear, out int term)
        {
            EYear = "";
            term = 0;
            int year = Convert.ToInt32(DateTime.Now.ToString("yyyy"));
            int month = Convert.ToInt32(DateTime.Now.ToString("MM"));
            if (month < 8 && month >= 2)
            {
                EYear = (year - 1) + "-" + year;
                term = (int)CommonEnum.XQ.下学期;
            }
            else
            {
                if (month <= 12 && month >= 8)
                {
                    EYear = year + "-" + (year + 1);
                }
                else
                {
                    EYear = (year - 1) + "-" + year;
                }
                term = (int)CommonEnum.XQ.上学期;
            }
        }
        #endregion
    }
}