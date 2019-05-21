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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GKICMP.ashx
{
    /// <summary>
    /// Customized 的摘要说明
    /// </summary>
    public class WF : IHttpHandler
    {
        WF_FormDAL wF_FormDAL = new WF_FormDAL();
        WF_CustomizedDAL wF_CustomizedDAL = new WF_CustomizedDAL();
        WF_CustomizedFlowDAL wF_CustomizedFlowDAL = new WF_CustomizedFlowDAL();
        public void ProcessRequest(HttpContext context)
        {
            string method = context.Request.Params["method"];
            switch (method)
            {
                case "GetWF":
                    GetWF(context);
                    break;
                case "GetDraftWF":
                    GetDraftWF(context);
                    break;
                case "GetWFPart":
                    GetWFPart(context);
                    break;
                case "GetWFPartByID":
                    GetWFPartByID(context);
                    break;
                case "GetFormAuditByID":
                    GetFormAuditByID(context);
                    break;
                case "GetFormAudit":
                    GetFormAudit(context);
                    break;
                case "GetFormFlowData":
                    GetFormFlowData(context);
                    break;
                case "SaveWFFromData":
                    SaveWFFromData(context);
                    break;
                case "SaveFormAuditData":
                    SaveFormAuditData(context);
                    break;
                case "SaveWFFormFlowData":
                    SaveWFFormFlowData(context);
                    break;
                case "UploadFile":
                    UploadFile(context);
                    break;
                case "GetRole":
                    GetRole(context);
                    break;
                case "GetRoleUser":
                    GetRoleUser(context);
                    break;
                case "GetFullFlow":
                    GetFullFlow(context);
                    break;
                case "WFAudit":
                    WFAudit(context);
                    break;
                case "WFListApp":
                    WFListApp(context);
                    break;
                case "WFZBListApp":
                    WFZBListApp(context);
                    break;
                case "WFDBListApp":
                    WFDBListApp(context);
                    break;
                case "WFCSListApp":
                    WFCSListApp(context);
                    break;
            }
            //List(context);
        }
        /// <summary>
        /// 事务列表（移动端）
        /// </summary>
        /// <param name="context"></param>
        private void WFListApp(HttpContext context)
        {
            int recordCount = -1;
            StringBuilder sb = new StringBuilder();
            string userid = CommonFunction.Decrypt(context.Request.Params["UserID"]);
            int pageindex = Convert.ToInt32(context.Request.Params["pageindex"]);
            int pagesize = Convert.ToInt32(context.Request.Params["pagesize"]);
            string didname = context.Request.Params["didname"];
            string name = "";
            DataTable dt = wF_FormDAL.GetPagedList(pagesize, pageindex, ref recordCount, 1, 1);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    name += "{\"WFFID\":\"" + dt.Rows[i]["WFFID"] + "\",";//
                    name += "\"FormName\":\"" + dt.Rows[i]["FormName"] + "\"},";//
                }
                sb.Append("{\"result\":\"success\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");
            }
            else
            {
                sb.Append("{\"result\":\"false\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");
            }
            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }
        /// <summary>
        /// 在办事务列表（移动端）
        /// </summary>
        /// <param name="context"></param>
        private void WFZBListApp(HttpContext context)
        {
            int recordCount = -1;
            StringBuilder sb = new StringBuilder();
            string userid = CommonFunction.Decrypt(context.Request.Params["UserID"]);
            int pageindex = Convert.ToInt32(context.Request.Params["pageindex"]);
            int pagesize = Convert.ToInt32(context.Request.Params["pagesize"]);
            string didname = context.Request.Params["didname"];
            string name = "";
            DataTable dt = wF_CustomizedDAL.GetPagedList(pagesize, pageindex, ref recordCount, userid, "");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    name += "{\"WFFID\":\"" + dt.Rows[i]["WFFID"] + "\",";//
                    name += "\"FormName\":\"" + dt.Rows[i]["FormName"] + "\",";//
                    name += "\"CreateDate\":\"" + Convert.ToDateTime(dt.Rows[i]["CreateDate"].ToString()).ToString("yyyy-MM-dd") + "\",";//
                    name += "\"CStateName\":\"" + CommonFunction.CheckEnum< CommonEnum.CState >( dt.Rows[i]["CState"]) + "\",";//
                    name += "\"LastDate\":\"" + Convert.ToDateTime(dt.Rows[i]["LastDate"].ToString()).ToString("yyyy-MM-dd") + "\",";//
                    name += "\"CState\":\"" + dt.Rows[i]["CState"] + "\",";//
                    name += "\"CID\":\"" + dt.Rows[i]["CID"] + "\"},";//
                }
                sb.Append("{\"result\":\"success\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");
            }
            else
            {
                sb.Append("{\"result\":\"false\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");
            }
            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }
        /// <summary>
        /// 待办事务列表（移动端）
        /// </summary>
        /// <param name="context"></param>
        private void WFDBListApp(HttpContext context)
        {
            int recordCount = -1;
            StringBuilder sb = new StringBuilder();
            string userid = CommonFunction.Decrypt(context.Request.Params["UserID"]);
            int pageindex = Convert.ToInt32(context.Request.Params["pageindex"]);
            int pagesize = Convert.ToInt32(context.Request.Params["pagesize"]);
            string didname = context.Request.Params["didname"];
            string name = "";
            DataTable dt = wF_CustomizedFlowDAL.GetUserPagedList(pagesize, pageindex, ref recordCount, userid, (int)CommonEnum.CState.审核中);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    name += "{\"WFFID\":\"" + dt.Rows[i]["WFFID"] + "\",";//
                    name += "\"FormName\":\"" + dt.Rows[i]["FormName"] + "\",";//
                    name += "\"CreateDate\":\"" + Convert.ToDateTime(dt.Rows[i]["CreateDate"].ToString()).ToString("yyyy-MM-dd") + "\",";//
                    //name += "\"CStateName\":\"" + CommonFunction.CheckEnum<CommonEnum.CState>(dt.Rows[i]["CState"]) + "\",";//
                   // name += "\"LastDate\":\"" + Convert.ToDateTime(dt.Rows[i]["LastDate"].ToString()).ToString("yyyy-MM-dd") + "\",";//
                    //name += "\"CState\":\"" + dt.Rows[i]["CState"] + "\",";//
                    name += "\"UserName\":\"" + dt.Rows[i]["UserName"] + "\",";//
                    name += "\"FAID\":\"" + dt.Rows[i]["FAID"] + "\",";//
                    name += "\"CID\":\"" + dt.Rows[i]["CID"] + "\"},";//
                }
                sb.Append("{\"result\":\"success\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");
            }
            else
            {
                sb.Append("{\"result\":\"false\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");
            }
            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }
        private void WFCSListApp(HttpContext context)
        {
            int recordCount = -1;
            StringBuilder sb = new StringBuilder();
            string userid = CommonFunction.Decrypt(context.Request.Params["UserID"]);
            int pageindex = Convert.ToInt32(context.Request.Params["pageindex"]);
            int pagesize = Convert.ToInt32(context.Request.Params["pagesize"]);
            string didname = context.Request.Params["didname"];
            string name = "";
            DataTable dt = wF_CustomizedDAL.GetSendPagedList(pagesize, pageindex, ref recordCount, userid);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    name += "{\"WFFID\":\"" + dt.Rows[i]["WFFID"] + "\",";//
                    name += "\"FormName\":\"" + dt.Rows[i]["FormName"] + "\",";//
                    name += "\"CreateDate\":\"" + Convert.ToDateTime(dt.Rows[i]["CreateDate"].ToString()).ToString("yyyy-MM-dd") + "\",";//
                    name += "\"CStateName\":\"" + CommonFunction.CheckEnum<CommonEnum.CState>(dt.Rows[i]["CState"]) + "\",";//
                    name += "\"LastDate\":\"" + Convert.ToDateTime(dt.Rows[i]["LastDate"].ToString()).ToString("yyyy-MM-dd") + "\",";//
                    name += "\"CState\":\"" + dt.Rows[i]["CState"] + "\",";//
                    name += "\"CID\":\"" + dt.Rows[i]["CID"] + "\"},";//
                }
                sb.Append("{\"result\":\"success\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");
            }
            else
            {
                sb.Append("{\"result\":\"false\",\"data\":[");
                sb.Append(name.TrimEnd(','));
                sb.Append("]}");
            }
            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }

        #region 获取自有流表单的信息
        private void GetWF(HttpContext context)
        {
            string wffid = context.Request.Params["WFFID"];
            StringBuilder sb = new StringBuilder("");
            string data = "";
            try
            {
                WF_FormEntity model = new WF_FormDAL().GetObjByID(wffid);
                DataTable dt = new WF_FormDataDAL().GetTable(wffid, isdel: true);

                string part = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //获取下级的数据
                    DataTable fdvdt = new WF_FormDValueDAL().GetTable(dt.Rows[i]["FDID"].ToString());
                    string fdv = "";
                    for (int j = 0; j < fdvdt.Rows.Count; j++)
                    {
                        fdv += "{\"FDVID\":\"" + fdvdt.Rows[j]["FDVID"].ToString() + "\"" +
                            ",\"FDValue\":\"" + fdvdt.Rows[j]["FDValue"].ToString() + "\"},";
                    }


                    part += "{\"FDValue\":\"" + dt.Rows[i]["FDValue"].ToString() + "\"" +
                          ",\"FDID\":\"" + dt.Rows[i]["FDID"].ToString() + "\"" +
                    ",\"FDType\":\"" + dt.Rows[i]["FDType"].ToString() + "\"" +
                    ",\"FPID\":\"" + dt.Rows[i]["FPID"].ToString() + "\"" +
                    ",\"List\":[" + fdv.TrimEnd(',') + "]" +
                    ",\"IsRequired\":\"" + dt.Rows[i]["IsRequired"].ToString() + "\"},";
                }
                data = "{\"FormName\":\"" + model.FormName + "\",\"List\":[" + part.TrimEnd(',') + "]}";
                sb.Append("[");
                sb.Append(data.ToString());
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


        #region 获取自有流表单的草稿信息
        private void GetDraftWF(HttpContext context)
        {
            string wffid = context.Request.Params["WFFID"];
            string cid = context.Request.Params["CID"];
            StringBuilder sb = new StringBuilder("");
            string data = "";
            try
            {
                WF_FormEntity model = new WF_FormDAL().GetObjByID(wffid);
                DataTable dt = new WF_FormDataDAL().GetTable(wffid, isdel: true);

                string part = "";

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //获取下级的数据
                    DataTable fdvdt = new WF_FormDValueDAL().GetTable(dt.Rows[i]["FDID"].ToString());
                    string fdv = "";
                    for (int j = 0; j < fdvdt.Rows.Count; j++)
                    {
                        fdv += "{\"FDVID\":\"" + fdvdt.Rows[j]["FDVID"].ToString() + "\"" +
                            ",\"FDValue\":\"" + fdvdt.Rows[j]["FDValue"].ToString() + "\"},";
                    }
                    string draftvalue = "";
                    DataTable ffddt = new WF_FormFlowDataDAL().GetTable(cid, Convert.ToInt32(dt.Rows[i]["FDID"]));
                    foreach (DataRow ffddr in ffddt.Rows)
                    {
                        draftvalue += "{\"FFDID\":\"" + ffddr["FFDID"].ToString() + "\"" +
                            ",\"FDValue\":\"" + ffddr["FDValue"].ToString().Replace("\r", "$%$").Replace("\n", "$%$") + "\"},";
                    }
                    //WF_FormFlowDataEntity ffdmodel = new WF_FormFlowDataDAL().GetObjByFDID(dt.Rows[i]["FDID"].ToString());
                    //if (ffdmodel != null)
                    //{
                    //    draftvalue = ffdmodel.FDValue;
                    //}
                    part += "{\"FDValue\":\"" + dt.Rows[i]["FDValue"].ToString() + "\"" +
                          ",\"FDID\":\"" + dt.Rows[i]["FDID"].ToString() + "\"" +
                    ",\"FDType\":\"" + dt.Rows[i]["FDType"].ToString() + "\"" +
                    ",\"FPID\":\"" + dt.Rows[i]["FPID"].ToString() + "\"" +
                    ",\"DraftValue\":[" + draftvalue.TrimEnd(',') + "]" +
                    ",\"List\":[" + fdv.TrimEnd(',') + "]" +
                    ",\"IsRequired\":\"" + dt.Rows[i]["IsRequired"].ToString() + "\"},";
                }


                //获取所有未审核的数据



                data = "{\"FormName\":\"" + model.FormName + "\",\"List\":[" + part.TrimEnd(',') + "]}";
                sb.Append("[");
                sb.Append(data.ToString());
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


        #region 获取所有的组件
        private void GetWFPart(HttpContext context)
        {
            StringBuilder sb = new StringBuilder("");
            string part = "";
            try
            {
                DataTable dt = new WF_FormPartDAL().GetTable();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        part += "{\"FPID\":\"" + dt.Rows[i]["FPID"].ToString() + "\"" +
                        ",\"FPartName\":\"" + dt.Rows[i]["FPartName"].ToString() + "\"" +
                        ",\"FPType\":\"" + dt.Rows[i]["FPType"].ToString() + "\"" +
                        ",\"IsRequired\":\"" + dt.Rows[i]["IsRequired"].ToString() + "\"" +
                        ",\"Isdel\":\"" + dt.Rows[i]["Isdel"].ToString() + "\"},";
                    }
                }
                else
                {
                    part = "";
                }
                sb.Append("[");
                sb.Append(part.ToString().TrimEnd(','));
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


        #region 获取所有的审核流
        private void GetFormAudit(HttpContext context)
        {
            StringBuilder sb = new StringBuilder("");
            string wffid = context.Request.Params["WFFID"];
            string cid = context.Request.Params["CID"];
            string part = "";
            try
            {
                DataTable dt = new WF_FormAuditDAL().GetTable(wffid, true);

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataTable partdt = new WF_FormAuditValueDAL().GetTable(Convert.ToInt32(dt.Rows[i]["FAID"]), Convert.ToInt32(dt.Rows[i]["AuditType"]), wffid);
                        string favpart = "", seldata = "";
                        for (int j = 0; j < partdt.Rows.Count; j++)
                        {
                            favpart += "{\"FAVID\":\"" + partdt.Rows[j]["FAVID"].ToString() + "\"" +
                        ",\"URID\":\"" + partdt.Rows[j]["URID"].ToString() + "\"" +
                        ",\"Name\":\"" + partdt.Rows[j]["Name"].ToString() + "\"" +
                        ",\"FAVType\":\"1\"},";
                        }
                        favpart = favpart.ToString().TrimEnd(',');

                        if (!string.IsNullOrEmpty(cid))
                        {
                            DataTable cfdt = new WF_CustomizedFlowDAL().GetTable(cid, Convert.ToInt32(dt.Rows[i]["FAID"]));
                            foreach (DataRow cfdr in cfdt.Rows)
                            {
                                //判断是否是角色组
                                WF_FormAuditEntity famodel = new WF_FormAuditDAL().GetObjByID(dt.Rows[i]["FAID"].ToString());
                                if (famodel.AuditType == 1)
                                {
                                    //用户组
                                    int selfavid = new WF_FormAuditValueDAL().GetObjByUID(cfdr["UID"].ToString(), dt.Rows[i]["FAID"].ToString()).FAVID;
                                    seldata += "{\"CFID\":\"" + cfdr["CFID"].ToString() + "\"" +
                            ",\"FAVID\":\"" + selfavid + "\"},";
                                }
                                else
                                {
                                    //角色
                                    int selfavid = Convert.ToInt32(cfdr["FAVID"]);
                                    seldata += "{\"CFID\":\"" + cfdr["CFID"].ToString() + "\"" +
                            ",\"FAVID\":\"" + selfavid + "\"},";
                                    break;
                                }

                            }
                        }

                        part += "{\"FAID\":\"" + dt.Rows[i]["FAID"].ToString() + "\"" +
                        ",\"AuditType\":\"" + dt.Rows[i]["AuditType"].ToString() + "\"" +
                        ",\"PID\":\"" + dt.Rows[i]["PID"].ToString() + "\"" +
                        ",\"FAVType\":\"1\"" +
                        ",\"FAVData\":[" + favpart + "]" +
                        ",\"SelData\":[" + seldata.ToString().TrimEnd(',') + "]" +
                        ",\"FlowType\":\"" + dt.Rows[i]["FlowType"].ToString() + "\"},";
                    }
                    //获取抄送人
                    DataTable favdt = new WF_FormAuditValueDAL().GetTable(-1, 1, wffid);
                    for (int i = 0; i < favdt.Rows.Count; i++)
                    {
                        part += "{\"FAVID\":\"" + favdt.Rows[i]["FAVID"].ToString() + "\"" +
                        ",\"URID\":\"" + favdt.Rows[i]["URID"].ToString() + "\"" +
                        ",\"Name\":\"" + favdt.Rows[i]["Name"].ToString() + "\"" +
                        ",\"FAVType\":\"2\"},";
                    }

                }
                else
                {
                    part = "";
                }
                sb.Append("[");
                sb.Append(part.ToString().TrimEnd(','));
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


        #region 根据ID获取组件
        private void GetWFPartByID(HttpContext context)
        {
            string fpid = context.Request.Params["FPID"];
            StringBuilder sb = new StringBuilder("");

            try
            {
                string part = "";
                WF_FormPartEntity model = new WF_FormPartDAL().GetObjByID(fpid);

                part += "{\"FPID\":\"" + model.FPID + "\"" +
                     ",\"FPartName\":\"" + model.FPartName + "\"" +
                     ",\"FPType\":\"" + model.FPType + "\"" +
                     ",\"IsRequired\":\"" + model.IsRequired + "\"" +
                     ",\"Isdel\":\"" + model.Isdel + "\"}";

                sb.Append(part);
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


        #region 根据ID获取审批流
        private void GetFAByID(HttpContext context)
        {
            string faid = context.Request.Params["FAID"];
            StringBuilder sb = new StringBuilder("");

            try
            {
                string part = "";
                WF_FormAuditEntity model = new WF_FormAuditDAL().GetObjByID(faid);

                DataTable partdt = new WF_FormAuditValueDAL().GetTable(Convert.ToInt32(faid));
                string favpart = "";
                for (int j = 0; j < partdt.Rows.Count; j++)
                {
                    favpart += "{\"FAVID\":\"" + partdt.Rows[j]["FAVID"].ToString() + "\"" +
                ",\"URID\":\"" + partdt.Rows[j]["URID"].ToString() + "\"" +
                ",\"Name\":\"" + partdt.Rows[j]["Name"].ToString() + "\"" +
                ",\"FAVType\":\"1\"},";
                }
                favpart = favpart.ToString().TrimEnd(',');


                part += "{\"FAID\":\"" + model.FAID + "\"" +
                   ",\"AuditType\":\"" + model.AuditType + "\"" +
                        ",\"PID\":\"" + model.PID + "\"" +
                        ",\"FAVData\":[" + favpart + "]" +
                        ",\"FlowType\":\"" + model.FlowType + "\"}";

                sb.Append(part);
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


        #region 根据ID获取审核流程
        private void GetFormAuditByID(HttpContext context)
        {
            string wffid = context.Request.Params["WFFID"];
            StringBuilder sb = new StringBuilder("");
            try
            {
                string part = "";
                int resultcount = -1;
                DataTable famodel = new WF_FormAuditDAL().GetTable(wffid, true);
                if (famodel.Rows.Count > 0)
                {
                    foreach (DataRow fadr in famodel.Rows)
                    {
                        string favpart = "";
                        DataTable favmodel = new WF_FormAuditValueDAL().GetTable(Convert.ToInt32(fadr["FAID"]), Convert.ToInt32(fadr["AuditType"]));

                        foreach (DataRow favdr in favmodel.Rows)
                        {
                            favpart += "{\"URID\":\"" + favdr["URID"].ToString() + "\"" +
                                ",\"Name\":\"" + favdr["Name"].ToString() + "\"},";
                        }

                        part += "{\"AuditType\":\"" + fadr["AuditType"].ToString() + "\"" +
                             ",\"FavPart\":[" + favpart.ToString().TrimEnd(',') + "]" +
                                ",\"FlowType\":\"" + fadr["FlowType"].ToString() + "\"},";
                    }

                    //获取抄送人
                    DataTable sendmodel = new WF_FormAuditValueDAL().GetTable(-1, 1, wffid);
                    string sendpart = "";
                    foreach (DataRow senddr in sendmodel.Rows)
                    {
                        sendpart += "{\"URID\":\"" + senddr["URID"].ToString() + "\"" +
                               ",\"Name\":\"" + senddr["Name"].ToString() + "\"},";
                    }

                    if (!string.IsNullOrEmpty(sendpart))
                    {
                        part += "{\"AuditType\":\"4\"" +
                            ",\"FavPart\":[" + sendpart.ToString().TrimEnd(',') + "]" +
                               ",\"FlowType\":\"-1\"},";
                    }

                    sb.Append("[");
                    sb.Append(part.ToString().TrimEnd(','));
                    sb.Append("]");
                }
                else
                {
                    sb.Append("{\"result\":\"NoCount\"}");
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
        #endregion


        #region 根据ID获取审核数据
        private void GetFormFlowData(HttpContext context)
        {
            string cid = context.Request.Params["CID"];
            string wffid = context.Request.Params["WFFID"];
            StringBuilder sb = new StringBuilder("");
            try
            {
                string part = "";

                DataTable dt = new WF_FormDataDAL().GetTable(wffid);

                WF_CustomizedEntity cmodel = new WF_CustomizedDAL().GetObjByID(cid);

                TimeSpan ts = cmodel.LastDate.Subtract(cmodel.CreateDate);
                string timediff = (ts.Days > 0 ? ts.Days + "天" : "") + (ts.Hours > 0 ? ts.Hours + "小时" : "") + ts.Minutes + "分";

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //获取下级的数据
                        DataTable ffdt = new WF_FormFlowDataDAL().GetTable(cid, Convert.ToInt32(dt.Rows[i]["FDID"]));
                        string ff = "";
                        for (int j = 0; j < ffdt.Rows.Count; j++)
                        {
                            //根据不同类型显示不同的数据
                            WF_FormDataEntity fd = new WF_FormDataDAL().GetObjByID(ffdt.Rows[j]["FDID"].ToString());

                            string fdvalue = "";
                            if (fd.FPID == 4 || fd.FPID == 5)
                            {
                                fdvalue = new WF_FormDValueDAL().GetObjByID(ffdt.Rows[j]["FDValue"].ToString()).FDValue;
                            }
                            else if (fd.FPID == 9)
                            {
                                fdvalue = new SysUserDAL().GetObjByID(ffdt.Rows[j]["FDValue"].ToString()).RealName;
                            }
                            else
                            {
                                fdvalue = ffdt.Rows[j]["FDValue"].ToString();
                            }


                            ff += "{\"FFDID\":\"" + ffdt.Rows[j]["FFDID"].ToString() + "\"" +
                                ",\"FDValue\":\"" + fdvalue.Replace("\r", "$%$").Replace("\n", "$%$") + "\"},";
                        }

                        if (ffdt.Rows.Count > 0)
                        {
                            part += "{\"FDValue\":\"" + dt.Rows[i]["FDValue"].ToString() + "\"" +
                             ",\"FDID\":\"" + dt.Rows[i]["FDID"].ToString() + "\"" +
                       ",\"FDType\":\"" + dt.Rows[i]["FDType"].ToString() + "\"" +
                       ",\"FPID\":\"" + dt.Rows[i]["FPID"].ToString() + "\"" +
                       ",\"List\":[" + ff.TrimEnd(',') + "]" +
                       ",\"TimeDiff\":\"" + timediff + "\"" +
                       ",\"IsRequired\":\"" + dt.Rows[i]["IsRequired"].ToString() + "\"},";
                        }

                    }

                    sb.Append("[");
                    sb.Append(part.TrimEnd(','));
                    sb.Append("]");
                }
                else
                {
                    sb.Append("{\"result\":\"NOCOUNT\"}");
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
        #endregion
        public static object locker = new object();


        #region 保存表单信息
        private void SaveWFFromData(HttpContext context)
        {
            StringBuilder sb = new StringBuilder("");
            var wfformdata = context.Request.Params["wfformdata"];
            string wffid = context.Request.Params["wffid"];
            JArray wfformjson = (JArray)JsonConvert.DeserializeObject(wfformdata);

            string userid = CommonFunction.Decrypt(context.Request.Cookies["UserID"].Value);
            //判断权限
            bool isusing = false;
            try
            {
                lock (locker)
                {
                    //判断该数据是否有正在审核中的
                    if (!string.IsNullOrEmpty(wffid))
                    {
                        DataTable usingdt = new WF_CustomizedDAL().GetTable(wffid: wffid);
                        foreach (DataRow usingdr in usingdt.Rows)
                        {
                            if (Convert.ToInt32(usingdr["CState"]) != (int)CommonEnum.CState.审核通过 && Convert.ToInt32(usingdr["CState"]) != (int)CommonEnum.CState.审核退回)
                            {
                                isusing = true;
                                break;
                            }
                        }
                    }

                    if (!isusing)
                    {
                        WF_FormEntity wffmodel = new WF_FormEntity();
                        wffmodel.WFFID = wffid;
                        wffmodel.IsEnable = 1;
                        wffmodel.Isdel = 0;
                        if (wffid.Length == 0)
                        {
                            wffmodel.IsSetAuditor = 0;
                        }
                        else
                        {
                            wffmodel.IsSetAuditor = new WF_FormDAL().GetObjByID(wffid).IsSetAuditor;
                        }

                        wffmodel.FormName = wfformjson.First["FormName"].ToString();
                        wffmodel.CreateUser = userid;

                        string wffresult = new WF_FormDAL().Edit(wffmodel);
                        if (!string.IsNullOrEmpty(wffresult))
                        {
                            if (wffresult != "自由流名称重复")
                            {
                                //读取内部表单数据
                                JArray wfformdatajson = (JArray)wfformjson.First["wfdatalist"];
                                //删除原有的所有记录，不应该真实删除
                                int delresult = new WF_FormDataDAL().Delete(wffresult);
                                if (delresult >= 0)
                                {
                                    foreach (JObject wfwormdata in wfformdatajson)
                                    {
                                        WF_FormDataEntity fdmodel = new WF_FormDataEntity();
                                        fdmodel.FDOrder = Convert.ToInt32(wfwormdata["FDOrder"]);
                                        fdmodel.FDType = Convert.ToInt32(wfwormdata["FDType"]);
                                        fdmodel.FDValue = wfwormdata["FDValue"].ToString();
                                        fdmodel.FPID = Convert.ToInt32(wfwormdata["FPID"]);
                                        fdmodel.WFFID = wffresult;
                                        fdmodel.IsRequired = Convert.ToInt32(wfwormdata["IsRequired"]);
                                        fdmodel.FDID = -1;
                                        int fdresult = new WF_FormDataDAL().Edit(fdmodel);
                                        if (fdresult >= 0)
                                        {
                                            if (fdmodel.FPID == 4 || fdmodel.FPID == 5)
                                            {
                                                JArray fdvarray = (JArray)wfwormdata["wfvalue"];
                                                foreach (JObject fdv in fdvarray)
                                                {
                                                    WF_FormDValueEntity fdvmodel = new WF_FormDValueEntity();
                                                    fdvmodel.FDVID = -1;
                                                    fdvmodel.FDID = fdresult;
                                                    fdvmodel.FDValue = fdv["value"].ToString();
                                                    new WF_FormDValueDAL().Edit(fdvmodel);
                                                }
                                            }
                                            else
                                            {
                                                WF_FormDValueEntity fdvmodel = new WF_FormDValueEntity();
                                                fdvmodel.FDVID = -1;
                                                fdvmodel.FDID = fdresult;
                                                fdvmodel.FDValue = wfwormdata["wfvalue"].First["value"].ToString();
                                                new WF_FormDValueDAL().Edit(fdvmodel);
                                            }
                                        }

                                    }
                                }

                                sb.Append("{\"result\":\"success\"}");
                            }
                            else
                            {
                                sb.Append("{\"result\":\"" + wffresult + "\"}");
                            }

                        }
                        else
                        {
                            sb.Append("{\"result\":\"" + wffresult + "\"}");
                        }
                    }
                    else
                    {
                        sb.Append("{\"result\":\"有审核流程未完成，请等所有审核流程结束后修改\"}");
                    }

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
        #endregion


        #region 保存表单审核信息
        private void SaveFormAuditData(HttpContext context)
        {
            StringBuilder sb = new StringBuilder("");
            var formauditdata = context.Request.Params["formauditdata"];
            var wffid = context.Request.Params["wffid"];
            JArray formauditjson = (JArray)JsonConvert.DeserializeObject(formauditdata);

            string userid = CommonFunction.Decrypt(context.Request.Cookies["UserID"].Value);
            bool isusing = false;
            //判断权限
            try
            {
                lock (locker)
                {
                    //判断该数据是否有正在审核中的
                    if (!string.IsNullOrEmpty(wffid))
                    {
                        DataTable usingdt = new WF_CustomizedDAL().GetTable(wffid: wffid);
                        foreach (DataRow usingdr in usingdt.Rows)
                        {
                            if (Convert.ToInt32(usingdr["CState"]) != (int)CommonEnum.CState.审核通过 && Convert.ToInt32(usingdr["CState"]) != (int)CommonEnum.CState.审核退回)
                            {
                                isusing = true;
                                break;
                            }
                        }
                    }

                    if (!isusing)
                    {

                        WF_FormEntity wfmodel = new WF_FormDAL().GetObjByID(wffid);
                        wfmodel.IsSetAuditor = 1;
                        wfmodel.CreateUser = userid;
                        //要考虑到已有的数据如何处理
                        new WF_FormAuditDAL().Delete(wffid);
                        new WF_FormAuditValueDAL().Delete(wffid);

                        if (wfmodel != null)
                        {
                            //事先删除掉原来的数据
                            int pid = -1;
                            foreach (JObject formaudit in formauditjson)
                            {
                                if (Convert.ToInt32(formaudit["Type"]) != (int)CommonEnum.AuditType.抄送)
                                {
                                    WF_FormAuditEntity famodel = new WF_FormAuditEntity();
                                    famodel.WFFID = wffid;
                                    famodel.PID = pid;
                                    famodel.FAID = -1;
                                    famodel.FlowType = Convert.ToInt32(formaudit["flowtype"]);
                                    famodel.AuditType = Convert.ToInt32(formaudit["Type"]);
                                    int faressult = new WF_FormAuditDAL().Edit(famodel);
                                    if (faressult > 0)
                                    {
                                        pid = faressult;

                                        JArray dataarray = (JArray)formaudit["Data"];
                                        foreach (JObject data in dataarray)
                                        {
                                            WF_FormAuditValueEntity fvmodel = new WF_FormAuditValueEntity();
                                            fvmodel.FAID = faressult;
                                            fvmodel.FAVID = -1;
                                            fvmodel.WFFID = wffid;
                                            fvmodel.URID = data["id"].ToString();
                                            fvmodel.FAVType = (int)CommonEnum.FAVType.审核;
                                            new WF_FormAuditValueDAL().Edit(fvmodel);
                                        }
                                    }
                                }
                                else
                                {
                                    JArray dataarray = (JArray)formaudit["Data"];
                                    foreach (JObject data in dataarray)
                                    {
                                        WF_FormAuditValueEntity fvmodel = new WF_FormAuditValueEntity();
                                        fvmodel.FAID = -1;
                                        fvmodel.FAVID = -1;
                                        fvmodel.WFFID = wffid;
                                        fvmodel.URID = data["id"].ToString();
                                        fvmodel.FAVType = (int)CommonEnum.FAVType.抄送;
                                        new WF_FormAuditValueDAL().Edit(fvmodel);
                                    }
                                }


                            }
                            new WF_FormDAL().Edit(wfmodel);
                            sb.Append("{\"result\":\"success\"}");
                        }
                        else
                        {
                            sb.Append("{\"result\":\"NoCount\"}");
                        }
                    }
                    else
                    {
                        sb.Append("{\"result\":\"有审核流程未完成，请等所有审核流程结束后修改\"}");
                    }
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
        #endregion


        #region 保存提交的自由流
        private void SaveWFFormFlowData(HttpContext context)
        {
            HttpFileCollection files = context.Request.Files;
            StringBuilder sb = new StringBuilder("");
            var wfformflowdata = context.Request.Params["wfformflowdata"];
            var auditdata = context.Request.Params["auditdata"];
            var wffid = context.Request.Params["wffid"];
            string cid = context.Request.Params["cid"];
            int isdraft = Convert.ToInt32(context.Request.Params["isdraft"]);
            JArray wfformflowjson = (JArray)JsonConvert.DeserializeObject(wfformflowdata);
            JArray auditjson = (JArray)JsonConvert.DeserializeObject(auditdata);

            string userid = CommonFunction.Decrypt(context.Request.Cookies["UserID"].Value);
            //判断权限,是否在可见用户中
            bool isempty = false, isflow = false;
            string emptyfd = "";
            try
            {
                lock (locker)
                {
                    //先判定是否有必填项未添
                    DataTable fdmodel = new WF_FormDataDAL().GetTable(wffid, 1, true);

                    foreach (DataRow dr in fdmodel.Rows)
                    {
                        bool isvalue = false;
                        foreach (JObject wffformflow in wfformflowjson)
                        {
                            if (Convert.ToInt32(wffformflow["FDID"]) == Convert.ToInt32(dr["FDID"]) && wffformflow["Data"] != null && !string.IsNullOrEmpty(wffformflow["Data"].ToString()))
                            {
                                isvalue = true;
                                break;
                            }
                        }
                        if (!isvalue)
                        {
                            emptyfd = dr["FDValue"].ToString();
                            isempty = true;
                            break;
                        }
                    }


                    //在判断是否修改了已处于审核中的数据
                    if (!string.IsNullOrEmpty(cid))
                    {
                        WF_CustomizedEntity wfcmodel = new WF_CustomizedDAL().GetObjByID(cid);
                        if (wfcmodel != null)
                        {
                            if (wfcmodel.CState != (int)CommonEnum.CState.拟办)
                            {
                                isflow = true;
                            }
                        }
                    }

                    if (!isflow)
                    {
                        if (!isempty)
                        {
                            WF_CustomizedEntity wfcmodel = new WF_CustomizedEntity();
                            if (!string.IsNullOrEmpty(cid))
                            {
                                wfcmodel = new WF_CustomizedDAL().GetObjByID(cid);
                                wfcmodel.CID = cid;
                            }
                            else
                            {
                                wfcmodel.CID = "";
                                wfcmodel.LastDate = DateTime.Now;
                            }
                            wfcmodel.WFFID = wffid;
                            wfcmodel.CreateUser = userid;
                            if (isdraft == 1)
                            {
                                wfcmodel.CState = (int)CommonEnum.CState.拟办;
                            }
                            else
                            {
                                wfcmodel.CState = (int)CommonEnum.CState.审核中;
                            }
                            wfcmodel.FAID = Convert.ToInt32(new WF_FormAuditDAL().GetTable(wffid, true).Rows[0]["FAID"]);
                            string result = new WF_CustomizedDAL().Edit(wfcmodel);

                            if (!string.IsNullOrEmpty(result))
                            {
                                wfcmodel.CID = result;
                                //清空之前的数据
                                if (!string.IsNullOrEmpty(cid))
                                    new WF_FormFlowDataDAL().Deleted(cid);
                                foreach (JObject wffformflow in wfformflowjson)
                                {
                                    if (wffformflow["Data"] != null)
                                    {
                                        string fdvaluelist = wffformflow["Data"].ToString();
                                        foreach (string fdvalue in fdvaluelist.Split(','))
                                        {
                                            if (!string.IsNullOrEmpty(fdvalue))
                                            {
                                                //保存值
                                                WF_FormFlowDataEntity ffdmodel = new WF_FormFlowDataEntity();
                                                ffdmodel.FFDID = -1;
                                                ffdmodel.FDID = Convert.ToInt32(wffformflow["FDID"]);
                                                ffdmodel.WFFID = wffid;
                                                ffdmodel.FDValue = fdvalue;
                                                ffdmodel.CID = result;
                                                new WF_FormFlowDataDAL().Edit(ffdmodel);
                                            }
                                        }
                                    }
                                }

                            }
                            else
                            {
                                sb.Append("{\"result\":\"failed\"}");
                            }

                            //草稿时删除所有的审核记录
                            if (!string.IsNullOrEmpty(cid))
                            {
                                new WF_CustomizedFlowDAL().Delete(cid);
                            }
                            //录入所有的选择项，并置为未审核
                            foreach (JObject auditflow in auditjson)
                            {
                                int favid = Convert.ToInt32(auditflow["FAVID"]);
                                WF_FormAuditValueEntity fav = new WF_FormAuditValueDAL().GetObjByID(favid);
                                WF_FormAuditEntity fa = new WF_FormAuditDAL().GetObjByID(auditflow["FAID"].ToString());
                                if (fa.AuditType == 1)
                                {
                                    WF_CustomizedFlowEntity cfemodel = new WF_CustomizedFlowEntity();
                                    cfemodel.AuditDate = DateTime.Now;
                                    cfemodel.CID = result;
                                    cfemodel.CFID = -1;
                                    cfemodel.CStauts = (int)CommonEnum.CState.未审核;
                                    cfemodel.FAID = Convert.ToInt32(auditflow["FAID"]);
                                    cfemodel.UID = fav.URID;
                                    cfemodel.Remark = "";
                                    cfemodel.FAVID = favid;
                                    new WF_CustomizedFlowDAL().Edit(cfemodel);
                                }
                                else
                                {
                                    //用户组所有人都发一份
                                    DataTable userdt = new SysUserDAL().GetSysUserByRole(Convert.ToInt32(fav.URID), (int)CommonEnum.Deleted.未删除);
                                    foreach (DataRow userdr in userdt.Rows)
                                    {
                                        if (new WF_CustomizedFlowDAL().GetObjByID(result, Convert.ToInt32(auditflow["FAID"]), userdr["UID"].ToString()) == null)
                                        {
                                            WF_CustomizedFlowEntity cfemodel = new WF_CustomizedFlowEntity();
                                            cfemodel.AuditDate = DateTime.Now;
                                            cfemodel.CID = result;
                                            cfemodel.CFID = -1;
                                            cfemodel.CStauts = (int)CommonEnum.CState.未审核;
                                            cfemodel.FAID = Convert.ToInt32(auditflow["FAID"]);
                                            cfemodel.UID = userdr["UID"].ToString();
                                            cfemodel.Remark = "";
                                            cfemodel.FAVID = favid;
                                            new WF_CustomizedFlowDAL().Edit(cfemodel);
                                        }
                                    }

                                }
                            }
                            if (isdraft != 1)
                            {
                                //可发送一条信息到第一轮的用户中
                                DataTable famodel = new WF_FormAuditDAL().GetTable(wffid, true);
                                Send(new WF_FormAuditDAL().GetObjByID(famodel.Rows[0]["FAID"].ToString()), result);
                            }
                            sb.Append("{\"result\":\"success\"}");
                        }
                        else
                        {
                            sb.Append("{\"result\":\"请填写:" + emptyfd + "\"}");
                        }
                    }
                    else
                    {
                        sb.Append("{\"result\":\"该事务已发起审核，无法修改\"}");
                    }
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
        #endregion




        #region 上传文件
        private void UploadFile(HttpContext context)
        {
            StringBuilder sb = new StringBuilder("");
            try
            {
                System.Web.HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
                if (files.AllKeys.Length > 0)
                {
                    for (int i = 0; i < files.AllKeys.Length; i++)
                    {
                        //webupload
                        System.Web.HttpPostedFile postedfile = files[i];
                        string uploadPath = HttpContext.Current.Server.MapPath("\\webupload\\WFFile\\");
                        string exten = System.IO.Path.GetExtension(postedfile.FileName);
                        string fileName = string.Format("WFFILE_{0}{1}", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-ff"), exten);

                        files[i].SaveAs(uploadPath + fileName);

                        sb.Append("{\"result\":\"success\",\"name\":\"" + fileName + "\"}");
                    }
                }
                else
                {
                    sb.Append("{\"result\":\"NOCOUNT\"}");
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
        #endregion



        #region 获取所有的角色
        private void GetRole(HttpContext context)
        {
            StringBuilder sb = new StringBuilder("");
            try
            {
                string part = "";
                //DataTable model = new DepartmentDAL().GetZNBM((int)CommonEnum.DepType.职能部门, (int)CommonEnum.Deleted.未删除);
                //foreach (DataRow dr in model.Rows)
                //{
                //    part += "{\"DID\":\"" + dr["DID"].ToString() + "\"" +
                //     ",\"DepName\":\"" + dr["DepName"].ToString() + "\"},";
                //}
                DataTable model = new SysRoleDAL().GetTable(0);
                foreach (DataRow dr in model.Rows)
                {
                    part += "{\"DID\":\"" + dr["RoleID"].ToString() + "\"" +
                     ",\"DepName\":\"" + dr["RoleName"].ToString() + "\"},";
                }
                sb.Append("[");
                sb.Append(part.ToString().TrimEnd(','));
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


        #region 获取所有的角色下的人员
        private void GetRoleUser(HttpContext context)
        {
            StringBuilder sb = new StringBuilder("");
            int roleid = Convert.ToInt32(context.Request.Params["role"]);

            try
            {
                DataTable model = null;
                string part = "";
                if (roleid == 0)
                {
                    model = new SysUserDAL().GetSysUserByTeac((int)CommonEnum.UserType.老师, (int)CommonEnum.Deleted.未删除);
                }
                else
                {
                    model = new SysUserDAL().GetSysUserByRole(roleid, (int)CommonEnum.Deleted.未删除);
                }
                foreach (DataRow dr in model.Rows)
                {
                    part += "{\"UID\":\"" + dr["UID"].ToString() + "\"" +
                     ",\"RealName\":\"" + dr["RealName"].ToString() + "\"},";
                }
                sb.Append("[");
                sb.Append(part.ToString().TrimEnd(','));
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



        #region 获取审核的流程
        private void GetFullFlow(HttpContext context)
        {
            StringBuilder sb = new StringBuilder("");
            string cid = context.Request.Params["CID"].ToString();

            try
            {
                WF_CustomizedEntity cmodel = new WF_CustomizedDAL().GetObjByID(cid);
                string part = "";
                //在这里需要考虑如何兼容老的
                DataTable fadt = new WF_FormAuditDAL().GetTable(cmodel.WFFID);

                DataRow[] fadr = fadt.Select("PID=-1");
                WF_FormAuditEntity fa = new WF_FormAuditEntity();
                for (int i = 0; i < fadr.Length; i++)
                {
                    fa = new WF_FormAuditDAL().GetObjByID(fadr[i]["FAID"].ToString());
                    DataTable cfdt = new WF_CustomizedFlowDAL().GetTable(cid, fa.FAID);
                    if (cfdt.Rows.Count > 0)
                    {
                        break;
                    }
                }


                while (fa != null && fa.PID != cmodel.FAID)
                {
                    if (fa.FlowType == 1)
                    {
                        //会签
                        DataTable cfdt = new WF_CustomizedFlowDAL().GetTable(cid, fa.FAID);
                        string cfpart = "";
                        foreach (DataRow dr in cfdt.Rows)
                        {
                            if (Convert.ToInt32(dr["CStauts"]) != (int)CommonEnum.CState.审核中)
                            {
                                cfpart += "{\"FAID\":\"" + fa.FAID + "\"" +
                       ",\"AuditDate\":\"" + Convert.ToDateTime(dr["AuditDate"]).ToString("yyyy-MM-dd HH:mm") + "\"" +
                             ",\"UserName\":\"" + new SysUserDAL().GetObjByID(dr["UID"].ToString()).RealName + "\"" +
              ",\"Remark\":\"" + dr["Remark"].ToString() + "\"},";
                            }
                        }

                        part += "{\"FAID\":\"" + fa.FAID + "\"" +
                               ",\"FlowType\":\"" + fa.FlowType + "\"" +
                ",\"CFData\":[" + cfpart.TrimEnd(',') + "]},";
                    }
                    else
                    {
                        WF_CustomizedFlowEntity cfmodel = new WF_CustomizedFlowDAL().GetObjByID(cid, fa.FAID, cstate: 2);
                        if (cfmodel == null)
                        {
                            cfmodel = new WF_CustomizedFlowDAL().GetObjByID(cid, fa.FAID, cstate: 3);
                        }

                        if (cfmodel != null)
                        {
                            //该级别已审核
                            part += "{\"FAID\":\"" + fa.FAID + "\"" +
                                ",\"FlowType\":\"" + fa.FlowType + "\"" +
                          ",\"AuditDate\":\"" + cfmodel.AuditDate.ToString("yyyy-MM-dd HH:mm") + "\"" +
                                ",\"UserName\":\"" + new SysUserDAL().GetObjByID(cfmodel.UID).RealName + "\"" +
                 ",\"Remark\":\"" + cfmodel.Remark + "\"},";
                        }
                        else
                        {
                            part += "{\"FAID\":\"" + fa.FAID + "\"" +
                               ",\"FlowType\":\"" + fa.FlowType + "\"" +
                         ",\"AuditDate\":\"\"" +
                               ",\"UserName\":\"\"" +
                ",\"Remark\":\"\"},";
                        }


                    }

                    fa = new WF_FormAuditDAL().GetObjByParentID(fa.FAID.ToString());
                }


                sb.Append("[");
                sb.Append(part.ToString().TrimEnd(','));
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



        #region 审核表单信息
        private void WFAudit(HttpContext context)
        {
            StringBuilder sb = new StringBuilder("");
            int faid = Convert.ToInt32(context.Request.Params["FAID"]);
            int csstate = Convert.ToInt32(context.Request.Params["CState"]);
            string cid = context.Request.Params["CID"].ToString();
            string remark = context.Request.Params["Remark"].ToString();
            string userid = CommonFunction.Decrypt(context.Request.Cookies["UserID"].Value);
            //判断权限
            try
            {
                lock (locker)
                {
                    WF_CustomizedFlowEntity cfmodel = new WF_CustomizedFlowDAL().GetObjByID(cid.ToString(), Convert.ToInt32(faid), userid, (int)CommonEnum.CState.审核中);
                    if (cfmodel != null)
                    {


                        WF_CustomizedEntity cmodel = new WF_CustomizedDAL().GetObjByID(cid);
                        cmodel.LastDate = DateTime.Now;



                        cfmodel.CStauts = csstate;
                        cfmodel.Remark = remark;
                        cfmodel.AuditDate = DateTime.Now;

                        new WF_CustomizedFlowDAL().Edit(cfmodel);

                        WF_FormAuditEntity famodel = new WF_FormAuditDAL().GetObjByID(faid.ToString());
                        if (csstate == (int)CommonEnum.CState.审核通过)
                        {
                            //判断该项目是否是会签
                            if (famodel.FlowType == 1)
                            {
                                //会签，判断该位置是否审批完成,未完成继续
                                WF_CustomizedFlowEntity isauditcf = new WF_CustomizedFlowDAL().GetObjByID(cid, faid, cstate: (int)CommonEnum.CState.审核中);
                                if (isauditcf == null)
                                {
                                    //发送下一级
                                    WF_FormAuditEntity nextfa = new WF_FormAuditDAL().GetObjByParentID(faid.ToString());
                                    if (nextfa != null)
                                    {
                                        //发送下一级
                                        Send(nextfa, cid);
                                        cmodel.FAID = nextfa.FAID;
                                    }
                                    else
                                    {
                                        //完成
                                        cmodel.FAID = faid;
                                        cmodel.CState = csstate;
                                    }
                                }

                            }
                            else
                            {
                                //其他，将其他该fa的置为无需审批,并向下一级发送请求，若无下一级，则将该审批置为完成
                                new WF_CustomizedFlowDAL().Set(cid, userid, faid, (int)CommonEnum.CState.无需审核, remark, 2);
                                WF_FormAuditEntity nextfa = new WF_FormAuditDAL().GetObjByParentID(faid.ToString());
                                if (nextfa != null)
                                {
                                    //发送下一级
                                    Send(nextfa, cid);
                                    cmodel.FAID = nextfa.FAID;
                                }
                                else
                                {
                                    //完成
                                    cmodel.FAID = faid;
                                    cmodel.CState = csstate;
                                }
                            }
                        }
                        else
                        {
                            //将该级别的全部置为无需审批，结束该级别
                            new WF_CustomizedFlowDAL().Set(cid, userid, faid, csstate, remark, 2);
                            cmodel.FAID = faid;
                            cmodel.CState = csstate;
                        }


                        new WF_CustomizedDAL().Edit(cmodel);

                        sb.Append("{\"result\":\"success\"}");
                    }
                    else
                    {
                        sb.Append("{\"result\":\"非审核用户\"}");
                    }

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
        #endregion


        private void Send(WF_FormAuditEntity fa, string cid)
        {
            int faid = fa.FAID;
            int audittype = fa.AuditType;
            int flowtype = fa.FlowType;

            if (flowtype == 0)
            {
                //获取第一个的数据
                WF_CustomizedFlowEntity cfemodel = new WF_CustomizedFlowDAL().GetObjByID(cid, faid);
                if (cfemodel != null)
                {
                    if (audittype == 1)
                    {
                        cfemodel.CStauts = (int)CommonEnum.CState.审核中;
                        cfemodel.AuditDate = DateTime.Now;
                        new WF_CustomizedFlowDAL().Edit(cfemodel);
                    }
                    else
                    {
                        new WF_CustomizedFlowDAL().Set(cid, "", faid, (int)CommonEnum.CState.审核中, "", 2);
                    }
                }
            }
            else
            {
                //每一个人都发一个
                DataTable favmodel = new WF_FormAuditValueDAL().GetTable(faid);
                if (audittype == 1)
                {
                    //每个人发一个,不重复发
                    foreach (DataRow favdr in favmodel.Rows)
                    {
                        WF_CustomizedFlowEntity cfemodel = new WF_CustomizedFlowDAL().GetObjByID(cid, faid, favdr["URID"].ToString());
                        if (cfemodel == null)
                        {
                            cfemodel = new WF_CustomizedFlowEntity();
                            cfemodel.CID = cid;
                            cfemodel.CStauts = (int)CommonEnum.CState.审核中;
                            cfemodel.FAID = faid;
                            cfemodel.UID = favdr["URID"].ToString();
                            cfemodel.Remark = "";
                            cfemodel.AuditDate = DateTime.Now;
                            cfemodel.CFID = -1;
                            cfemodel.FAVID = Convert.ToInt32(favdr["FAVID"]);
                        }
                        else
                        {
                            cfemodel.CStauts = (int)CommonEnum.CState.审核中;
                        }
                        new WF_CustomizedFlowDAL().Edit(cfemodel);

                    }
                }
                else
                {
                    foreach (DataRow favdr in favmodel.Rows)
                    {
                        int roleid = Convert.ToInt32(favdr["URID"]);
                        DataTable userdt = new SysUserDAL().GetSysUserByRole(roleid, (int)CommonEnum.Deleted.未删除);
                        foreach (DataRow userdr in userdt.Rows)
                        {
                            if (new WF_CustomizedFlowDAL().GetObjByID(cid, faid, userdr["UID"].ToString()) == null)
                            {
                                WF_CustomizedFlowEntity cfemodel = new WF_CustomizedFlowEntity();
                                cfemodel.CID = cid;
                                cfemodel.CStauts = (int)CommonEnum.CState.审核中;
                                cfemodel.FAID = faid;
                                cfemodel.UID = userdr["UID"].ToString();
                                cfemodel.Remark = "";
                                cfemodel.CFID = -1;
                                cfemodel.AuditDate = DateTime.Now;
                                new WF_CustomizedFlowDAL().Edit(cfemodel);
                            }
                        }
                    }
                }
            }
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