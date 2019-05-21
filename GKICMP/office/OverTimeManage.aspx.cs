/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      殷志瑞
** 创建日期:    20177214日
** 描 述:       作业布置管理页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;

namespace GKICMP.office
{
    public partial class OverTimeManage : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public HomeWorkDAL homeWorkDAL = new HomeWorkDAL();
        public CourseDAL courseDAL = new CourseDAL();
        public OverTimeDAL overTimeDAL = new OverTimeDAL();

        #region 参数集合
        /// <summary>
        /// Flag==1 我的 else  全部
        /// </summary>
        public int Flag
        {
            get
            {
                return GetQueryString<int>("flag", 0);
            }
        }
        #endregion

        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //flag==1 我的
                if (Flag == 1)
                {
                    this.txt_ApplyUser.Text = UserRealName;
                    this.txt_ApplyUser.Enabled = false;
                    this.btn_OutPut.Visible = false;
                }
                else
                {
                    this.btn_Add.Visible = false;
                    this.btn_Delete.Visible = false;
                }
                
                CommonFunction.BindEnum<CommonEnum.AduitState>(this.ddl_OState, "-2");
                //CommonFunction.BindEnum<CommonEnum.IsorNot>(this.ddl_IsSend, "-2");
                GetCondition();
                DataBindList();
            }
        }
        #endregion


        #region 获取查询条件
        public void GetCondition()
        {
            //ViewState["CID"] = this.ddl_CID.SelectedValue;
            ViewState["ApplyUser"] = this.txt_ApplyUser.Text;

            ViewState["BeginDate"] = this.txt_BeginDate.Text == "" ? "1900-01-01 00:00" : this.txt_BeginDate.Text + " 00:00";
            ViewState["EndDate"] = this.txt_EndDate.Text == "" ? "9999-12-31 23:59" : this.txt_EndDate.Text + " 23:59";
        }
        #endregion


        #region 数据绑定
        public void DataBindList()
        {
            int recordCount = 0;
            OverTimeEntity model = new OverTimeEntity();
            model.ApplyUser = ViewState["ApplyUser"].ToString();
            model.OState = int.Parse(this.ddl_OState.SelectedValue);
            DataTable dt = overTimeDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model, Convert.ToDateTime(ViewState["BeginDate"].ToString()), Convert.ToDateTime(ViewState["EndDate"].ToString()));
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


        #region 查询
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            Pager.CurrentPageIndex = 1;
            GetCondition();
            DataBindList();
        }
        #endregion


        #region 分页
        public void Pager_PageChanged(object sender, EventArgs e)
        {
            DataBindList();
        }
        #endregion


        #region 删除
        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                string ids = this.hf_CheckIDS.Value.TrimEnd(',');
                int result = overTimeDAL.DeleteBat(ids);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除加班信息", UserID));
                    ShowMessage("删除成功");
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
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                ShowMessage(ex.Message);
            }
        }
        #endregion

        protected void btn_OutPut_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();

                if (this.hf_CheckIDS.Value == "")
                {
                    int recordCount = 0;
                    OverTimeEntity model = new OverTimeEntity();
                    model.ApplyUser = ViewState["ApplyUser"].ToString();
                    model.OState = int.Parse(this.ddl_OState.SelectedValue);
                    dt = overTimeDAL.GetPaged(2000, 1, ref recordCount, model, Convert.ToDateTime(ViewState["BeginDate"].ToString()), Convert.ToDateTime(ViewState["EndDate"].ToString()));

                }
                else
                {
                    dt = overTimeDAL.GetList(this.hf_CheckIDS.Value.Trim(','));
                }
                string schoolname = ConfigurationManager.AppSettings["SchoolName"];
                if (dt.Rows.Count > 0)
                {
                    DataTable leave = new DataTable("All");
                    //source.Columns.Add("")
                    leave.Columns.Add("申请人", typeof(string));
                    leave.Columns.Add("加班时长", typeof(string));
                    leave.Columns.Add("开始日期", typeof(string));
                    //leave.Columns.Add("结束日期", typeof(string));
                    leave.Columns.Add("加班类型", typeof(string));
                    leave.Columns.Add("参与人员", typeof(string));
                    foreach (DataRow dr in dt.Rows)
                    {
                        List<string> list = new List<string>();
                        list.Add(dr["ApplyUserName"].ToString());
                        list.Add(dr["ODay"].ToString() + "天");
                        list.Add(dr["BeginDate"].ToString() == "" ? "" : Convert.ToDateTime(dr["BeginDate"]).ToString("yyyy-MM-dd"));
                        //list.Add(dr["EndDate"].ToString() == "" ? "" : Convert.ToDateTime(dr["EndDate"]).ToString("yyyy-MM-dd"));
                        list.Add(dr["OTypeName"].ToString());
                        list.Add(dr["UsersName"].ToString());
                        leave.Rows.Add(list.ToArray());
                    }
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, "导出教师加班申请记录信息", UserID));
                    CommonFunction.ExportByWeb(leave, schoolname + "加班申请记录", "加班申请记录" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");
                    //ExportWord.ImportWord(leave, "../Template/Leave.docx", "教师请假列表" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".doc", new SysSetConfigEntity());
                   
                }
                else
                {
                    ShowMessage("暂无数据导出，请选择时间段");
                    return;
                }
            }
            catch (Exception ex)
            {
                ShowMessage("导出失败" + ex.Message);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                return;
            }
        }
    }
}