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
    /// Tea 的摘要说明
    /// </summary>
    public class Tea : IHttpHandler
    {
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public SysModuleDAL sysModuleDAL=new SysModuleDAL();
        public void ProcessRequest(HttpContext context)
        {
            string method = context.Request.Params["method"];
            switch (method)
            {
                case "TeaL":
                    TeaL(context);
                    break;
                case "GetUser":
                    GetUser(context);
                    break;
                case "GetFUrl":
                    GetUrlName(context);
                    break;
                case "RemindUpdate":
                    RemindUpdate(context);
                    break;
            }
        }


        #region 获取地址
        private void GetUrlName(HttpContext context)
        {          
            StringBuilder str = new StringBuilder("");
            SysModuleDAL sysModuleDAL = new SysModuleDAL();
            string uid = context.Request.Params["uid"];
            string mid = context.Request.Params["mid"];
            StringBuilder sb = new StringBuilder("");
            DataTable dvmodules = sysModuleDAL.GetListByUserID(Convert.ToInt32(mid), uid);
            string name = "";
            if (dvmodules != null && dvmodules.Rows.Count > 0)
            {
                foreach (DataRow row in dvmodules.Rows)
                {
                    DataTable dt = sysModuleDAL.GetTableByUID(Convert.ToInt32(row["ModuleID"].ToString()),uid);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow row1 in dt.Rows)
                        {
                            if (row1["ModuleUrl"].ToString().Length > 5)
                            {
                                if (row1["ModuleUrl"].ToString().Split('?').Length > 1)
                                {
                                    name = "{\"Name\":\"" + row1["ModuleUrl"].ToString() + "&SysMUID=" + row1["ModuleID"].ToString() + "\"}";
                                }
                                else
                                {
                                    name = "{\"Name\":\"" + row1["ModuleUrl"].ToString() + "?SysMUID=" + row1["ModuleID"].ToString() + "\"}";
                                }
                                break;
                            }
                        }
                        break;
                    }
                    else
                    {
                        if (row["ModuleUrl"].ToString().Length > 5)
                        {
                            if (row["ModuleUrl"].ToString().Split('?').Length > 1)
                            {
                                name = "{\"Name\":\"" + row["ModuleUrl"].ToString() + "&SysMUID=" + row["ModuleID"].ToString() + "\"}";
                            }
                            else
                            {
                                name = "{\"Name\":\"" + row["ModuleUrl"].ToString() + "?SysMUID=" + row["ModuleID"].ToString() + "\"}";
                            }
                            break;
                        }
                    }
                }
                str.Append("{\"result\":\"true\",\"data\":[");
                str.Append(name.ToString().TrimEnd(','));
                str.Append("]}");
            }
            else
            {
                str.Append("{\"result\":\"false\"}");
            }
            context.Response.Clear();
            context.Response.Write(str.ToString());
            context.Response.End();
        }
        #endregion

        #region 获取用户列表（剔除部门没人分组）
        /// <summary>
        /// 获取用户列表（剔除部门没人分组）
        /// </summary>
        /// <param name="context"></param>
        public void TeaL(HttpContext context)
        {
            StringBuilder sb = new StringBuilder("");
            string name = "";
            try
            {
                DataTable dt = departmentDAL.GetList((int)CommonEnum.Deleted.未删除, (int)CommonEnum.DepType.职能部门);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string a = InitChildUser((int)CommonEnum.UserType.老师, dt.Rows[i]["DID"].ToString());//调用递归方法
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



        #region 获取用户列表（剔除部门没人分组--人事管理）
        /// <summary>
        /// 获取用户列表（剔除部门没人分组）
        /// </summary>
        /// <param name="context"></param>
        public void GetUser(HttpContext context)
        {
            StringBuilder sb = new StringBuilder("");
            int datatype = context.Request.Params["data"] == "js" ? -2 : -1;//部门类型：-1为班级 -2为职能部门；
            int usertype = datatype == -2 ? 1 : 2;//1为教师，2为学生
            string name = "";
            try
            {
                DataTable dt = new DepartmentDAL().GetList((int)CommonEnum.Deleted.未删除, datatype);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string a = InitChild(usertype, dt.Rows[i]["DID"].ToString());
                        if (a == "")
                        { }
                        else
                        {
                            name += "{\"id\":\"" + dt.Rows[i]["DID"].ToString() +
                               "\",\"text\":\"" + dt.Rows[i]["DepName"].ToString() + "\",";

                            name += a;//调用递归方法

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
        public string InitChild(int usertype, string parentID)
        {
            DataTable dt = sysUserDAL.GetSysUserByDepid(usertype, int.Parse(parentID));
            StringBuilder sb = new StringBuilder();
            string name = "";

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    // string a = dt.Rows[i]["UID"].ToString();
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

        #region 获取地址
        private void RemindUpdate(HttpContext context)
        {
            StringBuilder str = new StringBuilder("");

            string uid =CommonFunction.Decrypt( context.Request.Params["UserID"]);
            string mid = context.Request.Params["mid"];
            StringBuilder sb = new StringBuilder("");
            int result = sysModuleDAL.RemindUpdate(int.Parse(mid), uid);
            if (result > 0)
            {
                str.Append("{\"result\":\"true\"}");
            }
            else
            {
                str.Append("{\"result\":\"false\"}");
            }
            context.Response.Clear();
            context.Response.Write(str.ToString());
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