/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      樊紫红
** 创建日期:    2017年11月21日 9时04分
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
    public partial class TeacherLesson : PageBase
    {
        public LessonPlan_DetailDAL detailDAL = new LessonPlan_DetailDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();


        #region 参数集合
        /// <summary>
        /// 用户ID
        /// </summary>
        public string UID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        #endregion


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.hf_UID.Value = UID.ToString();
                if (UID != UserID)
                {
                    this.lbtn_ClassSpace.Visible = false;
                    this.lbtn_ClassCul.Text = "他的日志";
                }

                SysUserEntity model = sysUserDAL.GetObjByID(this.hf_UID.Value);
                if (model != null)
                {
                    this.ltl_RealName.Text = model.RealName;
                }
                DataBindList();
            }
        }
        #endregion


        #region 页面跳转
        /// <summary>
        /// 个人主页跳转
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_ClassHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("TeacherSpace.aspx?id=" + this.hf_UID.Value);
        }
        /// <summary>
        /// 我的日志跳转
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_ClassCul_Click(object sender, EventArgs e)
        {
            Response.Redirect("TeacherLog.aspx?id=" + this.hf_UID.Value);
        }
        /// <summary>
        /// 教学工作室跳转
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_Photo_Click(object sender, EventArgs e)
        {
            Response.Redirect("TeacherPhotos.aspx?id=" + this.hf_UID.Value);
        }
        /// <summary>
        /// 班级空间跳转
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_ClassSpace_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClassList.aspx");
        }
        #endregion


        #region 数据绑定
        private void DataBindList()
        {
            int recordCount = -1;
            DataTable dt = detailDAL.GetPersonPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, "", "", -2, this.hf_UID.Value);
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


        #region 分页事件
        protected void Pager_PageChanged(object sender, EventArgs e)
        {
            DataBindList();
        }
        #endregion


        #region 备课事件
        protected void lbtn_Bill_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            string ispre = lbtn.CommandName.ToString();

            string param = lbtn.CommandArgument.ToString();
            string[] paramstr = param.Split(',');

            Response.Write("<script language=javascript>window.open('../lessonplan/LessonEdit.aspx?ldid=" + paramstr[0].ToString() + "&lid=" + paramstr[1].ToString() + "&ltype=" + paramstr[2].ToString() + "&isprepare=" + ispre + "&flag=3" + "', '_self')</script>");
        }
        #endregion


        #region 判断是否隐藏
        public bool IsVisible()
        {
            try
            {
                if (UID == UserID)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return true;
            }
        } 
        #endregion
    }
}