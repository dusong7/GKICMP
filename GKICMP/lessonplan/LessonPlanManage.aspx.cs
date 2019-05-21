/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年10月19日 16时25分46秒
** 描    述:      排课计划操作类
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Data;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.lessonplan
{
    public partial class LessonPlanManage : PageBase
    {
        public LessonPlanDAL planDAL = new LessonPlanDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public BaseDataDAL baseDataDAL = new BaseDataDAL();
        public CampusDAL campusDAL = new CampusDAL();

        #region 参数集合
        /// <summary>
        /// Flag 1：备课计划 2：我的备课计划
        /// </summary>
        public int Flag
        {
            get
            {
                return GetQueryString<int>("flag", -1);
            }
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
                DataTable dtType = baseDataDAL.GetList((int)CommonEnum.BaseDataType.备课类型, -1);
                CommonFunction.DDlTypeBind(this.ddl_LType, dtType, "SDID", "DataName", "-2");

                DataTable dtCampus = campusDAL.GetList((int)CommonEnum.Deleted.未删除);
                CommonFunction.DDlTypeBind(this.ddl_CID, dtCampus, "CID", "CampusName", "-2");

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
            ViewState["LName"] = CommonFunction.GetCommoneString(this.txt_LName.Text.ToString().Trim());
            ViewState["CID"] = this.ddl_CID.SelectedValue.ToString();
            ViewState["LType"] = this.ddl_LType.SelectedValue.ToString();
        }
        #endregion


        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {
            int recordCount = -1;
            LessonPlanEntity model = new LessonPlanEntity((string)ViewState["LName"], Convert.ToInt32(ViewState["CID"].ToString()), Convert.ToInt32(ViewState["LType"].ToString()));
            DataTable dt = planDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model, UserID, Flag);
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

                int result = planDAL.DeleteBat(ids);
                if (result > 0)
                {
                    ShowMessage("删除成功");
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除备课计划信息", UserID));
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
            }
        }
        #endregion


        //#region 备课事件
        //protected void lbtn_Prepare_Click(object sender, EventArgs e)
        //{
        //    LinkButton lbtn = (LinkButton)sender;
        //    string id = lbtn.CommandArgument.ToString();
        //    string ltype = lbtn.CommandName.ToString();

        //    Response.Write("<script language=javascript>window.open('LessonManage.aspx?lid=" + id + "&ltype=" + ltype + "', '_self')</script>");
        //}
        //#endregion


        #region 计划清单
        protected void lbtn_Bill_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            string id = lbtn.CommandArgument.ToString();
            string ltype = lbtn.CommandName.ToString();

            Response.Write("<script language=javascript>window.open('LessonPlanBillManage.aspx?lid=" + id + "&ltype=" + ltype + "', '_self')</script>");
        }
        #endregion


        #region 详情跳转
        protected void lbtn_Detail_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            string id = lbtn.CommandArgument.ToString();
            string ltype = lbtn.CommandName.ToString();

            Response.Write("<script language=javascript>window.open('LessonPlanDetail.aspx?lid=" + id + "&ltype=" + ltype + "', '_self')</script>");
        }
        #endregion
    }
}