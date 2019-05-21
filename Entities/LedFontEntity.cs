using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK.GKICMP.Entities
{
   public  class LedFontEntity
    {
       public LedFontEntity() { }
       /// <summary>
       /// 字体名
       /// </summary>
       public string FontName { get; set; }
       /// <summary>
       /// 字号(单位磅)
       /// </summary>
       public int FontSize { get; set; }	
		/// <summary>
       /// 字体颜色
		/// </summary>
       public int FontColor { get; set; }			
       /// <summary>
       /// 是否加粗0否，1是
       /// </summary>
       public int FontBold { get; set; }		
       /// <summary>
       /// 是否斜体
       /// </summary>
       public int FontItalic { get; set; }		
       /// <summary>
       /// 时否下划线
       /// </summary>
       public int FontUnderLine { get; set; }
       /// <summary>
       /// 入场特技值（取值范围 0-38）
       /// </summary>
       public int InStyle { get; set; }	
       /// <summary>
       /// 退场特技值（现无效，预留，置0）
       /// </summary>
       public int OutStyle { get; set; }
       /// <summary>
       /// 特技显示速度(取值范围1-255)
       /// </summary>
       public int Speed { get; set; }		
       /// <summary>
       /// 页面留停时间(1-65535)
       /// </summary>
       public int DelayTime { get; set; }	
    }
}
