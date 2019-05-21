
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
    public partial class PurchaseContract : PageBase
    {
        public Project_ContractDAL project_ContractDAL = new Project_ContractDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public AccessoryDAL accessoryDAL = new AccessoryDAL();

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
            ViewState["Name"] = CommonFunction.GetCommoneString(this.txt_Name.Text.ToString().Trim());
            ViewState["PartyB"] = CommonFunction.GetCommoneString(this.txt_PartyB.Text.ToString().Trim());
            ViewState["BidNumber"] = CommonFunction.GetCommoneString(this.txt_BidNumber.Text.ToString().Trim());
        }
        #endregion

        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {
            int recordCount = -1;
            Project_ContractEntity model = new Project_ContractEntity();
            model.Name = (string)ViewState["Name"];
            model.BidNumber = (string)ViewState["BidNumber"];
            model.PartyB = (string)ViewState["PartyB"];
            model.Isdel = (int)CommonEnum.Deleted.未删除;
            DataTable dt = project_ContractDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
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
                int result = project_ContractDAL.DeleteBat(ids, (int)CommonEnum.Deleted.删除);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除采购合同信息", UserID));
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
            Project_ContractEntity model = new Project_ContractEntity();
            model.Name = (string)ViewState["Name"];
            model.BidNumber = (string)ViewState["BidNumber"];
            model.PartyB = (string)ViewState["PartyB"];
            model.Isdel = (int)CommonEnum.Deleted.未删除;
            DataTable dt = project_ContractDAL.GetPaged(99999, 1, ref recordCount, model);
            DataTable dtOut = new DataTable();
            if (dt != null && dt.Rows.Count > 0)
            {
                dtOut.Columns.Add("合同编号", typeof(string));
                dtOut.Columns.Add("合同名称", typeof(string));
                dtOut.Columns.Add("项目名称", typeof(string));
                dtOut.Columns.Add("乙方", typeof(string));
                dtOut.Columns.Add("金额", typeof(string));
                dtOut.Columns.Add("签订日期", typeof(string));
                dtOut.Columns.Add("维保开始日期", typeof(string));
                dtOut.Columns.Add("维保年限", typeof(string));
                foreach (DataRow dr in dt.Rows)
                {
                    List<string> list = new List<string>();
                    list.Add(dr["BidNumber"].ToString());
                    list.Add(dr["Name"].ToString());
                    list.Add(dr["PTitle"].ToString());
                    list.Add(dr["PartyBName"].ToString());
                    list.Add(dr["Price"].ToString());
                    list.Add(Convert.ToDateTime(dr["SignDate"].ToString()).ToString("yyyy-MM-dd"));
                    list.Add(Convert.ToDateTime(dr["ServerDate"].ToString()).ToString("yyyy-MM-dd"));
                    list.Add(dr["ServerYears"].ToString());
                    dtOut.Rows.Add(list.ToArray());
                }
            }
            else
            {
                ShowMessage("暂无数据导出！");
                return;
            }
            CommonFunction.ExportByWeb(dtOut, "", "采购合同信息表" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");
            sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_导出, "导出采购合同信息", UserID));

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
                List<GKICMP.localhost1.ContractReport> args = new List<GKICMP.localhost1.ContractReport>();

                for (int i = 0; i < id.Split(',').Length; i++)
                {
                    GKICMP.localhost1.ContractReport modelReport = new localhost1.ContractReport();
                    GKICMP.localhost1.Project_ContractEntity model = new localhost1.Project_ContractEntity();
                    List<GKICMP.localhost1.AccessoryEntity> pub = new List<GKICMP.localhost1.AccessoryEntity>();

                    GK.GKICMP.Entities.Project_ContractEntity p = project_ContractDAL.GetObjByID(id.Split(',')[i]);

                    #region 附件上传


                    DataTable dt = accessoryDAL.GetList((int)CommonEnum.AccessoryType.Tb_Contract, p.FileID);
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

                    model.PCID = p.ID;
                    model.PID = p.PID;
                    model.Name = p.Name;
                    model.BidNumber = p.BidNumber;
                    model.PartyA = p.PartyA;
                    model.PartyB = p.PartyB;
                    model.SignDate = p.SignDate;
                    model.Price = p.Price;
                    model.StartTime = p.StartTime;
                    model.PCDesc = p.PCDesc;
                    model.CreateUser = UserRealName;
                    model.CreateDate = DateTime.Now;
                    model.Isdel = p.Isdel;
                    model.ServerYears = p.ServerYears;
                    model.ServerDate = p.ServerDate;
                    model.ServerLinkUser = p.ServerLinkUser;
                    model.ServerPhone = p.ServerPhone;
                    model.FileID = p.FileID;


                    modelReport.Contract = model;
                    modelReport.Accessory = pub.ToArray();

                    args.Add(modelReport);
                }
                //service.Url = ConfigurationManager.AppSettings["URL"] + "/WebService1.asmx";
                string sguid = ConfigurationManager.AppSettings["SGUID"];
                //service.Show("1", "2", out aa);
                GKICMP.localhost1.ContractReport[] A = args.ToArray();
                if (service.PurContractReport(sguid, A, out aa))
                {
                    int rusult = project_ContractDAL.Update(id);
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
                LinkButton lbtn = (LinkButton)sender;
                string id = lbtn.CommandArgument.ToString();
                string aa = "";
                List<GKICMP.localhost1.ContractReport> args = new List<GKICMP.localhost1.ContractReport>();

                for (int i = 0; i < id.Split(',').Length; i++)
                {
                    GKICMP.localhost1.ContractReport modelReport = new localhost1.ContractReport();
                    GKICMP.localhost1.Project_ContractEntity model = new localhost1.Project_ContractEntity();
                    List<GKICMP.localhost1.AccessoryEntity> pub = new List<GKICMP.localhost1.AccessoryEntity>();

                    GK.GKICMP.Entities.Project_ContractEntity p = project_ContractDAL.GetObjByID(id.Split(',')[i]);

                    #region 附件上传


                    DataTable dt = accessoryDAL.GetList((int)CommonEnum.AccessoryType.Tb_Contract, p.FileID);
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

                    model.PCID = p.ID;
                    model.PID = p.PID;
                    model.Name = p.Name;
                    model.BidNumber = p.BidNumber;
                    model.PartyA = p.PartyA;
                    model.PartyB = p.PartyB;
                    model.SignDate = p.SignDate;
                    model.Price = p.Price;
                    model.StartTime = p.StartTime;
                    model.PCDesc = p.PCDesc;
                    model.CreateUser = UserRealName;
                    model.CreateDate = DateTime.Now;
                    model.Isdel = p.Isdel;
                    model.ServerYears = p.ServerYears;
                    model.ServerDate = p.ServerDate;
                    model.ServerLinkUser = model.ServerLinkUser;
                    model.ServerPhone = model.ServerPhone;
                    model.FileID = p.FileID;


                    modelReport.Contract = model;
                    modelReport.Accessory = pub.ToArray();

                    args.Add(modelReport);
                }
                //service.Url = ConfigurationManager.AppSettings["URL"] + "/WebService1.asmx";
                string sguid = ConfigurationManager.AppSettings["SGUID"];
                //service.Show("1", "2", out aa);
                GKICMP.localhost1.ContractReport[] A = args.ToArray();
                if (service.PurContractReport(sguid, A, out aa))
                {
                    int rusult = project_ContractDAL.Update(id);
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
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, ex.Message, UserID));
            }

        }
        #endregion

        public string GetDisabled(object sender)
        {
            if (sender.ToString() == "0")
            {
                return "";
            }
            else
            {
                return "disabled";
            }
        }
    }
}