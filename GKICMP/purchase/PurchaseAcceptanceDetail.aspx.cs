/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2016年10月15日 13时56分24秒
** 描    述:      项目验收详细页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
******************************************************************/
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GKICMP.purchase
{
    public partial class PurchaseAcceptanceDetail : PageBase
    {
        //public BuildApplyDAL buildApplyDAL = new BuildApplyDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        //public JZProjectManageDAL jzprojectManageDAL = new JZProjectManageDAL();
        public Project_CheckDAL project_CheckDAL = new Project_CheckDAL();
        public string File = "";

        #region 参数集合
        /// <summary>
        /// 参数集合
        /// </summary>
        public string PCID
        {
            get
            {
                return GetQueryString<string>("id", "");
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
                if (PCID != "")
                {
                    InfoBind();
                }
            }
        }
        #endregion


        #region 初始化用户数据
        /// <summary>
        /// 初始化用户数据
        /// </summary>
        private void InfoBind()
        {

            Project_CheckEntity model = project_CheckDAL.GetObjByID(PCID,2);
            if (model != null)
            {
                this.ltl_PName.Text = model.PName.ToString();
                //this.ltl_Evaluate.Text = model.Evaluate.ToString() + "年";
                this.ltl_Evaluate.Text = CommonFunction.CheckEnum<CommonEnum.ProjectCheck>(model.Evaluate.ToString());
                this.ltl_PCDate.Text = model.PCDate.ToString() == "0001/1/1 0:00:00" ? "" : model.PCDate.ToString("yyyy-MM-dd");
                this.ltl_Opinion.Text = model.Opinion.ToString();

                //  this.ltl_BrandChecked.Text = model.BrandChecked == 0 ? "否" : "是";

                if (model.BrandChecked != 0)
                    this.cb_BrandChecked.Checked = true;
                this.cb_BrandChecked.Enabled = false;
                if (model.SpecificationChecked != 0)
                    this.cb_SpecificationChecked.Checked = true;
                this.cb_SpecificationChecked.Enabled = false;
                if (model.DebuggingChecked != 0)
                    this.cb_DebuggingChecked.Checked = true;
                this.cb_DebuggingChecked.Enabled = false;
                if (model.CountChecked != 0)
                    this.cb_CountChecked.Checked = true;
                this.cb_CountChecked.Enabled = false;
                if (model.ConfigChecked != 0)
                    this.cb_ConfigChecked.Checked = true;
                this.cb_ConfigChecked.Enabled = false;
                if (model.GuaranteeChecked != 0)
                    this.cb_GuaranteeChecked.Checked = true;
                this.cb_GuaranteeChecked.Enabled = false;
                if (model.PackingChecked != 0)
                    this.cb_PackingChecked.Checked = true;
                this.cb_PackingChecked.Enabled = false;
                if (model.ContractChecked != 0)
                    this.cb_ContractChecked.Checked = true;
                this.cb_ContractChecked.Enabled = false;

                //this.ltl_SpecificationChecked.Text = model.SpecificationChecked == 0 ? "否" : "是";
                //this.ltl_DebuggingChecked.Text = model.DebuggingChecked == 0 ? "否" : "是";
                //this.ltl_CountChecked.Text = model.CountChecked == 0 ? "否" : "是";
                //this.ltl_ConfigChecked.Text = model.ConfigChecked == 0 ? "否" : "是";
                //this.ltl_GuaranteeChecked.Text = model.GuaranteeChecked == 0 ? "否" : "是";
                //this.ltl_PackingChecked.Text = model.PackingChecked == 0 ? "否" : "是";
                //this.ltl_ContractChecked.Text = model.ContractChecked == 0 ? "否" : "是";
                // File=this.ltl_PCFile.Text = model.PCFile.ToString();
                AccessBind();

            }
        }
        #endregion

        #region 附件下载、删除
        protected void rpaccess_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string accessid = e.CommandArgument.ToString().Trim();
            string name = Path.GetFileNameWithoutExtension(accessid);

            if (!CommonFunction.UpLoadFunciotn(accessid, name))
            {
                ShowMessage("下载文件不存在，请联系系统管理员");
                return;
            }

        }
        #endregion


        #region 附件绑定
        /// <summary>
        /// 附件绑定
        /// </summary>
        /// <param name="rpcontr"></param>
        /// <param name="objid"></param>
        /// <param name="flag"></param>
        public void AccessBind()
        {
            DataTable ds = project_CheckDAL.GetTable(PCID);
            rp_File.DataSource = ds;
            rp_File.DataBind();
        }
        #endregion

        #region 获取文件后缀名
        /// <summary>
        /// 获取文件后缀名
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string getFileName(string obj)
        {
            //return Path.GetFileNameWithoutExtension(obj);
            return Path.GetFileName(obj);
        }
        #endregion
    }
}