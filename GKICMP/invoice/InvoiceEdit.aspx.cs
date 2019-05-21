/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年10月27日 14时44分01秒
** 描    述:      报销编辑页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.IO;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.invoice
{
    public partial class InvoiceEdit : PageBase
    {
        public InvoiceDAL invoiceDAL = new InvoiceDAL();
        public Invoice_InfoDAL infoDAL = new Invoice_InfoDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SysDataDAL sysDataDAL = new SysDataDAL();
        public AccessoryDAL accessoryDAL = new AccessoryDAL();

        #region 参数集合
        /// <summary>
        /// IID
        /// </summary>
        public string IID
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
                DataTable dtModel = sysDataDAL.GetList((int)CommonEnum.Deleted.未删除, (int)CommonEnum.DataType.报销方式);
                //DataTable dtType = sysDataDAL.GetList((int)CommonEnum.Deleted.未删除, (int)CommonEnum.DataType.报销分类);
                //CommonFunction.DDlTypeBind(this.ddl_InvType, dtType, "SDID", "DataName", "-2");//报销分类
                CommonFunction.DDlTypeBind(this.ddl_InvModel, dtModel, "SDID", "DataName", "-2");//报销方式
                this.txt_CreateDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                this.hf_IID.Value = Guid.NewGuid().ToString();
                if (IID != "")
                {
                    InfoBind();
                }
            }
        }
        #endregion


        #region 初始化用户数据
        private void InfoBind()
        {
            InvoiceEntity model = invoiceDAL.GetObjByID(IID);
            if (model != null)
            {
                this.txt_CreateDate.Enabled = false;
                this.txt_AccountUnit.Text = model.AccountUnit.ToString();
                this.txt_CreateDate.Text = model.CreateDate.ToString("yyyy-MM-dd");
                this.txt_AduitUser.Text = model.AduitUser.ToString();
                this.txt_InvoiceDesc.Text = model.InvoiceDesc.ToString();
                this.ddl_InvModel.SelectedValue = model.InvModel.ToString();
                //this.ddl_InvType.SelectedValue = model.InvType.ToString();
                this.rdo_IsSign.SelectedValue = model.IsSign.ToString();
                this.hf_IID.Value = model.IID.ToString();
                DataBindList();
                AccessBind(rp_File, IID, (int)CommonEnum.AccessoryType.报销附件);
            }
        }
        #endregion


        #region 提交事件
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                InvoiceEntity model = new InvoiceEntity();
                int isadd = IID == "" ? 0 : 1;
                model.IID = this.hf_IID.Value; ;
                model.AccountUnit = this.txt_AccountUnit.Text.ToString().Trim();
                model.CreateUser = UserID;
                model.CreateDate = Convert.ToDateTime(this.txt_CreateDate.Text.ToString());
                model.AduitUser = this.txt_AduitUser.Text.ToString().Trim();

                model.InvoiceDesc = this.txt_InvoiceDesc.Text.ToString().Trim();
                model.IsSign = Convert.ToInt32(this.rdo_IsSign.SelectedValue.ToString());
                model.IState = (int)CommonEnum.AduitState.未审核;
                //model.InvType = Convert.ToInt32(this.ddl_InvType.SelectedValue.ToString());
                model.InvModel = Convert.ToInt32(this.ddl_InvModel.SelectedValue.ToString());
                model.Isdel = (int)CommonEnum.Deleted.未删除;

                decimal cash = 0;
                for (int i = 0; i < this.rp_List1.Items.Count; i++)
                {
                    HiddenField hf_Cash = (HiddenField)rp_List1.Items[i].FindControl("hf_Cash");
                    cash += Convert.ToDecimal(hf_Cash.Value.ToString());
                }
                model.TotelCash = cash;
                int upsize = 4000000;
                try
                {
                    upsize = Convert.ToInt32(ConfigurationManager.AppSettings["upsize"].ToString());
                }
                catch (Exception) { }
                AccessoryEntity fileinfo = CommonFunction.upfile(0, Convert.ToInt32(hf_UpFile.Value.Trim()), hf_UpFile);

                if (fileinfo.AccessID == "-2")
                {
                    CommonFunction.delfile(hf_UpFile.Value.ToString());
                    ShowMessage(fileinfo.AccessName);
                    return;
                }
                else
                {
                    fileinfo.AccessFlag = (int)CommonEnum.AccessoryType.报销附件;
                    fileinfo.AccessObjID = model.IID;
                    fileinfo.ObjID = "";
                    model.PicUrl = fileinfo.AccessUrl;
                }

                int result = invoiceDAL.Edit(model, isadd, fileinfo);
                if (result > 0)
                {
                    ShowMessage();
                    int log = (IID == "" ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改);
                    sysLogDAL.Edit(new SysLogEntity(log, (IID == "" ? "添加" : "修改") + "报销单位为【" + this.txt_AccountUnit.Text.ToString() + "】，报销日期为【" + this.txt_CreateDate.Text.ToString() + "】的报销信息", UserID));
                }
                else
                {
                    ShowMessage("提交失败");
                    return;
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                return;
            }
        }
        #endregion


        #region 附件下载、删除
        /// <summary>
        /// 附件下载、删除
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void rpaccess_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string accessid = e.CommandArgument.ToString().Trim();
            AccessoryEntity attainfo = accessoryDAL.GetObjByID(accessid);
            string path = attainfo.AccessUrl;

            if (e.CommandName.ToString() == "del")
            {
                path = HttpContext.Current.Server.MapPath(path);
                int istrue = accessoryDAL.DeleteBat(accessid);
                if (istrue > 0)
                {
                    ShowMessage("删除成功！");
                    //物理路径的文件删除
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }

                    AccessBind(rp_File, IID, (int)CommonEnum.AccessoryType.报销附件);
                }
                else
                {
                    ShowMessage("删除失败！");
                    return;
                }
            }
            else
            {
                if (!CommonFunction.UpLoadFunciotn(attainfo.AccessUrl, attainfo.AccessName))
                {
                    ShowMessage("下载文件不存在，请联系系统管理员！");
                    return;
                }
            }
        }
        #endregion


        #region 删除事件
        public void imbtn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                ImageButton imbtn = (ImageButton)sender;
                string infoid = imbtn.CommandArgument.ToString();
                int result = infoDAL.DeleteBat(infoid, (int)CommonEnum.Deleted.删除);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除报销详细信息", UserID));
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<script>alert('删除成功');</script>");
                }
                else
                {
                    ShowMessage("删除失败");
                    return;
                }
                DataBindList();
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                ShowMessage(ex.Message);
            }
        }
        #endregion


        #region 绑定报销详情数据
        private void DataBindList()
        {
            DataTable dt = infoDAL.GetDataByIID(this.hf_IID.Value);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.tr_null1.Visible = false;
            }
            else
            {
                this.tr_null1.Visible = true;
            }
            rp_List1.DataSource = dt;
            rp_List1.DataBind();
        }
        #endregion


        #region 刷新页面
        protected void imgbtn_inquiry_Click(object sender, EventArgs e)
        {
            DataBindList();
        }
        #endregion


        #region 附件绑定
        /// <summary>
        /// 附件绑定
        /// </summary>
        /// <param name="rpcontr"></param>
        /// <param name="objid"></param>
        /// <param name="flag"></param>
        public void AccessBind(Repeater rpcontr, string objid, int flag)
        {
            DataTable ds = accessoryDAL.GetList(flag, objid);
            rpcontr.DataSource = ds;
            rpcontr.DataBind();
        }
        #endregion
    }
}