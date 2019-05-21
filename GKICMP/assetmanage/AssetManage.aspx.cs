/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      gxl
** 创建日期:    2016年11月10日
** 描 述:       资产信息管理页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GKICMP.assetmanage
{
    public partial class AssetManage : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public AssetDAL assetDAL = new AssetDAL();
        public SysDataDAL sysDataDAL = new SysDataDAL();
        public AssetTypeDAL assetTypeDAL = new AssetTypeDAL();
        public string Url = HttpContext.Current.Request.Url.ToString();
        #region 参数集合
        /// <summary>
        /// 1代表校产管理 2 代表耗材管理
        /// </summary>
        public int Flag
        {
            get
            {
                return GetQueryString<int>("flag", -1);
            }
        }
        #endregion

        #region 页面加载
        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                if (Flag == 1)
                {
                    this.lbl_ParentMenu.Text = "资产管理";
                    this.lbl_Menuname.Text = "资产管理";
                    this.lbl_Number.Text = this.lbl_Number1.Text = this.lbl_Name.Text = this.lbl_Name1.Text = this.lbl_Type.Text = this.lbl_Type1.Text = this.lbl_Sum.Text = "资产";

                    //资产分组
                    DataTable assetGroupdt = sysDataDAL.GetList((int)CommonEnum.IsorNot.否, (int)CommonEnum.DataType.资产分组);
                    CommonFunction.DDlTypeBind(this.ddl_AssetGroup, assetGroupdt, "SDID", "DataName", "-2");

                    DataTable DataType = assetTypeDAL.GetList((int)CommonEnum.Deleted.未删除, 1);


                    //this.ddl_DataType.Items.Add(new ListItem("--请选择--", "-2"));
                    //ModelParent(DataType, "-1", this.ddl_DataType, "");//递归栏目菜单

                }
                else
                {
                    this.AssetGroup.Visible = false;
                    this.ddl_Report.Visible = false;
                    this.lbl_ParentMenu.Text = "后勤管理";
                    //this.lbl_Menuname.Text = "耗材管理";
                    this.lbl_Menuname.Text = "管理";
                    //this.lbl_Number.Text = this.lbl_Number1.Text = this.lbl_Name.Text = this.lbl_Name1.Text = this.lbl_Type.Text = this.lbl_Type1.Text = this.lbl_Sum.Text = "耗材";
                    this.lbl_Number.Text = this.lbl_Number1.Text = this.lbl_Name.Text = this.lbl_Name1.Text = this.lbl_Type.Text = this.lbl_Type1.Text = this.lbl_Sum.Text = "";

                    //CommonFunction.DDlDataBaseBind(this.ddl_DataType, (int)CommonEnum.DataType.资产分类);
                    //DataTable dt = sysDataDAL.GetList((int)CommonEnum.IsorNot.否, (int)CommonEnum.DataType.耗材分类);
                    //CommonFunction.DDlTypeBind(this.ddl_DataType, dt, "SDID", "DataName", "-2");
                }
                this.hf_Flag.Value = Flag.ToString();

               


                ViewState["DataDesc"] = CommonFunction.GetCommoneString(this.txt_DataDesc.Text.Trim());//资产编号
                ViewState["AssetName"] = CommonFunction.GetCommoneString(this.txt_AssetName.Text.Trim());//物品名称
                DataBindList();
            }

        }
        #endregion

        #region 递归栏目菜单
        private void ModelParent(DataTable dt, string parentid, DropDownList ddl, string str)
        {
            string str_;
            string slt;
            slt = string.Format("PID='{0}'", parentid);
            DataRow[] drarr = dt.Select(slt);
            foreach (DataRow dr in drarr)
            {
                if (parentid == "-1")
                {
                    str_ = "";
                }
                else
                {
                    str_ = "├";
                }
                ListItem item = new ListItem();
                item.Text = str + str_ + dr["DataName"].ToString();     //Bind text
                item.Value = dr["SDID"].ToString();                                //Bind value
                string parent_id = item.Value;
                ddl.Items.Add(item);

                ModelParent(dt, parent_id, ddl, str + "..          ");
            }

        }
        #endregion

        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {
            int recordCount = -1;
            decimal Sum = 0;
            //AssetEntity model = new AssetEntity(int.Parse(this.ddl_DataType.SelectedValue), (int)CommonEnum.Deleted.未删除);
            AssetEntity model = new AssetEntity();
            model.DataType = int.Parse(Flag == 1 ? this.txt_DataType1.Text == "" ? "-2" : this.txt_DataType1.Text : txt_DataType2.Text == "" ? "-2" : this.txt_DataType2.Text);
            model.Isdel = (int)CommonEnum.Deleted.未删除;
            model.DataDesc = ViewState["DataDesc"].ToString();
            model.AssetName = ViewState["AssetName"].ToString();
            model.Flag = Flag; //1代表校产管理 2 代表耗材管理

            if (Flag == 1)
            {
                model.AssetGroup = int.Parse(this.ddl_AssetGroup.SelectedValue);
                model.IsReport = int.Parse(this.ddl_Report.SelectedValue);
            }
            else
            {
                model.AssetGroup = -2;
                model.IsReport = -2;
            }
            DataTable dt = assetDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model,ref Sum);
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
            string a = string.Format("{0:0,00.00}", Sum);
            this.ltl_Sum.Text = "当前资产的总价值为：￥" + a;
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
            ViewState["DataDesc"] = CommonFunction.GetCommoneString(this.txt_DataDesc.Text.Trim());//资产编号
            ViewState["AssetName"] = CommonFunction.GetCommoneString(this.txt_AssetName.Text.Trim());//物品名称
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
            string ids = hf_CheckIDS.Value.ToString();
            try
            {
                ids = ids.TrimEnd(',').TrimStart(',');
                string[] rid = ids.Split(',');
                int delresult = assetDAL.DeleteBat(ids, (int)CommonEnum.Deleted.删除);
                if (delresult > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除资产信息", UserID));
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
                return;
            }
        }
        #endregion


        #region 单条上报
        protected void lbtn_SB_Click(object sender, EventArgs e)
        {
            try
            {
                //localhost1.WebService1 service = new localhost1.WebService1();
                AssetService.AssetService AssetService = new AssetService.AssetService();
                AssetService.Url = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "AssetServerUrl") + "/AssetService.asmx";
              
                LinkButton lbtn = (LinkButton)sender;
                string id = lbtn.CommandArgument.ToString();
                string aa = "";
                string errorAseet = "";
                List<object> args = new List<object>();
                for (int i = 0; i < id.Split(',').Length; i++)
                {
                    AssetEntity p = assetDAL.GetObjByID(id.Split(',')[i]);

                    args.Add(
                       new
                       {
                           AID = p.AID,
                           PID = p.PID,
                           DataDesc = p.DataDesc,
                           AssetName = p.AssetName,
                           DataType = p.DataType,
                           APrice = p.APrice,
                           Brand = p.Brand,
                           BuyDate = p.BuyDate,
                           SpecificationModel = p.SpecificationModel,
                           Suppliers = p.Suppliers,
                           CreateUser = p.CreateUserName,
                           AssetNum = p.AssetNum,
                           Isdel = (int)CommonEnum.IsorNot.否,
                           PlanYear = p.PlanYear,
                           AssetMark = p.AssetMark,
                           // AUnit = p.AUnit,    //计量单位 须转化为计量单位名称
                           AUnitName = p.AUnitName,//计量单位名称
                           Flag = p.IsChecked, // 是否验收：0  否 ，1 是  对应区平台的flag字段
                           AssetGroupName = p.AssetGroupName

                       }
                        );
                   // model.AID = p.AID;
                   // model.PID = p.PID;
                   // model.DataDesc = p.DataDesc;
                   // model.AssetName = p.AssetName;
                   // model.DataType = p.DataType;
                   // model.APrice = p.APrice;
                   // model.Brand = p.Brand;
                   // model.BuyDate = p.BuyDate;
                   // model.SpecificationModel = p.SpecificationModel;
                   // model.Suppliers = p.Suppliers;
                   // model.CreateUser = p.CreateUserName;
                   // model.AssetNum = p.AssetNum;
                   // model.Isdel = (int)CommonEnum.IsorNot.否;


                   // model.PlanYear = p.PlanYear;
                   // model.AssetMark = p.AssetMark;
                   //// model.AUnit = p.AUnit;    //计量单位 须转化为计量单位名称
                   // model.AUnitName = p.AUnitName;//计量单位名称
                   // model.Flag = p.IsChecked; // 是否验收：0  否 ，1 是  对应区平台的flag字段
                   // model = p.AssetGroup;
                //)
                    //args.Add(model);
                }
                // string url = "http://localhost:5317/WebService1.asmx";

                //service.Url = ConfigurationManager.AppSettings["URL"] + "/WebService1.asmx";

                string sguid = ConfigurationManager.AppSettings["SGUID"];
                //service.Show("1", "2", out aa);
               // GKICMP.localhost1.AssetEntity[] A = args.ToArray();
                //object[] A = args.ToArray();
                string A = Newtonsoft.Json.JsonConvert.SerializeObject(args);
                if (AssetService.AssetUpload(sguid, A, out aa, out errorAseet))
                {
                    if (errorAseet == "")
                    { int rusult = assetDAL.Update(id); }
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

        #region 多条上报--测试完成
        protected void lbtn_MoreSB_Click(object sender, EventArgs e)
        {
            try
            {
                AssetService.AssetService AssetService = new AssetService.AssetService();
                AssetService.Url = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "AssetServerUrl") + "/AssetService.asmx";

                string id =  this.hf_CheckIDS.Value.ToString().TrimEnd(',').TrimStart(',');
                string aa = ""; string errorAseet = "";
                List<object> args = new List<object>();
                List<string> assetList=new List<string>();
                for (int i = 0; i < id.Split(',').Length; i++)
                {
                    AssetEntity p = assetDAL.GetObjByID(id.Split(',')[i]);
                    assetList.Add(p.AID);
                    args.Add(
                       new
                       {
                           AID = p.AID,
                           PID = p.PID,
                           DataDesc = p.DataDesc,
                           AssetName = p.AssetName,
                           DataType = p.DataType,
                           APrice = p.APrice,
                           Brand = p.Brand,
                           BuyDate = p.BuyDate,
                           SpecificationModel = p.SpecificationModel,
                           Suppliers = p.Suppliers,
                           CreateUser = p.CreateUserName,
                           AssetNum = p.AssetNum,
                           Isdel = (int)CommonEnum.IsorNot.否,
                           PlanYear = p.PlanYear,
                           AssetMark = p.AssetMark,
                           // AUnit = p.AUnit,    //计量单位 须转化为计量单位名称
                           AUnitName = p.AUnitName,//计量单位名称
                           Flag = p.IsChecked, // 是否验收：0  否 ，1 是  对应区平台的flag字段
                           AssetGroupName = p.AssetGroupName

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
                        id = "";
                        foreach (string asset in assetList)
                        {
                            id += asset + ","; ;
                        }
                    }                
                    int rusult = assetDAL.Update(id);
                    ShowMessage(aa);
                    DataBindList();
                }
                else
                {
                    ShowMessage(aa);
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, aa, UserID));
                }
                //List<GKICMP.localhost1.AssetEntity> args = new List<GKICMP.localhost1.AssetEntity>();
                //for (int i = 0; i < id.Split(',').Length; i++)
                //{
                //    AssetEntity p = assetDAL.GetObjByID(id.Split(',')[i]);
                //    GKICMP.localhost1.AssetEntity model = new localhost1.AssetEntity();

                //    model.AID = p.AID;
                //    model.PID = p.PID;
                //    model.DataDesc = p.DataDesc;
                //    model.AssetName = p.AssetName;
                //    model.DataType = p.DataType;
                //    model.APrice = p.APrice;
                //    model.Brand = p.Brand;
                //    model.BuyDate = p.BuyDate;
                //    model.SpecificationModel = p.SpecificationModel;
                //    model.Suppliers = p.Suppliers;
                //    model.CreateUser = p.CreateUserName;
                //    model.AssetNum = p.AssetNum;
                //    model.Isdel = (int)CommonEnum.IsorNot.否;
                   

                //    model.PlanYear = p.PlanYear;
                //    model.AssetMark = p.AssetMark;
                //    //model.AUnit = p.AUnit;    //计量单位 须转化为计量单位名称
                //    model.AUnitName = p.AUnitName;//计量单位名称
                //    model.Flag = p.IsChecked; // 是否验收：0  否 ，1 是  对应区平台的flag字段

                //    //model.AssetGroup = p.AssetGroup;
                //    args.Add(model);
                //}
                ////service.Url = ConfigurationManager.AppSettings["URL"] + "/WebService1.asmx";

                //string sguid = ConfigurationManager.AppSettings["SGUID"];
                //GKICMP.localhost1.AssetEntity[] A = args.ToArray();
                //if (service.AssetManage(sguid, A, out aa))
                //{
                //    int rusult = assetDAL.Update(id);
                //    ShowMessage(aa);
                //    DataBindList();
                //}
                //else
                //{
                //    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, aa, UserID));
                //}
            }
            catch (Exception ex)
            {
                ShowMessage("请配置区平台网址");
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, ex.Message, UserID));
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

        protected void btn_OutPut_Click(object sender, EventArgs e)
        {
            int recordCount = -1;
            decimal sum = 0;
            string[] u = Url.Split('/');
            string s=Url.Substring(0, Url.LastIndexOf('/'));
            string url = s.Substring(0,s.LastIndexOf('/')+1) + "app/AssetDetail.aspx?id=";
            //AssetEntity model = new AssetEntity(int.Parse(this.ddl_DataType.SelectedValue), (int)CommonEnum.Deleted.未删除);
            AssetEntity model = new AssetEntity();
            model.DataType = int.Parse(Flag == 1 ? this.txt_DataType1.Text == "" ? "-2" : this.txt_DataType1.Text : txt_DataType2.Text == "" ? "-2" : this.txt_DataType2.Text);
            model.Isdel = (int)CommonEnum.Deleted.未删除;
            model.DataDesc = ViewState["DataDesc"].ToString();
            model.AssetName = ViewState["AssetName"].ToString();
            model.Flag = Flag; //1代表校产管理 2 代表耗材管理
            if (Flag == 1)
            {
                model.AssetGroup = int.Parse(this.ddl_AssetGroup.SelectedValue);
                model.IsReport = int.Parse(this.ddl_Report.SelectedValue);
            }
            else
            {
                model.AssetGroup = -2;
                model.IsReport = -2;
            }
            DataTable dt = assetDAL.GetPaged(9999, 1, ref recordCount, model,ref sum);
            DataTable dtOut = new DataTable();
            if (dt != null && dt.Rows.Count > 0)
            {
                
                //DataTable stu = exam_StudentDAL.GetStuByEid(int.Parse(EID));
                //DataTable course = exam_SubjectDAL.GetByEID(EID);
                dtOut.Columns.Add("资产名称", typeof(string));
                dtOut.Columns.Add("编号", typeof(string));
                dtOut.Columns.Add("类别", typeof(string));
                dtOut.Columns.Add("品牌", typeof(string));
                dtOut.Columns.Add("规格型号", typeof(string));
                dtOut.Columns.Add("计量单位", typeof(string));
                dtOut.Columns.Add("供应商", typeof(string));
                dtOut.Columns.Add("置购时间", typeof(string));
                dtOut.Columns.Add("计划使用年限", typeof(string));
                dtOut.Columns.Add("资产分组", typeof(string));
                dtOut.Columns.Add("二维码", typeof(string));
                foreach (DataRow dr in dt.Rows)
                {
                    List<string> list = new List<string>();
                    list.Add(dr["AssetName"].ToString());
                    list.Add(dr["DataDesc"].ToString());
                    list.Add(dr["TypeName"].ToString());
                    list.Add(dr["Brand"].ToString());
                    list.Add(dr["SpecificationModel"].ToString());
                    list.Add(dr["AUnitName"].ToString());
                    list.Add(dr["SuppliersName"].ToString());
                    list.Add(dr["BuyDate"].ToString());
                    list.Add(dr["PlanYear"].ToString() == "" ? "0" : dr["PlanYear"].ToString());
                    list.Add(dr["AssetGroupName"].ToString());
                    list.Add(url + dr["AID"].ToString());
                    dtOut.Rows.Add(list.ToArray());
                }
            }
            else 
            {
                ShowMessage("暂无数据导出");
                return;
            }
            try
            {
                //string _excelName = "发货列表信息";//Excel表头名称
                //string fileName = _excelName + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls"; //Excel文件名称
                //调用导出方法
                CommonFunction.ExportByWeb(dtOut, "", "资产表" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");

            }
            catch (Exception ee)
            {
                string _err = ee.Message;
            }
            this.hf_CheckIDS.Value = "";
        }


        public bool GetAcceptName(object isreport, object flag)
        {
            int report = Convert.ToInt32(isreport);
            int flags = Convert.ToInt32(flag);
            if (flags == 2 )
            {
                return false;
            }
            else if (flags == 1 && report == 1)
            {
                return false;
            }
            else if (flags == 1 && report == 0)
            {
                return true;
            }
            else 
            {
                return true;
            }

        }

        
    }
}