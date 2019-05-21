/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年08月23日 17时21分01秒
** 描    述:      教师听课打分页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Text;
using System.Data;
using System.Collections.Generic;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.lecturemanage
{
    public partial class LectureScoreEdit : PageBase
    {
        public Lecture_StandardDAL standardDAL = new Lecture_StandardDAL();
        public Lecture_ScoreDAL scoreDAL = new Lecture_ScoreDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public LectureDAL lecDAL = new LectureDAL();

        #region 参数集合
        /// <summary>
        /// LID 听课ID
        /// </summary>
        public string LID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        #endregion


        #region 页面初始化
        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LectureEntity model = lecDAL.GetObjByID(LID);
                if (model != null)
                {
                    this.ltl_ClassName.Text = model.ClassName.ToString();
                    this.ltl_CourseName.Text = model.CourseName.ToString();
                    this.ltl_TeacherName.Text = model.TeacherName.ToString();
                    this.ltl_DateTime.Text = model.BeginDate.Year + "年" + model.BeginDate.Month + "月" + model.BeginDate.Day + "日" + model.BeginDate.Hour + "时" + model.BeginDate.Minute + "分" + "-" + model.EndDate.Hour + "时" + model.EndDate.Minute + "分";
                }
                string str = GetTableContent();
                this.ltl_Content.Text = str.ToString();
            }
        }
        #endregion


        #region 拼接表格
        /// <summary>
        /// 拼接表格
        /// </summary>
        /// <returns></returns>
        private string GetTableContent()
        {
            StringBuilder sb = new StringBuilder("");
            DataTable dtFirst = standardDAL.GetList((int)CommonEnum.Deleted.未删除, -2, 1);//获取第一标准 1：听课标准 2：考核标准

            sb.Append("<table border='0' cellpadding='0' cellspacing='0' class='layui-table layui-form' id='example-advanced'>");
            sb.Append("<caption>");
            sb.Append("<a href='#' onclick='jQuery(&#39;#example-advanced&#39;).treetable(&#39;expandAll&#39;); return false;'>全部展开</a><a href='#' onclick='jQuery(&#39;#example-advanced&#39;).treetable(&#39;collapseAll&#39;); return false;'>全部收起</a>");
            sb.Append("</caption>");
            sb.Append("<tr>");
            sb.Append("<th width='160px'>&nbsp;</th>");
            sb.Append("<th>评分标准</th>");
            sb.Append("<th>分值</th>");
            sb.Append("<th>评分</th>");
            sb.Append("</tr>");
            sb.Append("<tbody class='btable-content'>");
            if (dtFirst != null && dtFirst.Rows.Count > 0)
            {
                for (int i = 0; i < dtFirst.Rows.Count; i++)
                {
                    sb.Append("<tr data-tt-id='" + dtFirst.Rows[i]["LSID"].ToString() + "' class='collapsed'>");
                    sb.Append("<td width='160px'>&nbsp;</td>");
                    sb.Append("<td><span class='treebg'>");
                    sb.Append("<b1></b1>");
                    sb.Append("</span><span class='file'>" + dtFirst.Rows[i]["StandardContent"].ToString() + "</span></td>");
                    sb.Append("<td>" + dtFirst.Rows[i]["LScore"].ToString() + "</td>");
                    sb.Append("<td>&nbsp;</td>");
                    sb.Append("</tr>");
                    string str = ChildBind(Convert.ToInt32(dtFirst.Rows[i]["LSID"].ToString())).ToString();
                    sb.Append(str.ToString());
                }
            }
            else
            {
                sb.Append("   <tr id='trnull'  ><td colspan='4' align='center'>暂无记录</td> </tr>");
            }
            sb.Append("</tbody>");
            sb.Append("</table>");
            return sb.ToString();
        }
        #endregion


        #region 绑定子标准
        /// <summary>
        /// 绑定子标准
        /// </summary>
        /// <param name="treenode"></param>
        /// <param name="depid"></param>
        private string ChildBind(int parentid)
        {
            StringBuilder sb = new StringBuilder("");
            DataTable dv = standardDAL.GetList((int)CommonEnum.Deleted.未删除, parentid, 1);//1：听课标准 2：考核标准
            if (dv.Rows.Count > 0)
            {
                for (int i = 0; i < dv.Rows.Count; i++)
                {
                    sb.Append("<tr data-tt-id='" + dv.Rows[i]["LSID"].ToString() + "' data-tt-parent-id='" + dv.Rows[i]["ParentID"].ToString() + "' class='branch' style='display: none;'>");
                    sb.Append("<td width='160px'>&nbsp;</td>");
                    sb.Append("<td><span class='treebg'>");
                    sb.Append("<b1></b1>");
                    sb.Append("</span><span class='file'>" + dv.Rows[i]["StandardContent"].ToString() + "</span></td>");
                    sb.Append("<td>" + dv.Rows[i]["LScore"].ToString() + "</td>");
                    sb.Append("<td>");
                    sb.Append("<input type='text' name='score' runat='server' id='txt_" + dv.Rows[i]["LSID"].ToString() + "' Width='60px' value='0' />");
                    sb.Append("</td>");
                    sb.Append("</tr>");
                    string str = ChildBind(Convert.ToInt32(dv.Rows[i]["LSID"].ToString())).ToString();
                    sb.Append(str.ToString());
                }
            }
            return sb.ToString();
        }
        #endregion


        #region 提交事件
        /// <summary>
        /// 提交事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                List<Lecture_ScoreEntity> lecmodel = new List<Lecture_ScoreEntity>();
                string b = this.hf_Value.Value.Replace("txt_", "");
                string[] c = b.TrimEnd(',').Split(',');
                for (int i = 0; i < c.Length; i++)
                {
                    Lecture_ScoreEntity model = new Lecture_ScoreEntity();
                    model.SID = "";
                    string[] d = c[i].Split(':');
                    model.Score = Convert.ToInt32(d[1]);
                    model.LSID = Convert.ToInt32(d[0]);
                    model.LID = LID;
                    model.CreateUser = UserID;
                    lecmodel.Add(model);
                }
                int result = scoreDAL.AddScore(lecmodel);
                if (result == 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, "添加听课评分信息", UserID));
                    ClientScript.RegisterStartupScript(Page.GetType(), "", "<script>alert('提交成功');window.location.href='LectureScoreList.aspx'</script>");
                }
                else
                {
                    ShowMessage("提交失败");
                    return;
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                return;
            }
        }
        #endregion
    }
}