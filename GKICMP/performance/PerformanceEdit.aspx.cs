/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年09月04日 17时04分21秒
** 描    述:      考核操作类
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.performance
{
    public partial class PerformanceEdit : PageBase
    {
        public PerformanceDAL perDAL = new PerformanceDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();

        #region 参数集合
        /// <summary>
        /// 考核ID
        /// </summary>
        public int PFID
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
                CommonFunction.BindEnum<CommonEnum.State>(this.rdo_IsUse);
                this.rdo_IsUse.SelectedIndex = 0;

                if (PFID != -1)
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
            PerformanceEntity model = perDAL.GetObjByID(PFID);
            this.txt_PerName.Text = model.PerName.ToString();
            this.rdo_IsUse.SelectedValue = model.IsUse.ToString();
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
                PerformanceEntity model = new PerformanceEntity();
                model.PFID = PFID;
                model.PerName = this.txt_PerName.Text.ToString();
                model.IsUse = Convert.ToInt32(this.rdo_IsUse.SelectedValue.ToString());
                model.Isdel = (int)CommonEnum.Deleted.未删除;
                model.CreateUser = UserID;
                if (Convert.ToInt32(rdo_IsUse.SelectedValue.ToString()) == (int)CommonEnum.State.禁用)
                {
                    model.StopDate = DateTime.Now;
                }
                else
                {
                    model.StopDate = Convert.ToDateTime("9999-12-31");
                }

                int result = perDAL.Edit(model);
                if (result == 0)
                {
                    ShowMessage();
                    int log = PFID == -1 ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, (PFID == -1 ? "添加" : "修改") + "名称为：【" + this.txt_PerName.Text + "】的考核信息", UserID));
                }
                else if (result == -2)
                {
                    ShowMessage("此考核名称已存在，请修改后重新导入");
                    return;
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