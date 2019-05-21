/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      殷志瑞
** 创建日期:    2017年3月14日 10:13
** 描 述:       资源平台管理页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/

using System;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
namespace GKICMP.resourcesite
{
    public partial class Res_Main : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public EduResourceDAL eduResourceDAL = new EduResourceDAL();
        public EduResourceUserDAL eduUserDAL = new EduResourceUserDAL();
        public static int type = 0;

        #region 参数集合
        /// <summary>
        /// RType
        /// </summary>
        public int RType
        {
            get
            {
                return GetQueryString<int>("RType", -2);
            }
        }
        #endregion


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                type = RType;
                GetCondition();
                DataBindList(type);
            }
        }
        #endregion


        #region 获取查询条件
        public void GetCondition()
        {
            ViewState["txt_All"] = CommonFunction.GetCommoneString(this.txt_All.Text.Trim());
            // ViewState["RType"] = type;
        }
        #endregion


        #region 数据绑定
        public void DataBindList(int rtypes)
        {
            int recordCount = 0;
            Pager.PageSize = 4;
            EduResourceEntity model = new EduResourceEntity();
            DataTable dt = eduResourceDAL.GetPagedZypt(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model, ViewState["txt_All"].ToString(), rtypes);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.tr_null.Visible = false;
            }
            else
            {
                this.tr_null.Visible = true;
            }
            this.rp_List.DataSource = dt;
            this.ltl_Count.Text = recordCount.ToString();
            Pager.RecordCount = recordCount;
            this.rp_List.DataBind();
        }
        #endregion


        #region 分页
        public void Pager_PageChanged(object sender, EventArgs e)
        {
            DataBindList(type);
        }
        #endregion


        #region 获取图标
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


        #region 查询
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            Pager.CurrentPageIndex = 1;
            GetCondition();
            DataBindList(type);
        }
        #endregion


        #region 根据资源类型查询
        protected void lbtn_All_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            int RType1 = Convert.ToInt32(lbtn.CommandArgument.ToString());
            ViewState["txt_All"] = "";
            // ViewState["RType"] = RType.ToString();
            DataBindList(RType1);
        }
        #endregion



        #region 重置条件
        protected void img_cz_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            this.txt_All.Text = "";
            ViewState["txt_All"] = "";
            // ViewState["RType"] = "-2";
            DataBindList(type);
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

            DataBindList(RType);
            try
            {
                string Erid = ((LinkButton)sender).CommandArgument;
                EduResourceEntity model = eduResourceDAL.GetObjByID(Convert.ToInt32(Erid));
                string accessid = model.ResourseUrl;
                string name = ((LinkButton)sender).CommandName;

                if (!CommonFunction.UpLoadFunciotn(accessid, name))
                {
                    ShowMessage("下载文件不存在，请联系系统管理员");
                    return;
                }
                else
                {
                    eduResourceDAL.DownLoad(Erid);
                    DataBindList(RType);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alertsuccess", "<script>alert('系统提示：下载成功！');</script>");
                }
            }
            catch (Exception ex)
            {

            }
        }
        #endregion


        #region 收藏事件
        /// <summary>
        /// 收藏事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_Collection_Click(object sender, EventArgs e)
        {
            try
            {
                int Erid = Convert.ToInt32(((LinkButton)sender).CommandArgument.ToString());
                string name = ((LinkButton)sender).CommandName.ToString();

                EduResourceUserEntity model = new EduResourceUserEntity();
                model.EUID = -1;
                model.Erid = Erid;
                model.CreateUser = UserID;

                int result = eduUserDAL.Edit(model);
                if (result == 0)
                {
                    ShowMessage("收藏成功");
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "成功收藏名称为【" + name + "】的资源信息", UserID));
                }
                else if(result==-2)
                {
                    ShowMessage("您已收藏此信息");
                    return;
                }
                else
                {
                    ShowMessage("收藏失败");
                    return;
                }
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