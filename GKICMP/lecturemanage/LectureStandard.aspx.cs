/*****************************************************************
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
    public partial class LectureStandard : PageBase
    {
        public Lecture_StandardDAL standardDAL = new Lecture_StandardDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();

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
            DataTable dtFirst = standardDAL.GetList((int)CommonEnum.Deleted.未删除, -2, 1);//获取第一标准 1：听课标准 2：考核标准
            //DataTable dtFirst = standardDAL.GetList((int)CommonEnum.Deleted.未删除);
            sb.Append("<caption>");
            sb.Append(@"<a href='#'  style='border: 1px solid #FB614A;border-radius: 2px; background: #FB614A; color: #FFFFFF; width: 140px; height: 28px;line-height: 28px; text-align: center;
 font-size: 14px; margin-right: 13px;'onclick='jQuery(&#39;#example-advanced&#39;).treetable(&#39;expandAll&#39;); return false;'><span stlye='color:red' >&nbsp;全部展开&nbsp;</span></a>&nbsp;&nbsp;&nbsp;&nbsp;<a href='#'style='border: 1px solid #FB614A;border-radius: 2px; background: #FB614A; color: #FFFFFF; width: 120px; height: 26px;line-height: 24px; text-align: center;
 font-size: 14px;' onclick='jQuery(&#39;#example-advanced&#39;).treetable(&#39;collapseAll&#39;); return false;'>&nbsp;全部收起&nbsp;</a>");
            sb.Append("</caption>");
            sb.Append("<table border='0' cellpadding='0' cellspacing='0' class='layui-table layui-form' id='example-advanced'>");

            sb.Append("<tr>");
            sb.Append("<th width='160px'>&nbsp;</th>");
            sb.Append("<th>评分标准</th>");
            sb.Append("<th>分值</th>");
            sb.Append("<th></th>");
            sb.Append("</tr>");
            sb.Append("<tbody class='btable-content'>");
            if (dtFirst != null && dtFirst.Rows.Count > 0)
            {
                for (int i = 0; i < dtFirst.Rows.Count; i++)
                {
                    //sb.Append("<tr data-tt-id='" + dtFirst.Rows[i]["LSID"].ToString() + "' data-tt-parent-id='" + dtFirst.Rows[i]["ParentID"].ToString() + "' class='collapsed'>");
                    sb.Append("<tr data-tt-id='" + dtFirst.Rows[i]["LSID"].ToString() + "' class='collapsed'>");
                    sb.Append("<td width='160px'>&nbsp;</td>");
                    sb.Append("<td><span class='treebg'>");
                    sb.Append("<b1></b1>");
                    sb.Append("</span><a href='#' onclick='return showbox(" + dtFirst.Rows[i]["LSID"].ToString() + ")'><span class='file'>" + dtFirst.Rows[i]["StandardContent"].ToString() + "</span></a></td>");
                    sb.Append("<td>" + dtFirst.Rows[i]["LScore"].ToString() + "</td>");
                    sb.Append("<td align='center'><a onclick='return editinfo(" + dtFirst.Rows[i]["LSID"].ToString() + ")' style='cursor:pointer;'>编辑</a>&nbsp;&nbsp;&nbsp;&nbsp;");
                    sb.Append("<a onclick='return deleteinfo(" + dtFirst.Rows[i]["LSID"].ToString() + ")' style='cursor:pointer;'>删除</a></td>");
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
                    sb.Append("</span><a href='#' onclick='return showbox(" + dv.Rows[i]["LSID"].ToString() + ")'><span class='file'>" + dv.Rows[i]["StandardContent"].ToString() + "</span></a></td>");
                    sb.Append("<td>" + dv.Rows[i]["LScore"].ToString() + "</td>");
                    sb.Append("<td align='center'><a onclick='return editinfo(" + dv.Rows[i]["LSID"].ToString() + ")' style='cursor:pointer;'>编辑</a>&nbsp;&nbsp;&nbsp;&nbsp;");
                    sb.Append("<a onclick='return deleteinfo(" + dv.Rows[i]["LSID"].ToString() + ")' style='cursor:pointer;'>删除</a></td>");
                    sb.Append("</tr>");
                    string str = ChildBind(Convert.ToInt32(dv.Rows[i]["LSID"].ToString())).ToString();
                    sb.Append(str.ToString());
                }
            }
            return sb.ToString();
        }
        #endregion


        #region 删除事件
        /// <summary>
        /// 删除事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                string lsid = this.hf_LSID.Value.ToString();
                int result = standardDAL.DeleteBat(lsid, (int)CommonEnum.Deleted.删除);
                if (result > 0)
                {
                    ShowMessage("删除成功");
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除听课评分标准信息", UserID));
                }
                else
                {
                    ShowMessage("删除失败");
                    return;
                }
                string str = GetTableContent();
                this.ltl_Content.Text = str.ToString();
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                return;
            }
        }
        #endregion


        #region 刷新页面
        /// <summary>
        /// 刷新页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            string str = GetTableContent();
            this.ltl_Content.Text = str.ToString();
        }
        #endregion
    }
}