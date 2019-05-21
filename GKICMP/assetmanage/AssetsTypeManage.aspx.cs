/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      gxl
** 创建日期:    2016年11月09日
** 描 述:       资产类别管理页面
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

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Collections.Generic;

namespace GKICMP.assetmanage
{
    public partial class AssetsTypeManage : PageBase
    {
        //public SysDataDAL SysDataDAL = new SysDataDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
      // public SysData1DAL sysData1DAL = new SysData1DAL();
        public AssetTypeDAL assetTypeDAL = new AssetTypeDAL();
        #region 参数集合
        /// <summary>
        /// Flag 标示 1：校产分类管理 2：校产登记管理 3：计量单位  4：宿舍楼类型 5：专业部
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
        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //this.hf_CID.Value = Flag.ToString();
                this.hf_CID.Value = "1"; 
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
            ViewState["DataName"] = CommonFunction.GetCommoneString(this.txt_AssetName.Text.Trim());//姓名
        }
        #endregion


        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBindList()
        {
            int recordCount = -1;
            AssetTypeEntity model = new AssetTypeEntity((string)ViewState["DataName"], (int)CommonEnum.Deleted.未删除);
            model.DataType = 1;
            model.Isdel = (int)CommonEnum.Deleted.未删除;
            DataTable dt = assetTypeDAL.GetPagedList(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
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
                int delresult = assetTypeDAL.DeleteBat(ids, (int)CommonEnum.Deleted.删除);
                if (delresult > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除基础数据", UserID));
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
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                ShowMessage(ex.Message);
            }
        }
        #endregion

        protected void btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                string sdid = "";
                List<AssetTypeEntity> Entity = new List<AssetTypeEntity>();
                localhost1.WebService1 server = new localhost1.WebService1();
                localhost1.SysDataEntity[] asset;
                server.Url = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "ServerUrl") + "/WebService1.asmx";
                DataTable dt = assetTypeDAL.GetList((int)CommonEnum.IsorNot.否, 1);//1为资产分类
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        sdid += dr["SDID"].ToString() + ",";
                    }
                }
                if (server.AssetType(sdid, 2, out asset))
                {
                    if (asset.Length > 0)
                    {
                        foreach (localhost1.SysDataEntity m in asset)
                        {
                            AssetTypeEntity model = new AssetTypeEntity();
                            model.SDID = m.SDID;
                            model.DataName = m.DataName;
                            model.DataDesc = m.DataDesc;
                            model.DataType = 1;
                            model.PID = m.PID;
                            model.Isdel = (int)CommonEnum.IsorNot.否;
                            model.IsSysSet = (int)CommonEnum.IsorNot.是;
                            Entity.Add(model);
                        }
                        int result = assetTypeDAL.UpdateAssetType(Entity);
                        if (result == 0)
                        {
                            sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, "更新资产类别", UserID));
                            ShowMessage("更新成功【本次共更新" + asset.Length + "条】");
                        }
                        else
                        {
                            ShowMessage("更新失败");
                        }
                    }
                    else { ShowMessage("暂无更新，请稍后再试"); }
                }
                else
                { ShowMessage("更新出错"); }
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                ShowMessage(ex.Message);
            }
            
        }
    }
}