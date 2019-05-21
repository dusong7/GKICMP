/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月01日 17时38分29秒
** 描    述:      代课详细信息
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.educationals
{
    public partial class SubstituteDetail : PageBase
    {
        public AbsentDAL absentDAL = new AbsentDAL();



        #region 页面参数
        public int ABID
        {
            get
            {
                return GetQueryString<int>("id", -1);
            }
        }
        #endregion


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (ABID != -1)
                {
                    BindInfo();
                }
            }
        }
        #endregion


        #region 初始化用户数据
        public void BindInfo()
        {
            AbsentEntity model = absentDAL.GetObjByID(ABID);
            if (model != null)
            {
                this.ltl_AbsentUser.Text = model.AbsentUserName;
                this.ltl_CreateDate.Text = model.CreateDate.ToString("yyyy-MM-dd");
                this.ltl_CreateUserName.Text = model.CreateUserName;
                this.ltl_Hourse.Text = model.Hourse.ToString();
                this.ltl_OtherName.Text = model.OtherName;
                this.ltl_Reason.Text = model.Reason;
                this.ltl_SubCoruse.Text = model.SubCoruseName;
                this.ltl_SubCount.Text = model.SubCount.ToString();
                this.ltl_SubDate.Text = model.SubDate.ToString("yyyy-MM-dd");
                this.ltl_SubNum.Text = model.SubNum.ToString();
                this.ltl_SubState.Text = CommonFunction.CheckEnum<CommonEnum.PraState>(model.SubState);
                this.ltl_SubUserName.Text = model.SubUserName;
            }
        }
        #endregion
    }
}