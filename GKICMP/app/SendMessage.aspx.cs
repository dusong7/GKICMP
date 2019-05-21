using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK.GKICMP.Common;

namespace GKICMP.app
{
    public partial class SendMessage :PageBaseApp
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                WeixinQYAPI.SendMessage("", "", "10004", "测试发送文本消息");
            }
        }
    }
}