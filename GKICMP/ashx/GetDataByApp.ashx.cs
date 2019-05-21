using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace GKICMP.ashx
{
    /// <summary>
    /// GetDataByApp 的摘要说明
    /// </summary>
    public class GetDataByApp : IHttpHandler
    {
        public SysDataDAL sysDataDAL = new SysDataDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public CourseDAL courseDAL = new CourseDAL();
        public SupplierDAL supplierDAL = new SupplierDAL();
        public ClassRoomDAL classRoomDAL = new ClassRoomDAL();
        public BaseDataDAL basedataDAL = new BaseDataDAL();
        public SysUser_TypeDAL typeDAL = new SysUser_TypeDAL();
        public PurchaseDAL purchaseDAL = new PurchaseDAL();
        public void ProcessRequest(HttpContext context)
        {
            string method = context.Request.Params["method"];
            switch (method)
            {
                case "GetDepAPP":
                    GetDepAPP(context);
                    break;
                case "GetUserAPP":
                    GetUserAPP(context);
                    break;
                case "GetCourseAll":
                    GetCourseAll(context);
                    break;
                case "GetClaIDByTID":
                    GetClaIDByTID(context);
                    break;
                case "GetSupp":
                    GetSupp(context);
                    break;
                case "GetAID":
                    GetAID(context);
                    break;
                case "GetQJ":
                    GetQJ(context);
                    break;
                case "GetLB":
                    GetLB(context);
                    break;
                case "GetType":
                    GetType(context);
                    break;
                case "GetUList":
                    GetUList(context);
                    break;
                case "GetJB":
                    GetJB(context);
                    break;
                case "GetBKSHR":
                    GetBKSHR(context);
                    break;
                case "GetProList":
                    GetProList(context);
                    break;
            }
        }

        

        public void GetBKSHR(HttpContext context)
        {
            StringBuilder sb = new StringBuilder("");
            string name = "";
            try
            {
                DataTable dv = typeDAL.GetList((int)CommonEnum.HumanType.补卡审核人);
                foreach (DataRow row in dv.Rows)
                {
                    name += "{\"value\":\"" + row["UID"] + "\",\"text\":\"" + row["RealName"] + "\"},";
                }
                //Array values = Enum.GetValues(typeof(CommonEnum.LType));
                //foreach (Enum value in values)
                //{
                //    name += "{\"value\":\"" + (int)Enum.Parse(typeof(CommonEnum.LType), value.ToString()) +
                //               "\",\"text\":\"" + value.ToString() + "\"},";
                //}

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


        public void GetUList(HttpContext context)
        {
            StringBuilder sb = new StringBuilder("");
            string uid = CommonFunction.Decrypt(context.Request.Params["UserID"]);
            string name = "";
            try
            {

                DataTable dv = sysUserDAL.GetUList(uid, (int)CommonEnum.IsorNot.否, (int)CommonEnum.UState.正常);
                foreach (DataRow row in dv.Rows)
                {
                    name += "{\"value\":\"" + row["UID"] + "\",\"text\":\"" + row["RealName"] + "\"},";
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
        /// 获取部门列表（参数data=js则获取职能部门，否则获取班级）
        /// </summary>
        /// <param name="context"></param>
        public void GetDepAPP(HttpContext context)
        {
            StringBuilder sb = new StringBuilder("");
            int datatype = context.Request.Params["data"] == "js" ? -2 : -1;//部门类型：-1 班级 -2 职能部门；
            int usertype = datatype == -2 ? 1 : 2;//1 教师，2 学生
            string name = "";
            try
            {
                DataTable dt = departmentDAL.GetList((int)CommonEnum.Deleted.未删除, datatype);
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
        /// <summary>
        /// 根据部门获取用户信息
        /// </summary>
        /// <param name="context"></param>
        public void GetUserAPP(HttpContext context)
        {
            StringBuilder sb = new StringBuilder("");
            int datatype = Convert.ToInt32(context.Request.Params["data"]);//部门类型：-1 班级 -2 职能部门；
            // int usertype = datatype == -2 ? 1 : 2;//1 教师，2 学生
            string name = "";
            try
            {
                DataTable dt = sysUserDAL.GetSysUserByDepid(1, datatype);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        // string a = dt.Rows[i]["UID"].ToString();
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
        public void GetCourseAll(HttpContext context)
        {
            StringBuilder sb = new StringBuilder("");
            string userid = context.Request.Params["data"];//部门类型：-1 班级 -2 职能部门；
            // int usertype = datatype == -2 ? 1 : 2;//1 教师，2 学生
            string name = "";
            string bj = "";
            try
            {
                DataTable dt = courseDAL.GetCourseAll(userid);
                DataTable dt1 = departmentDAL.GetClaIDByTID(userid);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        // string a = dt.Rows[i]["UID"].ToString();
                        name += "{\"value\":\"" + dt.Rows[i]["CID"].ToString() +
                           "\",\"text\":\"" + dt.Rows[i]["CourseName"].ToString() + "\"},";
                    }
                }
                if (dt1.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        // string a = dt.Rows[i]["UID"].ToString();
                        bj += "{\"value\":\"" + dt1.Rows[i]["ClaID"].ToString() +
                           "\",\"text\":\"" + dt1.Rows[i]["ClaIDName"].ToString() + "\"},";
                    }
                }
                sb.Append("{\"result\":\"true\",\"data\":[");
                sb.Append(name.ToString().TrimEnd(','));
                sb.Append("],\"bj\":[");
                sb.Append(bj.ToString().TrimEnd(','));
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
        public void GetClaIDByTID(HttpContext context)
        {
            StringBuilder sb = new StringBuilder("");
            string userid = context.Request.Params["data"];//部门类型：-1 班级 -2 职能部门；
            // int usertype = datatype == -2 ? 1 : 2;//1 教师，2 学生
            string name = "";
            try
            {
                DataTable dt = departmentDAL.GetClaIDByTID(userid);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        // string a = dt.Rows[i]["UID"].ToString();
                        name += "{\"value\":\"" + dt.Rows[i]["ClaID"].ToString() +
                           "\",\"text\":\"" + dt.Rows[i]["ClaIDName"].ToString() + "\"},";
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
        public void GetSupp(HttpContext context)
        {
            StringBuilder sb = new StringBuilder("");
            string name = "";
            try
            {
                DataTable dt = supplierDAL.GetList((int)CommonEnum.Deleted.未删除, "");
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        name += "{\"value\":\"" + dt.Rows[i]["SDID"].ToString() +
                           "\",\"text\":\"" + dt.Rows[i]["SupplierName"].ToString() + "\"},";
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

        public void GetAID(HttpContext context)
        {
            StringBuilder sb = new StringBuilder("");
            string name = "";
            try
            {
                DataTable dt = classRoomDAL.Table((int)CommonEnum.Deleted.未删除, (int)CommonEnum.IsorNot.是);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        name += "{\"value\":\"" + dt.Rows[i]["CRID"].ToString() +
                           "\",\"text\":\"" + dt.Rows[i]["RoomName"].ToString() + "\"},";
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


        public void GetQJ(HttpContext context)
        {
            StringBuilder sb = new StringBuilder("");
            string name = "";
            try
            {
                DataTable dv = basedataDAL.GetList((int)CommonEnum.BaseDataType.请假类型, -1);
                foreach (DataRow row in dv.Rows)
                {
                    name += "{\"value\":\"" + row["SDID"] + "\",\"text\":\"" + row["DataName"] + "\"},";
                }
                //Array values = Enum.GetValues(typeof(CommonEnum.LType));
                //foreach (Enum value in values)
                //{
                //    name += "{\"value\":\"" + (int)Enum.Parse(typeof(CommonEnum.LType), value.ToString()) +
                //               "\",\"text\":\"" + value.ToString() + "\"},";
                //}

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


        public void GetJB(HttpContext context)
        {
            StringBuilder sb = new StringBuilder("");
            string name = "";
            try
            {
                DataTable dv = basedataDAL.GetList((int)CommonEnum.BaseDataType.加班类型, -1);
                foreach (DataRow row in dv.Rows)
                {
                    name += "{\"value\":\"" + row["SDID"] + "\",\"text\":\"" + row["DataName"] + "\"},";
                }
                //Array values = Enum.GetValues(typeof(CommonEnum.LType));
                //foreach (Enum value in values)
                //{
                //    name += "{\"value\":\"" + (int)Enum.Parse(typeof(CommonEnum.LType), value.ToString()) +
                //               "\",\"text\":\"" + value.ToString() + "\"},";
                //}

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


        #region 获取手机端通知公告类型
        public void GetType(HttpContext context)
        {
            StringBuilder sb = new StringBuilder("");
            string name = "";
            try
            {
                DataTable dt = sysDataDAL.GetList((int)CommonEnum.IsorNot.否, (int)CommonEnum.DataType.通知公告);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        name += "{\"value\":\"" + dt.Rows[i]["SDID"].ToString() +
                               "\",\"text\":\"" + dt.Rows[i]["DataName"].ToString() + "\"},";
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
        #endregion

        public void GetLB(HttpContext context)
        {
            StringBuilder sb = new StringBuilder("");
            string name = "";
            try
            {
                Array values = Enum.GetValues(typeof(CommonEnum.LFlag));
                foreach (Enum value in values)
                {
                    name += "{\"value\":\"" + (int)Enum.Parse(typeof(CommonEnum.LFlag), value.ToString()) +
                               "\",\"text\":\"" + value.ToString() + "\"},";
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


        #region 获取项目信息
        public void GetProList(HttpContext context)
        {
            StringBuilder sb = new StringBuilder("");
            string name = "";
            try
            {
                PurchaseEntity model = new PurchaseEntity();
                model.Isdel = (int)CommonEnum.Deleted.未删除;
                model.PLState = (int)CommonEnum.AduitState.通过;
                model.IsChecked = (int)CommonEnum.Deleted.未删除;
                DataTable dv = purchaseDAL.List(model);
                foreach (DataRow row in dv.Rows)
                {
                    name += "{\"value\":\"" + row["PID"] + "\",\"text\":\"" + row["PTitle"] + "\"},";
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

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}