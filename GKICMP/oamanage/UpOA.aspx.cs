
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using GKICMP.localhost1;
using System.Text;
using System.Configuration;

namespace GKICMP.oamanage
{
    public partial class UpOA : PageBase
    {
        public Egovernment_FlowDAL egovernment_FlowDAL = new Egovernment_FlowDAL();
        public EgovernmentDAL egovernmentDAL = new EgovernmentDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public string data = "";
        public string SGUID = ConfigurationManager.AppSettings["SGUID"];
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                localhost1.WebService1 service = new localhost1.WebService1();
                service.Url = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "ServerUrl") + "/WebService1.asmx";


                if (service.Url != "" && service.HelloWorld() == "You Are Welcome")
                {
                    string json = "";
                    string child = "";
                    Tree[] a = service.GetReceiverList();
                    foreach (Tree t in a)
                    {

                        if (t.children != null)
                        {
                            foreach (Tree c in t.children)
                            {
                                child += "{\"id\":\"" + c.id + "\",\"text\":\"" + c.text + "\"},";
                            }
                            child = "\"children\":[" + child + "]";
                            json += "{\"id\":\"" + t.id + "\",\"text\":\"" + t.text + "\", \"state\":\"closed\"," + child + "},";
                            child = "";
                        }
                        // child += "\"children\":[{\"id\":\""+t.children+"\"}],";


                    }
                    data = json;
                }
                else 
                {
                    ShowMessage("请配置区平台地址");
                    return;
                }
                //BandData(json);
            }
        }
        private void BandData(string  json)
        {
            StringBuilder sb = new StringBuilder("");
            sb.Append("<script type='text/javascript'>");
            sb.Append(" $(function () {");
            sb.Append(" $('#Series').combotree({");
            sb.Append(" data: [ ");
            sb.Append(json);
            sb.Append("],");
            sb.Append("multiple: false,");
            sb.Append("lines: true,");
            sb.Append("});");
            sb.Append(" }); </script>");
            this.ltl_JQ.Text = sb.ToString();
        }
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                localhost1.WebService1 a = new localhost1.WebService1();
                localhost1.OA oa=new localhost1.OA();
                EgovernmentEntity model = new EgovernmentEntity();
                //if (!string.IsNullOrEmpty(FID))
                //{
                //    model.EID = egovernment_FlowDAL.GetObjByID(FID).EID;
                //    i = 1;
                //}
                //else
                //{
                //    model.EID = this.hf_EID.Value;
                //}
                oa.zwid= Guid.NewGuid();
                model.EID= oa.zwid.ToString();
                oa.Title= model.Etitle = this.txt_ETitle.Text;
                model.Ecode = "";
                model.EKey = "";
                model.EDepartment ="";
                model.EtitleType = "";
                if (this.txt_Content.Text == "")
                {
                    ShowMessage("请填写正文");
                    return;
                }
                else
                {
                  oa.Content=  model.EContent = this.txt_Content.Text;
                }
                //model.EContent = Context.Request.Form["myContent"].ToString();
                model.Opened = (int)CommonEnum.IsorNot.否;
                model.Completed = (int)CommonEnum.IsorNot.否;
                model.IsApproved =  0;
                model.Etype = 0;
                model.CreateDate = DateTime.Now;
                model.CreateUser = UserRealName;
               
                model.IsSave = 1;//0保存，1提交
                model.Estate = (int)CommonEnum.GWType.上报;
                model.IsSuperior = (int)CommonEnum.IsorNot.是;


                Egovernment_FlowEntity model_flow = new Egovernment_FlowEntity();
                oa.Operator= model_flow.Comment = "上报至局端";
                if (this.hf_SelectedValue.Value != "")
                { model_flow.AcceptUser = this.hf_SelectedText.Value;
                     oa.ReceiveUser=this.hf_SelectedValue.Value;}
                else { ShowMessage("请选择收件人"); return; }
                oa.IsCompleted=false;
                model_flow.IsSendMess =  0;
                model_flow.State = (int)CommonEnum.GWType.上报;//未处理状态
                model_flow.IsRead = (int)CommonEnum.IsorNot.否;
                if (a.SendOA(new Guid(SGUID), "", 1, oa))
                {
                    int result = egovernmentDAL.Edit(model, model_flow, 0);
                    if (result > 0)
                    {
                        ClientScript.RegisterStartupScript(GetType(), "Message", "<script>alert('提交成功');window.location='EgovernmentIntends.aspx';</script>");
                        sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "上报公文为：" + this.txt_ETitle.Text + "的信息", UserID));
                    }
                    else
                    {
                        ShowMessage("保存失败");
                        return;
                    }
                }
                else 
                {
                    ShowMessage("上报失败");
                    return;
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                return;
            }
        }
    }
}