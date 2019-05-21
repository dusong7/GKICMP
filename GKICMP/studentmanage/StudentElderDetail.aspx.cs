using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Data;
using System;

namespace GKICMP.studentmanage
{
    public partial class StudentElderDetail : PageBase
    {
        public StuElderDAL stuElderDAL = new StuElderDAL();
        #region 参数集合
        public string StuID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        #endregion


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (StuID != "")
                {
                    BindInfo();
                }
            }
        } 
        #endregion


        #region 初始化用户数据
        public void BindInfo()
        {
            int result = 0;
            StuElderEntity model = new StuElderEntity();
            model.StuID = StuID;
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
        }
        #endregion
    }
}