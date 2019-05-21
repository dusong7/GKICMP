/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2016年10月15日 13时56分24秒
** 描    述:      教师学习培训管理
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
******************************************************************/
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace GKICMP.teachermanage
{
    public partial class TeacherChangesDetail : PageBase
    {
        public Teacher_TrainDAL teacher_TrainDAL = new Teacher_TrainDAL();
        public SysDataDAL SysDataDAL = new SysDataDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public TeacherDAL teacherDAL = new TeacherDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public BaseDataDAL baseDataDAL = new BaseDataDAL();

        public Teacher_ChangesDAL teacher_ChangesDAL = new Teacher_ChangesDAL();

        #region 参数集合
        /// <summary>
        /// 参数集合
        /// </summary>
        public string TCID
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
                if (TCID != "")
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

            Teacher_ChangesEntity model = teacher_ChangesDAL.GetObjByID(TCID);
            if (model != null)
            {
                this.ltl_TeacherName.Text = model.TName.ToString();
                this.ltl_CDate.Text = model.CDate == null ? "" :  Convert.ToDateTime(model.CDate).ToString("yyyy-MM-dd");
                this.ltl_ChangeReason.Text = model.ChangeReason.ToString();
                this.ltl_CType.Text = CommonFunction.CheckEnum<CommonEnum.TeacherState>(model.CType.ToString());

                AccessBind();
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
            DataTable ds = teacher_ChangesDAL.GetTable(TCID);
            rp_File.DataSource = ds;
            rp_File.DataBind();
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

        #region 获取文件后缀名
        /// <summary>
        /// 获取文件后缀名
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string getFileName(string obj)
        {
            return Path.GetFileName(obj);
        }
        #endregion


    }
}