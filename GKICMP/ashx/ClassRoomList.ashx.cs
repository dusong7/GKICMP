using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Text;

namespace GKICMP.ashx
{
    /// <summary>
    /// ClassRoomList 的摘要说明
    /// </summary>
    public class ClassRoomList : IHttpHandler
    {
        public ClassRoomDAL classRoomDAL = new ClassRoomDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public void ProcessRequest(HttpContext context)
        {
            string method = context.Request.Params["method"];
            switch (method)
            {
                case "CRList":
                    CRList(context);
                    break;
                case "TList":
                    TList(context);
                    break;
                case "StuList":
                    StuList(context);
                    break;
            }
            //List(context);
        }
        #region 绑定教室
        private void CRList(HttpContext context)
        {
            //DataTable dt = new ClassRoomDAL().GetTable((int)CommonEnum.IsorNot.否, 0);
            StringBuilder sb = new StringBuilder("");
            string name = "";
            try
            {
                DataTable dt = classRoomDAL.GetTable((int)CommonEnum.IsorNot.否, (int)CommonEnum.IsorNot.是);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //string a = InitChildUser(usertype, dt.Rows[i]["DID"].ToString());
                        //if (a == "")
                        //{ }
                        //else
                        //{
                        name += "{\"id\":\"" + dt.Rows[i]["CRID"].ToString() +
                           "\",\"text\":\"" + dt.Rows[i]["RoomName"].ToString() + "\"},";

                        // name += a;//调用递归方法

                        //name += ",\"state\":\"closed\"},";
                        //}
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

        #region 绑定教师
        private void TList(HttpContext context)
        {
            StringBuilder sb = new StringBuilder("");
            //int datatype = context.Request.Params["data"] == "js" ? -2 : -1;//部门类型：-1 班级 -2 职能部门；
            //int usertype = datatype == -2 ? 1 : 2;//1 教师，2 学生
            string name = "";
            try
            {
                DataTable dt = departmentDAL.GetList((int)CommonEnum.Deleted.未删除, -2);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string a = InitChildUser(1, dt.Rows[i]["DID"].ToString());
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
        public string InitChildUser(int usertype, string parentID)
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

        #region 根据年级id 绑定班级列表
        private void StuList(HttpContext context)
        {
            StringBuilder sb = new StringBuilder("");
            int gid =int.Parse(context.Request.Params["id"]);//部门类型：-1 班级 -2 职能部门；
            //int usertype = datatype == -2 ? 1 : 2;//1 教师，2 学生
            string name = "";
            try
            {
                DataTable dt = departmentDAL.GetClass((int)CommonEnum.Deleted.未删除, -1, gid);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //string a = InitChildUser(1, dt.Rows[i]["DID"].ToString());
                        //if (a == "")
                        //{ }
                        //else
                        //{
                            name += "{\"id\":\"" + dt.Rows[i]["DID"].ToString() +
                               "\",\"text\":\"" + dt.Rows[i]["OtherName"].ToString() + "\"},";

                           // name += a;//调用递归方法

                           // name += ",\"state\":\"closed\"},";
                        //}
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