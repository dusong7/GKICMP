/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月12日 09点30分
** 描   述:       学生变动信息编辑页面
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.Data;
using System.Text;
using System.Web.UI.WebControls;

namespace GKICMP.studentmanage
{
    public partial class SchoolChangeEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SchoolChangeDAL schoolChangeDAL = new SchoolChangeDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();


        #region 参数集合
        public string TID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        public string stID
        {
            get
            {
                return GetQueryString<string>("stid", "");
            }
        }
        public int Flag
        {
            get
            {
                return GetQueryString<int>("flag", -1);
            }
        }
        #endregion


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.hf_Stuid.Value = stID.TrimEnd(',');
                CommonFunction.BindEnum<CommonEnum.BDLX>(this.ddl_SCType, "-2");
                SysUserEntity model = sysUserDAL.GetObjByID(this.hf_Stuid.Value);
                if (model != null)
                {
                    this.ltl_StuName.Text = model.RealName;
                    this.ltl_DepID.Text = model.DepName;
                }
                if (Flag == 2)
                {
                    BindInfo();
                }
            }
        }
        #endregion


        #region 提交
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                SchoolChangeEntity model = new SchoolChangeEntity();
                model.CreateUser = UserID;
                model.SCDate = Convert.ToDateTime(this.txt_SCDate.Text);
                model.SCDesc = this.txt_SCDesc.Text.Trim();
                model.SCReason = this.txt_SCReason.Text.Trim();
                model.SCType = Convert.ToInt32(this.ddl_SCType.SelectedValue);
                model.StuID = this.hf_Stuid.Value;
                model.TID = TID;
                model.AduitState = (int)CommonEnum.AduitState.未审核;
                int result = schoolChangeDAL.Edit(model);
                if (result == 0)
                {
                    int log = TID == "" ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, (TID == "" ? "添加" : "修改") + "姓名：" + this.ltl_StuName.Text + "的学生变动信息", UserID));
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


        #region 初始化用户数据
        public void BindInfo()
        {
            SchoolChangeEntity model = schoolChangeDAL.GetObjByID(TID);
            if (model != null)
            {
                this.txt_SCDate.Text = model.SCDate.ToString("yyyy-MM-dd");
                this.txt_SCDesc.Text = model.SCDesc;
                this.txt_SCReason.Text = model.SCReason;
                this.ddl_SCType.SelectedValue = model.SCType.ToString();
                this.hf_Stuid.Value = model.StuID;
            }
        }
        #endregion
    }
}