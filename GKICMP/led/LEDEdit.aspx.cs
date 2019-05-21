/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年08月22日 13时41分01秒
** 描    述:      教师听课操作类
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.led
{
    public partial class LEDEdit : PageBase
    {
        public LEDDAL lEDDAL = new LEDDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();

        #region 参数集合
        /// <summary>
        /// LID
        /// </summary>
        public int LID
        {
            get
            {
                return GetQueryString<int>("id", 0);
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
                CommonFunction.BindEnum<CommonEnum.LedColor>(this.ddl_LColor,"-99");
                CommonFunction.BindEnum<CommonEnum.LedConn>(this.ddl_LCType,"-99");
                CommonFunction.BindEnum<CommonEnum.LedType>(this.ddl_LType, "-99");
                CommonFunction.BindEnum<CommonEnum.LedBrand>(this.ddl_Brand, "-99");
                if (LID != 0)
                {
                    InfoBind();
                }
            }
        }
        #endregion


        #region 绑定数据
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void InfoBind()
        {
            try
            {
                LEDEntity model = lEDDAL.GetObjByID(LID);
                if (model != null)
                {
                    this.txt_LName.Text = model.LName;
                    this.ddl_LColor.SelectedValue = model.LColor.ToString();
                    this.txt_LIP.Text = model.LIP;
                    this.ddl_LCType.SelectedValue = model.LCType.ToString();
                    this.ddl_LType.SelectedValue = model.LType.ToString();
                    this.txt_SizeH.Text = model.LHeight.ToString();
                    this.txt_SizeW.Text = model.LWidth.ToString();
                    this.ddl_LBright.SelectedValue = model.LBright.ToString();
                    this.ddl_Brand.SelectedValue = model.LBrand.ToString();
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                return;
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
                LEDEntity model = new LEDEntity();
                model.LID = LID;
                model.LName = this.txt_LName.Text;
                model.LCType = int.Parse(this.ddl_LCType.SelectedValue);
                model.LIP = this.txt_LIP.Text;
                model.LType = int.Parse(this.ddl_LType.SelectedValue);
                model.LColor = int.Parse(this.ddl_LColor.SelectedValue);
                model.LWidth = int.Parse(this.txt_SizeW.Text);
                model.LHeight = int.Parse(this.txt_SizeH.Text);
                model.LBright = int.Parse(this.ddl_LBright.SelectedValue);
                model.CreateDate = DateTime.Now;
                model.CreateUser = UserID;
                model.LBrand=int.Parse(this.ddl_Brand.SelectedValue);
                int result = lEDDAL.Edit(model);
                if (result > 0)
                {
                    //ShowMessage();
                    int log = LID == 0 ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, (LID == 0 ? "添加" : "修改") + "LED信息", UserID));
                    ShowMessage();
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
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                return;
            }
        }
        #endregion
    }
}