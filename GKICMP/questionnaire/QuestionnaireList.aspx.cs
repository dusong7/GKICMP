/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      lfz
** 创建日期:      2016年12月29日 13时46分17秒
** 描    述:      问卷管理页
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using System.Data;
using GK.GKICMP.Entities;


namespace GKICMP.questionnaire
{
    public partial class QuestionnaireList : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public QuestionnaireDAL questionnaireDAL = new QuestionnaireDAL();
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
            ViewState["QuestName"] = this.txt_QuestName.Text.ToString();
            ViewState["Begin"] = this.txt_Begin.Text == "" ? "1900-01-01" : this.txt_Begin.Text.ToString();
            ViewState["End"] = this.txt_End.Text == "" ? "9999-12-31" : this.txt_End.Text.ToString();
        }
        #endregion


        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {
            int recordCount = -1;
            QuestionnaireEntity model = new QuestionnaireEntity();
            model.QuestName = (string)ViewState["QuestName"];
            model.Isdel = (int)CommonEnum.Deleted.未删除;
            DataTable dt = questionnaireDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model, Convert.ToDateTime(ViewState["Begin"].ToString()), Convert.ToDateTime(ViewState["End"].ToString()));
            if (dt.Rows.Count > 0 && dt != null)
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


        #region 查看事件
        /// <summary>
        /// 查看事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_Result_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lbtn = (LinkButton)sender;
                string ids = lbtn.CommandArgument.ToString();
                string aa = string.Format("<script language=javascript>window.open('QuestionResult.aspx?id={0}', '_self')</script>", ids);
                Response.Write(aa);
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                return;
            }
        }
        #endregion


        #region 删除事件
        /// <summary>
        /// 删除事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lbtn = (LinkButton)sender;
                string ids = lbtn.CommandArgument.ToString();

                int result = questionnaireDAL.DeleteBat(ids, (int)CommonEnum.Deleted.删除);
                if (result > 0)
                {
                    ShowMessage("删除成功");
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除考试信息", UserID));
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
                ShowMessage(ex.Message);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                return;
            }
        }
        #endregion

        public string getValue(object obj)
        {
            if (obj.ToString() == UserID)
                return "true";
            else
                return "false";
        }


        #region 发布事件
        /// <summary>
        /// 发布事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Publish_Click(object sender, EventArgs e)
        {
            try
            {
                string ids = this.hf_CheckIDS.Value.ToString();
                ids = ids.TrimEnd(',').TrimStart(',');
                QuestionnaireEntity model = new QuestionnaireEntity();
                model.IsPublish = (int)CommonEnum.IsorNot.是;
                model.Isdel = (int)CommonEnum.Deleted.未删除;
                int result = questionnaireDAL.UpdateIsPublic(model, ids);
                if (result > 0)
                {
                    ShowMessage("发布成功");
                }
                DataBindList();
                this.hf_CheckIDS.Value = "";
            }
            catch (Exception ex)
            {
                ShowMessage("发布失败");
                return;
            }
        }
        #endregion


        #region 取消发布
        /// <summary>
        /// 取消发布
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_CancelPublic_Click(object sender, EventArgs e)
        {
            try
            {
                string ids = this.hf_CheckIDS.Value.ToString();
                ids = ids.TrimEnd(',').TrimStart(',');
                QuestionnaireEntity model = new QuestionnaireEntity();
                model.IsPublish = (int)CommonEnum.IsorNot.否;
                model.Isdel = (int)CommonEnum.Deleted.未删除;
                int result = questionnaireDAL.UpdateIsPublic(model, ids);
                if (result > 0)
                {
                    ShowMessage("取消发布成功");
                }
                DataBindList();
                this.hf_CheckIDS.Value = "";
            }
            catch (Exception ex)
            {
                ShowMessage("取消发布失败");
                return;
            }
        }
        #endregion


        #region 详细事件
        /// <summary>
        /// 详细事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_Detail_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lbtn = (LinkButton)sender;
                string id = lbtn.CommandArgument.ToString();
                string aa = string.Format("<script language=javascript>window.open('QuestionnaireDetail.aspx?id={0}', '_self')</script>", id);
                Response.Write(aa);
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                return;
            }
        }
        #endregion
    }
}