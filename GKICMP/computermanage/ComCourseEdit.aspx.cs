/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      lfz
** 创建日期:     2017年03月03日
** 描 述:       基础数据编辑页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Data;
using System.Web.UI.WebControls;
using System.Collections.Generic;
namespace GKICMP.computermanage
{
    public partial class ComCourseEdit : PageBase
    {
        public ComCourseDAL comCourseDAL = new ComCourseDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public ClassRoomDAL classRoomDAL = new ClassRoomDAL();
        public ScheduleSetDAL scheduleSetDAL = new ScheduleSetDAL();
        public CourseDAL courseDAL = new CourseDAL();
        public TeacherPlaneDAL teacherPlaneDAL = new TeacherPlaneDAL();
        public TeacherDAL teacherDAL = new TeacherDAL();
        public DataTable teac = null;
        #region 参数集合
        /// <summary>
        /// SDID 基础数据主键
        /// </summary>
        public string CCID
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
                BaseBind();
                this.txt_RegDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                //CommonFunction.BindEnum<CommonEnum.DataType>(this.ddl_Type, "-2");
                if (CCID != "")
                {
                    InfoBind();
                }
            }
        }
        #endregion
        public void BaseBind()
        {
            //班级绑定
            DataTable dt = departmentDAL.GetList((int)CommonEnum.IsorNot.否, (int)CommonEnum.DepType.普通班级);
            CommonFunction.DDlTypeBind(this.ddl_CID, dt, "DID", "OtherName", "-999");

            //教室绑定
            DataTable dtcr = classRoomDAL.GetTable((int)CommonEnum.IsorNot.否, (int)CommonEnum.IsorNot.是,3);
            CommonFunction.DDlTypeBind(this.ddl_CRID, dtcr, "CRID", "RoomName", "-999");

            //学科绑定
            //DataTable course = courseDAL.GetCourse((int)CommonEnum.IsorNot.否);
          teac=  teacherPlaneDAL.GetTeacByDep(int.Parse(this.ddl_CID.SelectedValue));
          CommonFunction.DDlTypeBind(this.ddl_CourseID, teac, "CourseID", "CourseName", "-999");

          //DataRow[] dr = teac.Select("TeacherID<>''");

          //绑定教师
          DataTable tt = TeacBind();
            //教师
            // teac = teacherDAL.GetList();
          CommonFunction.DDlTypeBind(this.ddl_Teach, tt, "TeacherID", "RealName", "-2");
         // this.ddl_Teach.Items.Remove(this.ddl_Teach.Items.FindByValue(""));
             //teac = teacherPlaneDAL.GetTeacByDep(int.Parse(this.ddl_CID.SelectedValue));
             //CommonFunction.DDlTypeBind(this.ddl_Teach, teac, "TeacherID", "RealName", "-999");
          DataRow[] dr = teac.Select("CourseID=" + this.ddl_CourseID.SelectedValue);
          if (dr != null)
              this.ddl_Teach.SelectedIndex = this.ddl_Teach.Items.IndexOf(this.ddl_Teach.Items.FindByValue(dr[0]["TeacherID"].ToString()));

            //节次
            ScheduleSetEntity model = scheduleSetDAL.GetObjByID();
            int js = model.MorningPitch + model.AfterPitch;
            for (int i = 1; i <= js; i++) 
            {
                this.ddl_Num.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }

           
        }

        private DataTable TeacBind()
        {
            DataTable tt = new DataTable();
            tt.Columns.Add("TeacherID", typeof(string));
            tt.Columns.Add("RealName", typeof(string));
            if (teac != null && teac.Rows.Count > 0)
            {
                foreach (DataRow drt in teac.Rows)
                {
                    if (drt["TeacherID"].ToString() != "")
                    {
                        if (tt.Select("TeacherID='" + drt["TeacherID"] + "'").Length <= 0)
                        {
                            List<string> list = new List<string>();
                            list.Add(drt["TeacherID"].ToString());
                            list.Add(drt["RealName"].ToString());
                            tt.Rows.Add(list.ToArray());
                        }
                    }
                }
            }
            return tt;
        }



        #region 初始化数据
        /// <summary>
        /// 初始化数据
        /// </summary>
        protected void InfoBind()
        {
            ComCourseEntity model = comCourseDAL.GetObjByID(CCID);
            if (model != null)
            {
              this.ddl_Teach.SelectedValue=  model.SysID  ;     
              this.ddl_CourseID.SelectedValue =  model.CID.ToString();       
              this.txt_ChapterName.Text=  model.ChapterName ;
              this.txt_RegDate.Text = model.RegDate.ToString("yyyy-MM-dd HH:mm");                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         
              this.ddl_CRID.SelectedValue = model.CRID.ToString();
              this.ddl_CID.SelectedValue = model.DID.ToString();
              this.ddl_Num.SelectedValue = model.ClassNum.ToString();   
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
                ComCourseEntity model = new ComCourseEntity();
                model.CCID = CCID;
                model.SysID = this.ddl_Teach.SelectedValue;
                model.CID = int.Parse(this.ddl_CourseID.SelectedValue);
                model.ChapterName = this.txt_ChapterName.Text;
                model.RegDate = Convert.ToDateTime(this.txt_RegDate.Text);
                //model.Xyear = DateTime.Now;
                //model.XTerm = 1;//1班班通，2多媒体教室
                model.CRID = int.Parse(this.ddl_CRID.SelectedValue);
                model.DID = int.Parse(this.ddl_CID.SelectedValue);
                model.ClassNum = int.Parse(this.ddl_Num.SelectedValue);
                model.Isdel = (int)CommonEnum.IsorNot.否;
                int result = comCourseDAL.Edit(model);
                if (result == -1)
                {
                    ShowMessage("提交失败");
                    return;
                }
                else if (result == -2)
                {
                    ShowMessage("时间冲突，请重新输入");
                    return;
                }
                else
                {
                    if (CCID == "")
                        sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, "增加机房登记信息【" + this.txt_ChapterName.Text + "】信息", UserID));
                    else
                        sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_修改, "修改机房登记信息【" + this.txt_ChapterName.Text + "】信息", UserID));
                    ShowMessage();
                }
            }
            catch (Exception error)
            {
                ShowMessage(error.Message);
                return;
            }

        }
        #endregion

        /// <summary>
        /// 班级变更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddl_CID_SelectedIndexChanged(object sender, EventArgs e)
        {
            teac = teacherPlaneDAL.GetTeacByDep(int.Parse(this.ddl_CID.SelectedValue));
           // DataRow[] drt = teac.Select("TeacherID<>''");
            if (teac != null)
            {
                this.ddl_Teach.Items.Clear(); this.ddl_CourseID.Items.Clear();
                CommonFunction.DDlTypeBind(this.ddl_CourseID, teac, "CourseID", "CourseName", "-999");//学科

                DataTable tt = TeacBind();
                CommonFunction.DDlTypeBind(this.ddl_Teach, tt, "TeacherID", "RealName", "-999");

                //this.ddl_Teach.Items.Remove(this.ddl_Teach.Items.FindByValue(""));
                DataRow[] dr = teac.Select("CourseID=" + this.ddl_CourseID.SelectedValue);
                if (dr != null)
                    this.ddl_Teach.SelectedIndex = this.ddl_Teach.Items.IndexOf(this.ddl_Teach.Items.FindByValue(dr[0]["TeacherID"].ToString()));
            }
        }
        /// <summary>
        /// 学科变更事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddl_CourseID_SelectedIndexChanged(object sender, EventArgs e)
        {
            teac = teacherPlaneDAL.GetTeacByDep(int.Parse(this.ddl_CID.SelectedValue));
            this.ddl_Teach.Items.Remove(this.ddl_Teach.Items.FindByValue(""));
            if (teac != null)
            {
                DataRow[] dr = teac.Select("CourseID=" + this.ddl_CourseID.SelectedValue + "and TeacherID<>''");
                if (dr != null && dr.Length > 0)
                    this.ddl_Teach.SelectedIndex = this.ddl_Teach.Items.IndexOf(this.ddl_Teach.Items.FindByValue(dr[0]["TeacherID"].ToString()));
            }
        }
    }
}