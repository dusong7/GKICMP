/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月01日 17时38分29秒
** 描    述:      查看答题信息
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using System.Data;
using System.Text;
using System.Web.UI.WebControls;

namespace GKICMP.educational
{
    public partial class SelectExercise : PageBase
    {
        public ExamPaperDAL examPaperDAL = new ExamPaperDAL();
        public ExerciseDAL exerciseDAL = new ExerciseDAL();
        public ExamPaper_PractStuDAL practStuDAL = new ExamPaper_PractStuDAL();
        public ExamPaper_EeStuDAL eeStuDAL = new ExamPaper_EeStuDAL();


        #region 参数集合
        public string EPID
        {
            get
            {
                return GetQueryString<string>("epid", "");
            }
        }
        public string EPPID
        {
            get
            {
                return GetQueryString<string>("eppid", "");
            }
        }
        public string UID
        {
            get
            {
                return GetQueryString<string>("uid", "");
            }
        }
        #endregion


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int v = 0;
                int x = 0;
                decimal score = 0;
                ExamPaper_PractStuEntity model1 = practStuDAL.GetByEPPID(EPPID, UID);
                if (model1 != null)
                {
                    score = model1.PScore;
                }
                ExamPaperEntity model = examPaperDAL.GetObjByID(EPID);
                if (model != null)
                {
                    StringBuilder str = new StringBuilder();
                    str.AppendFormat("<h2>{0}</h2>", model.PaperName);
                    str.AppendFormat("<h4>姓名：{2}&nbsp;&nbsp;&nbsp;&nbsp科目：{0}&nbsp;&nbsp;&nbsp;&nbsp;考试时间：{1}分钟&nbsp;&nbsp;&nbsp;&nbsp;分数：{3}</h4>", model.CIDName, model.Minutes.ToString(), UserRealName, score == 0 ? "" : score.ToString());
                    str.Append("<div id='testid'><ul>");
                    DataTable dt = exerciseDAL.GetTable(EPID);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                if (dt.Rows[j]["EType"].ToString() == (i + 1).ToString() && x != Convert.ToInt32(dt.Rows[j]["EType"]))
                                {
                                    v += 1;
                                    str.AppendFormat("<h3>{0}</h3>", Get(v, Convert.ToInt32(dt.Rows[j]["EType"])));
                                }
                            }
                            decimal zf = 0;
                            decimal df = 0;
                            string answer = "";
                            ExamPaper_EeStuEntity model2 = eeStuDAL.GetObj(EPPID, EPID, UID, Convert.ToInt32(dt.Rows[j]["EID"].ToString()));
                            if (model2 != null)
                            {
                                df = model2.EScore;
                                answer = model2.EAnswer;
                            }
                            ExerciseEntity model3 = exerciseDAL.GetObjByID(Convert.ToInt32(dt.Rows[j]["EID"].ToString()));
                            if (model3 != null)
                            {
                                zf = Convert.ToDecimal(model3.Score);
                            }
                            str.AppendFormat("<li><div class='test-title'><div class='serial-number'>{0}", (j + 1).ToString() + "、");
                            str.Append("</div>");
                            str.Append("<div class='test-title-name'>");
                            str.AppendFormat("{0}", dt.Rows[j]["Ttile"].ToString());
                            str.Append(" <span>(总分：" + (zf == 0 ? "0" : zf.ToString("0.0")) + " &nbsp;&nbsp;得分：" + (df == 0 ? "0" : df.ToString("0.0")) + ")</span>");
                            str.Append("</div></div>");
                            str.AppendFormat(" <div>{0}</div>", dt.Rows[j]["Options"]);
                            str.Append(" <div class='andiv'>");
                            str.Append("<table width='100%' border ='0' cellspaccing='0' cellpadding='0'><tbody><tr>");
                            str.AppendFormat("<td width='50' valign='top'>答案：</td><td>{0}</td>", GetAnswer(Convert.ToInt32(dt.Rows[j]["EType"].ToString()), Convert.ToInt32(dt.Rows[j]["EID"].ToString()), answer));
                            str.Append("</tr></tbody></table></div></li>");
                            x = Convert.ToInt32(dt.Rows[j]["EType"].ToString());
                        }
                    }
                    str.Append("</ul></div>");
                    this.lbl.Text = str.ToString();
                }

            }
        }
        #endregion


        #region 获取序号和类型
        public string Get(int v, int x)
        {
            string a, b;
            a = v == 1 ? "一、" : v == 2 ? "二、" : v == 3 ? "三、" : v == 4 ? "四、" : "五、";
            b = x == 1 ? "单项选" : x == 2 ? "多选题" : x == 3 ? "填空题" : x == 4 ? "判断题" : "主观题";
            return a + b;
        }
        #endregion


        #region 获取答案选项
        public string GetAnswer(int type, int j, string answer)
        {
            //string str = "";
            //string[] arr = { "A", "B", "C", "D" };
            //if (type == (int)CommonEnum.ExerciseType.单项选)
            //{
            //    str += "<span class=\"rbl\">";
            //    for (int i = 0; i < 4; i++)
            //    {
            //        str += "<input type=\"radio\" value=\"" + arr[i].ToString() + "\" name=" + j.ToString() + "><label>" + arr[i].ToString() + "</label>";
            //    }
            //    str += "</span>";

            //}
            //else if (type == (int)CommonEnum.ExerciseType.多选题)
            //{
            //    str += "<span class=\"rbl\">";
            //    for (int i = 0; i < 4; i++)
            //    {
            //        str += "<input type=\"checkbox\" value=\"" + arr[i].ToString() + "\" name=" + j.ToString() + "><label>" + arr[i].ToString() + "</label>";
            //    }
            //    str += "</span>";
            //}
            //else
            //{
            //    //str += "<span><textarea name=" + j.ToString() + " rows='5'   style=\"height:80px;width:100%;resize: none\"></textarea></span>";
            //    str += "<span><textarea name=\"" + j.ToString() + "\" id=\"" + j.ToString() + "\" rows='5'   style=\"height:80px;width:100%;resize: none\"></textarea><script type=\"text/javascript\">var ue = UE.getEditor('" + j.ToString() + "');</script></span>";
            //}
            //return str;
            string str = "";
            if (type == (int)CommonEnum.ExerciseType.单项选 || type == (int)CommonEnum.ExerciseType.多选题 || type == (int)CommonEnum.ExerciseType.判断题)
            {
                str = "<span><textarea disabled=\"disabled\" type=\"text\" name=" + type.ToString() + "  id=" + j.ToString() + " rows='1'   style=\"height:20px;width:60px;line-height:20px;text-align:center;resize: none\">" + answer + "</textarea></span>";
            }
            else
            {
                str = "<span><textarea disabled=\"disabled\" type=\"text\" name=" + type.ToString() + "  id=" + j.ToString() + " rows='5'   style=\"height:80px;width:100%;resize: none\">" + answer + "</textarea></span>";
            }

            return str;
        }
        #endregion
    }
}