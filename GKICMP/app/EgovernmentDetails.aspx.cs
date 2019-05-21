using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Data;
using System.Text;

namespace GKICMP.app
{
    public partial class EgovernmentDetails : PageBaseApp
    {
        public Egovernment_FlowDAL egovernment_FlowDAL = new Egovernment_FlowDAL();
        public EgovernmentDAL egovernmentDAL = new EgovernmentDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
       

        #region 参数集合
        /// <summary>
        /// BID 宿舍楼ID
        /// </summary>
        public string FID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
         public int Flag
        {
            get
            {
                return GetQueryString<int>("flag", 0);
            }
        }
        
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //this.pz.Visible = false;
                if (!string.IsNullOrEmpty(FID))
                {
                    IsRead();
                    BindInfo();
                    DataBindList();//绑定收件人
                   
                }
            }
        }

        #region 是否阅读
        public void IsRead()
        {
            int result = egovernment_FlowDAL.IsReadAPP(FID, UserID);
        }
        #endregion


        #region 绑定数据
        private void BindInfo()
        {
            DataTable dt = egovernmentDAL.GetTableAPP(FID);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.lbl_ETitle.Text = this.lbl_ETitle.Text = dt.Rows[0]["Etitle"].ToString();//公文标题
                //this.lbl_AcceptUser.Text = dt.Rows[0]["SendUserName"].ToString(); //发件人
                this.lbl_SendDate.Text = Convert.ToDateTime(dt.Rows[0]["SendDate"].ToString()).ToString("yyyy-MM-dd HH:mm");//日期
                this.lbl_EContent.Text = dt.Rows[0]["EContent"].ToString();//内容

                if (dt.Rows[0]["IsApproved"].ToString() == "1")
                {
                    BindRepeter();
                }
                else
                {
                    //
                }

                #region 按钮是否显示
                //已阅按钮(已阅过或归档不显示)
                if (dt.Rows[0]["State"].ToString() == "5" ||dt.Rows[0]["Completed"].ToString()=="1")
                {
                    this.btn_YY.Visible = false;
                   
                }
                else
                {
                    this.btn_YY.Visible = true;
                }

                //批转按钮(不是批转公文或者归档不显示)
                if (dt.Rows[0]["IsApproved"].ToString() == "0" || dt.Rows[0]["Completed"].ToString()=="1")
                {
                    this.btn_CY.Visible = false;
                }
                else
                {
                    this.btn_CY.Visible = true;
                }

                //已归档政务隐藏已阅，批转按钮
                //if (dt.Rows[0]["Completed"].ToString() == "1")
                //{
                //    this.btn_CY.Visible = false;
                //    this.btn_YY.Visible = false;
                //}
                //else
                //{

                //}

                if (Flag == 1)
                { this.btn_YY.Visible = false; }
                #endregion

            }
        }

        public void BindRepeter()
        {
            DataTable dt = egovernment_FlowDAL.GetFlowAPP(FID);
            this.rp_List.DataSource = dt;
            rp_List.DataBind();

        }
        
        #endregion

        #region 批转后提交
        protected void btn_Send_Click(object sender, EventArgs e)
        {
            string ids = this.hf_UID.Value.ToString();
            ids = ids.TrimEnd(',').TrimStart(',');
            Egovernment_FlowEntity model = egovernment_FlowDAL.GetObjByID(FID);
            Egovernment_FlowEntity model_flow = new Egovernment_FlowEntity();
            model_flow.EID = model.EID;
            model_flow.FID = FID;
            model_flow.Comment = this.hf_SelectedText.Value;//批注
            model_flow.SendUser = UserID;//发件人
            model_flow.AcceptUser = ids;//接受人
            model_flow.FOpinion = "";//处理意见
            model_flow.SendDate = DateTime.Now;//发送时间
            model_flow.State = (int)CommonEnum.GWType.已处理;//
            int egstate = (int)CommonEnum.GWType.批转中;
            if (ids == "")
            {
                ShowMessage("请选择收件人");
                return;
            }
            model_flow.AcceptDate = DateTime.Now;//接收时间  

            //int result = egovernment_FlowDAL.EditAPP(model_flow, egstate);
            int result = egovernment_FlowDAL.Edit(model_flow, egstate);
            if (result > 0)
            {
                string message = "";
                WeiXinInfoEntity model1 = XMLHelper.Get("~/QYWX.xml", "Main", 1);
                if (model1.IsOpen == 1)
                {
                    message += WXSendMsg(model1.Agent) + ",";
                }
                Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('提交成功。" + message.TrimEnd(',') + "');window.location='AlreadyEgovernmentManage.aspx';", true);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "批转公文为：" + Title + "的信息", UserID));
                //sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "批转公文：" + this.lbl_ETitle.Text + "的信息", UserID));
                //RegisterStartupScript("false", "<script>alert('提交成功');window.location.href='EgovernmentList.aspx'</script>");
            }
            else
            {
                ShowMessage("保存失败");
                return;
            }
        }
        #endregion

        #region 点击批转按钮显示页面
        protected void btn_CY_Click(object sender, EventArgs e)
        {
            if (this.pz.Visible)
            {
                this.pz.Visible = false;
            }
            else
            {
                this.pz.Visible = true;
                //BandData(2); 
                // Data(2); 
                DataBindList();
            }
        }

         #endregion

        #region 已阅
        protected void btn_YY_Click(object sender, EventArgs e)
        {
            //Visible='<%#Eval("state").ToString()=="5"? false: true%>'
            IsRead();//是否阅读

            int result = egovernment_FlowDAL.Read(FID);
            if (result > 0)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "对公文" + this.lbl_ETitle.Text + "进行已阅操作", UserID));
                RegisterStartupScript("false", "<script>alert('已阅成功');window.location.href='EgovernmentList.aspx'</script>");

                //this.btn_YY.Visible = false;
            }
            else
            {
                ShowMessage("提交失败");
            }
        
        }
        
        #endregion


        #region 选择收件人绑定
        private void BandData(int type)
        {
            StringBuilder sb = new StringBuilder("");
            string a = MList();
            sb.Append("<script type='text/javascript'>");
            sb.Append(" $(function () {");
            sb.Append(" $('#Series').combotree({");
            sb.Append(" data: [ ");
            sb.Append(a);
            sb.Append("],");
            if (type == 1)
                sb.Append("multiple: false,");
            else
                sb.Append("multiple: true,");
            sb.Append("lines: true,");
            sb.Append("});");
            sb.Append(" }); </script>");

            this.ltl_JQ.Text = sb.ToString();
        }

        //绑定部门
        private string MList()
        {
            DataTable dt;
            dt = new DepartmentDAL().GetList((int)CommonEnum.Deleted.未删除, (int)CommonEnum.DepType.职能部门);
            string name = string.Empty;
            if (dt == null)
            {
                name = "[]";
            }
            StringBuilder sb = new StringBuilder();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string a = InitChild((int)CommonEnum.UserType.老师, dt.Rows[i]["DID"].ToString());
                    if (a == "")
                    { }
                    else
                    {
                        name += "{\"id\":\"" + dt.Rows[i]["DID"].ToString() +
                           "\",\"text\":\"" + dt.Rows[i]["DepName"].ToString() + "\",";
                        //调用递归方法
                        name += a;

                        name += ",state:\"closed\"},";
                    }
                }
            }
            sb.Append(name.ToString().TrimEnd(','));
            return sb.ToString();
        }

        //绑定部门下的人员
        public string InitChild(int usertype, string parentID)
        {
            DataTable dt = new SysUserDAL().GetSysUserByDepid(usertype, int.Parse(parentID));
            StringBuilder sb = new StringBuilder();
            string name = "";
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
                return "";
            }
            sb.Append("\"children\":[");
            sb.Append(name.ToString().TrimEnd(','));
            sb.Append("]");
            return sb.ToString();
        }

        #endregion


        #region 选择收件人绑定
        public void DataBindList()
        {
            DataTable dt;
            dt = new DepartmentDAL().GetList((int)CommonEnum.Deleted.未删除, (int)CommonEnum.DepType.职能部门);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.rpmodule.DataSource = dt;
                this.rpmodule.DataBind();
            }
        }
        #endregion

        protected void rpmodule_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Repeater rpnextModule = (Repeater)e.Item.FindControl("rpnextModule");
            HiddenField hf_DID = (HiddenField)e.Item.FindControl("hf_DID");
            DataTable dt = sysUserDAL.GetSysUserByDepid((int)CommonEnum.UserType.老师, Convert.ToInt32(hf_DID.Value));
            if (dt != null && dt.Rows.Count > 0)
            {
                rpnextModule.DataSource = dt;
                rpnextModule.DataBind();
            }
        }


        #region 发送企业微信消息
        /// <summary>
        /// 发送企业微信消息
        /// </summary>
        /// <returns>返回结果</returns>
        private string WXSendMsg(string agent)
        {
            string token = WeixinQYAPI.GetToken(1, "Main");
            if (token != "")
            {
                //string AgentID = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "WX//AgentID");
                string AgentID = agent;
                DataTable dt = sysUserDAL.GetToUser(this.hf_UID.Value.ToString().TrimEnd(','));
                string msg = WeixinQYAPI.SendMessage(token, dt.Rows[0]["ToUser"].ToString(), AgentID, "政务提醒：您收到一份标题为【" + Title + "】的政务，请及时查看。");
                if (msg == "ok")
                {
                    // sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, "增加公文为：" + this.txt_ETitle.Text + "的信息", UserID));
                    return "微信提醒成功";
                }
                else
                {
                    //sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "公文为：" + this.txt_ETitle.Text + "的信息", UserID));
                    //sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, msg, UserID));
                    return "但微信消息发送失败";
                }
            }
            else
            {
                //sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, FID == "" ? "增加" : "修改" + "【" + this.txt_ETitle.Text + "】的用户", UserID));
                return "但微信凭证调用失败";
            }

        }
        #endregion


    }
}