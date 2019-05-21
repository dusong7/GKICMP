/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年11月3日 17点30分
** 描   述:       学生活动列表页面
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.schoolwork
{
    public partial class StudentActList : PageBase
    {
        public StudentActivityDAL actDAL = new StudentActivityDAL();

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
            }
        }
        #endregion


        #region 活动数据绑定
        /// <summary>
        /// 活动数据绑定
        /// </summary>
        private void GradeBind()
        {
            this.tv_Meun.Nodes.Clear();
            DataTable dv = actDAL.GetList((int)CommonEnum.Deleted.未删除);
            string id = "";
            for (int i = 0; i < dv.Rows.Count; i++)
            {

                DataRow row = dv.Rows[i];
                if (i == 0)
                {
                    id = row["SAID"].ToString();

                }
                TreeNode treenode = new TreeNode();
                treenode.Value = row["SAID"].ToString();
                treenode.Text = row["ActName"].ToString().Length > 10 ? row["ActName"].ToString().Substring(0, 10) + "..." : row["ActName"].ToString();
                treenode.ToolTip = row["ActName"].ToString();
                tv_Meun.Nodes.Add(treenode);

            }
            framemain.Attributes["src"] = "StudentActTheme.aspx?id=" + id + "&deep=1";
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
            framemain.Attributes["src"] = "StudentActTheme.aspx?id=" + svalue + "&deep=" + tv_Meun.SelectedNode.Depth.ToString();
        }
        #endregion
    }
}