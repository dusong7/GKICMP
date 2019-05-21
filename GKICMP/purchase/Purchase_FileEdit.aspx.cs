using System;
using System.Configuration;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;


using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;

namespace GKICMP.purchase
{
    public partial class Purchase_FileEdit : PageBase
    {
        public Project_FileDAL project_FileDAL = new Project_FileDAL();
        public SysDataDAL SysDataDAL = new SysDataDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public PurchaseDAL purchaseDAL = new PurchaseDAL();

        #region 参数集合
        /// <summary>
        /// TCID 合同ID
        /// </summary>
        public string PID
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
                DataTable dtType = purchaseDAL.GetListByIsCheck((int)CommonEnum.Deleted.未删除);//获取验收状态为0的项目名称
                CommonFunction.DDlTypeBind(this.ddl_ProName, dtType, "PID", "PTitle", "-2");

                DataTable PType = purchaseDAL.GetPType(PID);
                CommonFunction.DDlTypeBind(this.ddl_ProStage, PType, "ID", "Name", "-2");

                if (PID != "")
                {
                    this.ddl_ProName.SelectedValue = PID;
                    this.ddl_ProName.Enabled = false;
                    InfoBind(0);
                }
            }
        }
        #endregion

        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void InfoBind(int i)
        {
            Project_FileEntity model = project_FileDAL.GetObjByID(PID);
            if (model != null)
            {
                this.ddl_ProStage.SelectedValue = model.ProStage.ToString();
            }
        }
        #endregion

        #region 提交事件
        /// <summary>
        /// 提交事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                Project_FileEntity model = new Project_FileEntity();
                // model.PFID = PFID.ToString();
                model.PFID = "";
                model.PID = this.ddl_ProName.SelectedValue.ToString();
                model.ProStage = Convert.ToInt32(this.ddl_ProStage.SelectedValue.ToString());
                model.CreateUser = UserID;
                model.IsReport = (int)CommonEnum.IsorNot.否;//是否上报

                //附件上传
                int upsize = 4000000;
                try
                {
                    upsize = Convert.ToInt32(ConfigurationManager.AppSettings["upsize"].ToString());
                }
                catch (Exception) { }
                AccessoryEntity accessinfo = CommonFunction.upfile(0, Convert.ToInt32(hf_UpFile.Value.Trim()), hf_UpFile, "profile");
                if (accessinfo.AccessID == "-2")
                {
                    //刚才上传的文件删除
                    CommonFunction.delfile(hf_UpFile.Value.ToString());
                    ShowMessage(accessinfo.AccessName);
                    return;
                }
                else
                {
                    accessinfo.AccessFlag = (int)CommonEnum.AccessoryType.Tb_Project;
                    accessinfo.AccessObjID = model.PFID;
                    accessinfo.ObjID = "";
                }
                model.FileName = accessinfo.AccessName; //this.hf_Images.Value
                model.FileUrl = accessinfo.AccessUrl;

                int result = project_FileDAL.Edit(model);
                if (result > 0)
                {
                    ShowMessage();
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "", UserID));
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
                return;
            }
        }
        #endregion

        #region 附件下载、删除
        protected void rpaccess_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string path = e.CommandArgument.ToString().Trim();
            if (e.CommandName.ToString() == "del")
            {
                string path1 = HttpContext.Current.Server.MapPath(path);
                this.hf_Images.Value = this.hf_Images.Value.Replace(path, "").Trim(',');
                if (System.IO.File.Exists(path1))
                {
                    System.IO.File.Delete(path1);
                }
                else
                {
                    ShowMessage("删除失败");
                }
                InfoBind(1);
            }

        }
        #endregion

        #region 通过采购名称选取要提交的文件类型
        protected void ddl_ProName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectvalue = this.ddl_ProName.SelectedValue;
            DataTable PType = purchaseDAL.GetPType(selectvalue);
            CommonFunction.DDlTypeBind(this.ddl_ProStage, PType, "ID", "Name", "-2");
        }
        #endregion
    }
}