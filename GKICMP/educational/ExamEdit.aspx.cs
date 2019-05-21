/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      殷志瑞
** 创建日期:    2017年6月8日 18时04分
** 描 述:       考试管理
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;
using System.Text;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.educational
{
    public partial class ExamEdit : PageBase
    {
        public ExamDAL examDAL = new ExamDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SysDataDAL sysDataDAL = new SysDataDAL();
        public GradeDAL gradeDAL = new GradeDAL();


        #region 参数集合
        /// <summary>
        /// EID
        /// </summary>
        public int EID
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
                this.txt_PeoNum.Text = "30";
                DDLBind();
                if (EID != -1)
                {
                    InfoBind();
                }
                else
                {
                    if (DateTime.Now.Month > 8)
                    {
                        this.txt_EYear.Text = DateTime.Now.Year + "-" + (DateTime.Now.Year + 1);
                        this.ddl_Term.SelectedValue = ((int)CommonEnum.XQ.上学期).ToString();
                    }
                    else
                    {
                        this.txt_EYear.Text = (DateTime.Now.Year - 1) + "-" + DateTime.Now.Year;
                        this.ddl_Term.SelectedValue = ((int)CommonEnum.XQ.下学期).ToString();
                    }
                    //int weeks = CommonFunction.Weeks(DateTime.Now, "~/BaseInfoSet.xml", "TFristDate");
                    //this.txt_WeekNum.Text = weeks.ToString();
                }
                ClassBand(this.ddl_GID.SelectedValue);
            }
        }
        #endregion


        #region 下拉框绑定
        /// <summary>
        /// 下拉框绑定
        /// </summary>
        private void DDLBind()
        {
            DataTable dtGrade = gradeDAL.GetListAll((int)CommonEnum.IsorNot.否);
            CommonFunction.DDlTypeBind(this.ddl_GID, dtGrade, "GID", "GradeName", "-2");//年级 
            CommonFunction.BindEnum<CommonEnum.XQ>(this.ddl_Term, "-2");
            DataTable dt = examDAL.GetTableByGID(Convert.ToInt32(this.ddl_GID.SelectedValue));
            this.ddl_SeatModel.Items.Clear();
            if (dt != null && dt.Rows.Count > 0)
            {
                CommonFunction.DDlTypeBind(this.ddl_SeatModel, dt, "EID", "ExamName", "-999");
            }
            this.ddl_SeatModel.Items.Insert(0, (new ListItem("不排序", "-2")));
        }
        #endregion


        #region 初始化用户数据
        /// <summary>
        /// 初始化用户数据
        /// </summary>
        private void InfoBind()
        {
            ExamEntity model = examDAL.GetObjByID(EID);
            if (model != null)
            {
                this.txt_ExamName.Text = model.ExamName.ToString();
                this.ddl_GID.SelectedValue = model.GID.ToString();
                this.ddl_Term.SelectedValue = model.Term.ToString();
                this.txt_BeginDate.Text = model.BeginDate.ToString("yyyy-MM-dd HH:mm");
                this.txt_EndDate.Text = model.EndDate.ToString("yyyy-MM-dd HH:mm");
                this.txt_PeoNum.Text = model.PeoNum.ToString();
                //DataTable dt = examDAL.GetTableByGID(Convert.ToInt32(this.ddl_GID.SelectedValue));
                //if (dt != null && dt.Rows.Count > 0)
                //{
                //    CommonFunction.DDlTypeBind(this.ddl_SeatModel, dt, "EID", "ExamName", "-999");
                //}
                //this.ddl_SeatModel.Items.Insert(0, (new ListItem("不排序", "-2")));
                this.ddl_SeatModel.SelectedValue = model.SeatModel.ToString();
                //this.rdo_SeatType.SelectedValue = model.SeatType.ToString();
                //this.rdo_SeatModel.SelectedValue = model.SeatModel.ToString();
                this.txt_EYear.Text = model.EYear.ToString();
                this.txt_ClassRoom.Text = model.ClassRoom;
                //if (rdo_SeatType.SelectedValue == "2")
                //{
                //    this.txt_PeoNum.Enabled = true;
                //}
            }
            string depid = examDAL.GetDepIDByEID(EID);
            this.txt_Student.Text = depid;
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
                string ClassRoom = this.txt_ClassRoom.Text;
                ExamEntity model = new ExamEntity();
                model.EID = EID;
                model.ExamName = this.txt_ExamName.Text.Trim();
                model.GID = Convert.ToInt32(this.ddl_GID.SelectedValue.ToString());
                model.Term = Convert.ToInt32(this.ddl_Term.SelectedValue.ToString());
                model.CreateUser = UserID;
                model.BeginDate = Convert.ToDateTime(this.txt_BeginDate.Text.ToString());
                model.EndDate = Convert.ToDateTime(this.txt_EndDate.Text.ToString());

                if (EID == -1)
                {
                    if (model.BeginDate < DateTime.Now)
                    {
                        ShowMessage("考试开始时间不能小于当前时间");
                        return;
                    }
                    if (model.EndDate <= model.BeginDate)
                    {
                        ShowMessage("考试结束时间要大于考试开始时间");
                        return;
                    }
                }
                else
                {
                    if (model.EndDate <= model.BeginDate)
                    {
                        ShowMessage("考试结束时间不能小于考试开始时间");
                        return;
                    }
                }
                model.PeoNum = Convert.ToInt32(this.txt_PeoNum.Text.ToString());
                model.SeatType = 1;
                //if (model.SeatType == 2 && model.PeoNum <= 0)
                //{
                //    ShowMessage("选择分考场考试时，考场最多人数必须大于0");
                //    return;
                //}
                model.SeatModel = Convert.ToInt32(this.ddl_SeatModel.SelectedValue);
                model.EYear = this.txt_EYear.Text.Trim();
                model.Isdel = (int)CommonEnum.IsorNot.否;
                string Stu = this.txt_Student.Text;
                int result = examDAL.Edit(model, ClassRoom, Stu);
                if (result == 0)
                {
                    int log = EID == -1 ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, (EID == -1 ? "添加" : "修改") + "考试名称为：" + this.txt_ExamName.Text.ToString() + "的考试信息", UserID));
                    ShowMessage();
                }
                else if (result == -2)
                {
                    ShowMessage("该考试信息已存在，请重新输入");
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
                ShowMessage(ex.Message);
            }
        }
        #endregion

        protected void ddl_GID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = this.ddl_GID.SelectedValue;
            this.ltl_Stu.Text = "";
            ClassBand(id);
            DataTable dt = examDAL.GetTableByGID(Convert.ToInt32(this.ddl_GID.SelectedValue));
            this.ddl_SeatModel.Items.Clear();
            if (dt != null && dt.Rows.Count > 0)
            {
                CommonFunction.DDlTypeBind(this.ddl_SeatModel, dt, "EID", "ExamName", "-999");
            }
            this.ddl_SeatModel.Items.Insert(0, (new ListItem("不排序", "-2")));
        }

        public void ClassBand(string id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<script>");
            sb.Append("$(function(){");
            sb.Append("$('#txt_Student').combotree('reload', '../ashx/ClassRoomList.ashx?method=StuList&id=" + id + "');");
            sb.Append("});");
            sb.Append("</script>");
            this.ltl_Stu.Text = sb.ToString();
        }
    }
}