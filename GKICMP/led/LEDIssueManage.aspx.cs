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
    public partial class LEDIssueManage : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public LED_IssueDAL lED_IssueDAL = new LED_IssueDAL();
        public LEDDAL lEDDAL = new LEDDAL();
        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["ActName"] = CommonFunction.GetCommoneString(this.txt_LName.Text.ToString().Trim());
                ViewState["Begin"] = this.txt_Begin.Text == "" ? "1900-01-01" : this.txt_Begin.Text.ToString();
                ViewState["End"] = this.txt_End.Text == "" ? "9999-12-31" : this.txt_End.Text.ToString();
                DataBindList();
            }
        }
        #endregion





        #region 数据绑定
        private void DataBindList()
        {
            int recordCount = -1;
            LED_IssueEntity model = new LED_IssueEntity();
            model.LName = ViewState["ActName"].ToString();
            model.Begin = Convert.ToDateTime(ViewState["Begin"]);
            model.End = Convert.ToDateTime(ViewState["End"]);
            DataTable dt = lED_IssueDAL.GetPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
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
                int result = lED_IssueDAL.DeleteBat(ids);
                if (result > 0)
                {
                    ShowMessage("删除成功");
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_删除, "删除led节目信息", UserID));
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

        protected void btn_Publish_Click(object sender, EventArgs e)
        {
            string ids = this.hf_CheckIDS.Value.ToString();
            ids = ids.TrimEnd(',').TrimStart(',');
            LED_IssueEntity model = lED_IssueDAL.GetObjByID(int.Parse(ids.Split(',')[0]));
            LEDEntity lmodel = lEDDAL.GetObjByID(model.LID);

            LedDll.COMMUNICATIONINFO cOMMUNICATIONINFO = new LedDll.COMMUNICATIONINFO();
            cOMMUNICATIONINFO.LEDType = lmodel.LType;
            cOMMUNICATIONINFO.SendType = lmodel.LCType;
            //cOMMUNICATIONINFO.SendType = 1;
            cOMMUNICATIONINFO.IpStr = lmodel.LIP;
            int d = 0;
            int k = 0;
            int p = LedDll.LV_CreateProgram(lmodel.LWidth, lmodel.LHeight, lmodel.LColor);//创建节目对象
            foreach (string i in ids.Split(',')) 
            {
                k++;
                LED_IssueEntity m = lED_IssueDAL.GetObjByID(int.Parse(i));

                //字体设置
                LedDll.FONTPROP vmodel = new LedDll.FONTPROP();
                vmodel.FontName = m.FontType;//字体名
                vmodel.FontSize = m.FontSize;//字号(单位磅)
                vmodel.FontColor = LedDll.COLOR_RED;//字体颜色
                vmodel.FontBold = 0;//是否加粗0否，1是
                vmodel.FontItalic = 0;//是否斜体

                //发送区域
                LedDll.AREARECT aREARECT = new LedDll.AREARECT();
                aREARECT.left = 0;
                aREARECT.top = 0;
                aREARECT.height = lmodel.LHeight;
                aREARECT.width = lmodel.LWidth;


                //播放特效
                LedDll.PLAYPROP pLAYPROP = new LedDll.PLAYPROP();
                pLAYPROP.InStyle = m.Translate;
                pLAYPROP.OutStyle = 0;
                pLAYPROP.Speed = m.LWidth;
                pLAYPROP.DelayTime = m.StopTime;

                //定时播放节目
                LedDll.PROGRAMTIME pROGRAMTIME = new LedDll.PROGRAMTIME();
                if (m.BeginDate.ToString("yyyy-MM-dd")!= "1900-01-01")
                {

                    pROGRAMTIME.EnableFlag = LedDll.ENABLE_DATE | LedDll.ENABLE_TIME;
                    pROGRAMTIME.StartYear = Convert.ToDateTime(m.BeginDate).Year;
                    pROGRAMTIME.StartMonth = Convert.ToDateTime(m.BeginDate).Month;
                    pROGRAMTIME.StartDay = Convert.ToDateTime(m.BeginDate).Day;
                    pROGRAMTIME.StartHour = Convert.ToDateTime(m.BeginTime).Hour;
                    pROGRAMTIME.StartMinute = Convert.ToDateTime(m.BeginTime).Minute;
                    pROGRAMTIME.StartSecond = Convert.ToDateTime(m.BeginTime).Second;
                    pROGRAMTIME.EndYear = Convert.ToDateTime(m.EndDate).Year;
                    pROGRAMTIME.EndMonth = Convert.ToDateTime(m.EndDate).Month;
                    pROGRAMTIME.EndDay = Convert.ToDateTime(m.EndDate).Day;
                    pROGRAMTIME.EndHour = Convert.ToDateTime(m.EndTime).Hour;
                    pROGRAMTIME.EndMinute = Convert.ToDateTime(m.EndTime).Minute;
                    pROGRAMTIME.EndSecond = Convert.ToDateTime(m.EndTime).Second;
                }
                int a = LedDll.LV_AddProgram(p, k, 0, 0);//添加一个节目
                int it = LedDll.LV_AddImageTextArea(p, k, 1, ref aREARECT, 0);//添加一个图文区域
                int lt = 0;
                if (m.IFlag==1)
                    //LedDll.LV_AddFileToImageTextArea(p, 1, 1, this.hf_UpFile.Value, ref pLAYPROP);//添加一个单行文本到图文区域
                    lt = LedDll.LV_AddMultiLineTextToImageTextArea(p, k, 1, LedDll.ADDTYPE_FILE, Server.MapPath(m.IContent), ref vmodel, ref pLAYPROP, 0, 0);//添加一个单行文本到图文区域
                else
                    lt = LedDll.LV_AddMultiLineTextToImageTextArea(p, k, 1, LedDll.ADDTYPE_STRING, m.IContent, ref vmodel, ref pLAYPROP, 0, 0);//添加一个单行文本到图文区域
                if (pROGRAMTIME.EnableFlag > 0)
                { 
                    int tt = LedDll.LV_SetProgramTime(p, 1, ref pROGRAMTIME); 
                }
                 d = LedDll.LV_Send(ref cOMMUNICATIONINFO, p);

            }
            if (d == 0) 
            {
                ShowMessage("发布成功");
            }
        }
    }
}