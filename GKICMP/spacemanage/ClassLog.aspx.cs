/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      樊紫红
** 创建日期:    2017年8月25日 10时14分
** 描 述:       班级日志
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

namespace GKICMP.spacemanage
{
    public partial class ClassLog : PageBase
    {
        public SpaceLogDAL logDAL = new SpaceLogDAL();
        public DepartmentDAL departDAL = new DepartmentDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public SpaceThumbsDAL SpaceThumbsDAL = new SpaceThumbsDAL();

        #region 参数集合
        /// <summary>
        /// 
        /// </summary>
        public int ClaID
        {
            get
            {
                return GetQueryString<int>("claid", -1);
            }
        }

        public int Deep
        {
            get
            {
                return GetQueryString<int>("deep", -1);
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
                this.hf_ClaID.Value = ClaID.ToString();
                DataTable dt = departDAL.GetInfo(ClaID, (int)CommonEnum.Deleted.未删除);
                if (dt != null && dt.Rows.Count > 0)
                {
                    this.ltl_GradeName.Text = dt.Rows[0]["GradeName"].ToString();
                    this.ltl_ClassName.Text = dt.Rows[0]["DepName"].ToString();
                }
                SysUserEntity model = sysUserDAL.GetObjByID(UserID);
                if ((ClaID == -1 || Deep != 1) && model.UserType == (int)CommonEnum.UserType.老师)
                {
                    this.btn_Upload.Visible = false;
                }

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
            SpaceLogEntity model = new SpaceLogEntity(UserID, (int)CommonEnum.IsorNot.是, ClaID, (int)CommonEnum.AduitState.通过);
            model.SFlag = 1;
            DataTable dt = logDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model, 1);
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
        }
        #endregion


        #region 跳转主页页面
        /// <summary>
        /// 跳转主页页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_ClassHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClassSpace.aspx?id=" + ClaID.ToString() + "&deep=" + Deep);
        }
        #endregion


        #region 跳转相册页面
        /// <summary>
        /// 跳转相册页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_Photo_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClassPhotos.aspx?claid=" + ClaID + "&deep=" + Deep);
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


        #region 点赞事件
        /// <summary>
        /// 点赞事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_Praise_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lbtn = (LinkButton)sender;
                string ids = lbtn.CommandArgument.ToString();
                int result = logDAL.UpdatePeoNum(Convert.ToInt32(ids),UserID,1);
                if (result > 0)
                {
                    DataBindList();
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                return;
            }
        }
        #endregion
        public string GetDZ(object id) 
        {
            DataTable dt = SpaceThumbsDAL.GetByUser(UserID,id.ToString(),1);
            if (dt != null && dt.Rows.Count > 0)
                return "取消赞";
            return "赞";
        }
    }
}