/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      gxl
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
    public partial class MyRewardEdit : PageBase
    {
        public Teacher_ContractDAL contractDal = new Teacher_ContractDAL();
        public SysDataDAL SysDataDAL = new SysDataDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public TeacherDAL teacherDAL = new TeacherDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public BaseDataDAL baseDataDAL = new BaseDataDAL();
        public Teacher_RewardDAL teacher_RewardDAL = new Teacher_RewardDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();

        #region 参数集合
        /// <summary>
        /// TPID
        /// </summary>
        public string TPID
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
                CommonFunction.BindEnum<CommonEnum.RewardType>(this.ddl_RewardType, "-2");//获奖类别
                CommonFunction.BindEnum<CommonEnum.RGrade>(this.ddl_RGrade, "-2");//奖励级别
                CommonFunction.BindEnum<CommonEnum.Ranking>(this.ddl_Ranking, "-2");
                //BandDepart(); //绑定教师
                // BandData();

                if (TPID != "")
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
            Teacher_RewardEntity model = teacher_RewardDAL.GetObjByID(TPID);
            if (model != null)
            {
                this.txt_RewardName.Text = model.RewardName.ToString();
                this.txt_Lunit.Text = model.Lunit.ToString();
                this.txt_PubDate.Text = model.PubDate.ToString("yyyy-MM-dd");
                this.ddl_RewardType.SelectedValue = model.RewardType.ToString();
                this.ddl_RGrade.SelectedValue = model.RGrade.ToString();
                this.ddl_Ranking.SelectedValue = model.Ranking.ToString();
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
                Teacher_RewardEntity model = new Teacher_RewardEntity();
                    model.TPID = TPID.ToString();
                    model.TID = UserID;
                    model.RewardType = Convert.ToInt32(this.ddl_RewardType.SelectedValue.ToString());
                    model.RGrade = this.ddl_RGrade.SelectedValue.ToString();
                    model.Ranking = Convert.ToInt32(this.ddl_Ranking.SelectedValue.ToString());
                    model.RewardName = this.txt_RewardName.Text.ToString();
                    model.Lunit = this.txt_Lunit.Text.ToString();
                    model.PubDate = Convert.ToDateTime(this.txt_PubDate.Text.ToString());


                    model.Isdel = (int)CommonEnum.Deleted.未删除;
                    model.IsReport = (int)CommonEnum.IsorNot.否;//是否上报

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
                    int result = teacher_RewardDAL.Edit(model);
                    if (result == 0)
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





        #region 附件绑定
        /// <summary>
        /// 附件绑定
        /// </summary>
        /// <param name="rpcontr"></param>
        /// <param name="objid"></param>
        /// <param name="flag"></param>
        public void AccessBind()
        {
            DataTable ds = teacher_RewardDAL.GetTable(TPID);
            rp_File.DataSource = ds;
            rp_File.DataBind();
        }
        #endregion

        #region 获取文件后缀名(文件名称)
        /// <summary>
        /// 获取文件后缀名(文件名称)
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