/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      gxl
** 创建日期:      2016年10月15日 13时56分24秒
** 描    述:      异动管理
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Configuration;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;


namespace GKICMP.teachermanage
{
    public partial class TeacherChangesEdit : PageBase
    {
        Teacher_TrainDAL teacher_TrainDAL = new Teacher_TrainDAL();
        public SysDataDAL SysDataDAL = new SysDataDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public TeacherDAL teacherDAL = new TeacherDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public BaseDataDAL baseDataDAL = new BaseDataDAL();
        public Teacher_ChangesDAL teacher_ChangesDAL = new Teacher_ChangesDAL();

        #region 参数集合
        /// <summary>
        /// 参数集合
        /// </summary>
        public string TCID
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
                CommonFunction.BindEnum<CommonEnum.TeacherState>(this.ddl_CType, "-2");//异动类型

                //BandDepart();
                if (TCID != "")
                {
                    InfoBind();
                    //SetValue();
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

        #region 初始化用户数据
        /// <summary>
        /// 初始化用户数据
        /// </summary>
        private void InfoBind()
        {
            Teacher_ChangesEntity model = teacher_ChangesDAL.GetObjByID(TCID);
            if (model != null)
            {
                //SetValue(model.TID);//绑定教师姓名
                //this.hf_SelectedValue.Value = model.TID;
                this.Series.Text = model.TID;
                this.Series.Enabled = false;

                this.txt_CDate.Text = Convert.ToDateTime(model.CDate).ToString("yyyy-MM-dd");
                this.txt_ChangeReason.Text = model.ChangeReason.ToString();
                this.ddl_CType.SelectedValue = model.CType.ToString();

                this.hf_RFile.Value = model.CFile;
                AccessBind();

            }
        }
        #endregion

        #region 提交
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                Teacher_ChangesEntity model = new Teacher_ChangesEntity();
                model.TCID = TCID;
                //if (this.hf_SelectedValue.Value == "")
                //{
                //    ShowMessage("教师姓名不能为空");
                //    return;
                //}
                //model.TID = this.hf_SelectedValue.Value;
                if (this.Series.Text == "")
                {
                    ShowMessage("请选择教师");
                    return;
                }
                model.TID = this.Series.Text;

                model.CDate = DateTime.Parse(this.txt_CDate.Text);
                model.ChangeReason = this.txt_ChangeReason.Text;
                model.CType = Da(Convert.ToInt32(this.ddl_CType.SelectedValue));
                model.Isdel = (int)CommonEnum.Deleted.未删除;
                model.IsReport = (int)CommonEnum.IsorNot.否;
                model.CreateUser = UserID;

                //附件上传
                int upsize = 4000000;
                try
                {
                    upsize = Convert.ToInt32(ConfigurationManager.AppSettings["upsize"].ToString());
                }
                catch (Exception) { }
                AccessoryEntity accessinfo = CommonFunction.upfile(0, 1, hf_file, "file");
                if (accessinfo.AccessID == "-2")
                {
                    //刚才上传的文件删除
                    CommonFunction.delfile(hf_file.Value.ToString());
                    ShowMessage(accessinfo.AccessName);
                    return;
                }
                else
                {
                    accessinfo.AccessFlag = (int)CommonEnum.AccessoryType.Tb_Contract;
                    accessinfo.AccessObjID = model.TCID;
                    accessinfo.ObjID = "";
                }
                model.CFile = accessinfo.AccessUrl;


                int result = teacher_ChangesDAL.Edit(model);
                if (result == 0)
                {
                    if (TCID == "")
                        sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, "增加教师异动信息", UserID));
                    else
                        sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_修改, "修改教师异动信息", UserID));
                    ShowMessage();
                }
                else
                {
                    ShowMessage("提交错误");
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, "系统错误【" + ex.Message + "】", UserID));
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
            DataTable ds = teacher_ChangesDAL.GetTable(TCID);
            rp_File.DataSource = ds;
            rp_File.DataBind();
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

        #region 获取文件后缀名
        /// <summary>
        /// 获取文件后缀名
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string getFileName(string obj)
        {
            return Path.GetFileName(obj);
        }
        #endregion


        #region 判断异动类型是否需要加300
        public int Da(int type)
        {
            type += 300;
            if (type == (int)CommonEnum.TeaState.暂未在本单位任职_退休 || type == (int)CommonEnum.TeaState.暂未在本单位任职_离休 || type == (int)CommonEnum.TeaState.暂未在本单位任职_死亡 || type == (int)CommonEnum.TeaState.暂未在本单位任职_辞职 || type == (int)CommonEnum.TeaState.暂未在本单位任职_离职 || type == (int)CommonEnum.TeaState.暂未在本单位任职_开除)
            {
            }
            else
            {
                type -= 300;
            }
            return type;
        }
        #endregion

    }
}