/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      樊紫红
** 创建日期:    2017年03月20日 15时20分
** 描 述:       班级空间页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.spacemanage
{
    public partial class ClassSpace : PageBase
    {
        public DepartmentDAL departDAL = new DepartmentDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public AfficheDAL afficheDAL = new AfficheDAL();
        public SpaceCommentDAL commentDAL = new SpaceCommentDAL();

        #region 参数集合
        /// <summary>
        /// ClaID 班级ID
        /// </summary>
        public int ClaID
        {
            get
            {
                return GetQueryString<int>("id", -1);
            }
        }

        /// <summary>
        /// Deep 
        /// </summary>
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
                SysUserEntity model = sysUserDAL.GetObjByID(UserID);
                this.hf_UserType.Value = model.UserType.ToString();
                this.hf_DepID.Value = model.DepID.ToString();
                if ((ClaID == -1 || Deep != 1) && model.UserType == (int)CommonEnum.UserType.老师)
                {
                    this.btn_Upload.Visible = false;
                }
                if (ClaID == -1 || Deep == 1)
                {
                    InfoBind();
                    MessageBind();
                }
            }
        }
        #endregion


        #region 数据绑定
        /// <summary>
        /// 数据绑定
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
            this.hf_ClaID.Value = clid.ToString();
            DataTable dt = departDAL.GetInfo(clid, (int)CommonEnum.Deleted.未删除);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.ltl_GradeName.Text = dt.Rows[0]["GradeName"].ToString();
                this.ltl_ClassName.Text = dt.Rows[0]["DepName"].ToString();
                this.ltl_DutyUser.Text = dt.Rows[0]["TeacherName"].ToString();
                this.ltl_ClassCount.Text = dt.Rows[0]["ClassCount"].ToString();
                this.ltl_GradeUser.Text = dt.Rows[0]["GradeUser"].ToString();
            }
            DataTable dtAffiche = afficheDAL.GetInfo(clid);
            if (dtAffiche != null && dtAffiche.Rows.Count > 0)
            {
                this.li1.Visible = false;
            }
            else
            {
                this.li1.Visible = true;
            }
            this.rp_List.DataSource = dtAffiche;
            this.rp_List.DataBind();
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
            if (Convert.ToInt32(this.hf_UserType.Value) == (int)CommonEnum.UserType.老师)
            {
                Response.Redirect("ClassPhotos.aspx?claid=" + ClaID + "&deep=" + Deep);
            }
            else
            {
                Response.Redirect("ClassPhotos.aspx?claid=" + Convert.ToInt32(this.hf_DepID.Value) + "&deep=" + Deep);
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
                claid = ClaID.ToString();
            }
            else
            {
                claid = this.hf_DepID.Value;
            }
            Response.Redirect("ClassLog.aspx?claid=" + claid + "&deep=" + Deep);
        }
        #endregion


        #region 留言绑定
        /// <summary>
        /// 留言绑定
        /// </summary>
        private void MessageBind()
        {
            int recordCount = -1;
            int clid = -1;
            if (Convert.ToInt32(this.hf_UserType.Value) == (int)CommonEnum.UserType.老师)
            {
                clid = ClaID;
            }
            else
            {
                clid = Convert.ToInt32(this.hf_DepID.Value);
            }
            DataTable dt = commentDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, clid, 3);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.li2.Visible = false;
            }
            else
            {
                this.li2.Visible = true;
            }
            this.rp_MassageList.DataSource = dt;
            Pager.RecordCount = recordCount;
            this.rp_MassageList.DataBind();
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
            MessageBind();
        }
        #endregion


        public string GetPhoto(object usertype)
        {
            try
            {
                if (Convert.ToInt32(usertype.ToString()) == (int)CommonEnum.UserType.老师)
                {
                    return "../images/teaicon.png";
                }
                else
                {
                    return "../images/stuicon.png";
                }
            }
            catch
            {
                return "../images/noface.png";
            }
        }
    }
}