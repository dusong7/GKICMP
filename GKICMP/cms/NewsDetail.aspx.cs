using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GKICMP.cms
{
    public partial class NewsDetail : PageBase
    {
        public Web_NewsDAL newsDAL = new Web_NewsDAL();


        #region 参数集合
        public string NID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        #endregion

        public string bg="";
        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindInfo();
            }
        }
        #endregion


        #region 初始化用户数据
        private void BindInfo()
        {
            Web_NewsEntity model = newsDAL.GetObjByID(NID);
            if (model != null)
            {
                
                //this.bg.Attributes.Add("","this.style.backgroundColor='red'");
                this.ltl_CreateDate.Text = model.CreateDate.ToString("yyyy-MM-dd");
                this.ltl_IsComment.Text = CommonFunction.CheckEnum<CommonEnum.IsorNot>(model.IsComment);
                this.ltl_IsImgNews.Text = CommonFunction.CheckEnum<CommonEnum.IsorNot>(model.IsImgNews);
                this.ltl_IsRecommend.Text = CommonFunction.CheckEnum<CommonEnum.IsorNot>(model.IsRecommend);
                this.ltl_IsTop.Text = CommonFunction.CheckEnum<CommonEnum.IsorNot>(model.IsTop);
                this.ltl_LinkUrl.Text = model.LinkUrl;
                this.ltl_MDescription.Text = CommonFunction.CheckEnum<CommonEnum.IsorNot>(model.MDescription);
                this.ltl_MID.Text = model.MName;
               // this.ltl_MSourse.Text = model.MSourse;
                this.ltl_NAuthor.Text = model.NAuthorName;
                this.ltl_NColor.Text=bg = model.NColor;
                this.ltl_NContent.Text = model.NContent;
                this.ltl_NDescription.Text = model.NDescription;
                this.ltl_NewsTitle.Text = model.NewsTitle;
                this.ltl_NKeyWords.Text = model.NKeyWords;
                this.ltl_NOrder.Text = model.NOrder.ToString();
                this.ltl_Nstate.Text = model.Nstate == 1 ? "发布" : "未发布";
                this.ltl_NTtitle.Text = model.NTtitle;
                this.ltl_ReadCount.Text = model.ReadCount.ToString();
                this.img_ImageUrl.ImageUrl = model.ImageUrl;
                this.ltl_CommentNumber.Text = model.CommentNumber.ToString();
                this.ltl_Audit.Text=CommonFunction.CheckEnum<CommonEnum.IsorNot>(model.IsAudit);
                if (model.IsAudit == 0)
                {
                    this.audit.Visible = false;
                }
                else
                {
                    this.ltl_AduitUser.Text = model.AduitUserName;
                    this.ltl_AduitDate.Text = model.AduitDate.ToString() == "0001/1/1 0:00:00" ? "" : model.AduitDate.ToString("yyyy-MM-dd HH:mm");
                }
            }
        }
        #endregion


        #region 返回
        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewsManage.aspx");
        }
        #endregion
    }
}