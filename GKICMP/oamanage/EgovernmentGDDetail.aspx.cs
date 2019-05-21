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
    public partial class EgovernmentGDDetail : PageBase
    {
        Egovernment_FlowDAL egovernment_FlowDAL = new Egovernment_FlowDAL();
        EgovernmentDAL egovernmentDAL = new EgovernmentDAL();
        SysLogDAL sysLogDAL = new SysLogDAL();
        DepartmentDAL departmentDAL = new DepartmentDAL();
        SysUserDAL sysuserDAL = new SysUserDAL();
        public int i = 0;

        #region 参数集合
        /// <summary>
        /// BID 宿舍楼ID
        /// </summary>
        public string EID
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
                if (!string.IsNullOrEmpty(EID))
                {
                        BindInfo();
                }
            }
        }
        #region 绑定数据
        private void BindInfo()
        {
            DataTable dt = egovernmentDAL.GetTableGD(EID);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.ltl_ETitle.Text = this.ltl_ETitle.Text = dt.Rows[0]["GWBT"].ToString();//公文标题
                this.ltl_CreateUserName.Text = dt.Rows[0]["fjr"].ToString(); //发件人
                this.ltl_CreateDate.Text = Convert.ToDateTime(dt.Rows[0]["rq"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");//日期
                this.ltl_Comment.Text = dt.Rows[0]["nr"].ToString();//内容
                this.ltl_IsRead.Text = dt.Rows[0]["yd"].ToString();//已读
                this.ltl_NotRead.Text = dt.Rows[0]["wd"].ToString();//未读
                this.ltl_EType.Text = dt.Rows[0]["gwlx"].ToString();//公文类型
                this.ltl_Ecode.Text = dt.Rows[0]["gdbh"].ToString();//归档编号
                this.ltl_EDepartment.Text = dt.Rows[0]["lwdw"].ToString();//来文单位
                this.ltl_CreateDate1.Text = Convert.ToDateTime(dt.Rows[0]["swsj"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");//收文时间
                this.ltl_EtitleType.Text = dt.Rows[0]["wh"].ToString();//文号
                //this.ltl_EState.Text = dt.Rows[0]["gwzt"].ToString(); //公文状态
                this.ltl_EState.Text = dt.Rows[0]["WC"].ToString() == "1" ? "归档" : dt.Rows[0]["GWZT"].ToString() == "0" ? "未处理" : dt.Rows[0]["GWZT"].ToString() == "1" ? "批转中" : dt.Rows[0]["GWZT"].ToString() == "0" ? "已处理" : ""; //公文状态
                this.ltl_ETitleName.Text = dt.Rows[0]["GWBT"].ToString();//公文标题
                if (dt.Rows[0]["PZ"].ToString() == "1")
                {
                    BindRepeter();
                }
            }
        }

        public void BindRepeter()
        {
            DataTable dt = egovernment_FlowDAL.GetFlowGD(EID);
            this.rp_List.DataSource = dt;
            rp_List.DataBind();

        }
        #endregion
    }
}