/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      gxl
** 创建日期:    2016年11月07日
** 描 述:       角色编辑页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.IO;
using System.Data;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using System.Configuration;


namespace GKICMP.assetmanage
{
    public partial class Project_FileDelete : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public Project_FileDAL project_FileDAL = new Project_FileDAL();
        //public 

        #region 参数集合
        /// <summary>
        /// ID
        /// </summary>
        public string AID
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
                DataTable proname = new JZProjectManageDAL().GetProList();
                CommonFunction.DDlTypeBind(this.ddl_ProName, proname, "PID", "ProName", "-2"); //项目绑定
                CommonFunction.BindEnum<CommonEnum.ProjectFile>(this.ddl_ProStage, "-2");

                if (!string.IsNullOrEmpty(AID))
                {
                    this.ddl_ProName.SelectedValue = AID;
                    this.ddl_ProName.Enabled = false;
                }

            }
        }
        #endregion


        #region 提交
        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                int result = project_FileDAL.DeleteBat(this.ddl_ProName.SelectedValue, int.Parse(this.ddl_ProStage.SelectedValue));
                if (result > 0)
                {
                    ShowMessage();
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除文件信息", UserID));
                }
                else if (result == 0) { ShowMessage("所选择的类型没有上传文件"); return; }
                else { ShowMessage("提交失败，请稍后再试"); return; }
            }
            catch (Exception error)
            {
                ShowMessage(error.Message);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, error.Message, UserID));
            }
        }
        #endregion
    }
}