/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      樊紫红
** 创建日期:    2017年11月9日 9时25分
** 描 述:       资产信息管理页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;
using System.Collections.Generic;
using System.Web;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;

namespace GKICMP.assetmanage
{
    public partial class AssetManageOffice : PageBase
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
                this.lbl_ParentMenu.Text = "后勤管理";
                this.lbl_Menuname.Text = "管理";

                ViewState["AssetName"] = CommonFunction.GetCommoneString(this.txt_AssetName.Text.Trim());//物品名称
                DataBindList();
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
            AssetEntity model = new AssetEntity();
            model.DataType = int.Parse(txt_DataType2.Text == "" ? "-2" : this.txt_DataType2.Text);
            model.Isdel = (int)CommonEnum.Deleted.未删除;
            model.DataDesc = "";
            model.AssetName = ViewState["AssetName"].ToString();
            model.Flag = 2; //1代表校产管理 2 代表耗材管理
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
            string a = string.Format("{0:0,00.00}", Sum);
            this.ltl_Sum.Text = "当前办公用品的总价值为：￥" + a;
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
            //ViewState["DataDesc"] = CommonFunction.GetCommoneString(this.txt_DataDesc.Text.Trim());//资产编号
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
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除办公用品信息", UserID));
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
            string s = Url.Substring(0, Url.LastIndexOf('/'));
            string url = s.Substring(0, s.LastIndexOf('/') + 1) + "app/AssetDetail.aspx?id=";
            //AssetEntity model = new AssetEntity(int.Parse(this.ddl_DataType.SelectedValue), (int)CommonEnum.Deleted.未删除);
            AssetEntity model = new AssetEntity();
            model.DataType = int.Parse(txt_DataType2.Text == "" ? "-2" : this.txt_DataType2.Text);
            model.Isdel = (int)CommonEnum.Deleted.未删除;
            model.DataDesc = "";
            model.AssetName = ViewState["AssetName"].ToString();
            model.Flag = 2; //1代表校产管理 2 代表耗材管理
            DataTable dt = assetDAL.GetPaged(1999, 1, ref recordCount, model, ref sum);
            DataTable dtOut = new DataTable();
            if (dt != null && dt.Rows.Count > 0)
            {
                dtOut.Columns.Add("资产名称", typeof(string));
                dtOut.Columns.Add("类别", typeof(string));
                dtOut.Columns.Add("品牌", typeof(string));
                dtOut.Columns.Add("规格型号", typeof(string));
                dtOut.Columns.Add("计量单位", typeof(string));
                dtOut.Columns.Add("置购时间", typeof(string));
                dtOut.Columns.Add("计划使用年限", typeof(string));
                dtOut.Columns.Add("二维码", typeof(string));
                foreach (DataRow dr in dt.Rows)
                {
                    List<string> list = new List<string>();
                    list.Add(dr["AssetName"].ToString());
                    list.Add(dr["TypeName"].ToString());
                    list.Add(dr["Brand"].ToString());
                    list.Add(dr["SpecificationModel"].ToString());
                    list.Add(dr["AUnitName"].ToString());
                    list.Add(dr["BuyDate"].ToString());
                    list.Add(dr["PlanYear"].ToString() == "" ? "0" : dr["PlanYear"].ToString());
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
            if (flags == 2)
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