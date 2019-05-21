/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      liufuzhou
** 创建日期:    2017年8月11日 18时04分
** 描 述:       考试管理
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;

namespace GKICMP.educational
{
    public partial class ExamRoomEdit : PageBase
    {
        public ExamDAL examDAL = new ExamDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SysDataDAL sysDataDAL = new SysDataDAL();
        public GradeDAL gradeDAL = new GradeDAL();
        public Exam_RoomDAL exam_RoomDAL = new Exam_RoomDAL();
        //public Exam_RoomDAL eRoomDAL = new Exam_RoomDAL();
        //public TermDAL termDAL = new TermDAL();
        //public ExamSubjectDAL examSubjectDAL = new ExamSubjectDAL();


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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              //  this.txt_PeoNum.Text = "30";
                DDLBind();
                if (EID != -1)
                {
                    InfoBind();
                }

            }
        }
        #region 下拉框绑定
        /// <summary>
        /// 下拉框绑定
        /// </summary>
        private void DDLBind()
        {
            //DataTable dt = examDAL.getListByDDL((int)CommonEnum.IsorNot.否);
            //CommonFunction.DDlTypeBind(this.ddl_EID, dt, "EID", "ExamName", "-2");//年级 
          

        }
        #endregion


        #region 初始化用户数据
        /// <summary>
        /// 初始化用户数据
        /// </summary>
        private void InfoBind()
        {
            //ExamEntity model = examDAL.GetObjByID(EID);
            //if (model != null)
            //{
            //    this.txt_ExamName.Text = model.ExamName.ToString();
            //    this.ddl_GID.SelectedValue = model.GID.ToString();
            //    this.ddl_Term.SelectedValue = model.Term.ToString();
            //    this.txt_BeginDate.Text = model.BeginDate.ToString("yyyy-MM-dd HH:mm");
            //    this.txt_EndDate.Text = model.EndDate.ToString("yyyy-MM-dd HH:mm");
            //    this.txt_PeoNum.Text = model.PeoNum.ToString();
            //    //this.rdo_SeatType.SelectedValue = model.SeatType.ToString();
            //    //this.rdo_SeatModel.SelectedValue = model.SeatModel.ToString();
            //    this.txt_EYear.Text = model.EYear.ToString();
            //    //if (rdo_SeatType.SelectedValue == "2")
            //    //{
            //    //    this.txt_PeoNum.Enabled = true;
            //    //}
            //}
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
                //ExamEntity model = new ExamEntity();
                //model.EID = EID;
                //model.ExamName = this.txt_ExamName.Text.Trim();
                //model.GID = Convert.ToInt32(this.ddl_GID.SelectedValue.ToString());
                //model.Term = Convert.ToInt32(this.ddl_Term.SelectedValue.ToString());
                //model.CreateUser = UserID;
                //model.BeginDate = Convert.ToDateTime(this.txt_BeginDate.Text.ToString());
                //model.EndDate = Convert.ToDateTime(this.txt_EndDate.Text.ToString());
                //if (EID == -1)
                //{
                //    if (model.BeginDate < DateTime.Now)
                //    {
                //        ShowMessage("考试开始时间不能小于当前时间");
                //        return;
                //    }
                //    if (model.EndDate <= model.BeginDate)
                //    {
                //        ShowMessage("考试结束时间要大于考试开始时间");
                //        return;
                //    }
                //}
                //else
                //{
                //    if (model.EndDate <= model.BeginDate)
                //    {
                //        ShowMessage("考试结束时间不能小于考试开始时间");
                //        return;
                //    }
                //}
                //model.PeoNum = Convert.ToInt32(this.txt_PeoNum.Text.ToString());
                //model.SeatType = 1;
                ////if (model.SeatType == 2 && model.PeoNum <= 0)
                ////{
                ////    ShowMessage("选择分考场考试时，考场最多人数必须大于0");
                ////    return;
                ////}
                //model.SeatModel = 1;
                //model.EYear = this.txt_EYear.Text.Trim();
                //model.Isdel = (int)CommonEnum.IsorNot.否;

                //int result = examDAL.Edit(model);
                //if (result == 0)
                //{
                //    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志, (EID == -1 ? "添加" : "修改") + "考试名称为：" + this.txt_ExamName.Text.ToString() + "的考试信息", UserID));
                //    ShowMessage();
                //}
                //else if (result == -2)
                //{
                //    ShowMessage("该考试信息已存在，请重新输入");
                //    return;
                //}
                //else
                //{
                //    ShowMessage("提交失败");
                //    return;
                //}
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                ShowMessage(ex.Message);
            }
        }
        #endregion
    }
}