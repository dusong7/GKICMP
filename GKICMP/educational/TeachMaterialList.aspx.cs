/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年05月27日 09点36分
** 描   述:      教材年级列表页面
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;

namespace GKICMP.educational
{
    public partial class TeachMaterialList : PageBase
    {
        public TeachMaterialDAL materDAL = new TeachMaterialDAL();
        public TeachMaterialVersionDAL versionDAL = new TeachMaterialVersionDAL();

        #region 参数集合
        /// <summary>
        /// 课程ID
        /// </summary>
        public int CID
        {
            get
            {
                return GetQueryString<int>("id", -1);
            }
        }
        #endregion
        public DataTable dtm;

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
                framemain.Attributes["src"] = "TeachMaterialEdit.aspx?id=" + "" + "&cid=" + CID + "&deep=-1";
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
            DataTable dt = versionDAL.GetList(CID);
            dtm = materDAL.GetList( CID, (int)CommonEnum.Deleted.未删除);
            //for (int i = 0; i < dt.Rows.Count; i++)
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                TreeNode treenode = new TreeNode();
                int moduleid = Convert.ToInt32(row["TMVID"].ToString());//获取枚举对应值的数字
                treenode.Value = moduleid.ToString();
                treenode.Text = row["VersionName"].ToString();
                tv_Meun.Nodes.Add(treenode);
                treenode.Expanded = false;
                if (i == 0)
                {
                    treenode.Expanded = true;
                    framemain.Attributes["src"] = "TeachMaterialManage.aspx?tmvid=" + moduleid.ToString() + "&deep=" + treenode.Depth.ToString();
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
            if (dtm != null && dtm.Rows.Count > 0)
            {
                DataRow[] dr = dtm.Select("TEdition=" + moduleid);
                if (dr != null && dr.Length > 0)
                {
                    foreach (DataRow row in dr)
                    {
                        // DataRow row = dv.Rows[i];
                        TreeNode childnode = new TreeNode();
                        childnode.Value = row["TMID"].ToString();
                        childnode.Text = row["TMName"].ToString();
                        int childid = Convert.ToInt32(row["TMID"].ToString());
                        childnode = new TreeNode(childnode.Text, childnode.Value);
                        treenode.ChildNodes.Add(childnode);
                        childnode.Expanded = false;
                        //ChildBind(childnode, childid);
                        //if (i == 0)
                        //{
                        //    treenode.Expanded = true;
                        //    framemain.Attributes["src"] = "TeachMaterialEdit.aspx?tmvid=" + moduleid.ToString() + "&deep=" + treenode.Depth.ToString();
                        //}
                    }
                }
            }



            //DataTable dv = materDAL.GetList(moduleid, CID, (int)CommonEnum.Deleted.未删除);
            //if (dv.Rows.Count > 0)
            //{
            //    for (int i = 0; i < dv.Rows.Count; i++)
            //    {
            //        DataRow row = dv.Rows[i];
            //        TreeNode childnode = new TreeNode();
            //        childnode.Value = row["TMID"].ToString();
            //        childnode.Text = row["TMName"].ToString();
            //        int childid = Convert.ToInt32(row["TMID"].ToString());
            //        childnode = new TreeNode(childnode.Text, childnode.Value);
            //        treenode.ChildNodes.Add(childnode);
            //        childnode.Expanded = false;
            //        ChildBind(childnode, childid);
            //        //if (i == 0)
            //        //{
            //        //    treenode.Expanded = true;
            //        //    framemain.Attributes["src"] = "TeachMaterialEdit.aspx?tmvid=" + moduleid.ToString() + "&deep=" + treenode.Depth.ToString();
            //        //}
            //    }
            //}
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
            if (tv_Meun.SelectedNode.Depth.ToString() == "0")
            {
                framemain.Attributes["src"] = "TeachMaterialManage.aspx?tmvid=" + svalue + "&cid=" + CID + "&deep=" + tv_Meun.SelectedNode.Depth.ToString();
            }
            else if (tv_Meun.SelectedNode.Depth.ToString() == "1")
            {
                framemain.Attributes["src"] = "TeachMChapterManage.aspx?tmid=" + svalue + "&deep=" + tv_Meun.SelectedNode.Depth.ToString();
            }
        }
        #endregion


        #region 教材添加
        /// <summary>
        /// 教材添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Add_Click(object sender, EventArgs e)
        {
            framemain.Attributes["src"] = "TeachMaterialEdit.aspx?cid=" + CID;
        }
        #endregion

        protected void btn_Import_Click(object sender, EventArgs e)
        {
            framemain.Attributes["src"] = "TeachMateriaImport.aspx?cid=" + CID;
        }
    }
}