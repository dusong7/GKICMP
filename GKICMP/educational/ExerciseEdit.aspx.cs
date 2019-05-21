/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年01月06日 09时52分17秒
** 描    述:      题目编辑页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Data;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using System.Text;

namespace GKICMP.educational
{
    public partial class ExerciseEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public ExerciseDAL exerciseDAL = new ExerciseDAL();
        public CourseDAL courseDAL = new CourseDAL();


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
                CommonFunction.BindEnum<CommonEnum.ExerciseType>(this.ddl_EType, "-99");
                CommonFunction.BindEnum<CommonEnum.DifficultyType>(this.ddl_Difficulty, "-99");
                CommonFunction.BindEnum<CommonEnum.NJ>(this.ddl_GradeID, "-99");
                CommonFunction.BindEnum<CommonEnum.XQ>(this.ddl_Term, "-99");
                DataTable dtCourse = courseDAL.GetList();
                CommonFunction.DDlTypeBind(this.ddl_CourseName, dtCourse, "CID", "CourseName", "-999");
                Ddl();
                if (EID != -1)
                {
                    BindInfo();
                }
            }
        }
        #endregion


        #region 提交
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                ExerciseEntity model = new ExerciseEntity();
                model.EID = EID;
                model.CID = Convert.ToInt32(this.ddl_CourseName.SelectedValue);
                model.Difficulty = Convert.ToInt32(this.ddl_Difficulty.SelectedValue);
                model.EType = Convert.ToInt32(this.ddl_EType.SelectedValue);
                model.GradeID = Convert.ToInt32(this.ddl_GradeID.SelectedValue);
                model.Score = Convert.ToInt32(this.txt_Score.Text.Trim());
                model.Ttile = this.txt_Ttile.Text.Trim();
                model.Term = Convert.ToInt32(this.ddl_Term.SelectedValue);
                //if (model.EType == (int)CommonEnum.ExerciseType.单项选)
                //{
                //    model.Answer = this.rbl_Answer.SelectedValue;
                //}
                //else if (model.EType == (int)CommonEnum.ExerciseType.多选题)
                //{
                //    string name = "";
                //    for (int i = 0; i < ckl_Answer.Items.Count; i++)
                //    {
                //        if (ckl_Answer.Items[i].Selected)
                //        {
                //            name += ckl_Answer.Items[i].Value + ",";
                //        }
                //    }
                //    model.Answer = name.ToString().TrimEnd(',');
                //}
                //else
                //{
                //    model.Answer = this.txt_Answer.Text.Trim();
                //}
                model.Answer = this.txt_Answer.Text.Trim();
                model.Options = this.txt_Options.Text.Trim();
                model.Isdel = (int)CommonEnum.IsorNot.否;
                int result = exerciseDAL.Edit(model);
                if (result == 0)
                {
                    int log = EID == -1 ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('提交成功！');window.location='ExerciseManage.aspx';", true);
                    sysLogDAL.Edit(new SysLogEntity(log, EID == -1 ? "添加" : "修改" + "题目信息", UserID));
                }
                else
                {
                    ShowMessage("保存失败");
                    return;
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
            }
        }
        #endregion



        #region 初始化用户数据
        public void BindInfo()
        {
            ExerciseEntity model = exerciseDAL.GetObjByID(EID);
            if (model != null)
            {
                //this.txt_Answer.Text = model.Answer;
                this.txt_Options.Text = model.Options;
                this.txt_Score.Text = model.Score.ToString();
                this.txt_Ttile.Text = model.Ttile;
                this.ddl_CourseName.SelectedValue = model.CID.ToString();
                this.ddl_Difficulty.SelectedValue = model.Difficulty.ToString();
                this.ddl_EType.SelectedValue = model.EType.ToString();
                this.ddl_GradeID.SelectedValue = model.GradeID.ToString();
                this.ddl_Term.SelectedValue = model.Term.ToString();
                this.txt_Answer.Text = model.Answer;
                if (Convert.ToInt32(this.ddl_EType.SelectedValue) != Convert.ToInt32(CommonEnum.ExerciseType.单项选) && Convert.ToInt32(this.ddl_EType.SelectedValue) != Convert.ToInt32(CommonEnum.ExerciseType.多选题) && Convert.ToInt32(this.ddl_EType.SelectedValue) != Convert.ToInt32(CommonEnum.ExerciseType.判断题))
                {
                    this.tr_xx.Visible = false;
                    this.hf_aa.Value = "0";
                    //this.txt_Answer.Visible = true;
                    //this.rbl_Answer.Visible = false;
                    //this.ckl_Answer.Visible = false;
                }
                else
                {
                    this.hf_aa.Value = "1";
                    this.tr_xx.Visible = true;
                    //this.txt_Answer.Visible = false;
                    //string[] arr = { "A", "B", "C", "D" };
                    //if (Convert.ToInt32(this.ddl_EType.SelectedValue) == Convert.ToInt32(CommonEnum.ExerciseType.单项选))
                    //{
                    //    this.ckl_Answer.Visible = false;
                    //    this.rbl_Answer.Visible = true;
                    //    this.rbl_Answer.Items.Clear();
                    //    for (int i = 0; i < arr.Length; i++)
                    //    {
                    //        this.rbl_Answer.Items.Add(arr[i].ToString());
                    //    }
                    //    this.rbl_Answer.SelectedValue = model.Answer;
                    //}
                    //else
                    //{
                    //    this.ckl_Answer.Visible = true;
                    //    this.rbl_Answer.Visible = false;
                    //    this.ckl_Answer.Items.Clear();
                    //    for (int i = 0; i < arr.Length; i++)
                    //    {
                    //        this.ckl_Answer.Items.Add(arr[i].ToString());
                    //    }
                    //    string[] str = model.Answer.Split(',');
                    //    for (int i = 0; i < str.Length; i++)
                    //    {
                    //        for (int j = 0; j < ckl_Answer.Items.Count; j++)
                    //        {
                    //            if (str[i].ToString() == ckl_Answer.Items[j].ToString())
                    //            {
                    //                ckl_Answer.Items[j].Selected = true;
                    //            }
                    //        }
                    //    }
                    //}
                }
            }
        }
        #endregion


        #region 根据题型判断
        protected void ddl_EType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ddl();
        }
        #endregion


        #region 根据类型判断
        private void Ddl()
        {
            if (Convert.ToInt32(this.ddl_EType.SelectedValue) != Convert.ToInt32(CommonEnum.ExerciseType.单项选) && Convert.ToInt32(this.ddl_EType.SelectedValue) != Convert.ToInt32(CommonEnum.ExerciseType.多选题) && Convert.ToInt32(this.ddl_EType.SelectedValue) != Convert.ToInt32(CommonEnum.ExerciseType.判断题))
            {
                this.tr_xx.Visible = false;
                this.hf_aa.Value = "0";

                //this.txt_Answer.Visible = true;
                //this.rbl_Answer.Visible = false;
                //this.ckl_Answer.Visible = false;
            }
            else
            {
                this.hf_aa.Value = "1";
                this.tr_xx.Visible = true;
                //this.txt_Answer.Visible = false;
                //string[] arr = { "A", "B", "C", "D" };
                //if (Convert.ToInt32(this.ddl_EType.SelectedValue) == Convert.ToInt32(CommonEnum.ExerciseType.单项选))
                //{
                //    this.ckl_Answer.Visible = false;
                //    this.rbl_Answer.Visible = true;
                //    this.rbl_Answer.Items.Clear();
                //    for (int i = 0; i < arr.Length; i++)
                //    {
                //        this.rbl_Answer.Items.Add(arr[i].ToString());
                //    }
                //    this.rbl_Answer.SelectedIndex = 0;
                //}
                //else
                //{
                //    this.ckl_Answer.Visible = true;
                //    this.rbl_Answer.Visible = false;
                //    this.ckl_Answer.Items.Clear();
                //    for (int i = 0; i < arr.Length; i++)
                //    {
                //        this.ckl_Answer.Items.Add(arr[i].ToString());
                //    }
                //    this.ckl_Answer.SelectedIndex = 0;
                //}
            }
        }
        #endregion
    }
}