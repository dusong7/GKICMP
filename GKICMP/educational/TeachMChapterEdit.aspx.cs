/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年06月01日 16时13分29秒
** 描    述:      教材章节操作类
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
    public partial class TeachMChapterEdit : PageBase
    {
        public TeachMaterial_ChapterDAL chapterDAL = new TeachMaterial_ChapterDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();

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
        /// <summary>
        /// 教材ID
        /// </summary>
        public int TMID
        {
            get
            {
                return GetQueryString<int>("tmid", -1);
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
                if (TCID != -1)
                {
                    this.hf_TMID.Value = TMID.ToString();
                    InfoBind();
                }
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
            if (model != null)
            {
                this.txt_Content.Text = model.ChapterContent.ToString();
                this.txt_ChapterName.Text = model.ChapterName.ToString();
            }
        }
        #endregion


        #region 提交事件
        /// <summary>
        /// 提交事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                TeachMaterial_ChapterEntity model = new TeachMaterial_ChapterEntity();
                model.TCID = TCID;
                model.TMID = TMID;
                model.ChapterName = this.txt_ChapterName.Text.ToString().Trim();
                if (this.txt_Content.Text == "")
                {
                    ShowMessage("章节内容不能为空");
                    return;
                }
                model.ChapterContent = this.txt_Content.Text.ToString();

                int result = chapterDAL.Edit(model);
                if (result > 0)
                {
                    ShowMessage();
                    int log = TCID == -1 ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, (TCID == -1 ? "添加" : "修改") + "章节名称为【" + this.txt_ChapterName.Text + "】的章节信息", UserID));
                }
                else
                {
                    ShowMessage("提交失败");
                    return;
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                return;
            }
        }
        #endregion
    }
}