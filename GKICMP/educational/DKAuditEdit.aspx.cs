/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      lfz
** 创建日期:      2017年08月16日 16时54分10秒
** 描    述:      调代课操作类
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.educational
{
    public partial class DKAuditEdit : PageBase
    {
        public SubstituteDAL substituteDAL = new SubstituteDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public TeacherDAL teacherDAL = new TeacherDAL();
        public int SubID
        {
            get
            {
                return GetQueryString<int>("id", -1);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = teacherDAL.GetList();
                CommonFunction.DDlTypeBind(this.ddl_SubUser, dt, "TID", "RealName", "-2");
                if (SubID != -1)
                {
                    InfoBand();
                }
            }
        }
        public void InfoBand()
        {
            try
            {
                SubstituteEntity model = substituteDAL.GetObjByID(SubID);
                this.ltl_ApplyUserName.Text = model.ApplyuserName;
                this.ltl_SubBegin.Text = model.SubBegin.ToString("yyyy-MM-dd") + "--" + model.SubEnd.ToString("yyyy-MM-dd");
                this.ltl_ApplyReason.Text = model.ApplyReason;
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                ShowMessage(ex.Message);
            }
        }

        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                SubstituteEntity model = new SubstituteEntity();
                model.SubID = SubID;
                model.SubUser = this.ddl_SubUser.SelectedValue;
                model.AuditUser = UserID;
                model.AuditDate = DateTime.Now;
                model.SubState = (int)CommonEnum.PraState.通过;

                //SubstituteEntity smodel = substituteDAL.GetObjByID(SubID);
                //if (smodel != null)
                //{
                //    model.SubBegin = smodel.SubBegin;
                //    model.SubEnd = smodel.SubEnd;
                //}

                int result = substituteDAL.AuditByDK(model);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, "代课审核", UserID));
                    ShowMessage();
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
                return;
            }
        }
    }
}