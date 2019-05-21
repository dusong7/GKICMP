/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      czz
** 创建日期:    2017年02月28日
** 描 述:       模板编辑页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Configuration;
using System.Text;
using System.Data;
namespace GKICMP.sysmanage
{
    public partial class SystTempEdit : PageBase
    {
        public SystTempDAL systTempDAL = new SystTempDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();

        #region 参数集合
        public int STID
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
                if (STID != -1)
                {
                    InfoBind();
                 
                }
            }
        }
        #endregion

        #region 初始化用户数据
        private void InfoBind()
        {
            SystTempEntity model = new SystTempEntity();
            model = systTempDAL.GetObjByID(STID);
            if (model != null)
            {
                this.txt_TempContent.Text = model.TempContent.ToString();//年级名称
                
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
                SystTempEntity model = new SystTempEntity();
                model.STID = STID;
                model.TempContent = this.txt_TempContent.Text.Trim();

                int result = systTempDAL.Edit(model);
                if (result == 0)
                {
                    SysLogEntity log = new SysLogEntity((int)CommonEnum.LogType.操作日志_修改, "修改模板信息", UserID);
                    sysLogDAL.Edit(log);
                    ShowMessage();
                   
                }
                else
                {
                    ShowMessage("提交失败");
                    return; 
                }
            }
            catch (Exception error)
            {
                ShowMessage(error.Message);
            }
        }
        #endregion


        

    }
}