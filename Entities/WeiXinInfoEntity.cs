using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK.GKICMP.Entities
{
   public  class WeiXinInfoEntity
    {
       public WeiXinInfoEntity() { }
       /// <summary>
       /// 企业id
       /// </summary>
       public string CorpID { get; set; }
       /// <summary>
       /// 是否启用
       /// </summary>
       public int IsOpen { get; set; }
       /// <summary>
       /// 应用id
       /// </summary>
       public string Agent { get; set; }
       /// <summary>
       /// 应用权限
       /// </summary>
       public string Secret { get; set; }
       /// <summary>
       /// 应用凭证
       /// </summary>
       public string Access_Token { get; set; }
       /// <summary>
       /// 应用凭证取得时间
       /// </summary>
       public string Token_Time { get; set; }
    }
}
