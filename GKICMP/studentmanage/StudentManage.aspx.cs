/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月16日 08时30分53秒
** 描    述:      学生信息列表页面
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
    public partial class StudentManage : PageBase
    {
        public StudentDAL studentDAL = new StudentDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();

        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonFunction.BindEnum<CommonEnum.XB>(this.ddl_Sex, "-2");
                CommonFunction.BindEnum<CommonEnum.UState>(this.ddl_Ustate, "-2");
                CommonFunction.BindEnum<CommonEnum.BDLX>(this.ddl_Ustate, "-99");
                GetCondition();
                DataBindList();
            }
        }
        #endregion


        #region 获取查询条件
        public void GetCondition()
        {
            ViewState["Name"] = CommonFunction.GetCommoneString(this.txt_Name.Text.Trim());
            ViewState["begin"] = this.txt_Begin.Text == "" ? "1900-01-01" : this.txt_Begin.Text;
            ViewState["end"] = this.txt_End.Text == "" ? "9999-12-31" : this.txt_End.Text;
            ViewState["sex"] = this.ddl_Sex.SelectedValue;
            ViewState["ustate"] = this.ddl_Ustate.SelectedValue;
        }
        #endregion


        #region 数据绑定
        public void DataBindList()
        {
            int recordCount = 0;
            SysUserEntity model = new SysUserEntity();
            model.RealName = ViewState["Name"].ToString();
            model.UserSex = Convert.ToInt32(ViewState["sex"].ToString());
            model.UState = Convert.ToInt32(ViewState["ustate"].ToString());
            DateTime begin = Convert.ToDateTime(ViewState["begin"].ToString());
            DateTime end = Convert.ToDateTime(ViewState["end"].ToString());
            model.Isdel = Convert.ToInt32(CommonEnum.IsorNot.否);
            model.UserType = Convert.ToInt32(CommonEnum.UserType.学生);
            DataTable dt = sysUserDAL.GetStudent(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model, begin, end);
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


        #region 修改跳转
        /// <summary>
        /// 修改跳转
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_Edit_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            string id = lbtn.CommandArgument.ToString();
            string aa = string.Format("<script language=javascript>window.open('StudentEdit.aspx?id={0}', '_self')</script>", id);
            Response.Write(aa);
        }
        #endregion


        #region 详细跳转
        /// <summary>
        /// 详细跳转
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_Detail_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            string id = lbtn.CommandArgument.ToString();
            string aa = string.Format("<script language=javascript>window.open('StudentDetail.aspx?id={0}', '_self')</script>", id);
            Response.Write(aa);
        }
        #endregion

      
      
    }
}