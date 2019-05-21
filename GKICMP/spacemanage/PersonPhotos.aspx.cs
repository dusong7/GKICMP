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
    public partial class PersonPhotos : PageBase
    {
        public DepartmentDAL departDAL = new DepartmentDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public SpacePhotosDAL photoDAL = new SpacePhotosDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();


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
                if (UID != UserID)//判断是否当前登录学生相册
                {
                    this.btn_Upload.Visible = false;
                }
                SysUserEntity model = sysUserDAL.GetObjByID(this.hf_UID.Value);
                if (model != null)
                {
                    this.ltl_RealName.Text = model.RealName;
                   // DepartmentEntity cmodel = departDAL.GetObj(Convert.ToInt32(model.DepID));
                    //this.ltl_ClassName.Text = cmodel.DepName;
                    this.hf_ClaID.Value = model.DepID.ToString();
                    //GradeEntity gmodel = gradeDAL.GetObjByID(cmodel.GID);
                    //if (gmodel != null)
                    //{
                    //    this.ltl_GradeName.Text = gmodel.GradeName;
                    //}
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
            DataTable dt = photoDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, -1, this.hf_UID.Value, 2);

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


        #region 个人主页跳转
        /// <summary>
        /// 个人主页跳转
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_ClassHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("PersonSpace.aspx?id=" + this.hf_UID.Value);
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
            Response.Redirect("PersonLog.aspx?id=" + this.hf_UID.Value);
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