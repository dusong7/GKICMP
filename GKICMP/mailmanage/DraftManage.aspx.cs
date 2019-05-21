/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      樊紫红
** 创建日期:    2017年8月21日 15时41分
** 描 述:       草稿箱管理页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.mailmanage
{
    public partial class DraftManage : PageBase
    {
        public EmailDAL emailDAL = new EmailDAL();
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
                CommonFunction.BindEnum<CommonEnum.RecType>(this.ddl_EType, "-2");
                GetCondition();
                DataBindList();
            }
        }
        #endregion


        #region 获取查询条件
        /// <summary>
        /// 获取查询条件
        /// </summary>
        private void GetCondition()
        {
            ViewState["EmailTitle"] = CommonFunction.GetCommoneString(this.txt_EmailTitle.Text.ToString().Trim());
            ViewState["BeginDate"] = this.txt_Begin.Text.ToString().Trim() == "" ? "1900-01-01 00:00" : this.txt_Begin.Text.ToString().Trim();
            ViewState["EndDate"] = this.txt_End.Text.ToString().Trim() == "" ? "9999-12-31 23:59" : this.txt_End.Text.ToString().Trim();
            ViewState["EType"] = this.ddl_EType.SelectedValue.ToString();
        }
        #endregion


        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {
            int recordCount = -1;
            EmailEntity model = new EmailEntity();
            model.EmailTitle = (string)ViewState["EmailTitle"];
            model.EType = Convert.ToInt32(ViewState["EType"].ToString());
            model.SendUser = UserID;
            model.Isdel = (int)CommonEnum.Deleted.未删除;
            DateTime begindate = Convert.ToDateTime(ViewState["BeginDate"].ToString());
            DateTime enddate = Convert.ToDateTime(ViewState["EndDate"].ToString());
            DataTable dt = emailDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model, begindate, enddate, 3);//3：草稿箱
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


        #region 查询事件
        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            Pager.CurrentPageIndex = 1;
            GetCondition();
            DataBindList();
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
                string ids = this.hf_CheckIDS.Value.ToString();
                ids = ids.TrimEnd(',').TrimStart(',');
                int result = emailDAL.DeleteBat(ids, 3);//3表示从数据中完全删除
                if (result > 0)
                {
                    ShowMessage("删除成功");
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除发件箱邮件信息", UserID));
                }
                else
                {
                    ShowMessage("删除失败");
                    return;
                }
                this.hf_CheckIDS.Value = "";
                DataBindList();
            }
            catch (Exception ex)
            {
                ShowMessage();
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                return;
            }
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
            string id = lbtn.CommandArgument;
            Response.Write("<script language=javascript>window.open('EmailEdit.aspx?id=" + id + "', '_self')</script>");
        }
        #endregion


        #region 提交事件
        /// <summary>
        /// 提交事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                string ids = this.hf_CheckIDS.Value.ToString();
                ids = ids.TrimEnd(',').TrimStart(',');
                int result = emailDAL.UpdateSubmit(ids, (int)CommonEnum.IsorNot.是, (int)CommonEnum.Deleted.未删除);

                if (result > 0)
                {
                    ShowMessage("提交成功");
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "提交邮件信息", UserID));
                }
                else
                {
                    ShowMessage("提交失败");
                    return;
                }
                this.hf_CheckIDS.Value = "";
                DataBindList();
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                return;
            }
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
            string aa = string.Format("<script language=javascript>window.open('EmailDetail.aspx?id={0}&flag=1', '_self')</script>", id);
            Response.Write(aa);
        } 
        #endregion
    }
}