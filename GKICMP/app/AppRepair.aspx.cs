using System;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Data;
using System.Text;
using System.Configuration;
using System.Diagnostics;

namespace GKICMP.app
{
    public partial class AppRepair : PageBaseApp
    {
        public Asset_RepairDAL asset_RepairDAL = new Asset_RepairDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public AssetDAL assetDAL = new AssetDAL();
        //public string agentId = "";
        //public string corpId = "";
        //public string CorpSecret = "";
        //public string nonceStr = "GKDZ";
        //public string signature = "";
        //public string timestamp = "";
        //public string accessToken = "";
        //public string jsApiTicket = "";


        public string AID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //DataTable dt = new DepartmentDAL().GetList((int)CommonEnum.Deleted.未删除, -2);
                //CommonFunction.DDlTypeBind(this.ddl_Dep, dt, "DID", "DepName", "-2");
                //GetConfig();
            }
        }


        //#region 获取jsapi签名验证处理
        //private void GetConfig()
        //{
        //    WeiXinInfoEntity model = XMLHelper.Get("~/QYWX.xml", "Notice", 1);
        //    corpId = model.CorpID;
        //    CorpSecret = model.Secret;
        //    agentId = model.Agent;
        //    accessToken = WeixinQYAPI.GetAccess_Token(corpId, CorpSecret);
        //    string ticket = WeixinQYAPI.RequestUrl(string.Format("https://qyapi.weixin.qq.com/cgi-bin/get_jsapi_ticket?access_token={0}", accessToken.Trim()));
        //    jsApiTicket = WeixinQYAPI.Json(ticket, "ticket");
        //    timestamp = timeStamp();
        //    string url = Request.Url.AbsoluteUri;
        //    string signature1 = "jsapi_ticket=" + jsApiTicket.Trim() + "&noncestr=" + nonceStr + "&timestamp=" + timestamp.Trim() + "&url=" + url.Trim();
        //    signature = FormsAuthentication.HashPasswordForStoringInConfigFile(signature1, "SHA1").ToLower();
        //}
        //#endregion


        //#region 时间戳的随机数
        ///// <summary>
        ///// 时间戳的随机数
        ///// </summary>
        ///// <returns></returns>
        //public static string timeStamp()
        //{
        //    DateTime dt1 = Convert.ToDateTime("1970-01-01 00:00:00");
        //    TimeSpan ts = DateTime.Now - dt1;
        //    return Math.Ceiling(ts.TotalSeconds).ToString();
        //}
        //#endregion

        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {

                Stopwatch sp = new Stopwatch();
                sp.Start();
                if (this.hf_User.Value == "")
                {

                    ShowMessage("请选择受理人员");
                    return;

                }
                Asset_RepairEntity model = new Asset_RepairEntity();
                model.ARID = "";
                model.RepairObj = this.txt_RepairObj.Text.Trim();
                model.CreaterUser = UserID;
                //try
                //{
                //    model.DutyDep = Convert.ToInt32(this.hf_Dep.Value);
                //}
                //catch (Exception ex)
                //{
                //    ShowMessage("部门有误");
                //}
                model.DutyDep = Convert.ToInt32(this.hf_Dep.Value);
                //model.DutyDep = Convert.ToInt32(this.ddl_Dep.SelectedValue);
                //model.DutyUser = this.ddl_User.SelectedValue;
                //model.DutyDep = int.Parse(this.hf_Dep.Value);
                model.SDID = hf_D.Value;
                model.DutyUser = this.hf_User.Value;

                model.RepairContent = this.hf_RepairContent.Value;
                model.ARState = Convert.ToInt32(CommonEnum.ARState.未受理);
                model.Isdel = Convert.ToInt32(CommonEnum.Deleted.未删除);
                //上传图片                  
                //AccessoryEntity accessinfo = getModel();
                //model.ARFile = accessinfo.AccessUrl;
                //model.ARFile = "";
                //if (this.hf_FilePath.Value != "")
                //    model.ARFile = "/webupload/FileBox/" + this.hf_FilePath.Value + ".jpeg";
                //else
                //    model.ARFile = "";
                model.ARFile = this.hf_FilePath.Value;
                int result = asset_RepairDAL.EditAPP(model);
                if (result == 0)
                {
                    string msg = "";
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "添加报修对象为：" + this.txt_RepairObj.Text + "的数据", UserID));
                    string a = XMLHelper.GetXmlNodesAttributes("~/BaseInfoSet.xml", "DX", "IsOpen");
                    if (a == "1")
                    {
                        if (!string.IsNullOrEmpty(this.hf_D.Value))
                        {
                            SupplierEntity sub = new SupplierDAL().GetObjByID(this.hf_D.Value);
                            if (!string.IsNullOrEmpty(sub.LinkPhone))
                            {
                                MessageConfigEntity msmodel = new MessageConfigDAL().GetObjByID("售后服务");
                                if (msmodel != null)
                                {
                                    msg = ALiDaYu.SendMessage(msmodel, "", sub.LinkPhone);
                                }

                            }
                            if (!string.IsNullOrEmpty(ID))
                            {
                                //ShowMessage("提交成功" + msg);
                                ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('提交成功');window.location.href='RepairList.aspx'</script>");
                                // Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('提交成功！');window.location='AppMain.aspx';", true);
                            }
                            else
                            {
                                ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('提交成功" + msg + "');window.location.href='RepairList.aspx'</script>");
                            }
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(ID))
                            {
                                ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('提交成功');window.location.href='RepairList.aspx'</script>");
                            }
                            else
                            {
                                ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('提交成功');window.location.href='RepairList.aspx'</script>");
                            }
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(ID))
                        {
                            ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('提交成功');window.location.href='RepairList.aspx'</script>");
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('提交成功');window.location.href='RepairList.aspx'</script>");
                        }
                    }
                    sp.Stop();
                    TimeSpan ts = sp.Elapsed;

                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "总时长：" + ts.Milliseconds.ToString(), UserID));


                }
                else
                {
                    ShowMessage("保存失败");
                    return;
                }


            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                ShowMessage(ex.Message);
            }
        }

        //protected void ddl_Dep_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    DataTable dt = new SysUserDAL().GetSysUserByDepid(1,int.Parse(this.ddl_Dep.SelectedValue));
        //    CommonFunction.DDlTypeBind(this.ddl_User, dt, "UID", "RealName", "-2");
        //}

        public AccessoryEntity getModel()
        {
            return CommonFunction.upfileTest(0, 1, hf_file, "FileBox");
        }

        protected void btn_SearchUser_Click(object sender, EventArgs e)
        {
            //string str = "";
            //this.txt_User.Text = "";
            //if (this.hf_Dep.Value != "")
            //{
            //    this.txt_User.Enabled = true;
            //    DataTable dt = new SysUserDAL().GetUserByRYFL(1, int.Parse(this.hf_Dep.Value));
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        str += "{value:'" + dt.Rows[i]["UID"].ToString() + "',text:'" + dt.Rows[i]["RealName"].ToString() + "'},";
            //    }
            //    str = str.TrimEnd(',');
            //    StringBuilder sb = new StringBuilder();
            //    sb.Append("<script type='text/javascript'>");
            //    sb.Append("(function ($, doc) {");
            //    sb.Append("$.init();");
            //    sb.Append("$.ready(function () {");
            //    sb.Append("    var userPicker1 = new $.PopPicker();");
            //    sb.Append("    userPicker1.setData([");
            //    sb.Append(str.ToString());
            //    sb.Append("    ]);");
            //    sb.Append("    var showUserPickerButton = doc.getElementById('txt_User');");
            //    sb.Append("    var userResult = doc.getElementById('txt_User');");
            //    sb.Append("    var userCustInt = doc.getElementById('hf_User');");
            //    sb.Append("    showUserPickerButton.addEventListener('tap', function (event) {");
            //    sb.Append("        userPicker1.show(function (items) {");
            //    sb.Append("            userResult.value = items[0].text;");
            //    sb.Append("            userCustInt.value = items[0].value;");
            //    sb.Append("        });");
            //    sb.Append("    }, false);");
            //    sb.Append("});");
            //    sb.Append("})");
            //    sb.Append("(mui, document);");
            //    sb.Append("</script>");
            //    this.ltl_User.Text = sb.ToString();
            //}
            //else
            //{

            //}

        }
    }
}