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
    public partial class PersonSpace : PageBase
    {
        public HomeWorkDAL workDAL = new HomeWorkDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public DepartmentDAL departDAL = new DepartmentDAL();
        public GradeDAL gradeDAL = new GradeDAL();
        public EduResourceDAL eduResourceDAL = new EduResourceDAL();


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
                if (UID != "")
                {
                    model = sysUserDAL.GetObjByID(UID);
                    this.hf_UserID.Value = UID.ToString();
                }
                else
                {
                    model = sysUserDAL.GetObjByID(UserID);
                    this.hf_UserID.Value = UserID;
                }
                if (model != null)
                {
                    //DataTable dt = sysUserDAL.GetTable(model.DepID);
                    //if (dt != null && dt.Rows.Count > 0)
                    //{
                    //    this.rp_List1.DataSource = dt;
                    //    this.rp_List1.DataBind();
                    //}
                    this.hf_DepID.Value = model.DepID.ToString();
                    this.ltl_RealName.Text = model.RealName;
                    this.img_Photo.ImageUrl = model.Photos == "" ? "../images/gr_05.png" : model.Photos;
                    this.ltl_Sex.Text = CommonFunction.CheckEnum<CommonEnum.XB>(model.UserSex.ToString());
                    this.ltl_Birthday.Text = model.BirthDay.ToString("yyyy") + "年" + model.BirthDay.ToString("MM") + "月";
                    this.ltl_Address.Text = model.Address.ToString();
                    //DepartmentEntity cmodel = departDAL.GetObj(Convert.ToInt32(model.DepID));
                    //GradeEntity gmodel = gradeDAL.GetObjByID(cmodel.GID);
                    //if (cmodel != null)
                    //{
                    //    this.ltl_ClassName.Text = cmodel.DepName;
                    //}
                    //if (gmodel != null)
                    //{
                    //    this.ltl_GradeName.Text = gmodel.GradeName;
                    //}
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
            DataTable dt = workDAL.GetList(this.hf_UserID.Value, 1);
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
            Pager.PageSize = 4;
            DataTable dt = eduResourceDAL.GetPagedZypt(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model, "", -2);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.tr_null.Visible = false;
            }
            else
            {
                this.tr_null.Visible = true;
            }
            this.rp_ResList.DataSource = dt;
            //this.ltl_Count.Text = recordCount.ToString();
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

            }
        }
        #endregion


        #region 分页
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Pager_PageChanged(object sender, EventArgs e)
        {
            ResBind();
        }
        #endregion


        #region 文化墙跳转
        /// <summary>
        /// 文化墙跳转
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_ClassCul_Click(object sender, EventArgs e)
        {
            string a = this.hf_UserID.Value.ToString();
            Response.Redirect("PersonLog.aspx?&id=" + this.hf_UserID.Value.ToString());
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
            Response.Redirect("PersonPhotos.aspx?&id=" + this.hf_UserID.Value.ToString());
        }
        #endregion
    }
}