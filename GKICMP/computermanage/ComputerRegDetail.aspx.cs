/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      lfz
** 创建日期:     2017年03月03日
** 描 述:       基础数据编辑页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Data;
using System.Web.UI.WebControls;

namespace GKICMP.computermanage
{
    public partial class ComputerRegDetail : PageBase
    {
        public ComputerRegDAL computerRegDAL = new ComputerRegDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public ScreenImagesDAL screenImagesDAL = new ScreenImagesDAL();
        #region 参数集合
        /// <summary>
        /// CRID
        /// </summary>
        public string CRID
        {
            get
            {
                return GetQueryString<string>("id", "");
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
                InfoBind();
            }
        }
        #endregion


        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void InfoBind()
        {
            ComputerRegEntity model = computerRegDAL.GetObjByID(CRID);
            if (model != null)
            {
                this.ltl_ChapterName1.Text = model.ChapterName == null ? "" : model.ChapterName.ToString();

                //this.ltl_UserName.Text = model.SysID == null ? "" : model.SysID.ToString();
                this.ltl_UserName.Text = model.SysID == null ? "" : model.UserName.ToString();
                this.ltl_Subject.Text = model.CIDName == null ? "" : model.CIDName.ToString();
                this.ltl_ChapterName.Text = model.ChapterName == null ? "" : model.ChapterName.ToString();
                this.ltl_ComputerName.Text = model.ComputerName == null ? "" : model.ComputerName.ToString();
                this.ltl_IP.Text = model.IP == null ? "" : model.IP.ToString();
                this.ltl_RegDate.Text = model.RegDate == null ? "" : model.RegDate.ToString("yyyy-MM-dd HH:mm:ss");
            }
            DataTable dt = screenImagesDAL.GetList(CRID);
            if (dt != null && dt.Rows.Count > 0)
            {
                Image img_Simage;
                Literal ltl_ImageDate;
                this.rp_List.DataSource = dt;
                this.rp_List.DataBind();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    img_Simage = (Image)this.rp_List.Items[i].FindControl("img_Simage");
                    ltl_ImageDate = (Literal)this.rp_List.Items[i].FindControl("ltl_ImageDate");
                    img_Simage.ImageUrl = dt.Rows[i]["Simage"].ToString();
                    //img_Simage.ImageUrl = "data:image/png;base64," + dt.Rows[i]["Simage"];
                    ltl_ImageDate.Text = Convert.ToDateTime(dt.Rows[i]["ImageDate"]).ToString("yyyy-MM-dd HH:mm:ss");
                }
            }
        }
        #endregion


        #region 返回
        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_return_Click(object sender, EventArgs e)
        {
            Response.Redirect("ComputerRegManage.aspx");
        }
        #endregion
    }
}