/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月12日 09点30分
** 描   述:       学生活动列表页面
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;
using System.Web.UI.WebControls;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;


namespace GKICMP.schoolwork
{
    public partial class StudentActManage : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public StudentActivityDAL studentActivityDAL = new StudentActivityDAL();
        public SysDataDAL sysDataDAL = new SysDataDAL();


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = sysDataDAL.GetList((int)CommonEnum.Deleted.未删除, (int)CommonEnum.DataType.学生活动类型);
                CommonFunction.DDlTypeBind(this.ddl_ActType, dt, "SDID", "DataName", "-2");
                GetCondition();
                DataBindList();
            }
        }
        #endregion


        #region 获取查询条件
        public void GetCondition()
        {
            ViewState["ActName"] = CommonFunction.GetCommoneString(this.txt_ActName.Text.ToString().Trim());
            ViewState["ActType"] = this.ddl_ActType.SelectedValue.ToString();
            ViewState["BeginDate"] = this.txt_BeginDate.Text == "" ? "1900-01-01" : this.txt_BeginDate.Text.ToString().Trim();
            ViewState["EndDate"] = this.txt_EndDate.Text == "" ? "9999-12-31" : this.txt_EndDate.Text.ToString().Trim();
        }
        #endregion


        #region 数据绑定
        public void DataBindList()
        {
            int recordCount = 0;
            StudentActivityEntity model = new StudentActivityEntity();
            model.ActName = ViewState["ActName"].ToString();
            model.ActType = Convert.ToInt32(ViewState["ActType"].ToString());
            DateTime begin = Convert.ToDateTime(ViewState["BeginDate"].ToString());
            DateTime end = Convert.ToDateTime(ViewState["EndDate"].ToString());
            model.Isdel = (int)CommonEnum.IsorNot.否;
            DataTable dt = studentActivityDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model, begin, end);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.tr_null.Visible = false;
            }
            else
            {
                this.tr_null.Visible = true;
            }
            rp_List.DataSource = dt;
            Pager.RecordCount = recordCount;
            rp_List.DataBind();
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


        #region 删除
        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                string ids = this.hf_CheckIDS.Value.TrimEnd(',');
                int result = studentActivityDAL.DeleteByID(ids, (int)CommonEnum.Deleted.删除);
                if (result > 0)
                {
                    ShowMessage("删除成功");
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除学生活动信息", UserID));
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
            }
        }
        #endregion


        #region 分页
        public void Pager_PageChanged(object sender, EventArgs e)
        {
            DataBindList();
        }
        #endregion


        #region 添加跳转页面
        protected void btn_Add_Click(object sender, EventArgs e)
        {
            string aa = string.Format("<script language=javascript>window.open('StudentActEdit.aspx', '_self')</script>");
            Response.Write(aa);
        }
        #endregion


        #region 编辑跳转页面
        protected void lbtn_Edit_Click(object sender, EventArgs e)
        {
            LinkButton lbt = (LinkButton)sender;
            string said = lbt.CommandArgument.ToString();
            string aa = string.Format("<script language=javascript>window.open('StudentActEdit.aspx?id={0}', '_self')</script>", said);
            Response.Write(aa);
        }
        #endregion


        #region 发布事件
        protected void btn_Publish_Click(object sender, EventArgs e)
        {
            try
            {
                string ids = this.hf_CheckIDS.Value.ToString();
                if (ids == "")
                {
                    ShowMessage("请至少选择一条信息");
                    return;
                }
                ids = ids.TrimEnd(',').TrimStart(',');
                int result = studentActivityDAL.ActPublish(ids, (int)CommonEnum.IsorNot.是);
                if (result > 0)
                {
                    ShowMessage("发布成功");
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "发布学生活动记录信息", UserID));
                }
                else
                {
                    ShowMessage("发布失败");
                    return;
                }
                DataBindList();
                this.hf_CheckIDS.Value = "";
            }
            catch (Exception ex)
            {
                ShowMessage();
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                return;
            }
        }
        #endregion
    }
}