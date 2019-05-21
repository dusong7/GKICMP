/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      gxl
** 创建日期:    2017年08月15日 08时30分
** 描 述:       缴费项目管理页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Data;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using System.Text;
using GK.GKICMP.Entities;


namespace GKICMP.payment
{
    public partial class PayRegistrationEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public Teacher_JournalDAL journalDAL = new Teacher_JournalDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public TeacherDAL teacherDAL = new TeacherDAL();
        public Stu_PhysicalDAL stu_PhysicalDAL = new Stu_PhysicalDAL();

        public PayProjectDAL payProjectDAL = new PayProjectDAL();
        public PayRegistrationDAL payRegistrationDAL = new PayRegistrationDAL();

        #region 参数集合
        public string PRID
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
                //CommonFunction.BindEnum<CommonEnum.IsorNot>(this.ddl_PIID, "-2");

                this.txt_RegCount.Attributes["readonly"] = "true"; //不可编辑

                DataTable dt = payProjectDAL.GetTable((int)CommonEnum.Deleted.未删除, (int)CommonEnum.IsorNot.否);
                CommonFunction.DDlTypeBind(this.ddl_PIID, dt, "PPID", "ProjectName", "-2");
                //CommonFunction.CBLTypeBind(this.ddl_PIID, dt, "PPID", "ProjectName");

                


                //BandData();//绑定学生

                if (PRID != "")
                {
                    InfoBind();
                }
            }
        }
        #endregion

        #region 绑定学生姓名
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

        #region 绑定学生
        /// <summary>
        /// 绑定学生
        /// </summary>
        private void BandData()
        {
            StringBuilder sb = new StringBuilder("");
            string a = MList();
            sb.Append("<script type='text/javascript'>");
            sb.Append(" $(function () {");
            sb.Append(" $('#Series').combotree({");
            sb.Append(" data: [ ");
            sb.Append(a);
            sb.Append("],");
            sb.Append("multiple: false,");
            sb.Append("lines: true,");
            sb.Append("});");
            sb.Append(" }); </script>");
            this.ltl_Content.Text = sb.ToString();
        }

        /// <summary>
        /// 绑定普通班级信息
        /// </summary>
        /// <returns></returns>
        private string MList()
        {
            DataTable dt;
            dt = departmentDAL.GetZNBM((int)CommonEnum.DepType.普通班级, (int)CommonEnum.IsorNot.否);
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
        /// 绑定普通班级人员信息
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
        public string InitChild(string parentID)
        {
            DataTable dt = teacherDAL.GetByDepID(int.Parse(parentID), (int)CommonEnum.UserType.学生, (int)CommonEnum.IsorNot.否);
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

        #region 绑定缴费金额
        protected void ddl_Professional_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataTable pt = payProjectDAL.GetList(this.ddl_PIID.SelectedValue, (int)CommonEnum.Deleted.未删除, Convert.ToInt32(CommonEnum.Deleted.未删除));
            if(pt!=null && pt.Rows.Count>0)
            {
                this.txt_RegCount.Text = pt.Rows[0]["PayCount"].ToString();//缴费金额
            }

        }
        #endregion

        #region 初始化用户数据
        /// <summary>
        /// 初始化用户数据
        /// </summary>
        private void InfoBind()
        {
            PayRegistrationEntity model = payRegistrationDAL.GetObjByID(PRID);
            if (model != null)
            {
                //SetValue(model.StID);//绑定学生姓名
                //this.hf_TID.Value = model.StID;
                this.Series.Text = model.StID;
                this.Series.Enabled = false;

                this.ddl_PIID.SelectedValue = model.PIID.ToString();
                this.txt_RegCount.Text = model.RegCount.ToString();
               
               
            }
        }
        #endregion


        #region 提交
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                PayRegistrationEntity model = new PayRegistrationEntity();
                //if (this.hf_TID.Value == "")
                //{
                //    ShowMessage("学生姓名不能为空");
                //    return;
                //}

                //DataTable dt = departmentDAL.GetZNBM((int)CommonEnum.DepType.普通班级, (int)CommonEnum.IsorNot.否);
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    if (this.hf_TID.Value == dt.Rows[i]["DID"].ToString())
                //    {
                //        ShowMessage("部门不可选做教师");
                //        return;
                //    }
                //}
                //model.StID = this.hf_TID.Value;
                if (this.Series.Text == "")
                {
                    ShowMessage("请选择教师");
                    return;
                }
                model.StID = this.Series.Text;

                model.PRID = PRID;
                model.PIID = this.ddl_PIID.SelectedValue.ToString();
                model.RegCount = Convert.ToDecimal(this.txt_RegCount.Text.Trim());
                model.Isdel = (int)CommonEnum.Deleted.未删除;
                model.CreateUser = UserID;

                int result = payRegistrationDAL.Edit(model);
                if (result > 0)
                {
                    int log = PRID == "" ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, PRID == "" ? "添加" : "修改" + "学生缴费登记信息", UserID));
                    ShowMessage();
                }
                else
                {
                    ShowMessage("保存失败");
                    return;
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