/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月07日 09点30分
** 描   述:      排课计划
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;
using System.Web.UI.WebControls;


using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.customizedworkflow
{
    public partial class WFManage : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public WF_FormDAL formDAL = new WF_FormDAL();


        #region 页面初始化
        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataBindList();
            }

        }
        #endregion


        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {
            int recordCount = -1;


            DataTable dt = new WF_FormDAL().GetPagedList(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, -1,-1);

            if (dt != null && dt.Rows.Count > 0)
            {
                this.tr_null.Visible = false;
            }
            else
            {
                this.tr_null.Visible = true;
            }
            Pager.RecordCount = recordCount;
            this.rp_List.DataSource = dt;
            rp_List.DataBind();
        }
        #endregion


        #region 分页事件
        /// <summary>
        /// 分页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Pager_PageChanged(object sender, EventArgs e)
        {
            DataBindList();
        }
        #endregion


        #region 删除事件
        /// <summary>
        /// 删除事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lbtn = (LinkButton)sender;
                string id = lbtn.CommandArgument.ToString();
                string formname = lbtn.CommandName.ToString();
                //判断是否可以删除
                DataTable custmodel = new WF_CustomizedDAL().GetTable(wffid: id);
                bool isusing = false;
                for (int i = 0; i < custmodel.Rows.Count; i++)
                {
                    if (Convert.ToInt32(custmodel.Rows[i]["CState"]) != (int)CommonEnum.CState.审核通过 && Convert.ToInt32(custmodel.Rows[i]["CState"]) != (int)CommonEnum.CState.审核退回)
                    {
                        isusing = true;
                        break;
                    }
                }
                if (!isusing)
                {
                    int result = formDAL.Deleted(id, (int)CommonEnum.Deleted.删除);
                    if (result > 0)
                    {
                        ShowMessage("删除成功");
                        sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除名称为：【" + formname + "】的工作流信息", UserID));
                    }
                    else
                    {
                        ShowMessage("删除失败");
                        return;
                    }
                    DataBindList();
                }
                else
                {
                    ShowMessage("有审核流程未完成，请等所有审核流程结束后修改");
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

        public string getValue(object obj)
        {
            if (obj.ToString() == "0")
                return "true";
            else
                return "false";
        }

        #region 禁用启用事件
        protected void btn_PStateq_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lbtn = (LinkButton)sender;
                string id = lbtn.CommandArgument.ToString();
                int isenable = Convert.ToInt32(lbtn.CommandName.ToString());
                int result = -2;
                if (isenable == (int)CommonEnum.IsorNot.否)
                {
                    result = formDAL.IsEnable(id, (int)CommonEnum.IsorNot.是);
                }
                else
                {
                    result = formDAL.IsEnable(id, (int)CommonEnum.IsorNot.否);
                }

                if (result > 0)
                {
                    ShowMessage("设置成功");
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "设置自由流是否启用", UserID));
                }
                else
                {
                    ShowMessage("设置失败");
                    return;
                }
                DataBindList();
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