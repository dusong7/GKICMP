/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2016年10月15日 13时56分24秒
** 描    述:      教师合同管理界面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Configuration;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;

namespace GKICMP.teachermanage
{
    public partial class TeacherRetire : PageBase
    {
        public Teacher_ContractDAL contractDal = new Teacher_ContractDAL();
        public SysDataDAL SysDataDAL = new SysDataDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public TeacherDAL teacherDAL = new TeacherDAL();

        #region 参数集合
        /// <summary>
        /// 教师ID
        /// </summary>
        public string TID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        /// <summary>
        /// 教师合同ID
        /// </summary>
        public string TCID
        {
            get
            {
                return GetQueryString<string>("tcid", "");
            }
        }

        /// <summary>
        /// Flag 1：退休 2：解除合同
        /// </summary>
        public int Flag
        {
            get
            {
                return GetQueryString<int>("flag", -1);
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
                if (Flag == 1)
                {
                    this.ltl_Message.Text = "教师退休信息";
                    this.ltl_Message1.Text = "退休";
                }
                else
                {
                    this.ltl_Message.Text = "教师合同解除信息";
                    this.ltl_Message1.Text = "合同解除";
                }
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
            int result = -1;
            if (Flag == 1)
            {
                //result = teacherDAL.UpdateT(TID, Convert.ToDateTime(this.txt_OutDate.Text));
                //if (result == 0)
                //{
                //    ShowMessage();
                //    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志, "将教师退休", UserID));
                //}
                //else
                //{
                //    ShowMessage("更新出错，请稍后再试");
                //}
            }
            else
            {
                result = contractDal.RemoveDate(TCID, (int)CommonEnum.TState.解除, Convert.ToDateTime(this.txt_OutDate.Text.ToString()));
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "解除教师合同", UserID));
                    ShowMessage();
                }
                else
                {
                    ShowMessage("解除失败");
                    return;
                }
            }
        }
        #endregion

    }
}