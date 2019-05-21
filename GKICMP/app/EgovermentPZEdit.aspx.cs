using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using System.Data;
using GK.GKICMP.Entities;
using System.Text;
using System.Net;
using System.IO;

namespace GKICMP.app
{
    public partial class EgovermentPZEdit : PageBaseApp
    {
        public Egovernment_FlowDAL egovernment_FlowDAL = new Egovernment_FlowDAL();
        public EgovernmentDAL egovernmentDAL = new EgovernmentDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        SysUserDAL sysuserDAL = new SysUserDAL();


        #region 参数集合
        public string FID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        public string Title
        {
            get
            {
                return GetQueryString<string>("title", "");
            }
        }
        #endregion


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindInfo();
                DataBindList();
            }
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
            DataTable dt = sysuserDAL.GetSysUserByDepid((int)CommonEnum.UserType.老师, Convert.ToInt32(hf_DID.Value));
            if (dt != null && dt.Rows.Count > 0)
            {
                rpnextModule.DataSource = dt;
                rpnextModule.DataBind();
            }
        }

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
            }
        }

        public void BindRepeter()
        {
            DataTable dt = egovernment_FlowDAL.GetFlowAPP(FID);
            this.rp_List.DataSource = dt;
            rp_List.DataBind();

        }
        #endregion


        #region 提交
        protected void btn_Sumbit_Click(object sender, EventArgs e)
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
            model_flow.AcceptDate = DateTime.Now;//接收时间      
            model_flow.State = (int)CommonEnum.GWType.已处理;//
            int egstate = (int)CommonEnum.GWType.批转中;
            if (ids == "")
            {
                ShowMessage("请选择收件人");
                return;
            }
            int result = egovernment_FlowDAL.Edit(model_flow, egstate);
            if (result > 0)
            {
                string message = "";
                WeiXinInfoEntity model1 = XMLHelper.Get("~/QYWX.xml", "Main", 1);
                if (model1.IsOpen == 1)
                {
                    message += WXSendMsg(model1.Agent) + ",";
                    //Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('" + message + "');window.location='EgovernmentIntends.aspx';", true);
                    //sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, (FID == "" ? "提交" : "修改") + "公文为：" + this.txt_ETitle.Text + "的信息", UserID));
                }
                Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('提交成功。" + message.TrimEnd(',') + "');window.location='AlreadyEgovernmentManage.aspx';", true);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "批转公文为：" + Title + "的信息", UserID));
            }
            else
            {
                ShowMessage("保存失败");
                return;
            }
        }
        #endregion


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
                DataTable dt = sysuserDAL.GetToUser(this.hf_UID.Value.ToString().TrimEnd(','));
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