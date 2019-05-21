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
    public partial class AfficheEdit : PageBase
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
                DataTable dt = sysDataDAL.GetList((int)CommonEnum.IsorNot.否, (int)CommonEnum.DataType.通知公告);
                CommonFunction.DDlTypeBind(this.ddl_AType, dt, "SDID", "DataName", "-2");
                CommonFunction.BindEnum<CommonEnum.IsorNot>(this.rbl_IsDisplay);
                this.rbl_IsDisplay.SelectedIndex = 1;
                BandData();
            }
        }
        #endregion

        #region 前台js绑定数据
        /// <summary>
        /// 前台js绑定数据
        /// </summary>
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
            sb.Append("multiline: true,");
            sb.Append("});");
            sb.Append(" }); </script>");
            this.ltl_Content.Text = sb.ToString();
        }

        /// <summary>
        /// 绑定部门信息
        /// </summary>
        /// <returns></returns>
        private string MList()
        {
            DataTable dt;
             dt = departmentDAL.GetZNBM((int)CommonEnum.DepType.职能部门, (int)CommonEnum.IsorNot.否);
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

        /// <summary>
        /// 绑定部门人员信息
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
        public string InitChild(string parentID)
        {
            DataTable dt = teacherDAL.GetByDepID(int.Parse(parentID), (int)CommonEnum.UserType.老师, (int)CommonEnum.IsorNot.否);
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
                AfficheEntity model = new AfficheEntity();
                model.AfficheTitle = this.txt_AfficheTitle.Text.Trim();
                model.AContent = this.txt_AContent.Text.Trim();
                model.SendUser = UserID;
                model.AType = Convert.ToInt32(this.ddl_AType.SelectedValue);
                model.IsDisplay = Convert.ToInt32(this.rbl_IsDisplay.SelectedValue);
                model.AFlag = 1;
                model.ClaID = 0;
                if (this.hf_TID.Value.Length <= 0)
                {
                    ShowMessage("请选择接收人");
                    return;
                }
                string ids = this.hf_TID.Value;
                int result = afficheDDAL.Edit(model, ids);
                if (result == 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, "添加通知公告信息", UserID));
                    //string msg = SendMsg(ids, model.AContent);
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<script>alert('提交成功');window.location='AfficheManage.aspx'</script>");
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
                DataTable dt = sysUserDAL.GetPhone(touser);
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