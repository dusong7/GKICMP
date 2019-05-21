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
using System.Data;
using System.Text;

namespace GKICMP.educational
{
    public partial class ExamAssemblyDetail : PageBase
    {
        public ExamPaperDAL examPaperDAL = new ExamPaperDAL();
        public ExerciseDAL exerciseDAL = new ExerciseDAL();


        #region 参数集合
        public string EPID
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
                int v = 0;
                int x = 0;
                ExamPaperEntity model = examPaperDAL.GetObjByID(EPID);
                if (model != null)
                {
                    StringBuilder str = new StringBuilder();
                    str.AppendFormat("<h2>{0}</h2>", model.PaperName);
                    str.AppendFormat("<h4>科目：{0}&nbsp;&nbsp;&nbsp;&nbsp;考试时间：{1}分钟</h4>", model.CIDName, model.Minutes.ToString());
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
                            str.AppendFormat("<li><div class='test-title'><div class='serial-number'>{0}", (j + 1).ToString() + "、");
                            str.Append("</div>");
                            str.Append("<div class='test-title-name'>");
                            str.AppendFormat("{0}", dt.Rows[j]["Ttile"].ToString());
                            str.Append(" <span>(显示答案)</span>");
                            str.Append("</div></div>");
                            str.AppendFormat(" <div>{0}</div>", dt.Rows[j]["Options"]);
                            str.Append(" <div class='andiv nonedis'>");
                            str.Append("<table width='100%' border ='0' cellspaccing='0' cellpadding='0'><tbody><tr>");
                            str.AppendFormat("<td width='50' valign='top'>答案：</td><td><p>{0}</p></td>", dt.Rows[j]["Answer"]);
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
    }
}