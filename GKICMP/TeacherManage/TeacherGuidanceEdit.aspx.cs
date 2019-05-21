/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      lfz
** 创建日期:      2016年10月15日 13时56分24秒
** 描    述:      教师合同管理界面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Configuration;
using System.Web;
using System.IO;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;


using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;

namespace GKICMP.teachermanage
{
    public partial class TeacherGuidanceEdit : PageBase
    {
        public Teacher_ContractDAL contractDal = new Teacher_ContractDAL();
        public SysDataDAL SysDataDAL = new SysDataDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public TeacherDAL teacherDAL = new TeacherDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public BaseDataDAL baseDataDAL = new BaseDataDAL();
        public Teacher_GuidanceDAL teacher_GuidanceDAL = new Teacher_GuidanceDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();
      

        #region 参数集合
        /// <summary>
        /// TPID
        /// </summary>
        public string TGID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        #endregion

        protected int v = 0;

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
                CommonFunction.BindEnum<CommonEnum.URole>(this.ddl_GRoles, "-2");
               // BandDepart(); //绑定教师
                if (TGID != "")
                {
                    InfoBind(0);
                }
            }
        }
        #endregion

        #region 绑定教师姓名
        private void SetValue(string TID)
        {
            StringBuilder sb1 = new StringBuilder();
            sb1.Append("<script type='text/javascript'>");
            sb1.Append("$(function () {$('#TeacherName').combotree('setValue', '");
            sb1.Append(TID);
            sb1.Append("');");
            sb1.Append("$('#TeacherName').combotree('disable');");
            sb1.Append("})</script>");
            this.ltl_xz.Text = sb1.ToString();
        }
        #endregion

        //#region 教师绑定
        ///// <summary>
        ///// 教师绑定
        ///// </summary>
        //private void BandDepart()
        //{
        //    StringBuilder sb = new StringBuilder("");
        //    string a = DepartList();
        //    sb.Append("<script type='text/javascript'>");
        //    sb.Append(" $(function () {");
        //    sb.Append(" $('#TeacherName').combotree({");
        //    sb.Append(" data:[");
        //    sb.Append(a);
        //    sb.Append("],");
        //    sb.Append("multiple: false,");
        //    sb.Append("multiline: false,");
        //    sb.Append("});");
        //    sb.Append(" }); </script>");

        //    this.ltl_JQ.Text = sb.ToString();

        //}
        //private string DepartList()
        //{
        //    DataTable dt;
        //    dt = sysUserDAL.GetSysUserByType((int)CommonEnum.UserType.老师, (int)CommonEnum.Deleted.未删除);
        //    string name = string.Empty;
        //    StringBuilder sb = new StringBuilder();
        //    if (dt.Rows.Count > 0)
        //    {
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            name += "{\"id\":\"" + dt.Rows[i]["UID"].ToString() +
        //               "\",\"text\":\"" + dt.Rows[i]["RealName"].ToString() + "\"},";
        //        }
        //    }
        //    sb.Append(name.ToString().TrimEnd(','));
        //    return sb.ToString();
        //}
        //#endregion

        #region 带部门的教师绑定
        /// <summary>
        /// 带部门的教师绑定
        /// </summary>
        private void BandDepart()
        {
            StringBuilder sb = new StringBuilder("");
            string a = MList();
            sb.Append("<script type='text/javascript'>");
            sb.Append(" $(function () {");
            sb.Append(" $('#TeacherName').combotree({");
            sb.Append(" data: [ ");
            sb.Append(a);
            sb.Append("],");
            sb.Append("multiple: false,");
            sb.Append("lines: true,");
            sb.Append("});");
            sb.Append(" }); </script>");
            this.ltl_JQ.Text = sb.ToString();
        }

        /// <summary>
        /// 绑定职能部门信息
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
        /// 绑定职能部门人员信息
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

        #region 数据绑定
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void InfoBind(int i)
        {
            Teacher_GuidanceEntity model = teacher_GuidanceDAL.GetObjByID(TGID);
            if (model != null)
            {
                //SetValue(model.TID);//绑定教师姓名
                //this.hf_SelectedValue.Value = model.TID;
                this.Series.Text = model.TID;
                this.Series.Enabled = false;

                this.txt_RewardName.Text = model.RewardName.ToString();
                this.txt_Lunit.Text = model.Lunit.ToString();
                this.txt_PubDate.Text = model.PubDate.ToString("yyyy-MM-dd");
                this.ddl_GRoles.SelectedValue = model.GRole.ToString();
                this.txt_RGrade.Text = model.RGrade.ToString();
                this.txt_GuiDesc.Text = model.GuiDesc;
                this.hf_UpFile.Value = model.RFile;
                AccessBind();

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
                Teacher_GuidanceEntity model = new Teacher_GuidanceEntity();
               // string teacherName = Request["TeacherName"].ToString(); //获取值
                //if (this.hf_SelectedValue.Value == "")
                if (this.Series.Text == "")
                {
                    ShowMessage("教师姓名不能为空");
                    return;
                }
                else
                {
                    model.TGID = TGID;
                    //model.TID = this.hf_SelectedValue.Value;
                    model.TID = this.Series.Text;

                    model.RewardName = this.txt_RewardName.Text;
                    model.Lunit = this.txt_Lunit.Text;
                    model.PubDate = Convert.ToDateTime(this.txt_PubDate.Text);
                    model.GRole = int.Parse(this.ddl_GRoles.SelectedValue);
                    model.RGrade = this.txt_RGrade.Text;
                    model.GuiDesc = this.txt_GuiDesc.Text;
                    model.RFile = this.hf_UpFile.Value;
                    model.Isdel = (int)CommonEnum.IsorNot.否;
                    //附件上传
                    int upsize = 4000000;
                    try
                    {
                        upsize = Convert.ToInt32(ConfigurationManager.AppSettings["upsize"].ToString());
                    }
                    catch (Exception) { }
                    AccessoryEntity accessinfo = CommonFunction.upfile(0, 1, hf_UpFile, "ImageUrl");
                    if (accessinfo.AccessID == "-2")
                    {
                        //刚才上传的文件删除
                        CommonFunction.delfile(hf_UpFile.Value.ToString());
                        ShowMessage(accessinfo.AccessName);
                        return;
                    }
                    else
                    {
                        if (this.fl_UpFile.HasFile)
                            model.RFile = accessinfo.AccessUrl;
                        else
                            model.RFile = this.hf_UpFile.Value;
                    }

                    //model.RFile = (this.hf_Images.Value + "," + accessinfo.AccessUrl).Trim(',');
                    int result = teacher_GuidanceDAL.Edit(model);
                    if (result > 0)
                    {
                        ShowMessage();
                        sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_其他, "", UserID));
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
                return;
            }
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
            DataTable ds = teacher_GuidanceDAL.GetTable(TGID);
            rp_File.DataSource = ds;
            rp_File.DataBind();
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