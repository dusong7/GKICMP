/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年11月15日 11时16分32秒
** 描    述:      教师活动添加页面
** 修 改 人:      
** 修改日期:      
** 修改说明:      
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.lecturemanage
{
    public partial class TeacherActivityDetail : PageBase
    {
        public TeacherActivityDAL teacherActDAL = new TeacherActivityDAL();


        #region 参数集合
        /// <summary>
        /// 教师活动ID
        /// </summary>
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
            if(!IsPostBack)
            {
                InfoBind();
            }
        }
        #endregion


        private void InfoBind()
        {
            TeacherActivityEntity model = teacherActDAL.GetObjByID(SAID);
            if (model != null)
            {
                this.ltl_ActName.Text = model.ActName.ToString();
                this.ltl_ActAddress.Text = model.ActAddress.ToString();
                this.ltl_ActType.Text = model.ActTypeName.ToString();
                this.ltl_ABegin.Text = model.ABegin.ToString("yyyy-MM-dd");
                this.ltl_AEnd.Text = model.AEnd.ToString("yyyy-MM-dd");
                this.Series.Text = model.CounselorName.ToString();
                this.ltl_ActContent.Text = model.ActContent.ToString();
                this.ltl_ActDesc.Text = model.ActDesc.ToString();
            }
        }
    }
}