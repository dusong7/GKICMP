using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using GK.GKICMP.Entities;
using System.Web.UI.WebControls;

namespace GKICMP.ashx
{
    /// <summary>
    /// GetBaseDate 的摘要说明
    /// </summary>
    public class GetBaseDate : IHttpHandler
    {
        public CourseDAL courseDAL = new CourseDAL();
        public GradeDAL gradeDAL = new GradeDAL();
        public DepartmentDAL departDAL = new DepartmentDAL();
        public VehicleDAL vechilceDAL = new VehicleDAL();
        public DriverDAL driverDAL = new DriverDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public AssetTypeDAL typeDAL = new AssetTypeDAL();
        public SysDataDAL sysDataDAL = new SysDataDAL();
        public LessonPlanDAL lessonPlanDAL = new LessonPlanDAL();
        public BaseDataDAL baseDataDAL = new BaseDataDAL();
        public SysUser_TypeDAL sysUser_TypeDAL = new SysUser_TypeDAL();
        public Web_MenuDAL web_MenuDAL = new Web_MenuDAL();
        public void ProcessRequest(HttpContext context)
        {
            string method = context.Request.Params["method"];
            switch (method)
            {
                case "GetBaseDate":
                    GetDate(context);
                    break;
                case "GetDep":
                    GetDep(context);
                    break;
                case "GetUserByDep":
                    GetUserByDep(context);
                    break;
                case "GetUser":
                    GetUser(context);
                    break;
                case "GetCourse":
                    GetCourse(context);
                    break;
                case "GetDepAPP":
                    GetDepAPP(context);
                    break;
                case "GetUserAPP":
                    GetUserAPP(context);
                    break;
                case "GetVehicle":
                    GetVehicle(context);
                    break;
                case "GetDriver":
                    GetDriver(context);
                    break;
                case "GetGrade":
                    GetGrade(context);
                    break;
                case "GetAssetType":
                    GetAssetType(context);
                    break;
                case "GetTeacher":
                    GetTeacher(context);
                    break;
                case "Grade":
                    Grade(context);
                    break;
                case "GetGradeOut":
                    GetGradeOut(context);
                    break;
                case "GetStu":
                    GetStu(context);
                    break;
                case "GetGroupUser":
                    GetGroupUser(context);
                    break;
                case "GetStuID":
                    GetStuID(context);
                    break;
                case "GetXK":
                    GetXK(context);
                    break;
                case "GetDepAPPByRYFL":
                    GetDepAPPByRYFL(context);
                    break;
                case "GetMenu":
                    GetMenu(context);
                    break;
                case "GetTransferUser":
                    GetTransferUser(context);
                    break;
                case "GetUserByType":
                    GetUserByType(context);
                    break; 
            }
        }
        public void GetUserByType(HttpContext context)
        {
            StringBuilder sb = new StringBuilder("");
            int dep =int.Parse( context.Request.Params["dep"]);
            string name = "";
            try
            {
                DataTable dt = sysUserDAL.GetUserByRYFL(1, dep);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //string a = InitChildUser(usertype, dt.Rows[i]["DID"].ToString());
                        //if (a == "")
                        //{ }
                        //else
                        //{s
                        name += "{\"value\":\"" + dt.Rows[i]["UID"].ToString() +
                           "\",\"text\":\"" + dt.Rows[i]["RealName"].ToString() + "\"},";

                        // name += a;//调用递归方法

                        //name += ",\"state\":\"closed\"},";
                        //}
                    }
                }
                else
                {
                    name = "[]";
                }
                sb.Append("{\"result\":\"true\",\"data\":[");
                sb.Append(name.ToString().TrimEnd(','));
                sb.Append("]}");
            }

