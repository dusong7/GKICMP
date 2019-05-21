using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GK.GKICMP.DAL;
using System.IO;
using System.Text;
using GK.GKICMP.Entities;
using GK.GKICMP.Common;

namespace GKICMP.ashx
{
    /// <summary>
    /// SetDownLoad 的摘要说明
    /// </summary>
    public class SetDownLoad : IHttpHandler
    {
        public EduResourceDAL eduResourceDAL = new EduResourceDAL();
        public void ProcessRequest(HttpContext context)
        {
            if (HttpContext.Current.Request.HttpMethod.ToUpper() == "POST") 
            {
                DownLoad();
            }
            //string method = context.Request.Params["method"];
            //switch (method)
            //{
            //    case "check":
            //        GetPsw(context);
            //        break;
            //    //case "Update":
            //    //    UpdatePost(context);
            //    //    break;
            //}
        }
        public void GetPsw(HttpContext context)
        {
           int erid=int.Parse( HttpContext.Current.Request.QueryString["id"]);
           EduResourceEntity model = eduResourceDAL.GetObjByID(erid);
           StringBuilder sb = new StringBuilder();
           if (model != null && model.ERPwd != "") 
           {
              
               sb.Append("{\"result\":\"success\"}");
              
           }
           else
           {
               sb.Append("{\"result\":\"error\"}");
           }
           context.Response.Clear();
           context.Response.Write(sb.ToString());
           context.Response.End();
        }
        public void DownLoad()
        {
          string erid=  HttpContext.Current.Request.QueryString["id"];
          string psw = HttpContext.Current.Request.QueryString["psw"];
          StringBuilder sb = new StringBuilder();
          if (psw != null)
          {
              EduResourceEntity model = eduResourceDAL.GetObjByID(int.Parse(erid));
              if (model != null && model.ERPwd != "")
              {
                  if (CommonFunction.Decrypt(model.ERPwd) == psw)
                  {
                      sb.Append("{\"result\":\"success\"}");
                  }
                  else 
                  {
                      sb.Append("{\"result\":\"error\"}");
                  }
              }
          }
          else 
          {
              int result = eduResourceDAL.DownLoad(erid);
              sb.Append("{\"result\":\"success\"}");
          }
          //using (Stream stream = HttpContext.Current.Request.InputStream)
          //{
          //    Byte[] postBytes = new Byte[stream.Length];
          //    stream.Read(postBytes, 0, (Int32)stream.Length);
          //    string postString = Encoding.UTF8.GetString(postBytes);
          //}

         
          //if (result > 0) 
          //{ }
          HttpContext.Current.Response.Clear();
          HttpContext.Current.Response.Write(sb.ToString());
          HttpContext.Current.Response.End();
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