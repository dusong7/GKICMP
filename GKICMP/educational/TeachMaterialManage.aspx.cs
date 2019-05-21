/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年05月27日 10时26分11秒
** 描    述:      教材操作类
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Data;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using System.Web.UI.WebControls;

namespace GKICMP.educational
{
    public partial class TeachMaterialManage : PageBase
    {
        public TeachMaterialDAL materDAL = new TeachMaterialDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public TeachMaterialVersionDAL versionDAL = new TeachMaterialVersionDAL();

        #region 参数集合
        /// <summary>
        /// 版本ID
        /// </summary>
        public int TVMID
        {
            get
            {
                return GetQueryString<int>("tmvid", -1);
            }
        }

        /// <summary>
        /// 课程ID
        /// </summary>
        public int CID
        {
            get
            {
                return GetQueryString<int>("cid", -1);
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
                //DataTable dt = versionDAL.GetList();
                //CommonFunction.DDlTypeBind(this.ddl_TEdition, dt, "TMVID", "VersionName", "-2");

                this.hf_CID.Value = CID.ToString();
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
            ViewState["TMName"] = CommonFunction.GetCommoneString(this.txt_TMName.Text.ToString().Trim());
            //ViewState["TEdition"] = this.ddl_TEdition.SelectedValue.ToString();
        }
        #endregion


        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {
            int recordCount = -1;

            TeachMaterialEntity model = new TeachMaterialEntity((string)ViewState["TMName"], TVMID, CID, (int)CommonEnum.Deleted.未删除);
            DataTable dt = materDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
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
        protected void lbtn_Deleted_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lbtn = (LinkButton)sender;

                string ids = lbtn.CommandArgument.ToString();
                int result = materDAL.DeleteBat(Convert.ToInt32(ids), TVMID, CID, (int)CommonEnum.Deleted.删除);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除教材信息", UserID));
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script>alert('系统提示：提交成功！');succ();</script>");
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
                return;
            }
        }
        #endregion
    }
}