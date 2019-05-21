using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

using GK.GKICMP.DAL;

namespace GKICMP.ashx
{
    /// <summary>
    /// StatisticsHandler 的摘要说明
    /// </summary>
    public class StatisticsHandler : IHttpHandler
    {
        public AttendRecordDAL attendRecordDAL = new AttendRecordDAL();
        public TeacherDAL teacherDAL = new TeacherDAL();
        public void ProcessRequest(HttpContext context)
        {
            string method = context.Request.Params["method"];
            switch (method)
            {
                case "Age":
                    Age(context);
                    break;
                case "Edu":
                    Edu(context);
                    break;
                case "TState":
                    TState(context);
                    break;
                case "GetAttend":
                    GetAttend(context);
                    break;
            }
        }
        private void GetAttend(HttpContext context) 
        {
            string begin = context.Request.Params["b"];
            string end = context.Request.Params["e"];
            DataTable dt;
           // dt = attendRecordDAL.GetAttend();
            //string name = string.Empty;
            //if (dt == null)
            //{
            //    name = "[]";
            //}
            StringBuilder sb = new StringBuilder();
            //if (dt.Rows.Count > 0)
            //{

            //    name = "\"S25\":" + dt.Rows[0][0] + "," + "\"S26\":" + dt.Rows[0][1] + "," + "\"S31\":" + dt.Rows[0][2] + "," + "\"S36\":" + dt.Rows[0][3] + "," + "\"S41\":" + dt.Rows[0][4] + "," + "\"S46\":" + dt.Rows[0][5] + "," + "\"S51\":" + dt.Rows[0][6] + "," + "\"S56\":" + dt.Rows[0][7] + ",";

            //}
            //sb.Append("{");
            //sb.Append(name.ToString().TrimEnd(','));
            ////sb.Append("\"result\":\"true\"");
            //sb.Append("}");
            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }
         private void Age(HttpContext context)
        {
            DataTable dt;
            dt = teacherDAL.GetAge();
            string name = string.Empty;
            if (dt == null)
            {
                name = "[]";
            }
            StringBuilder sb = new StringBuilder();
            if (dt.Rows.Count > 0)
            {

                name = "\"S25\":" + dt.Rows[0][0] + "," + "\"S26\":" + dt.Rows[0][1] + "," + "\"S31\":" + dt.Rows[0][2] + "," + "\"S36\":" + dt.Rows[0][3] + "," + "\"S41\":" + dt.Rows[0][4] + "," + "\"S46\":" + dt.Rows[0][5] + "," + "\"S51\":" + dt.Rows[0][6] + "," + "\"S56\":" + dt.Rows[0][7] + ",";

            }
            sb.Append("{");
            sb.Append(name.ToString().TrimEnd(','));
            //sb.Append("\"result\":\"true\"");
            sb.Append("}");
            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }
        private void Edu(HttpContext context)
        {
            DataTable dt;
            dt = teacherDAL.GetEdu();
            string name = string.Empty;
            if (dt == null)
            {
                name = "[]";
            }
            StringBuilder sb = new StringBuilder();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    name += "{\"DName\":\""+dr[0]+"\",\"YJS\":" + dr[1] + "," + "\"BK\":" + dr[2] + "," + "\"DZ\":" + dr[3] + "," + "\"ZS\":" + dr[4] + "},";
                }
            }
            sb.Append("{\"comments\":[");
            sb.Append(name.ToString().TrimEnd(','));
            //sb.Append("\"result\":\"true\"");
            sb.Append("]}");
            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }
        private void TState(HttpContext context)
        {
            DataTable dt;
            dt = teacherDAL.TState();
            string name = string.Empty;
            if (dt == null)
            {
                name = "[]";
            }
            StringBuilder sb = new StringBuilder();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    name += "{\"DName\":\"" + dr[0] + "\",\"ZB\":" + dr[1] + "," + "\"QP\":" + dr[2] + "},";
                }
            }
            sb.Append("{\"comments\":[");
            sb.Append(name.ToString().TrimEnd(','));
            //sb.Append("\"result\":\"true\"");
            sb.Append("]}");
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