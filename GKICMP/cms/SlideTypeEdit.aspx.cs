/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      樊紫红
** 创建日期:    2017年5月31日
** 描 述:       类别编辑页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.cms
{
    public partial class SlideTypeEdit : PageBase
    {
        public Web_SlideTypeDAL slidetypeDAL = new Web_SlideTypeDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();


        #region 参数集合
        /// <summary>
        /// 分类ID
        /// </summary>
        public int SType
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
                CommonFunction.BindEnum<CommonEnum.SlideType>(this.ddl_TFlag, "-99");
                if (SType != -1)
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
            Web_SlideTypeEntity model = slidetypeDAL.GetObjByID(SType);
            if (model != null)
            {
                this.txt_STypeName.Text = model.STypeName.ToString();
                this.ddl_TFlag.SelectedValue = model.TFlag.ToString();
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
                Web_SlideTypeEntity model = new Web_SlideTypeEntity();
                model.SType = SType;
                model.STypeName = this.txt_STypeName.Text.ToString().Trim();
                model.TFlag = Convert.ToInt32(this.ddl_TFlag.SelectedValue.ToString());
                model.CreateUser = UserID;
                model.Isdel = (int)CommonEnum.Deleted.未删除;

                int result = slidetypeDAL.Edit(model);
                if (result == 0)
                {
                    ShowMessage();
                    int log = SType == -1 ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, (SType == -1 ? "添加" : "修改") + "名称为：【" + this.txt_STypeName.Text.ToString().Trim() + "】分类信息", UserID));
                }
                else if (result == -2)
                {
                    ShowMessage("已存在类别名称与类别标识都相同的数据");
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