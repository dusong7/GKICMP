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
    public partial class PurchaseImport : PageBase
    {
        public PurchaseDAL purchaseDAL = new PurchaseDAL();
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
            PurchaseEntity model = new PurchaseEntity();
            model.PTitle = (string)ViewState["GName"];
            model.Isdel = (int)CommonEnum.Deleted.未删除;
            DataTable dt = purchaseDAL.GetPagedByImprot(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
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
                if (args != null && args.Count > 0)
                {
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
                else
                {
                    ShowMessage("请先导入清单");
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
                if (args != null && args.Count > 0)
                {
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
                else 
                {
                    ShowMessage("请先导入清单");
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