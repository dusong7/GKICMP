using System;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;


namespace GKICMP.app
{
    public partial class LeaveAudit : PageBaseApp
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public LeaveDAL leaveDAL = new LeaveDAL();
        public LeaveAuditDAL auditDAL = new LeaveAuditDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }
        
    }
}