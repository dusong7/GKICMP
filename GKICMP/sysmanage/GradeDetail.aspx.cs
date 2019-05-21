/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      czz
** 创建日期:    2017年03月01日
** 描 述:       年级详情页面
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

namespace GKICMP.sysmanage
{
    public partial class GradeDetail : PageBase
    {
        public GradeDAL GradeDAL = new GradeDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SysUserDAL UserDal = new SysUserDAL();
        public GradeLevelDAL gradeLevelDal = new GradeLevelDAL();

        #region 参数集合
        public int GID
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
            if (!IsPostBack)
            {
                if (GID != -1)
                {
                    InfoBind();
                }
            }
        }
        #endregion


        #region 初始化用户数据
        private void InfoBind()
        {
            GradeEntity model = new GradeEntity();
            if(GID!=-1)
                model = GradeDAL.GetObjByID(GID);
            if (model != null)
            {
                this.lbl_GradeName.Text=model.GradeName;//年级名称
                this.lbl_GradeYear.Text=model.GradeYear.ToString();//入学年份
                this.lbl_IsGraduate.Text = CommonFunction.CheckEnum<CommonEnum.IsorNot>(model.IsGraduate);//是否毕业
                //this.lbl_ShortName.Text=model.ShortName.ToString();
             
                GradeLevelEntity level=gradeLevelDal.GetGradeLevelByGLID(int.Parse(model.ShortName.ToString()));
                if (level != null)
                    this.lbl_ShortName.Text = level.ShortName;//当前简述
                SysUserEntity entitys = UserDal.GetObjByID(model.GradeDuty);
                this.lbl_GradeDuty.Text = entitys.RealName;//年级职责
                this.lbl_CreateDate.Text = model.CreateDate.ToString("yyyy-MM-dd HH:mm");//创建日期 
                this.lbl_Notes.Text=model.Notes;//备注
                if (model.GraduatePhoto != "")
                    this.img_GraduatePhoto.ImageUrl = model.GraduatePhoto;
            }
        }
        #endregion 
    }
}