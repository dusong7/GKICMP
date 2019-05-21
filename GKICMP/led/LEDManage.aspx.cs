/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年11月15日 9时41分32秒
** 描    述:      教师活动列表页面
** 修 改 人:      
** 修改日期:      
** 修改说明:      
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.led
{
    public partial class LEDManage : PageBase
    {
       
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public LEDDAL lEDDAL = new LEDDAL();

        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataBindList();
            }
        }
        #endregion


       


        #region 数据绑定
        private void DataBindList()
        {
            int recordCount = -1;
            LEDEntity model = new LEDEntity();
            DataTable dt = lEDDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
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
            this.rp_List.DataBind();
            this.hf_CheckIDS.Value = "";
        }
        #endregion


        #region 查询事件
        protected void btn_Search_Click(object sender, EventArgs e)
        {
           
            DataBindList();
        }
        #endregion


        #region 分页事件
        protected void Pager_PageChanged(object sender, EventArgs e)
        {
            DataBindList();
        }
        #endregion


        #region 删除事件
        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                string ids = this.hf_CheckIDS.Value.ToString();
                ids = ids.TrimEnd(',').TrimStart(',');
                int result = lEDDAL.DeleteBat(ids);
                if (result > 0)
                {
                    ShowMessage("删除成功");
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除led屏信息", UserID));
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
                ShowMessage(ex.Message);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                return;
            }
        }
        #endregion

        protected void lbtn_OC_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            string id = lbtn.CommandArgument;
            LEDEntity model = lEDDAL.GetObjByID(int.Parse(id));
            LedDll.COMMUNICATIONINFO ledInfo = new LedDll.COMMUNICATIONINFO();
            ledInfo.LEDType = model.LType;
            ledInfo.SendType = model.LCType;
            ledInfo.IpStr = model.LIP;
            int result = lEDDAL.IsOpen(int.Parse(id));
            if (result >0) 
           {
               int r = LedDll.LV_PowerOnOff(ref ledInfo, model.IsOpen == 1 ? 0 : 1);
               if (r == 0)
               {
                   ShowMessage("提交成功");
                   DataBindList();
               }
           }
        }
    }
}