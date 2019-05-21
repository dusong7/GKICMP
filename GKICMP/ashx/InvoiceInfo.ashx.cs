using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;


namespace GKICMP.ashx
{
    /// <summary>
    /// InvoiceInfo 的摘要说明
    /// </summary>
    public class InvoiceInfo : IHttpHandler
    {
        public Invoice_InfoDAL infoDAL = new Invoice_InfoDAL();
        private StringBuilder sb = new StringBuilder("");
        public void ProcessRequest(HttpContext context)
        {
            string method = context.Request.Params["method"];
            switch (method)
            {
                case "Add":
                    AddInvoiceInfo(context);
                    break;
            }
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="context"></param>
        private void AddInvoiceInfo(HttpContext context)
        {
            string iid = context.Request.Params["iid"];
            int inum = Convert.ToInt32(context.Request.Params["inum"].ToString());
            string invdesc = context.Request.Params["invdesc"];
            int invoicecount = Convert.ToInt32(context.Request.Params["invoicecount"].ToString());
            decimal invoicecash = Convert.ToDecimal(context.Request.Params["invoicecash"].ToString());
            Invoice_InfoEntity model = new Invoice_InfoEntity();
            //model.InfoID = -1;
            model.IID = HttpUtility.UrlDecode(iid, Encoding.GetEncoding("utf-8"));
            model.INum = inum;
            model.InvDesc = HttpUtility.UrlDecode(invdesc, Encoding.GetEncoding("utf-8"));
            model.InvoiceCount = invoicecount;
            model.InvoiceCash = invoicecash;
            model.Isdel = (int)CommonEnum.Deleted.未删除;
            int result = infoDAL.Edit(model);

            if (result > 0)
            {
                sb.Append("{\"result\":\"success\"}");
            }
            else
            {
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