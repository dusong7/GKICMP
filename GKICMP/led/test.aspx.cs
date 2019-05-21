using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;

namespace GKICMP.led
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                //LED基础属性实体
                LedBase model=new LedBase();
                model.LEDType = 0;// LED类型	0.为所有6代单色、双色、七彩卡,1.为所有6代全彩卡
                model.SendType = 1;//通讯方式0.为Tcp发送（又称固定IP通讯）,1.广播发送（又称单机直连)2.串口通讯3.磁盘保存
                model.IpStr = "10.168.7.111";//LED屏的IP地址，只有通讯方式为0时才需赋值，其它通讯方式无需赋值
                model.ColorType = 1;//屏的颜色 1.单色  2.双基色  3.七彩  4.全彩
                model.LedWidth = 32;// 屏的宽度点数
                model.LedHeight = 16;//屏的高度点数
                model.Left = 2;//区域左上角横坐标
                model.Top = 2;//区域左上角纵坐标
                model.BrightnessValue = 15;//亮度值 0~15
                //LED显示属性实体
                LedFontEntity vmodel = new LedFontEntity();
                vmodel.FontName = "宋体";//字体名
                vmodel.FontSize = 20;//字号(单位磅)
                vmodel.FontColor = LedDll.COLOR_RED;//字体颜色
                vmodel.FontBold = 0;//是否加粗0否，1是
                vmodel.FontItalic = 0;//是否斜体
                vmodel.InStyle = (int)CommonEnum.LedPLAYPROP.随机;//入场特技值（取值范围 0-38）
                vmodel.OutStyle = 0;//退场特技值（现无效，预留，置0）
                vmodel.Speed = 3;//特技显示速度1-255
                vmodel.DelayTime = 3;//页面停留时间1-65535

               //int result=  LV_PowerOnOff(model, 0);
            }
        }
        #region 测试是否可以接入
        /// <summary>
        /// 测试是否可以接入
        /// </summary>
        /// <param name="model">实体参数包含led类型，通讯方式，ip地址</param>
        /// <returns>0成功</returns>
        public int LV_TestOnline(LedBase model)
        {
            LedDll.COMMUNICATIONINFO ledInfo = new LedDll.COMMUNICATIONINFO();
            ledInfo.LEDType = model.LEDType;
            ledInfo.SendType = model.SendType;
            ledInfo.IpStr = model.IpStr;
            return LedDll.LV_TestOnline(ref ledInfo);
            
        }
        #endregion
        #region 设置屏参
        /// <summary>
        /// 设置屏参
        /// </summary>
        /// <param name="model">屏参实体</param>
        /// <returns>0成功</returns>
        public int LV_SetBasicInfo(LedBase model)
        {
            LedDll.COMMUNICATIONINFO ledInfo = new LedDll.COMMUNICATIONINFO();
            ledInfo.LEDType = model.LEDType;
            ledInfo.SendType = model.SendType;
            ledInfo.IpStr = model.IpStr;
            return LedDll.LV_SetBasicInfo(ref ledInfo, model.ColorType, model.LedWidth, model.LedHeight);
        } 
        #endregion

        #region 开关屏
        /// <summary>
        /// 开关屏
        /// </summary>
        /// <param name="model">led基本参数</param>
        /// <param name="OnOff">开关值1.关屏  0.开屏</param>
        /// <returns>0成功</returns>
        public int LV_PowerOnOff(LedBase model, int OnOff)
        {
            LedDll.COMMUNICATIONINFO ledInfo = new LedDll.COMMUNICATIONINFO();
            ledInfo.LEDType = model.LEDType;
            ledInfo.SendType = model.SendType;
            ledInfo.IpStr = model.IpStr;
            return LedDll.LV_PowerOnOff(ref ledInfo, OnOff);
        } 
        #endregion

        #region 设置led亮度
        /// <summary>
        /// 设置led亮度
        /// </summary>
        /// <param name="model">led基本参数</param>
        /// <param name="BrightnessValue">亮度值 0~15</param>
        /// <returns>0成功</returns>
        public int LV_SetBrightness(LedBase model)
        {
            LedDll.COMMUNICATIONINFO ledInfo = new LedDll.COMMUNICATIONINFO();
            ledInfo.LEDType = model.LEDType;
            ledInfo.SendType = model.SendType;
            ledInfo.IpStr = model.IpStr;
            return LedDll.LV_SetBrightness(ref ledInfo, model.BrightnessValue);
        } 
        #endregion

        #region 发送led消息
        #region 创建节目对象
        /// <summary>
        /// 创建节目对象
        /// </summary>
        /// <param name="LedWidth">Led宽度</param>
        /// <param name="LedHeight">Led高度</param>
        /// <param name="ColorType">Led屏的颜色1.单色  2.双基色  3.七彩  4.全彩</param>
        /// <returns>节目对象句柄，0失败</returns>
        public int LV_CreateProgram(int LedWidth, int LedHeight, int ColorType)
        {
            return LedDll.LV_CreateProgram(LedWidth, LedHeight, ColorType);
        }
        #endregion

        #region 添加一个节目
        /// <summary>
        /// 添加一个节目
        /// </summary>
        /// <param name="hProgram">节目对象句柄（上述方法创建节目对象的返回值）</param>
        /// <param name="ProgramNo">节目号一般为1</param>
        /// <param name="ProgramTime">节目播放时长 0.节目播放时长  非0.指定播放时长</param>
        /// <param name="LoopCount">循环播放次数</param>
        /// <returns>0成功</returns>
        public int LV_AddProgram(int hProgram, int ProgramNo, int ProgramTime, int LoopCount)
        {
            return LedDll.LV_AddProgram(hProgram, ProgramNo, ProgramTime, LoopCount);
        }
        #endregion

        #region 添加一个图文区域
        /// <summary>
        /// 添加一个图文区域
        /// </summary>
        /// <param name="hProgram">节目对象句柄</param>
        /// <param name="ProgramNo">节目号,跟上述方法的节目号一致</param>
        /// <param name="AreaNo">区域号</param>
        /// <param name="pAreaRect">区域坐标属性</param>
        /// <param name="IsBackgroundArea">是否为背景区域</param>
        /// <returns>0成功</returns>
        public int LV_AddImageTextArea(int hProgram, int ProgramNo, int AreaNo, LedBase model, int IsBackgroundArea)
        {
            LedDll.AREARECT pAreaRect = new LedDll.AREARECT();
            pAreaRect.left = model.Left;
            pAreaRect.top = model.Top;
            pAreaRect.width = model.LedWidth;
            pAreaRect.height = model.LedHeight;
            return LedDll.LV_AddImageTextArea(hProgram, ProgramNo, AreaNo, ref pAreaRect, IsBackgroundArea);
        }
        #endregion

        #region 添加一个多行文本到图文区
        /// <summary>
        /// 添加一个多行文本到图文区
        /// </summary>
        /// <param name="hProgram">节目对象句柄</param>
        /// <param name="ProgramNo">节目号,跟上述方法的节目号一致</param>
        /// <param name="AreaNo">区域号</param>
        /// <param name="AddType">添加的类型  0.为字符串  1.文件（只支持txt和rtf文件）</param>
        /// <param name="AddStr">AddType为0则为字符串数据,AddType为1则为文件路径(所要发送的文字)</param>
        /// <param name="MODEL">文字显示类</param>
        /// <param name="nAlignment">水平对齐样式，0.左对齐  1.右对齐  2.水平居中</param>
        /// <param name="IsVCenter">是否垂直居中  0.置顶（默认） 1.垂直居中</param>
        /// <returns>0成功</returns>
        public int LV_AddMultiLineTextToImageTextArea(int hProgram, int ProgramNo, int AreaNo, int AddType, string AddStr, LedFontEntity MODEL, int nAlignment, int IsVCenter)
        {
            LedDll.FONTPROP pFontProp = new LedDll.FONTPROP();
            pFontProp.FontName = MODEL.FontName;
            pFontProp.FontSize = MODEL.FontSize;
            pFontProp.FontColor = MODEL.FontColor;
            pFontProp.FontBold = MODEL.FontBold;
            pFontProp.FontItalic = MODEL.FontItalic;
            pFontProp.FontUnderLine = MODEL.FontUnderLine;
            LedDll.PLAYPROP pPlayProp = new LedDll.PLAYPROP();
            pPlayProp.InStyle = MODEL.InStyle;
            pPlayProp.OutStyle = MODEL.OutStyle;
            pPlayProp.Speed = MODEL.Speed;
            pPlayProp.DelayTime = MODEL.DelayTime;
            //可以添加多个子项到图文区，如下添加可以选一个或多个添加
            return LedDll.LV_AddMultiLineTextToImageTextArea(hProgram, ProgramNo, AreaNo, AddType, AddStr, ref pFontProp, ref pPlayProp, nAlignment, IsVCenter);
        }
        #endregion

        #region 发送节目，此发送为一对一发送
        /// <summary>
        ///  发送节目，此发送为一对一发送
        /// </summary>
        /// <param name="model">Led屏基本信息类</param>
        /// <param name="hProgram">节目对象句柄</param>
        /// <returns>0成功</returns>
        public int LV_Send(LedBase model, int hProgram)
        {
            LedDll.COMMUNICATIONINFO ledInfo = new LedDll.COMMUNICATIONINFO();
            ledInfo.LEDType = model.LEDType;
            ledInfo.SendType = model.SendType;
            ledInfo.IpStr = model.IpStr;
            return LedDll.LV_Send(ref ledInfo, hProgram);
        }
        #endregion

        #region 销毁节目对象
        /// <summary>
        /// 销毁节目对象
        /// </summary>
        /// <param name="hProgram">节目对象句柄</param>
        /// <returns></returns>
        public void LV_DeleteProgram(int hProgram)
        {
            LedDll.LV_DeleteProgram(hProgram);
        }
        #endregion 
        #endregion
    }
}