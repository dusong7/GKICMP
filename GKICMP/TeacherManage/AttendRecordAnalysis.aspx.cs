
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Data;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Diagnostics;

namespace GKICMP.teachermanage
{
    public partial class AttendRecordAnalysis : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public AttendRecordDAL attendRecordDAL = new AttendRecordDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public BaseDataDAL baseDataDAL = new BaseDataDAL();
        public AttendSetDAL attendSetDAL = new AttendSetDAL();

        public int cd = 0;
        public int zt = 0;
        public int lswc = 0;
        public int sj = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //this.hf_IsIsAnalysis.Value = Convert.ToString(CommonEnum.RecordType.迟到);
                //this.hf_Begin.Value = ViewState["begin"].ToString();
                //this.hf_End.Value = ViewState["end"].ToString();

                // CommonFunction.BindEnum<CommonEnum.AttendType>(this.ddl_AttendType, "-2");//考勤方式
                DataTable dt = departmentDAL.GetList((int)CommonEnum.Deleted.未删除, (int)CommonEnum.DepType.职能部门);
                CommonFunction.DDlTypeBind(this.ddl_DepName, dt, "DID", "DepName", "-2");

                this.txt_SDate.Text = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).ToString("yyyy-MM");
                this.txt_EDate.Text = (DateTime.Now.AddDays(1 - DateTime.Now.Day).AddMonths(1).AddDays(-1)).ToString("yyyy-MM");
                int days = System.Threading.Thread.CurrentThread.CurrentUICulture.Calendar.GetDaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
                GetCondition();

                DataBindList();

            }
        }

        #region 获取查询条件
        public void GetCondition()
        {
            ViewState["TeaIDName"] = CommonFunction.GetCommoneString(this.txt_TeaIDName.Text.Trim());
            ViewState["begin"] = this.txt_SDate.Text == "" ? "1900-01-01" : this.txt_SDate.Text;
            ViewState["end"] = this.txt_EDate.Text == "" ? "9999-12-31" : this.txt_EDate.Text;
            ViewState["DepID"] = this.ddl_DepName.SelectedValue;
        }
        #endregion


        #region 数据绑定
        public void DataBindList()
        {
            Stopwatch sp = new Stopwatch();
            sp.Start();
            DataTable dttop = attendSetDAL.GetTableIsuse();
            sp.Stop();
            TimeSpan ts2 = sp.Elapsed;
            int a = ts2.Seconds;

            StringBuilder str = new StringBuilder("");
            str.Append("<table border='0' cellspacing='0' cellpadding='0' width='100%' class='listinfo'><tbody><tr><th align='center'>姓名</th><th align='center'>应到</th><th align='center'>实到</th><th align='center'>请假</th>");
            if (dttop != null && dttop.Rows.Count > 0)
            {
                foreach (DataRow row in dttop.Rows)
                {
                    str.AppendFormat("<th align='center'>{0}</th>", row["ATypeName"]);
                }
            }
            str.Append("</tr>");
            int recordCount = 0;
            AttendRecordEntity model = new AttendRecordEntity();
            model.UserName = ViewState["TeaIDName"].ToString();
            model.Begin = Convert.ToDateTime(ViewState["begin"].ToString());
            model.End = Convert.ToDateTime(ViewState["end"].ToString());

            Stopwatch sw = new Stopwatch();
            sw.Start();
            DataTable dt = attendRecordDAL.Analysis(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model, (int)CommonEnum.UserType.老师, Convert.ToString(ViewState["DepID"]));
            sw.Stop();
            int b = sw.Elapsed.Seconds;

            Stopwatch sw1 = new Stopwatch();
            sw1.Start();
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    str.Append("<tr>");
                    str.AppendFormat("<td>{0}</td>", dt.Rows[i]["UserName"]);
                    str.AppendFormat("<td>{0}</td>", dt.Rows[i]["YD"]);
                    str.AppendFormat("<td>{0}</td>", dt.Rows[i]["SD"]);
                    str.AppendFormat("<td>{0}</td>", dt.Rows[i]["QJ"]);
                    DataTable dtlx = attendRecordDAL.GetTableByUid(dt.Rows[i]["TID"].ToString(), Convert.ToDateTime(ViewState["begin"]).Year, Convert.ToDateTime(ViewState["begin"]).Month, Convert.ToString(ViewState["DepID"]));
                    if (dtlx != null && dtlx.Rows.Count > 0)
                    {
                        //for (int j = 0; j < dtlx.Rows.Count; j++)
                        //{
                        //    str.AppendFormat("<td tid=\"{1}\" IsAnalysis=\"{2}\" onclick=\"show(this)\" style=\"color:blue;cursor: pointer;\">{0}</td>", dtlx.Rows[j]["counts"], dt.Rows[i]["TID"], dtlx.Rows[j]["IsAnalysis"]);
                        //}
                        //if (dtlx.Rows.Count < dttop.Rows.Count)
                        //{
                        //    for (int k = 0; k < (dttop.Rows.Count - dtlx.Rows.Count); k++)
                        //    {
                        //        str.Append("<td>0</td>");
                        //    }
                        //}
                        for (int s = 0; s < dttop.Rows.Count; s++)
                        {
                            DataRow[] dr = dtlx.Select("IsAnalysis ='" + dttop.Rows[s]["AType"] + "'");
                            if (dr.Length == 0)
                            {
                                str.Append("<td>0</td>");
                            }
                            else
                            {
                                str.AppendFormat("<td tid=\"{1}\" IsAnalysis=\"{2}\" onclick=\"show(this)\" style=\"color:blue;cursor: pointer;\">{0}</td>", dr[0]["counts"], dt.Rows[i]["TID"], dr[0]["IsAnalysis"]);
                            }
                        }

                    }
                    else
                    {
                        if (dttop != null && dttop.Rows.Count > 0)
                        {
                            for (int k = 0; k < dttop.Rows.Count; k++)
                            {
                                str.Append("<td>0</td>");
                            }
                        }
                    }
                    str.Append("</tr>");
                }

            }
            else
            {
                str.Append("<tr><td>暂无记录</td></tr>");
            }
            str.Append("</tbody></table>");
            this.lbl.Text = str.ToString();
            Pager.RecordCount = recordCount;
            sw1.Stop();
            int c = sw1.Elapsed.Seconds;
        }

        #endregion


        #region 导出事件
        /// <summary>
        /// 导出事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_OutPut_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder str = new StringBuilder();
                str.Append(@"<table border='1' cellpadding='0' cellspacing='0'><tr>
                                        <th>姓名</th>
                                        <th>应到</th>
                                        <th>实到</th>
                                        <th>请假</th>");
                DataTable dttop = attendSetDAL.GetTableIsuse();
                if (dttop != null && dttop.Rows.Count > 0)
                {
                    foreach (DataRow row in dttop.Rows)
                    {
                        str.AppendFormat("<th>{0}</th>", row["ATypeName"]);
                    }
                }
                str.Append("</tr>");
                int recordCount = 0;
                AttendRecordEntity model = new AttendRecordEntity();
                model.UserName = ViewState["TeaIDName"].ToString();
                model.Begin = Convert.ToDateTime(ViewState["begin"].ToString());
                model.End = Convert.ToDateTime(ViewState["end"].ToString());
                DataTable dt = attendRecordDAL.Analysis(int.MaxValue, 1, ref recordCount, model, (int)CommonEnum.UserType.老师, Convert.ToString(ViewState["DepID"]));
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        str.Append("<tr>");
                        str.AppendFormat("<td>{0}</td>", row["UserName"]);
                        str.AppendFormat("<td>{0}</td>", row["YD"]);
                        str.AppendFormat("<td>{0}</td>", row["SD"]);
                        str.AppendFormat("<td>{0}</td>", row["QJ"]);
                        DataTable dtlx = attendRecordDAL.GetTableByUid(row["TID"].ToString(), Convert.ToDateTime(ViewState["begin"]).Year, Convert.ToDateTime(ViewState["begin"]).Month, Convert.ToString(ViewState["DepID"]));
                        if (dtlx != null && dtlx.Rows.Count > 0)
                        {
                            //for (int j = 0; j < dtlx.Rows.Count; j++)
                            //{
                            //    str.AppendFormat("<td>{0}</td>", dtlx.Rows[j]["counts"]);
                            //}
                            //if (dtlx.Rows.Count < dttop.Rows.Count)
                            //{
                            //    for (int k = 0; k < (dttop.Rows.Count - dtlx.Rows.Count); k++)
                            //    {
                            //        str.Append("<td>0</td>");
                            //    }
                            //}                          
                            for (int s = 0; s < dttop.Rows.Count; s++)
                            {
                                DataRow[] dr = dtlx.Select("IsAnalysis ='" + dttop.Rows[s]["AType"] + "'");
                                if (dr.Length == 0)
                                {
                                    str.Append("<td>0</td>");
                                }
                                else
                                {
                                    str.AppendFormat("<td>{0}</td>", dr[0]["counts"]);
                                }
                            }
                        }
                        else
                        {
                            if (dttop != null && dttop.Rows.Count > 0)
                            {
                                for (int k = 0; k < dttop.Rows.Count; k++)
                                {
                                    str.Append("<td>0</td>");
                                }
                            }
                        }
                        str.Append("</tr>");
                    }
                    str.Append("</table>");
                    CommonFunction.ExportExcel("导出考勤记录", str.ToString());
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_导出, "导出考勤记录", UserID));
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


        //设置跳转页面
        public string GetName(object tid)
        {
            string TID = tid.ToString();
            int IsAnalysis = Convert.ToInt32(CommonEnum.RecordType.迟到);
            string Begin = Convert.ToString(ViewState["begin"].ToString());
            string End = Convert.ToString(ViewState["end"].ToString());
            //string aa = string.Format("<script language=javascript>window.open('AttendRecordSelectCD.aspx?id={0}+'&IsAnalysis={1}'+'&Begin={2}'+'&End={3}'', '_self')</script>", TID, IsAnalysis, Begin, End);
            //Response.Write(aa);
            return " AttendRecordSelectCD.aspx?id=" + TID + "&IsAnalysis=" + IsAnalysis + "&Begin=" + Begin + "&End=" + End;
            //return Response.Write("<script language=javascript>window.open('AttendRecordSelectCD.aspx?id=" + TID + "&IsAnalysis="+ IsAnalysis + "&Begin=" + Begin + "&End=" + End + " ', '_self')</script>");

        }

        public string GetNameZT(object tid)
        {
            string TID = tid.ToString();
            int IsAnalysis = Convert.ToInt32(CommonEnum.RecordType.早退);
            string Begin = Convert.ToString(ViewState["begin"].ToString());
            string End = Convert.ToString(ViewState["end"].ToString());

            return " AttendRecordSelectCD.aspx?id=" + TID + "&IsAnalysis=" + IsAnalysis + "&Begin=" + Begin + "&End=" + End;

        }

    }
}