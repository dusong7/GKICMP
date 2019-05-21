/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年10月09日 15时15分
** 描    述:      班班通使用登记补录
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

namespace GKICMP.computermanage
{
    public partial class ComputerRegEdit : PageBase
    {
        public ComputerRegDAL regDAL = new ComputerRegDAL();
        public CourseDAL courseDAL = new CourseDAL();
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
                DataTable dt = courseDAL.GetList();
                CommonFunction.DDlTypeBind(this.ddl_CourseID, dt, "CID", "CourseName", "-2");
                CommonFunction.BindEnum<CommonEnum.XQ>(this.ddl_XTerm, "-2");
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
                ComputerRegEntity model = new ComputerRegEntity();
                model.CRID = "";
                if (this.Series.Text == "")
                {
                    ShowMessage("请选择教师");
                    return;
                }
                model.SysID = this.Series.Text;
                model.CID = Convert.ToInt32(this.ddl_CourseID.SelectedValue.ToString());
                model.ChapterName = this.txt_ChapterName.Text.ToString().Trim();
                model.RegDate = Convert.ToDateTime(this.txt_RegDate.Text.ToString());
                model.XTerm = Convert.ToInt32(this.ddl_XTerm.SelectedValue.ToString());
                model.Xyear = this.txt_Xyear.ToString().Trim();
                model.RegType = (int)CommonEnum.RegType.补录;

                int result = regDAL.RecEdit(model);
                if (result == 0)
                {
                    ShowMessage();
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, "添加课题为【" + this.txt_ChapterName.Text + "】的班班通使用登记补录信息", UserID));
                }
                else if (result == -2)
                {
                    ShowMessage("当前登记时间之前的40分钟内已有登记记录，请检查后重新录入");
                    return;
                }
                else if (result == -3)
                {
                    ShowMessage("当前登记时间之后的40分钟内已有登记记录，请检查后重新录入");
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
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                ShowMessage(ex.Message);
                return;
            }
        }
        #endregion
    }
}