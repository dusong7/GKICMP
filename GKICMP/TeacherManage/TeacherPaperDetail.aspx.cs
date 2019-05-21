/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      lfz
** 创建日期:    2017年02月28日
** 描 述:       年级编辑页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Configuration;
using System.Text;
using System.Data;

namespace GKICMP.teachermanage
{
    public partial class TeacherPaperDetail : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public Teacher_PaperDAL teacher_PaperDAL = new Teacher_PaperDAL();
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
        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>     
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (TPID != "")
                {
                    InfoBind();
                }
            }
        }
        #endregion
        #region 初始化用户数据
        private void InfoBind()
        {
            try
            {
                Teacher_PaperEntity model = new Teacher_PaperEntity();
                model = teacher_PaperDAL.GetObjByID(TPID);
                if (model != null)
                {
                    this.ltl_TeacherName.Text = model.TeacherName;//教师
                    this.ltl_PaperName.Text = model.PaperName;//论文名称
                    this.ltl_Publication.Text = model.Publication;//发表刊物名称
                    this.ltl_PubDate.Text = model.PubDate.ToString("yyyy-MM-dd").ToString();//发表日期
                    this.ltl_Volume.Text = model.Volume;//卷号
                    this.ltl_TermNum.Text = model.TermNum;//期号
                    this.ltl_BeginPage.Text = model.BeginPage.ToString();//起始页码
                    this.ltl_EndPage.Text = model.EndPage.ToString();//结束页码
                    this.ltl_URoles.Text =CommonFunction.CheckEnum<CommonEnum.URole>(model.URoles);//本人角色
                    this.ltl_SubjectArea.Text = model.SubjectAreaName.ToString();//学科领域
                    this.ltl_Included.Text = model.IncludedName.ToString();//论文收录情况
                }
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                ShowMessage("请稍候再试");
            }
        }
        #endregion
    }
}