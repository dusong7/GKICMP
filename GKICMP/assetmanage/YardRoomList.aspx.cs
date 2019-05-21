/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月07日 09点30分
** 描   述:       场室列表
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

namespace GKICMP.assetmanage
{
    public partial class YardRoomList : PageBase
    {
        public BuildingDAL buildingDAL = new BuildingDAL();
        public FloorDAL floorDAL = new FloorDAL();
        public CampusDAL campusDAL = new CampusDAL();
        public ClassRoomDAL roomDAL = new ClassRoomDAL();



        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                DepBind();
                framemain.Attributes["src"] = "YardRoomManage.aspx?id=" + "" + "&deep=0";
            }
        }
        #endregion


        #region 校区绑定
        /// <summary>
        /// 校区绑定
        /// </summary>
        private void DepBind()
        {
            this.tv_Meun.Nodes.Clear();
            DataTable dt = campusDAL.GetList((int)CommonEnum.Deleted.未删除);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                TreeNode treenode = new TreeNode();
                int DID = Convert.ToInt32(row["CID"].ToString());
                treenode.Value = DID.ToString();
                treenode.Text = row["CampusName"].ToString();
                tv_Meun.Nodes.Add(treenode);
                if (i != 0)
                {
                    treenode.Expanded = false;
                }
                FlooBind(treenode, DID);
            }
        }
        #endregion


        #region 宿舍楼绑定
        public void FlooBind(TreeNode treenode, int parentID)
        {
            DataTable dt = buildingDAL.GetList(parentID, (int)CommonEnum.Deleted.未删除, (int)CommonEnum.BuildingType.教学楼);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                TreeNode pnode = new TreeNode();
                int DID = Convert.ToInt32(row["BID"].ToString());
                pnode.Value = DID.ToString();
                pnode.Text = row["BName"].ToString();
                pnode = new TreeNode(pnode.Text, pnode.Value);
                treenode.ChildNodes.Add(pnode);
                if (i != 0)
                {
                    pnode.Expanded = false;
                }
                ChildBind(pnode, DID);
            }

        }
        #endregion



        #region 楼层绑定
        public void ChildBind(TreeNode treenode, int parentID)
        {
            DataTable dt = floorDAL.GetByBID(parentID, (int)CommonEnum.Deleted.未删除);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                TreeNode childnode = new TreeNode();
                string FID = row["FID"].ToString();
                childnode.Value = row["FID"].ToString();
                childnode.Text = row["FloorName"].ToString();
                childnode = new TreeNode(childnode.Text, childnode.Value);
                treenode.ChildNodes.Add(childnode);
                if (i != 0)
                {
                    childnode.Expanded = false;
                }
                CBind(childnode, FID);
            }
        }
        #endregion


        #region 场室绑定
        public void CBind(TreeNode treenode, string parentID)
        {
            DataTable dt = roomDAL.GetList(parentID, 3, (int)CommonEnum.Deleted.未删除, (int)CommonEnum.IsorNot.是);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                TreeNode childsnode = new TreeNode();
                childsnode.Value = row["CRID"].ToString();
                childsnode.Text = row["RoomName"].ToString();
                childsnode = new TreeNode(childsnode.Text, childsnode.Value);
                treenode.ChildNodes.Add(childsnode);
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
            framemain.Attributes["src"] = "YardRoomManage.aspx?id=" + svalue + "&deep=" + tv_Meun.SelectedNode.Depth.ToString();
        }
        #endregion
    }
}