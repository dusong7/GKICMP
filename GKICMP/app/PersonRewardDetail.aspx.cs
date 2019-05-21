using System;
using System.Web.UI.WebControls;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Data;
using System.IO;

namespace GKICMP.app
{
    public partial class PersonRewardDetail : PageBaseApp
    {
        public Teacher_RewardDAL teacherRewardDAL = new Teacher_RewardDAL();

        #region 参数集合
        public string TPID
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
                if (TPID != "")
                {
                    Teacher_RewardEntity model = teacherRewardDAL.GetObjByID(TPID);
                    if (model != null)
                    {
                        this.lbl_Lunit.Text = model.Lunit;
                        this.lbl_PubDate.Text = model.PubDate.ToString("yyyy-MM-dd");
                        this.lbl_Ranking.Text = CommonFunction.CheckEnum<CommonEnum.Ranking>(model.Ranking);
                        this.lbl_Report.Text = CommonFunction.CheckEnum<CommonEnum.IsorNot>(model.IsReport);
                        this.lbl_RewardType.Text = CommonFunction.CheckEnum<CommonEnum.RewardType>(model.RewardType);
                        this.lbl_RewardName.Text = model.RewardName;
                        this.lbl_RGrade.Text = CommonFunction.CheckEnum<CommonEnum.RGrade>(model.RGrade);
                        if (model.RFile != "")
                        {
                            string[] arr = model.RFile.Split('.');
                            if (arr[1].ToString() == "jpg" || arr[1].ToString() == "bmp" || arr[1].ToString() == "jpeg" || arr[1].ToString() == "gif" || arr[1].ToString() == "psd" || arr[1].ToString() == "png" || arr[1].ToString() == "tiff" || arr[1].ToString() == "tga" || arr[1].ToString() == "eps")
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
            DataTable ds = teacherRewardDAL.GetTable(TPID);
            rp_File.DataSource = ds;
            rp_File.DataBind();
        }
        #endregion
    }
}