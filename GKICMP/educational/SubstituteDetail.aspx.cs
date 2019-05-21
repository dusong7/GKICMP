using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using GK.GKICMP.DAL;

namespace GKICMP.educational
{
    public partial class SubstituteDetail : PageBase
    {
        SubstituteDAL substituteDAL = new SubstituteDAL();
        #region 参数集合
        public int SubID
        {
            get
            {
                return GetQueryString<int>("id", 0);
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SubID != 0)
            {
                InfoBand();
            }

        }
        public void InfoBand() 
        {
            try
            {
                SubstituteEntity model = substituteDAL.GetObjByID(SubID);
                this.ltl_ApplyUserName.Text = model.ApplyuserName;
                this.ltl_SubUserName.Text = model.SubuserName;
                this.ltl_SubBegin.Text = model.SubBegin.ToString("yyyy-MM-dd");
                this.ltl_SubBegin1.Text = model.SubBegin1.ToString("yyyy-MM-dd");
                this.ltl_SubCoruseName.Text = model.SubcoruseName;
                this.ltl_SubCoruseName1.Text = model.Subcoruse1Name;
                this.ltl_SubName.Text = "【周" + Week(model.SubName.Substring(0, 1)) + "】第" + model.SubName.Substring(model.SubName.Length - 1) + "节";
                this.ltl_SubName1.Text = "【周" + Week(model.SubName1.Substring(0, 1)) + "】第" + model.SubName1.Substring(model.SubName1.Length - 1) + "节";
                this.ltl_ApplyReason.Text = model.ApplyReason;
                this.ltl_SubState.Text = CommonFunction.CheckEnum<CommonEnum.PraState>(model.SubState);
                this.ltl_ApplyDate.Text = model.ApplyDate.ToString("yyyy-MM-dd");
                if (model.SubState == (int)CommonEnum.PraState.申请中)
                {
                    this.audit.Visible = false;
                }
                else
                {
                    this.ltl_AuditUserName.Text = model.AudituserName;
                    this.ltl_AuditDate.Text = model.AuditDate.ToString("yyyy-MM-dd");
                }
            }
            catch (Exception ex)
            {
                new SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志,ex.Message,UserID));
                ShowMessage("查询出错，请稍后再试");
            }
        }
        public string Week(string week) 
        {
            switch (week) 
            {
                case "1":
                    return "一";
                case "2":
                    return "二";
                case "3":
                    return "三";
                case "4":
                    return "四";
                case "5":
                    return "五";
                case "6":
                    return "六";
                case "7":
                    return "七";
            }
            return "";
        }
    }
}