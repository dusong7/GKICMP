/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年11月3日 14时10分32秒
** 描    述:      学生报名页面
** 修 改 人:      
** 修改日期:      
** 修改说明:      
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Data;
using System.Configuration;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.schoolwork
{
    public partial class StudentActPersonEdit : PageBase
    {
        public StudentActivityDAL actDAL = new StudentActivityDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();


        #region 参数集合
        /// <summary>
        /// 活动ID
        /// </summary>
        public string SAID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        #endregion


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //StudentActivityEntity model = actDAL.GetObjByID(SAID);
                //if (model != null)
                //{
                //    this.ActUsers.Text = model.ActUsers.ToString();
                //}
            }
        }
        #endregion


        #region 提交事件
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                StudentActivityEntity model = actDAL.GetObjByID(SAID);
                int result = actDAL.ActUserAdd(this.ActUsers.Text.TrimEnd(','), SAID);
                if (result > 0)
                {
                    ShowMessage();
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "添加活动名称为：【" + model.ActName + "】的报名的学生信息", UserID));
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