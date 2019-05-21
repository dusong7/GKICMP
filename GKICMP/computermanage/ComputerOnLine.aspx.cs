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
    public partial class ComputerOnLine : PageBase
    {
        ComputersDAL computersDAL = new ComputersDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public BuildingDAL buildingDAL = new BuildingDAL();
        public DataTable dtc = new ComputersDAL().GetList(1);
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
               DataTable dt = new ComputersDAL().GetList(1);//从数据库中取得数据
                HttpRuntime.Cache.Insert("ALL", dt, null,
                            DateTime.Now.AddHours(1),
                            System.Web.Caching.Cache.NoSlidingExpiration);
                ComputeList();
            }
        }
        #endregion


        //#region 获取学校名称
        ///// <summary>
        ///// 获取学校名称
        ///// </summary>
        //private void SchoolName()
        //{
        //    try
        //    {
        //        DataTable dt = ComputersBLL.GetSchoolName();
        //        if (dt != null && dt.Rows.Count > 0)
        //        {
        //            this.rp_List.DataSource = dt;
        //            this.rp_List.DataBind();
        //        }
        //        this.hf_SchoolName.Value = dt.Rows[0]["schoolname"].ToString();
        //        ComputeList();
        //    }
        //    catch (Exception)
        //    {


        //    }
        //}
        //#endregion


        //#region
        //protected void rp_List_ItemCommand(object source, RepeaterCommandEventArgs e)
        //{
        //    if (e.CommandName == "lbtn_Name")
        //    {
        //        string schoolname = e.CommandArgument.ToString();

        //        this.hf_SchoolName.Value = schoolname;
        //        ComputeList();
        //    }
        //}
        //#endregion

        #region 班班通列表
        /// <summary>
        /// 班班通列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rp_List_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                HiddenField hfModuleID = (HiddenField)e.Item.FindControl("hfbid");
                Repeater rpnextModule = (Repeater)e.Item.FindControl("rp_ImgList");
                try
                {
                    DataRow[] dr = dtc.Select("BID=" + int.Parse(hfModuleID.Value));
                    if (dr != null && dr.Length> 0)
                    {
                        DataTable dtnew = SreeenDataTable(dtc, dr);
                        rpnextModule.DataSource = dtnew;
                        rpnextModule.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                }
            }
        }
        #endregion

        public DataTable SreeenDataTable(DataTable dt, DataRow[] dr)
        {
            if (dt.Rows.Count <= 0) return dt;        //当数据为空时返回
            DataTable dtNew = dt.Clone();         //复制数据源的表结构
            for (int i = 0; i < dr.Length; i++)
            {
                dtNew.Rows.Add(dr[i].ItemArray);  // 将DataRow添加到DataTable中
            }
            return dtNew;
        }
        public string GetIDstr(object id)
        {
            return id.ToString() + "1";
        }
        public void ComputeList()
        {
            //try
            //{
            //    DataTable dt = computersDAL.GetList(1);
            //    if (dt != null && dt.Rows.Count > 0)
            //    {
            //        this.rp_ImgList.DataSource = dt;
            //        this.rp_ImgList.DataBind();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
            //}
            try
            {
                DataTable dt = buildingDAL.Get((int)CommonEnum.IsorNot.否,(int)CommonEnum.BuildingType.教学楼);
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow dr = dt.NewRow();
                    //dr["BID"] = "0";
                    //dr["BName"] = "其他";
                    //dr["BNumber"] = "0";
                    //dr["BType"] = "其他";
                    //dr["AllBuilding"] = "0";
                    //dr["AllUseArea"] = "其他";
                    //dr["BAddress"] = "0";
                    //dr["FloorNum"] = "其他";
                    //dr["BState"] = "0";
                    //dr["BOrder"] = "其他";
                    //dr["BPhoto"] = "0";
                    //dr["BAdmin"] = "其他";

                    //dr["BFlag"] = "其他";
                    //dr["Isdel"] = "0";
                    //dr["CID"] = "其他";
                    dt.Rows.Add(0,"其他","0",-2,"0","0","0",0,1,0,"","",2,0,1,"其他");
                    this.rp_List.DataSource = dt;
                    this.rp_List.DataBind();
                }
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
            }
        }
        public string GetPic(object id)
        {
            string a = "";
            if (HttpRuntime.Cache.Get(id.ToString()) != null && HttpRuntime.Cache.Get(id.ToString()).ToString() != "")
            {
                a = "data:image/png;base64," + HttpRuntime.Cache.Get(id.ToString()).ToString();
            }
            else 
            {
                a = "../images/diannaotu_05.png";
            }
            return a;
        }
    }
}