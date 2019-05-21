/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      lfz
** 创建日期:    2017年3月02日
** 描 述:       模块管理页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;

namespace GKICMP.sysmanage
{
    public partial class ModuleEdit : PageBase
    {
        public SysModuleDAL sysModuleDAL = new SysModuleDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();

        #region 参数集合
        /// <summary>
        /// MID
        /// </summary>
        public int MID
        {
            get
            {
                return GetQueryString<int>("id", -2);
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
                cblBand();
                if (MID != -2)
                {
                    InfoBind();
                }
                else
                {
                    this.hf_PID.Value = "-1";
                    this.hf_ID.Value = "-2";
                    this.btn_Delete.Visible = false;
                    this.btn_Add.Visible = false;
                }
            }
        }
        #endregion


        #region 初始化数据
        /// <summary>
        /// 初始化数据
        /// </summary>
        protected void InfoBind()
        {
            SysModuleEntity model = sysModuleDAL.GetObj(MID);
            if (model != null)
            {
                this.txt_MName.Text = model.ModuleName;//模块名称
                this.hf_ID.Value = model.ModuleID.ToString();
                this.hf_PID.Value = model.ParentID.ToString();
                string[] bt = model.ModuleButton.Split(',');
                //父级模块名称
                if (model.ParentID != -1)
                {
                    SysModuleEntity Mmodel = sysModuleDAL.GetObj(model.ParentID);
                    if (model != null)
                    {
                    }
                    this.txt_PMName.Text = Mmodel.ModuleName;
                }
                //按钮
                foreach (string dr in bt)
                {
                    foreach (ListItem li in this.cbl_Button.Items)
                    {
                        if (dr == li.Value)
                        {
                            li.Selected = true;
                        }
                    }
                }
                this.txt_Icon.Text = model.ModuleIcon;//图标
                this.txt_Url.Text = model.ModuleUrl;//栏目地址
                this.rbol_MType.SelectedValue = model.IsRight.ToString();
                this.txt_Order.Text = model.ModuleOrder.ToString();
            }
        }
        #endregion


        #region 按钮绑定
        /// <summary>
        /// 按钮绑定
        /// </summary>
        private void cblBand()
        {
            DataTable dt = sysModuleDAL.GetButton();
            CommonFunction.CBLTypeBind(this.cbl_Button, dt, "BID", "ButtonName");
        }
        #endregion


        #region 提交
        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                string button = "";
                SysModuleEntity model = new SysModuleEntity();
                model.ParentID = int.Parse(this.hf_PID.Value);
                model.ModuleID = int.Parse(this.hf_ID.Value);
                model.ModuleName = this.txt_MName.Text;
                model.ModuleUrl = this.txt_Url.Text;
                model.ModuleIcon = this.txt_Icon.Text;
                model.IsRight = int.Parse(this.rbol_MType.SelectedValue);
                if (this.txt_Order.Text == "")
                {
                    model.ModuleOrder = 0;
                }
                else
                {
                    Double rt;
                    if (System.Double.TryParse(this.txt_Order.Text, out rt))
                    {
                        model.ModuleOrder = int.Parse(this.txt_Order.Text);
                    }
                    else
                    {
                        ShowMessage("排序号只能填写有效数字！！！");
                        return;
                    }
                }
                foreach (ListItem li in this.cbl_Button.Items)
                {
                    if (li.Selected)
                    {
                        button = button + li.Value + ",";
                    }
                }

                if (button.Length > 0)
                {
                    button = button.Substring(0, button.Length - 1);
                }
                model.ModuleButton = button;
                int result = sysModuleDAL.Edit(model);
                if (result == -1)
                {
                    ShowMessage("提交失败");
                    return;
                }
                else if (result == -2)
                {
                    ShowMessage("该栏目名称已存在，请重新输入");
                    return;
                }
                else
                {
                    int log = MID == -2 ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, (MID == -2 ? "" : "") + "增加栏目【" + this.txt_MName.Text + "】信息", UserID));

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script>alert('系统提示：提交成功！');succ();</script>");
                }
            }
            catch (Exception error)
            {
                ShowMessage(error.Message);
            }
        }
        #endregion


        #region 添加子栏目
        /// <summary>
        /// 添加子栏目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Add_Click(object sender, EventArgs e)
        {
            this.btn_Delete.Visible = this.btn_Add.Visible = false;
            this.txt_PMName.Text = this.txt_MName.Text;
            this.txt_MName.Text = "";
            this.hf_PID.Value = this.hf_ID.Value;
            this.hf_ID.Value = "-2";
            this.rbol_MType.SelectedValue = "1";
            this.txt_Url.Text = "";
            this.txt_Icon.Text = "";
        }
        #endregion


        #region 删除栏目
        /// <summary>
        /// 删除栏目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            int mid = Convert.ToInt32(this.hf_ID.Value);
            int istrue = sysModuleDAL.DeleteBat(mid);
            if (istrue == 0)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除栏目【" + this.txt_MName.Text + "】", UserID));
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script>alert('系统提示：删除成功！');succ();</script>");
            }
            else if (istrue == -2)
            {
                ShowMessage("该栏目存在子栏目，无法删除");
                return;
            }
            else
            {
                ShowMessage("删除失败");
                return;
            }
        }
        #endregion
    }
}