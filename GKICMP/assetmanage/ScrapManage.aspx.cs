/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      gxl
** 创建日期:    2016年12月01日
** 描 述:       报废管理页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using System.Collections.Generic;
using System.Configuration;

namespace ICMP.assetmanage
{
    public partial class ScrapManage : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public Asset_ScrapDAL asset_ScrapDAL = new Asset_ScrapDAL();

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
                //CommonFunction.DDlDataBaseBind(this.ddl_DataType, (int)CommonEnum.DataType.资产分类);
                ViewState["CreaterUser"] = CommonFunction.GetCommoneString(this.txt_CreaterUser.Text.Trim());//资产编号
                ViewState["AssetName"] = CommonFunction.GetCommoneString(this.txt_AssetName.Text.Trim());//物品名称
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
            Asset_ScrapEntity model = new Asset_ScrapEntity(Convert.ToDateTime(ViewState["BeginDate"]), Convert.ToDateTime(ViewState["EndDate"]),(int)CommonEnum.Deleted.未删除);
            model.CreaterUser = ViewState["CreaterUser"].ToString();//报废人
            string assetname = ViewState["AssetName"].ToString();//资产名称
            DataTable dt = asset_ScrapDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model, assetname);
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
            ViewState["CreaterUser"] = CommonFunction.GetCommoneString(this.txt_CreaterUser.Text.Trim());//
            ViewState["AssetName"] = CommonFunction.GetCommoneString(this.txt_AssetName.Text.Trim());//物品名称
            ViewState["BeginDate"] = this.txt_BeginDate.Text == "" ? "1900-01-01" : this.txt_BeginDate.Text;
            ViewState["EndDate"] = this.txt_EndDate.Text == "" ? "9999-12-31" : this.txt_EndDate.Text;
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
            LinkButton lbtn = (LinkButton)sender;
            string asid = lbtn.CommandArgument;
            try
            {

                int delresult = asset_ScrapDAL.DeleteBat(asid, (int)CommonEnum.Deleted.删除);
                if (delresult > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除报废信息", UserID));
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

        #region 单条上报
        protected void lbtn_SB_Click(object sender, EventArgs e)
        {

            try
            {
                GKICMP.localhost1.WebService1 service = new GKICMP.localhost1.WebService1();
                service.Url = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "ServerUrl") + "/WebService1.asmx";
                LinkButton lbtn = (LinkButton)sender;
                string id = lbtn.CommandArgument.ToString();
                string aa = "";
                List<GKICMP.localhost1.Asset_ScrapEntity> args = new List<GKICMP.localhost1.Asset_ScrapEntity>();
                for (int i = 0; i < id.Split(',').Length; i++)
                {
                    Asset_ScrapEntity p = asset_ScrapDAL.GetObjByID(id.Split(',')[i]);
                    GKICMP.localhost1.Asset_ScrapEntity model = new GKICMP.localhost1.Asset_ScrapEntity();
                    model.ASID = p.ASID;
                    model.AID = p.AID;
                    model.ASNum = p.ASNum;
                    model.ASMark = p.ASMark;
                    model.ASDate = p.ASDate;
                    model.CreaterUser = p.CreaterUser;
                    model.Isdel = p.Isdel;
                    args.Add(model);
                }
                //service.Url = ConfigurationManager.AppSettings["URL"] + "/WebService1.asmx";
                string sguid = ConfigurationManager.AppSettings["SGUID"];
                //service.Show("1", "2", out aa);
                GKICMP.localhost1.Asset_ScrapEntity[] A = args.ToArray();
                if (service.ProScrap(sguid, A, out aa))
                {
                    int rusult = asset_ScrapDAL.Update(id);//更新字段为 已上报
                    ShowMessage(aa);
                    DataBindList();
                }
            }
            catch (Exception ex)
            {
                ShowMessage("请配置区平台网址");
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
            }
        }
        #endregion 

        #region 多条上报--测试完成
        protected void lbtn_MoreSB_Click(object sender, EventArgs e)
        {

            try
            {
                GKICMP.localhost1.WebService1 service = new GKICMP.localhost1.WebService1();
                service.Url = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "ServerUrl") + "/WebService1.asmx";
                string id = "";
                id = this.hf_CheckIDS.Value.ToString();
                id = id.TrimEnd(',').TrimStart(',');
                string aa = "";
                List<GKICMP.localhost1.Asset_ScrapEntity> args = new List<GKICMP.localhost1.Asset_ScrapEntity>();
                for (int i = 0; i < id.Split(',').Length; i++)
                {
                    Asset_ScrapEntity p = asset_ScrapDAL.GetObjByID(id.Split(',')[i]);
                    GKICMP.localhost1.Asset_ScrapEntity model = new GKICMP.localhost1.Asset_ScrapEntity();
                    model.ASID = p.ASID;
                    model.AID = p.AID;
                    model.ASNum = p.ASNum;
                    model.ASMark = p.ASMark;
                    model.ASDate = p.ASDate;
                    model.CreaterUser = p.CreaterUser;
                    model.Isdel = p.Isdel;
                    args.Add(model);
                }
              //  service.Url = ConfigurationManager.AppSettings["URL"] + "/WebService1.asmx";
                string sguid = ConfigurationManager.AppSettings["SGUID"];
                //service.Show("1", "2", out aa);
                GKICMP.localhost1.Asset_ScrapEntity[] A = args.ToArray();
                if (service.ProScrap(sguid, A, out aa))
                {
                    int rusult = asset_ScrapDAL.Update(id);//更新字段为 已上报
                    ShowMessage(aa);
                    DataBindList();
                }
            }
            catch (Exception ex)
            {
                ShowMessage("请配置区平台网址");
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, ex.Message, UserID));
            }
        }
        #endregion 


        #region 判断复选框是否可用
        /// <summary>
        /// 判断复选框是否可用
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public string GetState(object state)
        {
            string sstate = state.ToString();
            if (sstate == "1")
            {
                return "disabled";
            }
            else
            {
                return "";
            }
        }
        #endregion

    }
}