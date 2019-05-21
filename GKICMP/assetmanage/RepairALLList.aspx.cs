/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      殷志瑞
** 创建日期:    2016年12月24日
** 描 述:       受理报修管理页面
** 修改人:      
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

namespace ICMP.assetmanage
{
    public partial class RepairALLList : PageBase
    {

        public SysLogDAL sysLogDAL = new SysLogDAL();
        public Asset_RepairDAL repairDAL = new Asset_RepairDAL();


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonFunction.BindEnum<CommonEnum.ARState>(this.ddl_ARState, "-2");
                //this.txt_Begin.Text = DateTime.Now.ToString("yyyy-MM-dd");
                //this.txt_End.Text = DateTime.Now.ToString("yyyy-MM-dd");
                GetCondition();
                DataBindList();
            }
        }
        #endregion


        #region 获取查询条件
        public void GetCondition()
        {
            ViewState["RepairObj"] = CommonFunction.GetCommoneString(this.txt_RepairObj.Text.Trim());
            ViewState["begin"] = this.txt_Begin.Text == "" ? "1900-01-01" : this.txt_Begin.Text;
            ViewState["end"] = this.txt_End.Text == "" ? "9999-12-31" : this.txt_End.Text;
            ViewState["DutyUser"] = CommonFunction.GetCommoneString(this.txt_DutyUser.Text.Trim());
            ViewState["ARState"] = this.ddl_ARState.SelectedValue;
        }
        #endregion


        #region 数据绑定
        public void DataBindList()
        {
            int recordCount = 0;
            Asset_RepairEntity model = new Asset_RepairEntity();
            model.RepairObj = ViewState["RepairObj"].ToString();
            DateTime begin = Convert.ToDateTime(ViewState["begin"].ToString());
            DateTime end = Convert.ToDateTime(ViewState["end"].ToString());
            model.DutyUser = ViewState["DutyUser"].ToString();
            model.ARState = Convert.ToInt32(ViewState["ARState"].ToString());
            model.Isdel = Convert.ToInt32(CommonEnum.Deleted.未删除);
            model.CreaterUser = UserID;
            DataTable dt = repairDAL.GetPagedByfalg(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model, begin, end, 2);
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
            this.hf_CheckIDS.Value = "";
        }
        #endregion


        #region 分页
        public void Pager_PageChanged(object sender, EventArgs e)
        {
            DataBindList();
        }
        #endregion


        #region 查询
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            Pager.CurrentPageIndex = 1;
            GetCondition();
            DataBindList();
        }
        #endregion


        public string GetState(object obj)
        {
            string name = "";
            name = obj.ToString() == "0" ? "<span style='color:#febe17'>" + CommonFunction.CheckEnum<CommonEnum.ARState>(obj.ToString()) + "</span>" : obj.ToString() == "1" ? "<span style='color:#47ae6f'>" + CommonFunction.CheckEnum<CommonEnum.ARState>(obj.ToString()) + "</span>" : obj.ToString() == "2" ? "<span style='color:red'>" + CommonFunction.CheckEnum<CommonEnum.ARState>(obj.ToString()) + "</span>" : "<span style='color:gray'>" + CommonFunction.CheckEnum<CommonEnum.ARState>(obj.ToString()) + "</span>";
            return name;
        }


        #region 导出
        protected void btn_OutPut_Click(object sender, EventArgs e)
        {
            try
            {
                int recordCount = 0;
                Asset_RepairEntity model = new Asset_RepairEntity();
                model.RepairObj = ViewState["RepairObj"].ToString();
                DateTime begin = Convert.ToDateTime(ViewState["begin"].ToString());
                DateTime end = Convert.ToDateTime(ViewState["end"].ToString());
                model.DutyUser = ViewState["DutyUser"].ToString();
                model.ARState = Convert.ToInt32(ViewState["ARState"].ToString());
                model.Isdel = Convert.ToInt32(CommonEnum.Deleted.未删除);
                model.CreaterUser = UserID;
                DataTable dt = repairDAL.GetPagedByfalg(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model, begin, end, 2);
                if (dt != null && dt.Rows.Count > 0)
                {
                    StringBuilder str = new StringBuilder("");
                    str.Append("<table border='1' cellpadding='0' cellspaccing='0'><tr><th>报修对象</th><th>报修人</th><th>报修日期</th><th>受理部门</th><th>本校受理人</th><th>维修单位</th><th>联系方式</th><th>完成日期</th><th>完成说明</th><th>状态</th></tr>");
                    foreach (DataRow row in dt.Rows)
                    {
                        str.Append("<tr>");
                        str.AppendFormat("<td>{0}</td>", row["RepairObj"]);
                        str.AppendFormat("<td>{0}</td>", row["CreaterUserName"]);
                        str.AppendFormat("<td>{0}</td>", row["ARDate"].ToString() == "" ? "" : Convert.ToDateTime(row["ARDate"]).ToString("yyyy-MM-dd"));
                        str.AppendFormat("<td>{0}</td>", row["DutyDepName"]);
                        str.AppendFormat("<td>{0}</td>", row["RealName"]);
                        str.AppendFormat("<td>{0}</td>", row["SName"]);
                        str.AppendFormat("<td>{0}</td>", row["LinkPhone"]);
                        str.AppendFormat("<td>{0}</td>", row["CompDate"].ToString() == "" ? "" : Convert.ToDateTime(row["CompDate"]).ToString("yyyy-MM-dd"));
                        str.AppendFormat("<td>{0}</td>", row["CompDesc"]);
                        str.AppendFormat("<td>{0}</td>", CommonFunction.CheckEnum<CommonEnum.ARState>(row["ARState"]));
                        str.Append("</tr>");
                    }
                    str.Append("</table>");
                    CommonFunction.ExportExcel("报修信息", str.ToString());
                }
                else
                {
                    ShowMessage("暂无数据导出");
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_导出, "导出报修信息", UserID));
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