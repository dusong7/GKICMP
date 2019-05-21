/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      殷志瑞
** 创建日期:    2016年12月24日
** 描 述:       受理报修管理页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;

using System;
using System.Data;
using System.Web.UI.WebControls;

namespace ICMP.assetmanage
{
    public partial class RepairPeopleList : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public Asset_RepairDAL repairDAL = new Asset_RepairDAL();

        public int Flag
        {
            get
            {
                return GetQueryString<int>("flag", -1);
            }
        }

        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Flag == 1)
                {
                    this.lbl_ParentMenu.Text = "";
                }
                else
                {
                    this.ltl_Sign.Text = ">";
                }
                CommonFunction.BindEnum<CommonEnum.ARState>(this.ddl_ARState, "-2");
                GetCondition();
                DataBindList();
            }
        }
        #endregion


        #region 获取查询条件
        public void GetCondition()
        {
            ViewState["RepairObj"] = CommonFunction.GetCommoneString(this.txt_RepairObj.Text.Trim());
            ViewState["begin"] = this.txt_Begin.Text == "" ? "1900-01-01" : this.txt_Begin.Text;
            ViewState["end"] = this.txt_End.Text == "" ? "9999-12-31" : this.txt_End.Text;
            ViewState["ARState"] = this.ddl_ARState.SelectedValue;
        }
        #endregion


        #region 数据绑定
        public void DataBindList()
        {
            int recordCount = 0;
            Asset_RepairEntity model = new Asset_RepairEntity();
            model.RepairObj = ViewState["RepairObj"].ToString();
            DateTime begin = Convert.ToDateTime(ViewState["begin"].ToString());
            DateTime end = Convert.ToDateTime(ViewState["end"].ToString());
            model.DutyUser = UserRealName;
            model.ARState = Convert.ToInt32(ViewState["ARState"].ToString());
            model.Isdel = Convert.ToInt32(CommonEnum.Deleted.未删除);
            model.CreaterUser = UserID;
            DataTable dt = repairDAL.GetPagedByfalg(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model, begin, end, 1);//1 查询受理人是自己的 2 查询所有
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


        #region 分页
        public void Pager_PageChanged(object sender, EventArgs e)
        {
            DataBindList();
        }
        #endregion


        #region 查询
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
                int result = repairDAL.DeleteByID(ids, (int)CommonEnum.Deleted.删除);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除报修信息", UserID));
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

        protected void lbtn_SL_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            string id = lbtn.CommandArgument.ToString();
            int result = repairDAL.SL(id, (int)CommonEnum.ARState.已受理);
            if (result > 0)
            {
                ShowMessage("受理成功");
                GetCondition();
                DataBindList();
            }
            else
            {
                ShowMessage("提交失败");
                return;
            }
        }
        public string GetState(object obj)
        {
            string name = "";
            name = obj.ToString() == "0" ? "<span style='color:#febe17'>" + CommonFunction.CheckEnum<CommonEnum.ARState>(obj.ToString()) + "</span>" : obj.ToString() == "1" ? "<span style='color:#47ae6f'>" + CommonFunction.CheckEnum<CommonEnum.ARState>(obj.ToString()) + "</span>" : obj.ToString() == "2" ? "<span style='color:red'>" + CommonFunction.CheckEnum<CommonEnum.ARState>(obj.ToString()) + "</span>" : "<span style='color:gray'>" + CommonFunction.CheckEnum<CommonEnum.ARState>(obj.ToString()) + "</span>";
            return name;
        }
    }
}