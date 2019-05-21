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
    public partial class WorkPlanDetail : PageBase
    {
        public WorkPlanDAL workPlanDAL = new WorkPlanDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
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

                if (!string.IsNullOrEmpty(PlanID))
                {
                    InfoBind();
                }
                else 
                {
                    ShowMessage("查询出错，请稍候再试");
                }
         
            }
        }
        public void InfoBind()
        {
            try
            {
                WorkPlanEntity model = workPlanDAL.GetObjByID(PlanID);
                this.ltl_Weeks.Text = model.EYear + "学年度" + CommonFunction.CheckEnum<CommonEnum.XQ>(model.Term) + "第" + model.WeekNum.ToString() + "周";
                //this.ltl_ExamName.Text = model.ExamName;

                string m = model.ExamName;
                if (m.Contains("&"))       //便于区分以前写过的计划不包含&
                //if (m.IndexOf("&") >= 0)
                {
                    string[] n = m.Split('&');
                    for (int i = 0; i < n.Length - 1; i++)
                    {
                        string name = "";
                        int j = i;
                        name = j == 0 ? "一" : j == 1 ? "二" : j == 2 ? "三" : j == 3 ? "四" : j == 4 ? "五" : i == 5 ? "六" : "日";
                        if (i >= 7)
                        {
                            j = i - 7;
                            name = j == 0 ? "一" : j == 1 ? "二" : j == 2 ? "三" : j == 3 ? "四" : j == 4 ? "五" : j == 5 ? "六" : "日";
                        }
                        this.ltl_ExamName.Text += "【周" + name + "】" + Convert.ToString(n[i]) + "<br>";

                        //this.ltl_ExamName.Text += "【" + Convert.ToString(i + 1) + "】" + Convert.ToString(n[i]) + "<br>";
                    }
                }
                else 
                {
                    this.ltl_ExamName.Text = model.ExamName;
                }
                
                this.ltl_BeginDate.Text = model.BeginDate.ToString("yyyy-MM-dd");
                this.ltl_EndDate.Text = model.EndDate.ToString("yyyy-MM-dd");
                this.ltl_AllUsers.Text = model.AllUsers;
                this.ltl_DutyUser.Text = model.DutyUserName;
                this.ltl_DepID.Text = model.DepIDName;
                this.ltl_CreateUser.Text = model.CreateUserName;
                this.ltl_CreateDate.Text = model.CreateDate.ToString("yyyy-MM-dd hh:mm");
            }
            catch (Exception error)
            {
                ShowMessage("系统查询出错，请查看系统日志信息");
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, error.Message, UserID));
            }
        }
    }
}