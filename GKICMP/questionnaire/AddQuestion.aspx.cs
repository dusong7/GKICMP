using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.Entities;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;

namespace GKICMP.questionnaire
{
    public partial class AddQuestion : PageBase
    {
        Questionnaire_SubjectDAL questionnaire_SubjectDAL = new Questionnaire_SubjectDAL();
        Questionnaire_OptionDAL questionnaire_OptionDAL = new Questionnaire_OptionDAL();
        #region 参数集合
        /// <summary>
        /// ID
        /// </summary>
        public string QID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            Questionnaire_OptionEntity qomodel = new Questionnaire_OptionEntity();
            Questionnaire_SubjectEntity qsmodel = new Questionnaire_SubjectEntity();
            qsmodel.QID = QID;//问卷id
            //qsmodel.SubContent = this.txt_QuestName.Text;//题目类型
            //qsmodel.SubType = int.Parse(this.ddl_Type.SelectedValue);//题目
            if (this.txt_QuestName.Text != null && txt_QuestName.Text.ToString() != "")
            {
                //题型为单选或多选时
                if (this.ddl_Type.SelectedValue != "2")
                {
                    qsmodel.SubType = int.Parse(this.ddl_Type.SelectedValue);//题目类型
                    qsmodel.SubContent = this.txt_QuestName.Text;//题目
                    //获取插入题目的Questionid
                    int questionId = questionnaire_SubjectDAL.Edit(qsmodel);//新增
                    if (questionId > 0)
                    {
                        //获取新增选项
                        string[] answers = Request.Form.GetValues("option");
                        //if (answers.Length < 2)
                        //{
                        //    this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('答案至少有两个')</script>");
                        //    return;
                        //}
                        //else
                        //{
                        //string ans = Request.Form["option"].ToString();
                        //存入答案选项
                        for (int i = 0; i < answers.Length; i++)
                        {
                            qomodel.OptionContent = answers[i];
                            if (qomodel.OptionContent == "")
                            {
                                this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('答案不能为空')</script>");
                                questionnaire_SubjectDAL.DeleteBat(questionId);//选项添加不成功，删除题目
                                questionnaire_OptionDAL.DeleteBat(questionId);
                                return;
                            }
                            qomodel.OptionVlaue = (i + 1).ToString();
                            qomodel.QSID = questionId;
                            questionnaire_OptionDAL.Edit(qomodel);
                        }
                        //}
                    }
                }
                //题型为问答题时，存入题目
                else
                {
                    qsmodel.SubType = int.Parse(this.ddl_Type.SelectedValue);
                    qsmodel.SubContent = this.txt_QuestName.Text;
                    questionnaire_SubjectDAL.Edit(qsmodel);//新增
                    //QuestionBLL.AddQuestion(question);
                    //info.InnerHtml = "<font color='red'>添加成功</font>";
                }
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加成功！')</script>");
            }
            //题目内容为空时
            else
            {
                Response.Write("<script>alert('题目不能为空')</script>");
                //清空题目内容
                this.txt_QuestName.Text = "";
                return;
            }
        }
    }
}