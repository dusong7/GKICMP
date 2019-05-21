/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年8月29日 11时09分29秒
** 描    述:      助学金编辑页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.IO;
using System.Data;
using System.Configuration;
using System.Web.UI.WebControls;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using System.Text;


namespace GKICMP.schoolwork
{
    public partial class GrantEdit : PageBase
    {
        public GrantDAL grantDAL = new GrantDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();

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
                //BandDepart();
                CommonFunction.BindEnum<CommonEnum.GrantType>(this.ddl_GrantType, "-2");
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
                //this.txt_RealName.Text = model.UserName;//模块名称
                //SetValue(model.UID);
                //this.hf_SelectedValue.Value = model.UID;

                this.Series.Text = model.UID;
                this.Series.Enabled = false;

                this.ddl_GrantType.SelectedValue = model.GType.ToString();//
                this.txt_GDesc.Text = model.GMark.ToString();
                this.hf_file.Value = model.ApplyUrl;
               
                AccessBind();
            }
        }
        #endregion


        #region 绑定教师姓名
        private void SetValue(string TID)
        {
            StringBuilder sb1 = new StringBuilder();
            sb1.Append("<script type='text/javascript'>");
            sb1.Append("$(function () {$('#StuName').combotree('setValue', '");
            sb1.Append(TID);
            sb1.Append("');");
            sb1.Append("$('#StuName').combotree('disable');");
            sb1.Append("})</script>");
            this.ltl_xz.Text = sb1.ToString();
        }
        #endregion

        #region 教师绑定
        /// <summary>
        /// 教师绑定
        /// </summary>
        private void BandDepart()
        {
            StringBuilder sb = new StringBuilder("");
            string a = DepartList();
            sb.Append("<script type='text/javascript'>");
            sb.Append(" $(function () {");
            sb.Append(" $('#StuName').combotree({");
            sb.Append(" data:[");
            sb.Append(a);
            sb.Append("],");
            sb.Append("multiple: false,");
            sb.Append("multiline: false,");
            sb.Append("});");
            sb.Append(" }); </script>");

            this.ltl_JQ.Text = sb.ToString();

        }
        private string DepartList()
        {
            DataTable dt;
            dt = sysUserDAL.GetSysUserByType((int)CommonEnum.UserType.学生, (int)CommonEnum.Deleted.未删除);
            string name = string.Empty;
            StringBuilder sb = new StringBuilder();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    name += "{\"id\":\"" + dt.Rows[i]["UID"].ToString() +
                       "\",\"text\":\"" + dt.Rows[i]["RealName"].ToString() + "\"},";
                }
            }
            sb.Append(name.ToString().TrimEnd(','));
            return sb.ToString();
        }
        #endregion


        #region 附件下载、删除
        /// <summary>
        /// 附件下载、删除
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
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


        #region 提交
        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                GrantEntity model = new GrantEntity();
                model.GID = GID;
                //model.UID = this.hf_SelectedValue.Value;
                if (this.Series.Text == "")
                {
                    ShowMessage("请选择学生");
                    return;
                }
                model.UID = this.Series.Text;

                model.GType = int.Parse(this.ddl_GrantType.SelectedValue);
                model.AduitState = Convert.ToInt32(CommonEnum.AduitState.未审核);
                //申请材料
                //上传图片
                int upsize = 4000000;
                try
                {
                    upsize = Convert.ToInt32(ConfigurationManager.AppSettings["upsize"].ToString());
                }
                catch (Exception) { }
                AccessoryEntity accessinfo = CommonFunction.upfile(0, 1, hf_file, "ImageUrl");
                if (accessinfo.AccessID == "-2")
                {
                    //刚才上传的文件删除
                    CommonFunction.delfile(hf_file.Value.ToString());
                    ShowMessage(accessinfo.AccessName);
                    return;
                }
                else
                {
                    if (this.fl_UpFile.HasFile)
                        model.ApplyUrl = accessinfo.AccessUrl;
                    else
                        model.ApplyUrl = this.hf_file.Value;
                }
                model.GMark = this.txt_GDesc.Text;
                model.Isdel = (int)CommonEnum.Deleted.未删除;
                model.CreateDate = DateTime.Now;
                int result = grantDAL.Edit(model);
                if (result == -1)
                {
                    ShowMessage("提交失败");
                    return;
                }
                else if (result == -2)
                {
                    ShowMessage("该学生已申请");
                    return;
                }
                else
                {
                    int log = ID == "" ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, (ID == "" ? "添加" : "修改") + "学生助学金信息", UserID));
                    ShowMessage();
                }
            }
            catch (Exception error)
            {
                ShowMessage(error.Message);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, error.Message, UserID));
                return;
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
    }
}