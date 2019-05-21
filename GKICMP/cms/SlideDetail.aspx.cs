/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年06月1日 08时35分06秒
** 描    述:      幻灯片/超链接详情
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.cms
{
    public partial class SlideDetail : PageBase
    {
        public Web_SlideDAL slideDAL = new Web_SlideDAL();

        #region 参数集合
        /// <summary>
        /// SliID 友情链接、幻灯片id
        /// </summary>
        public int SliID
        {
            get
            {
                return GetQueryString<int>("id", -1);
            }
        }

        /// <summary>
        /// Flag 1：友情链接 2：幻灯片 3：宣传标语
        /// </summary>
        public int Flag
        {
            get
            {
                return GetQueryString<int>("flag", -1);
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
                if (Flag == 1)
                {
                    this.ltl_SName.Text = "友情链接";
                    this.ltl_Name.Text = "友情链接";
                }
                else if (Flag == 2)
                {
                    this.ltl_SName.Text = "幻灯片";
                    this.ltl_Name.Text = "幻灯片";
                }
                else
                {
                    this.ltl_SName.Text = "宣传标语";
                    this.ltl_Name.Text = "宣传标语";
                }
                InfoBind();
            }
        }
        #endregion


        #region 初始化用户数据
        /// <summary>
        /// 初始化用户数据
        /// </summary>
        private void InfoBind()
        {
            Web_SlideEntity model = slideDAL.GetObjByID(SliID);
            this.ltl_SType.Text = model.STypeName;
            this.ltl_SlideName.Text = model.SlideName;
            this.ltl_SlideUrl.Text = model.SlideUrl;
            this.ltl_InvalidDate.Text = model.InvalidDate.ToString("yyyy-MM-dd");
            this.ltl_CreateUser.Text = model.CreateUserName;
            this.ltl_CreateDate.Text = model.CreateDate.ToString("yyyy-MM-dd");
            if (model.SImage != null && model.SImage.ToString() != "")
            {
                this.img_SImage.Visible = true;
                this.img_SImage.ImageUrl = model.SImage;
            }
        }
        #endregion
    }
}