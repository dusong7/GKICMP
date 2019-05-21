/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      201611月10日 10时55分47秒
** 描    述:     报修管理详细页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
******************************************************************/
using System;

using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using GK.GKICMP.Common;
using System.Data;
using System.Web.UI.WebControls;
using System.IO;

namespace GKICMP.app
{
    public partial class RepairDetail : PageBaseApp
    {
        public Asset_RepairDAL repairDAL = new Asset_RepairDAL();


        #region 参数集合
        public string ARID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        #endregion


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindInfo();
            }
        }
        #endregion


        #region 初始会用户数据
        public void BindInfo()
        {
            Asset_RepairEntity model = repairDAL.GetObjByID(ARID);
            if (model != null)
            {
                this.lbl_ARDate.Text = model.ARDate.ToString("yyyy-MM-dd");
                this.lbl_ARState.Text = CommonFunction.CheckEnum<CommonEnum.ARState>(model.ARState);
                this.lbl_CompDate.Text = model.CompDate.ToString("yyyy-MM-dd") == "0001-01-01" ? "" : model.CompDate.ToString("yyyy-MM-dd");
                this.lbl_CompDesc.Text = model.CompDesc == null ? "" : model.CompDesc;
                //this.lbl_DutyDep.Text = model.DutyDepName;
                this.lbl_DutyDept.Text = model.DutyDepName;
                this.lbl_DutyUser.Text = model.DutyUserName;
                this.lbl_RepairContent.Text = model.RepairContent;
                this.lbl_RepairObj.Text = model.RepairObj;
                this.lbl_TransferDesc.Text = model.TransferDesc;
                this.lbl_TransferName.Text = model.TransferName;
                this.lbl_CreaterUser.Text = model.CreaterUserName;
                if (!string.IsNullOrEmpty(model.SDID) && model.SDID != "-2")
                {
                    SupplierEntity sup = new SupplierDAL().GetObjByID(model.SDID);
                    this.lbl_Sdid.Text = sup.SupplierName;
                    this.lbl_LinkUser.Text = sup.LinkUser;
                    this.lbl_LinkNo.Text = sup.LinkPhone;
                }
                if (model.ARFile != "")
                {
                    this.Image1.Visible = true;
                    this.Image1.ImageUrl = model.ARFile;

                    this.hf_Images.Value = model.ARFile;
                }
                //DataTable dt = new DataTable();
                //dt.Columns.Add("ARID", typeof(string));
                //dt.Columns.Add("ARFile", typeof(string));
                //dt.Rows.Add(model.ARID, model.ARFile);
                //rp_File.DataSource = dt;
                //rp_File.DataBind();

            }
        }
        #endregion

        #region 获取附件名称
        /// <summary>
        /// 获取附件名称
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string getFileName(string obj)
        {
            return Path.GetFileNameWithoutExtension(obj);
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
    }
}