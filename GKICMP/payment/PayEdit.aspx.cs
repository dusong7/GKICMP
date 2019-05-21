/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      gxl
** 创建日期:    2017年08月15日 08时30分
** 描 述:       缴费项目管理页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;
using System.Linq;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
namespace GKICMP.payment
{
    public partial class PayEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public PayProjectDAL payProjectDAL = new PayProjectDAL();
        public PayItemDAL payItemDAL = new PayItemDAL();
        public PayProject_ItemDAL payProject_ItemDAL = new PayProject_ItemDAL();


        #region 参数集合
        public string PPID
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
                //this.txt_PayCount.Attributes["readonly"] = "true"; 

                //this.hf_PPID.Value = PPID.ToString();

                if (PPID != "")
                {
                    this.hf_PPID.Value = PPID.ToString();
                    BindInfo();
                    RegBind();//缴费项绑定
                }
                else
                {
                    this.hf_PPID.Value = Guid.NewGuid().ToString();
                }
              
               
            }
        }
        #endregion


        #region 缴费项绑定
        /// <summary>
        /// 缴费项绑定
        /// </summary>
        private void RegBind()
        {
            //DataTable pmodel = payProject_ItemDAL.GetByPPID(PPID);
            DataTable pmodel = payProject_ItemDAL.GetByPPID(this.hf_PPID.Value);
            if (pmodel != null && pmodel.Rows.Count > 0)
            {
                this.tr_null.Visible = false;
            }
            else
            {
                this.tr_null.Visible = true;
            }
            this.rp_List123.DataSource = pmodel;
            this.rp_List123.DataBind();
        }
        #endregion

        #region 删除缴费项
        /// <summary>
        /// 删除缴费项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lbtn = (LinkButton)sender;
                string esid = lbtn.CommandArgument.ToString();
                int result = payProject_ItemDAL.DeleteBat(esid);
                if (result > 0)
                {
                    ShowMessage("删除成功");
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除缴费项", UserID));
                }
                else
                {
                    ShowMessage("删除失败");
                    return;
                }
                RegBind();//缴费项绑定
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
            }
        }
        #endregion

        #region 刷新绑定缴费项
        /// <summary>
        /// 刷新绑定缴费项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtn_inquiry_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            RegBind();
        }
        #endregion


        #region 初始化用户数据
        public void BindInfo()
        {
            PayProjectEntity model = payProjectDAL.GetObjByID(PPID);
            if (model != null)
            {
                this.txt_ProjectName.Text = model.ProjectName;

                RegBind();


            }

        }
        #endregion

        #region 提交
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                PayProjectEntity model = new PayProjectEntity();
                int isadd = PPID == "" ? 0 : 1;
                model.PPID = this.hf_PPID.Value;
                model.ProjectName = this.txt_ProjectName.Text.Trim();
                model.Isdel = (int)CommonEnum.IsorNot.否;
                model.IsDisable = (int)CommonEnum.IsorNot.否;

                #region 计算缴费项总金额--缴费项的id
                PayItemEntity tmodel = payItemDAL.GetTableByPIIDs(this.hf_PPID.Value);
                if (tmodel != null)
                {
                    model.PayCount = Convert.ToDecimal(tmodel.PayCount);//缴费总金额
                }
                else
                {
                    ShowMessage("还没添加缴费项名称，请添加");
                    return;
                }
                #endregion


                int result = payProjectDAL.Edit(model, isadd);
                if (result == 0)
                {
                    ShowMessage();
                   // ClientScript.RegisterStartupScript(GetType(), "Message", "<script>alert('提交成功');window.location='PayProjectManage.aspx';</script>");
                    int log = isadd == 0 ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, isadd == 0  ? "添加" : "修改" + "缴费项目名称为：【" + this.txt_ProjectName.Text + "】的信息", UserID));
                }
                else if (result == -2)
                {
                    ShowMessage("缴费项名称已存在，请重新录入");
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