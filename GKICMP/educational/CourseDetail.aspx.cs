
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;

namespace GKICMP.educational
{
    public partial class CourseDetail : PageBase
    {
        CourseDAL courseDAL = new CourseDAL();
        #region 参数集合
        public int CID
        {
            get
            {
                return GetQueryString<int>("id", 0);
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InfoBind();
            }
        }
        public void InfoBind()
        {
            try
            {
                CourseEntity model = courseDAL.GetObjByID(CID);
                this.ltl_CourseName.Text = model.CourseName;
                this.ltl_CourseOther.Text = model.CourseOther;
                this.ltl_MaterialNum.Text = model.MaterialNum.ToString();
                this.ltl_EditionNum.Text = model.EditionNum.ToString();
                this.ltl_IsOpen.Text = model.IsOpen.ToString() == "1" ? "已开设" : "未开设";
                this.ltl_CourseGrade.Text = CommonFunction.CheckEnum<CommonEnum.CourseGrade>(model.CourseGrade);
                this.ltl_IsMain.Text = model.IsMain.ToString() == "1" ? "是" : "否";
                this.ltl_IsElective.Text = model.IsElective.ToString() == "1" ? "是" : "否";
            }
            catch (Exception ex)
            {
                ShowMessage("系统出错，请稍后再试。" + ex.Message);
            }

        }
    }
}