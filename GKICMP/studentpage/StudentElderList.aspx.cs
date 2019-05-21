
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

namespace GKICMP.studentpage
{
    public partial class StudentElderList : PageBase
    {
        public StuElderDAL stuElderDAL = new StuElderDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (UserID != "")
                {
                    this.hf_TID.Value = UserID;
                    BindInfo();
                }
            }
        }
        #region 初始化用户数据
        public void BindInfo()
        {
            int result = 0;
            StuElderEntity model = new StuElderEntity();
            model.StuID = UserID;
            model.Isdel = (int)CommonEnum.IsorNot.否;
            DataTable dt = stuElderDAL.GetPaged(100, 1, ref result, model);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.tr_null.Visible = false;
            }
            else
            {
                this.tr_null.Visible = true;
            }
            this.rp_List.DataSource = dt;
            //Pager.RecordCount = recordCount;
            rp_List.DataBind();
            this.hf_CheckIDS.Value = "";
        }
        #endregion

    
    }
}