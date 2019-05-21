
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
using System.IO;

namespace GKICMP.office
{
    public partial class LeaveRecordDetail : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public LeaveDAL leaveDAL = new LeaveDAL();
        public LeaveAuditDAL auditDAL = new LeaveAuditDAL();
        protected int count = 0;


        #region 参数集合
        public string LID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }

        /// <summary>
        /// 1学生 2其他
        /// </summary>
        public int Flag
        {
            get
            {
                return GetQueryString<int>("flag", -1);
            }
        }
        #endregion


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LeaveEntity model = leaveDAL.GetObjByID(LID);
                if (model != null)
                {
                    this.ltl_BeginDate.Text = model.BeginDate.ToString("yyyy-MM-dd") + (Convert.ToInt32(model.BeginDate.ToString("HH")) == 7 ? " 上午" : " 下午");
                    this.ltl_EndDate.Text = model.EndDate.ToString("yyyy-MM-dd") + (Convert.ToInt32(model.EndDate.ToString("HH")) == 13 ? " 上午" : " 下午");
                    this.ltl_LeaveDays.Text = model.LeaveDays.ToString();
                    this.ltl_LeaveMark.Text = model.LeaveMark.ToString();                  
                    this.ltl_LeaveUser.Text = model.LeaveUserName;
                    AccessBind();
                }
            }
        }
        #endregion


        public string getFileName(string obj)
        {
            return Path.GetFileNameWithoutExtension(obj);
        }


        #region 附件下载、删除
        protected void rpaccess_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string accessid = e.CommandArgument.ToString().Trim();
            string name = Path.GetFileNameWithoutExtension(accessid);

            if (!CommonFunction.UpLoadFunciotn(accessid, name))
            {
                ShowMessage("下载文件不存在，请联系系统管理员");
                return;
            }

        }
        #endregion


        #region 附件绑定
        /// <summary>
        /// 附件绑定
        /// </summary>
        /// <param name="rpcontr"></param>
        /// <param name="objid"></param>
        /// <param name="flag"></param>
        public void AccessBind()
        {
            DataTable ds = leaveDAL.GetTable(LID);
            rp_File.DataSource = ds;
            rp_File.DataBind();
        }
        #endregion
    }
}