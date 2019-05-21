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
using System.Text;


using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;

namespace GKICMP.cms
{
    public partial class NewsAudit : PageBase
    {

        public Web_NewsDAL web_NewsDAL = new Web_NewsDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public TeacherDAL teacherDAL = new TeacherDAL();
        public BaseDataDAL baseDataDAL = new BaseDataDAL();

        #region 参数集合
        public int Flag
        {
            get { return GetQueryString<int>("flag", -1); }
        }

        public int NID
        {
            get
            {
                return GetQueryString<int>("id", 0);
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                CommonFunction.BindEnum<CommonEnum.NewsAuditState>(this.ddl_AuditState, "-2");
            }
        }

        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {

             try
            {
                Web_NewsEntity model = new Web_NewsEntity();
                model.NID = NID;
                model.AduitUser = UserID;//
                model.AuditState = Convert.ToInt32(this.ddl_AuditState.SelectedValue.ToString());//审核状态
                model.IsAudit = Convert.ToInt32(CommonEnum.IsorNot.是);//是否审核

                int result = web_NewsDAL.NewsAudit(model);
                if (result > 0)
                {
                    ShowMessage();
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, "", UserID));
                }
                else
                {
                    ShowMessage("提交失败");
                    return;
                }

            }
             catch (Exception error)
             {
                 ShowMessage(error.Message);
             }

        }


        #region  返回
        protected void bt_ok_Click(object sender, EventArgs e)
        {

            Response.Redirect("NewsManage.aspx?flag=" + Flag);
        }
        #endregion

    }
}