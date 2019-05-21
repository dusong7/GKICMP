/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年1月24日 16时35分19秒
** 描    述:      角色信息编辑
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Collections;
using System.Web.UI.WebControls;
using System.Data;

using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using GK.GKICMP.DAL;

namespace GKICMP.sysmanage
{
    public partial class RoleRight : PageBase
    {
        public SysRoleDAL sysRoleDAL = new SysRoleDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        #region 参数集合
        /// <summary>
        /// RoleID
        /// </summary>
        private int RoleID
        {
            get
            {
                return GetQueryString<int>("id", -1);
            }
        }
        #endregion


        #region 页面加载
        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dvmodules = sysRoleDAL.GetTableByRole(RoleID, -1);
                this.rpmodule.DataSource = dvmodules;
                this.rpmodule.DataBind();

                SysRoleEntity model = sysRoleDAL.GetObjByID(RoleID);
                if (model != null)
                {
                    this.lblrolename.Text = model.RoleName;
                }
            }
        }

        #endregion

        #region 一级模块绑定
        /// <summary>
        /// 一级模块绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rpmodule_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                HiddenField hfModuleID = (HiddenField)e.Item.FindControl("hffid");
                Repeater rpnextModule = (Repeater)e.Item.FindControl("rpnextModule");
                DataTable dvmodules = sysRoleDAL.GetTableByRole(RoleID, Convert.ToInt32(hfModuleID.Value));
                rpnextModule.DataSource = dvmodules;
                rpnextModule.DataBind();
                CheckBox chk_fid = (CheckBox)e.Item.FindControl("chk_fid");
            }
              
        }
        #endregion

        #region 二级模块绑定
        /// <summary>
        /// 二级模块绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rpnextModule_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                HiddenField hfModuleID = (HiddenField)e.Item.FindControl("hfsid");
                Repeater rpnextModule = (Repeater)e.Item.FindControl("rplastModule");
                DataTable dvmodules = sysRoleDAL.GetTableByRole(RoleID, Convert.ToInt32(hfModuleID.Value));
                rpnextModule.DataSource = dvmodules;
                rpnextModule.DataBind();
                CheckBox chk_fid = (CheckBox)e.Item.FindControl("chk_fid");

               
            }
            
        }
        #endregion

        #region 按钮列表绑定
        /// <summary>
        /// 按钮列表绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rpbuttonModule_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                HiddenField hfModuleID = (HiddenField)e.Item.FindControl("hftid");
                CheckBox chk_fid = (CheckBox)e.Item.FindControl("chk_tid");
                CheckBoxList chklModule = (CheckBoxList)e.Item.FindControl("chkl_tid");
                DataTable dvchkmodules = sysRoleDAL.GetButtonsByRid(Convert.ToInt32(hfModuleID.Value), RoleID);
                chklModule.DataTextField = "ButtonName";
                chklModule.DataValueField = "ButtonID";
                chklModule.DataSource = dvchkmodules;
                chklModule.DataBind();
                for (int i = 0; i < dvchkmodules.Rows.Count; i++)
                {
                    DataRow row = dvchkmodules.Rows[i];
                    if (row["F1"].ToString() != "" || RoleID == 1)
                    {
                        chklModule.Items[i].Selected = true;
                    }
                }
                if (RoleID == 1)
                {
                    chk_fid.Checked = true;
                }
                HiddenField hflModuleID = (HiddenField)e.Item.FindControl("hftid");
                Repeater rpendModule = (Repeater)e.Item.FindControl("rpendModule");
                DataTable dvlmodules = sysRoleDAL.GetTableByRole(RoleID, Convert.ToInt32(hflModuleID.Value));
                rpendModule.DataSource = dvlmodules;
                rpendModule.DataBind();
                CheckBox chk_lfid = (CheckBox)e.Item.FindControl("chk_fid");
            }
        }
        protected void rpbuttonModuleb_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                HiddenField hfModuleID = (HiddenField)e.Item.FindControl("hflid");
                CheckBox chk_fid = (CheckBox)e.Item.FindControl("chk_tid");
                CheckBoxList chklModule = (CheckBoxList)e.Item.FindControl("chkl_tid");
                DataTable dvchkmodules = sysRoleDAL.GetButtonsByRid(Convert.ToInt32(hfModuleID.Value), RoleID);
                chklModule.DataTextField = "ButtonName";
                chklModule.DataValueField = "ButtonID";
                chklModule.DataSource = dvchkmodules;
                chklModule.DataBind();
                for (int i = 0; i < dvchkmodules.Rows.Count; i++)
                {
                    DataRow row = dvchkmodules.Rows[i];
                    if (row["F1"].ToString() != "" || RoleID == 1)
                    {
                        chklModule.Items[i].Selected = true;
                    }
                }
                if (RoleID == 1)
                {
                    chk_fid.Checked = true;
                }
            }
        }
        #endregion

        #region 保存
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {

            CheckBox chkfid;
            HiddenField hffid;
            CheckBox chksid;
            HiddenField hfsid;
            CheckBoxList chkl_sbtnids;
            CheckBox chktid;
            HiddenField hftid;
            CheckBoxList chkl_tbtnids;
            Repeater rpsid;
            Repeater rptid;
            Repeater lptid;


            string sids = "";
            string sbtnids = "";

            for (int i = 0; i < this.rpmodule.Items.Count; i++)
            {
                chkfid = (CheckBox)rpmodule.Items[i].FindControl("chk_fid");
                hffid = (HiddenField)rpmodule.Items[i].FindControl("hffid");
                rpsid = (Repeater)rpmodule.Items[i].FindControl("rpnextModule");
                if (chkfid.Checked)
                {
                    sids += hffid.Value + "|";
                    sbtnids += "-2" + "|";
                }
                if (rpsid != null && rpsid.Items.Count != 0)
                {
                    for (int j = 0; j < rpsid.Items.Count; j++)
                    {
                        rptid = (Repeater)rpsid.Items[j].FindControl("rplastModule");
                        chksid = (CheckBox)rpsid.Items[j].FindControl("chk_fid");
                        hfsid = (HiddenField)rpsid.Items[j].FindControl("hfsid");
                        chkl_sbtnids = (CheckBoxList)rpsid.Items[j].FindControl("chkl_tid");
                        if (chksid != null && chksid.Checked)
                        {
                            sids += hfsid.Value + "|";
                            if (chkl_sbtnids != null && chkl_sbtnids.Items.Count > 0)
                            {
                                sbtnids += GetChecked(chkl_sbtnids) + "|";
                            }
                            else
                            {
                                sbtnids += "-2" + "|";
                            }
                        }

                        if (rptid != null && rptid.Items.Count != 0)
                        {
                            for (int k = 0; k < rptid.Items.Count; k++)
                            {
                                lptid=(Repeater)rptid.Items[k].FindControl("rpendModule");
                                chktid = (CheckBox)rptid.Items[k].FindControl("chk_tid");
                                hftid = (HiddenField)rptid.Items[k].FindControl("hftid");
                                chkl_tbtnids = (CheckBoxList)rptid.Items[k].FindControl("chkl_tid");
                                if (chktid != null && chktid.Checked)
                                {
                                    sids += hftid.Value + "|";
                                    if (chkl_tbtnids != null && chkl_tbtnids.Items.Count > 0)
                                    {
                                        sbtnids += GetChecked(chkl_tbtnids) + "|";
                                    }
                                    else
                                    {
                                        sbtnids += "-2" + "|";
                                    }
                                }
                                if (lptid != null && lptid.Items.Count != 0)
                                {
                                    for (int l = 0; l < lptid.Items.Count; l++)
                                    {
                                        chktid = (CheckBox)lptid.Items[l].FindControl("chk_tid");
                                        hftid = (HiddenField)lptid.Items[l].FindControl("hflid");
                                        chkl_tbtnids = (CheckBoxList)lptid.Items[l].FindControl("chkl_tid");
                                        if (chktid != null && chktid.Checked)
                                        {
                                            sids += hftid.Value + "|";
                                            if (chkl_tbtnids != null && chkl_tbtnids.Items.Count > 0)
                                            {
                                                sbtnids += GetChecked(chkl_tbtnids) + "|";
                                            }
                                            else
                                            {
                                                sbtnids += "-2" + "|";
                                            }
                                        }

                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (sids != "")
            {
                int result = sysRoleDAL.RoleRightAdd(RoleID, sids.TrimEnd('|'), sbtnids.TrimEnd('|'));
                if (result > 0)
                {
                    ShowMessage();
                }
                else
                {
                    ShowMessage("提交失败");
                    return;
                }
            }
            else
            {
                ShowMessage("请选择要设置的权限");
                return;
            }

        }
        #endregion

        #region 得到CheckBoxList中选中了的值
        /// <summary>
        /// 得到CheckBoxList中选中了的值
        /// </summary>
        /// <param name="checkList">CheckBoxList</param>
        /// <returns></returns>
        private string GetChecked(CheckBoxList checkList)
        {
            string selval = "";
            for (int i = 0; i < checkList.Items.Count; i++)
            {
                if (checkList.Items[i].Selected)
                {
                    selval += checkList.Items[i].Value + ",";
                }
            }
            if (selval.TrimEnd(',') == "")
            {
                return "-2";
            }
            else
            {
                return selval.TrimEnd(',');
            }
        }
        #endregion

        #region 遍历所有节点
        //遍历所有节点
        private void SetNode(TreeNodeCollection tc, ref Hashtable ht)
        {
            foreach (TreeNode TNode in tc)
            {
                foreach (DictionaryEntry de in ht)
                {
                    if (TNode.Value == de.Key.ToString())
                    {
                        string blnode = de.Value.ToString();
                        if (blnode == "")
                            blnode = "True";
                        TNode.Expanded = bool.Parse(blnode);
                        SetNode(TNode.ChildNodes, ref ht);
                    }
                }
            }
        }
        #endregion

        #region 遍历所有节点
        //遍历所有节点
        public void GetNode(TreeNodeCollection tc, ref Hashtable ht)
        {
            foreach (TreeNode TNode in tc)
            {

                ht.Add(TNode.Value.ToString(), TNode.Expanded.ToString());
                GetNode(TNode.ChildNodes, ref ht);
            }
        }
        #endregion

        #region 选中部分节点
        //遍历所有节点
        public void SelectNode(TreeNodeCollection tc, string strdeplist)
        {
            foreach (TreeNode TNode in tc)
            {

                string[] deplist = strdeplist.Split(',');
                for (int i = 0; i < deplist.Length; i++)
                {
                    if (deplist[i] == TNode.Value)
                        TNode.Checked = true;
                }
                SelectNode(TNode.ChildNodes, strdeplist);
            }
        }
        #endregion

        #region 选中部分节点
        //遍历所有节点
        public void SelectAllNode(TreeNodeCollection tc)
        {
            foreach (TreeNode TNode in tc)
            {
                TNode.Checked = true;
                SelectAllNode(TNode.ChildNodes);
            }
        }
        #endregion
    }
}