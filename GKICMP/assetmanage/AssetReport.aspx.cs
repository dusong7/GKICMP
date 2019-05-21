using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GKICMP.assetmanage
{
    public partial class AssetReport : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public AssetDAL assetDAL = new AssetDAL();
        public SysDataDAL sysDataDAL = new SysDataDAL();
        public AssetTypeDAL assetTypeDAL = new AssetTypeDAL();
        public string Url = HttpContext.Current.Request.Url.ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                DataBindList();
            }
        }
        public void DataBindList()
        {
            int recordCount = -1;
            decimal Sum = 0;
            AssetEntity model = new AssetEntity();
            model.DataType = -2;
            model.Isdel = (int)CommonEnum.Deleted.未删除;
            model.DataDesc = "";
            model.AssetName = ""; ;
            model.Flag = 1; //1代表校产管理 2 代表耗材管理
            model.AssetGroup = -2;
            model.IsReport = 0;
            DataTable dt = assetDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model, ref Sum);
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
        }
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
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                int recordCount = -1;
                decimal Sum = 0;
                string id = "";
                AssetService.AssetService AssetService = new AssetService.AssetService();
                AssetService.Url = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "AssetServerUrl") + "/AssetService.asmx";

                #region 查询前100条数据
                AssetEntity model = new AssetEntity();
                model.DataType = -2;
                model.Isdel = (int)CommonEnum.Deleted.未删除;
                model.DataDesc = "";
                model.AssetName = ""; ;
                model.Flag = 1; //1代表校产管理 2 代表耗材管理
                model.AssetGroup = -2;
                model.IsReport = 0;
                DataTable dt = assetDAL.GetPaged(100, 1, ref recordCount, model, ref Sum); 
                #endregion
                
                string aa = ""; string errorAseet = "";
                List<object> args = new List<object>();
                List<string> assetList = new List<string>();
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        assetList.Add(dr["AID"].ToString());
                        args.Add(
                           new
                           {
                               AID = dr["AID"],
                               PID = dr["PID"],
                               DataDesc = dr["DataDesc"],
                               AssetName = dr["AssetName"],
                               DataType = dr["DataType"],
                               APrice = dr["APrice"],
                               Brand = dr["Brand"],
                               BuyDate = dr["BuyDate"],
                               SpecificationModel = dr["SpecificationModel"],
                               Suppliers = dr["Suppliers"],
                               CreateUser = dr["CreateUserName"],
                               AssetNum = dr["AssetNum"],
                               Isdel = (int)CommonEnum.IsorNot.否,
                               PlanYear = dr["PlanYear"],
                               AssetMark = dr["AssetMark"],
                               // AUnit = dr["AUnit,    //计量单位 须转化为计量单位名称
                               AUnitName = dr["AUnitName"],//计量单位名称
                               Flag = dr["IsChecked"], // 是否验收：0  否 ，1 是  对应区平台的flag字段
                               AssetGroupName = dr["AssetGroupName"]

                           }
                         );

                    }
                    string sguid = ConfigurationManager.AppSettings["SGUID"];


                    string A = Newtonsoft.Json.JsonConvert.SerializeObject(args);
                    if (AssetService.AssetUpload(sguid, A, out aa, out errorAseet))
                    {
                        if (errorAseet != "")
                        {
                            foreach (string s in errorAseet.Split(','))
                            {
                                assetList.Remove(s);
                            }
                           
                        }
                        //id = "";
                        foreach (string asset in assetList)
                        {
                            id += asset + ","; ;
                        }
                        int rusult = assetDAL.Update(id);
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
                    ShowMessage("已全部上传！");
                }
            }
            catch (Exception ex)
            {
                ShowMessage("请配置区平台网址");
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, ex.Message, UserID));
            }

        }
    }
}