/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      樊紫红
** 创建日期:    2017年9月6日 9：29
** 描 述:       资源平台管理详细页面
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
    public partial class Res_Detail : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public EduResourceDAL eduResourceDAL = new EduResourceDAL();
        public EduResourceUserDAL eduUserDAL = new EduResourceUserDAL();


        #region 参数集合
        public int RID
        {
            get
            {
                return GetQueryString<int>("id", -1);
            }
        }
        #endregion


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataBindListByZy();
                BindInfo();
            }
        }
        #endregion


        #region 初始化用户数据
        public void BindInfo()
        {
            DataTable dt = eduResourceDAL.GetTable(RID);
            if (dt != null)
            {
                this.rp_List.DataSource = dt;
                this.rp_List.DataBind();
            }
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
                pname = "../images/unknown_ico.gif";
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


        #region 最新资源绑定
        public void DataBindListByZy()
        {
            DataTable dt = eduResourceDAL.GetPagedZyptByFlag(1);//1 精品资源
            if (dt != null && dt.Rows.Count > 0)
            {
                this.tr_null2.Visible = false;
            }
            else
            {
                this.tr_null2.Visible = true;
            }
            this.rp_jpList.DataSource = dt;
            this.rp_jpList.DataBind();

            DataTable dt1 = eduResourceDAL.GetPagedZyptByFlag(2);//最新资源
            if (dt != null && dt.Rows.Count > 0)
            {
                this.tr_null1.Visible = false;
            }
            else
            {
                this.tr_null1.Visible = true;
            }
            this.rp_zxList.DataSource = dt1;
            this.rp_zxList.DataBind();

        }
        #endregion


        #region 下载
        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void img_xz_Click(object sender, ImageClickEventArgs e)
        {
            EduResourceEntity model = eduResourceDAL.GetObjByID(RID);
            string accessid = model.ResourseUrl;
            string name = Path.GetFileNameWithoutExtension(accessid);

            if (!CommonFunction.UpLoadFunciotn(accessid, name))
            {
                ShowMessage("下载文件不存在，请联系系统管理员");
                return;
            }
            else
            {
                eduResourceDAL.UpdateNum(RID);
            }
            BindInfo();
        }
        #endregion


        #region 收藏事件
        /// <summary>
        /// 收藏事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void img_sc_Click(object sender, ImageClickEventArgs e)
        {
            EduResourceEntity emodel = eduResourceDAL.GetObjByID(RID);

            EduResourceUserEntity model = new EduResourceUserEntity();
            model.EUID = -1;
            model.Erid = emodel.Erid;
            model.CreateUser = UserID;

            int result = eduUserDAL.Edit(model);
            if (result == 0)
            {
                ShowMessage("收藏成功");
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "成功收藏名称为【" + emodel.ResourseName + "】的资源信息", UserID));
            }
            else if (result == -2)
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
        #endregion
    }
}