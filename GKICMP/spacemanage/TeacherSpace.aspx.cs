/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年03月24日 10时52分04秒
** 描    述:      个人空间
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.spacemanage
{
    public partial class TeacherSpace : PageBase
    {
        public SpaceLogDAL logDAL = new SpaceLogDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();


        #region 参数集合
        /// <summary>
        /// UID 
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
        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SysUserEntity model = null;
                if (UID != "" && UID != UserID)
                {
                    model = sysUserDAL.GetObjByID(UID);
                    this.hf_UserID.Value = UID.ToString();
                    this.lbtn_ClassSpace.Visible = false;
                    this.lbtn_Lesson.Visible = false;
                    this.lbtn_ClassCul.Text = "他的日志";
                }
                else
                {
                    model = sysUserDAL.GetObjByID(UserID);
                    this.hf_UserID.Value = UserID;
                }
                if (model != null)
                {
                    this.ltl_RealName.Text = model.RealName;
                    this.img_Photo.ImageUrl = model.Photos == "" ? "../images/gr_05.png" : model.Photos;
                    this.ltl_Sex.Text = CommonFunction.CheckEnum<CommonEnum.XB>(model.UserSex);
                    this.ltl_Birthday.Text = model.BirthDay.ToString("yyyy") + "年" + model.BirthDay.ToString("MM") + "月";
                    this.ltl_Address.Text = model.Address.ToString();
                    //GetTeacherInfo();
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
            SpaceLogEntity model = new SpaceLogEntity(UserID, (int)CommonEnum.IsorNot.是, -2, -2);
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


        //private void GetTeacherInfo()
        //{
        //    DataTable dt = sysUserDAL.GetSysUserByTeac((int)CommonEnum.UserType.老师, (int)CommonEnum.Deleted.未删除);
        //    if (dt != null && dt.Rows.Count > 0)
        //    {
        //        this.rp_List1.DataSource = dt;
        //        this.rp_List1.DataBind();
        //    }
        //}


        #region 分页
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Pager_PageChanged(object sender, EventArgs e)
        {
            DataBindList();
        }
        #endregion


        #region 我的日志跳转
        /// <summary>
        /// 我的日志跳转
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_ClassCul_Click(object sender, EventArgs e)
        {
            Response.Redirect("TeacherLog.aspx?&id=" + this.hf_UserID.Value.ToString());
        }
        #endregion


        #region 协同备课跳转
        /// <summary>
        /// 协同备课跳转
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_Lesson_Click(object sender, EventArgs e)
        {
            Response.Redirect("TeacherLesson.aspx?&id=" + this.hf_UserID.Value.ToString());
        }
        #endregion


        #region 跳转相册
        /// <summary>
        /// 跳转相册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_Photo_Click(object sender, EventArgs e)
        {
            Response.Redirect("TeacherPhotos.aspx?&id=" + this.hf_UserID.Value.ToString());
        }
        #endregion


        #region 点赞事件
        protected void lbtn_Praise_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lbtn = (LinkButton)sender;
                string ids = lbtn.CommandArgument.ToString();
                int result = logDAL.UpdatePeoNum(Convert.ToInt32(ids), UserID, 1);
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


        #region 跳转班级空间
        protected void lbtn_ClassSpace_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClassList.aspx");
        }
        #endregion
    }
}