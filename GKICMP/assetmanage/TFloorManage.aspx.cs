/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      樊紫红
** 创建日期:    2016年12月28日 
** 描 述:       楼层管理页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using GK.GKICMP.Common;
using GK.GKICMP.DAL;

using System;
using System.Data;
using System.Web.UI.WebControls;

namespace ICMP.assetmanage
{
    public partial class TFloorManage : PageBase
    {
        public FloorDAL floorDAL = new FloorDAL();
        public SysModuleDAL sysModuleDAL = new SysModuleDAL();
        public BuildingDAL buildingDAL = new BuildingDAL();

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


        #region 绑定校区
        /// <summary>
        /// 绑定校区
        /// </summary>
        private void TreeBind()
        {
            this.tv_Meun.Nodes.Clear();
            DataTable dv = floorDAL.GetTable((int)CommonEnum.Deleted.未删除);

            for (int i = 0; i < dv.Rows.Count; i++)
            {
                DataRow row = dv.Rows[i];
                TreeNode treenode = new TreeNode();
                int cid = Convert.ToInt32(row["CID"].ToString());
                treenode.Value = cid.ToString();
                treenode.Text = row["CampusName"].ToString();
                tv_Meun.Nodes.Add(treenode);
                //treenode.Expanded = false;
                if (i == 0)
                {
                    treenode.Expanded = true;
                    //framemain.Attributes["src"] = "TFloorEdit.aspx?id=" + cid.ToString() + "&deep=" + treenode.Depth.ToString();
                }
                ChildBind(treenode, cid);
            }
        }
        #endregion


        #region 绑定子节点--教学楼
        /// <summary>
        ///绑定子节点--宿舍楼
        /// </summary>
        /// <param name="treenode"></param>
        /// <param name="depid"></param>
        private void ChildBind(TreeNode treenode, int cid)
        {
            //DataTable dv = buildingDAL.GetTable(cid, (int)CommonEnum.Deleted.未删除);
            DataTable dv = buildingDAL.GetList(cid, (int)CommonEnum.Deleted.未删除, (int)CommonEnum.BuildingType.教学楼);
            //DataTable dv = buildingDAL.GetList((int)CommonEnum.Deleted.未删除, (int)CommonEnum.BuildingType.教学楼);
            if (dv.Rows.Count > 0)
            {
                for (int i = 0; i < dv.Rows.Count; i++)
                {
                    DataRow row = dv.Rows[i];
                    TreeNode childnode = new TreeNode();
                    childnode.Value = row["BID"].ToString();
                    childnode.Text = row["BName"].ToString();
                    int bid = Convert.ToInt32(row["BID"].ToString());
                    childnode = new TreeNode(childnode.Text, childnode.Value);
                    treenode.ChildNodes.Add(childnode);
                    //childnode.Expanded = false;
                    FloorBind(childnode, bid);
                    if (i == 0)
                    {
                        treenode.Expanded = true;
                        //framemain.Attributes["src"] = "TFloorEdit.aspx?id=" + bid.ToString() + "&deep=" + treenode.Depth.ToString();
                    }
                }
            }
        }
        #endregion


        #region 绑定子节点--楼层
        /// <summary>
        /// 绑定子节点--楼层
        /// </summary>
        /// <param name="treenode"></param>
        /// <param name="depid"></param>
        private void FloorBind(TreeNode treenode, int bid)
        {
            DataTable dv = floorDAL.GetByBID(bid, (int)CommonEnum.Deleted.未删除);
            if (dv.Rows.Count > 0)
            {
                for (int i = 0; i < dv.Rows.Count; i++)
                {
                    DataRow row = dv.Rows[i];
                    TreeNode childnode = new TreeNode();
                    childnode.Value = row["FID"].ToString();
                    childnode.Text = row["FloorName"].ToString();
                    string tid = row["BID"].ToString();
                    childnode = new TreeNode(childnode.Text, childnode.Value);
                    treenode.ChildNodes.Add(childnode);
                    //childnode.Expanded = false;
                    //if (i == 0)
                    //{
                    //    treenode.Expanded = true;
                    //    framemain.Attributes["src"] = "TFloorEdit.aspx?bid=" + tid.ToString() + "&deep=" + treenode.Depth.ToString();
                    //}
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
            framemain.Attributes["src"] = "TFloorEdit.aspx?id=" + svalue + "&deep=" + tv_Meun.SelectedNode.Depth.ToString();
        }
        #endregion
    }
}