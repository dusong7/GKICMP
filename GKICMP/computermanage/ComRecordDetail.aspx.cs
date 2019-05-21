/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      lfz
** 创建日期:    2017年03月03日
** 描 述:       班班通管理页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
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

namespace GKICMP.computermanage
{
    public partial class ComRecordDetail : PageBase
    {
        ComputersDAL computersDAL = new ComputersDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        #region 参数集合
        /// <summary>
        /// TID
        /// </summary>
        public string CCID
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
                //SchoolName();
                //DataTable dt = new ComputersDAL().GetList(2);//从数据库中取得数据
                //HttpRuntime.Cache.Insert("ALL", dt, null,
                //            DateTime.Now.AddHours(1),
                //            System.Web.Caching.Cache.NoSlidingExpiration);
                ComputeList();
            }
        }
        #endregion

        public string GetIDstr(object id)
        {
            return id.ToString() + "1";
        }
        public void ComputeList()
        {
            try
            {
                DataTable dt = computersDAL.GetCRoomList(2, CCID);
                if (dt != null && dt.Rows.Count > 0)
                {
                    this.rp_ImgList.DataSource = dt;
                    this.rp_ImgList.DataBind();
                }
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
            }
        }
        
    }
}