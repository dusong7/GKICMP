/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年11月11日 9时55分47秒
** 描    述:      通知公告详细页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using GK.GKICMP.Common;
using System.Text;

namespace GKICMP.app
{
    public partial class AfficheResearchDetail : PageBaseApp
    {
        public AfficheDAL afficheDAL = new AfficheDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SysDataDAL sysDataDAL = new SysDataDAL();

        #region 参数集合
        public string AID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }

        public string Users
        {
            get
            {
                return GetQueryString<string>("users", "");
            }
        }
        #endregion

        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // IsRead();//是否已读

                AfficheEntity model = afficheDAL.GetObjByID(AID, Users);
                if (model != null)
                {
                    this.lbl_AfficheTitle.Text = model.AfficheTitle;
                    this.ltl_AType.Text = model.ATypeName;
                    this.lbl_SendDate.Text = model.SendDate.ToString("yyyy-MM-dd HH:mm");
                    this.lbl_SendUserName.Text = model.SendUserName;
                    this.lbl_AContent.Text = model.AContent;

                    //this.ltl_AcceptUser.Text = model.AcceptUserName;
                    // this.lbl_IsDisplay.Text = CommonFunction.CheckEnum<CommonEnum.IsorNot>(model.IsDisplay);

                    //afficheDAL.Update(AID, Users, (int)CommonEnum.IsorNot.是);//是否已读
                    //this.lbl_IsRead.Text = CommonEnum.IsorNot.是.ToString();

                   
                }

                
                DataTable dt = afficheDAL.GetIsRead(AID, model.AType);
                if (dt != null && dt.Rows.Count > 0)
                {
                    //for (int i = 0; i < dt.Rows.Count; i++)
                    //{
                    //    //this.lbl_IsRead.Text = dt.Rows[0]["YD"].ToString().Trim(',');//已读
                    //    //this.lbl_IsNotRead.Text = dt.Rows[0]["WD"].ToString().Trim(',');//未读

                    //    this.lbl_IsRead.Text = dt.Rows[i]["AcceptUserName"].ToString();//
                    //    this.lbl_IsNotRead.Text = dt.Rows[i]["IsRead"].ToString() == "0" ? "不参与" : "参与";
                    //    this.lbl_AuditMark.Text = dt.Rows[i]["AuditMark"].ToString();//
                    //}
                   
                    this.rp_List.DataSource = dt;
                    rp_List.DataBind();
                }

            }
        }
        #endregion


        public string GetState(object obj, object tbj)
        {
            string isread = obj.ToString();
            string auditmark = tbj.ToString();
            string name = "";

            if (isread == "1" )
            {
                name = "参与";
            }

            if (isread == "0" && auditmark=="")
            {
                name = "未处理";
            }

            if (isread == "0" && auditmark != "")
            {
                name = "不参与";
            }
           
            return name;
        }

        
    }
}