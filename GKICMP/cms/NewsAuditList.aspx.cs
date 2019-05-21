/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      lfz
** 创建日期:    2016年11月08日
** 描 述:       新闻栏目编辑页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using System.Data;
using GK.GKICMP.DAL;

namespace GKICMP.cms
{
    public partial class NewsAuditList : PageBase
    {
        public Web_NewsDAL web_NewsDAL = new Web_NewsDAL();
        public Web_MenuDAL web_MenuDAL = new Web_MenuDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();


        #region 参数集合
        public int Flag
        {
            get { return GetQueryString<int>("flag", -1); }
        }
        #endregion


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
                DataTable dt = web_MenuDAL.GetTable((int)CommonEnum.Deleted.未删除);
                CommonFunction.DDlTypeBind(this.ddl_MName, dt, "MID", "MName", "-2");
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
            ViewState["BName"] = CommonFunction.GetCommoneString(this.txt_BName.Text.ToString().Trim());
        }
        #endregion


        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {
            int recordCount = -1;
            Web_NewsEntity model = new Web_NewsEntity((string)ViewState["BName"], this.ddl_MName.SelectedValue, (int)CommonEnum.Deleted.未删除);
            model.AduitUser = UserID;
            if (Flag != 2)
                model.AuditState = (int)CommonEnum.NewsAuditState.未审;
            else
                model.AuditState = -2;
            DataTable dt = web_NewsDAL.GetNewsAuditPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
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
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            Pager.CurrentPageIndex = 1;
            GetCondition();
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
                int result = web_NewsDAL.DeleteBat(ids, (int)CommonEnum.Deleted.删除);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除新闻信息", UserID));
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
                ShowMessage(ex.Message);
                return;
            }
        }
        #endregion


        #region 发布
        protected void btn_Publish_Click(object sender, EventArgs e)
        {
            try
            {
                string ids = this.hf_CheckIDS.Value.ToString();
                ids = ids.TrimEnd(',').TrimStart(',');

                int result = web_NewsDAL.Update(ids, (int)CommonEnum.IsorNot.是);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "发布新闻信息", UserID));
                    ShowMessage("发布成功");
                }
                else
                {
                    ShowMessage("发布失败");
                    return;
                }
                DataBindList();
                this.hf_CheckIDS.Value = "";
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                ShowMessage(ex.Message);
                return;
            }
        }
        #endregion


        #region 添加
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Add_Click(object sender, EventArgs e)
        {
            string aa = string.Format("<script language=javascript>window.open('NewsEdit.aspx?id={0}', '_self')</script>", "");
            Response.Write(aa);
        }
        #endregion


        #region 编辑
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_Edit_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            string id = lbtn.CommandArgument.ToString();
            string aa = string.Format("<script language=javascript>window.open('NewsEdit.aspx?id={0}&flag=1', '_self')</script>", id);//flag:1:审核列表页面
            Response.Write(aa);
        }
        #endregion


        #region 详情
        protected void lbtn_Detail_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            string id = lbtn.CommandArgument.ToString();
            string aa = string.Format("<script language=javascript>window.open('NewsDetail.aspx?id={0}','_self')</script>", id);
            Response.Write(aa);
        }
        #endregion
        //#region 详情
        //protected void lbtn_Audit_Click(object sender, EventArgs e)
        //{
        //    LinkButton lbtn = (LinkButton)sender;
        //    string id = lbtn.CommandArgument.ToString();
        //    string aa = string.Format("<script language=javascript>window.open('NewsAudit.aspx?id={0}','_self')</script>", id);
        //    Response.Write(aa);
        //}
        //#endregion

        #region 审核
        protected void lbtn_Audit_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            string id = lbtn.CommandArgument.ToString();
            string aa = string.Format("<script language=javascript>window.open('NewsAudit.aspx?id={0}','_self')</script>", id);
            Response.Write(aa);
        }
        #endregion


        #region 复选框是否可选
        protected string Gettrue(object nstate)
        {
            if (Convert.ToInt32(nstate.ToString() == "" ? "0" : nstate.ToString()) == (int)CommonEnum.NewsAuditState.未审)
            {
                return "";
            }
            else
            {
                return "disabled";
            }
        }
        #endregion
    }
}