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
    public partial class AfficheDetail : PageBaseApp
    {
        public AfficheDAL afficheDAL = new AfficheDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();


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
                    this.lbl_IsDisplay.Text = CommonFunction.CheckEnum<CommonEnum.IsorNot>(model.IsDisplay);
                    this.ltl_AType.Text = model.ATypeName;
                    this.lbl_SendDate.Text = model.SendDate.ToString("yyyy-MM-dd HH:mm");
                    this.lbl_SendUserName.Text = model.SendUserName;
                    //this.ltl_AcceptUser.Text = model.AcceptUserName;

                    afficheDAL.Update(AID, Users, (int)CommonEnum.IsorNot.是);//是否已读
                    this.lbl_IsRead.Text = CommonEnum.IsorNot.是.ToString();

                    this.lbl_AContent.Text = model.AContent;
                }
            }
        }
        #endregion

         #region 是否已读
        public void IsRead()
        {
            int result = afficheDAL.Update(AID, Users, (int)CommonEnum.IsorNot.是);
        }
        #endregion

        


    }
}
