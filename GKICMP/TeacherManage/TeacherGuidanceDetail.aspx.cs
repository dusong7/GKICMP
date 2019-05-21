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

namespace GKICMP.teachermanage
{
    public partial class TeacherGuidanceDetail : PageBase
    {
        public Teacher_ContractDAL contractDal = new Teacher_ContractDAL();
        public SysDataDAL SysDataDAL = new SysDataDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public TeacherDAL teacherDAL = new TeacherDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public BaseDataDAL baseDataDAL = new BaseDataDAL();
        public Teacher_GuidanceDAL teacher_GuidanceDAL = new Teacher_GuidanceDAL();

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
                this.TeacherName.Text = model.TeacherName;
                this.txt_RewardName.Text = model.RewardName.ToString();
                this.txt_Lunit.Text = model.Lunit.ToString();
                this.txt_PubDate.Text = model.PubDate.ToString("yyyy-MM-dd");
                this.ddl_GRoles.Text =CommonFunction.CheckEnum<CommonEnum.URole>( model.GRole);
                this.txt_RGrade.Text = model.RGrade.ToString();
                this.txt_GuiDesc.Text = model.GuiDesc;
                this.Image2.ImageUrl = model.RFile;
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