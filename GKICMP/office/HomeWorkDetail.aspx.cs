/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年7月10日 10时55分47秒
** 描    述:     作业布置详细页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
******************************************************************/
using System;

using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using GK.GKICMP.Common;

namespace GKICMP.office
{
    public partial class HomeWorkDetail : PageBase
    {
        public HomeWorkDAL homeWorkDAL = new HomeWorkDAL();


        #region 参数集合
        public string HWID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        #endregion


        #region 初始化页面
        protected void Page_Load(object sender, EventArgs e)
        {
           if(!IsPostBack)
           {
               HomeWorkEntity model = homeWorkDAL.GetObjByID(HWID);
               if (model != null)
               {                   
                   this.ltl_CID.Text = model.CidName;
                   this.ltl_CompleteTime.Text = model.CompleteTime.ToString();
                   this.ltl_HomeWork.Text = model.HomeWork;
                   this.ltl_ClaName.Text = model.ClaName;
                   this.ltl_IsSend.Text = CommonFunction.CheckEnum<CommonEnum.IsorNot>(model.IsSend);
                   this.ltl_CreateDate.Text = model.CreateDate.ToString("yyyy-MM-dd HH:mm");
               }
           }
        }
        #endregion
    }
}