            catch (Exception error)
            {
                sb.Append("{\"result\":\"" + error.Message + "\"}");
            }

            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }
        public void GetTransferUser(HttpContext context)
        {
            StringBuilder sb = new StringBuilder("");
            string name = "";
            try
            {
                DataTable dt = sysUserDAL.GetSysUserByTeac((int)CommonEnum.UserType.校外人士,(int)CommonEnum.IsorNot.否);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //string a = InitChildUser(usertype, dt.Rows[i]["DID"].ToString());
                        //if (a == "")
                        //{ }
                        //else
                        //{s
                        name += "{\"value\":\"" + dt.Rows[i]["UID"].ToString() +
                           "\",\"text\":\"" + dt.Rows[i]["RealName"].ToString() + "\"},";

                        // name += a;//调用递归方法

                        //name += ",\"state\":\"closed\"},";
                        //}
                    }
                }
                else
                {
                    name = "[]";
                }
                sb.Append("{\"result\":\"true\",\"data\":[");
                sb.Append(name.ToString().TrimEnd(','));
                sb.Append("]}");
            }

            catch (Exception error)
            {
                sb.Append("{\"result\":\"" + error.Message + "\"}");
            }

            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }
        public void GetMenu(HttpContext context)
        {
            StringBuilder sb = new StringBuilder("");
            int datatype = context.Request.Params["data"] == "js" ? -2 : -1;//部门类型：-1 班级 -2 职能部门；
            int usertype = datatype == -2 ? 1 : 2;//1 教师，2 学生
            string name = "";
            try
            {
                DataTable dt = web_MenuDAL.GetTable((int)CommonEnum.Deleted.未删除);
                //ModelParent(dt, "-1", this.ddl_WebMenu, "");
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //string a = InitChildUser(usertype, dt.Rows[i]["DID"].ToString());
                        //if (a == "")
                        //{ }
                        //else
                        //{
                        name += "{\"value\":\"" + dt.Rows[i]["MID"].ToString() +
                           "\",\"text\":\"" + dt.Rows[i]["MName"].ToString() + "\"},";

                        // name += a;//调用递归方法

                        //name += ",\"state\":\"closed\"},";
                        //}
                    }
                }
                else
                {
                    name = "[]";
                }
                sb.Append("{\"result\":\"true\",\"data\":[");
                sb.Append(name.ToString().TrimEnd(','));
                sb.Append("]}");
            }

            catch (Exception error)
            {
                sb.Append("{\"result\":\"" + error.Message + "\"}");
            }

            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }
        private void GetXK(HttpContext context)
        {
            StringBuilder sb = new StringBuilder();
            string userid = CommonFunction.Decrypt(context.Request.Params["UserID"]);
            string name = "";
            DataTable dt = courseDAL.GetCourseAll(userid);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    name += "{\"value\":\"" + dt.Rows[i]["CID"].ToString() +
                       "\",\"text\":\"" + dt.Rows[i]["CourseName"].ToString() + "\"},";
                }
            }
            sb.Append("{\"data\":[");
            sb.Append(name.ToString().TrimEnd(','));
            sb.Append("]}");

            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }


        private void Grade(HttpContext context)
        {
            StringBuilder sb = new StringBuilder();
            string name = "";
            //int datatype = context.Request.Params["data"] == "js" ? -2 : -1;//部门类型：-1 班级 -2 职能部门；
            try
            {
                DataTable dt = gradeDAL.GetGradeLevel();
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //string a = InitChildClass(Convert.ToInt32(dt.Rows[i]["GID"].ToString()), datatype);
                        //if (a == "")
                        //{ }
                        //else
                        //{
                        name += "{\"id\":\"" + dt.Rows[i]["GLID"].ToString() +
                           "\",\"text\":\"" + dt.Rows[i]["ShortName"].ToString() + "\"},";
                        //name += a;
                        //name += ",\"state\":\"closed\"},";
                        //}
                    }
                }
                sb.Append("[");
                sb.Append(name.ToString().TrimEnd(','));
                sb.Append("]");
            }

            catch (Exception error)
            {
                sb.Append("[]");
            }
            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }


        #region 获取资产类型数据
        /// <summary>
        /// 获取资产类型数据
        /// </summary>
        /// <param name="context"></param>
        public void GetAssetType(HttpContext context)
        {
            StringBuilder sb = new StringBuilder("");
            DataTable dt = null;
            int datatype = context.Request.Params["flag"] == "1" ? 1 : (int)CommonEnum.DataType.耗材分类;
            string name = "";
            try
            {
                if (datatype == 1)
                {
                    dt = typeDAL.GetType(-1, (int)CommonEnum.Deleted.未删除, datatype);
                }
                else
                {
                    dt = sysDataDAL.GetAssetType((int)CommonEnum.Deleted.未删除, (int)CommonEnum.DataType.耗材分类, -1);
                }
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string a = InitChildType(Convert.ToInt32(dt.Rows[i]["SDID"].ToString()), datatype);
                        if (a == "")
                        { }
                        else
                        {
                            name += "{\"id\":\"" + dt.Rows[i]["SDID"].ToString() +
                               "\",\"text\":\"" + dt.Rows[i]["DataName"].ToString() + "\",";
                            name += a;//调用递归方法
                            name += ",\"state\":\"closed\"},";
                        }
                    }
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

        public string InitChildType(int parentID, int datatype)
        {
            DataTable dt = null;
            if (datatype == 1)
            {
                dt = typeDAL.GetType(parentID, (int)CommonEnum.Deleted.未删除, datatype);
            }
            else
            {
                dt = sysDataDAL.GetAssetType((int)CommonEnum.Deleted.未删除, (int)CommonEnum.DataType.耗材分类, parentID);
            }
            StringBuilder sb = new StringBuilder();
            string name = "";

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    name += "{\"id\":\"" + dt.Rows[i]["SDID"].ToString() +
                       "\",\"text\":\"" + dt.Rows[i]["DataName"].ToString() + "\"},";
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

        #region 学科领域与论文收录情况
        public void GetDate(HttpContext context)
        {
            StringBuilder sb = new StringBuilder("");
            int datatype = context.Request.Params["data"] == "xk" ? (int)CommonEnum.BaseDataType.学科领域 : (int)CommonEnum.BaseDataType.论文收录情况;//4:学科领域；
            string name = "";
            try
            {
                DataTable dt = baseDataDAL.GetList(datatype, -1);//从数据库中取得数据
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        name += "{\"id\":\"" + dt.Rows[i]["SDID"].ToString() + "\",\"text\":\"" + dt.Rows[i]["DataName"].ToString() + "\",";//调用递归方法
                        name += InitChild(datatype, Convert.ToInt32(dt.Rows[i]["SDID"]));
                        name += "},";
                    }
                    sb.Append("{\"result\":\"true\",\"data\":[");
                    sb.Append(name.ToString().TrimEnd(','));
                    sb.Append("]}");
                }
            }
            catch (Exception error)
            {
                sb.Append("{\"result\":\"" + error.Message + "\"}");
            }

            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }
        public string InitChild(int type, int pid)
        {
            DataTable dt = baseDataDAL.GetList(type, pid);//GetSysUserByDepid
            StringBuilder sb = new StringBuilder();
            string name = "";
            if (dt == null)
            {
            }
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    name += "{\"id\":\"" + dt.Rows[i]["SDID"].ToString() +
                       "\",\"text\":\"" + dt.Rows[i]["DataName"].ToString() + "\"},";
                }
            }
            sb.Append("\"children\":[");
            sb.Append(name.ToString().TrimEnd(','));
            sb.Append("]");
            return sb.ToString();
        }
        #endregion


        public void GetDep(HttpContext context)
        {
            StringBuilder sb = new StringBuilder("");
            int datatype = 0;
            if (context.Request.Params["data"] == "js")//部门类型：-1 班级 -2 职能部门；
            {
                datatype = -2;
            }
            else if (context.Request.Params["data"] == "xs")
            {
                datatype = -1;
            }

            // int usertype = datatype == -2 ? 1 : 2;//1 教师，2 学生
            string name = "";
            try
            {
                DataTable dt = departDAL.GetList((int)CommonEnum.Deleted.未删除, datatype);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //string a = InitChildUser(usertype, dt.Rows[i]["DID"].ToString());
                        //if (a == "")
                        //{ }
                        //else
                        //{
                        name += "{\"id\":\"" + dt.Rows[i]["DID"].ToString() +
                           "\",\"text\":\"" + dt.Rows[i]["DepName"].ToString() + "\"},";

                        // name += a;//调用递归方法

                        //name += ",\"state\":\"closed\"},";
                        //}
                    }
                }
                else
                {
                    name = "[]";
                }
                sb.Append("{\"result\":\"true\",\"data\":[");
                sb.Append(name.ToString().TrimEnd(','));
                sb.Append("]}");
            }

            catch (Exception error)
            {
                sb.Append("{\"result\":\"" + error.Message + "\"}");
            }

            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }


        public void GetUserByDep(HttpContext context)
        {
            StringBuilder sb = new StringBuilder("");
            string dep = context.Request.Params["dep"];
           
            string name = "";
            try
            {
                DataTable dt = sysUserDAL.GetUserByDep(dep);
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
                    name = "[]";
                }
                sb.Append("{\"result\":\"true\",\"data\":[");
                sb.Append(name.ToString().TrimEnd(','));
                sb.Append("]}");
            }

            catch (Exception error)
            {
                sb.Append("{\"result\":\"" + error.Message + "\"}");
            }

            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }


        public void GetTeacher(HttpContext context)
        {
            StringBuilder sb = new StringBuilder("");
            string name = "";
            try
            {
                DataTable dt = departDAL.GetList((int)CommonEnum.Deleted.未删除, -2);
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


        #region 获取用户列表（剔除部门没人分组）
        /// <summary>
        /// 获取用户列表（剔除部门没人分组）
        /// </summary>
        /// <param name="context"></param>
        public void GetUser(HttpContext context)
        {
            StringBuilder sb = new StringBuilder("");
            int datatype = context.Request.Params["data"] == "js" ? -2 : -1;//部门类型：-1 班级 -2 职能部门；
            int usertype = datatype == -2 ? 1 : 2;//1 教师，2 学生
            int checkall = context.Request.Params["all"] == null ? 0 : 1;
            string name = "";
            try
            {
                DataTable dt = departDAL.GetList((int)CommonEnum.Deleted.未删除, datatype);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string a = InitChildUser(usertype, dt.Rows[i]["DID"].ToString());
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
                sb.Append("{\"result\":\"true\",\"data\":[");
                sb.Append(name.ToString().TrimEnd(','));
                //周计划
                if (checkall == 1)
                    sb.Append(",{\"id\":\"0\",\"text\":\"全体人员\",\"state\":\"closed\"}");
                sb.Append("]}");
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
                    // string a = dt.Rows[i]["UID"].ToString();
                    #region 获取不重复的用户（用户为多部门情况下）
                    //name += "{\"id\":\"" + parentID + ":" + dt.Rows[i]["UID"].ToString() +
                    //   "\",\"text\":\"" + dt.Rows[i]["RealName"].ToString() + "\"},";
                    #endregion

                    #region 获取
                    name += "{\"id\":\"" + dt.Rows[i]["UID"].ToString() +
                    "\",\"text\":\"" + dt.Rows[i]["RealName"].ToString() + "\"},";
                    #endregion
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


        #region 获取全部年级信息(二级菜单:年级-班级)
        private void GetGrade(HttpContext context)
        {
            StringBuilder sb = new StringBuilder();
            string name = "";
            int datatype = context.Request.Params["data"] == "js" ? -2 : -1;//部门类型：-1 班级 -2 职能部门；
            try
            {
                DataTable dt = gradeDAL.GetListAll((int)CommonEnum.IsorNot.否);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string a = InitChildClass(Convert.ToInt32(dt.Rows[i]["GID"].ToString()), datatype);
                        if (a == "")
                        { }
                        else
                        {
                            name += "{\"id\":\"" + dt.Rows[i]["GID"].ToString() +
                               "\",\"text\":\"" + dt.Rows[i]["GradeName"].ToString() + "\",";
                            name += a;
                            name += ",\"state\":\"closed\"},";
                        }
                    }
                }
                else
                {
                    name = "[]";
                }
                sb.Append("{\"result\":\"true\",\"data\":[");
                sb.Append(name.ToString().TrimEnd(','));
                sb.Append("]}");
            }

            catch (Exception error)
            {
                sb.Append("{\"result\":\"" + error.Message + "\"}");
            }
            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }

        private void GetGradeOut(HttpContext context)
        {
            StringBuilder sb = new StringBuilder();
            string name = "";
            int datatype = context.Request.Params["data"] == "js" ? -2 : -1;//部门类型：-1 班级 -2 职能部门；
            try
            {
                DataTable dt = gradeDAL.GetListAll((int)CommonEnum.IsorNot.否);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string a = InitChildClass(Convert.ToInt32(dt.Rows[i]["GID"].ToString()), datatype);
                        if (a == "")
                        { }
                        else
                        {
                            name += "{\"id\":\"" + dt.Rows[i]["GID"].ToString() +
                               "\",\"text\":\"" + dt.Rows[i]["GradeName"].ToString() + "\",";
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
        /// 根据年级ID获取班级信息
        /// </summary>
        /// <param name="gid"></param>
        /// <param name="deptype"></param>
        /// <returns></returns>
        public string InitChildClass(int gid, int deptype)
        {
            //DataTable dt = departDAL.GetClass(gid, (int)CommonEnum.IsorNot.否, deptype);
            DataTable dt = departDAL.GetByGID(gid, (int)CommonEnum.IsorNot.否);
            StringBuilder sb = new StringBuilder();
            string name = "";
            if (dt == null) { }
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    name += "{\"id\":\"" + dt.Rows[i]["DID"].ToString() +
                       "\",\"text\":\"" + dt.Rows[i]["DepName"].ToString() + "\"},";
                }
            }
            sb.Append("\"children\":[");
            sb.Append(name.ToString().TrimEnd(','));
            sb.Append("]");
            return sb.ToString();
        }
        #endregion



        public void GetDepAPP(HttpContext context)
        {
            StringBuilder sb = new StringBuilder("");
            int datatype = context.Request.Params["data"] == "js" ? -2 : -1;//部门类型：-1 班级 -2 职能部门；
            int usertype = datatype == -2 ? 1 : 2;//1 教师，2 学生
            string name = "";
            try
            {
                DataTable dt = departDAL.GetList((int)CommonEnum.Deleted.未删除, datatype);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //string a = InitChildUser(usertype, dt.Rows[i]["DID"].ToString());
                        //if (a == "")
                        //{ }
                        //else
                        //{
                        name += "{\"value\":\"" + dt.Rows[i]["DID"].ToString() +
                           "\",\"text\":\"" + dt.Rows[i]["DepName"].ToString() + "\"},";

                        // name += a;//调用递归方法

                        //name += ",\"state\":\"closed\"},";
                        //}
                    }
                }
                else
                {
                    name = "[]";
                }
                sb.Append("{\"result\":\"true\",\"data\":[");
                sb.Append(name.ToString().TrimEnd(','));
                sb.Append("]}");
            }

            catch (Exception error)
            {
                sb.Append("{\"result\":\"" + error.Message + "\"}");
            }

            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }


        public void GetDepAPPByRYFL(HttpContext context)
        {
            StringBuilder sb = new StringBuilder("");
            string name = "";
            try
            {
                DataTable dt = sysUser_TypeDAL.GetPagedByRYFL((int)CommonEnum.HumanType.报修受理人);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //string a = InitChildUser(usertype, dt.Rows[i]["DID"].ToString());
                        //if (a == "")
                        //{ }
                        //else
                        //{s
                        name += "{\"value\":\"" + dt.Rows[i]["DID"].ToString() +
                           "\",\"text\":\"" + dt.Rows[i]["DIDName"].ToString() + "\"},";

                        // name += a;//调用递归方法

                        //name += ",\"state\":\"closed\"},";
                        //}
                    }
                }
                else
                {
                    name = "[]";
                }
                sb.Append("{\"result\":\"true\",\"data\":[");
                sb.Append(name.ToString().TrimEnd(','));
                sb.Append("]}");
            }

            catch (Exception error)
            {
                sb.Append("{\"result\":\"" + error.Message + "\"}");
            }

            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }

        #region 获取用户APP
        public void GetUserAPP(HttpContext context)
        {
            StringBuilder sb = new StringBuilder("");
            int datatype = Convert.ToInt32(context.Request.Params["data"]);//部门类型：-1 班级 -2 职能部门；
            string name = "";
            try
            {
                DataTable dt = sysUserDAL.GetSysUserByDepid(1, datatype);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        name += "{\"value\":\"" + dt.Rows[i]["UID"].ToString() +
                           "\",\"text\":\"" + dt.Rows[i]["RealName"].ToString() + "\"},";
                    }
                }

                sb.Append("{\"result\":\"true\",\"data\":[");
                sb.Append(name.ToString().TrimEnd(','));
                sb.Append("]}");

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


        #region 获取全部课程信息
        private void GetCourse(HttpContext context)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                string name = "";
                name += "{\"id\":\"" +
               "\",\"text\":\"" + "全部课程" + "\",";
                //调用递归方法
                name += InitChild();
                name += "},";
                sb.Append("{\"result\":\"true\",\"data\":[");
                sb.Append(name.ToString().TrimEnd(','));
                sb.Append("]}");
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
        ///  绑定课程
        /// </summary>
        /// <returns></returns>

        public string InitChild()
        {
            DataTable dt = courseDAL.GetCourse((int)CommonEnum.IsorNot.是);
            StringBuilder sb = new StringBuilder();
            string name = "";
            if (dt == null)
            {
            }
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    name += "{\"id\":\"" + dt.Rows[i]["CID"].ToString() +
                       "\",\"text\":\"" + dt.Rows[i]["CourseName"].ToString() + "\"},";
                }
            }
            sb.Append("\"children\":[");
            sb.Append(name.ToString().TrimEnd(','));
            sb.Append("]");
            return sb.ToString();
        }
        #endregion


        #region 获取车辆
        public void GetVehicle(HttpContext context)
        {
            StringBuilder sb = new StringBuilder("");
            string name = "";
            try
            {
                DataTable dt = vechilceDAL.GetTable((int)CommonEnum.IsorNot.否);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        name += "{\"id\":\"" + dt.Rows[i]["VHID"].ToString() +
                           "\",\"text\":\"" + dt.Rows[i]["VehicleName"].ToString() + "（" + dt.Rows[i]["VehicleCode"].ToString() + "）" + "\"},";
                    }
                }

                sb.Append("{\"result\":\"true\",\"data\":[");
                sb.Append(name.ToString().TrimEnd(','));
                sb.Append("]}");

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


        #region 获取司机列表
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="context"></param>
        public void GetDriver(HttpContext context)
        {
            StringBuilder sb = new StringBuilder("");
            string name = "";
            try
            {
                DataTable dt = driverDAL.GetTable();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        name += "{\"id\":\"" + dt.Rows[i]["SysUid"].ToString() +
                           "\",\"text\":\"" + dt.Rows[i]["SysUidName"].ToString() + "\"},";
                    }
                }

                sb.Append("{\"result\":\"true\",\"data\":[");
                sb.Append(name.ToString().TrimEnd(','));
                sb.Append("]}");

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


        #region 获取班级根据年级
        /// <summary>
        /// 获取班级根据年级
        /// </summary>
        /// <param name="context"></param>
        public void GetStu(HttpContext context)
        {
            StringBuilder sb = new StringBuilder("");
            int GID = Convert.ToInt32(context.Request.Params["gid"].ToString());
            string name = "";
            try
            {
                DataTable dt = departDAL.GetByGID(GID, (int)CommonEnum.IsorNot.否);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string a = StuUser(Convert.ToInt32(dt.Rows[i]["DID"].ToString()));
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
                sb.Append("{\"result\":\"true\",\"data\":[");
                sb.Append(name.ToString().TrimEnd(','));
                sb.Append("]}");
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
        public string StuUser(int parentID)
        {
            DataTable dt = sysUserDAL.GetTeacherByDepID(parentID);
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


        #region 根据班级ID获取学生
        public void GetStuID(HttpContext context)
        {
            StringBuilder sb = new StringBuilder("");
            int did = Convert.ToInt32(context.Request.Params["did"].ToString());
            string name = "";
            try
            {
                DataTable dt = sysUserDAL.GetTeacherByDepID(did);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        name += "{\"id\":\"" + dt.Rows[i]["UID"].ToString() +
                       "\",\"text\":\"" + dt.Rows[i]["RealName"].ToString() + "\"},";
                    }
                }
                sb.Append("{\"result\":\"true\",\"data\":[");
                sb.Append(name.ToString().TrimEnd(','));
                sb.Append("]}");
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


        #region 获取用户包含自定义分组列表（剔除部门没人分组）
        /// <summary>
        /// 获取用户包含自定义分组列表（剔除部门没人分组）
        /// </summary>
        /// <param name="context"></param>
        public void GetGroupUser(HttpContext context)
        {
            StringBuilder sb = new StringBuilder("");
            string name = "";
            try
            {
                DataTable dt = departDAL.GetGroupList((int)CommonEnum.Deleted.未删除);//获取部门类型为-2和-3的包含自定义分组
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string a = InitGroupChildUser(1, dt.Rows[i]["DID"].ToString(), Convert.ToInt32(dt.Rows[i]["DepType"].ToString()));
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
                sb.Append("{\"result\":\"true\",\"data\":[");
                sb.Append(name.ToString().TrimEnd(','));
                sb.Append("]}");
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
        public string InitGroupChildUser(int usertype, string parentID, int deptype)
        {
            DataTable dt = null;
            if (deptype == -2)
            {
                dt = sysUserDAL.GetSysUserByDepid(usertype, int.Parse(parentID));
            }
            else
            {
                dt = sysUserDAL.GetSysUserByGroupid(int.Parse(parentID));
            }
            StringBuilder sb = new StringBuilder();
            string name = "";

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    // string a = dt.Rows[i]["UID"].ToString();
                    #region 获取不重复的用户（用户为多部门情况下）
                    //name += "{\"id\":\"" + parentID + ":" + dt.Rows[i]["UID"].ToString() +
                    //   "\",\"text\":\"" + dt.Rows[i]["RealName"].ToString() + "\"},";
                    #endregion

                    #region 获取
                    name += "{\"id\":\"" + dt.Rows[i]["UID"].ToString() +
                    "\",\"text\":\"" + dt.Rows[i]["RealName"].ToString() + "\"},";
                    #endregion
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


        #region 递归栏目菜单
        private void ModelParent(DataTable dt, string parentid, DropDownList ddl, string str)
        {
            string str_;
            foreach (DataRow dr in dt.Rows)
            {
                ListItem item = new ListItem();
                item.Text = str + dr["MName"].ToString();     //Bind text
                item.Value = dr["MID"].ToString();  //Bind value
                string parent_id = item.Value;
                ddl.Items.Add(item);
                //  ModelParent(dt, parent_id, ddl, str + "..");
            }
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