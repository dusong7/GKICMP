/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      lfz
** 创建日期:    2017年02月28日
** 描 述:       年级编辑页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Configuration;
using System.Text;
using System.Data;

namespace GKICMP.teachermanage
{
    public partial class TeacherPaperEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SysUserDAL UserDal = new SysUserDAL();
        public DepartmentDAL departmentDal = new DepartmentDAL();
        public SysUserDAL sysUserDal = new SysUserDAL();
        public Teacher_PaperDAL teacher_PaperDAL = new Teacher_PaperDAL();
        #region 参数集合
        public string TPID
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
                //BandData();
                CommonFunction.BindEnum<CommonEnum.URole>(this.ddl_URoles, "-2");//本人角色
                //学科领域
                //论文收录情况
                if (TPID != "")
                {
                    InfoBind();
                    //SetValue();
                }
            }
        }
        #endregion

        #region 设置初始值
        private void SetValue()
        {
            StringBuilder sb1 = new StringBuilder();
            sb1.Append("<script type='text/javascript'>");
            sb1.Append("$(function () {$('#tid').combotree('setValues', [");
            sb1.Append(this.hf_SelectedValue.Value.Trim(','));
            sb1.Append("]);");
            sb1.Append("})</script>");
            this.ltl_xz.Text = sb1.ToString();
        }
        #endregion

        #region 带分组人员绑定
        private void BandData()
        {
            StringBuilder sb = new StringBuilder("");
            string a = MList();
            sb.Append("<script type='text/javascript'>");
            sb.Append(" $(function () {");
            sb.Append(" $('#tid').combotree({");
            sb.Append(" data: [ ");
            sb.Append(a);
            sb.Append("],");
            sb.Append("multiple: false,onlyLeafCheck:true,");
            sb.Append("multiline: true,");
            sb.Append("});");
            sb.Append(" }); </script>");
            this.ltl_JQ.Text = sb.ToString();
        }
        private string MList()
        {
            DataTable dt;
            //获取所有的职能部门，部门类型为职能部门
            dt = departmentDal.GetZNBM((int)CommonEnum.DepType.职能部门, 0);
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
        public string InitChild(string parentID)
        {
            DataTable dt = sysUserDal.GetTeacherByDepID(int.Parse(parentID));//GetSysUserByDepid
            StringBuilder sb = new StringBuilder();
            string name = "";
            if (dt == null)
            {
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

        #region 提交
        /// <summary>
        ///   提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>  
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                Teacher_PaperEntity model = new Teacher_PaperEntity();

                //if (this.hf_SelectedValue.Value == "")
                //{
                //    ShowMessage("请选择姓名");
                //    return;
                //}
                //model.TID = this.hf_SelectedValue.Value;//教师
                if (this.Series.Text == "")
                {
                    ShowMessage("请选择教师");
                    return;
                }
                model.TID = this.Series.Text;

                model.TPID = TPID;
                model.PaperName = this.txt_PaperName.Text;//论文名称
                model.Publication = this.txt_Publication.Text;//发表刊物名称
                model.PubDate = Convert.ToDateTime(this.txt_PubDate.Text);//发表日期
                model.Volume = this.txt_Volume.Text;//卷号
                model.TermNum = this.txt_TermNum.Text;//期号
                model.BeginPage = int.Parse(this.txt_BeginPage.Text);//起始页码
                model.EndPage = int.Parse(this.txt_EndPage.Text);//结束页码
                model.URoles = int.Parse(this.ddl_URoles.SelectedValue);//本人角色
                model.SubjectArea = this.hf_SubjectArea.Value;//学科领域
                model.Included = int.Parse(this.hf_Included.Value);//论文收录情况    
                model.Isdel = 0;
                model.IsReport = 0;
                int result = teacher_PaperDAL.Edit(model);

                if (result == -1)
                {
                    ShowMessage("提交失败");
                    return;
                }
                else if (result == -2)
                {
                    ShowMessage("该论文名称已存在，请重新输入");
                    return;
                }
                else
                {
                    int log = TPID == "" ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, (TPID == "" ? "增加" : "修改") + "论文【" + this.txt_PaperName.Text + "】信息", UserID));
                    ShowMessage();
                }
            }
            catch (Exception error)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, error.Message, UserID));
                ShowMessage(error.Message);
            }
        }
        #endregion

        #region 初始化用户数据
        private void InfoBind()
        {
            try
            {
                Teacher_PaperEntity model = new Teacher_PaperEntity();
                model = teacher_PaperDAL.GetObjByID(TPID);
                if (model != null)
                {
                    //this.hf_SelectedValue.Value = model.TID;//教师
                    this.Series.Text = model.TID;//教师
                    this.Series.Enabled = false;

                    this.txt_PaperName.Text = model.PaperName;//论文名称
                    this.txt_Publication.Text = model.Publication;//发表刊物名称
                    this.txt_PubDate.Text = model.PubDate.ToString("yyyy-MM-dd").ToString();//发表日期
                    this.txt_Volume.Text = model.Volume;//卷号
                    this.txt_TermNum.Text = model.TermNum;//期号
                    this.txt_BeginPage.Text = model.BeginPage.ToString();//起始页码
                    this.txt_EndPage.Text = model.EndPage.ToString();//结束页码
                    this.ddl_URoles.SelectedValue = model.URoles.ToString();//本人角色
                    this.hf_Included.Value = model.Included.ToString();
                    this.hf_SubjectArea.Value = model.SubjectArea;
                    // this.ddl_SubjectArea.SelectedValue = model.SubjectArea.ToString();//学科领域
                    //  this.ddl_Included.SelectedValue = model.Included.ToString();//论文收录情况
                }
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                ShowMessage("请稍候再试");
            }
        }
        #endregion
    }
}