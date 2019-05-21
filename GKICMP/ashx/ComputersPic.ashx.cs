using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using System.Runtime.Remoting.Contexts;
using System.Web.Caching;
using GK.GKICMP.Entities;
using System.Threading;


namespace GKICMP.ashx
{
    /// <summary>
    /// ComputersPic 的摘要说明
    /// </summary>
    public class ComputersPic : IHttpHandler
    {
        public ComputersDAL computersDAL = new ComputersDAL();
        public ComRecordDAL comRecordDAL = new ComRecordDAL();
        public void ProcessRequest(HttpContext context)
        {
            string method = context.Request.Params["method"];
            switch (method)
            {
                case "GetPic":
                    GetPic(context);
                    break;
                case "GetRecord":
                    GetRecord(context);
                    break;
            }
            //GetPic(context);
        }

        private void GetPic(HttpContext context)
        {
            StringBuilder sb = new StringBuilder("");
           // string schoolname = context.Request.Params["schoolname"];
            string name = "";
            try
            {
                DataTable dt = new DataTable();
                if (HttpRuntime.Cache["ALL"] != null)
                {
                    dt = (DataTable)HttpRuntime.Cache["ALL"];
                    if (dt.Rows.Count < 1) 
                    {
                        dt = computersDAL.GetList(1);//从数据库中取得数据
                        HttpRuntime.Cache.Insert("ALL", dt, null,
                                    DateTime.Now.AddHours(1),
                                    System.Web.Caching.Cache.NoSlidingExpiration);
                    }
                }
                else
                {
                    dt = computersDAL.GetList(1);//从数据库中取得数据
                    HttpRuntime.Cache.Insert("ALL", dt, null,
                                DateTime.Now.AddHours(1),
                                System.Web.Caching.Cache.NoSlidingExpiration);

                }
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string a = dt.Rows[i]["MAC"].ToString();
                        if (HttpRuntime.Cache[a] != null)
                        {
                            //if (!string.IsNullOrEmpty(HttpRuntime.Cache.Get(dt.Rows[i]["MAC"].ToString()).ToString()))
                            //{
                                //name += "{\"Guid\":\"" + dt.Rows[i]["GUID"].ToString() + "\",\"image\":\"" + HttpRuntime.Cache.Get(dt.Rows[i]["GUID"].ToString()) + "\"},";
                                name += "{\"mac\":\"" + dt.Rows[i]["mac"].ToString() +
                                    "\",\"image\":\"" + HttpRuntime.Cache.Get(dt.Rows[i]["MAC"].ToString()) +
                                    "\",\"mac1\":\" " + HttpRuntime.Cache.Get(dt.Rows[i]["MAC"].ToString() + "1") +
                                    "\"},";
                            //}
                            //else
                            //{ }
                                HttpRuntime.Cache.Insert(dt.Rows[i]["MAC"].ToString(), "", null, DateTime.MaxValue, TimeSpan.Zero, CacheItemPriority.Normal, null);
                               // HttpRuntime.Cache.Remove(dt.Rows[i]["MAC"].ToString());
                        }
                      // new  SysLogDAL().Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, name, context.Request.Params["UserID"]));
                      
                    }
                    sb.Append("{\"result\":\"true\",\"data\":[");
                    sb.Append(name.ToString().TrimEnd(','));
                    sb.Append("]}");
                }

                //DataTable dt = ComputersBLL.GetList(schoolname);
                ////DataTable dt = ComputerRegBLL.GetBBT();
                //if (dt.Rows.Count > 0)
                //{
                //    for (int i = 0; i < dt.Rows.Count; i++)
                //    {
                //        if (!string.IsNullOrEmpty(HttpRuntime.Cache.Get(dt.Rows[i]["GUID"].ToString()).ToString()))
                //        {
                //            //name += "{\"Guid\":\"" + dt.Rows[i]["GUID"].ToString() + "\",\"image\":\"" + HttpRuntime.Cache.Get(dt.Rows[i]["GUID"].ToString()) + "\"},";
                //            name += "{\"Guid\":\"" + dt.Rows[i]["GUID"].ToString() + 
                //                "\",\"image\":\"" + HttpRuntime.Cache.Get(dt.Rows[i]["GUID"].ToString()) +
                //                "\",\"guid1\":\" "+ HttpRuntime.Cache.Get(dt.Rows[i]["GUID"].ToString()+"1") +
                //                "\"},";
                //        }
                //        else
                //        { }

                //    }
                //    sb.Append("{\"result\":\"true\",\"data\":[");
                //    sb.Append(name.ToString().TrimEnd(','));
                //    sb.Append("]}");
                //}
            }
            catch (Exception error)
            {
                sb.Append("{\"result\":\"fail\"}");
            }
            //try
            //{

            //    DataTable dt = ComputerRegBLL.GetBBT();
            //    if (dt.Rows.Count > 0)
            //    {
            //        for (int i = 0; i < dt.Rows.Count; i++)
            //        {
            //            TimeSpan ts = DateTime.Now - Convert.ToDateTime(dt.Rows[i]["ImageDate"]);
            //            if (ts.Minutes > 3) { }
            //            // name += "{\"Guid\":\"" + dt.Rows[i]["GUID"].ToString() + "\",\"image\":\"" + dt.Rows[i]["simage"].ToString() + "\"},";
            //            else
            //            //byte[] bytes =;
            //            //string image = Convert.ToBase64String((byte[])dt.Rows[i]["simage"]);
            //            { name += "{\"Guid\":\"" + dt.Rows[i]["GUID"].ToString() + "\",\"image\":\"" + dt.Rows[i]["simage"].ToString() + "\"},"; }

            //        }
            //        sb.Append("{\"result\":\"true\",\"data\":[");
            //        sb.Append(name.ToString().TrimEnd(','));
            //        sb.Append("]}");
            //    }
            //}
            //catch (Exception error)
            //{
            //    sb.Append("{\"result\":\"fail\"}");
            //}

            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }
        private void GetRecord(HttpContext context)
        {
            StringBuilder sb = new StringBuilder("");
            string ccid = context.Request.Params["ccid"];
            string name = "";
            try
            {
                DataTable dt = comRecordDAL.GetList(ccid);

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        name += "{\"Mac\":\"" + dt.Rows[i]["Mac"].ToString() +
                            "\",\"RegDate\":\"" + dt.Rows[i]["RegDate"].ToString() +
                            "\",\"UserName\":\" " + dt.Rows[i]["UserName"].ToString() +
                            "\"},";

                    }
                    sb.Append("[");
                    sb.Append(name.ToString().TrimEnd(','));
                    sb.Append("]");
                }
            }
            catch (Exception error)
            {
                sb.Append("{\"result\":\"fail\"}");
            }
            context.Response.Clear();
            context.Response.Write(sb.ToString());
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