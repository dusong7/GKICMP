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
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;


namespace GKICMP.meeting
{
    public partial class MeetingManage : PageBase
    {
        MeetingDAL mDAL = new MeetingDAL();
        public ClassRoomDAL croomDAL = new ClassRoomDAL();
        SysLogDAL sysLogDAL = new SysLogDAL();

        #region 参数集合
        /// <summary>
        /// flag 1:个人申请页面 2:审核页面
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
                if (Flag == 1)
                {
                    //this.btn_Audit.Visible = false;
                    this.lbtn_Audit.Visible = false;
                }
                else
                {
                    this.btn_Add.Visible = false;
                    this.btn_Delete.Visible = false;
                }
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
            model.CreateUser = UserID;
            DataTable dt = mDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model, Flag);
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

            if (Flag == 2)
            {
                this.th1.Visible = false;
                for (int i = 0; i < rp_List.Items.Count; i++)
                {
                    HtmlTableCell td1 = (HtmlTableCell)this.rp_List.Items[i].FindControl("td1");
                    td1.Visible = false;
                }
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
                int result = mDAL.DeleteBat(ids, (int)CommonEnum.Deleted.删除);
                if (result > 0)
                {
                    ShowMessage("删除成功");
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除会议信息", UserID));
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
            Response.Write("<script language=javascript>window.open('MeetingEdit.aspx?id=" + id + "', '_self')</script>");
        }
        #endregion


        #region 添加跳转
        /// <summary>
        /// 添加跳转
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Add_Click(object sender, EventArgs e)
        {
            Response.Write("<script language=javascript>window.open('MeetingEdit.aspx', '_self')</script>");
        }
        #endregion
    }
}