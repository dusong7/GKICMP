using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public  class WeiXinUser
    {
       public WeiXinUser(){}
       /// <summary>
       /// 微信用户id
       /// </summary>
       public string userid { get; set; }
       /// <summary>
       /// 成员名称
       /// </summary>
       public string name { get; set; }
       /// <summary>
       /// 成员所属部门id列表,不超过20个eg：[1,2,3]
       /// </summary>
       public string department { get; set; }
       /// <summary>
       /// 职位信息
       /// </summary>
       public string position { get; set; }
       /// <summary>
       /// 手机号码。企业内必须唯一
       /// </summary>
       public string mobile { get; set; }
       /// <summary>
       /// 性别：1表示男性，2表示女性
       /// </summary>
       public int gender { get; set; }
       /// <summary>
       /// 邮箱
       /// </summary>
       public string email { get; set; }
       /// <summary>
       /// 微信号
       /// </summary>
       public string weixinid { get; set; }
    }
}
