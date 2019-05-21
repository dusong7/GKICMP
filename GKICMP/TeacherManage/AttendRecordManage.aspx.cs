/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2016年10月15日 13时56分24秒
** 描    述:      考勤打卡管理界面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Configuration;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using GK.GKICMP.DAL;
using System.Diagnostics;

namespace GKICMP.teachermanage
{
    public partial class AttendRecordManage : PageBase
    {

        public SysLogDAL sysLogDAL = new SysLogDAL();
        public AttendRecordDAL attendRecordDAL = new AttendRecordDAL();
        public BaseDataDAL baseDataDAL = new BaseDataDAL();

        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Stopwatch sp = new Stopwatch();
                sp.Start();
                CommonFunction.BindEnum<CommonEnum.AttendType>(this.ddl_AttendType, "-2");//考勤方式
                DataTable dt = baseDataDAL.GetList((int)CommonEnum.BaseDataType.考勤节点类型, -1);
                CommonFunction.DDlTypeBind(this.ddl_IsAnalysis, dt, "SDID", "DataName", "-2");//分析结果
                GetCondition();
                DataBindList();
                sp.Stop();
                long s = sp.ElapsedMilliseconds;
            }
        }
        #endregion


        #region 获取查询条件
        public void GetCondition()
        {
            //ViewState["UserNum"] = CommonFunction.GetCommoneString(this.txt_UserNum.Text.Trim());
            ViewState["TeaIDName"] = CommonFunction.GetCommoneString(this.txt_TeaIDName.Text.Trim());
            ViewState["AttendType"] = this.ddl_AttendType.SelectedValue.ToString();
            ViewState["begin"] = this.txt_SDate.Text == "" ? "1900-01-01" : this.txt_SDate.Text;
            ViewState["end"] = this.txt_EDate.Text == "" ? "9999-12-31" : this.txt_EDate.Text;

            ViewState["IsAnalysis"] = this.ddl_IsAnalysis.SelectedValue.ToString();
        }
        #endregion


        #region 数据绑定
        public void DataBindList()
        {
            int recordCount;
            AttendRecordEntity model;
            getdt(out recordCount, out model);
            DataTable dt = attendRecordDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
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

        private void getdt(out int recordCount, out AttendRecordEntity model)
        {
            recordCount = 0;
            model = new AttendRecordEntity();
            model.UserNum = "";
            model.UserName = ViewState["TeaIDName"].ToString();
            model.AttendType = Convert.ToInt32(ViewState["AttendType"].ToString());
            model.Begin = Convert.ToDateTime(ViewState["begin"].ToString());
            model.End = Convert.ToDateTime(ViewState["end"].ToString());

            model.IsAnalysis = Convert.ToInt32(ViewState["IsAnalysis"].ToString());
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


        #region 分页
        protected void Pager_PageChanged(object sender, EventArgs e)
        {
            DataBindList();
        }
        #endregion


        #region 导出

        protected void btn_OutPut_Click(object sender, EventArgs e)
        {
            try
            {
                int recordCount;
                AttendRecordEntity model;
                getdt(out recordCount, out model);
                DataTable dt = attendRecordDAL.GetPaged(int.MaxValue, 1, ref recordCount, model);
                if (dt != null && dt.Rows.Count > 0)
                {
                    StringBuilder str = new StringBuilder();
                    str.Append("<table border='1' cellspaccing='0' cellpadding='0'><tr><th>卡号</th><th>姓名</th><th>打卡机号码</th><th>打卡时间</th><th>考勤方式</th><th>分析结果</th></tr>");
                    foreach (DataRow row in dt.Rows)
                    {
                        str.Append("<tr>");
                        str.AppendFormat("<td style='vnd.ms-excel.numberformat:@'>{0}</td>", row["CardNum"]);
                        str.AppendFormat("<td>{0}</td>", row["UserName"]);
                        str.AppendFormat("<td>{0}</td>", row["MachineCode"]);
                        str.AppendFormat("<td>{0}</td>", Convert.ToDateTime(row["RecordDate"]).ToString("yyyy-MM-dd HH:mm:ss"));
                        str.AppendFormat("<td>{0}</td>", CommonFunction.CheckEnum<CommonEnum.AttendType>(row["AttendType"]));
                        str.AppendFormat("<td>{0}</td>", row["AnayName"]);
                        str.Append("</tr>");
                    }
                    str.Append("</table>");
                    CommonFunction.ExportExcel("考勤打卡记录", str.ToString());
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_导出, "导出考勤打卡记录", UserID));
                }
                else
                {
                    ShowMessage("暂无数据导出");
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


        #region 获取分析结果
        public string GetIsanayName(object sender)
        {
            if (sender.ToString() == "")
            {
                return "<span style='color:red;'>未分析</span>";
            }
            else
            {
                return sender.ToString();
            }
        }
        #endregion
    }
}