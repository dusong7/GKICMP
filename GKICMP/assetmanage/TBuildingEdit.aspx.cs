/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2016年11月17日 16时59分35秒
** 描    述:      教学楼添加
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.IO;
using System.Data;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using System.Configuration;

namespace ICMP.assetmanage
{
    public partial class TBuildingEdit : PageBase
    {
        public BuildingDAL buildingDAL = new BuildingDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public CampusDAL campusDAL = new CampusDAL();

        #region 参数集合
        /// <summary>
        /// BID 教学楼ID
        /// </summary>
        public int BID
        {
            get
            {
                return GetQueryString<int>("id", -1);
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
                DDLBind();
                if (BID != -1)
                {
                    InfoBind();
                }
            }
        }
        #endregion


        #region 下拉框数据绑定
        /// <summary>
        /// 下拉框数据绑定
        /// </summary>
        private void DDLBind()
        {
            CommonFunction.BindEnum<CommonEnum.BState>(this.ddl_BState, "-2");//教学楼状态

            DataTable dt = campusDAL.GetList((int)CommonEnum.Deleted.未删除); //校区
            CommonFunction.DDlTypeBind(this.ddl_CID, dt, "CID", "CampusName", "-2");
        }
        #endregion


        #region 初始化用户数据
        /// <summary>
        /// 初始化用户数据
        /// </summary>
        private void InfoBind()
        {
            BuildingEntity model = buildingDAL.GetObjByID(BID);
            if (model != null)
            {
                this.txt_BName.Text = model.BName.ToString();
                this.txt_BNumber.Text = model.BNumber.ToString();
                this.txt_AllBuilding.Text = model.AllBuilding.ToString();
                this.ddl_CID.SelectedValue = model.CID.ToString();
                this.txt_AllUseArea.Text = model.AllUseArea.ToString();
                this.txt_BAddress.Text = model.BAddress.ToString();
                this.txt_FloorNum.Text = model.FloorNum.ToString();
                this.ddl_BState.SelectedValue = model.BState.ToString();
                this.txt_BOrder.Text = model.BOrder.ToString();
                if (model.BPhoto != "")
                {
                    this.img_SImage.ImageUrl = this.hf_SImage.Value = model.BPhoto;
                }
            }
        }
        #endregion


        #region 提交事件
        /// <summary>
        /// 提交事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                BuildingEntity model = new BuildingEntity();
                model.BID = BID;
                model.BName = this.txt_BName.Text.ToString().Trim();
                model.BNumber = this.txt_BNumber.Text.ToString().Trim();
                model.CID = Convert.ToInt32(this.ddl_CID.SelectedValue.ToString());
                model.BType = -2;
                model.AllBuilding = Convert.ToDecimal(this.txt_AllBuilding.Text.ToString().Trim());
                model.AllUseArea = Convert.ToDecimal(this.txt_AllUseArea.Text.ToString().Trim());
                model.BAddress = this.txt_BAddress.Text.ToString().Trim();
                model.FloorNum = Convert.ToInt32(this.txt_FloorNum.Text.ToString().Trim());
                model.BState = Convert.ToInt32(this.ddl_BState.SelectedValue.ToString());
                model.BOrder = Convert.ToInt32(this.txt_BOrder.Text.ToString());
                model.BFlag = (int)CommonEnum.BuildingType.教学楼;
                //上传图片
                int upsize = 4000000;
                try
                {
                    upsize = Convert.ToInt32(ConfigurationManager.AppSettings["upsize"].ToString());
                }
                catch (Exception) { }
                AccessoryEntity accessinfo = CommonFunction.upfile(0, 1, hf_SImage, "ImageUrl");
                if (accessinfo.AccessID == "-2")
                {
                    //刚才上传的文件删除
                    CommonFunction.delfile(hf_SImage.Value.ToString());
                    ShowMessage(accessinfo.AccessName);
                    return;
                }
                else
                {
                    if (this.fl_SImage.HasFile)
                        model.BPhoto = accessinfo.AccessUrl;
                    else
                        model.BPhoto = this.hf_SImage.Value;
                }
                model.Isdel = (int)CommonEnum.Deleted.未删除;

                int result = buildingDAL.Edit(model);
                if (result == 0)
                {
                    ShowMessage();
                    int log = BID == -1 ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, (BID == -1 ? "添加" : "修改") + "宿舍楼名称为：" + this.txt_BName.Text + "的宿舍楼信息", "123"));
                }
                else if (result == -2)
                {
                    ShowMessage("系统已存在该楼宇名称，请修改后重新提交");
                    return;
                }
                else
                {
                    ShowMessage("保存失败");
                    return;
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                return;
            }
        }
        #endregion
    }
}