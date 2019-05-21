/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      lfz
** 创建日期:    2017年02月27日
** 描 述:       考核信息编辑页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/

using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;


using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;


namespace GKICMP.teachermanage
{
    public partial class TeacherAssessmentEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public BaseDataDAL baseDataDAL = new BaseDataDAL();
        public Teacher_AssessmentDAL teacherAssessment = new Teacher_AssessmentDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public TeacherDAL teacherDAL = new TeacherDAL();

        #region 参数集合
        /// <summary>
        /// TEID
        /// </summary>
        public string TAID
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
        public int Flag
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
              
                DDLBind();                 
                if (TAID != "")
                {
                    InfoBind();

                }
            }
        }
        #endregion

        #region 下拉框绑定
        /// <summary>
        /// 下拉框绑定
        /// </summary>
        private void DDLBind()
        {
            //DataTable HS = baseDataDAL.GetList((int)CommonEnum.BaseDataType.考核结果, -1);
            //CommonFunction.DDlTypeBind(this.ddl_AssResult, HS, "SDID", "DataName", "-2");

            CommonFunction.BindEnum<CommonEnum.KHJG>(this.ddl_AssResult, "-2");//考核结果
        }
        #endregion

        //private void SetValue(string TID)
        //{
        //    StringBuilder sb1 = new StringBuilder();
        //    sb1.Append("<script type='text/javascript'>");
        //    sb1.Append("$(function () {$('#TeacherName').combotree('setValue', '");
        //    sb1.Append(TID);
        //    sb1.Append("');");
        //    sb1.Append("$('#TeacherName').combotree('disable');");
        //    sb1.Append("})</script>");
        //    this.ltl_xz.Text = sb1.ToString();
        //}

        ////#region 教师绑定
        /////// <summary>
        /////// 教师绑定
        /////// </summary>
        ////private void BandDepart()
        ////{
        ////    StringBuilder sb = new StringBuilder("");
        ////    string a = DepartList();
        ////    sb.Append("<script type='text/javascript'>");
        ////    sb.Append(" $(function () {");
        ////    sb.Append(" $('#TeacherName').combotree({");
        ////    sb.Append(" data:[");
        ////    sb.Append(a);
        ////    sb.Append("],");
        ////    sb.Append("multiple: false,");
        ////    sb.Append("multiline: false,");
        ////    sb.Append("});");
        ////    sb.Append(" }); </script>");

        ////    this.ltl_JQ.Text = sb.ToString();

        ////}
        ////private string DepartList()
        ////{
        ////    DataTable dt;
        ////    dt = sysUserDAL.GetSysUserByType((int)CommonEnum.UserType.老师, (int)CommonEnum.Deleted.未删除);
        ////    string name = string.Empty;
        ////    StringBuilder sb = new StringBuilder();
        ////    if (dt.Rows.Count > 0)
        ////    {
        ////        for (int i = 0; i < dt.Rows.Count; i++)
        ////        {
        ////            name += "{\"id\":\"" + dt.Rows[i]["UID"].ToString() +
        ////               "\",\"text\":\"" + dt.Rows[i]["RealName"].ToString() + "\"},";
        ////        }
        ////    }
        ////    sb.Append(name.ToString().TrimEnd(','));
        ////    return sb.ToString();
        ////}
        ////#endregion

        //#region 带部门的教师绑定
        ///// <summary>
        ///// 带部门的教师绑定
        ///// </summary>
        //private void BandDepart()
        //{
        //    StringBuilder sb = new StringBuilder("");
        //    string a = MList();
        //    sb.Append("<script type='text/javascript'>");
        //    sb.Append(" $(function () {");
        //    sb.Append(" $('#TeacherName').combotree({");
        //    sb.Append(" data: [ ");
        //    sb.Append(a);
        //    sb.Append("],");
        //    sb.Append("multiple: true,");
        //    sb.Append("lines: true,");
        //    sb.Append("});");
        //    sb.Append(" }); </script>");
        //    this.ltl_JQ.Text = sb.ToString();
        //}

        ///// <summary>
        ///// 绑定职能部门信息
        ///// </summary>
        ///// <returns></returns>
        //private string MList()
        //{
        //    DataTable dt;
        //    dt = departmentDAL.GetZNBM((int)CommonEnum.DepType.职能部门, (int)CommonEnum.IsorNot.否);
        //    string name = string.Empty;
        //    if (dt == null)
        //    {
        //        name = "[]";
        //    }
        //    StringBuilder sb = new StringBuilder();
        //    if (dt.Rows.Count > 0)
        //    {
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            name += "{\"id\":\"" + dt.Rows[i]["DID"].ToString() +
        //               "\",\"text\":\"" + dt.Rows[i]["DepName"].ToString() + "\",";
        //            //调用递归方法
        //            name += InitChild(dt.Rows[i]["DID"].ToString());
        //            name += "},";
        //        }
        //    }
        //    sb.Append(name.ToString().TrimEnd(','));
        //    return sb.ToString();
        //}

        ///// <summary>
        ///// 绑定职能部门人员信息
        ///// </summary>
        ///// <param name="parentID"></param>
        ///// <returns></returns>
        //public string InitChild(string parentID)
        //{
        //    DataTable dt = teacherDAL.GetByDepID(int.Parse(parentID), (int)CommonEnum.UserType.老师, (int)CommonEnum.IsorNot.否);
        //    StringBuilder sb = new StringBuilder();
        //    string name = "";
        //    if (dt == null)
        //    {
        //        //
        //    }

        //    if (dt.Rows.Count > 0)
        //    {
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            name += "{\"id\":\"" + dt.Rows[i]["UID"].ToString() +
        //               "\",\"text\":\"" + dt.Rows[i]["RealName"].ToString() + "\"},";
        //        }
        //    }
        //    sb.Append("\"children\":[");
        //    sb.Append(name.ToString().TrimEnd(','));
        //    sb.Append("]");
        //    return sb.ToString();
        //}
        //#endregion


        #region 初始化用户数据
        /// <summary>
        /// 初始化用户数据
        /// </summary>
        private void InfoBind()
        {
            Teacher_AssessmentEntity tmodel = teacherAssessment.GetObjByID(TAID);
            if (tmodel != null)
            {
                //this.txt_RealName.Text = tmodel.TName;
                //this.hf_UID.Value = tmodel.TID;//教师
                //this.TeacherName.Value = tmodel.TName;

                //SetValue(tmodel.TID);//绑定教师姓名
                this.hf_SelectedValue.Value = tmodel.TID;
                this.ddl_AssResult.SelectedValue = tmodel.AssResult.ToString();

                //this.txt_TSYear.Text = tmodel.TSYear.ToString() == "1990/1/1 0:00:00" ? "" : tmodel.TSYear.ToString("yyyy");
                this.txt_TSYear.Text = tmodel.TSYear == null ? "" : tmodel.TSYear.ToString("yyyy");
                this.txt_TSDesc.Text = tmodel.TSDesc == null ? "" : tmodel.TSDesc.ToString();
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
                Teacher_AssessmentEntity model = new Teacher_AssessmentEntity();
                model.TAID = TAID;
                if (this.hf_SelectedValue.Value == "")
                {
                    ShowMessage("教师姓名不能为空");
                    return;
                }
                model.TID = this.hf_SelectedValue.Value;//教师
                //model.TID = this.hf_UID.Value;//教师
                model.TSYear = Convert.ToDateTime(this.txt_TSYear.Text + "-01-01 0:00:00");//年份
                model.AssResult = Convert.ToInt32(this.ddl_AssResult.SelectedValue.ToString());//考核结果
                model.TSDesc = this.txt_TSDesc.Text.ToString(); //备注
                model.AduitState = (int)CommonEnum.AduitState.未审核;//审核状态

                model.TFlag = Flag;//标识 1年度考核  2 师德考核

                model.Isdel = (int)CommonEnum.Deleted.未删除;
                model.IsReport = (int)CommonEnum.IsorNot.否;

                int result = teacherAssessment.Edit(model);
                if (result == 0)
                {
                    int log =TAID == "" ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, (TAID == "" ? "添加" : "修改") + "名为：" + this.txt_TSDesc.Text + "的考核信息", UserID));
                    if (Flag == 1)
                    {
                        ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('保存成功！');window.location.href='TeacherAssessmentManage.aspx?Flag=1'</script>");
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('保存成功！');window.location.href='TeacherAssessmentManage.aspx?Flag=2'</script>");
                    }

                   
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