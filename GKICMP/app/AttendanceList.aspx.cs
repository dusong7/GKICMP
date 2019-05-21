using System;
using System.Web.UI.WebControls;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Data;
using System.IO;
using System.Collections.Generic;


namespace GKICMP.app
{
    public partial class AttendanceList : PageBaseApp
    {
        public SysUserDAL UserDal = new SysUserDAL();
        public AttendRecordDAL attendRecordDAL = new AttendRecordDAL();

        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ltl_UserName.Text = UserRealName;
            SysUserEntity model = UserDal.GetObjByID(UserID);
            if (model != null)
            {
                try
                {
                    this.image1.ImageUrl = model.Photos.ToString() == "" ? "../images/t_male.png" : model.Photos.ToString();
                }
                catch (Exception)
                {
                    this.image1.ImageUrl = "../images/t_male.png";
                }
            }

            DataBindList();

        }
        #endregion


        #region 获取查询条件
        public void GetCondition()
        {
            //ViewState["AfficheTitle"] = CommonFunction.GetCommoneString(this.txt_Name.Text.Trim());
            //ViewState["AType"] = -2;
            //ViewState["IsRead"] = -2;
            //ViewState["begin"] = "1900-01-01";
            //ViewState["end"] = "9999-12-31";
        }
        #endregion


        #region 数据绑定
        public void DataBindList()
        {
            int recordCount = 0;
            AttendRecordEntity model = new AttendRecordEntity();
            model.UserName = UserID;
            //model.Begin = Convert.ToDateTime(ViewState["begin"].ToString());
            //model.End = Convert.ToDateTime(ViewState["end"].ToString());
            model.Begin = Convert.ToDateTime("2018-06-01");
            model.End = Convert.ToDateTime("2018-06-30");
        

            //DataTable dt = attendRecordDAL.AnalysisCounts(10, 1, ref recordCount, model, (int)CommonEnum.UserType.老师);
            // if (dt != null && dt.Rows.Count > 0)
            //{
                //this.lbl_YD.Text=dt.Rows[0]["YD"].ToString();
                //this.lbl_SD.Text=dt.Rows[0]["SD"].ToString();
                //this.lbl_CD.Text=dt.Rows[0]["CD"].ToString();
                //this.lbl_ZT.Text=dt.Rows[0]["ZT"].ToString();
                //this.lbl_KG.Text=dt.Rows[0]["KG"].ToString();
                //this.lbl_QJ.Text=dt.Rows[0]["QJ"].ToString();
                //this.lbl_WC.Text=dt.Rows[0]["WC"].ToString();
             //}


            
        }
        #endregion





    }
}