
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.Common;

namespace GKICMP.networkteach
{
    public partial class TeacChat : PageBase
    {

        #region 参数集合
        /// <summary>
        /// UID
        /// </summary>
        public int nteFlag
        {
            get
            {
                return GetQueryString<int>("flag", 0);
            }
        }
        #endregion

        public string Name = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (nteFlag == 1)
                {
                    this.lbl_ParentMenu.Text = "我的学习";
                    this.lbl_Menuname.Text = "在线学习";
                }
                Name = UserRealName;
                this.hf_NTLID.Value = Guid.NewGuid().ToString();
            }
        }
    }
}