/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月07日 09点30分
** 描   述:       教师
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
    public partial class TeacherScheduleAll : PageBase
    {
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();



        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                DepBind();
                string svalue = ViewState["uid"].ToString();//获得点击的值 
                framemain.Attributes["src"] = "TPersonSchedule.aspx?id=" + svalue + "&flag=1" + "&deep=1";
            }
        }
        #endregion


        #region 部门绑定
        /// <summary>
        /// 部门绑定
        /// </summary>
        private void DepBind()
        {
            this.tv_Meun.Nodes.Clear();
            DataTable dt = departmentDAL.GetList((int)CommonEnum.Deleted.未删除, -2);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                TreeNode treenode = new TreeNode();
                int DID = Convert.ToInt32(row["DID"].ToString());
                treenode.Value = DID.ToString();
                treenode.Text = row["DepName"].ToString();
                tv_Meun.Nodes.Add(treenode);
                if (i != 0)
                {
                    treenode.Expanded = false;
                }
                ChildBind(treenode, DID, i);
            }
        }
        #endregion


        #region 人员绑定
        private void ChildBind(TreeNode treenode, int parentID, int j)
        {
            DataTable dt = sysUserDAL.GetSysUserByDepid(1, parentID);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                if (j == 0 && i == 0)
                {
                    ViewState["uid"] = row["UID"].ToString();
                }
                TreeNode childnode = new TreeNode();
                childnode.Value = row["UID"].ToString();
                childnode.Text = row["RealName"].ToString();
                childnode = new TreeNode(childnode.Text, childnode.Value);
                treenode.ChildNodes.Add(childnode);
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
            framemain.Attributes["src"] = "TPersonSchedule.aspx?id=" + svalue + "&flag=1" + "&deep=" + tv_Meun.SelectedNode.Depth.ToString();
        }
        #endregion
    }
}