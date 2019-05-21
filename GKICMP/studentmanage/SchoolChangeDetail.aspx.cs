/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      yzr
** 创建日期:      2017年01月26日 16时05分25秒
** 描    述:      学生变动信息详细页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using System.Data;

namespace GKICMP.studentmanage
{
    public partial class SchoolChangeDetail : PageBase
    {
        public SchoolChangeDAL schoolChangeDAL = new SchoolChangeDAL();


        #region 参数集合
        public string TID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        #endregion


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SchoolChangeEntity model = schoolChangeDAL.GetObjByID(TID);
                if (model != null)
                {
                    this.lbl_Claidname.Text = model.ClaIDName;
                    this.lbl_Gradename.Text = model.GradeName;
                    this.lbl_Realname.Text = model.StuIDName;
                    this.lbl_SCDesc.Text = model.SCDesc;
                    this.lbl_SCReason.Text = model.SCReason;
                    this.lbl_SCDate.Text = model.SCDate.ToString("yyyy-MM-dd");
                    this.lbl_SCType.Text = CommonFunction.CheckEnum<CommonEnum.BDLX>(model.SCType);
                }
            }
        }
        #endregion
    }
}