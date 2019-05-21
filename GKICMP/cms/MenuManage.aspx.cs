/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      刘福洲
** 创建日期:    2017年05月25日
** 描 述:       网站栏目管理页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;

namespace GKICMP.cms
{
    public partial class MenuManage : PageBase
    {
        public Web_MenuDAL web_MenuDAL = new Web_MenuDAL();


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
            DataTable dv = web_MenuDAL.GetTable("-1", (int)CommonEnum.Deleted.未删除);

            for (int i = 0; i < dv.Rows.Count; i++)
            {
                DataRow row = dv.Rows[i];
                TreeNode treenode = new TreeNode();
                string moduleid = row["MID"].ToString();
                treenode.Value = moduleid.ToString();
                treenode.Text = row["MName"].ToString();
                tv_Meun.Nodes.Add(treenode);
                //treenode.Expanded = false;
                if (i == 0)
                {
                    treenode.Expanded = true;
                    framemain.Attributes["src"] = "MenuEdit.aspx?id=" + moduleid + "&deep=" + treenode.Depth.ToString();
                }
                ChildBind(treenode, moduleid);
            }
        }
        #endregion


        #region 绑定子节点
        /// <summary>
        /// 绑定子节点
        /// </summary>
        /// <param name="treenode"></param>
        /// <param name="depid"></param>
        private void ChildBind(TreeNode treenode, string moduleid)
        {
            DataTable dv = web_MenuDAL.GetTable(moduleid, (int)CommonEnum.Deleted.未删除);
            if (dv.Rows.Count > 0)
            {
                for (int i = 0; i < dv.Rows.Count; i++)
                {
                    DataRow row = dv.Rows[i];
                    TreeNode childnode = new TreeNode();
                    childnode.Value = row["MID"].ToString();
                    childnode.Text = row["MName"].ToString();
                    string childid = row["MID"].ToString();
                    childnode = new TreeNode(childnode.Text, childnode.Value);
                    treenode.ChildNodes.Add(childnode);
                    //childnode.Expanded = false;
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
            framemain.Attributes["src"] = "MenuEdit.aspx?id=" + svalue + "&deep=" + tv_Meun.SelectedNode.Depth.ToString();
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
            framemain.Attributes["src"] = "MenuEdit.aspx?id=" + svalue + "&deep=" + tv_Meun.SelectedNode.Depth.ToString();

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
            framemain.Attributes["src"] = "MenuEdit.aspx?deep=1";
        }
        #endregion
    }
}