/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      樊紫红
** 创建日期:    2017年5月31日 15时32分
** 描 述:       友情链接、幻灯片、宣传标语管理页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.cms
{
    public partial class SlideManage : PageBase
    {
        public Web_SlideDAL slideDAL = new Web_SlideDAL();
        public Web_SlideTypeDAL slidetypeDAL = new Web_SlideTypeDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();

        #region 参数集合
        /// <summary>
        /// flag 1：友情链接 2：幻灯片 3：宣传标语
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
                DataTable dt = slidetypeDAL.GetList(Flag, (int)CommonEnum.Deleted.未删除);
                CommonFunction.DDlTypeBind(this.ddl_SType, dt, "SType", "STypeName", "-2");
                this.hf_Flag.Value = Flag.ToString();
                if (Flag == 1)
                {
                    this.ltl_Name.Text = this.ltl_SlideName.Text = "友情链接";
                    this.lbl_Menuname.Text = "友情链接管理";
                }
                else if (Flag == 2)
                {
                    this.ltl_Name.Text = this.ltl_SlideName.Text = "幻灯片";
                    this.lbl_Menuname.Text = "幻灯片管理";
                }
                else
                {
                    this.ltl_Name.Text = this.ltl_SlideName.Text = "宣传标语";
                    this.lbl_Menuname.Text = "宣传标语管理";
                }

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
            ViewState["SType"] = this.ddl_SType.SelectedValue.ToString();
            ViewState["SlideName"] = CommonFunction.GetCommoneString(this.txt_SlideName.Text.ToString().Trim());
            ViewState["BeginDate"] = this.txt_BeginDate.Text == "" ? "1900-01-01" : this.txt_BeginDate.Text.ToString().Trim();
            ViewState["EndDate"] = this.txt_EndDate.Text == "" ? "9999-12-31" : this.txt_EndDate.Text.ToString().Trim();
        }
        #endregion


        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {
            int recordCount = -1;
            Web_SlideEntity model = new Web_SlideEntity(Convert.ToInt32(ViewState["SType"].ToString()), (string)ViewState["SlideName"], Convert.ToDateTime(ViewState["BeginDate"].ToString()), Convert.ToDateTime(ViewState["EndDate"].ToString()), (int)CommonEnum.Deleted.未删除, Flag);
            DataTable dt = slideDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
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
            this.rp_List.DataBind();
            this.hf_CheckIDS.Value = "";
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
                int result = slideDAL.DeleteBat(ids, (int)CommonEnum.Deleted.删除);
                if (result > 0)
                {
                    ShowMessage("删除成功");
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除" + this.ltl_Name.Text + "信息", UserID));
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


        #region 分页事件
        /// <summary>
        /// 分页事件
        /// </summary>
        protected void Pager_PageChanged(object sender, EventArgs e)
        {
            DataBindList();
        }
        #endregion
    }
}