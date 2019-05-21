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
using System.Text;
using System.Web;
using System.Globalization;

namespace GKICMP.office
{
    public partial class WorkPlanEdit : PageBase
    {
        public Web_MenuDAL web_MenuDAL = new Web_MenuDAL();
        public WorkPlanDAL workPlanDAL = new WorkPlanDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SysSetConfigDAL sysSetConfigDAL = new SysSetConfigDAL();
        public Web_NewsDAL web_NewsDAL = new Web_NewsDAL();
        #region 参数集合
        /// <summary>
        /// TEID
        /// </summary>
        public string PlanID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonFunction.BindEnum<CommonEnum.XQ>(this.ddl_Term, "-2");//学期
                DataTable dt = web_MenuDAL.GetTable((int)CommonEnum.Deleted.未删除);
                ModelParent(dt, "-1", this.ddl_WebMenu, "");
                if (!string.IsNullOrEmpty(PlanID))
                {
                    InfoBind();
                }
                else
                {
                    this.hf_NID.Value = "0";
                    SysSetConfigEntity model = sysSetConfigDAL.GetObjByID();
                    //if (DateTime.Now.Month > 8 || DateTime.Now.Month < 3)
                    //{
                    //    this.txt_EYear.Text = DateTime.Now.Year + "-" + (DateTime.Now.Year + 1);
                    //    this.ddl_Term.SelectedValue = ((int)CommonEnum.XQ.上学期).ToString();
                    //}
                    //else
                    //{
                    //    this.txt_EYear.Text = (DateTime.Now.Year - 1) + "-" + DateTime.Now.Year;
                    //    this.ddl_Term.SelectedValue = ((int)CommonEnum.XQ.下学期).ToString();
                    //}
                    this.txt_EYear.Text = model.EYear;
                    this.ddl_Term.SelectedValue = model.NowTerm.ToString();
                    int weeks = CommonFunction.Weeks(DateTime.Now, model.BeginFristDate);
                    this.txt_WeekNum.Text = weeks.ToString();

                    this.txt_BeginDate.Text = DateTime.Now.ToString();

                    DateTime dttime = DateTime.Now;  //当前时间

                    DateTime startWeek = dttime.AddDays(1 - Convert.ToInt32(dttime.DayOfWeek.ToString("d"))); //本周周一
                    DateTime endWeek = startWeek.AddDays(4);  //本周周日
                    this.txt_EndDate.Text = endWeek.ToString();

                }
            }
        }
        #region 递归栏目菜单
        private void ModelParent(DataTable dt, string parentid, DropDownList ddl, string str)
        {
            string str_;
            foreach (DataRow dr in dt.Rows)
            {
                ListItem item = new ListItem();
                item.Text = str + dr["MName"].ToString();     //Bind text
                item.Value = dr["MID"].ToString();  //Bind value
                string parent_id = item.Value;
                ddl.Items.Add(item);
                //  ModelParent(dt, parent_id, ddl, str + "..");
            }
        }
        #endregion
        public void InfoBind()
        {
            try
            {
                WorkPlanEntity model = workPlanDAL.GetObjByID(PlanID);
                this.txt_EYear.Text = model.EYear;
                this.ddl_Term.SelectedValue = model.Term.ToString();
                this.txt_WeekNum.Text = model.WeekNum.ToString();
                this.txt_ExamName.Text = model.ExamName;
                this.txt_BeginDate.Text = model.BeginDate.ToString("yyyy-MM-dd");
                this.txt_EndDate.Text = model.EndDate.ToString("yyyy-MM-dd");
                this.hf_AllUsersText.Value = model.AllUsers;
                this.hf_AlluserID.Value = model.AlluserID;
                this.hf_DutyUser.Value = model.DutyUser;
                this.hf_DepID.Value = model.DepID.ToString();
                if (model.NID != 0)
                {
                    this.cb_IsWeb.Checked = true;
                    this.hf_NID.Value = model.NID.ToString();
                    this.ddl_WebMenu.SelectedValue = model.Menu.ToString();
                }
                else
                    this.hf_NID.Value = "0";
            }
            catch (Exception error)
            {
                ShowMessage("系统查询出错，请查看系统日志信息");
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, error.Message, UserID));
            }
        }

        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = "";
                int nid = 0;
                WorkPlanEntity model = new WorkPlanEntity();
                model.PlanID = PlanID;
                model.EYear = this.txt_EYear.Text;
                model.Term = int.Parse(this.ddl_Term.SelectedValue);

                try
                {
                    model.WeekNum = int.Parse(this.txt_WeekNum.Text);
                }
                catch (Exception )
                {
                    ShowMessage("请填写正确的周数（周数为数字）");
                    return;
                }
                model.ExamName = this.txt_ExamName.Text;
                model.BeginDate = DateTime.Parse(this.txt_BeginDate.Text);
                model.EndDate = DateTime.Parse(this.txt_EndDate.Text);
                if (this.hf_AllUsersText.Value == "")
                {
                    ShowMessage("请选择参与人");
                    return;
                }
                else
                {
                   model.AllUsers = this.hf_AllUsersText.Value;
                }

                model.AlluserID = this.hf_AlluserID.Value;
                //if (this.hf_DepID.Value == "")
                //{
                //    ShowMessage("请选择部门");
                //    return;
                //}
                //else
                //{
                model.DepID = int.Parse(this.hf_DepID.Value == "" ? "0" : this.hf_DepID.Value);
                //}
                //if (this.hf_DutyUser.Value == "")
                //{
                //    ShowMessage("请选择责任人");
                //    return;
                //}
                //else 
                //{ 
                    model.DutyUser = this.hf_DutyUser.Value;
                //}
                
               
                model.CreateDate = DateTime.Now;
                model.CreateUser = UserID;
                model.IsComplete = (int)CommonEnum.IsorNot.否;
                model.IsSendMess = (int)CommonEnum.IsorNot.否;
                model.Isdel = (int)CommonEnum.IsorNot.否;

                if (this.cb_IsWeb.Checked)
                {
                    Web_NewsEntity newsmodel = new Web_NewsEntity();
                    
                    newsmodel.NewsTitle = this.txt_ExamName.Text;
                    newsmodel.Isdel = (int)CommonEnum.Deleted.未删除;
                    newsmodel.NID =int.Parse(this.hf_NID.Value);
                    newsmodel.MID = this.ddl_WebMenu.SelectedValue;
                    newsmodel.NAuthor = UserID;

                    newsmodel.CreateDate = Convert.ToDateTime(this.txt_BeginDate.Text);

                    newsmodel.Nstate = 1;//是否发布
                    //置顶设置
                    newsmodel.IsTop = 0;

                    newsmodel.MDescription = 0;

                    newsmodel.IsRecommend = 0;

                    newsmodel.IsImgNews = 0;
                    newsmodel.IsComment = 1;
                    newsmodel.NContent = this.txt_ExamName.Text;
                    newsmodel.NOrder = 0;
                    // model.MSourse = this.txt_MSourse.Text;
                    newsmodel.NDep = -2;//内容所属部门
                    newsmodel.CommentNumber = 0;//评论次数
                    newsmodel.NColor = "balck";
                    newsmodel.LinkUrl = "";
                    // model.ImageUrl=this.hf_Image.Value;
                    newsmodel.NTtitle = "";
                    newsmodel.NKeyWords = "";
                    newsmodel.NDescription = "";
                    newsmodel.ReadCount = 0;
                    newsmodel.Isdel = (int)CommonEnum.Deleted.未删除;

                    newsmodel.UpdateUser = UserID;
                    newsmodel.UpdateDate = Convert.ToDateTime(this.txt_BeginDate.Text);
                    //  model.IsAudit = state == (int)CommonEnum.IsorNot.是 ? (int)CommonEnum.IsorNot.否 : (int)CommonEnum.IsorNot.是;
                    newsmodel.AduitUser = "";
                    newsmodel.AuditState = 1;
                    //上传图片

                    newsmodel.ImageUrl = "";

                    int result1 = web_NewsDAL.Edit(newsmodel,ref nid);
                    if (result1 > 0)
                    {
                        
                        sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, "添加新闻标题为：" + this.txt_ExamName.Text + "新闻信息", UserID));

                       
                    }
                    else
                    {
                        sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, "周计划关联新闻失败", UserID));
                        msg = "同步到网站失败。";
                       // return;
                    }
                }
                model.NID = nid;

                int result = workPlanDAL.Edit(model);
                if (result > 0)
                {
                    int log = PlanID == "" ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, (PlanID == "" ? "增加" : "修改") + "工作计划信息", UserID));
                    //ShowMessage();
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('提交成功！"+msg+"');window.location='WorkPlanManage.aspx';", true);
                }
                else
                {
                    ShowMessage("提交失败");
                    return;
                }
            }
            catch (Exception error)
            {
                ShowMessage("系统出错，请查看系统日志信息");
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, error.Message, UserID));
            }
        }
    }
}