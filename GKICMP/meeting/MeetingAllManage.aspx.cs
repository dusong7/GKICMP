/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      樊紫红
** 创建日期:    2017年08月15日 08时30分
** 描 述:       会议管理页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.meeting
{
    public partial class MeetingAllManage : PageBase
    {
        MeetingDAL mDAL = new MeetingDAL();
        public ClassRoomDAL croomDAL = new ClassRoomDAL();
        SysLogDAL sysLogDAL = new SysLogDAL();

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
                DataTable dt = croomDAL.GetList("-2", 2, (int)CommonEnum.Deleted.未删除, (int)CommonEnum.DorState.可用);
                CommonFunction.DDlTypeBind(this.ddl_MeetingRoom, dt, "CRID", "RoomName", "-2");
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
            ViewState["MTitle"] = CommonFunction.GetCommoneString(this.txt_MTitle.Text.Trim());
            ViewState["MeetingRoom"] = this.ddl_MeetingRoom.SelectedValue;
        }
        #endregion


        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {
            int recordCount = -1;
            MeetingEntity model = new MeetingEntity((string)ViewState["MTitle"], Convert.ToInt32(ViewState["MeetingRoom"].ToString()), (int)CommonEnum.Deleted.未删除);
            model.AuditState = (int)CommonEnum.PraState.通过;
            DataTable dt = mDAL.GetAllPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
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


        #region 详情事件
        /// <summary>
        /// 详情事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_Detail_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            string id = lbtn.CommandArgument.ToString();
            string aa = string.Format("<script language=javascript>window.open('MeetingDetail.aspx?id={0}', '_self')</script>", id);
            Response.Write(aa);
        }
        #endregion
    }
}