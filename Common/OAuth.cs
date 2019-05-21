using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK.GKICMP.Common
{
   public  class OAuth
    {
       /// <summary>
       /// 返回一个64位的随机字符串
       /// </summary>
       /// <returns></returns>
      public static string RandomCode()
      {
          Random rd = new Random();
          string code = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_";
          string result = "";
          for (int i = 0; i <= 64; i++)
          {
              result += code[rd.Next(code.Length)];
          }
          return result;
      } 
    }
}
