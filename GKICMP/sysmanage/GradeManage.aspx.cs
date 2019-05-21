/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      崔壮壮
** 创建日期:      2017年2月27日 16时35分19秒
** 描    述:      年级管理页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Text;
using System.Data;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.sysmanage
{
    public partial class GradeManage : PageBase
    {
        public GradeDAL gradeDAL = new GradeDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
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
                GetCondition();
                DataBindList();
            }
        }
        #endregion


        #region 获取查询条件
        /// <summary>
        /// 获取查询条件
        /// </summary>
        private void GetCondition()
        {
            ViewState["GName"] = CommonFunction.GetCommoneString(this.txt_GName.Text.ToString().Trim());
        }
        #endregion


        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {
            int recordCount = -1;
            GradeEntity model = new GradeEntity();
            model.GradeName = (string)ViewState["GName"];
            model.Isdel = (int)CommonEnum.Deleted.未删除;
            DataTable dt = gradeDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
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
            rp_List.DataBind();
            this.hf_CheckIDS.Value = "";
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


        #region 查询事件
        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            Pager.CurrentPageIndex = 1;
            GetCondition();
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
                string ids = this.hf_CheckIDS.Value.ToString();
                ids = ids.TrimEnd(',').TrimStart(',');
                int result = gradeDAL.DeleteBat(ids, (int)CommonEnum.Deleted.删除);
                if (result > 0)
                {
                    SysLogEntity log = new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除班级信息", UserID);
                    sysLogDAL.Edit(log);
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
                ShowMessage(ex.Message);
                return;
            }
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
            int recordCount = -1;
            StringBuilder str = new StringBuilder();
            GradeEntity model = new GradeEntity();
            model.GradeName = (string)ViewState["GName"];
            model.Isdel = (int)CommonEnum.Deleted.未删除;

            DataTable dt = gradeDAL.GetPaged(9999999, 1, ref recordCount, model);
            if (dt == null || dt.Rows.Count == 0)
            {
                ShowMessage("暂无数据导出！");
                return;
            }
            str.Append(@"<table border='1' cellpadding='0' cellspacing='0' >
                                     <tr>
                                        <th><strong>年级名称</strong></th>
                                        <th><strong>当前简称</strong></th>
                                        <th><strong>入学年份</strong></th>
                                        <th><strong>是否毕业</strong></th>
                                        <th><strong>年级负责人</strong></th>
                                        <th><strong>创建日期</strong></th></tr>");
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    str.Append("<tr>");
                    str.AppendFormat("<td>{0}</td>", row["GradeName"]);
                    str.AppendFormat("<td>{0}</td>", row["ShortName"]);
                    str.AppendFormat("<td>{0}</td>", row["GradeYear"]);
                    str.AppendFormat("<td>{0}</td>", GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.IsorNot>(row["IsGraduate"]));
                    str.AppendFormat("<td>{0}</td>", row["AcceptUserName"]);
                    str.AppendFormat("<td>{0}</td>", row["CreateDate"]);

                    str.Append("</tr>");
                }
            }
            CommonFunction.ExportExcel("年级信息", str.ToString());
            sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_导出, "导出年级信息", UserID));

        }
        #endregion
    }
}