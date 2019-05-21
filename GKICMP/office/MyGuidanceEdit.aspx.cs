/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      lfz
** 创建日期:      2016年10月15日 13时56分24秒
** 描    述:      教师合同管理界面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Configuration;
using System.Web;
using System.IO;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;


using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;

namespace GKICMP.office
{
    public partial class MyGuidanceEdit : PageBase
    {
        public Teacher_ContractDAL contractDal = new Teacher_ContractDAL();
        public SysDataDAL SysDataDAL = new SysDataDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public TeacherDAL teacherDAL = new TeacherDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public BaseDataDAL baseDataDAL = new BaseDataDAL();
        public Teacher_GuidanceDAL teacher_GuidanceDAL = new Teacher_GuidanceDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();


        #region 参数集合
        /// <summary>
        /// TPID
        /// </summary>
        public string TGID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        #endregion

        protected int v = 0;

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
                CommonFunction.BindEnum<CommonEnum.URole>(this.ddl_GRoles, "-2");
                // BandDepart(); //绑定教师
                if (TGID != "")
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
            Teacher_GuidanceEntity model = teacher_GuidanceDAL.GetObjByID(TGID);
            if (model != null)
            {
                this.txt_RewardName.Text = model.RewardName.ToString();
                this.txt_Lunit.Text = model.Lunit.ToString();
                this.txt_PubDate.Text = model.PubDate.ToString("yyyy-MM-dd");
                this.ddl_GRoles.SelectedValue = model.GRole.ToString();
                this.txt_RGrade.Text = model.RGrade.ToString();
                this.txt_GuiDesc.Text = model.GuiDesc;
                this.hf_UpFile.Value = model.RFile;
                AccessBind();

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
                Teacher_GuidanceEntity model = new Teacher_GuidanceEntity();
                    model.TGID = TGID;
                    model.TID = UserID;
                    model.RewardName = this.txt_RewardName.Text;
                    model.Lunit = this.txt_Lunit.Text;
                    model.PubDate = Convert.ToDateTime(this.txt_PubDate.Text);
                    model.GRole = int.Parse(this.ddl_GRoles.SelectedValue);
                    model.RGrade = this.txt_RGrade.Text;
                    model.GuiDesc = this.txt_GuiDesc.Text;
                    model.RFile = this.hf_UpFile.Value;
                    model.Isdel = (int)CommonEnum.IsorNot.否;
                    //附件上传
                    int upsize = 4000000;
                    try
                    {
                        upsize = Convert.ToInt32(ConfigurationManager.AppSettings["upsize"].ToString());
                    }
                    catch (Exception) { }
                    AccessoryEntity accessinfo = CommonFunction.upfile(0, 1, hf_UpFile, "ImageUrl");
                    if (accessinfo.AccessID == "-2")
                    {
                        //刚才上传的文件删除
                        CommonFunction.delfile(hf_UpFile.Value.ToString());
                        ShowMessage(accessinfo.AccessName);
                        return;
                    }
                    else
                    {
                        if (this.fl_UpFile.HasFile)
                            model.RFile = accessinfo.AccessUrl;
                        else
                            model.RFile = this.hf_UpFile.Value;
                    }
                    int result = teacher_GuidanceDAL.Edit(model);
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
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                ShowMessage(ex.Message);
                return;
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
            DataTable ds = teacher_GuidanceDAL.GetTable(TGID);
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
            return Path.GetFileNameWithoutExtension(obj);
        }
        #endregion
    }
}