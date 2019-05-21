
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;

namespace GKICMP.sysmanage
{
    public partial class SysUserType : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SysUser_TypeDAL sysUser_TypeDAL = new SysUser_TypeDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonFunction.BindEnum<CommonEnum.HumanType>(this.ddl_SType, "-2");
                DataBindList();
            }
        }
        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {
           
            DataTable dt = new DataTable();
            int recordCount = -1;
            //model = new UserTypeEntity(Convert.ToInt32(ViewState["SType"]));
            SysUser_TypeEntity model = new SysUser_TypeEntity();
            model.SType = int.Parse(this.ddl_SType.SelectedValue);
            dt = sysUser_TypeDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);

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
           // CommonFunction.BindEnum<CommonEnum.HumanType>(this.ddl_SType, "-2");
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
                int delresult = sysUser_TypeDAL.DeleteBat(ids);
                if (delresult > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除人员分类信息", UserID));
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
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志,ex.Message, UserID));
                ShowMessage(ex.Message);
                return;
            }
        }
        #endregion    
    }
}