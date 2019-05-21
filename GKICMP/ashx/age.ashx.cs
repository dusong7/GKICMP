using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GKICMP.ashx
{
    /// <summary>
    /// age 的摘要说明
    /// </summary>
    public class age : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("[{\"id\": \"\", \"text\": \"选择全部\",\"children\": [{ \"id\": 1, \"text\": \"25岁以下\" },{ \"id\": 2, \"text\": \"26-30\" },{ \"id\": 3, \"text\": \"31-35\" },{ \"id\": 4, \"text\": \"36-40\" },{ \"id\": 5, \"text\": \"41-45\" }, { \"id\": 6, \"text\": \"46-50\" }, { \"id\": 7, \"text\": \"51-55\" },{ \"id\": 8, \"text\": \"56-60\" }] }]");
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}