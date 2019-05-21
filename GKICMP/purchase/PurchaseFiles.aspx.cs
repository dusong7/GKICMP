using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;


namespace GKICMP.purchase
{
    public partial class PurchaseFiles : PageBase
    {
        public PurchaseDAL purchaseDAL = new PurchaseDAL();
        public Purchase_BillDAL purchase_BillDAL = new Purchase_BillDAL();
        public Purchase_FileTypeDAL purchase_FileTypeDAL = new Purchase_FileTypeDAL();
        public SysDataDAL SysDataDAL = new SysDataDAL();
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
            ViewState["FileName"] = CommonFunction.GetCommoneString(this.txt_FileName.Text.ToString());
        }
        #endregion

        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {
            int recordCount = -1;
            PurchaseEntity model = new PurchaseEntity((string)ViewState["FileName"]);
            DataTable dt = purchase_FileTypeDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
            if (dt.Rows.Count > 0 && dt != null)
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


        #region repeter行绑定
        /// <summary>
        /// repeter行绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void rptypelist_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rep1 = e.Item.FindControl("rp_ListFile1") as Repeater;//找到里层的repeater对象  
                DataRowView rowv = (DataRowView)e.Item.DataItem;//找到分类Repeater关联的数据项 

                string typeid = Convert.ToString(rowv["PID"].ToString()); //获取填充子类的id 
                DataTable dtf = purchase_FileTypeDAL.GetNameByType(typeid);
                if (dtf != null && dtf.Rows.Count > 0)
                {
                }
                else
                {
                    dtf.Rows.Add();
                }
                rep1.DataSource = dtf;
                rep1.DataBind();
            }
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

        #region 附件下载
        /// <summary>
        /// 附件下载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rpfilelist_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            try
            {
                string ProID = e.CommandArgument.ToString().Trim();
                DataTable dt = purchase_FileTypeDAL.GetFile(ProID);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (!CommonFunction.UpLoadFunciotn(dt.Rows[i]["FileUrl"].ToString(), dt.Rows[i]["FileName"].ToString()))
                    {
                        ShowMessage("下载文件不存在，请联系系统管理员");
                        return;
                    }
                }

            }
            catch (Exception)
            {

                ShowMessage("文件路径错误！请重新上传！！！");
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
                string[] ids = id.TrimEnd(',').Split(',');
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
                        ShowMessage(model.PTitle + "未添加采购清单，不予上报");
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
                //localhost1.WebService1 service = new localhost1.WebService1();
                //service.Url = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "ServerUrl") + "/WebService1.asmx";
                //string id = "";
                //id = this.hf_CheckIDS.Value.ToString();
                //id = id.TrimEnd(',').TrimStart(',');
                //string aa = "";
                ////#region 附件上传
                ////for (int i = 0; i < id.Split(',').Length; i++)
                ////{
                ////    JZProjectManageEntity bt = jzprojectManageDAL.GetObjByID(id.Split(',')[i]);
                ////    if (bt != null)
                ////    {
                ////        if (bt.PCFile != null)
                ////        {
                ////            Byte[] b = CommonFunction.File2Bytes(bt.PCFile);
                ////            service.SaveFile(b, bt.PCFile);
                ////        }
                ////    }
                ////}
                ////#endregion

                //string ulist = "";//上报成功列表
                //string elist = "";//上报未成功的列表
                ////List<GKICMP.localhost1.PurchaseEntity> args = new List<GKICMP.localhost1.PurchaseEntity>();
                //List<GKICMP.localhost1.Purchase_BillEntity> pub = new List<GKICMP.localhost1.Purchase_BillEntity>();
                //List<GKICMP.localhost1.PurchasrBillReport> purb = new List<GKICMP.localhost1.PurchasrBillReport>();
                //string[] ids = id.Split(',');
                //for (int i = 0; i < ids.Length; i++)
                //{
                //    PurchaseEntity model = purchaseDAL.GetObjByID(ids[i]);
                //    DataTable dt = purchase_BillDAL.GetByPID(ids[i]);
                //    if (dt != null && dt.Rows.Count > 0)
                //    {
                //        GKICMP.localhost1.PurchasrBillReport model1 = new localhost1.PurchasrBillReport();
                //        model1.Purchase.PID = model.PID;
                //        model1.Purchase.PTitle = model.PTitle;
                //        model1.Purchase.PEstimate = model.PEstimate;
                //        model1.Purchase.PDesc = model.PDesc;
                //        model1.Purchase.CreateDate = DateTime.Now;
                //        model1.Purchase.CreateUser = model.CreateUserName;
                //        model1.Purchase.PSDate = model.PSDate;
                //        model1.Purchase.PState = model.PState;
                //        model1.Purchase.PLState = 1;
                //        model1.Purchase.Isdel = 0;
                //        foreach (DataRow dr in dt.Rows)
                //        {
                //            GKICMP.localhost1.Purchase_BillEntity modelb = new localhost1.Purchase_BillEntity();
                //            //赋值
                //            modelb.PID = model1.Purchase.PID;
                //            modelb.BID = int.Parse(dr["BID"].ToString());
                //            modelb.BName = dr["BName"].ToString();
                //            modelb.BModel = dr["BModel"].ToString();
                //            modelb.BCount = int.Parse(dr["BCount"].ToString());
                //            modelb.BPrice = decimal.Parse(dr["BPrice"].ToString());
                //            modelb.BReason = dr["BReason"].ToString();
                //            modelb.CreateDate = DateTime.Now;
                //            pub.Add(modelb);
                //        }
                //        model1.Purchase_Bill = pub.ToArray();
                //        purb.Add(model1);
                //        ulist += ids[i] + ",";
                //    }
                //    else
                //    {
                //        elist += model.PTitle + ",";
                //    }

                //}
                //if (purb.Count > 0)
                //{
                //    string sguid = ConfigurationManager.AppSettings["SGUID"];
                //    GKICMP.localhost1.PurchasrBillReport[] A = purb.ToArray();
                //    if (service.PurchaseReport(sguid, A,  out aa))
                //    {
                //        int rusult = purchaseDAL.Update(ulist.TrimEnd(','), UserID);
                //        ShowMessage(aa + (elist == "" ? "" : ("其中【" + elist + "】未添加采购清单，不予上报")));
                //        DataBindList();
                //    }
                //    else
                //    {
                //        ShowMessage(aa);
                //        sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, aa, UserID));
                //    }
                //}
                //else 
                //{
                //    ShowMessage("所选项目未添加采购清单。【"+elist+"】");
                //    return;
                //}
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