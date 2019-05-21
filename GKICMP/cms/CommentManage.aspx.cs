/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2016年10月15日 13时56分24秒
** 描    述:      教师合同管理界面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
******************************************************************/
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GKICMP.cms
{
    public partial class CommentManage : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public Web_CommentDAL web_CommentDAL = new Web_CommentDAL();

        #region 参数集合
        /// <summary>
        /// Flag 标示 1：留言 2：评论
        /// </summary>
        public int Flag
        {
            get
            {
                return GetQueryString<int>("flag", -1);
            }
        }

        /// <summary>
        /// 站点ID
        /// </summary>
        public int SID
        {
            get
            {
                return GetQueryString<int>("SID", -1);
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
                this.hf_CID.Value = Flag.ToString();
                if (Flag == 1)
                {
                    this.lbl_Menuname.Text = "留言管理";
                    this.ltl_content.Text = this.ltl_date.Text = this.ltl_ComTitle.Text = this.ltl_OutDate.Text = this.ltl_title.Text = "留言";
                }
                if (Flag == 2)
                {
                    this.lbl_Menuname.Text = "评论管理";
                    this.ltl_content.Text = this.ltl_date.Text = this.ltl_ComTitle.Text = this.ltl_OutDate.Text = this.ltl_title.Text = "评论";
                }

                CommonFunction.BindEnum<CommonEnum.IsorNot>(this.ddl_IsPublish, "-2");//是否公开

                ViewState["ComTitle"] = CommonFunction.GetCommoneString(this.txt_ComTitle.Text.Trim());//
                ViewState["BeginDate"] = this.txt_BeginDate.Text == "" ? "1900-01-01" : this.txt_BeginDate.Text;
                ViewState["EndDate"] = this.txt_EndDate.Text == "" ? "9999-12-31" : this.txt_EndDate.Text;
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
            Web_CommentEntity model = new Web_CommentEntity(Convert.ToDateTime(ViewState["BeginDate"]), Convert.ToDateTime(ViewState["EndDate"]), (int)CommonEnum.Deleted.未删除, int.Parse(this.ddl_IsPublish.SelectedValue));
            model.ComTitle = ViewState["ComTitle"].ToString();
            model.CFlag = Flag;

            DataTable dt = web_CommentDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
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
            ViewState["ComTitle"] = CommonFunction.GetCommoneString(this.txt_ComTitle.Text.Trim());//
            ViewState["BeginDate"] = this.txt_BeginDate.Text == "" ? "1900-01-01" : this.txt_BeginDate.Text;
            ViewState["EndDate"] = this.txt_EndDate.Text == "" ? "9999-12-31" : this.txt_EndDate.Text;
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
                string[] rid = ids.Split(',');
                int delresult = web_CommentDAL.DeleteBat(ids, (int)CommonEnum.Deleted.删除);
                if (delresult > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除留言", UserID));
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
    }
}