using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GKICMP.sysmanage
{
    public partial class DepartmentList : PageBase
    {
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public CampusDAL campusDAL = new CampusDAL();

        #region 参数集合
        /// <summary>
        /// 1：部门 2：班级
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //DataTable dt = campusDAL.GetList((int)CommonEnum.Deleted.未删除);
                //CommonFunction.DDlTypeBind(this.ddl_CID, dt, "CID", "CampusName", "-2");

                if (Flag == 1)
                {
                    this.lbl_Menuname.Text = "部门管理";
                    this.ltl_Search.Text = this.ltl_DepName.Text =  "部门名称";
                    this.ltl_name.Text = "备注";
                    //this.ltl_ID.Text = "部门ID";
                    
                }
                else
                {
                    this.lbl_Menuname.Text = "班级管理";
                    this.ltl_Search.Text = this.ltl_DepName.Text = "班级名称";
                    this.ltl_name.Text = "别名";
                    //this.ltl_ID.Text = "班级ID";
                    this.btn_Add.Visible = false;
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
        public void GetCondition()
        {
            ViewState["DepName"] = CommonFunction.GetCommoneString(this.txt_DepName.Text.Trim());//姓名

            //ViewState["CID"] = this.ddl_CID.SelectedValue.ToString();
        }
        #endregion


        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {
            int recordCount = -1;
            DepartmentEntity model = new DepartmentEntity();
            model.DepName = (string)ViewState["DepName"];
            model.Isdel = (int)CommonEnum.Deleted.未删除;
            model.DepType=Flag==1?(int)CommonEnum.DepType.职能部门:(int)CommonEnum.DepType.普通班级;

            //model.CID = Convert.ToInt32(ViewState["CID"].ToString());

            DataTable dt = departmentDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
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
        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            string ids = hf_CheckIDS.Value.ToString();
            try
            {
                ids = ids.TrimEnd(',').TrimStart(',');
                int delresult = departmentDAL.DeleteBat(ids, (int)CommonEnum.Deleted.删除);
                if (delresult == 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除"+(Flag==1?"部门":"班级")+"信息", UserID));
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
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, "admin"));
                ShowMessage(ex.Message);
            }
        }
        #endregion
    }
}