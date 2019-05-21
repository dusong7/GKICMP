/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      gxl
** 创建日期:    2016年11月10日 17:29
** 描 述:       资产领用/借出页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.IO;
using System.Data;
using System.Configuration;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace GKICMP.assetmanage
{
    public partial class AssetGetManage : PageBase
    {
        public AssetBorrowDAL borrowDAL = new AssetBorrowDAL();
        public SysDataDAL sysDataDAL = new SysDataDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public AssetTypeDAL assetTypeDAL = new AssetTypeDAL();

        #region 参数集合
        /// <summary>
        /// Flag 标示 1：借出 2：领用
        /// </summary>
        public int Flag
        {
            get
            {
                return GetQueryString<int>("flag", -1);
            }
        }
        #endregion


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
                this.hf_Flag.Value = Flag.ToString();
                
                    this.btntab.Visible = false;
                    this.ltl_Name.Text = this.ltl_NameS.Text = "领用人";
                    this.ltl_Date.Text = this.ltl_DateS.Text = "领用日期";
                    this.ltl_AssetNum.Text = "领用数量";
                    this.lbl_Menuname.Text = "领用登记";

                    DataTable DataType = sysDataDAL.GetList((int)CommonEnum.Deleted.未删除, (int)CommonEnum.DataType.耗材分类);
                    CommonFunction.DDlTypeBind(this.ddl_DataType, DataType, "SDID", "DataName", "-2");
                }
                GetCondition();
                DataBindList();
           
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

        #region 获取查询条件
        /// <summary>
        /// 获取查询条件
        /// </summary>
        private void GetCondition()
        {
            ViewState["AssetName"] = CommonFunction.GetCommoneString(this.txt_AassetName.Text.ToString().Trim());
            ViewState["DataType"] = this.ddl_DataType.SelectedValue;
            ViewState["ABUserName"] = CommonFunction.GetCommoneString(this.txt_ABUserName.Text.ToString().Trim());
            ViewState["BeginDate"] = this.txt_BeginDate.Text == "" ? "1900-01-01" : this.txt_BeginDate.Text;
            ViewState["EndDate"] = this.txt_EndDate.Text == "" ? "9999-12-31" : this.txt_EndDate.Text;
        }
        #endregion


        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {
            int recordCount = -1;
            Asset_BorrowEntity model = new Asset_BorrowEntity(Convert.ToDateTime(ViewState["BeginDate"]), Convert.ToDateTime(ViewState["EndDate"]), 3, (int)CommonEnum.Deleted.未删除);//ABFlag=3 代表资产领用
            DataTable dt = borrowDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, (string)ViewState["AssetName"], Convert.ToInt32(ViewState["DataType"].ToString()), (string)ViewState["ABUserName"], model);
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


        #region 归还事件
        /// <summary>
        /// 归还事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Back_Click(object sender, EventArgs e)
        {
            try
            {
                string ids = this.hf_CheckIDS.Value.ToString();

                ids = ids.TrimEnd(',').TrimStart(',');
                int result = borrowDAL.UpdateBack(ids, (int)CommonEnum.ABState.归还);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "归还耗材" + ltl_Name.Text.ToString() + "信息", UserID));
                    ShowMessage("归还成功");
                }
                else
                {
                    ShowMessage("归还失败");
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


        #region 判断复选框是否可用
        /// <summary>
        /// 判断复选框是否可用
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public string GetDisable(object state)
        {
            string abstate = Convert.ToString(state.ToString());
            if (abstate != "")
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