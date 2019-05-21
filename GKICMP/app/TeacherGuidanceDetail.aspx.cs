using System;
using System.Web.UI.WebControls;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Data;
using System.IO;

namespace GKICMP.app
{
    public partial class TeacherGuidanceDetail : PageBaseApp
    {
        public Teacher_GuidanceDAL teacherGuidanceDAL = new Teacher_GuidanceDAL();

        #region 参数集合
        public string TGID
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
                if (TGID != "")
                {
                    Teacher_GuidanceEntity model = teacherGuidanceDAL.GetObjByID(TGID);
                    if (model != null)
                    {
                        this.lbl_GRole.Text = CommonFunction.CheckEnum<CommonEnum.URole>(model.GRole);
                        this.lbl_GuidDesc.Text = model.GuiDesc;
                        this.lbl_Lunit.Text = model.Lunit;
                        this.lbl_PubDate.Text = model.PubDate.ToString("yyyy-MM-dd");
                        this.lbl_RewardName.Text = model.RewardName;
                        this.lbl_RGrade.Text = model.RGrade;
                        if (model.RFile != "")
                        {
                            string[] arr = model.RFile.Split('.');
                            if (arr[1].ToString() == "jpg"||arr[1].ToString() == "bmp" || arr[1].ToString() == "jpeg" || arr[1].ToString() == "gif" || arr[1].ToString() == "psd" || arr[1].ToString() == "png" || arr[1].ToString() == "tiff" || arr[1].ToString() == "tga" || arr[1].ToString() == "eps")
                            {
                                this.img.Visible = true;
                                this.fj.Visible = false;
                                this.image.ImageUrl = model.RFile;
                            }
                            else
                            {
                                this.img.Visible = false;
                                this.fj.Visible = true;
                                AccessBind();
                            }
                        }
                        else
                        {
                            this.img.Visible = false;
                        }
                    }
                }
            }
        }
        #endregion


        public string getFileName(string obj)
        {
            return Path.GetFileNameWithoutExtension(obj);
        }


        #region 附件下载、删除
        protected void rpaccess_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string accessid = e.CommandArgument.ToString().Trim();
            string name = Path.GetFileNameWithoutExtension(accessid);

            if (!CommonFunction.UpLoadFunciotn(accessid, name))
            {
                ShowMessage("下载文件不存在，请联系系统管理员");
                return;
            }

        }
        #endregion


        #region 附件绑定
        /// <summary>
        /// 附件绑定
        /// </summary>
        /// <param name="rpcontr"></param>
        /// <param name="objid"></param>
        /// <param name="flag"></param>
        public void AccessBind()
        {
            DataTable ds = teacherGuidanceDAL.GetTable(TGID);
            rp_File.DataSource = ds;
            rp_File.DataBind();
        }
        #endregion
    }
}