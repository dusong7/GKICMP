/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      樊紫红
** 创建日期:    2017年8月21日 18：02
** 描 述:       回复消息编辑页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.IO;
using System.Data;
using System.Text;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;


namespace GKICMP.mailmanage
{
    public partial class ReplayEmailEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public EmailDAL emailDAL = new EmailDAL();


        #region 参数集合
        /// <summary>
        /// EUID
        /// </summary>
        public string EUID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        #endregion


        #region 页面初始化
        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string ysyj = "------------------ 原始邮件 ------------------";
                string fjr = "";
                string fssj = "";
                string sjr = "";
                string bt = "";
                string nr = "";

                EmailEntity model = emailDAL.GetObjByEUID(EUID);
                if (model != null)
                {
                    this.txt_EmailTitle.Text = "回复:" + model.EmailTitle;
                    fjr = model.SendUserName;
                    fssj = model.SendDate.ToString("yyyy-MM-dd HH:mm:ss");
                    sjr = model.AcceptName;
                    bt = model.EmailTitle;
                    nr = model.EmailContent;
                }
                StringBuilder str = new StringBuilder();
                str.Append("<br><br>");
                str.AppendFormat("<p style='font-family: 微软雅黑体; font-size:12px;padding:2px 0 2px 0;background:#efefef;position:relative;display:block'>{0}<span style='display:block; position:absolute; width:100%; height:100%; top:0PX; left:0PX'></span><br>", ysyj);
                //str.AppendFormat("<p style='font-family: 微软雅黑体; font-size:12px;padding:2px 0 2px 0;background:#efefef;position:relative;  display:block'><b>发件人：</b>{0}", fjr);
                str.AppendFormat("<b>发件人：</b>{0}<br>", fjr);
                str.AppendFormat("<b>发送时间：</b>{0}<br>", fssj);
                str.AppendFormat("<b>收件人：</b>{0}<br>", sjr);
                str.AppendFormat("<b>标题：</b>{0}<br>", bt);
                str.Append("<span style='display:block; position:absolute; width:100%; height:100%; top:0PX; left:0PX'></span></p>");
                str.AppendFormat("<p>{0}</p>", nr);
                this.txt_Content.Text = str.ToString();
            }
        }
        #endregion


        #region 提交事件
        /// <summary>
        /// 提交事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                EmailEntity model = emailDAL.GetObjByEUID(EUID);
                if (model != null)
                {
                    model.EmailContent = this.txt_Content.Text;
                    string SendUser = model.AcceptUser;
                    model.AcceptUser = model.SendUser;
                    model.SendUser = SendUser;
                    int result = emailDAL.Edit(model,0);
                    if (result > 0)
                    {
                        sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "回复信息", UserID));
                        ShowMessage();
                    }
                    else
                    {
                        ShowMessage("提交失败");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                ShowMessage(ex.Message);
            }
        }
        #endregion
    }
}