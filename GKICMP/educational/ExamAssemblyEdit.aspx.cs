/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      殷志瑞
** 创建日期:    2017年6月8日 18时04分
** 描 述:       组卷管理
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Text;
using System.Text.RegularExpressions;

namespace GKICMP.educational
{
    public partial class ExamAssemblyEdit : PageBase
    {
        public ExamPaperDAL examPaperDAL = new ExamPaperDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public CourseDAL courseDAL = new CourseDAL();


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonFunction.BindEnum<CommonEnum.XQ>(this.ddl_Term, "-99");
                CommonFunction.BindEnum<CommonEnum.NJ>(this.ddl_GradeID, "-99");
                CommonFunction.BindEnum<CommonEnum.DifficultyType>(this.ddl_Difficulty, "-99");
                DataTable dtCourse = courseDAL.GetList();
                CommonFunction.DDlTypeBind(this.ddl_CourseName, dtCourse, "CID", "CourseName", "-2");
            }
        }
        #endregion


        #region 提交
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                ExamPaperEntity model = new ExamPaperEntity();
                if (!IsNum(this.txt_dxx.Text))
                {
                    ShowMessage("请输入正确的单项选题数");
                    return;
                }
                if (!IsNum(this.txt_dxt.Text))
                {
                    ShowMessage("请输入正确的多选题题数");
                    return;
                }
                if (!IsNum(this.txt_tkt.Text))
                {
                    ShowMessage("请输入正确的填空题题数");
                    return;
                }
                if (!IsNum(this.txt_pdt.Text))
                {
                    ShowMessage("请输入正确的判断题题数");
                    return;
                }
                if (!IsNum(this.txt_zgt.Text))
                {
                    ShowMessage("请输入正确的主观题题数");
                    return;
                }
                model.CID = Convert.ToInt32(this.ddl_CourseName.SelectedValue);
                model.CreateUser = UserID;
                model.EPID = "";
                model.EType = Convert.ToInt32(CommonEnum.SCFS.自动生成);
                model.GradeID = Convert.ToInt32(this.ddl_GradeID.SelectedValue);
                model.Minutes = Convert.ToInt32(this.txt_Minutes.Text);
                model.PaperName = this.txt_PaperName.Text.Trim();
                model.Term = Convert.ToInt32(this.ddl_Term.SelectedValue);
                int dxx = Convert.ToInt32(this.txt_dxx.Text == "" ? "0" : this.txt_dxx.Text);
                int dxt = Convert.ToInt32(this.txt_dxt.Text == "" ? "0" : this.txt_dxt.Text);
                int tkt = Convert.ToInt32(this.txt_tkt.Text == "" ? "0" : this.txt_tkt.Text);
                int pdt = Convert.ToInt32(this.txt_pdt.Text == "" ? "0" : this.txt_pdt.Text);
                int zgt = Convert.ToInt32(this.txt_zgt.Text == "" ? "0" : this.txt_zgt.Text);
                int Difficulty = Convert.ToInt32(this.ddl_Difficulty.SelectedValue);
                if ((dxx + dxt + tkt + pdt + zgt) <= 0)
                {
                    ShowMessage("请录入试卷的题数");
                    return;
                }
                int result = examPaperDAL.Update(model, dxx, dxt, tkt, pdt, zgt, Difficulty);
                if (result == 0)
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('提交成功！');window.location='ExerciseManage.aspx';", true);
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, "添加组卷信息", UserID));
                }
                else if (result == -2)
                {
                    ShowMessage(this.ddl_GradeID.SelectedItem+this.ddl_Term.SelectedItem.ToString() +  this.ddl_CourseName.SelectedItem + this.txt_PaperName.Text + "试卷已存在");
                    return;
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


        #region 判断是否为数字
        /// <summary>
        /// 判断是否为数字
        /// </summary>
        /// <param name="Str"></param>
        /// <returns></returns>
        public bool IsNum(string Str)
        {
            bool bl = false;
            if (Str == "")
            {
                bl = true;
            }
            else
            {
                string Rx = @"^[1-9]\d*$";
                if (Regex.IsMatch(Str, Rx))
                {
                    bl = true;
                }
                else
                {
                    bl = false;
                }
            }
            return bl;
        }
        #endregion
    }
}