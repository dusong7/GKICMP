/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年08月22日 18时36分01秒
** 描    述:      考核标准管理页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Data;
using System.Text;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.performance
{
    public partial class PerformanceManage : PageBase
    {
        public Lecture_StandardDAL standardDAL = new Lecture_StandardDAL();
        public PerformanceDAL perDAL = new PerformanceDAL();
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
                CommonFunction.BindEnum<CommonEnum.State>(this.ddl_IsUse, "-2");

                ViewState["PerName"] = CommonFunction.GetCommoneString(this.txt_PerName.Text.ToString().Trim());
                ViewState["IsUse"] = this.ddl_IsUse.SelectedValue.ToString();
                DataBindList();
            }
        }
        #endregion


        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {
            int recordCount = -1;
            PerformanceEntity model = new PerformanceEntity((string)ViewState["PerName"], Convert.ToInt32(ViewState["IsUse"].ToString()), (int)CommonEnum.Deleted.未删除);
            DataTable dt = perDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.tr_null.Visible = false;
            }
            else
            {
                this.tr_null.Visible = true; ;
            }
            this.rp_List.DataSource = dt;
            Pager.RecordCount = recordCount;
            this.rp_List.DataBind();
            this.hf_CheckIDS.Value = "";
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
                int result = perDAL.DeleteBat(ids, (int)CommonEnum.Deleted.删除);
                if (result > 0)
                {
                    ShowMessage("删除成功");
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除考核信息", UserID));
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
                ShowMessage(ex.Message);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                return;
            }
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
            ViewState["PerName"] = CommonFunction.GetCommoneString(this.txt_PerName.Text.ToString().Trim());
            ViewState["IsUse"] = this.ddl_IsUse.SelectedValue.ToString();
            DataBindList();
        }
        #endregion


        #region 分页事件
        /// <summary>
        /// 分页事件
        /// </summary>
        protected void Pager_PageChanged(object sender, EventArgs e)
        {
            DataBindList();
        }
        #endregion


        #region 获取禁用日期
        /// <summary>
        /// 获取禁用日期
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public string GetDate(object sender)
        {
            try
            {
                if (Convert.ToDateTime(sender.ToString()).ToString("yyyy-MM-dd") == "9999-12-31")
                {
                    return "";
                }
                else
                {
                    return Convert.ToDateTime(sender.ToString()).ToString("yyyy-MM-dd");
                }
            }
            catch
            {
                return "";
            }
        }
        #endregion

        protected void lbtn_Add_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            string id = lbtn.CommandArgument.ToString();
            Response.Write("<script language=javascript>window.open('PerformanceStandard.aspx?id=" + id + "', '_self')</script>");
        }
    }
}