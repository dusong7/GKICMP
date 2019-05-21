/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      LFZ
** 创建日期:    2017年01月03日
** 描 述:       政务详情页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
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

namespace GKICMP.oamanage
{
    public partial class EgovernmentDetail : PageBase
    {
        Egovernment_FlowDAL egovernment_FlowDAL = new Egovernment_FlowDAL();
        EgovernmentDAL egovernmentDAL = new EgovernmentDAL();
        SysLogDAL sysLogDAL = new SysLogDAL();
        DepartmentDAL departmentDAL = new DepartmentDAL();
        SysUserDAL sysuserDAL = new SysUserDAL();
        public int i = 0;

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
                return GetQueryString<int>("flag", -1);
            }
        }
        public int type
        {
            get
            {
                return GetQueryString<int>("type", -1);
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(FID))
                {
                    if (Flag == 1)
                    {
                        //this.egovernment.Visible = false;
                        this.egovernmentPZ.Visible = false;
                        this.yy.Visible = false;

                    }
                    else if (Flag == 2)
                    {
                        this.RBack.Visible = false;
                        this.egovernmentPZ.Visible = false;
                    }
                    else
                    {
                        this.RBack.Visible = false;
                        this.yy.Visible = false;
                    }
                    try
                    {
                       // BandData();
                        IsRead();
                        BindInfo();

                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }
        #region 人员绑定
        private void BandData()
        {
            StringBuilder sb = new StringBuilder("");
            string a = MList();
            sb.Append("<script type='text/javascript'>");
            sb.Append(" $(function () {");
            sb.Append(" $('#Series').combotree({");
            sb.Append(" data: [ ");
            sb.Append(a);
            sb.Append("],");
            sb.Append("multiple: true,");
            sb.Append("lines: true,");
            sb.Append("});");
            sb.Append(" }); </script>");
            this.ltl_JQ.Text = sb.ToString();
        }
        private string MList()
        {

            //StringBuilder sb = new StringBuilder();
            //sb.Append("{\"result\":\"true\"}");
            DataTable dt;
            //System.Text.StringBuilder sb = new System.Text.StringBuilder();
            //数据库设计名称、id、父类id 初始化先获取父类id=0的数据集，返回数据是DataTable类型          
            //dt = .GetList("  Mtype=102 and ParentID=0 ").Tables[0];
            dt = departmentDAL.GetAllDeparInfo();
            string name = string.Empty;
            if (dt == null)
            {
                name = "[]";
            }
            StringBuilder sb = new StringBuilder();
            //builder.Append("{\"result\":\"true\",\"data\":[");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //builder.Append("{");
                    //builder.Append("\"id\":" + new JavaScriptSerializer().Serialize(dt.Rows[i]["DepID"].ToString()));
                    //builder.Append(",");
                    //builder.Append("\"text\":" + new JavaScriptSerializer().Serialize(dt.Rows[i]["DepName"].ToString()));
                    //builder.Append(",");
                    name += "{\"id\":\"" + dt.Rows[i]["DID"].ToString() +
                       "\",\"text\":\"" + dt.Rows[i]["DepName"].ToString() + "\",";
                    //调用递归方法
                    name += InitChild(dt.Rows[i]["DID"].ToString());
                    name += "},";
                    //builder.Append("}");
                    //if (i < (dt.Rows.Count - 1))
                    //{
                    //    builder.Append(",");
                    //}
                }
            }
            //builder.Append("],}");

            sb.Append(name.ToString().TrimEnd(','));

            //sbs.Append();
            // sbs = builder.ToString();
            //context.Response.Clear();
            return sb.ToString();
            //context.Response.End();
            //response.Write(sbs);   
        }
        public string InitChild(string parentID)
        {
            DataTable dt = sysuserDAL.GetTeacherByDepID(int.Parse(parentID));
            StringBuilder sb = new StringBuilder();
            string name = "";
            if (dt == null)
            {
                //
            }

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    // builder.Append("{");

                    // builder.Append("\"id\":" + new JavaScriptSerializer().Serialize(dt.Rows[i]["SysID"].ToString()));
                    // builder.Append(",");
                    // builder.Append("\"text\":" + new JavaScriptSerializer().Serialize(dt.Rows[i]["RealName"].ToString()));
                    //// builder.Append(",");
                    // builder = InitChild(builder, dt.Rows[i]["ClassifyID"].ToString());
                    //builder.Append("}");

                    name += "{\"id\":\"" + dt.Rows[i]["UID"].ToString() +
                       "\",\"text\":\"" + dt.Rows[i]["RealName"].ToString() + "\"},";
                    //if (i < (dt.Rows.Count - 1))
                    //{
                    //    builder.Append(",");
                    //}
                }
            }
            sb.Append("\"children\":[");
            sb.Append(name.ToString().TrimEnd(','));
            sb.Append("]");
            return sb.ToString();
        }
        #endregion

        #region 是否阅读
        public void IsRead()
        {
            int result = egovernment_FlowDAL.IsRead(FID,UserID);
        }
        #endregion


        #region 绑定数据
        private void BindInfo()
        {
            DataTable dt = egovernmentDAL.GetTable(FID);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.lbl_ETitle.Text = this.lbl_Etitle1.Text = dt.Rows[0]["GWBT"].ToString();//公文标题
                this.lbl_CreateUserName.Text = dt.Rows[0]["fjr"].ToString(); //发件人
                this.lbl_CreateDate.Text = Convert.ToDateTime(dt.Rows[0]["rq"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");//日期
                this.lbl_Comment.Text = dt.Rows[0]["nr"].ToString();//内容
                this.lbl_IsRead.Text = dt.Rows[0]["yd"].ToString().Trim(',');//已读
                this.lbl_NotRead.Text = dt.Rows[0]["wd"].ToString().Trim(',');//未读
                this.lbl_EType.Text = dt.Rows[0]["gwlx"].ToString();//公文类型
                this.lbl_Ecode.Text = dt.Rows[0]["gdbh"].ToString();//归档编号
                this.lbl_EDepartment.Text = dt.Rows[0]["lwdw"].ToString();//来文单位
                this.lbl_CreateDate1.Text = Convert.ToDateTime(dt.Rows[0]["swsj"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");//收文时间
                this.lbl_EtitleType.Text = dt.Rows[0]["wh"].ToString();//文号
                //this.lbl_EState.Text = dt.Rows[0]["gwzt"].ToString(); //公文状态
                //this.lbl_EState.Text = "批转"; //公文状态
                this.lbl_EState.Text = dt.Rows[0]["WC"].ToString() == "1" ? "归档" : dt.Rows[0]["GWZT"].ToString() == "0" ? "未处理" : dt.Rows[0]["GWZT"].ToString() == "1" ? "批转中" : dt.Rows[0]["GWZT"].ToString() == "0" ? "已处理" : ""; //公文状态
                this.lbl_ETitleName.Text = dt.Rows[0]["GWBT"].ToString();//公文标题
                if (dt.Rows[0]["PZ"].ToString() == "1")
                {
                    BindRepeter();
                }
                else if (dt.Rows[0]["PZ"].ToString() == "1" && dt.Rows[0]["gwzt"].ToString() == CommonEnum.GWType.归档.ToString())
                {
                    this.egovernmentPZ.Visible = false;
                }
                else
                {
                    this.egovernment.Visible = false;  //隐藏政务处理标签
                    this.egovernmentPZ.Visible = false; //隐藏批转政务
                }
            }
        }

        public void BindRepeter()
        {
            DataTable dt = egovernment_FlowDAL.GetFlow(FID);
            this.rp_List.DataSource = dt;
            rp_List.DataBind();

        }
        #endregion

        #region 批转
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {

            //string[] id = ids.Split(',');
            //int result=0;
            //for (int i = 0; i < id.Length; i++)
            //{

            string ids = this.hf_SelectedValue.Value.ToString();
            ids = ids.TrimEnd(',').TrimStart(',');
            Egovernment_FlowEntity model = egovernment_FlowDAL.GetObjByID(FID);
            Egovernment_FlowEntity model_flow = new Egovernment_FlowEntity();
            // model_flow.FID = Guid.NewGuid().ToString();//流程ID
            //if (model != null)
            //{
            //    model_flow.EID = model.EID;//公文ID

            //    if (model_flow.SendUser == model.AcceptUser)
            //        model_flow.IsRead = 1;//是否已读
            //    else
            //        model_flow.IsRead = 0;
            //}
            //else
            //{
            //    model_flow.EID = "";
            //}
            model_flow.EID = model.EID;
            model_flow.FID = FID;
            model_flow.Comment = this.txt_Comment.Text;//批注
            model_flow.SendUser = UserID;//发件人
            model_flow.AcceptUser = ids;//接受人
            model_flow.FOpinion = "";//处理意见
            model_flow.SendDate = DateTime.Now;//发送时间
            model_flow.AcceptDate = DateTime.Now;//接收时间

            //if (model_flow.SendUser == model.AcceptUser)
            //    model_flow.IsRead = 1;//是否已读
            //else
            //    model_flow.IsRead = 0;

            if (this.cb_SendMessage.Checked)
                model_flow.IsSendMess = 1;//
            else
                model_flow.IsSendMess = 0;

            model_flow.State = (int)CommonEnum.GWType.已处理;//
            int egstate=(int)CommonEnum.GWType.批转中;
            int result = egovernment_FlowDAL.Edit(model_flow,egstate);
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
                //发送短信通知
                else if (model1.IsOpen == 0)
                {
                    string isopen = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "DX/IsOpen");
                    if (isopen == "1")
                    {
                        if (this.cb_SendMessage.Checked)
                        {
                            DataTable dt = new SysUserDAL().GetPhone(model_flow.AcceptUser);
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                string phone = "";
                                foreach (DataRow dr in dt.Rows)
                                {
                                    if (dr[0].ToString() != "")
                                        phone += dr[0] + ",";
                                }
                                if (phone.TrimEnd(',') != "")
                                {
                                    message += SendMsg("", phone.TrimEnd(',')) + ",";
                                }
                            }
                        }
                    }
                }
                if (type == 1)
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('提交成功。" + message.TrimEnd(',') + "');window.location='EgovernmentBeSend.aspx';", true);
                else
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('提交成功。" + message.TrimEnd(',') + "');window.location='EgovernmentTR.aspx';", true);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "批转公文为：" + this.lbl_ETitle.Text + "的信息", UserID));
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
                DataTable dt = sysuserDAL.GetToUser(this.hf_SelectedValue.Value.TrimEnd(','));
                string msg = WeixinQYAPI.SendMessage(token, dt.Rows[0]["ToUser"].ToString(), AgentID, "政务提醒：您收到一份标题为【" + this.lbl_ETitle.Text + "】的政务，请及时查看。");
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

        #region 发送短信通知
        public string SendMsg(string content, string touser)
        {
            MessageConfigEntity msmodel = new MessageConfigDAL().GetObjByID("政务通知");
            return ALiDaYu.SendMessage(msmodel, content, touser);
        }
        #endregion

        #region 已阅
        protected void btn_Read_Click(object sender, EventArgs e)
        {
            //Egovernment_FlowEntity modeleid = egovernment_FlowDAL.GetObjByID(EID);
            //Egovernment_FlowEntity model = new Egovernment_FlowEntity();
            //model.FID = EID;
            //model.EID = modeleid.EID;
            //model.SendUser = UserID;
            ////model.AcceptUser = this.ddl_AcceptUser.SelectedValue;
            //model.Comment = "已阅";
            //model.State = (int)CommonEnum.Estate.已阅;
            //model.SendDate = DateTime.Now;
            //model.IsRead = (int)CommonEnum.IsorNot.是;
            //int newstate = (int)CommonEnum.Estate.已阅;
            int result = egovernment_FlowDAL.Read(FID);
            //model.FID = FID;
            //model.SendUser = UserID;
            //model.Comment = this.txt_Comment.Text;
            //model.State = (int)CommonEnum.Estate.通过;
            //int result = Egovernment_FlowBLL.UpdateEG(model);
            if (result > 0)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "对公文:" + this.lbl_ETitle.Text + "进行已阅操作", UserID));
                Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('提交成功');window.location='EgovernmentTR.aspx';", true);
               // ShowMessage("已阅");
                //this.btn_PZ.Visible = false;
                //string aa = string.Format("<script language=javascript>window.open('Egovernment.aspx', '_self')</script>");
                //Response.Write(aa);
            }
            else
            {
                ShowMessage("提交失败");
            }
        }
        #endregion

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    //string name = this.hf_Name.Value;
        //    //string path = this.hf_File.Value;
        //    ////string url = "http://www.mozilla.org/images/feature-back-cnet.png";
        //    ////WebClient myWebClient = new WebClient();
        //    ////myWebClient.DownloadFile(path, name);
        //    //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(path);
        //    //WebResponse response = request.GetResponse();
        //    //Stream stream = response.GetResponseStream();
        //    //byte[] bytes = new byte[stream.Length];
        //    //stream.Read(bytes, 0, bytes.Length);
        //    //// 设置当前流的位置为流的开始
        //    //stream.Seek(0, SeekOrigin.Begin);
        //    //HttpContext.Current.Response.ContentType = "application/octet-stream";
        //    //HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + name);
        //    //HttpContext.Current.Response.BinaryWrite(bytes);
        //    //HttpContext.Current.Response.Flush();
        //    ////HttpContext.Current.Response.End();
        //    //HttpContext.Current.ApplicationInstance.CompleteRequest();
        //    ////if (!response.ContentType.ToLower().StartsWith("text/"))
        //    ////{
        //    ////    //Value = SaveBinaryFile(response, FileName); 
        //    ////    byte[] buffer = new byte[1024];
        //    ////    Stream outStream = System.IO.File.Create(name);
        //    ////    Stream inStream = response.GetResponseStream();

        //    ////    int l;
        //    ////    do
        //    ////    {
        //    ////        l = inStream.Read(buffer, 0, buffer.Length);
        //    ////        if (l > 0)
        //    ////            outStream.Write(buffer, 0, l);
        //    ////    }
        //    ////    while (l > 0);

        //    ////    outStream.Close();
        //    ////    inStream.Close();
        //    ////}
        //}
    }
}