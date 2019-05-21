/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月08日 09点30分
** 描   述:       学生考场座位表管理
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;
using System.Text;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.educational
{
    public partial class SeatingSequenceManage : PageBase
    {
        public Exam_RoomDAL roomDAL = new Exam_RoomDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();


        #region 参数集合
        public int EID
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
                ViewState["kch"] = "-2";
                DdlBind();
                GetCondition();
                DataBindList();
            }
        }
        #endregion


        #region 下拉框绑定
        public void DdlBind()
        {
            ExamEntity model = new ExamEntity();
            model.EID = EID;
            DataTable dt = roomDAL.UpdateZWH(model, -2);
            if (dt != null && dt.Rows.Count > 0)
            {
                CommonFunction.DDlTypeBind(this.ddl_kch, dt, "KCH", "KCHName", "-2");
            }
            else
            {
                CommonFunction.DDlTypeBind(this.ddl_kch, dt, "", "", "-2");
            }
            this.ddl_kch.SelectedValue = ViewState["kch"].ToString();
        }
        #endregion


        #region 获取查询条件
        public void GetCondition()
        {
            ViewState["kch"] = this.ddl_kch.SelectedValue;
        }
        #endregion


        #region 查询
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            GetCondition();
            DataBindList();
        }
        #endregion


        #region 绑定数据
        public void DataBindList()
        {
            Pager.PageSize = 15;
            int recordCount = 0;
            ExamEntity model = new ExamEntity();
            model.EID = EID;
            DataTable dt = roomDAL.GetPageZWH(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model, Convert.ToInt32(ViewState["kch"].ToString()));
            if (dt.Rows.Count > 0 && dt != null)
            {
                this.tr_null.Visible = false;
            }
            else
            {
                this.btn_OutPut.Visible = false;
                this.btn_OutPutWord.Visible = false;
                this.tr_null.Visible = true;
            }
            this.rp_List.DataSource = dt;
            Pager.RecordCount = recordCount;
            this.rp_List.DataBind();
            DdlBind();
            this.hf_CheckIDS.Value = "";
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
                StringBuilder str = new StringBuilder();
                str.Append("<table border='1' cellspacing='0' cellpadding='0'><tr><th>姓名</th><th>班级</th><th>考场号</th><th>座位号</th></tr>");
                int recordCount = 0;
                ExamEntity model = new ExamEntity();
                model.EID = EID;
                DataTable dt = roomDAL.GetPageZWH(int.MaxValue, 1, ref recordCount, model, Convert.ToInt32(ViewState["kch"].ToString()));
                if (dt.Rows.Count > 0 && dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        str.Append("<tr>");
                        str.AppendFormat("<td>{0}</td>", row["UIDName"]);
                        str.AppendFormat("<td>{0}</td>", row["ClassName"]);
                        str.AppendFormat("<td>{0}</td>", "第" + row["KCH"].ToString() + "考场");
                        str.AppendFormat("<td style='text-align:center;'>{0}</td>", row["ERID"].ToString());
                        str.Append("</tr>");
                    }
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_导出, "导出Excel座位表数据", UserID));
                    CommonFunction.ExportExcel("考场座位表", str.ToString());
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


        #region 导出Word
        protected void btn_OutPutWord_Click(object sender, EventArgs e)
        {
            try
            {
                ExamEntity model1 = new ExamEntity();
                model1.EID = EID;
                DataTable dt1 = new DataTable("All");
                dt1 = roomDAL.UpdateZWH(model1, Convert.ToInt32(this.ddl_kch.SelectedValue));
                if (dt1 != null && dt1.Rows.Count > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_导出, "导出Word座位表数据", UserID));
                    CommonFunction.ImportWordKCZWB(dt1, "../Template/KCZWB.doc", "座位表" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".doc", EID);
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
    }
}