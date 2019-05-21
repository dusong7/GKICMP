
/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2016年10月15日 13时56分24秒
** 描    述:      教师合同管理界面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Configuration;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;


using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;

namespace GKICMP.lessonplan
{
    public partial class LessonEvaluate : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public Lesson_EvaluateDAL lesson_EvaluateDAL = new Lesson_EvaluateDAL();
        #region 参数集合
        /// <summary>
        /// TCID 合同ID
        /// </summary>
        public string TID
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
                if (TID != "")
                {
                    InfoBind();
                }
            }
        }
        #endregion
        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void InfoBind()
        {
            DataTable dt = lesson_EvaluateDAL.GetList((int)CommonEnum.IsorNot.否, TID);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.tr_null.Visible = false;
            }
            else
            {
                this.tr_null.Visible = true;
            }
            this.rp_List.DataSource = dt;
            rp_List.DataBind();
        }
        #endregion
        #region 附件下载、删除
        protected void rpaccess_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString().Trim();
            if (e.CommandName.ToString() == "del")
            {
                int result = lesson_EvaluateDAL.DeleteBat(id, (int)CommonEnum.IsorNot.是);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除评价信息", UserID));
                    ShowMessage("删除成功");
                }
                else 
                {
                    ShowMessage("删除失败");
                }
                InfoBind();
            }

        }
        #endregion

        protected void btn_Sumbit_Click(object sender, System.EventArgs e)
        {
            try
            {
                Lesson_EvaluateEntity model = new Lesson_EvaluateEntity();
                model.LEID = "";
                model.TID = TID;
                model.Term = (DateTime.Now.Month > 9||DateTime.Now.Month<3) ? (int)CommonEnum.XQ.上学期 : (int)CommonEnum.XQ.下学期;
                model.EvalDate = DateTime.Now;
                model.EvalUser = UserID;
                model.Remark = this.txt_Remark.Text;
                model.Degree = this.ddl_Degree.SelectedValue;
                model.EYear = (DateTime.Now.Month > 9 || DateTime.Now.Month < 3) ? (DateTime.Now.Year.ToString() + "-" + DateTime.Now.AddYears(1).Year.ToString()) : (DateTime.Now.AddYears(-1).Year.ToString() + "-" + DateTime.Now.Year.ToString()); 
                model.Isdel = (int)CommonEnum.IsorNot.否;
                int result = lesson_EvaluateDAL.Edit(model);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, "添加教师备课信息", UserID));
                    ShowMessage();
                }
                else { ShowMessage("提交失败"); return; }
            }
            catch (Exception error)
            {
                 sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, error.Message, UserID));
                 ShowMessage(error.Message);
                 return;
            }
        }
    }
}