/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      gxl
** 创建日期:    2017年02月27日
** 描 述:       考勤假期页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using GK.GKICMP.Common;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Data;
using System.Text;

namespace GKICMP.teachermanage
{
    public partial class AttendVacationEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
      
        public BaseDataDAL baseDataDAL = new BaseDataDAL();

        public AttendVacationDAL attendVacationDAL = new AttendVacationDAL();

        #region 参数集合
        /// <summary>
        /// Vid
        /// </summary>
        public int Vid
        {
            get
            {
                return GetQueryString<int>("id", -1);
            }
        }
      
        #endregion

        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              
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
                AttendVacationEntity model = new AttendVacationEntity();
                model.Vid = Vid;
                model.VacName = this.txt_VacName.Text.ToString();
                model.VBegin = this.txt_VBegin.Text == "" ? Convert.ToDateTime("1990/1/1 0:00:00") : Convert.ToDateTime(this.txt_VBegin.Text.Trim());
                model.VEnd = this.txt_VEnd.Text == "" ? Convert.ToDateTime("1990/1/1 0:00:00") : Convert.ToDateTime(this.txt_VEnd.Text.Trim());


                int result = attendVacationDAL.Edit(model);
                if (result == 0)
                {
                    ShowMessage();
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, ("添加") + "名称为：" + this.txt_VacName.Text + "的信息", UserID));
                }
                else if (result == -2)
                {
                    ShowMessage("系统中已存在此假期");
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
            }
        }
        #endregion



    }
}