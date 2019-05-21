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

namespace GKICMP.appstu
{
    public partial class ElectiverStu : PageBaseApp
    {
        public ECourseDAL eCourseDAL = new ECourseDAL();
        public ElectiverDAL electiverDAL = new ElectiverDAL();


        #region 参数集合
        public int EleID
        {
            get
            {
                return GetQueryString<int>("id", -1);
            }
        }
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //ViewState["ETitle"] = this.txt_Name.Text;
                this.hf_User.Value = UserID;

                BandList();
                

            }
        }

        public void BandList()
        {
            //int recordCount = -1;
            //Egovernment_FlowEntity model = new Egovernment_FlowEntity();
            //model.ETitle = ViewState["ETitle"].ToString();
            //model.ETitle = "";
            //model.Begin = Convert.ToDateTime("1900-12-01");
            //model.End = Convert.ToDateTime("9999-12-01");
            //model.AcceptUser = UserID;
            //DataTable dt = egovernment_FlowDAL.GetPaged(PagerAPP.PageSize, PagerAPP.CurrentPageIndex, ref recordCount, model, 2);
            //ECourseEntity model = new ECourseEntity();
            //model.Isdel = (int)CommonEnum.IsorNot.否;
            //DataTable dt = eCourseDAL.GetList(10, 1, ref recordCount, model,"");
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

            ElectiverEntity model = electiverDAL.GetObjByID(EleID);
            if (model != null)
            {
                this.lbl_Ecount.Text = Convert.ToString(model.Ecount);
                this.lbl_ks.Text = model.EBegin.ToString("yyyy-MM-dd");
                this.lbl_js.Text = model.EEnd.ToString("yyyy-MM-dd");
            }

            //超过截止日期后按钮不在显示
            if (DateTime.Parse(((DateTime)model.EEnd).ToString("yyyy-MM-dd")) < DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")))
            {
                
            }

       


        }


        
      






    }
}