/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年07月18日 11时26分32秒
** 描    述:      学生活动添加页面
** 修 改 人:      樊紫红
** 修改日期:      2017年11月3日
** 修改说明:      增加部分字段
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
    public partial class StudentActEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public StudentActivityDAL studentActivityDAL = new StudentActivityDAL();
        public SysDataDAL sysDataDAL = new SysDataDAL();


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
                this.txt_ClosingDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                DataTable dt = sysDataDAL.GetList((int)CommonEnum.Deleted.未删除, (int)CommonEnum.DataType.学生活动类型);
                CommonFunction.DDlTypeBind(this.ddl_ActType, dt, "SDID", "DataName", "-2");
                if (SAID != "")
                {
                    BindInfo();
                }
            }
        }
        #endregion


        #region 初始化用户数据
        public void BindInfo()
        {
            StudentActivityEntity model = studentActivityDAL.GetObjByID(SAID);
            if (model != null)
            {
                this.txt_ActName.Text = model.ActName.ToString().Trim();
                this.ddl_ActType.SelectedValue = model.ActType.ToString();
                this.txt_ABegin.Text = model.ABegin == null ? "" : model.ABegin.ToString("yyyy-MM-dd");
                this.txt_AEnd.Text = model.AEnd == null ? "" : model.AEnd.ToString("yyyy-MM-dd");
                this.Series.Text = model.Counselor;//指导老师
                this.txt_ActAddress.Text = model.ActAddress;
                this.txt_ClosingDate.Text = model.ClosingDate == null ? "" : model.ClosingDate.ToString("yyyy-MM-dd");
                this.hf_ActUsers.Value = model.ActUsers;
                if (model.LogoUrl != null && model.LogoUrl.ToString() != "")
                {
                    this.img_LogoUrl.Visible = true;
                    this.img_LogoUrl.ImageUrl = model.LogoUrl.ToString();
                }
                this.txt_ActContent.Text = model.ActContent;
                this.txt_ActDesc.Text = model.ActDesc;
                this.txt_Content.Text = model.ActivityTemp.ToString();
                this.rdo_IsSign.SelectedValue = model.IsSign.ToString();
            }
        }
        #endregion


        #region 提交
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                StudentActivityEntity model = new StudentActivityEntity();
                model.ActUsers = this.hf_ActUsers.Value.TrimEnd(',');

                if (this.Series.Text == "")
                {
                    ShowMessage("请选择指导老师");
                    return;
                }

                model.SAID = SAID;
                model.ActName = this.txt_ActName.Text.Trim();
                model.ActType = Convert.ToInt32(this.ddl_ActType.SelectedValue);
                model.ActAddress = this.txt_ActAddress.Text.Trim();
                model.Counselor = this.Series.Text;
                model.ActContent = this.txt_ActContent.Text.Trim();
                model.ActDesc = this.txt_ActDesc.Text.Trim();
                model.CreateUser = UserID;
                model.LogoUrl = this.img_LogoUrl.ImageUrl.ToString();
                model.ClosingDate = Convert.ToDateTime(this.txt_ClosingDate.Text.ToString().Trim());
                model.ActivityTemp = this.txt_Content.Text.ToString();
                model.ABegin = Convert.ToDateTime(this.txt_ABegin.Text.ToString().Trim());
                model.AEnd = Convert.ToDateTime(this.txt_AEnd.Text.ToString().Trim());
                model.IsSign = Convert.ToInt32(this.rdo_IsSign.SelectedValue.ToString());
                model.IsPublish = (int)CommonEnum.IsorNot.否;
                model.Isdel = (int)CommonEnum.IsorNot.否;

                int upsize = 4000000;
                try
                {
                    upsize = Convert.ToInt32(ConfigurationManager.AppSettings["upsize"].ToString());
                }
                catch (Exception) { }
                AccessoryEntity fileinfo = CommonFunction.upfile(0, 1, hf_UpFile);

                if (fileinfo != null && fileinfo.AccessUrl != null && fileinfo.AccessUrl.ToString() != "")
                {
                    model.LogoUrl = fileinfo.AccessUrl;
                }

                int result = studentActivityDAL.Edit(model);
                if (result > 0)
                {
                    int log = SAID == "" ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<script>alert('提交成功');window.location='StudentActManage.aspx'</script>");
                    sysLogDAL.Edit(new SysLogEntity(log, SAID == "" ? "添加" : "修改" + "学生活动名称为：" + this.txt_ActName.Text + "的信息", UserID));
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
            }
        }
        #endregion
    }
}