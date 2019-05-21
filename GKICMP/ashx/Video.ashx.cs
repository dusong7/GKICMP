using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Text;
using System.Xml;

namespace GKICMP.ashx
{
    /// <summary>
    /// Video 的摘要说明
    /// </summary>
    public class Video : IHttpHandler
    {
        public VideoDAL videoDAL = new VideoDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public void ProcessRequest(HttpContext context)
        {
            string method = context.Request.Params["method"];
            switch (method)
            {
                case "GetCamera":
                    GetCamera(context);
                    break;
                case "GetName":
                    GetName(context);
                    break;
                case "StuList":
                    StuList(context);
                    break;
            }
            //List(context);
        }
        #region 绑定所有的摄像机
        private void GetCamera(HttpContext context)
        {
            StringBuilder sb = new StringBuilder("");
            string name = "";
            try
            {
                DataTable dt = videoDAL.GetTable();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        name += "{\"VID\":\"" + dt.Rows[i]["VID"].ToString() + "\"" +
                        ",\"EquipName\":\"" + dt.Rows[i]["EquipName"].ToString() + "\"" +
                        ",\"EquipIP\":\"" + dt.Rows[i]["EquipIP"].ToString() + "\"" +
                        ",\"PotNum\":\"" + dt.Rows[i]["PotNum"].ToString() + "\"" +
                        ",\"UserName\":\"" + dt.Rows[i]["UserName"].ToString() + "\"" +
                        ",\"UserPwd\":\"" + dt.Rows[i]["UserPwd"].ToString() + "\"" +
                        ",\"EquipPotNum\":\"" + dt.Rows[i]["EquipPotNum"].ToString() + "\"},";
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
        #endregion


        #region 获取存在系统内的名称
        private void GetName(HttpContext context)
        {
            string ip = context.Request.Params["IP"];
            string type = context.Request.Params["type"];
            StringBuilder sb = new StringBuilder("");

            try
            {
                string name = "";
                DataTable dt = videoDAL.GetTable();
                DataRow[] drselect = dt.Select("EquipIP='" + ip + "'");

                if (drselect.Length > 0)
                {
                    name = drselect[0]["EquipName"].ToString();
                }




                //if (dt.Rows.Count > 0)
                //{
                //    for (int i = 0; i < dt.Rows.Count; i++)
                //    {
                //        name += "{\"VID\":\"" + dt.Rows[i]["VID"].ToString() + "\"" +
                //        ",\"EquipName\":\"" + dt.Rows[i]["EquipName"].ToString() + "\"" +
                //        ",\"EquipIP\":\"" + dt.Rows[i]["EquipIP"].ToString() + "\"" +
                //        ",\"PotNum\":\"" + dt.Rows[i]["PotNum"].ToString() + "\"" +
                //        ",\"UserName\":\"" + dt.Rows[i]["UserName"].ToString() + "\"" +
                //        ",\"UserPwd\":\"" + dt.Rows[i]["UserPwd"].ToString() + "\"" +
                //        ",\"EquipPotNum\":\"" + dt.Rows[i]["EquipPotNum"].ToString() + "\"},";
                //    }
                //}
                //else
                //{
                //    name = "";
                //}
                sb.Append("{");
                sb.Append("\"Name\":\"" + name + "\"");
                sb.Append("}");
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



        #region 根据年级id 绑定班级列表
        private void StuList(HttpContext context)
        {
            StringBuilder sb = new StringBuilder("");
            int gid = int.Parse(context.Request.Params["id"]);//部门类型：-1 班级 -2 职能部门；
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