/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2017年01月22日 13时43分25秒
** 描    述:      异动管理页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.teachermanage
{
    public partial class TeacherChangesManage :  PageBase
    {
       public TeacherDAL teacherDAL = new TeacherDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public TeacherEducationDAL teacherEducation = new TeacherEducationDAL();
        public Teacher_ChangesDAL teacher_ChangesDAL = new Teacher_ChangesDAL();

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
                CommonFunction.BindEnum<CommonEnum.TeacherState>(this.ddl_CType, "-2");//异动类型
                GetCondition();
                DataBindList();
            }
        }
        #endregion


        #region 获取查询条件
        /// <summary>
        /// 获取查询条件
        /// </summary>
        private void GetCondition()
        {
            ViewState["TName"] = CommonFunction.GetCommoneString(this.txt_TName.Text.ToString().Trim());
            ViewState["begin"] = this.txt_SDate.Text == "" ? "1900-01-01" : this.txt_SDate.Text;  //开始时间
            ViewState["end"] = this.txt_EDate.Text == "" ? "9999-12-31" : this.txt_EDate.Text;     //结束时间
            ViewState["CType"] = this.ddl_CType.SelectedValue.ToString();
        }
        #endregion


        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {
            int recordCount = -1;
            //Teacher_ChangesEntity model = new Teacher_ChangesEntity(Convert.ToDateTime(ViewState["begin"]), Convert.ToDateTime(ViewState["end"]));
            Teacher_ChangesEntity model = new Teacher_ChangesEntity();
            model.TName = (string)ViewState["TName"].ToString();
            model.Begin = Convert.ToDateTime(ViewState["begin"]);
            model.End = Convert.ToDateTime(ViewState["end"]);
            model.CType = Convert.ToInt32(ViewState["CType"].ToString());
            model.Isdel = (int)CommonEnum.Deleted.未删除;
            DataTable dt = teacher_ChangesDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.tr_null.Visible = false;
            }
            else
            {
                this.tr_null.Visible = true;
            }
            this.rp_List.DataSource = dt;
            Pager.RecordCount = recordCount;
            this.rp_List.DataBind();
            this.hf_CheckIDS.Value = "";
        }
        #endregion


        #region 查询事件
        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            Pager.CurrentPageIndex = 1;
            GetCondition();
            DataBindList();
        }
        #endregion


        #region 分页事件
        /// <summary>
        /// 分页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Pager_PageChanged(object sender, EventArgs e)
        {
            DataBindList();
        }
        #endregion


        #region 删除事件
        /// <summary>
        /// 删除事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                string ids = this.hf_CheckIDS.Value;
                ids = ids.TrimEnd(',').TrimStart(',');
                int result = teacher_ChangesDAL.DeleteBat(ids, (int)CommonEnum.Deleted.删除);
                if (result > 0)
                {
                    ShowMessage("删除成功");
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除教师异动信息", UserID));
                }
                else
                {
                    ShowMessage("删除失败");
                    return;
                }
                DataBindList();
                this.hf_CheckIDS.Value = "";
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }
        #endregion


        #region 判断复选框是否可用
        /// <summary>
        /// 判断复选框是否可用
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public string GetState(object state)
        {
            string sstate = state.ToString();
            if (sstate == "1")
            {
                return "disabled";
            }
            else
            {
                return "";
            }
        }
        #endregion


        #region 上报 ---测试完成
        protected void lbtn_SB_Click(object sender, EventArgs e)
        {
            ShowMessage("暂无上报");
            //try
            //{
            //    localhost1.WebService1 service = new localhost1.WebService1();
            //    service.Url = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "ServerUrl") + "/WebService1.asmx";
            //    LinkButton lbtn = (LinkButton)sender;
            //    string id = lbtn.CommandArgument.ToString();
            //    string aa = "";
            //    List<GKICMP.localhost1.Teacher_EducationEntity> args = new List<GKICMP.localhost1.Teacher_EducationEntity>();
            //    for (int i = 0; i < id.Split(',').Length; i++)
            //    {
            //        Teacher_EducationEntity model = teacherEducation.GetObjByID(id.Split(',')[i]);
            //        GKICMP.localhost1.Teacher_EducationEntity model1 = new localhost1.Teacher_EducationEntity();
            //        model1.TEID = model.TEID;
            //        model1.TID = model.TID;//名称
            //        model1.Education = model.Education;//
            //        model1.IsTeach = model.IsTeach;
            //        model1.DegreeName = model.DegreeName;
            //        model1.DegreeLevel = model.DegreeLevel;

            //        model1.StudyType = model.StudyType;//
            //        model1.CompanyType = model.CompanyType;
            //        model1.GradeCountry = model.GradeCountry;
            //        model1.EduCountry = model.EduCountry;//

            //        model1.InDate = model.InDate;//
            //        model1.OutDate = model.OutDate;//
            //        model1.GrantDate = model.GrantDate;


            //        model1.EduSchool = model.EduSchool;//
            //        model1.GradeSchool = model.GradeSchool;//
            //        model1.EMajor = model.EMajor;//

            //        model1.CreateUser = model.CreateUser;
            //        model1.Isdel = (int)CommonEnum.Deleted.未删除;
            //        model1.CreateDate = DateTime.Now;

            //        args.Add(model1);
            //    }
            //    string sguid = ConfigurationManager.AppSettings["SGUID"];
            //    GKICMP.localhost1.Teacher_EducationEntity[] A = args.ToArray();
            //    if (service.TeacherEducation(sguid, A, out aa))
            //    {
            //        int rusult = teacherEducation.Update(id);//更新字段为 已上报
            //        ShowMessage(aa);
            //        DataBindList();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ShowMessage("请配置区平台网址");
            //    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志, ex.Message, UserID));
            //}
        }
        #endregion

        #region 多条上报 ---测试完成
        protected void lbtn_MoreSB_Click(object sender, EventArgs e)
        {
            ShowMessage("暂无上报");
            //try
            //{
            //    localhost1.WebService1 service = new localhost1.WebService1();
            //    service.Url = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "ServerUrl") + "/WebService1.asmx";
            //    string aa = "";
            //    string id = "";
            //    id = this.hf_CheckIDS.Value.ToString();
            //    id = id.TrimEnd(',').TrimStart(',');

            //    List<GKICMP.localhost1.Teacher_EducationEntity> args = new List<GKICMP.localhost1.Teacher_EducationEntity>();
            //    for (int i = 0; i < id.Split(',').Length; i++)
            //    {
            //        Teacher_EducationEntity model = teacherEducation.GetObjByID(id.Split(',')[i]);
            //        GKICMP.localhost1.Teacher_EducationEntity model1 = new localhost1.Teacher_EducationEntity();
            //        model1.TEID = model.TEID;
            //        model1.TID = model.TID;//名称
            //        model1.Education = model.Education;//
            //        model1.IsTeach = model.IsTeach;
            //        model1.DegreeName = model.DegreeName;
            //        model1.DegreeLevel = model.DegreeLevel;

            //        model1.StudyType = model.StudyType;//
            //        model1.CompanyType = model.CompanyType;
            //        model1.GradeCountry = model.GradeCountry;
            //        model1.EduCountry = model.EduCountry;//

            //        model1.InDate = model.InDate;//
            //        model1.OutDate = model.OutDate;//
            //        model1.GrantDate = model.GrantDate;


            //        model1.EduSchool = model.EduSchool;//
            //        model1.GradeSchool = model.GradeSchool;//
            //        model1.EMajor = model.EMajor;//

            //        model1.CreateUser = model.CreateUser;
            //        model1.Isdel = (int)CommonEnum.Deleted.未删除;
            //        model1.CreateDate = DateTime.Now;

            //        args.Add(model1);
            //    }

            //    //service.Url = ConfigurationManager.AppSettings["URL"] + "/WebService1.asmx";
            //    string sguid = ConfigurationManager.AppSettings["SGUID"];
            //    //service.Show("1", "2", out aa);
            //    GKICMP.localhost1.Teacher_EducationEntity[] A = args.ToArray();
            //    if (service.TeacherEducation(sguid, A, out aa))
            //    {
            //        int rusult = teacherEducation.Update(id);//更新字段为 已上报
            //        ShowMessage(aa);
            //        DataBindList();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ShowMessage("请配置区平台网址");
            //    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志, ex.Message, UserID));
            //}

        }
        #endregion

        


    }
}