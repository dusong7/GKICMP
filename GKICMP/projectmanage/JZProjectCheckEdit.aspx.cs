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
using System;
using System.Configuration;
using System.IO;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;


using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;

namespace GKICMP.projectmanage
{
    public partial class JZProjectCheckEdit : PageBase
    {
        public BuildApplyDAL buildApplyDAL = new BuildApplyDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public JZProjectManageDAL jzprojectManageDAL = new JZProjectManageDAL();
        public Project_CheckDAL project_CheckDAL = new Project_CheckDAL();

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
                //DataTable dtType = jzprojectManageDAL.GetList((int)CommonEnum.Deleted.未删除);//项目名称
                DataTable dtType = jzprojectManageDAL.GetListByIsCheck((int)CommonEnum.Deleted.未删除);//获取验收状态为0的项目名称
                CommonFunction.DDlTypeBind(this.ddl_ProName, dtType, "PID", "ProName", "-2");

                CommonFunction.BindEnum<CommonEnum.ProjectCheck>(this.ddl_Evaluate, "-2");

                if (PCID != "")
                {
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
            Project_CheckEntity model = project_CheckDAL.GetObjByID(PCID);
            if (model != null)
            {
                this.ddl_ProName.SelectedValue = model.PID;
                //this.txt_Evaluate.Text = model.Evaluate.ToString();
                this.ddl_Evaluate.SelectedValue = Convert.ToString(model.Evaluate);
                this.txt_Opinion.Text = model.Opinion.ToString();
                this.txt_PCDate.Text = model.PCDate==null ? "" : model.PCDate.ToString("yyyy-MM-dd");

                this.cb_BrandChecked.Checked = Convert.ToBoolean(model.BrandChecked);
                this.cb_SpecificationChecked.Checked = Convert.ToBoolean(model.SpecificationChecked);
                this.cb_ConfigChecked.Checked = Convert.ToBoolean(model.ConfigChecked);
                this.cb_CountChecked.Checked = Convert.ToBoolean(model.CountChecked);
                this.cb_DebuggingChecked.Checked = Convert.ToBoolean(model.DebuggingChecked);
                this.cb_GuaranteeChecked.Checked = Convert.ToBoolean(model.GuaranteeChecked);
                this.cb_PackingChecked.Checked = Convert.ToBoolean(model.PackingChecked);
                this.cb_ContractChecked.Checked = Convert.ToBoolean(model.ContractChecked);

                this.hf_RFile.Value = model.PCFile;
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
           // return Path.GetFileNameWithoutExtension(obj);
            return Path.GetFileName(obj);
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
                Project_CheckEntity model = new Project_CheckEntity();
                model.PCID = PCID.ToString();
                model.PID = this.ddl_ProName.SelectedValue;//
                //model.Evaluate = Convert.ToInt32(this.txt_Evaluate.Text.Trim());
                model.Evaluate = Convert.ToInt32(this.ddl_Evaluate.SelectedValue);
                model.Opinion = this.txt_Opinion.Text.Trim();

                model.BrandChecked =Convert.ToInt32(this.cb_BrandChecked.Checked) ;
                model.SpecificationChecked = Convert.ToInt32(this.cb_SpecificationChecked.Checked);
                model.ConfigChecked = Convert.ToInt32(this.cb_ConfigChecked.Checked);
                model.CountChecked = Convert.ToInt32(this.cb_CountChecked.Checked);
                model.DebuggingChecked = Convert.ToInt32(this.cb_DebuggingChecked.Checked);
                model.GuaranteeChecked = Convert.ToInt32(this.cb_GuaranteeChecked.Checked);
                model.PackingChecked = Convert.ToInt32(this.cb_PackingChecked.Checked);
                model.ContractChecked = Convert.ToInt32(this.cb_ContractChecked.Checked);

                model.PCDate = Convert.ToDateTime(this.txt_PCDate.Text.ToString());
                model.CreateUser = UserID;
                model.IsReport = (int)CommonEnum.IsorNot.否;//是否上报

                //附件上传
                int upsize = 4000000;
                try
                {
                    upsize = Convert.ToInt32(ConfigurationManager.AppSettings["upsize"].ToString());
                }
                catch (Exception) { }
                AccessoryEntity accessinfo = CommonFunction.upfile(0, 1, hf_file, "file");
                if (accessinfo.AccessID == "-2")
                {
                    //刚才上传的文件删除
                    CommonFunction.delfile(hf_file.Value.ToString());
                    ShowMessage(accessinfo.AccessName);
                    return;
                }
                else
                {
                    //if (this.fl_UpFile.HasFile)
                    //{
                    //    model.PCFile = accessinfo.AccessName;
                    //}
                    //else
                    //{
                    //    model.PCFile = this.hf_RFile.Value;
                      
                    //}
                    accessinfo.AccessFlag = (int)CommonEnum.AccessoryType.Tb_Contract;
                    accessinfo.AccessObjID = model.PCID;
                    accessinfo.ObjID = "";
                }
                model.PCFile =  accessinfo.AccessUrl;
               // model.PCFile = accessinfo.AccessName ;
                int result = project_CheckDAL.Edit(model);
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



    }
}