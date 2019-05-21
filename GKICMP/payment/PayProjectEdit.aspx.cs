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
    public partial class PayProjectEdit : PageBase
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

                //获取已启用的缴费项
                DataTable dt = payItemDAL.GetTable((int)CommonEnum.Deleted.未删除, (int)CommonEnum.IsorNot.否);
                //CommonFunction.CBLTypeBind(this.cbl_Button, dt, "PIID", "PayName");
                if (dt != null && dt.Rows.Count > 0)
                {
                    this.tr_null.Visible = false;
                }
                else
                {
                    this.tr_null.Visible = true;
                }
                rp_List.DataSource = dt;
                rp_List.DataBind();


                if (PPID != "")
                {
                    BindInfo();
                }
            }
        }
        #endregion

        #region 计算缴费项总金额
        /// <summary>
        /// 计算缴费项总金额
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CheckBox_Click(object sender, EventArgs e)
        {
            //string button = "";
            //foreach (ListItem li in this.cbl_Button.Items)
            //{
            //    if (li.Selected)
            //    {
            //        button = button + li.Value + ",";
            //    }
            //}
            //if (button.Length > 0)
            //{
            //    button = button.Substring(0, button.Length - 1);
            //}
            //PayItemEntity tmodel = payItemDAL.GetTableByPIIDs(button);
            //if(tmodel != null)
            //{ 
            //  this.txt_PayCount.Text = Convert.ToString(tmodel.PayCount);//缴费总金额
            //}
        }
        #endregion


        #region 初始化用户数据
        public void BindInfo()
        {
            PayProjectEntity model = payProjectDAL.GetObjByID(PPID);
            if (model != null)
            {

                //this.txt_PayCount.Text = model.PayCount.ToString();
                this.txt_ProjectName.Text = model.ProjectName;

                //this.rbl_IsDisable.SelectedValue = model.IsDisable.ToString();
                //this.txt_End.Text = model.EndDate.ToString("yyyy-MM-dd");

                //缴费项绑定
                DataTable pmodel = payProject_ItemDAL.GetByPPID(PPID);
                if (pmodel != null && pmodel.Rows.Count > 0)
                {
                    string aa = "";
                    for (int c = 0; c < pmodel.Rows.Count; c++)
                    {
                        //aa += pmodel.Rows[c]["PIID"].ToString()+",";
                        aa = pmodel.Rows[c]["PIID"].ToString();


                        //foreach (ListItem li in this.cbl_Button.Items)
                        //{
                        //    if (aa == li.Value)
                        //    {
                        //        li.Selected = true;
                        //    }
                        //}

                    }

                }

            }

        }
        #endregion

        #region 提交
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                PayProjectEntity model = new PayProjectEntity();
                model.PPID = PPID;
                model.ProjectName = this.txt_ProjectName.Text.Trim();
                model.Isdel = (int)CommonEnum.IsorNot.否;
                model.IsDisable = (int)CommonEnum.IsorNot.否;

                #region 计算缴费项总金额--缴费项的id
                string ids = this.hf_CheckIDS.Value;
                string button = ids.TrimEnd(',').TrimStart(','); //缴费项的id
                PayItemEntity tmodel = payItemDAL.GetTableByPIIDs(button);
                if (tmodel != null)
                {
                    model.PayCount = Convert.ToDecimal(tmodel.PayCount);//缴费总金额
                }
                #endregion

                //model.PayCount = Convert.ToDecimal(this.txt_PayCount.Text);

                #region 获取缴费项的id
                //string button = "";
                //foreach (ListItem li in this.cbl_Button.Items)
                //{
                //    if (li.Selected)
                //    {
                //        button = button + li.Value + ",";
                //    }
                //}
                //if (button.Length > 0)
                //{
                //    button = button.Substring(0, button.Length - 1);
                //}
                #endregion

                int result = payProjectDAL.Edit(model, button);
                if (result == 0)
                {
                    ShowMessage();
                    int log = PPID == "" ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, (PPID == "" ? "添加" : "修改") + "缴费项目名称为：【" + this.txt_ProjectName.Text + "】的信息", UserID));
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