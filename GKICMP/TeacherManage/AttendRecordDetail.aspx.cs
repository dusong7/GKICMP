/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2017年01月26日 16时05分25秒
** 描    述:      教师管理页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using System.Data;

namespace GKICMP.teachermanage
{
    public partial class AttendRecordDetail : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        //public SysUserDAL sysUserDAL = new SysUserDAL();
        public AttendRecordDAL attendRecordDAL = new AttendRecordDAL();
        //public BaseDataDAL baseDataDAL = new BaseDataDAL();
        //public TeacherDAL teacherDAL = new TeacherDAL();

        #region 参数集合
        /// <summary>
        /// TID 用户ID ==教师ID
        /// </summary>
        public string ARID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ARID != "") 
            {
                InfoBind();
            }
        }
        #region 初始化用户数据
        /// <summary>
        /// 初始化用户数据
        /// </summary>
        private void InfoBind()
        {
            AttendRecordEntity tmodel = attendRecordDAL.GetObjByID(ARID);
            if (tmodel != null)
            {
                this.ltl_RealName.Text = tmodel.UserName;
                this.ltl_RecordDate.Text = tmodel.RecordDate.ToString("yyyy-MM-dd HH:mm:ss");
                this.ltl_OutType.Text = tmodel.OutType == 1 ? "进入" : "离开";
                this.img_AttImg.ImageUrl = tmodel.AttImg;
            }
        }
        #endregion
    }
}