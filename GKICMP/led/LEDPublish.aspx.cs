/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年08月22日 13时41分01秒
** 描    述:      教师听课操作类
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using System.Data;
using System.Configuration;

namespace GKICMP.led
{
    public partial class LEDPublish : PageBase
    {
        public LED_IssueDAL lED_IssueDAL = new LED_IssueDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public LEDDAL lEDDAL = new LEDDAL();

        #region 参数集合
        /// <summary>
        /// LID
        /// </summary>
        public int LIID
        {
            get
            {
                return GetQueryString<int>("id", 0);
            }
        }
        //public int LID
        //{
        //    get
        //    {
        //        return GetQueryString<int>("lid", 0);
        //    }
        //}
        #endregion
        public string name = "";

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
                CommonFunction.BindEnum<CommonEnum.LedPLAYPROP>(this.ddl_LTX, "-99");
                this.ddl_LTX.SelectedValue = ((int)CommonEnum.LedPLAYPROP.随机).ToString();
                DataTable dt = lEDDAL.GetList();
                CommonFunction.DDlTypeBind(this.ddl_LID, dt, "LID", "LName", "-999");

                if (LIID != 0)
                {
                    InfoBind();
                }
            }
        }
        #endregion

        #region 绑定数据
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void InfoBind()
        {
            try
            {
                LED_IssueEntity model = lED_IssueDAL.GetObjByID(LIID);
                if (model != null)
                {
                    this.ddl_LID.SelectedValue = model.LID.ToString();
                    this.ddl_Type.SelectedValue = model.IFlag.ToString();
                    if (model.IFlag == 1)
                    {

                        this.txt_LText.Style.Add("display", "none");
                        this.fl_UpFile.Style.Remove("display");
                        name = model.IName +"."+ model.IContent.Split('.')[model.IContent.Split('.').Length - 1];
                        this.hf_UpFile.Value = model.IContent;
                        this.hf_IName.Value = model.IName;
                    }
                    else
                        this.txt_LText.Text = model.IContent;
                    this.ddl_LFont.SelectedValue = model.FontType.ToString();
                    this.ddl_Size.SelectedValue = model.FontSize.ToString();
                    this.ddl_LVelocity.SelectedValue = model.LWidth.ToString();
                    this.ddl_LTX.SelectedValue = model.Translate.ToString();
                    this.txt_LS.Text = model.StopTime.ToString();
                    this.txt_Begin.Text = model.BeginDate.ToString("yyyy-MM-dd") == "1900-01-01" ? "" : model.BeginDate.ToString("yyyy-MM-dd");
                    this.txt_End.Text = model.EndDate.ToString("yyyy-MM-dd") == "1900-01-01" ? "" : model.EndDate.ToString("yyyy-MM-dd");
                    this.txt_BeginTime.Text = model.BeginTime.ToString("HH:mm:ss") == "00:00:00" ? "" : model.BeginTime.ToString("HH:mm:ss");
                    this.txt_EndTime.Text = model.EndTime.ToString("HH:mm:ss") == "00:00:00" ? "" : model.EndTime.ToString("HH:mm:ss");
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                return;
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
                LED_IssueEntity model = new LED_IssueEntity();
                model.LIID = LIID;
                model.LID =int.Parse( this.ddl_LID.SelectedValue);
                model.IFlag=int.Parse(this.ddl_Type.SelectedValue);
                if (model.IFlag == 1)
                {
                    int upsize = 4000000;
                    try
                    {
                        upsize = Convert.ToInt32(ConfigurationManager.AppSettings["upsize"].ToString());
                    }
                    catch (Exception) { }
                    AccessoryEntity accessinfo = CommonFunction.upfile(0, 1, hf_UpFile, "LEDFile");
                    if (accessinfo.AccessID == "-2")
                    {
                        //刚才上传的文件删除
                        CommonFunction.delfile(hf_UpFile.Value.ToString());
                        ShowMessage(accessinfo.AccessName);
                        return;
                    }
                    else
                    {
                        if (this.fl_UpFile.HasFile)
                        {
                            model.IContent = accessinfo.AccessUrl;
                            model.IName = accessinfo.AccessName;
                            CommonFunction.delfile(hf_UpFile.Value.ToString());
                            this.hf_UpFile.Value = model.IContent;
                        }
                        else
                        {
                            model.IContent = this.hf_UpFile.Value;
                            model.IName = this.hf_IName.Value;
                        }
                    }
                }
                else
                {
                    model.IContent = this.txt_LText.Text;
                    model.IName = "";
                }
                model.FontType = this.ddl_LFont.SelectedValue;
                model.FontSize = int.Parse(this.ddl_Size.SelectedValue);
                model.LWidth = int.Parse(this.ddl_LVelocity.SelectedValue);
                model.Translate = int.Parse(this.ddl_LTX.SelectedValue); ;
                model.StopTime = int.Parse(this.txt_LS.Text);
                model.BeginDate = Convert.ToDateTime(this.txt_Begin.Text == "" ? "1900-01-01" : this.txt_Begin.Text);
                model.EndDate = Convert.ToDateTime(this.txt_End.Text == "" ? "1900-01-01" : this.txt_End.Text);
                model.BeginTime = Convert.ToDateTime(this.txt_BeginTime.Text == "" ? "1900-01-01" : this.txt_BeginTime.Text);
                model.EndTime = Convert.ToDateTime(this.txt_EndTime.Text == "" ? "1900-01-01" : this.txt_EndTime.Text);
                model.CreateDate = DateTime.Now;
                model.CreateUser = UserID;
                int result = lED_IssueDAL.Edit(model);
                if (result > 0)
                {
                   // int d = SendLed();
                    int d=0;
                    if (d == 0)
                    {
                        sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, "发布内容为" + this.txt_LText.Text + "的信息", UserID));
                        ShowMessage();
                    }
                    else
                    {
                        string err=LedDll.LS_GetError(d);
                        sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, "提交成功，但发布到终端失败！失败原因：" + err, UserID));
                        ShowMessage("提交成功，但发布到终端失败！失败原因：" + err);
                    }
                }
               
               // int result = lEDDAL.Edit(model);
               
                else
                {
                    ShowMessage("发布失败");
                    return;
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                return;
            }
        }
        #endregion

        public int SendLed() 
        {
            LEDEntity lmodel = lEDDAL.GetObjByID(int.Parse(this.ddl_LID.SelectedValue));
            // LedBase model = new LedBase();
            // model.LEDType = lmodel.LType;// LED类型	0.为所有6代单色、双色、七彩卡,1.为所有6代全彩卡
            //// model.SendType = lmodel.LCType;//通讯方式0.为Tcp发送（又称固定IP通讯）,1.广播发送（又称单机直连)2.串口通讯3.磁盘保存
            // model.SendType = 1;//通讯方式0.为Tcp发送（又称固定IP通讯）,1.广播发送（又称单机直连)2.串口通讯3.磁盘保存
            // model.IpStr = lmodel.LIP;//LED屏的IP地址，只有通讯方式为0时才需赋值，其它通讯方式无需赋值
            // model.ColorType = lmodel.LColor;//屏的颜色 1.单色  2.双基色  3.七彩  4.全彩
            // model.LedWidth = lmodel.LWidth;// 屏的宽度点数
            // model.LedHeight = lmodel.LHeight;//屏的高度点数
            // model.Left = 2;//区域左上角横坐标
            // model.Top = 2;//区域左上角纵坐标
            // model.BrightnessValue = lmodel.LBright;//亮度值 0~15
            LedDll.COMMUNICATIONINFO cOMMUNICATIONINFO = new LedDll.COMMUNICATIONINFO();
            cOMMUNICATIONINFO.LEDType = lmodel.LType;
            cOMMUNICATIONINFO.SendType = lmodel.LCType;
            //cOMMUNICATIONINFO.SendType = 1;
            cOMMUNICATIONINFO.IpStr = lmodel.LIP;

            //LED显示字体
            LedDll.FONTPROP vmodel = new LedDll.FONTPROP();
            vmodel.FontName = this.ddl_LFont.SelectedValue;//字体名
            vmodel.FontSize = int.Parse(this.ddl_Size.SelectedValue);//字号(单位磅)
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
            pLAYPROP.InStyle = int.Parse(this.ddl_LTX.SelectedValue);
            pLAYPROP.OutStyle = 0;
            pLAYPROP.Speed = int.Parse(this.ddl_LVelocity.SelectedValue);
            pLAYPROP.DelayTime = int.Parse(this.txt_LS.Text);


            //定时播放节目
            LedDll.PROGRAMTIME pROGRAMTIME = new LedDll.PROGRAMTIME();
            if (this.txt_Begin.Text != "" && this.txt_End.Text != "" && this.txt_BeginTime.Text != "" && this.txt_EndTime.Text != "")
            {
                
                pROGRAMTIME.EnableFlag = LedDll.ENABLE_DATE | LedDll.ENABLE_TIME;
                pROGRAMTIME.StartYear = Convert.ToDateTime(this.txt_Begin.Text).Year;
                pROGRAMTIME.StartMonth = Convert.ToDateTime(this.txt_Begin.Text).Month;
                pROGRAMTIME.StartDay = Convert.ToDateTime(this.txt_Begin.Text).Day;
                pROGRAMTIME.StartHour = Convert.ToDateTime(this.txt_BeginTime.Text).Hour;
                pROGRAMTIME.StartMinute = Convert.ToDateTime(this.txt_BeginTime.Text).Minute;
                pROGRAMTIME.StartSecond = Convert.ToDateTime(this.txt_BeginTime.Text).Second;
                pROGRAMTIME.EndYear = Convert.ToDateTime(this.txt_Begin.Text).Year;
                pROGRAMTIME.EndMonth = Convert.ToDateTime(this.txt_Begin.Text).Month;
                pROGRAMTIME.EndDay = Convert.ToDateTime(this.txt_Begin.Text).Day;
                pROGRAMTIME.EndHour = Convert.ToDateTime(this.txt_EndTime.Text).Hour;
                pROGRAMTIME.EndMinute = Convert.ToDateTime(this.txt_EndTime.Text).Minute;
                pROGRAMTIME.EndSecond = Convert.ToDateTime(this.txt_EndTime.Text).Second;
            }
            //LedDll.PROGRAMTIME pROGRAMTIME1 = new LedDll.PROGRAMTIME();
            //pROGRAMTIME1.EnableFlag = LedDll.ENABLE_DATE | LedDll.ENABLE_TIME;
            //pROGRAMTIME1.StartYear = 2017;
            //pROGRAMTIME1.StartMonth = 11;
            //pROGRAMTIME1.StartDay = 30;
            //pROGRAMTIME1.StartHour = 08;
            //pROGRAMTIME1.StartMinute = 55;
            //pROGRAMTIME1.StartSecond = 01;
            //pROGRAMTIME1.EndYear = 2017;
            //pROGRAMTIME1.EndMonth = 11;
            //pROGRAMTIME1.EndDay = 30;
            //pROGRAMTIME1.EndHour = 08;
            //pROGRAMTIME1.EndMinute = 56;
            //pROGRAMTIME1.EndSecond = 01;


            //LedDll.FONTPROP fONTPROP=new LedDll.FONTPROP();
            //fONTPROP.FontName=this.ddl_LFont.SelectedValue;
            //节目1
            int p = LedDll.LV_CreateProgram(lmodel.LWidth, lmodel.LHeight, lmodel.LColor);//创建节目对象
            int a = LedDll.LV_AddProgram(p, 1, 1, 1);//添加一个节目
            int it = LedDll.LV_AddImageTextArea(p, 1, 1, ref aREARECT, 0);//添加一个图文区域
            int lt = 0;
            if(this.ddl_Type.SelectedValue=="1")
                //LedDll.LV_AddFileToImageTextArea(p, 1, 1, this.hf_UpFile.Value, ref pLAYPROP);//添加一个单行文本到图文区域
                lt = LedDll.LV_AddMultiLineTextToImageTextArea(p, 1, 1, LedDll.ADDTYPE_FILE, Server.MapPath(this.hf_UpFile.Value), ref vmodel, ref pLAYPROP,0,0);//添加一个单行文本到图文区域
            else
                lt = LedDll.LV_AddMultiLineTextToImageTextArea(p, 1, 1, LedDll.ADDTYPE_STRING, this.txt_LText.Text, ref vmodel, ref pLAYPROP, 0, 0);//添加一个单行文本到图文区域
            //节目2
            //int p1 = LedDll.LV_CreateProgram(lmodel.LWidth, lmodel.LHeight, lmodel.LColor);
            //int a1 = LedDll.LV_AddProgram(p1, 1, 1, 1);
            //int it1 = LedDll.LV_AddImageTextArea(p1, 1, 1, ref aREARECT, 0);
            //int ltit1 = LedDll.LV_AddSingleLineTextToImageTextArea(p1, 1, 1, 0, this.txt_LText.Text, ref vmodel, ref pLAYPROP);

            //节目1定时
            if (pROGRAMTIME.EnableFlag > 0)
            { int tt = LedDll.LV_SetProgramTime(p, 1, ref pROGRAMTIME); }
            //节目2定时
            //int st1 = LedDll.LV_SetProgramTime(p1, 1, ref pROGRAMTIME1);

            //快速添加一个单行文本区域
            // int b = LedDll.LV_QuickAddSingleLineTextArea(p, 1, 1, ref aREARECT, 0, this.txt_LText.Text, ref vmodel, int.Parse(this.ddl_LVelocity.SelectedValue));
            int d= LedDll.LV_Send(ref cOMMUNICATIONINFO, p);
            if (d == 0) 
            {
                if (pROGRAMTIME.EnableFlag==0)
                    LedDll.LV_DeleteProgram(p);
                return d;
            }
            return d;
            //int d1 = LedDll.LV_Send(ref cOMMUNICATIONINFO, p1);
        }
        protected void ddl_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddl_Type.SelectedValue == "1")
            {
                this.txt_LText.Style.Add("display", "none");
                this.fl_UpFile.Style.Remove("display");
            }
            else 
            {
                this.fl_UpFile.Style.Add("display", "none");
                this.txt_LText.Style.Remove("display");
            }
        }

        protected void lbtn_Sourse_Click(object sender, EventArgs e)
        {
            LED_IssueEntity model = lED_IssueDAL.GetObjByID(LIID);

            if (!CommonFunction.UpLoadFunciotn(model.IContent, "终端发布文件"))
            {
                ShowMessage("资源不存在，请联系系统管理员");
                return;
            }
        }
    }
}