/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月07日 09点30分
** 描   述:       晨检申报
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

namespace GKICMP.studentmanage
{
    public partial class StuAttendList : PageBase
    {
        public GradeDAL gradeDAL = new GradeDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();


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
                framemain.Attributes["src"] = "StuAttendEdit.aspx";
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
            dv = departmentDAL.GetByGID(gid, (int)CommonEnum.IsorNot.否);
            if (dv.Rows.Count > 0)
            {
                for (int i = 0; i < dv.Rows.Count; i++)
                {
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
            framemain.Attributes["src"] = "StuAttendEdit.aspx?did=" + svalue + "&deep=" + deep;
        }
        #endregion
    }
}