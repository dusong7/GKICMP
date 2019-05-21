using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace GKICMP.ashx
{
    /// <summary>
    /// UserList 的摘要说明
    /// </summary>
    public class UserList : IHttpHandler
    {
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public void ProcessRequest(HttpContext context)
        {
            string method = context.Request.Params["method"];
            switch (method)
            {
                case "Tea":
                    GetTea(context);
                    break;
                case "GetPartner":
                    GetPartner(context);
                    break;
                case "GetClassmates":
                    GetClassmates(context);
                    break;
            }
        }
        #region 获取用户列表（剔除部门没人分组）
        /// <summary>
        /// 获取用户列表（剔除部门没人分组）
        /// </summary>
        /// <param name="context"></param>
        public void GetTea(HttpContext context)
        {
            StringBuilder sb = new StringBuilder("");
            string name = "";
            try
            {
                DataTable dt = departmentDAL.GetList((int)CommonEnum.Deleted.未删除, (int)CommonEnum.DepType.普通班级);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string a = InitChildUser((int)CommonEnum.UserType.学生, dt.Rows[i]["DID"].ToString());//调用递归方法
                        if (a == "")
                        { }
                        else
                        {
                            name += "{\"id\":\"" + dt.Rows[i]["DID"].ToString() +
                               "\",\"text\":\"" + dt.Rows[i]["DepName"].ToString() + "\",";
                            name += a;
                            name += ",\"state\":\"closed\"},";
                        }
                    }
                }
                else
                {
                    name = "[]";
                }
                sb.Append("[");
                sb.Append(name.ToString().TrimEnd(','));
                sb.Append("]");
            }

            catch (Exception error)
            {
                sb.Append("{\"result\":\"" + error.Message + "\"}");
            }

            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }


        /// <summary>
        /// 根据部门id获取用户信息
        /// </summary>
        /// <param name="usertype">用户类别</param>
        /// <param name="parentID">部门id</param>
        /// <returns></returns>
        public string InitChildUser(int usertype, string parentID)
        {
            DataTable dt = sysUserDAL.GetSysUserByDepid(usertype, int.Parse(parentID));
            StringBuilder sb = new StringBuilder();
            string name = "";

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    name += "{\"id\":\"" + dt.Rows[i]["UID"].ToString() +
                       "\",\"text\":\"" + dt.Rows[i]["RealName"].ToString() + "\"},";
                }
            }
            else
            {
                return "";
            }
            sb.Append("\"children\":[");
            sb.Append(name.ToString().TrimEnd(','));
            sb.Append("]");
            return sb.ToString();
        }
        #endregion


        #region 获取同事列表
        /// <summary>
        /// 获取同事列表
        /// </summary>
        /// <param name="context"></param>
        public void GetPartner(HttpContext context)
        {
            StringBuilder sb = new StringBuilder("");
            string name = "";
            try
            {
                DataTable dt = sysUserDAL.GetSysUserByTeac((int)CommonEnum.UserType.老师, (int)CommonEnum.Deleted.未删除);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        name += "{\"UID\":\"" + dt.Rows[i]["UID"].ToString()
                            + "\",\"RealName\":\"" + dt.Rows[i]["RealName"].ToString()
                            + "\",\"Photos\":\"" + dt.Rows[i]["Photos"].ToString().Replace("\\", "\\\\") + "\"},";
                    }
                    //sb.Append("[");
                    //sb.Append(name.ToString().TrimEnd(','));
                    //sb.Append("]");
                }
                else
                {
                    name = "[]";
                    //sb.Append("{\"result\":\"fail\"}");
                }
                //sb.Append("{\"result\":\"true\",\"data\":[");
                //sb.Append(name.ToString().TrimEnd(','));
                //sb.Append("]}");

                sb.Append("[");
                sb.Append(name.ToString().TrimEnd(','));
                sb.Append("]");
            }

            catch (Exception error)
            {
                sb.Append("{\"result\":\"" + error.Message + "\"}");
            }

            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }
        #endregion


        #region 获取同学列表
        /// <summary>
        /// 获取同学列表
        /// </summary>
        /// <param name="context"></param>
        public void GetClassmates(HttpContext context)
        {
            StringBuilder sb = new StringBuilder("");
            string depid = context.Request.Params["depid"].ToString();
            string name = "";
            try
            {
                DataTable dt = sysUserDAL.GetTable(depid);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        name += "{\"UID\":\"" + dt.Rows[i]["UID"].ToString()
                            + "\",\"RealName\":\"" + dt.Rows[i]["RealName"].ToString()
                            + "\",\"Photos\":\"" + dt.Rows[i]["Photos"].ToString().Replace("\\", "\\\\") + "\"},";
                    }
                }
                else
                {
                    name = "[]";
                }

                sb.Append("[");
                sb.Append(name.ToString().TrimEnd(','));
                sb.Append("]");
            }

            catch (Exception error)
            {
                sb.Append("{\"result\":\"" + error.Message + "\"}");
            }

            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }
        #endregion

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}