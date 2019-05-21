/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      lfz
** 创建日期:    2017年3月02日
** 描 述:       模块管理页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;
using System.Web.UI.WebControls;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;

namespace GKICMP.sysmanage
{
    public partial class ModuleManage : PageBase
    {
        public SysModuleDAL sysModuleDAL = new SysModuleDAL();

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
                TreeBind();
            }
        }
        #endregion


        #region 绑定树
        /// <summary>
        /// 绑定树
        /// </summary>
        private void TreeBind()
        {
            this.tv_Meun.Nodes.Clear();
            DataTable dv = sysModuleDAL.GetTable(-1);

            for (int i = 0; i < dv.Rows.Count; i++)
            {
                DataRow row = dv.Rows[i];
                TreeNode treenode = new TreeNode();
                int moduleid = Convert.ToInt32(row["ModuleID"].ToString());
                treenode.Value = moduleid.ToString();
                treenode.Text = row["ModuleName"].ToString();
                tv_Meun.Nodes.Add(treenode);
                treenode.Expanded = false;
                if (i == 0)
                {
                    treenode.Expanded = true;
                    framemain.Attributes["src"] = "ModuleEdit.aspx?id=" + moduleid.ToString() + "&deep=" + treenode.Depth.ToString();
                }
                ChildBind(treenode, moduleid);
            }
        }
        #endregion


        #region 添加子节点
        /// <summary>
        /// 添加子节点
        /// </summary>
        /// <param name="treenode"></param>
        /// <param name="depid"></param>
        private void ChildBind(TreeNode treenode, int moduleid)
        {
            DataTable dv = sysModuleDAL.GetTable(moduleid);
            if (dv.Rows.Count > 0)
            {
                for (int i = 0; i < dv.Rows.Count; i++)
                {
                    DataRow row = dv.Rows[i];
                    TreeNode childnode = new TreeNode();
                    childnode.Value = row["ModuleID"].ToString();
                    childnode.Text = row["ModuleName"].ToString();
                    int childid = Convert.ToInt32(row["ModuleID"].ToString());
                    childnode = new TreeNode(childnode.Text, childnode.Value);
                    treenode.ChildNodes.Add(childnode);
                    childnode.Expanded = false;
                    ChildBind(childnode, childid);

                }
            }
        }
        #endregion


        #region 选择节点变化获得值
        /// <summary>
        /// 选择节点变化获得值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tr_Dep_SelectedNodeChanged(object sender, EventArgs e)
        {
            string svalue = tv_Meun.SelectedNode.Value;//获得点击的值
            framemain.Attributes["src"] = "ModuleEdit.aspx?id=" + svalue + "&deep=" + tv_Meun.SelectedNode.Depth.ToString();
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
            framemain.Attributes["src"] = "ModuleEdit.aspx?id=" + svalue + "&deep=" + tv_Meun.SelectedNode.Depth.ToString();
        }
        #endregion


        #region 添加一级菜单
        /// <summary>
        /// 添加一级菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_Add_Click(object sender, EventArgs e)
        {
            framemain.Attributes["src"] = "ModuleEdit.aspx?id=" + "" + "&deep=1";
        }
        #endregion
    }
}