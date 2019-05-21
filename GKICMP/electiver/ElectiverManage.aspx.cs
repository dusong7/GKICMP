/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2018年01月03日 10时24分45秒
** 描    述:      报修操作类
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.electiver
{
    public partial class ElectiverManage : PageBase
    {
        public ElectiverDAL eleDAL = new ElectiverDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();

        #region 参数集合
        public int SysMUID
        {
            get
            {
                return GetQueryString<int>("SysMUID", -1);
            }
        }
        #endregion

        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonFunction.BindEnum<CommonEnum.XQ>(this.ddl_TermID, "-2");
                GetCondition();
                DataBindList();
            }
        }
        #endregion


        #region 获取查询条件
        private void GetCondition()
        {
            ViewState["ElectiverName"] = CommonFunction.GetCommoneString(this.txt_ElectiverName.Text.ToString().Trim());
            ViewState["EYear"] = this.txt_EYear.Text.ToString().Trim();
            ViewState["TermID"] = this.ddl_TermID.SelectedValue.ToString();
        }
        #endregion


        #region 绑定数据
        private void DataBindList()
        {
            int recordCount = -1;
            ElectiverEntity model = new ElectiverEntity((string)ViewState["ElectiverName"], (string)ViewState["EYear"], Convert.ToInt32(ViewState["TermID"]));
            DataTable dt = eleDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.tr_null.Visible = false;
            }
            else
            {
                this.tr_null.Visible = true;
            }
            this.rp_List.DataSource = dt;
            Pager.RecordCount = recordCount;
            this.rp_List.DataBind();
        }
        #endregion


        #region 查询条件
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            GetCondition();
            DataBindList();
        }
        #endregion


        #region 删除事件
        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                string ids = this.hf_CheckIDS.Value.ToString();
                ids = ids.TrimEnd(',').TrimEnd(',');
                int result = eleDAL.DeleteBat(ids);
                if (result > 0)
                {
                    ShowMessage("删除成功");
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除选课任务信息", UserID));
                }
                else
                {
                    ShowMessage("删除失败");
                    return;
                }
                DataBindList();
                this.hf_CheckIDS.Value = "";
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                return;
            }
        }
        #endregion


        #region 分页事件
        protected void Pager_PageChanged(object sender, EventArgs e)
        {
            DataBindList();
        }
        #endregion


        #region 停止选课任务
        protected void lbtn_Stop_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lbtn = (LinkButton)sender;
                string id = lbtn.CommandArgument.ToString();
                int result = eleDAL.StopEle(Convert.ToInt32(id), (int)CommonEnum.ElectiveState.结束);
                if (result > 0)
                {
                    ShowMessage("停止任务成功");
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "停止选课任务", UserID));
                }
                else
                {
                    ShowMessage("停止任务失败");
                    return;
                }
                this.hf_CheckIDS.Value = "";
                DataBindList();
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
            }
        }
        #endregion

        protected void lbtn_Detail_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            string id = lbtn.CommandArgument.ToString();
            Response.Redirect("ElectiverDetail.aspx?id=" + id + "&SysMUID=" + SysMUID, false);
        }

        public string GetStateName(object begin, object end, object ebegin, object eend) 
        {
            if (DateTime.Parse(((DateTime)ebegin).ToString("yyyy-MM-dd")) >DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd"))) 
            {
                return "未开始";
            }
            else if (DateTime.Parse(((DateTime)end).ToString("yyyy-MM-dd")) < DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"))) 
            {
                //return CommonEnum.ElectiveState.结束.ToString();
                return "已结束";
            }
            else if (DateTime.Parse(((DateTime)eend).ToString("yyyy-MM-dd")) >DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd")))
            {
                return "预选阶段";
            }
            else 
            {
                return "选课阶段";
            }
        }
        public int GetState(object IsEstmate, object begin, object end, object ebegin, object eend)
        {
            if ((int)IsEstmate == 1)
            {

                if (DateTime.Parse(((DateTime)ebegin).ToString("yyyy-MM-dd")) > DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")))
                {
                    return 1;
                }
                else if (DateTime.Parse(((DateTime)end).ToString("yyyy-MM-dd")) < DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")))
                {
                    //return CommonEnum.ElectiveState.结束.ToString();
                    return 4;
                }
                else if (DateTime.Parse(((DateTime)eend).ToString("yyyy-MM-dd")) > DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")))
                {
                    return 2;
                }
                else
                {
                    return 3;
                }
                //if (DateTime.Parse(((DateTime)ebegin).ToString("yyyy-MM-dd")) > DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")))
                //{
                //    return 1;
                //}
                //else if (DateTime.Parse(((DateTime)end).ToString("yyyy-MM-dd")) < DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")))
                //{
                //    //return CommonEnum.ElectiveState.结束.ToString();
                //    return 4;
                //}
                //else if (DateTime.Parse(((DateTime)eend).ToString("yyyy-MM-dd")) > DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")))
                //{
                //    return 2;
                //}
                //else
                //{
                //    return 3;
                //}
            }
            else 
            {
                if (DateTime.Parse(((DateTime)end).ToString("yyyy-MM-dd")) < DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")))
                {
                    return 4;
                }
                else if (DateTime.Parse(((DateTime)begin).ToString("yyyy-MM-dd")) > DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")))
                    return 1;
                else
                    return 3;
            }
        }
    }
}