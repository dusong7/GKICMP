using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using System.Data;
using GK.GKICMP.Entities;

namespace GKICMP.app
{
    public partial class EgovernmentList : PageBaseApp
    {
        Egovernment_FlowDAL egovernment_FlowDAL = new Egovernment_FlowDAL();
        SysLogDAL sysLogDAL = new SysLogDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //ViewState["ETitle"] = this.txt_Name.Text;
                this.hf_User.Value = UserID;

                //BandList();
            }
        }
        public void BandList()
        {
            int recordCount = -1;
            Egovernment_FlowEntity model = new Egovernment_FlowEntity();
            //model.ETitle = ViewState["ETitle"].ToString();
            //model.ETitle = "";
            //model.Begin = Convert.ToDateTime("1900-12-01");
            //model.End = Convert.ToDateTime("9999-12-01");
            //model.AcceptUser = UserID;
           //DataTable dt = egovernment_FlowDAL.GetPaged(PagerAPP.PageSize, PagerAPP.CurrentPageIndex, ref recordCount, model, 2);
            DataTable dt = egovernment_FlowDAL.GetPaged(10, 1, ref recordCount, model, 2);
           //if (dt != null && dt.Rows.Count > 0)
           //{
           //    this.ul_null.Visible = false;
           //}
           //else
           //{
           //    this.ul_null.Visible = true;
           //}
          // this.rp_List.DataSource = dt;
          //// PagerAPP.RecordCount = recordCount;
          // rp_List.DataBind();
        }

       

        #region 分页事件
        /// <summary>
        /// 分页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Pager_PageChanged(object sender, EventArgs e)
        {
            BandList();
        }
        #endregion

        #region 获取政务状态
        /// <summary>
        /// 获取政务状态
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public string getState(object state)
        {
            string value = "";
            if (state.ToString() == "0")
            {
                value = "<span style='color:red'>未处理</span>";
            }
            else if (state.ToString() == "1")
            {
                value = "<span style='color:blue'>批转中</span>";
            }
            else if (state.ToString() == "2")
            {
                value = "已处理";
            }
            else if (state.ToString() == "5")
            {
                value = "<span style='color:#48bd81'>已阅</span>";
            }
            else
            {
                value = "";
            }
            return value;
        }
        #endregion

    }
}