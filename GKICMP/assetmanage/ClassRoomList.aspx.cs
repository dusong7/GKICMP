/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      樊紫红
** 创建日期:    2016年12月28日 15:31
** 描 述:       宿舍管理页面
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


namespace ICMP.assetmanage
{
    public partial class ClassRoomList : PageBase
    {
        public BuildingDAL buildingDAL = new BuildingDAL();
        public FloorDAL floorDAL = new FloorDAL();
        public CampusDAL campusDAL = new CampusDAL();

        #region 参数集合
        /// <summary>
        /// Flag 1:教室 2:会议室 3:场室
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
                CampusBind();
                framemain.Attributes["src"] = "ClassRoomManage.aspx?id=" + "" + "&deep=0" + "&flag=" + Flag;
            }
        }
        #endregion


        #region 绑定校区
        /// <summary>
        /// 绑定校区
        /// </summary>
        private void CampusBind()
        {
            this.tv_Meun.Nodes.Clear();
            DataTable dv = campusDAL.GetList((int)CommonEnum.Deleted.未删除);

            for (int i = 0; i < dv.Rows.Count; i++)
            {
                DataRow row = dv.Rows[i];
                TreeNode treenode = new TreeNode();
                int cid = Convert.ToInt32(row["CID"].ToString());
                treenode.Value = cid.ToString();
                treenode.Text = row["CampusName"].ToString();
                tv_Meun.Nodes.Add(treenode);
                if (i == 0)
                {
                    treenode.Expanded = true;
                }
                ChildBind(treenode, cid);
            }
        }
        #endregion


        #region 绑定宿舍楼
        /// <summary>
        ///绑定宿舍楼
        /// </summary>
        /// <param name="treenode"></param>
        /// <param name="depid"></param>
        private void ChildBind(TreeNode treenode, int cid)
        {
            DataTable dv = null;
            dv = buildingDAL.GetList(cid, (int)CommonEnum.Deleted.未删除, (int)CommonEnum.BuildingType.教学楼);
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
                    FloorBind(childnode, bid);
                    if (i == 0)
                    {
                        treenode.Expanded = true;
                    }
                }
            }
        }
        #endregion


        #region 绑定楼层
        /// <summary>
        /// 绑定楼层
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
            framemain.Attributes["src"] = "ClassRoomManage.aspx?id=" + svalue + "&deep=" + tv_Meun.SelectedNode.Depth.ToString() + "&flag=" + Flag;
        }
        #endregion
    }
}