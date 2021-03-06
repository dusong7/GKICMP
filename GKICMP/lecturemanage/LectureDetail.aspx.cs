﻿/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年08月22日 18时36分01秒
** 描    述:      教师听课评分标准管理页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Data;
using System.Text;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.lecturemanage
{
    public partial class LectureDetail : PageBase
    {
        public Lecture_StandardDAL standardDAL = new Lecture_StandardDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();

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
            DataTable dtFirst = standardDAL.GetList((int)CommonEnum.Deleted.未删除, -2, 1);//获取第一标准

            sb.Append("<table border='0' cellpadding='0' cellspacing='0' class='layui-table layui-form' id='example-advanced'>");
            sb.Append("<caption>");
            sb.Append("<a href='#' onclick='jQuery(&#39;#example-advanced&#39;).treetable(&#39;expandAll&#39;); return false;'>全部展开</a><a href='#' onclick='jQuery(&#39;#example-advanced&#39;).treetable(&#39;collapseAll&#39;); return false;'>全部收起</a>");
            sb.Append("</caption>");
            sb.Append("<tr>");
            sb.Append("<th width='160px'>&nbsp;</th>");
            sb.Append("<th>评分标准</th>");
            sb.Append("<th style='text-align:center'>分值</th>");
            sb.Append("<th style='text-align:center'>分数</th>");
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
                    sb.Append("<td align='center'>" + dtFirst.Rows[i]["LScore"].ToString() + "</td>");
                    sb.Append("<td align='center'></td>");
                    sb.Append("</tr>");
                    string str = ChildBind(Convert.ToInt32(dtFirst.Rows[i]["LSID"].ToString())).ToString();
                    sb.Append(str.ToString());
                }
            }
            else
            {
                sb.Append("   <tr id='trnull'><td colspan='4' align='center'>暂无记录</td> </tr>");
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
            DataTable dv = standardDAL.GetScoreList((int)CommonEnum.Deleted.未删除, parentid, UserID, LID.ToString(), 2);
            if (dv != null && dv.Rows.Count > 0)
            {
                for (int i = 0; i < dv.Rows.Count; i++)
                {
                    sb.Append("<tr data-tt-id='" + dv.Rows[i]["LSID"].ToString() + "' data-tt-parent-id='" + dv.Rows[i]["ParentID"].ToString() + "' class='branch' style='display: none;'>");
                    sb.Append("<td width='160px'>&nbsp;</td>");
                    sb.Append("<td><span class='treebg'>");
                    sb.Append("<b1></b1>");
                    sb.Append("</span><span class='file'>" + dv.Rows[i]["StandardContent"].ToString() + "</span></td>");
                    sb.Append("<td align='center'>" + dv.Rows[i]["LScore"].ToString() + "</td>");
                    sb.Append("<td align='center'>" + dv.Rows[i]["Average"].ToString() + "</td>");
                    sb.Append("</tr>");
                    string str = ChildBind(Convert.ToInt32(dv.Rows[i]["LSID"].ToString())).ToString();
                    sb.Append(str.ToString());
                }
            }
            return sb.ToString();
        }
        #endregion
    }
}