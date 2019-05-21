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
using System.Collections.Generic;

namespace GKICMP.app
{
    public partial class WorkPlan : PageBaseApp
    {
        public WorkPlanDAL workPlanDAL = new WorkPlanDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
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
                DataBindList();//绑定参与人

                //CommonFunction.BindEnum<CommonEnum.XQ>(this.ddl_Term, "-2");//学期
                if (!string.IsNullOrEmpty(PlanID))
                {
                    InfoBind();
                }
                else
                {
                    #region 初始化数据
                    //if (DateTime.Now.Month >= 8)
                    //{
                    //    this.txt_EYear.Text = DateTime.Now.Year + "-" + (DateTime.Now.Year + 1);
                    //    this.txt_Term.Text = CommonFunction.CheckEnum<CommonEnum.XQ>(CommonEnum.XQ.上学期);
                    //    this.hf_Term.Value = ((int)CommonEnum.XQ.上学期).ToString();
                    //}
                    //else
                    //{
                    //    this.txt_EYear.Text = (DateTime.Now.Year - 1) + "-" + DateTime.Now.Year;
                    //    this.txt_Term.Text = CommonFunction.CheckEnum<CommonEnum.XQ>(CommonEnum.XQ.下学期);
                    //    this.hf_Term.Value = ((int)CommonEnum.XQ.下学期).ToString();
                    //}
                    //int year = Convert.ToInt32(DateTime.Now.ToString("yyyy"));
                    //int month = Convert.ToInt32(DateTime.Now.ToString("MM"));
                    //if (month < 9 && month >= 3)
                    //{
                    //    this.txt_EYear.Text = (year - 1) + "-" + year;
                    //    this.txt_Term.Text = CommonEnum.XQ.下学期.ToString();
                    //    this.hf_Term.Value = ((int)CommonEnum.XQ.下学期).ToString();
                    //}
                    //else
                    //{
                    //    if (month <= 12 && month >= 9)
                    //    {
                    //        this.txt_EYear.Text = year + "-" + (year + 1);
                    //    }
                    //    else
                    //    {
                    //        this.txt_EYear.Text = (year - 1) + "-" + year;
                    //    }
                    //    this.txt_Term.Text = CommonEnum.XQ.上学期.ToString();
                    //    this.hf_Term.Value = ((int)CommonEnum.XQ.上学期).ToString();
                    //}
                    #endregion

                    SysSetConfigEntity model = sysSetConfigDAL.GetObjByID();
                    this.txt_EYear.Text = model.EYear;
                    this.txt_Term.Text = CommonFunction.CheckEnum<CommonEnum.XQ>(model.NowTerm);
                    this.hf_Term.Value = model.NowTerm.ToString();

                    int weeks = CommonFunction.Weeks(DateTime.Now, model.BeginFristDate);
                    this.txt_WeekNum.Text = "第" + (weeks).ToString() + "周";//在周数 + 1  该需求用于师范附小，后期还原
                    //this.txt_WeekNum.Text = "第" + (weeks + 1).ToString() + "周";//在周数 + 1  该需求用于师范附小，后期还原


                    this.hf_begin.Value = DateTime.Now.ToString("yyyy-MM-dd");

                    DateTime dttime = DateTime.Now;  //当前时间

                    DateTime startWeek = dttime.AddDays(1 - Convert.ToInt32(dttime.DayOfWeek.ToString("d"))); //本周周一
                    DateTime endWeek = startWeek.AddDays(4);  //本周周日
                    this.hf_end.Value = endWeek.ToString("yyyy-MM-dd");
                    this.hf_UID.Value = "0";
                }
            }
        }

        public void InfoBind()
        {
            //try
            //{
            //    WorkPlanEntity model = workPlanDAL.GetObjByID(PlanID);
            //    this.txt_EYear.Text = model.EYear;
            //    this.ddl_Term.SelectedValue = model.Term.ToString();
            //    this.txt_WeekNum.Text = model.WeekNum.ToString();
            //    this.txt_ExamName.Text = model.ExamName;
            //    this.txt_BeginDate.Text = model.BeginDate.ToString("yyyy-MM-dd");
            //    this.txt_EndDate.Text = model.EndDate.ToString("yyyy-MM-dd");
            //    this.hf_AllUsersText.Value = model.AllUsers;
            //    this.hf_AlluserID.Value = model.AlluserID;
            //    this.hf_DutyUser.Value = model.DutyUser;
            //    this.hf_DepID.Value = model.DepID.ToString();
            //}
            //catch (Exception error)
            //{
            //    ShowMessage("系统查询出错，请查看系统日志信息");
            //    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志, error.Message, UserID));
            //}
        }

        #region 提交
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = "";
                int nid = 0;
                WorkPlanEntity model = new WorkPlanEntity();
                model.PlanID = PlanID;
                model.EYear = this.txt_EYear.Text;
                model.Term = int.Parse(this.hf_Term.Value);
                //model.WeekNum = int.Parse(this.txt_WeekNum.Text.Substring(1, 1));
                //int weeks = CommonFunction.Weeks(DateTime.Now, "~/BaseInfoSet.xml", "TFristDate");

                try
                {
                    if (this.txt_WeekNum.Text != "")
                    {
                        string week = this.txt_WeekNum.Text.Substring(1);
                        string weeks = week.Substring(0, week.Length - 1);
                        model.WeekNum = Convert.ToInt32(weeks);
                    }
                    else
                    {
                        ShowMessage("周数不能为空");
                        return;
                    }
                }
                catch (Exception)
                {
                    ShowMessage("请填写正确的周数（周数为数字）");
                    return;
                }

                //model.ExamName = this.txt_ExamName.Text;
                model.ExamName = this.hf_nr.Value.TrimEnd(',').TrimStart(',');     //内容          
                string aa = this.hf_begin.Value;
                string cc = this.hf_end.Value.Substring(0, 10);
                model.BeginDate = DateTime.Parse(aa);
                model.EndDate = DateTime.Parse(cc);

                //model.BeginDate = DateTime.Parse(this.txt_BeginDate.Text);
                //model.EndDate = DateTime.Parse(this.txt_EndDate.Text);

                //if (this.txt_Users.Text == "")
                //{
                //    ShowMessage("请选择参与人");
                //    return;
                //}
                //else
                //{
                //    model.AllUsers = this.hf_Users.Value;
                //}
                ////string a = Request["txt_Users"].ToString();
                //model.AlluserID = this.txt_Users.Text;

                string ids = this.hf_UID.Value.ToString();
                ids = ids.TrimEnd(',').TrimStart(',');
                model.AlluserID = ids;//参与人
                // model.AllUsers = ids;//参与人
                model.AllUsers = this.hf_AllUsersText.Value.TrimEnd(',');

                model.DepID = int.Parse(this.hf_DepID.Value == "" ? "0" : this.hf_DepID.Value);//部门
                model.DutyUser = this.hf_DutyUser.Value;//责任人

                model.CreateDate = DateTime.Now;
                model.CreateUser = UserID;
                model.IsComplete = (int)CommonEnum.IsorNot.否;
                model.IsSendMess = (int)CommonEnum.IsorNot.否;
                model.Isdel = (int)CommonEnum.IsorNot.否;

                #region 周计划关联新闻
                if (this.cb_IsWeb.Checked)
                {
                    Web_NewsEntity newsmodel = new Web_NewsEntity();

                    //newsmodel.NewsTitle = this.txt_ExamName.Text;
                    //newsmodel.NewsTitle = this.hf_nr.Value.TrimEnd(',').TrimStart(',');

                    newsmodel.NewsTitle = this.txt_WeekNum.Text + "工作计划";

                    newsmodel.Isdel = (int)CommonEnum.Deleted.未删除;
                    newsmodel.NID = 0;
                    newsmodel.MID = this.hf_Menu.Value;
                    newsmodel.NAuthor = UserID;

                    newsmodel.CreateDate = DateTime.Parse(aa);

                    newsmodel.Nstate = 1;//是否发布
                    //置顶设置
                    newsmodel.IsTop = 0;

                    newsmodel.MDescription = 0;

                    newsmodel.IsRecommend = 0;

                    newsmodel.IsImgNews = 0;
                    newsmodel.IsComment = 1;

                    //newsmodel.NContent = this.txt_ExamName.Text;
                    //newsmodel.NContent = this.hf_nr.Value.TrimEnd(',').TrimStart(',');
                    newsmodel.NContent = this.hf_nr.Value.TrimEnd(',').TrimStart(',');

                    newsmodel.NOrder = 0;
                    // model.MSourse = this.txt_MSourse.Text;
                    //newsmodel.NDep = -2;//内容所属部门 3 办公室
                    newsmodel.NDep = int.Parse(this.hf_DepID.Value == "" ? "0" : this.hf_DepID.Value); ;//内容所属部门 3 办公室

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
                    newsmodel.UpdateDate = DateTime.Parse(aa); ;
                    //  model.IsAudit = state == (int)CommonEnum.IsorNot.是 ? (int)CommonEnum.IsorNot.否 : (int)CommonEnum.IsorNot.是;
                    newsmodel.AduitUser = "";
                    newsmodel.AuditState = 1;
                    //上传图片

                    newsmodel.ImageUrl = "";

                    int result1 = web_NewsDAL.Edit(newsmodel, ref nid);
                    if (result1 > 0)
                    {
                        //sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, "添加新闻标题为：" + this.txt_ExamName.Text + "新闻信息", UserID));
                        sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, "周计划关联新闻成功", UserID));
                    }
                    else
                    {
                        sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, "周计划关联新闻失败", UserID));
                        msg = "同步到网站失败。";
                        // return;
                    }
                }
                #endregion

                model.NID = nid;

                //int result = workPlanDAL.Edit(model);
                int result = workPlanDAL.EditAPP(model);
                if (result > 0)
                {
                    int log = PlanID == "" ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, (PlanID == "" ? "增加" : "修改") + "工作计划信息", UserID));
                    //ShowMessage();
                    //Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('提交成功！');window.location='AppMain.aspx';", true);
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('提交成功！');window.location='WorkPlanList.aspx';", true);
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
        #endregion


        #region 绑定责任人
        protected void btn_Serach_Click(object sender, EventArgs e)
        {
            //StringBuilder sb = new StringBuilder("");
            //if (this.hf_DepID.Value != "")
            //{
            //    DataTable dt = sysUserDAL.GetUserByDep(this.hf_DepID.Value);
            //    string str = "";
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        str += "{value:'" + dt.Rows[i]["UID"].ToString() + "',text:'" + dt.Rows[i]["RealName"].ToString() + "'},";
            //    }
            //    str = str.TrimEnd(',');
            //    sb.Append("<script type='text/javascript'>");
            //    sb.Append("(function ($, doc) {");
            //    sb.Append("$.init();");
            //    sb.Append("$.ready(function () {");
            //    sb.Append("    var userPicker1 = new $.PopPicker();");
            //    sb.Append("    userPicker1.setData([");
            //    sb.Append(str.ToString());
            //    sb.Append("    ]);");
            //    sb.Append("    var showUserPickerButton = doc.getElementById('txt_DutyUser');");
            //    sb.Append("    var userResult = doc.getElementById('txt_DutyUser');");
            //    sb.Append("    var userCustInt = doc.getElementById('hf_DutyUser');");
            //    sb.Append("    showUserPickerButton.addEventListener('tap', function (event) {");
            //    sb.Append("        userPicker1.show(function (items) {");
            //    sb.Append("            userResult.value = items[0].text;");
            //    sb.Append("            userCustInt.value = items[0].value;");
            //    sb.Append("        });");
            //    sb.Append("    }, false);");
            //    sb.Append("});");
            //    sb.Append("})");
            //    sb.Append("(mui, document);");
            //    sb.Append("</script>");
            //    this.ltl_DutyUser.Text = sb.ToString();
            //}



        }
        #endregion

        #region 绑定参与人
        public void DataBindList()
        {
            DataTable dt;
            dt = new DepartmentDAL().GetList((int)CommonEnum.Deleted.未删除, (int)CommonEnum.DepType.职能部门);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.rpmodule.DataSource = dt;
                dt.Rows.Add("0", "全体人员");
                this.rpmodule.DataBind();
            }
        }


        protected void rpmodule_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Repeater rpnextModule = (Repeater)e.Item.FindControl("rpnextModule");
            HiddenField hf_DID = (HiddenField)e.Item.FindControl("hf_DID");
            if (hf_DID.Value != "0")
            {
                DataTable dt = sysUserDAL.GetSysUserByDepid((int)CommonEnum.UserType.老师, Convert.ToInt32(hf_DID.Value));
                if (dt != null && dt.Rows.Count > 0)
                {
                    rpnextModule.DataSource = dt;
                    rpnextModule.DataBind();
                }
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("UID", typeof(string));
                dt.Columns.Add("RealName", typeof(string));
                dt.Rows.Add("0", "全体人员");
                rpnextModule.DataSource = dt;
                rpnextModule.DataBind();
            }
        }
        #endregion

    }
}