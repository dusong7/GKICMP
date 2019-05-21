/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      lfz
** 创建日期:     2017年03月03日
** 描 述:       基础数据编辑页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Data;
using System.Web.UI.WebControls;
using System.Text;

namespace GKICMP.studentmanage
{
    public partial class StuEvaluateEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        public Stu_EvaluateDAL stu_EvaluateDAL = new Stu_EvaluateDAL();
        public RemarkDAL remarkDAL = new RemarkDAL();
        public SysSetConfigDAL sysSetConfigDAL = new SysSetConfigDAL();
        #region 参数集合
        /// <summary>
        /// TEID
        /// </summary>
        public string SEID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        /// <summary>
        /// TID
        /// </summary>
        //public string TID
        //{
        //    get
        //    {
        //        return GetQueryString<string>("tid", "");
        //    }
        //}
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
            //this.hf_SelectedValue.Value = TID;

            if (!IsPostBack)
            {
                //BandDepart();
                
                CommonFunction.BindEnum<CommonEnum.XQ>(this.ddl_Term,"-2");
                DataTable dt = remarkDAL.GetListByUser(UserID);
                CommonFunction.DDlTypeBindLength(this.slwb, dt, "RemarkContent", "RemarkContent", "-999");
                SysSetConfigEntity smodel = sysSetConfigDAL.GetObjByID();
                this.txt_EYear.Text = smodel.EYear.ToString() ;
                this.ddl_Term.SelectedValue = smodel.NowTerm.ToString();
                //if (DateTime.Now.Month > 8 || DateTime.Now.Month<3)
                //{
                //    this.txt_EYear.Text = DateTime.Now.Year + "-" +( DateTime.Now.Year+1);
                //    this.ddl_Term.SelectedValue =((int)CommonEnum.XQ.上学期).ToString();
                //  //  this.ddl_Term.Enabled = false;
                //}
                //else
                //{
                //    this.txt_EYear.Text = (DateTime.Now.Year-1) + "-" + DateTime.Now.Year;
                //    this.ddl_Term.SelectedValue = ((int)CommonEnum.XQ.下学期).ToString();
                //   // this.ddl_Term.Enabled = false;
                //}
                if (SEID != "")
                {
                    InfoBind();

                }
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


        #region 初始化用户数据
        /// <summary>
        /// 初始化用户数据
        /// </summary>
        private void InfoBind()
        {
            try
            {
                Stu_EvaluateEntity model = stu_EvaluateDAL.GetObjByID(SEID);
                if (model != null)
                {
                    //SetValue(model.StuID);
                    //this.hf_SelectedValue.Value = model.StuID;
                    this.Series.Text = model.StuID;
                    this.Series.Enabled = false;

                    //this.txt_RealName.Text = tmodel.TName;
                    //this.hf_UID.Value = tmodel.TID;//教师
                    // this.TeacherName.Value = tmodel.TID;
                    txt_Evaluate.Text = model.Evaluate;
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
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
                Stu_EvaluateEntity model = new Stu_EvaluateEntity();
                model.SEID = SEID;
                if (this.txt_Evaluate.Text == "")
                {
                    ShowMessage("评语不能为空");
                    return;
                }
                model.Evaluate = this.txt_Evaluate.Text;
                //model.StuID = this.hf_SelectedValue.Value;
                if (this.Series.Text == "")
                {
                    ShowMessage("请选择学生");
                    return;
                }
                if (this.Series.Text.Length > 2000) {
                    ShowMessage("选择学生过多，请重新选择");
                    return;
                }
                model.StuID = this.Series.Text;
                
                model.Term = int.Parse(this.ddl_Term.SelectedValue);
                model.EYear = this.txt_EYear.Text;
                model.CreateDate = DateTime.Now;
                model.CreateUser = UserID;
                if (cb_IsOrNot.Checked) 
                {
                    RemarkEntity rmodel = new RemarkEntity();
                    rmodel.RID =-1;
                    rmodel.RemarkContent = this.txt_Evaluate.Text.Trim();//
                    rmodel.CreateUser = UserID;
                    rmodel.Isdel = (int)CommonEnum.Deleted.未删除;

                    int R = remarkDAL.Add(rmodel);
                }
                int result = stu_EvaluateDAL.Edit(model);
                if (result == -2)
                {
                    ShowMessage("每学年每学期下每位学生只能录入一条评语记录");
                    return;
                    
                }
                else
                {
                    ShowMessage();
                    int log = SEID == "" ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, (SEID == "" ? "添加" : "修改") + "学生评语信息", UserID));
                }
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                ShowMessage(ex.Message);
            }
        }
        #endregion
    }
}