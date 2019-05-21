/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      lfz
** 创建日期:     2017年03月03日
** 描 述:       基础数据编辑页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;

namespace GKICMP.sysmanage
{
    public partial class SysDataEdit : PageBase
    {
        #region 参数集合
        /// <summary>
        /// SDID 基础数据主键
        /// </summary>
        public int SDID
        {
            get
            {
                return GetQueryString<int>("id", -1);
            }
        }
        #endregion
        public SysDataDAL SysDataDAL = new SysDataDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();

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
                CommonFunction.BindEnum<CommonEnum.DataType>(this.ddl_Type, "-2");
                if (SDID != -1)
                {
                    InfoBind();
                }
            }
        }
        #endregion


        #region 初始化数据
        /// <summary>
        /// 初始化数据
        /// </summary>
        protected void InfoBind()
        {
            SysDataEntity model = SysDataDAL.GetObjByID(SDID);
            if (model != null)
            {
                this.ddl_Type.SelectedValue = model.DataType.ToString();
                this.txt_DataName.Text = model.DataName.Trim();
                this.txt_Desc.Text = model.DataDesc;
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
                SysDataEntity model = new SysDataEntity(this.txt_DataName.Text.Trim(), (int)CommonEnum.Deleted.未删除);
                model.SDID = SDID;
                model.DataType = int.Parse(this.ddl_Type.SelectedValue);
                model.DataDesc = this.txt_Desc.Text.Trim();
                model.IsSysSet = 0;
                int result = SysDataDAL.Edit(model);
                if (result == -1)
                {
                    ShowMessage("提交失败");
                    return;
                }
                else if (result == -2)
                {
                    ShowMessage("该角色名称已存在，请重新输入");
                    return;
                }
                else
                {
                    int log = SDID == -1 ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, (SDID == -1 ? "添加" : "修改") + "数据名称为【" + this.txt_DataName.Text + "】信息", UserID));
                    ShowMessage();
                }
            }
            catch (Exception error)
            {
                ShowMessage(error.Message);
                return;
            }

        }
        #endregion
    }
}