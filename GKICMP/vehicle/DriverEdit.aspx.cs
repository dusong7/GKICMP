/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月12日 09点30分
** 描   述:       司机编辑页面
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

namespace GKICMP.vehicle
{
    public partial class DriverEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public DriverDAL driverDAL = new DriverDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();



        #region 参数集合
        public int DID
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
                CommonFunction.BindEnum<CommonEnum.Vtype>(this.ddl_SType, "-2");
                if (DID != -1)
                {
                    BindInfo();
                }
            }
        }
        #endregion


        #region 初始化用户数据
        public void BindInfo()
        {
            DriverEntity model = driverDAL.GetObjByID(DID);
            if (model != null)
            {
                this.txt_DDesc.Text = model.DDesc;
                this.txt_DriverCode.Text = model.DriverCode;
                this.txt_FristGetDate.Text = model.FristGetDate.ToString("yyyy-MM-dd");
                this.ddl_SType.SelectedValue = model.SType.ToString();
               // this.hf_SelectedValue.Value = model.SysUid;
                this.Series.Text = model.SysUid;
               // this.Series.Enabled = false;
            }
        }
        #endregion


        #region 提交
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = departmentDAL.GetZNBM((int)CommonEnum.DepType.职能部门, (int)CommonEnum.IsorNot.否);
                DriverEntity model = new DriverEntity();
                model.CreateUser = UserID;
                model.DDesc = this.txt_DDesc.Text.Trim();
                model.DID = DID;
                model.DriverCode = this.txt_DriverCode.Text.Trim();
                model.FristGetDate = Convert.ToDateTime(this.txt_FristGetDate.Text);
                model.SType = Convert.ToInt32(this.ddl_SType.SelectedValue);
                              
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    if (this.hf_SelectedValue.Value == dt.Rows[i]["DID"].ToString())
                //    {
                //        ShowMessage("部门不可选做司机");
                //        return;
                //    }
                //}
                //model.SysUid = this.hf_SelectedValue.Value; 
                if (this.Series.Text == "")
                {
                    ShowMessage("请选择司机");
                    return;
                }
                model.SysUid = this.Series.Text;

                int result = driverDAL.Edit(model);
                if (result == 0)
                {
                    ShowMessage();
                    int log = DID == -1 ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, DID == -1 ? "添加" : "修改" + "司机名称为" + "的信息", UserID));
                }
                else if (result == -2)
                {
                    ShowMessage("司机已存在，请重新录入");
                    return;
                }
                else
                {
                    ShowMessage("保存失败");
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