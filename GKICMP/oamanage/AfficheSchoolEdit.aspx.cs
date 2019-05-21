/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月08日 09点30分
** 描   述:       通知公告页面
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.Data;
using System.Text;
namespace GKICMP.oamanage
{
    public partial class AfficheSchoolEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public AfficheDAL afficheDDAL = new AfficheDAL();
        public SysDataDAL sysDataDAL = new SysDataDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public TeacherDAL teacherDAL = new TeacherDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }
        #endregion

        

        #region 提交
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                AfficheEntity model = new AfficheEntity();
                model.AfficheTitle = this.txt_AfficheTitle.Text.Trim();
                model.AContent = this.txt_AContent.Text.Trim();
                model.SendUser = UserID;
                model.AType = -2;
                model.IsDisplay = 0;
                model.AFlag = 0;//0:全员
                model.ClaID = 0;
                
                int result = afficheDDAL.Edit(model, "");
                if (result == 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, "添加全员通知公告信息", UserID));
                    //string msg = SendMsg(ids, model.AContent);
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<script>alert('提交成功');window.location='AfficheSchoolManage.aspx'</script>");
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
        #endregion
        public string SendMsg(string touser, string content)
        {
            string result = "";
            string tousers = "";
            WeiXinInfoEntity model1 = XMLHelper.Get("~/QYWX.xml", "Notice", 1);
            if (model1.IsOpen == 1)
            {
                DataTable dt = sysUserDAL.GetMsgIdByDep(touser);
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        tousers += dr["userid"].ToString() + "|";
                    }
                    string token = WeixinQYAPI.GetToken(1, "Notice");
                    string json = "{\"touser\":\"" + tousers + "\",\"msgtype\":\"text\",\"agentid\":\"" + model1.Agent + "\",\"text\":{\"content\":\"" + content + "\"}}";
                    string msg = WeixinQYAPI.Post(string.Format("https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token={0}", token), json);
                    if (WeixinQYAPI.Json(msg, "errmsg") == "ok")
                    {
                        result = "微信消息发送成功";
                    }
                    else
                    {
                        result = "微信消息发送失败";
                    }
                }
            }
            return result;
        }
    }
}