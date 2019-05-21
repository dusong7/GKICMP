/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2018年01月05日 15时47分10秒
** 描    述:      来访登记详情页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.office
{
    public partial class VisitDetail : PageBase
    {
        public VisitDAL visitDAL = new VisitDAL();

        #region 参数集合
        public int VID
        {
            get
            {
                return GetQueryString<int>("id", -1);
            }
        }
        #endregion


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (VID != -1)
                {
                    InfoBind();
                }
            }
        }
        #endregion


        #region 初始化用户数据
        private void InfoBind()
        {
            VisitEntity model = visitDAL.GetObjByID(VID);
            if (model != null)
            {
                this.ltl_VisitUser.Text = model.VisitUser.ToString().Trim();
                this.ltl_VDate.Text = model.VDate.ToString("yyyy-MM-dd HH:mm");
                this.ltl_VisitReason.Text = model.VisitReason.ToString().Trim();
                this.ltl_SchoolUser.Text = model.SchoolUser.ToString().Trim();
                this.ltl_LinkNum.Text = model.LinkNum.ToString().Trim();
                this.ltl_VMark.Text = model.VMark.ToString().Trim();
                this.ltl_LeaveDate.Text = model.LeaveDate.ToString("yyyy-MM-dd HH:mm") == "0001-01-01 00:00" ? "" : model.LeaveDate.ToString("yyyy-MM-dd HH:mm");
                this.ltl_CreateUser.Text = model.CreateUserName.ToString();
                this.ltl_CreateDate.Text = model.CreateDate.ToString("yyyy-MM-dd HH:mm");
            }
        }
        #endregion
    }
}