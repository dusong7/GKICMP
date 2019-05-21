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
using GKICMP.localhost1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Text;
using System.Configuration;

namespace GKICMP.purchase
{
    public partial class PurchaseTender : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public Project_TenderDAL project_TenderDAL = new Project_TenderDAL();
        public AccessoryDAL accessoryDAL = new AccessoryDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCondition();
                DataBindList();
            }
        }
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
            GK.GKICMP.Entities.Project_TenderEntity model = new GK.GKICMP.Entities.Project_TenderEntity();
            model.PID = (string)ViewState["GName"];
            model.Isdel = (int)CommonEnum.Deleted.未删除;
            DataTable dt = project_TenderDAL.GetPagedByPurchase(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
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
                int result = project_TenderDAL.DeleteBat(ids, (int)CommonEnum.Deleted.删除);
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
            GK.GKICMP.Entities.Project_TenderEntity model = new GK.GKICMP.Entities.Project_TenderEntity();
            model.PID = (string)ViewState["GName"];
            model.Isdel = (int)CommonEnum.Deleted.未删除;

            DataTable dt = project_TenderDAL.GetPaged(9999999, 1, ref recordCount, model);
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


        #region 上报 --单条
        protected void lbtn_SB_Click(object sender, EventArgs e)
        {
            try
            {
                localhost1.WebService1 service = new localhost1.WebService1();
                service.Url = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "ServerUrl") + "/WebService1.asmx";
                LinkButton lbtn = (LinkButton)sender;
                string id = lbtn.CommandArgument.ToString();
                string aa = "";
                List<GKICMP.localhost1.TenderReport> args = new List<GKICMP.localhost1.TenderReport>();

                for (int i = 0; i < id.Split(',').Length; i++)
                {
                    GKICMP.localhost1.TenderReport modelReport = new localhost1.TenderReport();
                    GKICMP.localhost1.Project_TenderEntity model = new localhost1.Project_TenderEntity();
                    List<GKICMP.localhost1.AccessoryEntity> pub = new List<GKICMP.localhost1.AccessoryEntity>();

                    GK.GKICMP.Entities.Project_TenderEntity p = project_TenderDAL.GetObjByID(id.Split(',')[i]);

                    #region 附件上传


                    DataTable dt = accessoryDAL.GetList((int)CommonEnum.AccessoryType.Tb_Tender, p.FileID);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            GKICMP.localhost1.AccessoryEntity Accessory = new localhost1.AccessoryEntity();
                            Byte[] b = CommonFunction.File2Bytes(dr["AccessUrl"].ToString());
                            service.SaveFile(b, dr["AccessUrl"].ToString());
                            Accessory.AccessID = dr["AccessID"].ToString();
                            Accessory.AccessName = dr["AccessName"].ToString();
                            Accessory.AccessUrl = dr["AccessUrl"].ToString();
                            Accessory.AccessObjID = dr["AccessObjID"].ToString();
                            Accessory.AccessFlag = int.Parse(dr["AccessFlag"].ToString());
                            Accessory.AOrder = int.Parse(dr["AOrder"].ToString());
                            Accessory.ObjID = dr["ObjID"].ToString();
                            pub.Add(Accessory);
                        }
                    }
                    #endregion

                    model.PTID = p.PTID;//
                    model.PID = p.PID;//项目id
                    model.SID = p.SID;//供应商id
                    model.BAmount = p.BAmount;//中标金额
                    model.BDate = p.BDate;//中标日期
                    model.BSDate = p.BSDate;//开始实施日期
                    model.BEDate = p.BEDate;//结束日期
                    model.Bond = p.Bond;//保证金
                    model.BondDate = p.BondDate;//保证金日期
                    model.BondBackDate = p.BondBackDate;
                    // model.IsReturn = model.IsReturn;//
                    model.CreateUser = p.CreateUserName;//创建人
                    model.CreateDate = p.CreateDate;//创建时间
                    model.PTDesc = p.PTDesc;//备注
                    model.Isdel = p.Isdel;//是否删除
                    model.BidNumber = p.BidNumber;//招标编号


                    modelReport.Tender = model;
                    modelReport.Accessory = pub.ToArray();

                    args.Add(modelReport);
                }
                //service.Url = ConfigurationManager.AppSettings["URL"] + "/WebService1.asmx";
                string sguid = ConfigurationManager.AppSettings["SGUID"];
                //service.Show("1", "2", out aa);
                GKICMP.localhost1.TenderReport[] A = args.ToArray();
                if (service.TenderReport(sguid, A, out aa))
                {
                    int rusult = project_TenderDAL.Update(id);
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

        #region 多条上报 --测试完成
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
                //List<GKICMP.localhost1.Project_TenderEntity> args = new List<GKICMP.localhost1.Project_TenderEntity>();
                List<GKICMP.localhost1.TenderReport> args = new List<GKICMP.localhost1.TenderReport>();
                for (int i = 0; i < id.Split(',').Length; i++)
                {
                    GKICMP.localhost1.TenderReport modelReport = new localhost1.TenderReport();
                    GKICMP.localhost1.Project_TenderEntity model = new localhost1.Project_TenderEntity();
                    List<GKICMP.localhost1.AccessoryEntity> pub = new List<GKICMP.localhost1.AccessoryEntity>();

                    GK.GKICMP.Entities.Project_TenderEntity p = project_TenderDAL.GetObjByID(id.Split(',')[i]);

                    #region 附件上传


                    DataTable dt = accessoryDAL.GetList((int)CommonEnum.AccessoryType.Tb_Tender, p.FileID);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            GKICMP.localhost1.AccessoryEntity Accessory = new localhost1.AccessoryEntity();
                            Byte[] b = CommonFunction.File2Bytes(dr["AccessUrl"].ToString());
                            service.SaveFile(b, dr["AccessUrl"].ToString());
                            Accessory.AccessID = dr["AccessID"].ToString();
                            Accessory.AccessName = dr["AccessName"].ToString();
                            Accessory.AccessUrl = dr["AccessUrl"].ToString();
                            Accessory.AccessObjID = dr["AccessObjID"].ToString();
                            Accessory.AccessFlag = int.Parse(dr["AccessFlag"].ToString());
                            Accessory.AOrder = int.Parse(dr["AOrder"].ToString());
                            Accessory.ObjID = dr["ObjID"].ToString();
                            pub.Add(Accessory);
                        }
                    }
                    #endregion

                    model.PTID = p.PTID;//
                    model.PID = p.PID;//项目id
                    model.SID = p.SID;//供应商id
                    model.BAmount = p.BAmount;//中标金额
                    model.BDate = p.BDate;//中标日期
                    model.BSDate = p.BSDate;//开始实施日期
                    model.BEDate = p.BEDate;//结束日期
                    model.Bond = p.Bond;//保证金
                    model.BondDate = p.BondDate;//保证金日期
                    model.BondBackDate = p.BondBackDate;
                    // model.IsReturn = model.IsReturn;//
                    model.CreateUser = p.CreateUserName;//创建人
                    model.CreateDate = p.CreateDate;//创建时间
                    model.PTDesc = p.PTDesc;//备注
                    model.Isdel = p.Isdel;//是否删除
                    model.BidNumber = p.BidNumber;//招标编号


                    modelReport.Tender = model;
                    modelReport.Accessory = pub.ToArray();

                    args.Add(modelReport);
                    //GK.GKICMP.Entities.Project_TenderEntity p = project_TenderDAL.GetObjByID(id.Split(',')[i]);
                    //GKICMP.localhost1.Project_TenderEntity model = new localhost1.Project_TenderEntity();
                    //model.PTID = p.PTID;//
                    //model.PID = p.PID;//项目id
                    //model.SID = p.SID;//供应商id
                    //model.BAmount = p.BAmount;//中标金额
                    //model.BDate = p.BDate;//中标日期
                    //model.BSDate = p.BSDate;//开始实施日期
                    //model.BEDate = p.BEDate;//结束日期
                    //model.Bond = p.Bond;//保证金
                    //model.BondDate = p.BondDate;//保证金日期
                    //model.BondBackDate = p.BondBackDate;
                    //// model.IsReturn = model.IsReturn;//
                    //model.CreateUser = p.CreateUserName;//创建人
                    //model.CreateDate = p.CreateDate;//创建时间
                    //model.PTDesc = p.PTDesc;//备注
                    //model.Isdel = p.Isdel;//是否删除
                    //model.BidNumber = p.BidNumber;//招标编号
                    //args.Add(model);
                }
                //service.Url = ConfigurationManager.AppSettings["URL"] + "/WebService1.asmx";
                string sguid = ConfigurationManager.AppSettings["SGUID"];
                //service.Show("1", "2", out aa);
                //GKICMP.localhost1.Project_TenderEntity[] A = args.ToArray();
                //if (service.ProTender(sguid, A, out aa))
                //{
                //    int rusult = project_TenderDAL.Update(id);
                //    ShowMessage(aa);
                //    DataBindList();
                //}
                GKICMP.localhost1.TenderReport[] A = args.ToArray();
                if (service.TenderReport(sguid, A, out aa))
                {
                    int rusult = project_TenderDAL.Update(id);
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