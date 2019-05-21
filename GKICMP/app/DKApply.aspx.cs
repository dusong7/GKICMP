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

namespace GKICMP.app
{
    public partial class DKApply : PageBaseApp
    {
        public SubstituteDAL substituteDAL = new SubstituteDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
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
                this.txt_BeginTime.Text = model.SubBegin.ToString("yyyy-MM-dd");
                this.txt_EndTime.Text = model.SubEnd.ToString("yyyy-MM-dd");
                this.txt_ApplyReason.Text = model.ApplyReason;
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
                model.SubBegin = Convert.ToDateTime(this.txt_BeginTime.Text);
                model.SubEnd = Convert.ToDateTime(this.txt_EndTime.Text);
                model.Isdel = (int)CommonEnum.IsorNot.否;
                model.ApplyReason = this.txt_ApplyReason.Text;
                model.ApplyUser = UserID;
                model.SubType = 2;
                model.SubState = (int)CommonEnum.PraState.申请中;
                int result = substituteDAL.Add(model);
                if (result > 0)
                {
                    int log = SubID == -1 ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, SubID == -1 ? "添加" : "修改" + "代课信息", UserID));
                    ShowMessage();
                }
                else
                {
                    ShowMessage("提交失败");
                    return;
                }
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