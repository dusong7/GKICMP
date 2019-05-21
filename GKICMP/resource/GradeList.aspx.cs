using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GKICMP.resource
{
    public partial class GradeList :  PageBase
    {
        public GradeLevelDAL gradeLevelDAL = new GradeLevelDAL();
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
                if (Flag == 1)
                {
                    this.lbl_Menuname.Text = "我的资源";
                    framemain.Attributes["src"] = "EduEesourseList.aspx?gid=1,1&deep=-1&flag=1";
                }
               
                else
                {
                    this.lbl_Menuname.Text = "资源管理";
                    framemain.Attributes["src"] = "EduEesourseList.aspx?gid=1,1&deep=-1&flag=2";
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
            DataTable dt = gradeLevelDAL.GetList();//年级绑定

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                TreeNode treenode = new TreeNode();
                int gid = Convert.ToInt32(row["GLID"].ToString());
                treenode.Value = gid.ToString();
                treenode.Text = row["ShortName"].ToString();
                tv_Meun.Nodes.Add(treenode);
                treenode.Expanded = false;
                //if (i == 0)
                //{
                //    treenode.Expanded = true;
                //}
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
            //DataTable dv = null;
            //dv = departmentDAL.GetByGID(gid, (int)CommonEnum.Deleted.未删除);
            //if (dv.Rows.Count > 0)
            //{
            //    for (int i = 0; i < dv.Rows.Count; i++)
            //    {
            //        DataRow row = dv.Rows[i];
            //        TreeNode childnode = new TreeNode();
            //        childnode.Value = row["DID"].ToString();
            //        childnode.Text = row["DepName"].ToString();
            //        int claid = Convert.ToInt32(row["DID"].ToString());
            //        childnode = new TreeNode(childnode.Text, childnode.Value);
            //        treenode.ChildNodes.Add(childnode);                   
            //    }
            //}
              TreeNode childnode1 = new TreeNode();
                    childnode1.Value =gid.ToString()+",1";
                    childnode1.Text = "上学期";
            
                    childnode1 = new TreeNode(childnode1.Text, childnode1.Value);
                    treenode.ChildNodes.Add(childnode1);          
                    TreeNode childnode2 = new TreeNode();
                    childnode2.Value =gid.ToString()+",2";
                    childnode2.Text = "下学期";
            
                    childnode2 = new TreeNode(childnode2.Text, childnode2.Value);
                    treenode.ChildNodes.Add(childnode2);   
                 
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

            //if (Flag == 1)
            //{
                framemain.Attributes["src"] = "EduEesourseList.aspx?gid=" + svalue + "&deep=" + tv_Meun.SelectedNode.Depth.ToString()+"&flag="+Flag;
            //}
     
        }
        #endregion
    }
}