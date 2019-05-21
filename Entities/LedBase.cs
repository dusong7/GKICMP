using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK.GKICMP.Entities
{
    public class LedBase
    {
        public LedBase() { }
        /// <summary>
        /// LED类型	0.为所有6代单色、双色、七彩卡,1.为所有6代全彩卡
        /// </summary>
        public int LEDType { get; set; }
        /// <summary>
        /// 通讯方式0.为Tcp发送（又称固定IP通讯）,1.广播发送（又称单机直连)2.串口通讯3.磁盘保存
        /// </summary>
        public int SendType { get; set; }
        /// <summary>
        /// LED屏的IP地址，只有通讯方式为0时才需赋值，其它通讯方式无需赋值
        /// </summary>
        public string IpStr { get; set; }
        /// <summary>
        /// 屏的颜色 1.单色  2.双基色  3.七彩  4.全彩
        /// </summary>
        public int ColorType { get; set; }
        /// <summary>
        /// 屏的宽度点数
        /// </summary>
        public int LedWidth { get; set; }
        /// <summary>
        /// 屏的高度点数
        /// </summary>
        public int LedHeight { get; set; }
        /// <summary>
        /// 区域左上角横坐标
        /// </summary>
        public int Left { get; set; }
        /// <summary>
        /// 区域左上角纵坐标
        /// </summary>
        public int Top { get; set; }
        /// <summary>
        /// 亮度值 0~15
        /// </summary>
        public int BrightnessValue { get; set; }
    }
}
