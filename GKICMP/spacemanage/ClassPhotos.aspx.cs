/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年03月21日 11点23分
** 描   述:      班级空间
** 修 改 人:      
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
    public partial class ClassPhotos : PageBase
    {
        public DepartmentDAL classDAL = new DepartmentDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public SpacePhotosDAL photoDAL = new SpacePhotosDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();

        #region 参数集合
        /// <summary>
        /// ClaID 班级ID
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
                SysUserEntity model = sysUserDAL.GetObjByID(UserID);
                this.hf_UserType.Value = model.UserType.ToString();
                this.hf_DepID.Value = model.DepID.ToString();
                if ((ClaID == -1 || Deep != 1) && model.UserType == (int)CommonEnum.UserType.老师)
                {
                    this.btn_Upload.Visible = false;
                }
                InfoBind();
                DataBindList();
            }
        }
        #endregion


        #region 初始化用户数据
        /// <summary>
        /// 初始化用户数据
        /// </summary>
        private void InfoBind()
        {
            int clid = -1;
            if (Convert.ToInt32(this.hf_UserType.Value) == (int)CommonEnum.UserType.老师)
            {
                clid = ClaID;
            }
            else
            {
                clid = Convert.ToInt32(this.hf_DepID.Value);
            }
            DataTable dt = classDAL.GetInfo(clid, (int)CommonEnum.Deleted.未删除);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.ltl_GradeName.Text = dt.Rows[0]["GradeName"].ToString();
                this.ltl_ClassName.Text = dt.Rows[0]["DepName"].ToString();
                //this.ltl_Notes.Text = dt.Rows[0]["Notes"].ToString();
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
            DataTable dt = null;
            if (Convert.ToInt32(this.hf_UserType.Value) == (int)CommonEnum.UserType.老师)
            {
                dt = photoDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, Convert.ToInt32(this.hf_ClaID.Value), "", 1);
            }
            else
            {
                dt = photoDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, Convert.ToInt32(this.hf_DepID.Value), "", 1);
            }
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


        #region 跳转班级主页
        /// <summary>
        /// 跳转班级主页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_ClassHome_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.hf_UserType.Value) == (int)CommonEnum.UserType.老师)
            {
                Response.Redirect("ClassSpace.aspx?id=" + this.hf_ClaID.Value + "&deep=" + Deep);
            }
            else
            {
                Response.Redirect("ClassSpace.aspx?id=" + this.hf_DepID.Value + "&deep=" + Deep);
            }
        }
        #endregion


        #region 跳转文化墙
        /// <summary>
        /// 跳转文化墙
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_ClassCul_Click(object sender, EventArgs e)
        {
            string claid = "";
            if (Convert.ToInt32(this.hf_UserType.Value) == (int)CommonEnum.UserType.老师)
            {
                claid = this.hf_ClaID.Value;
            }
            else
            {
                claid = this.hf_DepID.Value;
            }
            Response.Redirect("ClassLog.aspx?claid=" + claid + "&deep=" + Deep);
        }
        #endregion


        #region 分页事件
        /// <summary>
        /// 分页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Pager_PageChanged(object sender, EventArgs e)
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
        protected void lbtn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lbtn = (LinkButton)sender;
                string id = lbtn.CommandArgument.ToString();
                string pname = lbtn.CommandName.ToString();
                int result = photoDAL.DeleteBat(id);
                if (result > 0)
                {
                    ShowMessage("删除成功");
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除名称为【" + pname + "】的照片信息", UserID));
                }
                else
                {
                    ShowMessage("删除失败");
                    return;
                }
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


        #region 判断是否显示删除按钮
        /// <summary>
        /// 判断是否显示删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public bool IsVisible(object sender)
        {
            try
            {
                if (sender.ToString() == UserID)
                {
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        } 
        #endregion
    }
}