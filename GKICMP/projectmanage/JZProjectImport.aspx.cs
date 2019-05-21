/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年05月17日 09点30分
** 描   述:      招标详情
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;

namespace GKICMP.projectmanage
{
    public partial class JZProjectImport : PageBase
    {
        public JZProjectManageDAL jzprojectManageDAL = new JZProjectManageDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public AssetDAL assetDAL = new AssetDAL();
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
            JZProjectManageEntity model = new JZProjectManageEntity();
            model.ProName = (string)ViewState["GName"];
            model.Isdel = (int)CommonEnum.Deleted.未删除;
            DataTable dt = jzprojectManageDAL.GetPagedByImprot(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
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
                int result = jzprojectManageDAL.DeleteBat(ids, (int)CommonEnum.Deleted.删除);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除教装项目申报", UserID));
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
            JZProjectManageEntity model = new JZProjectManageEntity();
            model.ProName = (string)ViewState["GName"];
            model.Isdel = (int)CommonEnum.Deleted.未删除;
            model.State = -2;
            model.ProType = -2;
            model.Financed = -2;
            DataTable dt = jzprojectManageDAL.GetPaged(2000, 1, ref recordCount, model, Convert.ToDateTime("1900-12-31"), Convert.ToDateTime("3000-12-31"));
            if (dt == null || dt.Rows.Count == 0)
            {
                ShowMessage("暂无数据导出！");
                return;
            }
            str.Append(@"<table border='1' cellpadding='0' cellspacing='0' >
                                     <tr>
                                        <th><strong>项目名称</strong></th>
                                        <th><strong>项目概算</strong></th>
                                        <th><strong>资金来源</strong></th>
                                        <th><strong>项目类型</strong></th>
                                        <th><strong>项目内容</strong></th>
                                        <th><strong>申报时间</strong></th>
                                        <th><strong>审核状态</strong></th>
                                        <th><strong>上报状态</strong></th>
                                     </tr>");
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    str.Append("<tr>");
                    str.AppendFormat("<td>{0}</td>", row["ProName"]);
                    str.AppendFormat("<td>{0}</td>", row["ProBudget"]);
                    str.AppendFormat("<td>{0}</td>", GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.BSources>(row["Financed"]));
                    str.AppendFormat("<td>{0}</td>", row["ProTypeName"]);
                    str.AppendFormat("<td>{0}</td>", row["ProContentName"]);
                    str.AppendFormat("<td>{0}</td>", DateTime.Parse(row["ProDate"].ToString()).ToString("yyyy-MM-dd"));
                    if (Convert.ToString(row["State"]) == "0")
                    {
                        str.AppendFormat("<td>{0}</td>", "已驳回");
                    }
                    else if (Convert.ToString(row["State"]) == "1")
                    {
                        str.AppendFormat("<td>{0}</td>", "未审核");
                    }
                    else if (Convert.ToString(row["State"]) == "2")
                    {
                        str.AppendFormat("<td>{0}</td>", "已通过");
                    }
                    else
                    {
                        str.AppendFormat("<td>{0}</td>", "待修改");
                    }

                    if (Convert.ToString(row["PType"]) == "1")
                    {
                        str.AppendFormat("<td>{0}</td>", "已上报");
                    }
                    else
                    {
                        str.AppendFormat("<td>{0}</td>", "未上报");
                    }

                    str.Append("</tr>");
                }
            }
            CommonFunction.ExportExcel("教装项目申报", str.ToString());
            sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_导出, "导出教装项目申报", UserID));

        }
        #endregion

        #region 单条上报
        protected void lbtn_SB_Click(object sender, EventArgs e)
        {
            try
            {
                localhost1.WebService1 service = new localhost1.WebService1();
                service.Url = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "ServerUrl") + "/WebService1.asmx";
                LinkButton lbtn = (LinkButton)sender;
                string id = lbtn.CommandArgument.ToString();
                string aa = "";
                List<GKICMP.localhost1.AssetEntity> args = new List<GKICMP.localhost1.AssetEntity>();
                for (int i = 0; i < id.Split(',').Length; i++)
                {
                    //DataTable dt = assetDAL.GetListByPID(id.Split(',')[i],(int)CommonEnum.Deleted.未删除);
                    DataTable dt = assetDAL.GetPID(id.Split(',')[i], (int)CommonEnum.Deleted.未删除);//获取供货清单里 根据PID来查询未上报资产
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        for (int t = 0; t < dt.Rows.Count; t++)
                        {
                            GKICMP.localhost1.AssetEntity model = new localhost1.AssetEntity();
                            model.AID = dt.Rows[t]["AID"].ToString();
                            model.PID = dt.Rows[t]["PID"].ToString();
                            model.DataDesc = dt.Rows[t]["DataDesc"].ToString();
                            model.AssetName = dt.Rows[t]["AssetName"].ToString();
                            model.DataType = Convert.ToInt32(dt.Rows[t]["DataType"].ToString());
                            model.APrice = Convert.ToDecimal(dt.Rows[t]["APrice"].ToString());
                            model.Brand = dt.Rows[t]["Brand"].ToString();
                            model.BuyDate = Convert.ToDateTime(dt.Rows[t]["BuyDate"].ToString());
                            model.SpecificationModel = dt.Rows[t]["SpecificationModel"].ToString();
                            model.Suppliers = dt.Rows[t]["Suppliers"].ToString();
                            model.CreateUser = dt.Rows[t]["CreateUser"].ToString();
                            model.AssetNum = Convert.ToInt32(dt.Rows[t]["AssetNum"].ToString());
                            model.Isdel = (int)CommonEnum.IsorNot.否;


                            model.PlanYear = dt.Rows[t]["PlanYear"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[t]["PlanYear"].ToString());
                            model.AssetMark = dt.Rows[t]["AssetMark"].ToString();
                            model.AUnitName = dt.Rows[t]["AUnitName"].ToString();//计量单位名称
                            //在验收管理前 供货清单里的资产肯定没有验收
                            model.Flag = 0; // 是否验收：0  否 ，1 是  对应区平台的flag字段 ,验收管理验收成功后区平台自动更新为1

                            args.Add(model);
                        }

                    }
                }

                string sguid = ConfigurationManager.AppSettings["SGUID"];
                //service.Show("1", "2", out aa);
                GKICMP.localhost1.AssetEntity[] A = args.ToArray();
                if (service.AssetManage(sguid, A, out aa))
                {
                    int rusult = assetDAL.UpdateByPIDs(id); //PID
                    ShowMessage(aa);
                    DataBindList();
                }
                else
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, aa, UserID));
                }
            }
            catch (Exception ex)
            {
                ShowMessage("请配置区平台网址");
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志

                    , ex.Message, UserID));
            }

        }
        #endregion

        #region 多条上报--测试完成
        protected void lbtn_MoreSB_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.hf_CheckIDS.Value == "")
                {
                    ShowMessage("请至少选择一条记录");
                    return;
                }
                localhost1.WebService1 service = new localhost1.WebService1();
                service.Url = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "ServerUrl") + "/WebService1.asmx";
                string id = "";
                id = this.hf_CheckIDS.Value.ToString();
                id = id.TrimEnd(',').TrimStart(',');
                string aa = "";
                List<GKICMP.localhost1.AssetEntity> args = new List<GKICMP.localhost1.AssetEntity>();
                for (int i = 0; i < id.Split(',').Length; i++)
                {
                    //DataTable dt = assetDAL.GetListByPID(id.Split(',')[i], (int)CommonEnum.Deleted.未删除);
                    DataTable dt = assetDAL.GetPID(id.Split(',')[i], (int)CommonEnum.Deleted.未删除);//获取供货清单里 根据PID来查询未上报资产
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        for (int t = 0; t < dt.Rows.Count; t++)
                        {
                            GKICMP.localhost1.AssetEntity model = new localhost1.AssetEntity();
                            model.AID = dt.Rows[t]["AID"].ToString();
                            model.PID = dt.Rows[t]["PID"].ToString();
                            model.DataDesc = dt.Rows[t]["DataDesc"].ToString();
                            model.AssetName = dt.Rows[t]["AssetName"].ToString();
                            model.DataType = Convert.ToInt32(dt.Rows[t]["DataType"].ToString());
                            model.APrice = Convert.ToDecimal(dt.Rows[t]["APrice"].ToString());
                            model.Brand = dt.Rows[t]["Brand"].ToString();
                            model.BuyDate = Convert.ToDateTime(dt.Rows[t]["BuyDate"].ToString());
                            model.SpecificationModel = dt.Rows[t]["SpecificationModel"].ToString();
                            model.Suppliers = dt.Rows[t]["Suppliers"].ToString();
                            model.CreateUser = dt.Rows[t]["CreateUser"].ToString();
                            model.AssetNum = Convert.ToInt32(dt.Rows[t]["AssetNum"].ToString());
                            model.Isdel = (int)CommonEnum.IsorNot.否;

                            model.PlanYear = Convert.ToInt32(dt.Rows[t]["PlanYear"].ToString());
                            model.AssetMark = dt.Rows[t]["AssetMark"].ToString();
                            model.AUnitName = dt.Rows[t]["AUnitName"].ToString();//计量单位名称
                            //在验收管理 前供货清单里的资产肯定没有验收
                            model.Flag = 0; // 是否验收：0  否 ，1 是  对应区平台的flag字段 ,验收管理验收成功后区平台自动更新为1


                            args.Add(model);
                        }
                    }

                }

                string sguid = ConfigurationManager.AppSettings["SGUID"];
                //service.Show("1", "2", out aa);
                GKICMP.localhost1.AssetEntity[] A = args.ToArray();
                if (service.AssetManage(sguid, A, out aa))
                {
                    int rusult = assetDAL.UpdateByPIDs(id);//PID
                    ShowMessage(aa);
                    DataBindList();
                }
                else
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, aa, UserID));
                }
            }
            catch (Exception ex)
            {
                ShowMessage("请配置区平台网址");
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
            }

        }
        #endregion

        #region 判断复选框是否可用
        /// <summary>
        /// 判断复选框是否可用
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public string GetState(object state)
        {
            string sstate = state.ToString();
            if (sstate == "1")
            {
                return "disabled";
            }
            else
            {
                return "";
            }
        }
        #endregion
    }
}