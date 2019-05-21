/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年05月27日 14时03分11秒
** 描    述:      教材操作类
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Data;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.educational
{
    public partial class TeachMaterialEdit : PageBase
    {
        public TeachMaterialDAL materDAL = new TeachMaterialDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public GradeLevelDAL levelDAL = new GradeLevelDAL();
        public TeachMaterialVersionDAL versionDAL = new TeachMaterialVersionDAL();

        #region 参数集合
        /// <summary>
        /// 教材ID
        /// </summary>
        public int TMID
        {
            get
            {
                return GetQueryString<int>("id", -1);
            }
        }

        /// <summary>
        /// 课程id
        /// </summary>
        public int CID
        {
            get
            {
                return GetQueryString<int>("cid", -1);
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
                this.hf_CID.Value = CID.ToString();
                DDLBind();
                if (TMID != -1)
                {
                    InfoBind();
                }
            }
        }
        #endregion


        #region 绑定下拉框
        /// <summary>
        /// 绑定下拉框
        /// </summary>
        private void DDLBind()
        {
            DataTable dtVersion = versionDAL.GetListAll();
            CommonFunction.DDlTypeBind(this.ddl_TEdition, dtVersion, "TMVID", "VersionName", "-2");

            CommonFunction.BindEnum<CommonEnum.XQ>(this.ddl_TermID, "-2");//学期

            DataTable dt = levelDAL.GetList();
            CommonFunction.DDlTypeBind(this.ddl_GID, dt, "GLID", "ShortName", "-2");
        }
        #endregion


        #region 初始化用户数据
        /// <summary>
        /// 初始化用户数据
        /// </summary>
        private void InfoBind()
        {
            TeachMaterialEntity model = materDAL.GetObjByID(TMID);
            if (model != null)
            {
                this.txt_TMName.Text = model.TMName.ToString();
                this.ddl_GID.SelectedValue = model.GID.ToString();
                this.ddl_TEdition.SelectedValue = model.TEdition.ToString();
                this.ddl_TermID.SelectedValue = model.TermID.ToString();
                this.ddl_TEdition.Enabled = false;
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
                TeachMaterialEntity model = new TeachMaterialEntity();
                model.TMID = TMID;
                model.TMName = this.txt_TMName.Text.ToString().Trim();
                model.TEdition = Convert.ToInt32(this.ddl_TEdition.SelectedValue.ToString());
                model.TMCourses = CID;
                model.GID = Convert.ToInt32(this.ddl_GID.SelectedValue.ToString());
                model.TermID = Convert.ToInt32(this.ddl_TermID.SelectedValue.ToString());
                model.CreateUser = UserID;
                model.Isdel = (int)CommonEnum.Deleted.未删除;

                int result = materDAL.Edit(model);
                if (result > 0)
                {
                    //ShowMessage("提交成功");
                    int log = TMID == -1 ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, (TMID == -1 ? "添加" : "修改") + "教材名称为【" + this.txt_TMName.Text.ToString().Trim() + "】的教材信息", UserID));
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script>alert('系统提示：提交成功！');succ();</script>");
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