/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      LFZ
** 创建日期:    2017年01月03日
** 描 述:       政务详情页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
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
using System.Text;

namespace GKICMP.oamanage
{
    public partial class AllEgovernmentDetail : PageBase
    {

        Egovernment_FlowDAL egovernment_FlowDAL = new Egovernment_FlowDAL();
        EgovernmentDAL egovernmentDAL = new EgovernmentDAL();
        SysLogDAL sysLogDAL = new SysLogDAL();
        DepartmentDAL departmentDAL = new DepartmentDAL();
        SysUserDAL sysuserDAL = new SysUserDAL();
        public int i = 0;

        #region 参数集合
        /// <summary>
        /// ID
        /// </summary>
        public string FID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        public int Flag
        {
            get
            {
                return GetQueryString<int>("flag", -1);
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(FID))
                {
                    //this.RBack.Visible = false;
                    try
                    {
                        // BandData();
                        IsRead();
                        BindInfo();

                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }
       

        #region 是否阅读
        public void IsRead()
        {
            int result = egovernment_FlowDAL.IsRead(FID, UserID);
        }
        #endregion


        #region 绑定数据
        private void BindInfo()
        {
            DataTable dt = egovernmentDAL.GetTable(FID);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.lbl_ETitle.Text =  dt.Rows[0]["GWBT"].ToString();//公文标题
                this.lbl_CreateUserName.Text = dt.Rows[0]["fjr"].ToString(); //发件人
                this.lbl_CreateDate.Text = Convert.ToDateTime(dt.Rows[0]["rq"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");//日期
                this.lbl_Comment.Text = dt.Rows[0]["nr"].ToString();//内容
                this.lbl_IsRead.Text = dt.Rows[0]["yd"].ToString();//已读
                this.lbl_NotRead.Text = dt.Rows[0]["wd"].ToString();//未读
                this.lbl_EType.Text = dt.Rows[0]["gwlx"].ToString();//公文类型
                this.lbl_Ecode.Text = dt.Rows[0]["gdbh"].ToString();//归档编号
                this.lbl_EDepartment.Text = dt.Rows[0]["lwdw"].ToString();//来文单位
                this.lbl_CreateDate1.Text = Convert.ToDateTime(dt.Rows[0]["swsj"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");//收文时间
                this.lbl_EtitleType.Text = dt.Rows[0]["wh"].ToString();//文号
                //this.lbl_EState.Text = dt.Rows[0]["gwzt"].ToString(); //公文状态
                //this.lbl_EState.Text = "批转"; //公文状态
                this.lbl_EState.Text = dt.Rows[0]["WC"].ToString() == "1" ? "归档" : dt.Rows[0]["GWZT"].ToString() == "0" ? "未处理" : dt.Rows[0]["GWZT"].ToString() == "1" ? "批转中" : dt.Rows[0]["GWZT"].ToString() == "0" ? "已处理" : ""; //公文状态
                this.lbl_ETitleName.Text = dt.Rows[0]["GWBT"].ToString();//公文标题
                
                if (dt.Rows[0]["PZ"].ToString() == "1")
                {
                    BindRepeter();//批转流程绑定
                }
                else if (dt.Rows[0]["PZ"].ToString() == "1" && dt.Rows[0]["gwzt"].ToString() == CommonEnum.GWType.归档.ToString())
                {
                    //this.egovernmentPZ.Visible = false;
                }
                else
                {
                    this.egovernment.Visible = false;  //隐藏政务处理标签
                    //this.egovernmentPZ.Visible = false; //隐藏批转政务
                }

            }
        }

        public void BindRepeter()
        {
            DataTable dt = egovernment_FlowDAL.GetFlow(FID);
            this.rp_List.DataSource = dt;
            rp_List.DataBind();

        }
        #endregion

       



    }
}