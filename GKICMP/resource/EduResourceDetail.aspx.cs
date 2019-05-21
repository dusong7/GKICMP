/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      lfz
** 创建日期:    2017年5月25日
** 描 述:       新闻栏目编辑页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using System.Configuration;
using System.Data;
using GK.GKICMP.DAL;

namespace GKICMP.resource
{
    public partial class EduResourceDetail : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public GradeLevelDAL gradeLevelDAL = new GradeLevelDAL();
        public EduResourceDAL eduResourceDAL = new EduResourceDAL();
        #region 参数集合


        public int Erid
        {
            get
            {
                return GetQueryString<int>("id", 0);
            }
        }
        #endregion
        public string url = "";
        public string name = "";
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
                if (Erid != 0)
                {
                    InfoBind();
                }
            }
        }
        #endregion
        #region 初始化用户数据
        /// <summary>
        /// 初始化用户数据
        /// </summary>
        private void InfoBind()
        {
            EduResourceEntity model = eduResourceDAL.GetObjByID(Erid);
            if (model != null)
            {
                name=this.ltl_ResourseName.Text = model.ResourseName;
                this.ltl_GID.Text = model.GIDName;
                this.ltl_TID.Text = CommonFunction.CheckEnum<CommonEnum.XQ>(model.TID);
                this.ltl_CID.Text = model.CIDName;
                this.ltl_EType.Text = CommonFunction.CheckEnum<CommonEnum.EType>( model.EType);
                this.ltl_DownLoadNum.Text = model.DownLoadNum.ToString();
                this.ltl_RSize.Text =CommonFunction.CountSize( model.RSize);
                this.ltl_RFormat.Text = model.RFormat;
                this.ltl_IsExcellent.Text = CommonFunction.CheckEnum<CommonEnum.IsorNot>(model.IsExcellent);
                this.ltl_IsOpen.Text = CommonFunction.CheckEnum<CommonEnum.IsorNot>(model.IsOpen);
                this.ltl_AuditState.Text = CommonFunction.CheckEnum<CommonEnum.NewsAuditState>(model.AuditState);
                if (model.AuditState == (int)CommonEnum.NewsAuditState.未审)
                    this.tr_null.Visible = false;
                else
                {
                    this.ltl_AuditUser.Text = model.AuditUserName;
                    this.ltl_AuditDate.Text = model.AuditDate.ToString("yyyy-MM-dd");
                }
                url = model.ResourseUrl;
               // this.hf_psw.Value = model.ERPwd == null ? "0" : model.ERPwd == "" ? "0" : "1";
            }
        }
        #endregion

        protected void lbtn_Sourse_Click(object sender, EventArgs e)
        {
            EduResourceEntity model = eduResourceDAL.GetObjByID(Erid);
            
            if (!CommonFunction.UpLoadFunciotn(model.ResourseUrl, model.ResourseName))
            {
                ShowMessage("资源不存在，请联系系统管理员");
                return;
            }
            int result = eduResourceDAL.DownLoad("");
        }
    }
}