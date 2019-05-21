/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2016年11月17日 16时35分19秒
** 描    述:      教学楼管理页面
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

namespace ICMP.assetmanage
{
    public partial class TBuildingManage : PageBase
    {
        public BuildingDAL buildingDAL = new BuildingDAL();
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
            ViewState["BName"] = CommonFunction.GetCommoneString(this.txt_BName.Text.ToString().Trim());
        }
        #endregion


        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {
            int recordCount = -1;
            BuildingEntity model = new BuildingEntity((string)ViewState["BName"], -2, (int)CommonEnum.Deleted.未删除, (int)CommonEnum.BuildingType.教学楼);
            DataTable dt = buildingDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
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
                int result = buildingDAL.DeleteBat(ids, (int)CommonEnum.Deleted.删除);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除教学楼信息", UserID));
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
            BuildingEntity model = new BuildingEntity(ViewState["BName"].ToString(),-2, Convert.ToInt32(CommonEnum.Deleted.未删除),Convert .ToInt32( CommonEnum.BuildingType.教学楼));
            DataTable dt = buildingDAL.GetPaged(9999999, 1, ref recordCount, model);
            if (dt == null || dt.Rows.Count == 0)
            {
                ShowMessage("暂无数据导出！");
                return;
            }
            str.Append(@"<table border='1' cellpadding='0' cellspacing='0' >
                                     <tr>
                                        <th><strong>教学楼名称</strong></th>
                                        <th><strong>教学楼代码</strong></th>
                                        <th><strong>所属校区</strong></th>
                                        <th><strong>层数</strong></th>
                                        <th><strong>总面积</strong></th>
                                        <th><strong>地址</strong></th>
                                        <th><strong>排序</strong></th>
                                        <th><strong>状态</strong></th></tr>");
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    str.Append("<tr>");
                    str.AppendFormat("<td>{0}</td>", row["BName"]);
                    str.AppendFormat("<td>{0}</td>", row["BNumber"]);
                    str.AppendFormat("<td>{0}</td>", row["CampusName"]);
                    str.AppendFormat("<td>{0}</td>", row["FloorNum"]);
                    str.AppendFormat("<td>{0}</td>", row["AllBuilding"]);
                    str.AppendFormat("<td>{0}</td>", row["BAddress"]);
                    str.AppendFormat("<td>{0}</td>", row["BOrder"]);
                    str.AppendFormat("<td>{0}</td>", GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.BState>(row["BState"]));
                    str.Append("</tr>");
                }
            }
            CommonFunction.ExportExcel("教学楼信息", str.ToString());
            sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_导出, "导出教学楼信息",UserID));
        }
        #endregion
    }
}