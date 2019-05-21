using System;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;

namespace GKICMP.app
{
    public partial class PersonSubstituteDetail :PageBaseApp
    {
        public AbsentDAL absentDAL = new AbsentDAL();


        #region 参数集合
        public int ABID
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
                if (ABID != -1)
                {
                    AbsentEntity model = absentDAL.GetObjByID(ABID);
                    if (model != null)
                    {
                        this.ltl_AbsentUser.Text = model.AbsentUserName;
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
            }
        }
    }
}