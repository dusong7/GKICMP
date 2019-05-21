/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      LFZ
** 创建日期:    2017年01月03日
** 描 述:       已发政务页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Web.UI.WebControls;
using System.Text;

namespace GKICMP.oamanage
{
    public partial class AllEgovernment : PageBase
    {
        Egovernment_FlowDAL egovernment_FlowDAL = new Egovernment_FlowDAL();
        SysLogDAL sysLogDAL = new SysLogDAL();

        #region 页面加载
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindWhere();
                BindInfo();
            }
        }
        #endregion

        #region 查询条件
        public void BindWhere()
        {
            ViewState["ETitle"] = this.txt_ETitle.Text;
            ViewState["Begin"] = this.txt_Begin.Text == "" ? "1900-01-01" : this.txt_Begin.Text;
            ViewState["End"] = this.txt_End.Text == "" ? "9999-12-31" : this.txt_End.Text;
        }
        #endregion

        #region 数据绑定
        public void BindInfo()
        {
            int recordCount = -1;
            EgovernmentEntity model = new EgovernmentEntity();
            model.Etitle = ViewState["ETitle"].ToString();
            model.Begin = Convert.ToDateTime(ViewState["Begin"]);
            model.End = Convert.ToDateTime(ViewState["End"]);
            model.CreateUser = UserID;
            //DataTable dt = egovernment_FlowDAL.GetSendPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
            DataTable dt = egovernment_FlowDAL.GetALLPaged(Pager.PageSize, Pager.CurrentPageIndex, ref recordCount, model);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.tr_null.Visible = false;
            }
            else
            {
                this.tr_null.Visible = true;
            }
            this.rp_List.DataSource = dt;
            Pager.RecordCount = recordCount;
            rp_List.DataBind();
            this.hf_CheckIDS.Value = "";
        }
        #endregion

        #region 分页事件
        /// <summary>
        /// 分页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Pager_PageChanged(object sender, EventArgs e)
        {
            BindInfo();
        }
        #endregion

        #region 查询事件
        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            Pager.CurrentPageIndex = 1;
            BindWhere();
            BindInfo();
        }
        #endregion


        #region 政务状态
        public string getState(object state)
        {
            string value = "";
            if (state.ToString() == "0")
            {
                value = "<span style='color:red'>未处理</span>";
            }
            else if (state.ToString() == "1")
            {
                value = "<span style='color:blue'>批转中</span>";
            }
            else if (state.ToString() == "2")
            {
                value = "已处理";
            }
            else if (state.ToString() == "5")
            {
                value = "<span style='color:#48bd81'>已阅</span>";
            }
            else
            {
                value = "";
            }
            return value;
        }
        #endregion


        public string getVaule(object state)
        {
            string result = "true";
            if ((int)state == 0)
            {

            }
            else
            {
                result = "false";
            }
            return result;
        }

        public string GetAcceptName(object count, object name)
        {
            int counts = count == null ? 0 : Convert.ToInt32(count);
            if (counts < 2)
            {
                return name.ToString();
            }
            else
            {
                return name.ToString().Split(',')[0] + "等" + count.ToString() + "人";
            }

        }

        


        #region 操作事件
        protected void lbtn_Detail_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            string id = lbtn.CommandArgument.ToString();
            string name = lbtn.CommandName.ToString();
            if (name == "XQ")
            {
                //aa = string.Format("<script language=javascript>window.open('Auditing.aspx?Type=1&ID={0}', '_self')</script>", id);
                Response.Write("<script language=javascript>window.open('AllEgovernmentDetail.aspx?flag=1&ID=" + id + "', '_self')</script>");
            }
            
        }
        #endregion



        #region 导出Excel事件
        /// <summary>
        /// 导出事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_AllOut_Click(object sender, EventArgs e)
        {
            int recordCount = -1;
            StringBuilder str = new StringBuilder();
            EgovernmentEntity model = new EgovernmentEntity();
            model.Etitle = ViewState["ETitle"].ToString();
            model.Begin = Convert.ToDateTime(ViewState["Begin"]);
            model.End = Convert.ToDateTime(ViewState["End"]);
            model.CreateUser = UserID;

            DataTable dt = egovernment_FlowDAL.GetALLPaged(2000, 1, ref recordCount, model);


            str.Append(@"<table border='1' cellpadding='0' cellspacing='0' >
                                     <tr>
                                        <th><strong>日期</strong></th>
                                        <th><strong>公文标题</strong></th>

                                            <th><strong>来源</strong></th>
                                            <th><strong>部门</strong></th>
                
                                        <th><strong>领导审批(收件人)</strong></th>
                                        <th><strong>信息接收人(发件人)</strong></th>

                                        <th><strong>是否已读</strong></th>
                                        <th><strong>状态</strong></th>
                                     </tr>");
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    str.Append("<tr>");
                    str.AppendFormat("<td>{0}</td>", row["CreateDate"].ToString() == "" ? "" : Convert.ToDateTime(row["CreateDate"]).ToString("yyyy-MM-dd HH:mm"));
                    str.AppendFormat("<td>{0}</td>", row["ETitle"]);

                    str.AppendFormat("<td>{0}</td>", "镜湖教育信息网");
                    str.AppendFormat("<td>{0}</td>", row["EDepartment"]);


                    
                    str.AppendFormat("<td>{0}</td>", row["AcceptUserList"]);
                    str.AppendFormat("<td>{0}</td>", row["CreateUserName"]);
                    str.AppendFormat("<td>{0}</td>", row["ReadOrNot"].ToString() == "" ? "有人未读" : "全部已读");
                    str.AppendFormat("<td>{0}</td>", row["Completed"].ToString() == "1" ? "已归档" : row["state"].ToString() == "0" ? "未处理" : row["state"].ToString() == "1" ? "批转中" : row["state"].ToString() == "2" ? "已处理" : row["state"].ToString() == "5" ? "已阅" : "");

                    str.Append("</tr>");
                }
            }
            CommonFunction.ExportExcel("政务导出", str.ToString());


        }
        #endregion


    }
}