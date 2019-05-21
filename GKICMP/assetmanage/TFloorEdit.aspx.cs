/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      樊紫红
** 创建日期:    2016年12月28日 13：55
** 描 述:      楼层编辑页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;

namespace ICMP.assetmanage
{
    public partial class TFloorEdit : PageBase
    {
        public FloorDAL floorDAL = new FloorDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public BuildingDAL buildDAL = new BuildingDAL();


        #region 参数集合
        /// <summary>
        /// ID
        /// </summary>
        public string FID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }

        public int Deep
        {
            get
            {
                return GetQueryString<int>("deep", -1);
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
                if (Deep == 0 || Deep == -1)
                {
                    this.btn_Sumbit.Visible = false;
                    this.btn_Deleted.Visible = false;
                }
                if (Deep == 1)
                {
                    this.hf_ID.Value = FID;
                }
                else
                {
                    this.hf_PID.Value = FID;
                }

            }
        }
        #endregion


        #region 初始化数据
        /// <summary>
        /// 初始化数据
        /// </summary>
        protected void InfoBind()
        {
            FloorEntity model = floorDAL.GetObj(FID);
            if (model != null)
            {
                this.txt_FloorName.Text = model.FloorName;//名称
                this.txt_FNumber.Text = model.FNumber;//
                this.txt_FOrder.Text = Convert.ToString(model.FOrder.ToString());
                this.hf_flag.Value = "1";//编辑
                this.hf_ID.Value = Convert.ToString(model.BID);
            }
        }
        #endregion


        #region 提交
        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                FloorEntity model = new FloorEntity();
                model.FID = this.hf_PID.Value.ToString();
                model.BID = Convert.ToInt32(this.hf_ID.Value.ToString());

                if (this.hf_flag.Value != "1")
                {
                    //BuildingEntity bmodel = buildDAL.GetObjByID(FID);
                    BuildingEntity bmodel = buildDAL.GetObjByID(model.BID);
                    if (bmodel != null)
                    {
                        int floornum = bmodel.FloorNum;
                        //DataTable dt = floorDAL.GetByBID(FID, (int)CommonEnum.Deleted.未删除);
                        DataTable dt = floorDAL.GetByBID(model.BID, (int)CommonEnum.Deleted.未删除);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            if (dt.Rows.Count >= floornum)
                            {
                                ShowMessage(bmodel.BName + "楼层总数为" + bmodel.FloorNum + "层，不可添加更多的楼层");
                                return;
                            }
                        }
                    }
                }

                model.FloorName = this.txt_FloorName.Text;//楼层名称
                model.FNumber = this.txt_FNumber.Text;//楼层代码
                model.Isdel = (int)CommonEnum.Deleted.未删除;
                if (this.txt_FOrder.Text == "")//排序
                {
                    model.FOrder = 0;
                }
                else
                {
                    Double rt;
                    if (System.Double.TryParse(this.txt_FOrder.Text, out rt))
                    {
                        model.FOrder = int.Parse(this.txt_FOrder.Text);
                    }
                    else
                    {
                        ShowMessage("排序号只能填写有效数字！！！");
                        return;
                    }
                }

                int result = floorDAL.Edit(model);
                if (result == -1)
                {
                    ShowMessage("提交失败");
                    return;
                }
                else if (result == -2)
                {
                    ShowMessage("该楼层名称已存在，请重新输入");
                    return;
                }
                else
                {
                    int log = FID == "" ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, (FID == "" ? "添加" : "修改") + "楼层为【" + this.txt_FloorName.Text + "】", UserID));
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script>alert('系统提示：提交成功！');succ();</script>");
                }
            }
            catch (Exception error)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, error.Message, UserID));
                ShowMessage(error.Message);
            }
        }
        #endregion


        #region 删除楼层
        /// <summary>
        /// 删除楼层
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            int istrue = floorDAL.DeleteBat(FID);
            if (istrue == 0)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除楼层【" + this.txt_FloorName.Text + "】", UserID));
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script>alert('系统提示：删除成功！');succ();</script>");
            }
            else
            {
                ShowMessage("删除失败");
                return;
            }
        }
        #endregion
    }
}