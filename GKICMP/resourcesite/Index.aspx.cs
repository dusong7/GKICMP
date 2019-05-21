using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.Common;

namespace GKICMP.resourcesite
{
    public partial class Index : PageBase
    {

        public int RType
        {
            get
            {
                return GetQueryString<int>("RType", -2);
            }
        }

        public int RTypes = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                RTypes = RType;
            }
        }
    }
}