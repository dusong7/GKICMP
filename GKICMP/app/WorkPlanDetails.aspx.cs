using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Data;
using System.Text;

namespace GKICMP.app
{
    public partial class WorkPlanDetails : PageBaseApp
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

        #region 页面加载
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
        #endregion

        #region 绑定数据
        public void InfoBind()
        {
            try
            {
                WorkPlanEntity model = workPlanDAL.GetObjByID(PlanID);
                if (model != null)
                {
                    int complete = model.IsComplete;
                    if (complete == 1) //1为已完成
                    {
                        this.btn_YY.Visible = false;
                    }
                    else
                    {
                        this.btn_YY.Visible = true;
                    }
                }

                //WorkPlanEntity model = workPlanDAL.GetObjByID(PlanID);
                this.lbl_ETitle.Text = model.EYear + "学年度" + CommonFunction.CheckEnum<CommonEnum.XQ>(model.Term) + "第" + model.WeekNum.ToString() + "周";
                this.lbl_SendDate.Text = model.DutyUserName;
                this.lbl_EContent.Text = model.ExamName;
                this.ltl_BeginDate.Text = model.BeginDate.ToString("yyyy-MM-dd");
                this.ltl_EndDate.Text = model.EndDate.ToString("yyyy-MM-dd");
                this.ltl_AllUsers.Text = model.AllUsers;

                this.ltl_DepID.Text = model.DepIDName;
            }
            catch (Exception error)
            {
                ShowMessage("系统查询出错，请查看系统日志信息");
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, error.Message, UserID));
            }
        }
        #endregion

        #region 完成
        protected void btn_YY_Click(object sender, EventArgs e)
        {
            try
            {
                int result = workPlanDAL.CompLete(PlanID, (int)CommonEnum.IsorNot.是);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "完成工作计划", UserID));
                    RegisterStartupScript("false", "<script>alert('提交成功');window.location.href='WorkPlanList.aspx'</script>");
                }
                else
                {
                    ShowMessage("提交失败");
                }
                InfoBind();
            }
            catch (Exception error)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, error.Message, UserID));
                RegisterStartupScript("false", "<script>alert('提交失败');window.location.href='WorkPlanList.aspx'</script>");
            }

        }
        #endregion

    }
}