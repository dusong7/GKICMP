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
    /// EUIDataList 的摘要说明
    /// </summary>
    public class EUIDataList : IHttpHandler
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
        public TeacherDAL teacherDAL = new TeacherDAL();
        public void ProcessRequest(HttpContext context)
        {
            string method = context.Request.Params["method"];
            switch (method)
            {
                case "GList":
                    GetGList(context);
                    break;

            }
        }
        /// <summary>
        /// 获取年级列表
        /// </summary>
        /// <param name="context.IsDuty">是否根据负责人查询</param>
        /// <param name="context.Flag">负责人类型（1：年级，2：班级）</param>
        /// <param name="context.Duty">负责人</param>
        /// <param name="context.IsChild">是否有子级</param>
        /// <param name="context.IsRE">空子级时是否删除</param>
        /// <param name="context.IsUser">是否绑定人员</param>
        public void GetGList(HttpContext context)
        {
            int flag = int.Parse(context.Request.Params["Flag"]);
            bool IsDuty = bool.Parse(context.Request.Params["IsDuty"]);
            string uid=CommonFunction.Decrypt(context.Request.Params["UserID"]);
            bool IsChild =bool.Parse( context.Request.Params["IsChild"]);
            bool IsRE = bool.Parse(context.Request.Params["IsRE"]);
            bool IsUser = bool.Parse(context.Request.Params["IsUser"]);
            StringBuilder sb = new StringBuilder();
            string name = "";
            int datatype = context.Request.Params["data"] == "js" ? -2 : -1;//部门类型：-1 班级 -2 职能部门；
            try
            {
                DataTable dt = null;
                if (IsDuty)
                    dt = gradeDAL.GetList((int)CommonEnum.IsorNot.否, flag == 1 ? uid : "");//
                else
                    dt = gradeDAL.GetList((int)CommonEnum.IsorNot.否,  "");//flag==1
                //DataTable dt = gradeDAL.GetList((int)CommonEnum.IsorNot.否, uid);
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataTable dtchild = null;
                   // DataTable dtUList = null;
                    //判断是否绑定下级菜单,获取部门列表
                    if (IsChild)
                    {
                        dtchild = departDAL.GetAllClass("where Isdel=0 and DepType=-1 and master like '%" + (flag == 1 ? "" : uid) + "%'");//获取全部部门
                    }
                    //判断是否绑定人员,获取人员列表
                    //if (IsUser) 
                    //{
                    //    dtUList = teacherDAL.GetByDepID(1, (int)CommonEnum.UserType.学生, (int)CommonEnum.IsorNot.否);
                    //}
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string a = "";
                        //判断是否剔除没有下级菜单的年级
                        if (IsChild)
                        {
                            a = InitChildClass(Convert.ToInt32(dt.Rows[i]["GID"].ToString()), dtchild, IsUser);
                            if (IsRE)
                            {
                                if (a == "")
                                { }
                                else
                                {
                                    name += "{\"id\":\"" + dt.Rows[i]["GID"].ToString() +
                                       "\",\"text\":\"" + dt.Rows[i]["GradeName"].ToString() + "\",";
                                    name += a;
                                    name += "\"state\":\"closed\"},";
                                }
                            }
                            else
                            {
                                
                                name += "{\"id\":\"" + dt.Rows[i]["GID"].ToString() +
                                   "\",\"text\":\"" + dt.Rows[i]["GradeName"].ToString() + "\"";
                                name +=","+ a;
                              //  name += "\"state\":\"closed\"";
                                name += "},";
                            }
                        }
                        else 
                        {
                            name += "{\"id\":\"" + dt.Rows[i]["GID"].ToString() +
                                   "\",\"text\":\"" + dt.Rows[i]["GradeName"].ToString() + "\",";
                        }
                    }
                }
                else
                {
                    name = "";
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
        public string InitChildClass(int gid, DataTable dt,bool isuser)
        {
            //DataTable dt = departDAL.GetClass(gid, (int)CommonEnum.IsorNot.否, deptype);
            StringBuilder sb = new StringBuilder();
            string name = "";

            if (dt.Rows.Count > 0)
            {
                DataRow[] drarr = dt.Select("gid=" + gid);
                if (drarr.Length > 0)
                {
                    foreach (DataRow dr in drarr)
                    {
                        string a = "";
                        if (isuser)
                        {
                            a = InitGChild(dr["DID"].ToString());//获取普通班级下的学生                      
                            if (a == "")
                            {

                            }
                            else
                            {
                                name += "{\"id\":\"" + dr["DID"].ToString() +
                                   "\",\"text\":\"" + dr["DepName"].ToString() + "\",";
                                name += a;
                                name += "\"state\":\"closed\"},";
                            }
                        }
                        else
                        {
                            name += "{\"id\":\"" + dr["DID"].ToString() +
                                   "\",\"text\":\"" + dr["DepName"].ToString() + "\"},";
                        }
                    }
                    sb.Append("\"children\":[");
                    sb.Append(name.ToString().TrimEnd(','));
                    sb.Append("],");
                }
                else
                    return "";
            }
            else
                return "";
           
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
                sb.Append("\"children\":[");
                sb.Append(name.ToString().TrimEnd(','));
                sb.Append("],");
            }
            else
            {
                //return "";
                name += "";
                sb.Append(name);
            }
            //sb.Append("\"children\":[");
            //sb.Append(name.ToString().TrimEnd(','));
            //sb.Append("]");
            //sb.Append("]},");
            return sb.ToString();

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