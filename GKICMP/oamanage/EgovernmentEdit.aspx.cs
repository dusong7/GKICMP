/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年01月03日 09点30分
** 描   述:      部门修改、添加页面
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GKICMP.oamanage
{
    public partial class EgovernmentEdit : PageBase
    {
        Egovernment_FlowDAL egovernment_FlowDAL = new Egovernment_FlowDAL();
        EgovernmentDAL egovernmentDAL = new EgovernmentDAL();
        SysLogDAL sysLogDAL = new SysLogDAL();
        DepartmentDAL departmentDAL = new DepartmentDAL();
        SysUserDAL sysuserDAL = new SysUserDAL();

        public int i = 0;
        #region 参数集合
        /// <summary>
        /// FID 公文流程ID
        /// </summary>
        public string FID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //BandData();
                // this.pz.Visible = false;
                if (!string.IsNullOrEmpty(FID))
                {
                    this.hf_EID.Value = FID;
                    BindInfo();
                    // SetValue();
                    //if (this.ck_IsOrNot.Checked)
                    //    this.pz.Visible = true;
                    //else
                    //    this.pz.Visible = false;
                }
                else
                {
                    this.ck_IsOrNot.Checked = true;
                    this.hf_EID.Value = Guid.NewGuid().ToString();
                }
            }
        }

        private void SetValue()
        {
            // ClientScript.RegisterStartupScript(this.GetType(), "", "<script>disable();</script>");
            StringBuilder sb1 = new StringBuilder();
            sb1.Append("<script type='text/javascript'>");
            sb1.Append("$(function () {$('#Series').combotree('setValues', [");
            sb1.Append(this.hf_SelectedValue.Value.Trim(','));
            sb1.Append("]);");
            sb1.Append("})</script>");
            this.ltl_xz.Text = sb1.ToString();
        }

        private void BindInfo()
        {
            Egovernment_FlowEntity model_flow = egovernment_FlowDAL.GetObjByID(FID);
            this.txt_Comment.Text = model_flow.Comment;
            if (model_flow.IsSendMess == 1)
                this.cb_SendMessage.Checked = true;
            DataTable dt = egovernment_FlowDAL.GetTable(model_flow.EID);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //this.txt_Name.Text += dt.Rows[i]["AcceptUserName"].ToString() + " ";
                this.hf_SelectedValue.Value += dt.Rows[i]["AcceptUser"].ToString() + ",";
            }
            this.hf_SelectedValue.Value = this.hf_SelectedValue.Value.TrimEnd(',');
            EgovernmentEntity model = egovernmentDAL.GetObjByID(model_flow.EID);
            this.txt_ETitle.Text = model.Etitle;
            if (model.IsApproved == 1)
            {
                //this.pz.Visible = true;
                this.ck_IsOrNot.Checked = true;
                this.txt_ECode.Text = model.Ecode.ToString();
                this.txt_Department.Text = model.EDepartment;
                this.txt_EtitleType.Text = model.EtitleType.ToString();
            }
            this.txt_Content.Text = model.EContent;
            //if(model.e)



        }


        #region 带分组人员绑定(保留不使用)
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
            DataTable dt;
            //部门类型为职能部门
            dt = departmentDAL.GetList((int)CommonEnum.Deleted.未删除, -2);
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
                    name += "{\"id\":\"" + dt.Rows[i]["DID"].ToString() +
                       "\",\"text\":\"" + dt.Rows[i]["DepName"].ToString() + "\",";
                    //调用递归方法
                    name += InitChild(dt.Rows[i]["DID"].ToString());
                    name += "},";
                }
            }
            sb.Append(name.ToString().TrimEnd(','));
            return sb.ToString();
        }
        public string InitChild(string parentID)
        {
            DataTable dt = sysuserDAL.GetSysUserByDepid(int.Parse(parentID));
            StringBuilder sb = new StringBuilder();
            string name = "";
            if (dt == null)
            {
            }
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string a = dt.Rows[i]["UID"].ToString();
                    name += "{\"id\":\"" + dt.Rows[i]["UID"].ToString() +
                       "\",\"text\":\"" + dt.Rows[i]["RealName"].ToString() + "\"},";
                }
            }
            sb.Append("\"children\":[");
            sb.Append(name.ToString().TrimEnd(','));
            sb.Append("]");
            return sb.ToString();
        }
        #endregion


        #region 提交
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                EgovernmentEntity model = new EgovernmentEntity();
                if (!string.IsNullOrEmpty(FID))
                {
                    model.EID = egovernment_FlowDAL.GetObjByID(FID).EID;
                    i = 1;
                }
                else
                {
                    model.EID = this.hf_EID.Value;
                }
                model.Etitle = this.txt_ETitle.Text;
                model.Ecode = this.txt_ECode.Text;
                model.EKey = "";
                model.EDepartment = this.txt_Department.Text;
                model.EtitleType = this.txt_EtitleType.Text;
                if (this.txt_Content.Text == "")
                {
                    ShowMessage("请填写正文");
                    return;
                }
                else
                {
                    model.EContent = this.txt_Content.Text;
                }
                //model.EContent = Context.Request.Form["myContent"].ToString();
                model.Opened = (int)CommonEnum.IsorNot.否;
                model.Completed = (int)CommonEnum.IsorNot.否;
                model.IsApproved = this.ck_IsOrNot.Checked ? 1 : 0;
                model.Etype = 0;
                model.CreateDate = DateTime.Now;
                model.CreateUser = UserID;
                model.IsSave = 1;//0保存，1提交
                model.Estate = (int)CommonEnum.GWType.未处理;
                model.IsSuperior = (int)CommonEnum.IsorNot.否;


                Egovernment_FlowEntity model_flow = new Egovernment_FlowEntity();
                model_flow.Comment = this.txt_Comment.Text;
                if (this.hf_SelectedValue.Value != "")
                {
                    #region 文本框列出选择的用户是没有重复的，下拉框显示只勾选的用户，其他部门不显示
                    //List<string> userlist = new List<string>();
                    //foreach (string seluser in this.hf_SelectedValue.Value.Split(','))
                    //{
                    //    string uid = seluser.Split(':')[1];
                    //    if (userlist.FirstOrDefault(t => t == uid) == null)
                    //    {
                    //        userlist.Add(uid);
                    //        model_flow.AcceptUser = model_flow.AcceptUser + uid + ",";
                    //    }

                    //}
                    //if (model_flow.AcceptUser.Length > 0)
                    //{
                    //    model_flow.AcceptUser = model_flow.AcceptUser.Substring(0, model_flow.AcceptUser.Length - 1);
                    //}
                    #endregion

                    #region 文本框列出选择的用户是没有重复的，下拉框其他部门也显示
                        model_flow.AcceptUser = this.hf_SelectedValue.Value;
                       // int length = model_flow.AcceptUser.Split(',').Length;
                    #endregion
                }
                // model_flow.AcceptUser = this.hf_SelectedValue.Value;
                else 
                { 
                    ShowMessage("请选择收件人"); return; 
                }

                model_flow.IsSendMess = this.cb_SendMessage.Checked ? 1 : 0;
                model_flow.State = (int)CommonEnum.GWType.未处理;//未处理状态
                model_flow.IsRead = (int)CommonEnum.IsorNot.否;
                int result = egovernmentDAL.Edit(model, model_flow, i);
                if (result > 0)
                {
                    //string isopen = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "WX//IsOpen");
                    //发送企业微信通知
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
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('提交成功。" + message.Trim(',') + "');window.location='EgovernmentIntends.aspx';", true);
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, (FID == "" ? "提交" : "修改") + "公文为：" + this.txt_ETitle.Text + "的信息", UserID));
                }
                else
                {
                    ShowMessage("提交失败");
                    return;
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, ex.Message, UserID));
                return;
            }

        }

        #region 发送企业微信消息
        /// <summary>
        /// 发送企业微信消息
        /// </summary>
        /// <returns>返回结果</returns>
        private string WXSendMsg(string agent)
        {
            //string token = WeixinQYAPI.GetToken(1, "Main");
            //if (token != "")
            //{
            //    //string AgentID = XMLHelper.GetXmlNodes("~/BaseInfoSet.xml", "WX//AgentID");
            //    string AgentID = agent;
            //    //string aa = "047B1281-362D-4FB6-AC4F-B9D8B14E825C,05674CCF-9E83-4CD5-8FB7-3589D56A2BC5,06973076-30F7-411C-8556-3249BA669228,06B9370C-02A6-426D-8442-529312C04113,092FF719-9DC0-426D-A688-EDA67891223D,0CC58368-70C6-4248-91D3-7A05D94A5A54,0D13CBED-7E64-4E3C-83F3-32578FA2121B,0EC5ED19-B303-44E6-947A-61F3307BEAF4,0F39864B-6A38-40C1-97AD-714A45B61FBD,10dbd168-1caa-4e8b-90ef-512ee9c297ca,121EC297-1E45-4503-AA21-F4517251DB07,12D01C67-00C8-4F89-B353-B006533CF82E,14d338a0-d7a1-4180-8775-a6aa1ec5b1b7,15400DA3-E8F7-4CB8-AABE-B568CAE35951,18FE995F-D422-4FE5-BFF4-24386D8E6D6D,198FD1AA-3D70-44F0-8477-D38702D72F53,2112F2E2-8B9A-4C5B-A2EE-FF32B0FD53E5,2348F6CD-0528-4036-B5C8-B45ECB80D4EA,262221AE-BCBE-47A2-BA63-63BB74192776,27F1CEE2-1C67-4E15-86FE-833C966F9945,29992595-4C55-4630-AE60-A124ADF7315C,2A21DD99-F5DE-4B23-B3D1-377F00797A99,2B7916B1-0E51-4AD7-9A5A-642EE836AF29,30BEEA93-F41E-4770-9A30-0EE60C837D32,32A5F403-5669-4C44-A9EB-60C5B401524C,32B4104B-517F-4BC3-9512-B368ACEF740C,337ED2CF-2ECE-4ABC-8C06-13F8A7966662,33FD1D77-BE06-42CA-9B7C-46B147B5858A,348FE5E0-6199-47B8-BA34-B859A0FB6271,34D2EA87-536A-4DDB-A26E-2E8F0CA5A4C7,35588F3C-0260-4698-8E79-DF7D57E840A2,35C00599-1A51-484A-8E31-8CF80AB97921,36735343-AAB5-4D05-B5C9-CC49B070AAF5,38210DCA-230A-4539-BD6A-FBFCFFF937D1,39A75137-AA73-456A-A84E-43FD04EE837A,3A86EF78-596A-477A-BCDD-1C2CA125A3A8,3B47CA32-02DE-4D34-851C-8BABFAE96ADB,3C0C300A-C40D-4767-801D-0E9000E4A863,3ED403A3-182A-4C7B-BA88-7CECE17C80E7,3FA37417-EF2D-488A-BE2F-EC5BDF9D31A6,42a484e4-585d-45ca-bb06-57204d0fbd72,431FE74C-ECB3-4E63-8481-E8FD0DCAB047,448FD822-FF08-4680-ABFC-6721E8B9F6E1,46672530-21A5-446E-9787-910308DF599F,4714A45F-1DE2-42E1-A090-5649D953DD62,483F52F2-5CF1-46BF-9747-60A40A6B81EA,49522350-ED55-4B63-8987-06C8734E6EFC,4A72733A-B8D3-4C18-961A-34BDD19A871A,4B8F5896-4879-4B84-962E-A8D90079FD6B,4BB2AD3D-0640-4590-A9D3-3DDDBFCD61A0,4CE5B30E-FD3A-48FD-B5D0-DE147B37A5C6,4ED54F47-1B49-4368-A6C9-92012C992E7D,50879F43-98C1-4F28-BA0B-DD3857CC23E7,51BFF189-2051-435D-A349-EA7F45BB48F0,55F70D7F-504F-476D-8E41-7A88B58F7F53,57BC2BF5-37D4-4FE3-BE6F-4B0E53746AA4,5AF4C0C3-80B7-451A-978E-124C204018D1,5dc6b892-bc8d-4b81-8325-24036b2531b3,627F77E5-8B25-4D7D-8FB0-DA98473AA064,634F0792-62A1-44C4-A507-A46D5515ACBB,6a497312-4534-4a19-b394-2563a5d3c91a,6b94632e-6994-40e0-9c5e-2ceb9dec859b,70ea4c4c-69c0-429e-a4b1-61ff62bb1343,720238C5-1710-478F-A980-E0285D20A42F,7BF85369-BC70-477F-A285-B16BFD2C0581,7CCC2DD8-E07C-4EF6-A465-7A79D17E83E2,7d47727f-6115-43d4-9229-fa1ec5a5f807,7DDFD994-1A36-4C72-A5AA-664FC0FE8ED2,7E241DD3-6517-42BA-A3BC-510B905DA2FD,7E6C0F1B-EDD9-4D86-BBB5-160366A33A8B,7E744D03-3496-4080-9498-1BCEACBDA7CD,7E9900A6-D546-4CB9-92B6-D7BB3B24A783,7F3515C6-C902-4723-9393-5AE3BDB49FBA,82A7993A-A5DE-4558-9EC7-55479C8F810E,83006E51-F13B-4998-A77F-7A12EE36B442,84B380A2-1C39-4D90-A219-2E24DF71C103,8C246A0D-59D5-4257-89B7-F86E7942D875,8C2E0675-8C6E-403B-BDA0-07AE0E6D0D44,92D84934-8F3E-4A9C-A60E-B73C69E9BB76,966E5703-1AA8-4369-BDCF-C5382AD36FA2,973B145B-D288-4AFA-988B-B8BB118EB6DB,9775AA83-E3DC-4128-A7D2-CF783A1AA17D,99994A54-FE14-4D9C-8240-4F694888E27A,9A5F0353-83AB-444D-BDB7-3DD62BDAFDF5,9B767A66-27B7-4C6F-96DD-477B79416563,A429C386-D38E-4862-9174-CCC6861280FA,A51FEAFB-2E3B-4036-8C0C-02C044A06E08,A9A966EC-6452-4900-9EC7-7BDBD657171A,ACAC6EAB-5C04-4EB3-92FC-F8AD2E5B83E5,AD8265F4-C81C-49D0-96D2-4003220ABC13,b1c09d29-d048-4824-afa2-60397538bd0c,B44B6635-4CD2-4E75-BD09-8CA205E7ABCA,B98F4B57-55A0-4181-A5CC-94BC9E9E7AF7,BB3DA89E-C182-46BB-BC64-AEBA8F119CED,BCA4CF98-B2F7-4600-B14E-2B4097645BB2,BE493E49-8A9B-43B5-A464-A86EDD79DABC,C1641397-9DCE-4CE2-8DDC-B7300E792047,C228EBFC-DF10-4639-983C-06D2EDF5A209,C4688E1C-D1B9-448B-B7F3-0E1878F9E861,C56F06EE-37EF-4394-91BA-4CCFC2B7129A,C75DCC7F-69E3-488F-A4DB-16DD539EE377,CB41FCE8-914A-4981-809D-4F852DF2C1DB,CE429F14-E5F0-4CF0-A367-181659BA9482,CF139CA9-13C6-480B-B956-0102D9600485,CF4890AB-94BD-4078-8580-246E1C016BA2,CF4B8DCC-983E-4A0C-AB16-FB1E841C0328,CFD868FD-2F3B-49A8-AF50-0B87E8305D07,D0D67072-F358-4F4B-AC5E-2306166FD0F8,d2836440-2f41-4f22-a71b-be1c05e3429e,DB7D7BB4-66A1-4358-A408-5CB4795A5D8C,E3543727-6E50-40BD-9C0B-58414136F94F,E5FA78DC-BDE9-4774-86BE-F574A31F0289,E7837AE1-5FC4-484A-A0D8-39EC02D6EDC2,E7FB332B-228B-40AE-B142-729179EB7B73,E95D4A5F-D086-4A74-B949-EDF72D802CFD,F3F40304-F157-4CA4-98E6-F653DBD460C5,F9655BA6-9ECB-4CDB-A5C3-B6B4DE553B7F,FAB4D75E-E9CC-4705-9AD5-5D44F6696CF1,FB60E7B5-163A-406A-A7CA-BC1077B6DB12,FC499C04-B115-45E2-B3F4-B05ED345306C,FCB4A54C-B006-4B88-BF9C-22940CD7F18F,fdf25551-67e9-4fbd-859b-30615279461d,FDFC87A5-A3BB-499A-8756-19739FA79C17,FE58D057-CE2E-44F3-A372-68D89371326A";
            //    string[] s = this.hf_SelectedValue.Value.TrimEnd(',').Split(',');
            //    int a = s.Length / 100;
            //    for (int i = 0; i <= a; i++)
            //    {

            //    }
            //    DataTable dt = sysuserDAL.GetToUser(this.hf_SelectedValue.Value.TrimEnd(','));
            //    int count = dt.Rows.Count;
            //    return "";
            //    //string msg = WeixinQYAPI.SendMessage(token, dt.Rows[0]["ToUser"].ToString(), AgentID, "政务提醒：您收到一份标题为【" + this.txt_ETitle.Text + "】的政务，请及时查看。");
            //    //if (msg == "ok")
            //    //{
            //    //    // sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, "增加公文为：" + this.txt_ETitle.Text + "的信息", UserID));
            //    //    return "微信提醒成功";
            //    //}
            //    //else
            //    //{
            //    //    //sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "公文为：" + this.txt_ETitle.Text + "的信息", UserID));
            //    //    //sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, msg, UserID));
            //    //    return "但微信消息发送失败";
            //    //}
            //}
            //else
            //{
            //    //sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, FID == "" ? "增加" : "修改" + "【" + this.txt_ETitle.Text + "】的用户", UserID));
            //    return "但微信凭证调用失败";
            //}
            return "";
        }
        #endregion

        #region 发送短信通知
        public string SendMsg(string content, string touser)
        {
            MessageConfigEntity msmodel = new MessageConfigDAL().GetObjByID("政务通知");
            return ALiDaYu.SendMessage(msmodel, content, touser);
        }
        #endregion

        #endregion

        #region 保存
        protected void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                EgovernmentEntity model = new EgovernmentEntity();
                if (!string.IsNullOrEmpty(FID))
                {
                    model.EID = egovernment_FlowDAL.GetObjByID(FID).EID;
                    i = 1;
                }
                else
                {
                    model.EID = this.hf_EID.Value;
                }
                model.Etitle = this.txt_ETitle.Text;
                model.Ecode = this.txt_ECode.Text;
                model.EKey = "";
                model.EDepartment = this.txt_Department.Text;
                model.EtitleType = this.txt_EtitleType.Text;
                if (this.txt_Content.Text == "")
                {
                    ShowMessage("请填写正文");
                    return;
                }
                else
                {
                    model.EContent = this.txt_Content.Text;
                }
                //model.EContent = Context.Request.Form["myContent"].ToString();
                model.Opened = (int)CommonEnum.IsorNot.否;
                model.Completed = (int)CommonEnum.IsorNot.否;
                model.IsApproved = this.ck_IsOrNot.Checked ? 1 : 0;
                model.Etype = 0;
                model.CreateDate = DateTime.Now;
                model.CreateUser = UserID;
                model.IsSave = 0;//0保存，1提交
                model.Estate = (int)CommonEnum.GWType.未处理;
                model.IsSuperior = (int)CommonEnum.IsorNot.否;


                Egovernment_FlowEntity model_flow = new Egovernment_FlowEntity();
                model_flow.Comment = this.txt_Comment.Text;
                if (this.hf_SelectedValue.Value != "")
                    model_flow.AcceptUser = this.hf_SelectedValue.Value;
                else { ShowMessage("请选择收件人"); return; }

                model_flow.IsSendMess = this.cb_SendMessage.Checked ? 1 : 0;
                model_flow.State = (int)CommonEnum.GWType.未处理;//未处理状态
                model_flow.IsRead = (int)CommonEnum.IsorNot.否;
                int result = egovernmentDAL.Edit(model, model_flow, i);
                if (result > 0)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<script>alert('保存成功');window.location='EgovernmentIntends.aspx';</script>");
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, (FID == "" ? "保存" : "修改") + "公文为：" + this.txt_ETitle.Text + "的信息", UserID));
                }
                else
                {
                    ShowMessage("保存失败");
                    return;
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                return;
            }
        }
        #endregion


        protected void ck_IsOrNot_CheckedChanged(object sender, EventArgs e)
        {
            //if (this.ck_IsOrNot.Checked)
            //    this.pz.Visible = true;
            //else
            //    this.pz.Visible = false;
        }
    }
}