/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      殷志瑞
** 创建日期:    2017年6月7日 18时04分
** 描 述:       代课安排通过或驳回
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using System.Text;
using GK.GKICMP.Entities;
using System.Web.UI.WebControls;

namespace GKICMP.educationals
{
    public partial class PersonSubstituteEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public AbsentDAL absentDAL = new AbsentDAL();


        #region 参数集合

        public int ABID
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
                CommonFunction.BindEnum<CommonEnum.PraState>(this.ddl_SubState, "-99");
                this.ddl_SubState.Items.Remove(new ListItem("申请中", "0"));
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
                AbsentEntity model = new AbsentEntity();
                model.AbID = ABID;
                model.SubState = Convert.ToInt32(this.ddl_SubState.SelectedValue);
                model.Reason = this.txt_Reason.Text.Trim();
                if (model.SubState == (int)CommonEnum.PraState.驳回 && model.Reason == "")
                {
                    ShowMessage("驳回请录入原因");
                    return;
                }
                int result = absentDAL.Audit(model);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "审核代课信息", UserID));
                    ShowMessage();
                }
                else
                {
                    ShowMessage("保存失败");
                    return;
                }
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                ShowMessage(ex.Message);
            }
        }
        #endregion
    }
}