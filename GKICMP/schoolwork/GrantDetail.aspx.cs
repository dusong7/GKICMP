/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      lfz
** 创建日期:      2016年11月21日 16时12分29秒
** 描    述:      助学金详情页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/

using System;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;

namespace GKICMP.schoolwork
{
    public partial class GrantDetail : PageBase
    {
        public GrantDAL grantDAL = new GrantDAL();

        #region 参数集合
        /// <summary>
        /// ID
        /// </summary>
        public string GID
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
                if (!string.IsNullOrEmpty(GID))
                {
                    InfoBind();
                }
            }
        }
        #endregion


        #region 初始化数据
        /// <summary>
        /// 初始化数据
        /// </summary>
        protected void InfoBind()
        {
            GrantEntity model = grantDAL.GetObj(GID);
            if (model != null)
            {
                this.lbl_UserName.Text = model.UserName;//模块名称
                this.lbl_GrantType.Text = CommonFunction.CheckEnum<CommonEnum.GrantType>(model.GType.ToString());//
                this.lbl_Mark.Text = model.GMark.ToString();
                this.ltl_AuditUser.Text = model.AduitName.ToString() == "" ? "" : model.AduitName;
                if (model.AduitDate != null && model.AduitDate.ToString() != "")
                {
                    this.ltl_AuditDate.Text = model.AduitDate.ToString("yyyy-MM-dd HH:mm");
                }
                else
                {
                    this.ltl_AuditDate.Text = "";
                }
                this.ltl_AuditState.Text = model.AduitState.ToString() == "" ? "" : GK.GKICMP.Common.CommonFunction.CheckEnum<GK.GKICMP.Common.CommonEnum.AduitState>(model.AduitState.ToString());
                AccessBind();
                // this.hf_file.Value = model.ApplyUrl;
            }
        }
        #endregion


        #region 获取文件后缀名
        /// <summary>
        /// 获取文件后缀名
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string getFileName(string obj)
        {
            return Path.GetFileNameWithoutExtension(obj);
        } 
        #endregion


        #region 附件下载、删除
        protected void rpaccess_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string accessid = e.CommandArgument.ToString().Trim();
            string name = Path.GetFileNameWithoutExtension(accessid);

            if (!CommonFunction.UpLoadFunciotn(accessid, name))
            {
                ShowMessage("下载文件不存在，请联系系统管理员");
                return;
            }
        }
        #endregion


        #region 附件绑定
        /// <summary>
        /// 附件绑定
        /// </summary>
        /// <param name="rpcontr"></param>
        /// <param name="objid"></param>
        /// <param name="flag"></param>
        public void AccessBind()
        {
            DataTable ds = grantDAL.GetTable(GID);
            rp_File.DataSource = ds;
            rp_File.DataBind();
        }
        #endregion
    }
}