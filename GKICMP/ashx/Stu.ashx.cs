
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;

namespace GKICMP.ashx
{
    /// <summary>
    /// Stu 的摘要说明:对学生的绑定操作
    /// </summary>
    public class Stu : IHttpHandler
    {
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public GradeDAL gradeDAL = new GradeDAL();
        public TeacherDAL teacherDAL = new TeacherDAL();
        public void ProcessRequest(HttpContext context)
        {
            string method = context.Request.Params["method"];
            switch (method)
            {
                case "StuL":
                    StuL(context);
                    break;
                case "StuGrade":
                    StuGrade(context);
                    break;
            }
        }

        #region 对学生进行班级分组绑定(二级菜单)--只显示有班级-学生
        private void StuL(HttpContext context)
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
                        string a = InitStu(dt.Rows[i]["DID"].ToString());
                        if (a == "")
                        { }
                        else
                        {
                            name += "{\"id\":\"" + dt.Rows[i]["DID"].ToString() +
                               "\",\"text\":\"" + dt.Rows[i]["OtherName"].ToString() + "\",";

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
        public string InitStu(string id)
        {
            DataTable dt = sysUserDAL.GetSysUserByDepid((int)CommonEnum.UserType.学生, int.Parse(id));
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




        #region 绑定年级-班级-学生(三级菜单)剔除没有学生的班级
        /// <summary>
        /// 绑定年级下的班级的学生(三级菜单)
        /// </summary>
        private void StuGrade(HttpContext context)
        {
            StringBuilder sb = new StringBuilder();
            string dname = "";
            try
            {
                //获取未毕业未删除的年级名称
                DataTable dd = gradeDAL.GetListAll((int)CommonEnum.IsorNot.否);
                if (dd.Rows.Count > 0)
                {
                    for (int x = 0; x < dd.Rows.Count; x++)
                    {
                        string a = InitGrade(dd.Rows[x]["GID"].ToString());//获取年级下的班级                             
                        if (a == "")
                        {
                        }
                        else
                        {
                            dname += "{\"id\":\"" + dd.Rows[x]["GID"].ToString() +
                               "\",\"text\":\"" + dd.Rows[x]["GradeName"].ToString() + "\"";
                            dname += a.TrimEnd(',');//调用递归方法
                            if (a.TrimEnd(',') != "")
                                dname += ",\"state\":\"closed\"},";
                            else
                                dname += "},";
                        }
                    }
                }
                else
                {
                    dname = "[]";
                }
                sb.Append("[");
                sb.Append(dname.ToString().TrimEnd(','));
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
        /// 绑定年级下的班级
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
        public string InitGrade(string parentID)
        {
            StringBuilder sb = new StringBuilder();
            string name = "";

            DataTable dt = departmentDAL.GetPTBJ(int.Parse(parentID), (int)CommonEnum.DepType.普通班级, (int)CommonEnum.IsorNot.否);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                   string a = InitGChild(dt.Rows[i]["DID"].ToString());//获取普通班级下的学生                      
                    if (a == ",")
                    {
                       
                    }
                    else
                    {
                        name += "{\"id\":\"" + dt.Rows[i]["DID"].ToString() +
                          "\",\"text\":\"" + dt.Rows[i]["DepName"].ToString() + "\"";

                        name += a.TrimEnd(',');//调用递归方法
                        if (a.TrimEnd(',') != "")
                            name += ",\"state\":\"closed\"},";
                        else
                            name += "},";
                    }
                   
                }
                sb.Append(",\"children\":[");
                sb.Append(name.ToString().TrimEnd(','));
                sb.Append("],");
            }
            else
            {
                //return "";
                name += ",";
                sb.Append(name);
            }
            
          
            //sb.Append("]},");
            return sb.ToString();
            
        }

        /// <summary>
        /// 绑定普通班级下的学生
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
        public string InitGChild(string parentID)
        {
            StringBuilder sb = new StringBuilder();
            string name = "";
            DataTable dt = teacherDAL.GetByDepID(int.Parse(parentID), (int)CommonEnum.UserType.学生, (int)CommonEnum.IsorNot.否);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    name += "{\"id\":\"" + dt.Rows[i]["UID"].ToString() +
                          "\",\"text\":\"" + dt.Rows[i]["RealName"].ToString() + "\"},";
                }
                sb.Append(",\"children\":[");
                sb.Append(name.ToString().TrimEnd(','));
                sb.Append("],");
            }
            else
            {
                //return "";
                name += ",";
                sb.Append(name);
            }
            //sb.Append("\"children\":[");
            //sb.Append(name.ToString().TrimEnd(','));
            //sb.Append("]");
            //sb.Append("]},");
            return sb.ToString();
          
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