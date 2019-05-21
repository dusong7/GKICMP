
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using GK.GKICMP.DAL;

namespace GKICMP.educational
{
    public partial class CourseEdit : PageBase
    {
        CourseDAL courseDAL = new CourseDAL();
        SysLogDAL sysLogDAL = new SysLogDAL();
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
                CommonFunction.BindEnum<CommonEnum.CourseGrade>(this.ddl_CourseGrade, "-2");
                if (CID != 0)
                {
                    InfoBind();
                }
            }
        }
        public void InfoBind()
        {
            try
            {
                CourseEntity model = courseDAL.GetObjByID(CID);
                this.txt_CourseName.Text = model.CourseName;
                this.txt_CourseOther.Text = model.CourseOther;
                this.rbl_IsOpen.SelectedValue = model.IsOpen.ToString();
                this.ddl_CourseGrade.SelectedValue = model.CourseGrade.ToString();
                this.rbl_IsMain.SelectedValue = model.IsMain.ToString();
                this.rbl_IsElective.SelectedValue = model.IsElective.ToString();
            }
            catch (Exception ex)
            {

                ShowMessage(ex.Message);
            }

        }
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                CourseEntity model = new CourseEntity();
                model.CID = CID;
                model.CourseName = this.txt_CourseName.Text;//
                model.CourseOther = this.txt_CourseOther.Text;//
                model.MaterialNum = 0;//
                model.EditionNum = 0;//
                model.IsOpen = int.Parse(this.rbl_IsOpen.SelectedValue);//
                model.IsStanard = 0;//
                model.CreateDate = DateTime.Now;//
                model.CourseGrade = int.Parse(this.ddl_CourseGrade.SelectedValue);//
                model.IsMain = int.Parse(this.rbl_IsMain.SelectedValue);//
                model.Isdel = 0;//
                model.IsElective = Convert.ToInt32(this.rbl_IsElective.SelectedValue);
                int result = courseDAL.Edit(model);
                if (result == 0)
                {
                    int log = CID == 0 ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, (CID == 0 ? "添加" : "修改") + "课程【" + this.txt_CourseName.Text + "】信息", UserID));
                    ShowMessage();
                }
                else if (result == -2)
                {
                    ShowMessage("已存在课程名称为" + this.txt_CourseName.Text + "的课程");
                }
                else
                {
                    ShowMessage("提交出错");
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }
    }
}