/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年05月17日 09点30分
** 描   述:      招标信息添加修改
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using GK.GKICMP.DAL;
using System.Data;

namespace GKICMP.projectmanage
{
    public partial class ProTenderEdit : PageBase
    {

        public SysLogDAL sysLogDAL = new SysLogDAL();
        public Project_TenderDAL project_TenderDAL = new Project_TenderDAL();
        public SupplierDAL supplierDAL = new SupplierDAL();
        public JZProjectManageDAL jZProjectManageDAL = new JZProjectManageDAL();
        #region 参数
        public string PTID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        #endregion
        #region 页面加载
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = supplierDAL.GetList((int)CommonEnum.IsorNot.否, "");
                CommonFunction.DDlTypeBind(this.ddl_SName, dt, "SDID", "SupplierName", "-2");

                // DataTable dtp = jZProjectManageDAL.GetList((int)CommonEnum.IsorNot.否);
                DataTable dtp = jZProjectManageDAL.GetListByIsCheck((int)CommonEnum.Deleted.未删除);//获取验收状态为0的项目名称
                CommonFunction.DDlTypeBind(this.ddl_ProName, dtp, "PID", "ProName", "-2");
                if (PTID != "")
                {
                    BindInfo();
                }

            }
        }
        #endregion
        #region 信息绑定
        public void BindInfo()
        {
            try
            {
                Project_TenderEntity model = project_TenderDAL.GetObjByID(PTID);
                this.txt_BidNumber.Text = model.BidNumber;
                this.ddl_ProName.SelectedValue = model.PID;
                this.ddl_SName.SelectedValue = model.SID;
                this.txt_BDate.Text = model.BDate.ToString("yyyy-MM-dd");
                this.txt_BAmount.Text = model.BAmount.ToString();
                this.txt_BSDate.Text = model.BSDate.ToString("yyyy-MM-dd");
                this.txt_BEDate.Text = model.BEDate.ToString("yyyy-MM-dd");
                this.txt_BondDate.Text = model.BondDate.ToString("yyyy-MM-dd");
                this.txt_Bond.Text = model.Bond.ToString();
                this.txt_PTDesc.Text = model.PTDesc;
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
            }
        }
        #endregion

        #region 提交
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                Project_TenderEntity model = new Project_TenderEntity();
                model.PTID = PTID;//id
                model.BidNumber = this.txt_BidNumber.Text;//招标编号
                model.PID = this.ddl_ProName.SelectedValue;//
                model.SID = this.ddl_SName.SelectedValue;//
                model.BDate = Convert.ToDateTime(this.txt_BDate.Text);//
                model.BAmount = decimal.Parse(this.txt_BAmount.Text);///
                model.BSDate = Convert.ToDateTime(this.txt_BSDate.Text);//
                model.BEDate = Convert.ToDateTime(this.txt_BEDate.Text);//
                model.BondDate = Convert.ToDateTime(this.txt_BondDate.Text);//
                model.Bond = decimal.Parse(this.txt_Bond.Text);//
                model.PTDesc = this.txt_PTDesc.Text;//
                model.CreateDate = DateTime.Now;//
                model.CreateUser = UserID;//
                model.Isdel = (int)CommonEnum.IsorNot.否;//
                AccessoryEntity accessinfo = new AccessoryEntity();

                int result = project_TenderDAL.Edit(model, accessinfo);
                if (result == 0)
                {
                    ShowMessage();
                }
                else if (result == -2)
                {
                    ShowMessage("招标编号不能重复，请修改后重新提交");
                    return;
                }
                else { ShowMessage("提交失败"); }
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