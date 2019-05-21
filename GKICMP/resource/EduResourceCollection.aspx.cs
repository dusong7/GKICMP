/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      樊紫红
** 创建日期:    2017年9月6日 10：06
** 描 述:       收藏的资源
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

namespace GKICMP.resource
{
    public partial class EduResourceCollection : PageBase
    {
        protected int v = 0;
        public EduResourceDAL eduResourceDAL = new EduResourceDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public EduResourceUserDAL eduUserDAL = new EduResourceUserDAL();


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
                CommonFunction.BindEnum<CommonEnum.EType>(this.ddl_EType, "-2");//类别绑定
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
            ViewState["ResourseName"] = CommonFunction.GetCommoneString(this.txt_ResourseName.Text.ToString().Trim());
            ViewState["EType"] = this.ddl_EType.SelectedValue.ToString();
        }
        #endregion


        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {
            int recordCount = -1;
            DataTable dt = eduUserDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, (string)ViewState["ResourseName"], Convert.ToInt32(ViewState["EType"].ToString()), UserID);
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
            rp_List.DataBind();
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


        #region 获取文件图标
        /// <summary>
        /// 获取文件图标
        /// </summary>
        /// <param name="lastname"></param>
        /// <returns></returns>
        public string GetPic(object lastname)
        {
            string pname = "";
            if (lastname.ToString() == "jpg" || lastname.ToString() == "gif" || lastname.ToString() == "png" || lastname.ToString() == "jpeg" || lastname.ToString() == "psd" || lastname.ToString() == "bmp")
            {
                pname = "../images/bmp_icon.png";
            }
            else if (lastname.ToString() == "xls" || lastname.ToString() == "xlsx")
            {
                pname = "../images/xlsx_icon.png";
            }
            else if (lastname.ToString() == "doc" || lastname.ToString() == "docx" || lastname.ToString() == "wps")
            {
                pname = "../images/docx_icon.png";
            }
            else if (lastname.ToString() == "ppt" || lastname.ToString() == "pps" || lastname.ToString() == "ppsx")
            {
                pname = "../images/pptx_icon.png";
            }
            else if (lastname.ToString() == "txt")
            {
                pname = "../images/text_icon.png";
            }
            else if (lastname.ToString() == "zip" || lastname.ToString() == "rar")
            {
                pname = "../images/rar_icon.png";
            }
            else if (lastname.ToString() == "pdf")
            {
                pname = "../images/pdf_icon.png";
            }
            else if (lastname.ToString() == "mp4")
            {
                pname = "../images/wmv_file_icon.png";
            }
            else if (lastname.ToString() == "mp4")
            {
                pname = "../images/wmv_file_icon.png";
            }
            else if (lastname.ToString() == "swf")
            {
                pname = "../images/flash_icon.png";
            }
            else
            {
                pname = "../images/unknown_ico.gif";
            }
            return pname;
        }
        #endregion


        #region 下载资源
        /// <summary>
        /// 下载资源
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_download_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;

            string expath = btn.CommandArgument;
            string name = btn.CommandName;
            if (!CommonFunction.UpLoadFunciotn(expath, name))
            {
                ShowMessage("资源不存在，请联系系统管理员");
                return;
            }
            int result = eduResourceDAL.DownLoad("");
            sysLogDAL.Edit((new SysLogEntity("于" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "下载【" + name + "】资源", UserID)));
        }
        #endregion


        #region 取消关注
        /// <summary>
        /// 取消关注
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_Unfollow_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)sender;

                int result = eduUserDAL.DeleteBat(btn.CommandArgument);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "取消关注名称为【" + btn.CommandName.ToString() + "】的资源信息", UserID));
                    ShowMessage("取消关注成功");
                }
                else
                {
                    ShowMessage("取消关注失败");
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
    }
}