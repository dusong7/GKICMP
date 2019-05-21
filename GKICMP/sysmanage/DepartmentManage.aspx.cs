/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年01月03日 09点30分
** 描   述:      部门页面
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using System.Data;

namespace GKICMP.sysmanage
{
    public partial class DepartmentManage : PageBase
    {
        
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
            Type enumType = typeof(CommonEnum.DepType);
            DataTable dt = EnumToDataTable(enumType);
            //for (int i = 0; i < dt.Rows.Count; i++)
            for (int i = 0; i < dt.Rows.Count;i++ )
            {
                DataRow row = dt.Rows[i];
                TreeNode treenode = new TreeNode();
                int moduleid = Convert.ToInt32(row["Value"].ToString());//获取枚举对应值的数字
                treenode.Value = moduleid.ToString();
                treenode.Text = row["Text"].ToString();
                tv_Meun.Nodes.Add(treenode);
                //treenode.Expanded = false;
                if (moduleid == -1)
                {
                    ChildBind(treenode);  //年级
                }
                else
                {
                    DepartBind(treenode); //部门
                }

            }
        }
        #endregion

        #region 将枚举转换成DataTable
        /// <summary>
        /// 将枚举转换成DataTable
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public DataTable EnumToDataTable(Type enumType)
        {
            string[] Names = System.Enum.GetNames(enumType);
            Array Values = System.Enum.GetValues(enumType);
            DataTable dt = new DataTable();
            dt.Columns.Add("Text", System.Type.GetType("System.String"));
            dt.Columns.Add("Value", System.Type.GetType("System.Int32"));
            dt.Columns["Text"].Unique = true;
            for (int i = 0; i < Values.Length; i++)
            {
                DataRow dr = dt.NewRow();
                dr["Text"] = Names[i].ToString();
                dr["Value"] = (int)Values.GetValue(i);
                dt.Rows.Add(dr);
            }
            return dt;
        }
        #endregion

        #region ListEnum
        public static DataTable ListEnum(Type enumType)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Text");
            dt.Columns.Add("Value");
            Array values = Enum.GetValues(enumType);
            foreach (Enum value in values)
            {
                DataRow dr = dt.NewRow();
                dr["Text"] = value.ToString();
                dr["Value"] = (int)Enum.Parse(enumType, value.ToString());
                dt.Rows.Add(dr);
            }
            return dt;
        }
        #endregion

        #region 绑子节点--部门
        /// <summary>
        /// 绑子节点--部门
        /// </summary>
        /// <param name="treenode"></param>
        /// <param name="depid"></param>
        private void DepartBind(TreeNode treenode)
        {
            DataTable dv = departmentDAL.GetList((int)CommonEnum.Deleted.未删除, (int)CommonEnum.DepType.职能部门);
            if (dv.Rows.Count > 0)
            {
                for (int i = 0; i < dv.Rows.Count; i++)
                {
                    DataRow row = dv.Rows[i];
                    TreeNode childnode = new TreeNode();
                    childnode.Value = row["DID"].ToString();
                    childnode.Text = row["DepName"].ToString();
                    //int childid = Convert.ToInt32(row["DID"].ToString());
                    childnode = new TreeNode(childnode.Text, childnode.Value);
                    treenode.ChildNodes.Add(childnode);
                    childnode.Expanded = false;


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
            framemain.Attributes["src"] = "DepartmentEdit.aspx?id=" + svalue + "&deep=" + tv_Meun.SelectedNode.Depth.ToString();
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
            framemain.Attributes["src"] = "DepartmentEdit.aspx?id=" + svalue + "&deep=" + tv_Meun.SelectedNode.Depth.ToString();
        }
        #endregion



        #region 添加一级菜单
         //<summary>
         //添加一级菜单
         //</summary>
         //<param name="sender"></param>
         //<param name="e"></param>
        protected void lbtn_Add_Click(object sender, EventArgs e)
        {
            framemain.Attributes["src"] = "DepartmentEdit.aspx?id=" + "" + "&deep=1";
        }
        #endregion

        #region 绑子节点--年级
        ///// <summary>
        ///// 绑子节点--年级
        ///// </summary>
        ///// <param name="treenode"></param>
        ///// <param name="depid"></param>
        private void ChildBind(TreeNode treenode)
        {
            DataTable dv = departmentDAL.GetTable((int)CommonEnum.Deleted.未删除);
            if (dv.Rows.Count > 0)
            {
                for (int i = 0; i < dv.Rows.Count; i++)
                {
                    DataRow row = dv.Rows[i];
                    TreeNode childnode = new TreeNode();
                    childnode.Value = row["DID"].ToString();
                    childnode.Text = row["DepName"].ToString();
                    //int childid = Convert.ToInt32(row["DID"].ToString());
                    childnode = new TreeNode(childnode.Text, childnode.Value);
                    treenode.ChildNodes.Add(childnode);
                    childnode.Expanded = false;
                    //DataRow row = dv.Rows[i];
                    //TreeNode childnode = new TreeNode();
                    //childnode.Value = row["GID"].ToString();
                    //childnode.Text = row["GradeName"].ToString();
                    //int childid = Convert.ToInt32(row["GID"].ToString());
                    //childnode = new TreeNode(childnode.Text, childnode.Value);
                    //treenode.ChildNodes.Add(childnode);
                    ////childnode.Expanded = false;
                    //ClassBind(childnode, childid);

                }
            }
        }
        #endregion

        #region 绑定班级
        ///// <summary>
        ///// 绑定班级
        ///// </summary>
        ///// <param name="treenode"></param>
        ///// <param name="moduleid"></param>
        private void ClassBind(TreeNode treenode, int moduleid)
        {
            DataTable dv = departmentDAL.GetByGID(moduleid, (int)CommonEnum.Deleted.未删除);
            if (dv.Rows.Count > 0)
            {
                for (int i = 0; i < dv.Rows.Count; i++)
                {
                    DataRow row = dv.Rows[i];
                    TreeNode childnode = new TreeNode();
                    childnode.Value = row["DID"].ToString();
                    childnode.Text = row["DepName"].ToString();
                    childnode = new TreeNode(childnode.Text, childnode.Value);
                    treenode.ChildNodes.Add(childnode);
                    childnode.Expanded = false;


                }
            }
        }
        #endregion


    }
}