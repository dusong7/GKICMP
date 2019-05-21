/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年8月25日 16点39分
** 描   述:      个人相册
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
    public partial class TeacherPhotos : PageBase
    {
        public DepartmentDAL departDAL = new DepartmentDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public SpacePhotosDAL photoDAL = new SpacePhotosDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public HomeWorkDAL workDAL = new HomeWorkDAL();
        public EduResourceDAL eduResourceDAL = new EduResourceDAL();
        public SysLogDAL ssysLogDAL = new SysLogDAL();

        #region 参数集合
        /// <summary>
        /// 学生ID UID
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
                if (UID != UserID)//判断是否当前登录教师
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
                ResBind();
            }
        }
        #endregion


        #region 作业绑定
        /// <summary>
        /// 作业绑定
        /// </summary>
        private void DataBindList()
        {
            DataTable dt = workDAL.GetList(this.hf_UID.Value, 2);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.li1.Visible = false;
            }
            else
            {
                this.li1.Visible = true;
            }
            this.rp_List.DataSource = dt;
            this.rp_List.DataBind();
        }
        #endregion


        #region 资源数据绑定
        /// <summary>
        /// 资源数据绑定
        /// </summary>
        /// <param name="rtypes"></param>
        public void ResBind()
        {
            int recordCount = 0;
            EduResourceEntity model = new EduResourceEntity();
            model.ResourseName = "";
            model.GID = -2;
            model.TID = -2;
            model.EType = -2;
            model.CreateUser = this.hf_UID.Value;
            Pager.PageSize = 4;
            DataTable dt = eduResourceDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model, 1);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.tr_null.Visible = false;
            }
            else
            {
                this.tr_null.Visible = true;
            }
            this.rp_ResList.DataSource = dt;
            Pager.RecordCount = recordCount;
            this.rp_ResList.DataBind();
        }
        #endregion


        #region 获取图标
        /// <summary>
        /// 获取图标
        /// </summary>
        /// <param name="lastname"></param>
        /// <returns></returns>
        public string GetPic(object lastname)
        {
            string pname = "";
            if (lastname.ToString() == "jpg" || lastname.ToString() == "gif" || lastname.ToString() == "png" || lastname.ToString() == "jpeg" || lastname.ToString() == "psd" || lastname.ToString() == "bmp")
            {
                pname = "../images/image_icon.png";
            }
            else if (lastname.ToString() == "xls" || lastname.ToString() == "xlsx")
            {
                pname = "../images/execl_icon.png";
            }
            else if (lastname.ToString() == "doc" || lastname.ToString() == "docx" || lastname.ToString() == "wps")
            {
                pname = "../images/zy_5.png";
            }
            else if (lastname.ToString() == "ppt" || lastname.ToString() == "pps" || lastname.ToString() == "ppsx")
            {
                pname = "../images/ppt_icon.png";
            }
            else if (lastname.ToString() == "txt")
            {
                pname = "../images/zy_12.png";
            }
            else if (lastname.ToString() == "zip" || lastname.ToString() == "rar")
            {
                pname = "../images/zy_13.png";
            }
            else
            {
                pname = "../images/unknow_icon.png";
            }
            return pname;
        }
        #endregion


        #region 获取大小
        /// <summary>
        /// 获取大小
        /// </summary>
        /// <param name="sizes"></param>
        /// <returns></returns>
        public string GetSize(object sizes)
        {
            string ResourceSize = "";
            int size = Convert.ToInt32(sizes.ToString());
            if (size >= 1024 * 1024)
            {
                ResourceSize = size / 1024 / 1024 + "M";
            }
            else
            {
                ResourceSize = size / 1024 + "kb";
            }
            return ResourceSize;
        }
        #endregion


        #region 下载事件
        /// <summary>
        /// 下载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_DownLoad_Click(object sender, EventArgs e)
        {
            DataBindList();
            try
            {
                string RID = ((LinkButton)sender).CommandArgument;
                EduResourceEntity model = eduResourceDAL.GetObjByID(Convert.ToInt32(RID));
                string accessid = model.ResourseUrl;
                string name = ((LinkButton)sender).CommandName;

                if (!CommonFunction.UpLoadFunciotn(accessid, name))
                {
                    ShowMessage("下载文件不存在，请联系系统管理员");
                    return;
                }
                else
                {
                    eduResourceDAL.UpdateNum(Convert.ToInt32(RID));
                    DataBindList();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alertsuccess", "<script>alert('系统提示：下载成功！');</script>");
                }
            }
            catch (Exception ex)
            {
                ShowMessage("下载文件过程中出现问题，请联系系统管理员");
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                return;
            }
        }
        #endregion


        #region 个人主页跳转
        /// <summary>
        /// 个人主页跳转
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_ClassHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("TeacherSpace.aspx?id=" + this.hf_UID.Value);
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
            Response.Redirect("TeacherLog.aspx?id=" + this.hf_UID.Value);
        }
        #endregion


        #region 协同备课跳转
        protected void lbtn_Lesson_Click(object sender, EventArgs e)
        {
            Response.Redirect("TeacherLesson.aspx?id=" + this.hf_UID.Value);
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
                int result = workDAL.DeleteBat(id);
                if (result > 0)
                {
                    ShowMessage("删除成功");
                    ssysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除作业布置信息", UserID));
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


        #region 跳转班级空间
        protected void lbtn_ClassSpace_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClassList.aspx");
        }
        #endregion


        public bool IsVisible(object sender, object uid)
        {
            try
            {
                if (sender.ToString() == "1" || uid.ToString() != UserID)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return true;
            }
        }
    }
}