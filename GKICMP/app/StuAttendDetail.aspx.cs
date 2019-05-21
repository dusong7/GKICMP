/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      yzr
** 创建日期:     2017年03月03日
** 描 述:       晨检申报详细页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Web.UI.WebControls;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Data;
using System.IO;

namespace GKICMP.app
{
    public partial class StuAttendDetail : PageBaseApp
    {
        public StuAttendDAL stuattendDAL = new StuAttendDAL();


        #region 参数集合
        public int DID
        {
            get
            {
                return GetQueryString<int>("id", -1);
            }
        }
        public DateTime Date
        {
            get
            {
                return GetQueryString<DateTime>("date", Convert.ToDateTime("1900-01-01"));
            }
        }
        #endregion


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                StuAttendEntity model = stuattendDAL.GetObjByID(DID, Date);
                if (model != null)
                {
                    this.ltl_AllIns.Text = model.AllIns.ToString();
                    this.ltl_Compassionate.Text = model.CompassionateNames.TrimEnd(',');
                    this.ltl_CreateDate.Text = model.CreateDate.ToString("yyyy-MM-dd");
                    this.ltl_Infectious.Text = model.InfectiousNames.TrimEnd(',');
                    this.ltl_LeaveUser.Text = model.LeaveUserNames.TrimEnd(',');
                    this.ltl_RealCOunt.Text = model.RealCOunt.ToString();
                    this.lbl_Sick.Text = model.SickNames.TrimEnd(',');
                    this.lbl_DIDName.Text = model.DIDName;
                }
            }
        }
        #endregion
    }
}