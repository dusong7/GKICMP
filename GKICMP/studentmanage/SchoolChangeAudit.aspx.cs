/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年9月8日 14时18分53秒
** 描    述:      学生变动信息审核列表页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.studentmanage
{
    public partial class SchoolChangeAudit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SchoolChangeDAL schoolChangeDAL = new SchoolChangeDAL();


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonFunction.BindEnum<CommonEnum.BDLX>(this.ddl_SCType, "-2");
                GetCondition();
                DataBindList();
            }
        }
        #endregion


        #region 获取查询条件
        public void GetCondition()
        {
            ViewState["Name"] = CommonFunction.GetCommoneString(this.txt_Name.Text.Trim());
            ViewState["SCType"] = this.ddl_SCType.SelectedValue;
            ViewState["begin"] = this.txt_Begin.Text == "" ? "1900-01-01" : this.txt_Begin.Text;
            ViewState["end"] = this.txt_End.Text == "" ? "9999-12-31" : this.txt_End.Text;
        }
        #endregion


        #region 数据绑定
        public void DataBindList()
        {
            int recordCount = 0;
            SchoolChangeEntity model = new SchoolChangeEntity();
            model.RealName = ViewState["Name"].ToString();
            model.SCType = Convert.ToInt32(ViewState["SCType"].ToString());
            DateTime begin = Convert.ToDateTime(ViewState["begin"].ToString());
            DateTime end = Convert.ToDateTime(ViewState["end"].ToString());
            model.AduitState = (int)CommonEnum.AduitState.未审核;
            DataTable dt = schoolChangeDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model, begin, end, 2);
            if (model != null && dt.Rows.Count > 0)
            {
                this.tr_null.Visible = false;
            }
            else
            {
                this.tr_null.Visible = true;
            }
            rp_List.DataSource = dt;
            Pager.RecordCount = recordCount;
            rp_List.DataBind();
            this.hf_CheckIDS.Value = "";
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


        #region 分页
        public void Pager_PageChanged(object sender, EventArgs e)
        {
            DataBindList();
        }
        #endregion


        #region 删除
        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                string ids = this.hf_CheckIDS.Value.TrimEnd(',');
                int result = schoolChangeDAL.DeleteByID(ids);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除学生变动信息", UserID));
                    ShowMessage("删除成功");
                }
                else
                {
                    ShowMessage("删除失败");
                }
                DataBindList();
                this.hf_CheckIDS.Value = "";
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                ShowMessage(ex.Message);
            }
        }
        #endregion


        public string GetColor(object sender)
        {
            try
            {
                if(Convert.ToInt32(sender.ToString())==(int)CommonEnum.AduitState.未审核)
                {
                    return "<span style='color:red'>未审核</span>";
                }
                else if (Convert.ToInt32(sender.ToString()) == (int)CommonEnum.AduitState.通过)
                {
                    return "通过";
                }
                else
                {
                    return "驳回";
                }
            }
            catch
            {
                return "";
            }
        }
    }
}