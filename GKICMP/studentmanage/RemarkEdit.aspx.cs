/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      gxl
** 创建日期:    2017年03月02日
** 描 述:       评语库编辑页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;
using System.Web.UI.WebControls;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Configuration;
namespace GKICMP.studentmanage
{
    public partial class RemarkEdit : PageBase
    {
        public SysRoleDAL sysRoleDAL = new SysRoleDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public RemarkDAL RemarkDAL = new RemarkDAL();
       
        #region 参数集合
        public int RID
        {
            get
            {
                return GetQueryString<int>("id", -1);
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
                if (RID != -1)
                {
                    InfoBind();
                }
            }
        }
        #endregion


        #region 提交
        /// <summary>
        ///   提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>  
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {

                RemarkEntity model = new RemarkEntity();
                model.RID = Convert.ToInt32(RID);
                model.RemarkContent = this.txt_RemarkContent.Text.Trim();//
                model.CreateUser = UserID;
                model.Isdel = (int)CommonEnum.Deleted.未删除;

                int result = RemarkDAL.Add(model);
                if (result == 0)
               {
                   ShowMessage("提交失败");
                   return;
               }
               else
               {
                   if (RID == -1)
                       sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, "添加评语信息", UserID));
                   else
                       sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_修改, "修改评语信息", UserID));
                   ShowMessage();
               }
           }
           catch (Exception error)
           {
               ShowMessage(error.Message);
           }
        }
        #endregion


        #region 初始化用户数据
        private void InfoBind()
        {
            RemarkEntity model = new RemarkEntity();
            model = RemarkDAL.GetObjByID(RID);
            if (model != null)
            {
                this.txt_RemarkContent.Text = model.RemarkContent;//
            }
        }
        #endregion

    }
}