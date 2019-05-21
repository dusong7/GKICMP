/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      fsc
** 创建日期:    2017年02月27日
** 描 述:       用户编辑页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using GK.GKICMP.Common;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Data;
using System.Configuration;

namespace GKICMP.electiver
{
    public partial class ElectiverCourseEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public GradeLevelDAL gradeLevelDAL = new GradeLevelDAL();
        public Electiver_CourseDAL electiver_CourseDAL = new Electiver_CourseDAL();
        public Electiver_CourseGradeDAL electiver_CourseGradeDAL = new Electiver_CourseGradeDAL();
        public ECourseDAL eCourseDAL = new ECourseDAL();
        #region 参数集合
        /// <summary>
        /// UID
        /// </summary>
        public int ECID
        {
            get
            {
                return GetQueryString<int>("id", 0);
            }
        }
        public int EleID
        {
            get
            {
                return GetQueryString<int>("eleid", 0);
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                //年级绑定
                cblBand();
                //课程绑定
                CourseBand();
                if (ECID != 0) 
                {
                    InfoBind();
                }
            }
        }
        #region 课程绑定
        /// <summary>
        /// 课程绑定
        /// </summary>
        private void CourseBand()
        {
            //checkboxlist 绑定
            DataTable grade = eCourseDAL.GetList();
            CommonFunction.DDlTypeBind(this.ddlCourseID, grade, "CID", "CourseName","-2");
        }
        #endregion
        #region 年级绑定
        /// <summary>
        /// 年级绑定
        /// </summary>
        private void cblBand()
        {
            //checkboxlist 绑定
            DataTable grade = gradeLevelDAL.GetList();
            CommonFunction.CBLTypeBind(this.cbl_Grade, grade, "GLID", "ShortName");
            foreach (ListItem li in cbl_Grade.Items)
            {
                li.Attributes.Add("alt", li.Value);
            }
        }
        #endregion
        public void InfoBind() 
        {
            Electiver_CourseEntity model = electiver_CourseDAL.GetObjByID(ECID);
            this.ddlCourseID.SelectedValue = model.CourseID.ToString();
            this.txt_MaxCount.Text = model.MaxCount.ToString();
            DataTable grades = electiver_CourseGradeDAL.GetList(ECID);
            foreach (DataRow dr in grades.Rows)
            {
                string value = dr["GID"].ToString();
                foreach (ListItem li in this.cbl_Grade.Items)
                {
                    if (value == li.Value)
                    {
                        li.Selected = true;
                    }
                }
            }
        }
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                Electiver_CourseEntity model = new Electiver_CourseEntity();
                model.ECID = ECID;
                model.EleID = EleID;
                model.CourseID = int.Parse(this.ddlCourseID.SelectedValue);
                model.MaxCount = int.Parse(this.txt_MaxCount.Text);
                string grades = "";
                //绑定角色
                foreach (ListItem li in this.cbl_Grade.Items)
                {
                    if (li.Selected)
                    {
                        grades = grades + li.Value + ",";
                    }
                }
                grades = grades.TrimEnd(',');
                int result = electiver_CourseDAL.Edit(model,grades);
                if (result == 0)
                {
                    sysLogDAL.Edit(new SysLogEntity(ECID == 0 ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改, ECID == 0 ? "添加" : "修改" + "选课课程【" + this.ddlCourseID.SelectedItem.Text + "】的信息", UserID));
                    ShowMessage();
                }
                else if (result == -2)
                {
                    ShowMessage("已添加该课程，请勿重复添加");
                    return;
                }
                else
                {
                    ShowMessage("提交失败");
                    return;
                }
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                ShowMessage(ex.Message.Replace("'","").Replace("\"",""));
            }
        }
       
    }
}