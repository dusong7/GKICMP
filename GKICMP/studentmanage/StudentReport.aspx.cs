using GK.GKICMP.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GKICMP.studentmanage
{
    public partial class StudentReport : PageBase
    {
        #region 参数集合
        public int GID
        {
            get
            {
                return GetQueryString<int>("id", -1);
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }
    }
}