/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月12日 09点30分
** 描   述:       值班日志
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
using System.Web.UI.WebControls;

namespace GKICMP.office
{
    public partial class DutyLogManage : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SchoolLogDAL schoolLogDAL = new SchoolLogDAL();



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
                CommonFunction.BindEnum<CommonEnum.XQ>(this.ddl_Term, "-2");
                GetCondition();
                DataBindList();
            }
        }
        #endregion


        #region  获取查询条件
        public void GetCondition()
        {
            ViewState["EYear"] = CommonFunction.GetCommoneString(this.txt_EYear.Text.Trim());
            ViewState["CreateUser"] = CommonFunction.GetCommoneString(this.txt_CreateUser.Text.Trim());
            ViewState["begin"] = this.txt_Begin.Text == "" ? "1900-01-01" : this.txt_Begin.Text;
            ViewState["end"] = this.txt_End.Text == "" ? "9999-12-31" : this.txt_End.Text;
            ViewState["Term"] = this.ddl_Term.SelectedValue;
        }
        #endregion


        #region 获取数据绑定
        public void DataBindList()
        {
            int recordCount = 0;
            SchoolLogEntity model = new SchoolLogEntity();
            model.SYear = ViewState["EYear"].ToString();
            model.CreateuserName = ViewState["CreateUser"].ToString();
            DateTime begin = Convert.ToDateTime(ViewState["begin"].ToString());
            DateTime end = Convert.ToDateTime(ViewState["end"].ToString());
            model.STerm = Convert.ToInt32(ViewState["Term"].ToString());
            DataTable dt = schoolLogDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model, begin, end);
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
        protected void Pager_PageChanged(object sender, EventArgs e)
        {
            DataBindList();
        }
        #endregion


        #region 删除
        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                string ids = this.hf_CheckIDS.Value.TrimEnd(',');
                int result = schoolLogDAL.DeleteByID(ids);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除值班日志信息", UserID));
                    ShowMessage("删除成功");
                }
                else
                {
                    ShowMessage("删除失败");
                    return;
                }
                DataBindList();
                this.hf_CheckIDS.Value = "";
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                ShowMessage(ex.Message);
            }
        }
        #endregion


        #region 添加
        protected void btn_Add_Click(object sender, EventArgs e)
        {
            string aa = string.Format("<script language=javascript>window.open('DutyLogEdit.aspx', '_self')</script>");
            Response.Write(aa);
        }
        #endregion


        #region 编辑
        protected void lbtn_Edit_Click(object sender, EventArgs e)
        {
            LinkButton lbt = (LinkButton)sender;
            int logid = Convert.ToInt32(lbt.CommandName.ToString());
            string aa = string.Format("<script language=javascript>window.open('DutyLogEdit.aspx?id={0}', '_self')</script>", logid);
            Response.Write(aa);
        }
        #endregion

    }
}
