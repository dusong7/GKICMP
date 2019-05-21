/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      yzr
** 创建日期:     2017年03月03日
** 描 述:        学生活动详细页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;


namespace GKICMP.schoolwork
{
    public partial class StudentActDetail : PageBase
    {
        public StudentActivityDAL studentActivityDAL = new StudentActivityDAL();


        #region 参数集合
        public string SAID
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
                StudentActivityEntity model = studentActivityDAL.GetObjByID(SAID);
                if (model != null)
                {
                    this.ltl_ActName.Text = model.ActName;
                    this.ltl_ActType.Text = model.ActTypeName;
                    this.ltl_ABegin.Text = model.ABegin == null ? "" : model.ABegin.ToString("yyyy-MM-dd");
                    this.ltl_AEnd.Text = model.AEnd == null ? "" : model.AEnd.ToString("yyyy-MM-dd");
                    this.ltl_IsPublish.Text = GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.IsorNot>(model.IsPublish);
                    this.ltl_IsSign.Text = GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.IsorNot>(model.IsSign);
                    this.ltl_ClosingDate.Text = model.ClosingDate == null ? "" : model.ClosingDate.ToString("yyyy-MM-dd");
                    this.ltl_Counselor.Text = model.CounselorName;
                    this.ltl_ActAddress.Text = model.ActAddress;
                    this.ltl_ActUsers.Text = model.ActUsersName;
                    this.ltl_ActContent.Text = model.ActContent;
                    this.ltl_ActivityTemp.Text = model.ActivityTemp.ToString();
                    this.img_LogoUrl.ImageUrl = model.LogoUrl == null ? "" : model.LogoUrl;
                    this.ltl_ActDesc.Text = model.ActDesc;
                }
            }
        }
        #endregion
    }
}