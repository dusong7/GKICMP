/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年05月17日 09点30分
** 描   述:      招标详情
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using GKICMP.localhost1;
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
using System.Text;


namespace GKICMP.projectmanage
{
    public partial class JZProjectImportDetail : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public AssetDAL assetDAL = new AssetDAL();
        public JZProjectManageDAL jZProjectManageDAL = new JZProjectManageDAL();
        #region 参数集合
        /// <summary>
        /// 参数集合
        /// </summary>
        public string PID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
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
                if (PID != "")
                {
                    this.ltl_Year.Text = DateTime.Now.Year.ToString();
                    try
                    {
                        GK.GKICMP.Entities.JZProjectManageEntity model = jZProjectManageDAL.GetObjByID(PID);
                        this.ltl_Project.Text = model.ProName;
                    }
                    catch (Exception ex)
                    {
                        ShowMessage(ex.Message); return;
                    }
                    InfoBind();
                }
            }
        }
        #endregion


        #region 初始化用户数据
        /// <summary>
        /// 初始化用户数据
        /// </summary>
        private void InfoBind()
        {
            int recordCount = -1;
            //AssetEntity model = new AssetEntity(-2, (int)CommonEnum.Deleted.未删除);
            //model.DataDesc = "";
            //model.AssetName = "";
            //model.CreateUser = DepID;

            DataTable dt = assetDAL.GetPagedList(10, 1, ref recordCount, PID);

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
            InfoBind();
        }
        #endregion

        protected void btn_return_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "", "winclose();", true);
        }
    }
}