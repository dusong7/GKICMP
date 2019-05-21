/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      樊紫红
** 创建日期:    2017年8月24日 17时19分
** 描 述:       班级列表页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;

namespace GKICMP.spacemanage
{
    public partial class ClassList : PageBase
    {
        public TeacherPlaneDAL teacherDAL = new TeacherPlaneDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();

        #region 参数集合
        /// <summary>
        /// 1：班级主页 2：文化墙 3：相册
        /// </summary>
        public int Flag
        {
            get
            {
                return GetQueryString<int>("flag", -1);
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
            DataTable dv = teacherDAL.GetGIDByUID(UserID);

            for (int i = 0; i < dv.Rows.Count; i++)
            {
                DataRow row = dv.Rows[i];
                TreeNode treenode = new TreeNode();
                int gid = Convert.ToInt32(row["GID"].ToString());
                treenode.Value = gid.ToString();
                treenode.Text = row["GradeName"].ToString();
                tv_Meun.Nodes.Add(treenode);
                if (i == 0)
                {
                    treenode.Expanded = true;
                }
                ChildBind(treenode, gid);
            }
        }
        #endregion


        #region 绑定班级
        /// <summary>
        ///绑定班级
        /// </summary>
        /// <param name="treenode"></param>
        /// <param name="depid"></param>
        private void ChildBind(TreeNode treenode, int gid)
        {
            DataTable dv = null;
            dv = teacherDAL.GetClaIDByUID(UserID, gid);
            if (dv.Rows.Count > 0)
            {
                string id = "";
                for (int i = 0; i < dv.Rows.Count; i++)
                {
                    DataRow row = dv.Rows[i];
                    if (i == 0)
                    {
                        id = row["DID"].ToString();
                        treenode.Expanded = true;
                    }
                    TreeNode childnode = new TreeNode();
                    childnode.Value = row["DID"].ToString();
                    childnode.Text = row["DepName"].ToString();
                    int claid = Convert.ToInt32(row["DID"].ToString());
                    childnode = new TreeNode(childnode.Text, childnode.Value);
                    treenode.ChildNodes.Add(childnode);
                    StuBind(childnode, claid.ToString());
                }
                framemain.Attributes["src"] = "ClassSpace.aspx?id=" + id + "&deep=1";
            }
        }
        #endregion


        #region 学生绑定
        private void StuBind(TreeNode treenode, string depid)
        {
            DataTable dv = null;
            dv = sysUserDAL.GetTable(depid);
            if (dv.Rows.Count > 0)
            {
                for (int i = 0; i < dv.Rows.Count; i++)
                {
                    DataRow row = dv.Rows[i];
                    if (i == 0)
                    {

                    }
                    TreeNode childnode = new TreeNode();
                    childnode.Value = row["UID"].ToString();
                    childnode.Text = row["RealName"].ToString();
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
            if (tv_Meun.SelectedNode.Depth.ToString()=="1")
            {
                framemain.Attributes["src"] = "ClassSpace.aspx?id=" + svalue + "&deep=" + tv_Meun.SelectedNode.Depth.ToString();
            }
            else if(tv_Meun.SelectedNode.Depth.ToString()=="2")
            {
                framemain.Attributes["src"] = "PersonSpace.aspx?id=" + svalue + "&deep=" + tv_Meun.SelectedNode.Depth.ToString();
            }
        }
        #endregion
    }
}