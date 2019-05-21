/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2017年06月12日 09点30分
** 描   述:       报修页面
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Text;
using System.Web.UI.WebControls;
namespace GKICMP.office
{
    public partial class RepairEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public Asset_RepairDAL repairDAL = new Asset_RepairDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public TeacherDAL teacherDAL = new TeacherDAL();
        public SysUser_TypeDAL sysUser_TypeDAL = new SysUser_TypeDAL();
        public SupplierDAL supplierDAL = new SupplierDAL();
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
                //DataTable dt = sysUser_TypeDAL.GetList((int)CommonEnum.HumanType.资产报修人);
                //CommonFunction.DDlTypeBind(this.ddl_DutyUser, dt, "UID", "RealName", "-2");
                DataTable dts = supplierDAL.GetList((int)CommonEnum.IsorNot.否, "");
                CommonFunction.DDlTypeBind(this.ddl_D, dts, "SDID", "SupplierName", "-2");
                DdlBind();
                if (ARID != "")
                {
                    BindInfo();
                }
            }
        }
        #endregion


        //#region 受理人绑定
        //public void DdlBind()
        //{
        //    DataTable dt = repairDAL.GetSysUserType(Convert.ToInt32(CommonEnum.UserClass.维修人员));
        //    CommonFunction.DDlTypeBind(this.ddl_DutyUser, dt, "UID", "RealName", "-2");
        //}
        //#endregion

        //#region 部门绑定
        //protected void ddl_DutyUser_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    DepartmentEntity model = departmentDAL.GetSysDep(this.ddl_DutyUser.SelectedValue);
        //    if (model != null)
        //    {
        //        this.txt_DutyDep.Text = model.DepName;
        //        this.hf_DutyDep.Value = model.DID.ToString();
        //    }
        //}
        //#endregion


        #region 受理部门绑定
        public void DdlBind()
        {
            DataTable dt = departmentDAL.GetZNBM((int)CommonEnum.DepType.职能部门, (int)CommonEnum.IsorNot.否);
            CommonFunction.DDlTypeBind(this.ddl_DutyDep, dt, "DID", "DepName", "-2");
           
        }
        #endregion

        #region 受理人绑定
        protected void ddl_DutyDep_SelectedIndexChanged(object sender, EventArgs e)
        {
            DutyUser();
        }

        private void DutyUser()
        {
            DataTable dt = teacherDAL.GetByAssetUser(int.Parse(this.ddl_DutyDep.SelectedValue), (int)CommonEnum.HumanType.报修受理人, (int)CommonEnum.IsorNot.否);
            CommonFunction.DDlTypeBind(this.ddl_DutyUser, dt, "UID", "RealName", "-2");
        }
        #endregion


        #region 初始化用户数据
        public void BindInfo()
        {
            Asset_RepairEntity model = repairDAL.GetObjByID(ARID);
            if (model != null)
            {
                //this.ddl_DutyUser.Enabled = false;
                //this.ddl_DutyUser.SelectedValue = model.DutyUser;
                this.txt_RepairContent.Text = model.RepairContent;
                this.txt_RepairObj.Text = model.RepairObj;
                //this.txt_DutyDep.Text = model.DutyDepName;
                //this.hf_DutyDep.Value = model.DutyDep.ToString();

                this.ddl_DutyDep.SelectedValue = Convert.ToString(model.DutyDep);//受理部门
                DutyUser();
                //DataTable dt = teacherDAL.GetByDepID(model.DutyDep, (int)CommonEnum.UserType.老师, (int)CommonEnum.IsorNot.否);
                //CommonFunction.DDlTypeBind(this.ddl_DutyUser, dt, "UID", "RealName", "-2");
                this.ddl_DutyUser.SelectedValue = model.DutyUser.ToString(); ;//受理人
                this.ddl_D.SelectedValue = model.SDID;
                if (model.ARFile != "")
                {
                    this.Image1.Visible = true;
                    this.Image1.ImageUrl = model.ARFile;
                }
                //DataTable dt = teacherDAL.GetByUID(model.DutyUser, (int)CommonEnum.UserType.老师, (int)CommonEnum.IsorNot.否);
                //CommonFunction.DDlTypeBind(this.ddl_DutyUser, dt, "UID", "RealName", "-2");
                //DataTable dt = new DataTable();
                //dt.Columns.Add("ARID", typeof(string));
                //dt.Columns.Add("ARFile", typeof(string));
                //dt.Rows.Add(model.ARID,model.ARFile);
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

       
        #region 提交
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                Asset_RepairEntity model = new Asset_RepairEntity();
                model.ARID = ARID;
                model.RepairObj = this.txt_RepairObj.Text.Trim();
                model.CreaterUser = UserID;
                //model.DutyDep = Convert.ToInt32(this.hf_DutyDep.Value);
                model.DutyDep = Convert.ToInt32(this.ddl_DutyDep.SelectedValue);
                
                model.DutyUser = this.ddl_DutyUser.SelectedValue;
                model.RepairContent = this.txt_RepairContent.Text.Trim();
                model.ARState = Convert.ToInt32(CommonEnum.ARState.未受理);
                model.Isdel = Convert.ToInt32(CommonEnum.Deleted.未删除);
                model.SDID = this.ddl_D.SelectedValue;
                int upsize = 4000000;
                try
                {
                    upsize = Convert.ToInt32(ConfigurationManager.AppSettings["upsize"].ToString());
                }
                catch (Exception) { }
                AccessoryEntity accessinfo = CommonFunction.upfile(0, 1, hf_file, "ImageUrl");
                if (accessinfo.AccessID == "-2")
                {
                    //刚才上传的文件删除
                    CommonFunction.delfile(hf_file.Value.ToString());
                    ShowMessage(accessinfo.AccessName);
                    return;
                }
                else
                {
                    if (this.fl_UpFile.HasFile)
                        model.ARFile = accessinfo.AccessUrl;
                    else
                        model.ARFile = this.hf_Url.Value;
                }


                int result = repairDAL.Edit(model);
                if (result == 0)
                {
                    string msg = "";
                    int log = ARID == "" ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, (ARID == "" ? "添加" : "修改") + "报修对象为：" + this.txt_RepairObj.Text + "的数据", UserID));
                    string a = XMLHelper.GetXmlNodesAttributes("~/BaseInfoSet.xml", "DX", "IsOpen");
                    if (a == "1")
                    {
                        if (this.ddl_D.SelectedValue != "-2")
                        {
                            //SupplierEntity sub = supplierDAL.GetObjByID(this.ddl_D.SelectedValue);
                            //if (!string.IsNullOrEmpty(sub.LinkPhone))
                            //{
                            //    msg = ALiDaYu.SendMessage("", sub.LinkPhone);
                            //}
                            Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('提交成功！" + msg + "');winclose();", true);
                        }
                        else { ShowMessage(); }
                    }
                    else
                    { ShowMessage(); }
                    
                }
                else
                {
                    ShowMessage("保存失败");
                    return;
                }
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                ShowMessage(ex.Message);
            }
        }
        #endregion

        

    }
}