/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2018年01月08日 8点30分
** 描   述:       选课成绩编辑
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Text;
using System.Data;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;


namespace GKICMP.electiver
{
    public partial class ElectiverScoreEdit : PageBase
    {
        public SysSetConfigDAL configDAL = new SysSetConfigDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public Electiver_ScoreDAL scoreDAL = new Electiver_ScoreDAL();
        public ElectiverDAL electiverDAL = new ElectiverDAL();
        public Electiver_CourseDAL eleCourseDAL = new Electiver_CourseDAL();
        public Electiver_StuDAL eleStuDAL = new Electiver_StuDAL();

        #region 参数集合
        /// <summary>
        /// SSID 成绩ID
        /// </summary>
        public int SSID
        {
            get
            {
                return GetQueryString<int>("id", -1);
            }
        }

        /// <summary>
        /// 任务ID
        /// </summary>
        public int EleID
        {
            get
            {
                return GetQueryString<int>("eleid", -1);
            }
        }
        #endregion


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.hf_EleID.Value = EleID.ToString();

                if (SSID != -1)
                {
                    InfoBind();
                }
                else
                {
                    ElectiverEntity model = electiverDAL.GetObjByID(Convert.ToInt32(this.hf_EleID.Value));
                    this.ltl_EYear.Text = model.EYear.ToString();
                    this.ltl_TermID.Text = Enum.GetName(typeof(CommonEnum.XQ), model.TermID);
                    this.hf_TermID.Value = model.TermID.ToString();

                    DataTable dt = eleCourseDAL.GetList(Convert.ToInt32(this.hf_EleID.Value.ToString()));
                    CommonFunction.DDlTypeBind(this.ddl_CourseID, dt, "CourseID", "CourseName", "-2");
                } 
            }
        }
        #endregion


        #region 初始化用户数据
        private void InfoBind()
        {
            Electiver_ScoreEntity model = scoreDAL.GetObjByID(SSID);
            this.hf_EleID.Value = model.EleID.ToString();
            this.txt_Score.Text = model.Score.ToString().Trim();
            this.ltl_EYear.Text = model.EYear;
            this.ltl_TermID.Text = CommonFunction.CheckEnum<CommonEnum.XQ>(model.TermID);
            DataTable dt = eleCourseDAL.GetList(model.EleID);
            CommonFunction.DDlTypeBind(this.ddl_CourseID, dt, "CourseID", "CourseName", "-2");
            this.ddl_CourseID.SelectedValue = model.CourseID.ToString();
            StuBind();
            this.hf_StID.Value = model.StID.ToString();
        }
        #endregion


        #region 提交事件
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                Electiver_ScoreEntity model = new Electiver_ScoreEntity();
                model.SSID = SSID;
                model.EleID = Convert.ToInt32(this.hf_EleID.Value);
                model.StID = this.hf_StID.Value.ToString();
                model.Score = Convert.ToInt32(this.txt_Score.Text.ToString().Trim());
                model.CourseID = Convert.ToInt32(this.ddl_CourseID.SelectedValue.ToString());
                model.EYear = this.ltl_EYear.Text.ToString();
                model.TermID = Convert.ToInt32(this.hf_TermID.Value.ToString());
                model.CreateUser = UserID;

                int result = scoreDAL.Edit(model);
                if (result > 0)
                {
                    ShowMessage();
                    int log = SSID == -1 ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, (SSID == -1 ? "添加" : "修改") + "学生【" + this.hf_StuName.Value.ToString() + "】的【" + this.ddl_CourseID.SelectedItem.Text + "】成绩信息", UserID));
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('提交成功！');window.location='ElectiverScoreManage.aspx';", true);
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                return;
            }
        }
        #endregion


        #region 绑定学生信息
        private void StuBind()
        {
            StringBuilder sb = new StringBuilder("");
            DataTable dt = eleStuDAL.GetList(Convert.ToInt32(this.hf_EleID.Value.ToString()), Convert.ToInt32(this.ddl_CourseID.SelectedValue.ToString()), 1);  //departmentDAL.GetClass(UserID, int.Parse(this.hf_XK.Value));
            string str = "";
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    str += "{\"id\":\"" + dt.Rows[i]["StuID"].ToString() +
                       "\",\"text\":\"" + dt.Rows[i]["StuIDName"].ToString() + "\"},";
                }
            }
            sb.Append("<script type='text/javascript'>");
            sb.Append(" $(function () {");
            sb.Append(" $('#Series').combotree({");
            sb.Append(" data: [ ");
            sb.Append(str.TrimEnd(','));
            sb.Append("],");
            sb.Append("multiple: true,");
            sb.Append("});");
            sb.Append(" }); </script>");

            this.ltl_Stu.Text = sb.ToString();
        }
        #endregion


        #region 根据课程信息绑定学生
        protected void ddl_CourseID_SelectedIndexChanged(object sender, EventArgs e)
        {
            StuBind();
        }
        #endregion
    }
}