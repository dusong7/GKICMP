using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Data;

namespace GKICMP.ashx
{
    /// <summary>
    /// PurchaseBill 的摘要说明
    /// </summary>
    public class PurchaseBill : IHttpHandler
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public Purchase_AuditDAL purchase_AuditDAL = new Purchase_AuditDAL();
        public Purchase_BillDAL purchase_BillDAL = new Purchase_BillDAL();
        public PurchaseDAL purchaseDAL = new PurchaseDAL();
        public void ProcessRequest(HttpContext context)
        {
            string method = context.Request.Params["method"];
            switch (method)
            {
                case "Add":
                    AddPost(context);
                    break;
                case "AuditUser":
                    AuditUser(context);
                    break;
            }
        }
        public void AddPost(HttpContext context)
        {
            StringBuilder sb = new StringBuilder();
            string userid = CommonFunction.Decrypt(context.Request.Params["UserID"]);
            try
            {
                string pid = context.Request.Params["pid"] == "" ? "0" : context.Request.Params["pid"];
                string bname = context.Request.Params["bname"];
                string bmodel = context.Request.Params["bmodel"];
                string bcount = context.Request.Params["bcount"];
                string bprice = context.Request.Params["bprice"];
                string breason = context.Request.Params["breason"];
                string pestimate = context.Request.Params["pestimate"];

                Purchase_BillEntity model = new Purchase_BillEntity();
                model.BID = 0;
                model.PID = pid;
                model.BName = bname;
                model.BModel = bmodel;
                model.BCount = int.Parse(bcount);
                model.BPrice = decimal.Parse(bprice);
                model.BReason = breason;
                model.CreateDate = DateTime.Now;
                decimal allprice = 0.0M;
                DataTable dt = purchase_BillDAL.GetByPID(pid);
                if (dt != null && dt.Rows.Count > 0)
                {
                    
                    //计算已添加清单费用
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        allprice += Convert.ToDecimal(dt.Rows[i]["BPrice"].ToString()) * Convert.ToInt32(dt.Rows[i]["BCount"].ToString());
                    }
                }
                    //增加当前要添加清单费用
                    allprice = allprice + Convert.ToDecimal(bprice) * Convert.ToInt32(bcount);
                    //PurchaseEntity pmodel = purchaseDAL.GetObjByID(pid);
                    //if (pmodel != null)
                    //{
                    //if (pmodel.PEstimate < allprice)
                    if (Convert.ToDecimal(pestimate) < allprice)
                    {
                        sb.Append("{\"result\":\"moreprice\"}");
                        context.Response.Clear();
                        context.Response.Write(sb.ToString());
                        context.Response.End();
                    }
                    //}
                

                int result = purchase_BillDAL.Edit(model);
                if (result == 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, "添加采购内容为【" + bname + "】的信息", userid));
                    sb.Append("{\"result\":\"sucess\"}");
                }
                else if (result == -2)
                {
                    sb.Append("{\"result\":\"repeat\"}");
                }
                else
                {
                    sb.Append("{\"result\":\"fail\"}");
                }
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, userid));
                sb.Append("{\"result\":\"fail\"}");
            }
            context.Response.Clear();
            context.Response.Write(sb.ToString());
            context.Response.End();
        }
        public void AuditUser(HttpContext context)
        {
            StringBuilder sb = new StringBuilder();
            string userid = CommonFunction.Decrypt(context.Request.Params["UserID"]);
            try
            {
                string pid = context.Request.Params["pid"] == "" ? "0" : context.Request.Params["pid"];
                // string AuditOrder = context.Request.Params["AuditOrder"];
                // string AuditResult = context.Request.Params["AuditResult"];
                //  string bcount = context.Request.Params["bcount"];
                //   string AuditMark = context.Request.Params["AuditMark"];
                string auser = context.Request.Params["uid"];
                //  string IsDisplay = context.Request.Params["IsDisplay"];

                Purchase_AuditEntity model = new Purchase_AuditEntity();
                // model.PAID = 0;
                model.PID = pid;
                model.AuditUser = auser;
                // model.AuditDate = DateTime.Now;
                // model.AuditMark = "";
                model.AuditResult = (int)CommonEnum.AduitState.未审核;
                //  model.AuditOrder = int.Parse(AuditOrder);
                // model.IsDisplay = int.Parse(IsDisplay);
                int result = purchase_AuditDAL.AuditEdit(model);
                if (result == 0)
                {
                    // string log= (int.Parse(pid) == 0 ? "添加" : "修改") + "选课课程【" + bname + "】的信息";
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, "添加采购审核人信息", userid));
                    sb.Append("{\"result\":\"sucess\"}");
                }
                else if (result == -2)
                {
                    sb.Append("{\"result\":\"repeat\"}");
                }
                else
                {
                    sb.Append("{\"result\":\"fail\"}");
                }
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, userid));
                sb.Append("{\"result\":\"fail\"}");
            }
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