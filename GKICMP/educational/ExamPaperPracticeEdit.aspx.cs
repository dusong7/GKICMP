/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      殷志瑞
** 创建日期:    2017年6月8日 18时04分
** 描 述:       发布练习编辑
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Text;

namespace GKICMP.educational
{
    public partial class ExamPaperPracticeEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public ExamPaper_PracticeDAL practiceDAL = new ExamPaper_PracticeDAL();


        #region 参数集合
        public string EPID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        public int GID
        {
            get
            {
                return GetQueryString<int>("gid", -1);
            }
        }
        #endregion


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.hf_gid.Value = GID.ToString();
            }
        }
        #endregion


        #region 提交
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                ExamPaper_PracticeEntity model = new ExamPaper_PracticeEntity();
                model.CompleteDate = Convert.ToDateTime(this.txt_CompleteDate.Text.Trim());
                if (model.CompleteDate <= DateTime.Now)
                {
                    ShowMessage("完成时间不能小于当前时间");
                    return;
                }
                model.CreateUser = UserID;
                model.EPID = EPID;
                model.ExcDesc = this.txt_ExcDesc.Text.Trim();
                model.Isdel = (int)CommonEnum.IsorNot.否;
                if (this.hf_AlluserID.Value == "")
                {
                    ShowMessage("学生不能为空");
                    return;
                }
                int result = practiceDAL.Edit(model, this.hf_AlluserID.Value.TrimEnd(','));
                if (result == 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, "添加发布练习信息", UserID));
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('保存成功');window.location.href='../educational/ExamPaperManage.aspx'</script>");
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