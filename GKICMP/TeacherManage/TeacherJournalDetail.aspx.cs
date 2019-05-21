/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      yzr
** 创建日期:    2017年06月14日
** 描 述:       著作详细页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Configuration;
using System.Text;
using System.Data;

namespace GKICMP.teachermanage
{
    public partial class TeacherJournalDetail : PageBase
    {
        SysLogDAL sysLogDAL = new SysLogDAL();
        Teacher_JournalDAL journalDAL = new Teacher_JournalDAL();


        #region 参数集合
        public string TPID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        #endregion



        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Teacher_JournalEntity model = journalDAL.GetObjByID(TPID);
                if (model != null)
                {
                    this.ltl_IsReport.Text = CommonFunction.CheckEnum<CommonEnum.IsorNot>(model.IsReport);
                    this.ltl_JournalType.Text = CommonFunction.CheckEnum<CommonEnum.JournalType>(model.JournalType);
                    this.ltl_OnwerNum.Text = model.OnwerNum.ToString();
                    this.ltl_PubDate.Text = model.PubDate.ToString("yyyy-MM-dd");
                    this.ltl_PubName.Text = model.PubName;
                    this.ltl_PubNum.Text = model.PubNum;
                    this.ltl_RewardName.Text = model.RewardName;
                    this.ltl_SubjectArea.Text = CommonFunction.CheckEnum<CommonEnum.SubjectField>(model.SubjectArea);
                    this.ltl_TidName.Text = model.TidName;
                    this.ltl_TotelNum.Text = model.TotelNum.ToString();
                }
            }
        }
        #endregion
    }
}