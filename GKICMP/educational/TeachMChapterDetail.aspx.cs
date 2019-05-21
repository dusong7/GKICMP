/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年06月01日 17时38分29秒
** 描    述:      教材章节详细信息
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.educational
{
    public partial class TeachMChapterDetail : PageBase
    {
        public TeachMaterial_ChapterDAL chapterDAL = new TeachMaterial_ChapterDAL();

        #region 参数集合
        /// <summary>
        /// 章节ID
        /// </summary>
        public int TCID
        {
            get
            {
                return GetQueryString<int>("id", -1);
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
            if(!IsPostBack)
            {
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
            TeachMaterial_ChapterEntity model = chapterDAL.GetObjByID(TCID);
            this.ltl_ChapterName.Text = model.ChapterName.ToString();
            this.ltl_ChapterContent.Text = model.ChapterContent.ToString();
        } 
        #endregion
    }
}