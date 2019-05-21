/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月01日 17时38分29秒
** 描    述:      题目详细信息
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.educational
{
    public partial class ExerciseDetail : PageBase
    {
        public ExerciseDAL exeriseDAL = new ExerciseDAL();


        #region 参数集合
        public int EID
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
                ExerciseEntity model = exeriseDAL.GetObjByID(EID);
                if (model != null)
                {
                    this.ltl_Title.Text = model.Ttile;
                    this.ltl_Answer.Text = model.Answer;
                    this.ltl_Option.Text = model.Options;
                    this.ltl_CourseName.Text = model.CIDName;
                    this.ltl_Difficulty.Text = CommonFunction.CheckEnum<CommonEnum.DifficultyType>(model.Difficulty);
                    this.ltl_EType.Text = CommonFunction.CheckEnum<CommonEnum.ExerciseType>(model.EType);
                    this.ltl_GradeID.Text = CommonFunction.CheckEnum<CommonEnum.NJ>(model.GradeID);
                    this.ltl_Score.Text = model.Score.ToString(); ;
                    this.ltl_Term.Text = CommonFunction.CheckEnum<CommonEnum.XQ>(model.Term);
                    if (model.EType != (int)CommonEnum.ExerciseType.单项选 && model.EType != (int)CommonEnum.ExerciseType.多选题)
                    {
                        this.ltl_Option.Visible = false;
                    }
                    else
                    {
                        this.ltl_Option.Visible = true;
                    }
                }
            }
        }
        #endregion
    }
}