
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

namespace GKICMP.purchase
{
    public partial class PurchaseListMine : PageBase
    {
        public PurchaseDAL purchaseDAL = new PurchaseDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public Purchase_BillDAL purchase_BillDAL = new Purchase_BillDAL();
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
                this.txt_Begin.Text = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).ToString("yyyy-MM-dd");
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
            ViewState["GName"] = CommonFunction.GetCommoneString(this.txt_PTitle.Text.ToString().Trim());
            ViewState["begin"] = this.txt_Begin.Text == "" ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).ToString() : this.txt_Begin.Text;  //开始时间
            ViewState["end"] = this.txt_End.Text == "" ? "9999-12-31" : this.txt_End.Text;     //结束时间
        }
        #endregion


        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {
            int recordCount = -1;
            PurchaseEntity model = new PurchaseEntity();
            model.PTitle = (string)ViewState["GName"];
            model.Isdel = (int)CommonEnum.Deleted.未删除;
            model.CreateUser = UserID;
            model.PState = 0;
            DataTable dt = purchaseDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model, Convert.ToDateTime(ViewState["begin"]), Convert.ToDateTime(ViewState["end"]));
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
                int result = purchaseDAL.DeleteBat(ids, (int)CommonEnum.Deleted.删除);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除采购信息", UserID));
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
            StringBuilder str = new StringBuilder();
            int recordCount = -1;
            PurchaseEntity model = new PurchaseEntity();
            model.PTitle = (string)ViewState["GName"];
            model.Isdel = (int)CommonEnum.Deleted.未删除;
            model.CreateUser = UserID;
            model.PState = 0;
            DataTable dt = purchaseDAL.GetPaged(99999, 1, ref recordCount, model, Convert.ToDateTime(ViewState["begin"]), Convert.ToDateTime(ViewState["end"]));
            if (dt != null || dt.Rows.Count > 0)
            {

                str.Append(@"<table border='1' cellpadding='0' cellspacing='0' >
                                     <tr>
                                        <th><strong>采购名称</strong></th>
                                        <th><strong>概算</strong></th>
                                        <th><strong>申报时间</strong></th>
                                        <th><strong>审核状态</strong></th>
                                        <th><strong>上报状态</strong></th>
                                        <th><strong>上级审核</strong></th>
                                        <th><strong>采购方式</strong></th>
                                     </tr>");
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        str.Append("<tr>");
                        str.AppendFormat("<td>{0}</td>", row["PTitle"]);
                        str.AppendFormat("<td>{0}</td>", row["PEstimate"]);
                        str.AppendFormat("<td>{0}</td>", Convert.ToDateTime(row["CreateDate"].ToString()).ToString("yyyy-MM-dd"));
                        str.AppendFormat("<td>{0}</td>", GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.AduitState>(row["PState"]));
                        str.AppendFormat("<td>{0}</td>", row["IsReport"].ToString() == "1" ? "已上报" : "未上报");
                        str.AppendFormat("<td>{0}</td>", GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.AduitState>(row["PLState"]));
                        str.AppendFormat("<td>{0}</td>", row["TypeName"]);
                        str.Append("</tr>");
                    }
                }
                CommonFunction.ExportExcel("采购申请", str.ToString());
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_导出, "导出采购申请信息", UserID));
            }
            else
            {
                ShowMessage("暂无数据导出！");
                return;
            }
        }
        #endregion


        #region 单条上报
        /// <summary>
        /// 上传项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtn_SB_Click(object sender, EventArgs e)
        {
            try
            {
                localhost1.WebService1 service = new localhost1.WebService1();
                service.Url = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "ServerUrl") + "/WebService1.asmx";
                LinkButton lbtn = (LinkButton)sender;
                string id = lbtn.CommandArgument.ToString();
                string aa = "";
                //List<GKICMP.localhost1.PurchaseEntity> args = new List<GKICMP.localhost1.PurchaseEntity>();

                List<GKICMP.localhost1.PurchasrBillReport> purb = new List<GKICMP.localhost1.PurchasrBillReport>();
                string[] ids = id.Split(',');
                for (int i = 0; i < ids.Length; i++)
                {
                    List<GKICMP.localhost1.Purchase_BillEntity> pub = new List<GKICMP.localhost1.Purchase_BillEntity>();
                    PurchaseEntity model = purchaseDAL.GetObjByID(ids[i]);
                    DataTable dt = purchase_BillDAL.GetByPID(ids[i]);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        GKICMP.localhost1.PurchasrBillReport model1 = new localhost1.PurchasrBillReport();
                        GKICMP.localhost1.PurchaseEntity pmodel = new localhost1.PurchaseEntity();
                        model1.Purchase = pmodel;
                        model1.Purchase.PID = model.PID;
                        model1.Purchase.PTitle = model.PTitle;
                        model1.Purchase.PEstimate = model.PEstimate;
                        model1.Purchase.PDesc = model.PDesc;
                        model1.Purchase.CreateDate = DateTime.Now;
                        model1.Purchase.CreateUser = model.CreateUserName;
                        model1.Purchase.PSDate = model.PSDate;
                        model1.Purchase.PState = model.PState;
                        model1.Purchase.PLState = 1;
                        model1.Purchase.Isdel = 0;
                        foreach (DataRow dr in dt.Rows)
                        {
                            GKICMP.localhost1.Purchase_BillEntity modelb = new localhost1.Purchase_BillEntity();
                            //赋值
                            modelb.PID = model1.Purchase.PID;
                            modelb.BID = int.Parse(dr["BID"].ToString());
                            modelb.BName = dr["BName"].ToString();
                            modelb.BModel = dr["BModel"].ToString();
                            modelb.BCount = int.Parse(dr["BCount"].ToString());
                            modelb.BPrice = decimal.Parse(dr["BPrice"].ToString());
                            modelb.BReason = dr["BReason"].ToString();
                            modelb.CreateDate = DateTime.Now;
                            pub.Add(modelb);
                        }
                        model1.Purchase_Bill = pub.ToArray();
                        purb.Add(model1);
                    }
                    else
                    {
                        ShowMessage("未添加采购清单，不予上报");
                        return;
                    }


                }
                if (purb.Count > 0)
                {
                    string sguid = ConfigurationManager.AppSettings["SGUID"];
                    GKICMP.localhost1.PurchasrBillReport[] A = purb.ToArray();
                    if (service.PurchaseReport(sguid, A, out aa))
                    {
                        int rusult = purchaseDAL.Update(id.TrimEnd(','), UserID);
                        ShowMessage();
                        DataBindList();
                    }
                    else
                    {
                        ShowMessage(aa);
                        sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, aa, UserID));
                    }
                }
                else
                {
                    ShowMessage("所选项目未添加采购清单。");
                    return;
                }
            }
            catch (Exception ex)
            {
                ShowMessage("请配置区平台网址");
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, ex.Message, UserID));
            }

        }
        #endregion

        #region 多条上报 --测试完成
        protected void lbtn_MoreSB_Click(object sender, EventArgs e)
        {
            try
            {
                localhost1.WebService1 service = new localhost1.WebService1();
                service.Url = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "ServerUrl") + "/WebService1.asmx";
                string id = this.hf_CheckIDS.Value.ToString();
                string aa = "";
                //List<GKICMP.localhost1.PurchaseEntity> args = new List<GKICMP.localhost1.PurchaseEntity>();

                List<GKICMP.localhost1.PurchasrBillReport> purb = new List<GKICMP.localhost1.PurchasrBillReport>();

                if (id != "")
                {
                    string[] ids = id.TrimEnd(',').Split(',');
                    for (int i = 0; i < ids.Length; i++)
                    {
                        List<GKICMP.localhost1.Purchase_BillEntity> pub = new List<GKICMP.localhost1.Purchase_BillEntity>();
                        PurchaseEntity model = purchaseDAL.GetObjByID(ids[i]);
                        if (model.PState == (int)CommonEnum.AduitState.通过)
                        {
                            DataTable dt = purchase_BillDAL.GetByPID(ids[i]);
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                GKICMP.localhost1.PurchasrBillReport model1 = new localhost1.PurchasrBillReport();
                                GKICMP.localhost1.PurchaseEntity pmodel = new localhost1.PurchaseEntity();
                                model1.Purchase = pmodel;
                                model1.Purchase.PID = model.PID;
                                model1.Purchase.PTitle = model.PTitle;
                                model1.Purchase.PEstimate = model.PEstimate;
                                model1.Purchase.PDesc = model.PDesc;
                                model1.Purchase.CreateDate = DateTime.Now;
                                model1.Purchase.CreateUser = model.CreateUserName;
                                model1.Purchase.PSDate = model.PSDate;
                                model1.Purchase.PState = model.PState;
                                model1.Purchase.PLState = 1;
                                model1.Purchase.Isdel = 0;
                                foreach (DataRow dr in dt.Rows)
                                {
                                    GKICMP.localhost1.Purchase_BillEntity modelb = new localhost1.Purchase_BillEntity();
                                    //赋值
                                    modelb.PID = model1.Purchase.PID;
                                    modelb.BID = int.Parse(dr["BID"].ToString());
                                    modelb.BName = dr["BName"].ToString();
                                    modelb.BModel = dr["BModel"].ToString();
                                    modelb.BCount = int.Parse(dr["BCount"].ToString());
                                    modelb.BPrice = decimal.Parse(dr["BPrice"].ToString());
                                    modelb.BReason = dr["BReason"].ToString();
                                    modelb.CreateDate = DateTime.Now;
                                    pub.Add(modelb);
                                }
                                model1.Purchase_Bill = pub.ToArray();
                                purb.Add(model1);
                            }
                            else
                            {
                                ShowMessage((model != null ? model.PTitle : "") + "未添加采购清单，不予上报");
                                return;
                            }
                        }
                    }
                    if (purb.Count > 0)
                    {
                        string sguid = ConfigurationManager.AppSettings["SGUID"];
                        GKICMP.localhost1.PurchasrBillReport[] A = purb.ToArray();
                        if (service.PurchaseReport(sguid, A, out aa))
                        {
                            int rusult = purchaseDAL.Update(id.TrimEnd(','), UserID);
                            ShowMessage();
                            DataBindList();
                        }
                        else
                        {
                            ShowMessage(aa);
                            sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, aa, UserID));
                        }
                    }
                    else
                    {
                        ShowMessage("所选项目未通过或未添加采购清单。");
                        return;
                    }
                }
                else
                {
                    ShowMessage("暂无可上报项目。");
                    return;
                }

            }
            catch (Exception ex)
            {
                ShowMessage("请配置区平台网址");
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, ex.Message, UserID));
            }

        }
        #endregion
    }
}