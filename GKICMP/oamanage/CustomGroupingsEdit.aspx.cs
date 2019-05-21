/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      殷志瑞
** 创建日期:    2017年02月27日
** 描 述:       自定义分组信息编辑页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/

using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;


using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;

namespace GKICMP.oamanage
{
    public partial class CustomGroupingsEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public Group_UserDAL groupUserDAL = new Group_UserDAL();
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
            DepartmentEntity model = departmentDAL.GetObjByDID(DID);
            if (model != null)
            {
                this.hf_SelectedValue.Value = model.UIDName.TrimEnd(',');
                this.txt_DepName.Text = model.DepName;
            }
        }
        #endregion


        #region 提交
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                Group_UserEntity model = new Group_UserEntity();
                if (this.hf_SelectedValue.Value == "")
                {
                    ShowMessage("请选择人员");
                    return;
                }
                model.SysID = this.hf_SelectedValue.Value.TrimEnd(',');
                model.DID = DID;
                string depname = this.txt_DepName.Text.Trim();
                int result = groupUserDAL.Edit(model, depname, (int)CommonEnum.DepType.自定义分组, (int)CommonEnum.IsorNot.否);
                if (result == 0)
                {
                    sysLogDAL.Edit(new SysLogEntity(DID == -1 ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改, DID == -1 ? "添加" : "修改" + "分组人员", UserID));
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('保存成功');window.location.href='CustomGroupingsManage.aspx'</script>");
                }
                else
                {
                    ShowMessage("保存失败");
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