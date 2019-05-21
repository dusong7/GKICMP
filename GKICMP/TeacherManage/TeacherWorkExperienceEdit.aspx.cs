/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      fsc
** 创建日期:    2017年02月27日
** 描 述:       用户编辑页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using GK.GKICMP.Common;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Data;
using System.Text;

namespace GKICMP.teachermanage
{
    public partial class TeacherWorkExperienceEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public TeacherEducationDAL teacherEducation = new TeacherEducationDAL();
        public BaseDataDAL baseDataDAL = new BaseDataDAL();
        public Teacher_WorkExperienceDAL teachworkExperient = new Teacher_WorkExperienceDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public TeacherDAL teacherDAL = new TeacherDAL();
         
        #region 参数集合
        /// <summary>
        /// TWEID
        /// </summary>
        public string TWEID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }

        /// <summary>
        /// TID
        /// </summary>
        public string TID
        {
            get
            {
                return GetQueryString<string>("tid", "");
            }
        }

        /// <summary>
        /// TID
        /// </summary>
        public int TFLAG
        {
            get
            {
                return GetQueryString<int>("flag", -1);
            }
        }
        #endregion

        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable HS = baseDataDAL.GetList((int)CommonEnum.BaseDataType.在学单位类别, -1);
                CommonFunction.DDlTypeBind(this.ddl_TType, HS, "SDID", "DataName", "-2");

                this.hf_SelectedValue.Value = TID;
                //BandDepart();
                if (TID != "")
                {
                    this.Series.Text = TID;
                    this.Series.Enabled = false;
                } 
                if (TFLAG == 1)
                {
                    this.Series.Text = UserID;
            
                  
                    this.Series.Enabled = false;
                }
                if (TWEID != "")
                {
                    InfoBind();
                }

            }
        }
        #endregion

        #region 绑定教师姓名
        /// <summary>
        /// 绑定教师姓名
        /// </summary>
        private void SetValue(string TID)
        {
            StringBuilder sb1 = new StringBuilder();
            sb1.Append("<script type='text/javascript'>");
            sb1.Append("$(function () {$('#Series').combotree('setValue', '");
            sb1.Append(TID);
            sb1.Append("');");
            sb1.Append("$('#Series').combotree('disable');");
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


        #region 初始化用户数据
        /// <summary>
        /// 初始化用户数据
        /// </summary>
        private void InfoBind()
        {
            Teacher_WorkExperienceEntity tmodel = teachworkExperient.GetObjByID(TWEID);
            if (tmodel != null)
            {
                //this.TeacherName.Value = tmodel.TName;//教师
                //SetValue(tmodel.TID);//绑定教师姓名
                //this.hf_SelectedValue.Value = tmodel.TID;
                this.Series.Text = tmodel.TID;
                this.Series.Enabled = false;

                this.ddl_TType.SelectedValue = tmodel.TType.ToString();
              
                this.txt_TStartDate.Text = tmodel.TStartDate.ToString() == "1900/1/1 0:00:00" ? "" : tmodel.TStartDate.ToString("yyyy-MM-dd");
                this.txt_TEndDate.Text = tmodel.TEndDate.ToString() == "1900/1/1 0:00:00" ? "" : tmodel.TEndDate.ToString("yyyy-MM-dd");

                this.txt_TrainContent.Text = tmodel.TrainContent == null ? "" : tmodel.TrainContent.ToString();
                this.txt_TrainAddress.Text = tmodel.TrainAddress == null ? "" : tmodel.TrainAddress.ToString();
               

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
                Teacher_WorkExperienceEntity model = new Teacher_WorkExperienceEntity();
                model.TWEID = TWEID;
                //if (this.hf_SelectedValue.Value == "")
                //{
                //    ShowMessage("教师姓名不能为空");
                //    return;
                //}
                //model.TID = this.hf_SelectedValue.Value;;
                if (this.Series.Text == "")
                {
                    ShowMessage("请选择教师");
                    return;
                }
                model.TID = this.Series.Text;

                model.TrainContent = this.txt_TrainContent.Text.ToString();
                model.TrainAddress = this.txt_TrainAddress.Text.ToString();
                model.TType = Convert.ToInt32(this.ddl_TType.SelectedValue.ToString());
                model.TStartDate = this.txt_TStartDate.Text == "" ? Convert.ToDateTime("1900/1/1 0:00:00") : Convert.ToDateTime(this.txt_TStartDate.Text.Trim());
                model.TEndDate = this.txt_TEndDate.Text == "" ? Convert.ToDateTime("1900/1/1 0:00:00") : Convert.ToDateTime(this.txt_TEndDate.Text.Trim());
                model.Isdel = (int)CommonEnum.Deleted.未删除;
                model.AduitState = (int)CommonEnum.AduitState.未审核;
                model.IsReport = (int)CommonEnum.IsorNot.否;


                int result = teachworkExperient.Edit(model);
                if (result == 0)
                {
                    ShowMessage();
                    int log = TWEID == "" ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, (TWEID == "" ? "添加" : "修改") + "任职单位名称为：" + this.txt_TrainAddress.Text + "的信息", UserID));
                }
                else
                {
                    ShowMessage("提交失败");
                    return;
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }
        #endregion

      
        

    }
}