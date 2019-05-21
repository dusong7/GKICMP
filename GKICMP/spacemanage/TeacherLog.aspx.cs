/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      樊紫红
** 创建日期:    2017年04月21日 10时49分
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
    public partial class TeacherLog : PageBase
    {
        public SpaceLogDAL logDAL = new SpaceLogDAL();
        public DepartmentDAL departDAL = new DepartmentDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public GradeDAL gradeDAL = new GradeDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();

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

                this.hf_UID.Value = UID.ToString();
                if (UID != UserID)//判断是否当前登录教师日志
                {
                    this.btn_Upload.Visible = false;
                    this.lbtn_ClassSpace.Visible = false;
                    this.lbtn_Lesson.Visible = false;
                    this.lbtn_ClassCul.Text = "他的日志";
                }
                SysUserEntity model = sysUserDAL.GetObjByID(this.hf_UID.Value);
                if (model != null)
                {
                    this.ltl_RealName.Text = model.RealName;
                    this.hf_ClaID.Value = model.DepID.ToString();
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
            SpaceLogEntity model = new SpaceLogEntity(this.hf_UID.Value, -2, -1, -1);
            model.SFlag = 1;
            DataTable dt = logDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model, 2);
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
        /// <summary>
        /// 分页事件
        /// </summary>
        protected void Pager_PageChanged(object sender, EventArgs e)
        {
            DataBindList();
        }
        #endregion


        #region 跳转主页
        /// <summary>
        /// 跳转主页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_ClassHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("TeacherSpace.aspx?id=" + this.hf_UID.Value);
        }
        #endregion


        #region 相册跳转
        /// <summary>
        /// 相册跳转
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_Photo_Click(object sender, EventArgs e)
        {
            Response.Redirect("TeacherPhotos.aspx?id=" + this.hf_UID.Value);
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


        #region 删除事件
        /// <summary>
        /// 删除事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_Detele_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lbtn = (LinkButton)sender;
                string ids = lbtn.CommandArgument.ToString();
                int result = logDAL.DeleteBat(ids);
                if (result > 0)
                {
                    ShowMessage("提交成功");
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除日志信息", UserID));
                }
                else
                {
                    ShowMessage("提交失败");
                    return;
                }
                DataBindList();
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                return;
            }
        }
        #endregion


        #region 设置私密日志
        /// <summary>
        /// 设置私密日志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_PrivateLog_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lbtn = (LinkButton)sender;
                string ids = lbtn.CommandArgument.ToString();
                string text = lbtn.Text.ToString();
                int ispublish = -1;
                if (text == "发布")
                {
                    ispublish = (int)CommonEnum.IsorNot.是;
                }
                else
                {
                    ispublish = (int)CommonEnum.IsorNot.否;
                }
                int result = logDAL.UpdateIsPublish(Convert.ToInt32(ids), ispublish);
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


        #region 协同备课跳转
        protected void lbtn_Lesson_Click(object sender, EventArgs e)
        {
            Response.Redirect("TeacherLesson.aspx?id=" + this.hf_UID.Value);
        }
        #endregion


        #region 跳转班级空间
        protected void lbtn_ClassSpace_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClassList.aspx");
        }
        #endregion


        #region 是否隐藏按钮
        /// <summary>
        /// 是否隐藏按钮
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