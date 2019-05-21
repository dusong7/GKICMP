/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      lfz
** 创建日期:    2017年02月27日
** 描 述:       用户编辑页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;

namespace GKICMP.onlinecourse
{
    public partial class NetworkTeachDetail : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public NetworkTeachDAL networkTeachDAL = new NetworkTeachDAL();
        public CourseDAL courseDAL = new CourseDAL();
        #region 参数集合
        /// <summary>
        /// UID
        /// </summary>
        public string NTID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                if (NTID != "")
                {
                    InfoBind();
                }
            }
        }
        #region 信息绑定
        public void InfoBind()
        {
            NetworkTeachEntity model = networkTeachDAL.GetObjByID(NTID);
            this.txt_NTTName.Text = model.NTTName;
            this.ddl_EPID.Text = model.GName;
            this.ddl_CID.Text = model.CName;
            #region 班级绑定
           // cblBand();
            DataTable dt = networkTeachDAL.GetClass(NTID);
            string value="";
            foreach (DataRow dr in dt.Rows)
            {
                value += dr["ClaName"].ToString() + ",";
            }
            this.cbl_Class.Text = value.Trim(',');
            #endregion
            this.txt_TeaBegin.Text = model.TeaBegin.ToString("yyyy-MM-dd HH:mm");
            this.txt_TeaEnd.Text = model.TeaEnd.ToString("yyyy-MM-dd HH:mm");
            this.cb_IsOrNot.Text = model.IsCommunication == 1 ? "允许" : "不允许";
           // this.hf_UpFile.Value = model.NTTUrl;
            this.ltl_CreateDate.Text = model.CreateDate.ToString("yyyy-MM-dd HH:mm");
            this.ltl_CreateName.Text = model.CreateName;
            //string cla = "";
            //foreach (ListItem li in this.cbl_Class.Items) 
            //{
            //    if (li.Selected)
            //    {
            //        cla = cla + li.Value + ",";
            //    }
            //}
        }
        #endregion

        protected void lbtn_Sourse_Click(object sender, EventArgs e)
        {
            NetworkTeachEntity model = networkTeachDAL.GetObjByID(NTID);

            if (!CommonFunction.UpLoadFunciotn(model.NTTUrl, model.NTTName))
            {
                ShowMessage("资源不存在，请联系系统管理员");
                return;
            }
        }
        public string GetName() 
        {
            return this.txt_NTTName.Text;
        }
    }
}