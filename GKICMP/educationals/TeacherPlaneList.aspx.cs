/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月07日 09点30分
** 描   述:       排课计划
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Web.UI.WebControls;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using System.Data;

namespace GKICMP.educationals
{
    public partial class TeacherPlaneList : PageBase
    {
        public GradeDAL gradeDAL = new GradeDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();

        #region 参数集合
        /// <summary>
        /// Flag 1:排课计划 2:班级任课教师管理 3:班级课表
        /// </summary>
        public int Flag
        {
            get
            {
                return GetQueryString<int>("Flag", -1);
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
                GradeBind();
                int did = Convert.ToInt32(ViewState["DID"].ToString());
                if (Flag == 1)
                {
                    this.lbl_ParentMenu.Text = "教学管理";
                    framemain.Attributes["src"] = "TeacherPlaneManage.aspx?id=" + did + "&deep=1";
                }
                else
                {
                    this.lbl_ParentMenu.Text = "教学管理";
                    this.lbl_Menuname.Text = "班级课表";
                    framemain.Attributes["src"] = "ClassSchedule.aspx?id=" + did + "&deep=1";
                }
            }
        }
        #endregion


        #region 年级绑定
        /// <summary>
        /// 年级绑定
        /// </summary>
        private void GradeBind()
        {
            this.tv_Meun.Nodes.Clear();
            DataTable dv = gradeDAL.GetListAll((int)CommonEnum.IsorNot.否);

            for (int i = 0; i < dv.Rows.Count; i++)
            {
                DataRow row = dv.Rows[i];
                TreeNode treenode = new TreeNode();
                int gid = Convert.ToInt32(row["GID"].ToString());
                treenode.Value = gid.ToString();
                treenode.Text = row["ShortGName"].ToString();
                tv_Meun.Nodes.Add(treenode);
                if (i != 0)
                {
                    treenode.Expanded = false;
                }
                ChildBind(treenode, gid, i);
            }
        }
        #endregion


        #region 绑定班级
        /// <summary>
        ///绑定班级
        /// </summary>
        /// <param name="treenode"></param>
        /// <param name="depid"></param>
        private void ChildBind(TreeNode treenode, int gid, int j)
        {
            DataTable dv = null;
            dv = departmentDAL.GetByGID(gid, (int)CommonEnum.IsorNot.否);
            if (dv.Rows.Count > 0)
            {
                for (int i = 0; i < dv.Rows.Count; i++)
                {
                    if (i == 0 && j == 0)
                    {
                        ViewState["DID"] = dv.Rows[0]["DID"].ToString();
                    }
                    DataRow row = dv.Rows[i];
                    TreeNode childnode = new TreeNode();
                    childnode.Value = row["DID"].ToString();
                    childnode.Text = row["OtherName"].ToString();
                    int claid = Convert.ToInt32(row["DID"].ToString());
                    childnode = new TreeNode(childnode.Text, childnode.Value);
                    treenode.ChildNodes.Add(childnode);
                }
            }
        }
        #endregion


        #region 菜单点击事件
        /// <summary>
        /// 菜单点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tv_Meun_SelectedNodeChanged(object sender, EventArgs e)
        {
            string svalue = tv_Meun.SelectedNode.Value;//获得点击的值
            string deep = tv_Meun.SelectedNode.Depth.ToString();
            if (deep == "0" && Flag == 1)
            {
                framemain.Attributes["src"] = "NJTeacherManage.aspx?id=" + svalue;
            }
            else
            {
                if (Flag == 1)
                {
                    framemain.Attributes["src"] = "TeacherPlaneManage.aspx?id=" + svalue + "&deep=" + deep;
                }
                //else if (Flag == 2)
                //{
                //    framemain.Attributes["src"] = "../database/ClassTeacherManage.aspx?id=" + svalue + "&deep=" + tv_Meun.SelectedNode.Depth.ToString();
                //}
                else
                {
                    framemain.Attributes["src"] = "ClassSchedule.aspx?id=" + svalue + "&deep=" + deep;
                }
            }
        }
        #endregion
    }
}