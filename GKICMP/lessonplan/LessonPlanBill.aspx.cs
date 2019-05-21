/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年10月20日 11时27分55秒
** 描    述:      备课计划清单编辑
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Data;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.lessonplan
{
    public partial class LessonPlanBill : PageBase
    {
        public LessonPlan_DetailDAL detailDAL = new LessonPlan_DetailDAL();
        public LessonPlanDAL lessonPlanDAL = new LessonPlanDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();

        #region 参数集合
        /// <summary>
        /// 清单ID
        /// </summary>
        public string LDID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }

        /// <summary>
        /// 备课计划ID
        /// </summary>
        public string LID
        {
            get
            {
                return GetQueryString<string>("lid", "");
            }
        }
        #endregion


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = lessonPlanDAL.GetLessonTeacher(LID);
                CommonFunction.CBLTypeBind(this.chk_TeachID, dt, "TeachID", "TeacherName");

                int week = detailDAL.GetMaxWeekNum(LID);
                this.txt_WeekNum.Text = week.ToString();

                if (LDID != "")
                {
                    InfoBind();
                }
            }
        }
        #endregion


        #region 初始化用户数据
        private void InfoBind()
        {
            LessonPlan_DetailEntity model = detailDAL.GetObjByID(LDID);
            if (model != null)
            {
                this.txt_WeekNum.Text = model.WeekNum.ToString();
                this.txt_PDate.Text = model.PDate.ToString("yyyy-MM-dd");
                this.txt_AContent.Text = model.AContent.ToString();
                string[] bt = model.TIDS.Split(',');
                foreach (string dr in bt)
                {
                    foreach (ListItem li in this.chk_TeachID.Items)
                    {
                        if (dr == li.Value)
                        {
                            li.Selected = true;
                        }
                    }
                }
            }
        }
        #endregion


        #region 提交事件
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                string tids = "";
                LessonPlan_DetailEntity model = new LessonPlan_DetailEntity();
                model.LDID = LDID;
                model.WeekNum = Convert.ToInt32(this.txt_WeekNum.Text.ToString().Trim());
                model.PDate = Convert.ToDateTime(this.txt_PDate.Text.ToString().Trim());
                model.AContent = this.txt_AContent.Text.ToString().Trim();
                foreach (ListItem li in this.chk_TeachID.Items)
                {
                    if (li.Selected)
                    {
                        tids = tids + li.Value + ",";
                    }
                }
                if (tids == "")
                {
                    ShowMessage("请选择指导教师");
                    return;
                }
                //model.TIDS = this.TeachID.Text.ToString();
                model.TIDS = tids.TrimEnd(',');
                model.LID = LID;
                model.IsPrepare = (int)CommonEnum.IsorNot.否;

                int result = detailDAL.Edit(model);
                if (result == 0)
                {
                    ShowMessage();
                    int log = LDID == "" ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, (LDID == "" ? "添加" : "修改") + "第" + this.txt_WeekNum.Text + "周备课计划清单", UserID));
                }
                else if (result == -2)
                {
                    ShowMessage("此备课计划中已有第" + this.txt_WeekNum.Text.ToString() + "周计划清单信息，请检查后重新输入");
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
                ShowMessage(ex.Message);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
            }
        }
        #endregion
    }
}