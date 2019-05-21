/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      殷志瑞
** 创建日期:    2017年6月14日 18时04分
** 描 述:       著作编辑页面
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

namespace GKICMP.teachermanage
{
    public partial class TeacherJournalEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public Teacher_JournalDAL journalDAL = new Teacher_JournalDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public TeacherDAL teacherDAL = new TeacherDAL();


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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonFunction.BindEnum<CommonEnum.SubjectField>(this.ddl_SubjectArea, "-2");
                CommonFunction.BindEnum<CommonEnum.JournalType>(this.ddl_JournalType, "-2");
                CommonFunction.BindEnum<CommonEnum.IsorNot>(this.rdo_IsReport);
                this.rdo_IsReport.SelectedIndex = 0;                
                if (TPID != "")
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
            Teacher_JournalEntity model = journalDAL.GetObjByID(TPID);
            if (model != null)
            {
                this.txt_PubDate.Enabled = false;
                this.txt_OnwerNum.Text = model.OnwerNum.ToString();
                this.txt_PubDate.Text = model.PubDate.ToString("yyyy-MM-dd");
                //this.hf_TID.Value = model.TID.ToString();
                this.Series.Text = model.TID;
                this.Series.Enabled = false;

                this.txt_PubName.Text = model.PubName;
                this.txt_RewardName.Text = model.RewardName;
                this.txt_TotelNum.Text = model.TotelNum.ToString();
                this.ddl_JournalType.SelectedValue = model.JournalType.ToString();
                this.ddl_SubjectArea.SelectedValue = model.SubjectArea.ToString();
                this.txt_PubNum.Text = model.PubNum;
                this.rdo_IsReport.SelectedValue = model.IsReport.ToString();

                //StringBuilder sb1 = new StringBuilder();
                //sb1.Append("<script type='text/javascript'>");
                //sb1.Append("$(function () {$('#Series').combotree('setValues',['");
                //sb1.Append(this.hf_TID.Value.Trim(','));
                //sb1.Append("']);})</script>");
                //this.ltl_xz.Text = sb1.ToString();
            }
        }
        #endregion


        #region 提交
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = departmentDAL.GetZNBM((int)CommonEnum.DepType.职能部门, (int)CommonEnum.IsorNot.否);
                Teacher_JournalEntity model = new Teacher_JournalEntity();
                model.Isdel = Convert.ToInt32(CommonEnum.IsorNot.否);
                model.IsReport = Convert.ToInt32(this.rdo_IsReport.SelectedValue);
                model.JournalType = Convert.ToInt32(this.ddl_JournalType.SelectedValue);
                model.OnwerNum = Convert.ToInt32(this.txt_OnwerNum.Text);
                if (TPID == "")
                {
                    if (Convert.ToDateTime(this.txt_PubDate.Text) > DateTime.Now)
                    {
                        ShowMessage("出版日期不能超过当前日期，请重新选择");
                        return;
                    }
                }
                model.PubDate = Convert.ToDateTime(this.txt_PubDate.Text);
                model.PubName = this.txt_PubName.Text.Trim();
                model.PubNum = this.txt_PubNum.Text.Trim();
                model.RewardName = this.txt_RewardName.Text.Trim();
                model.SubjectArea = this.ddl_SubjectArea.SelectedValue;
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    if (this.hf_TID.Value == dt.Rows[i]["DID"].ToString())
                //    {
                //        ShowMessage("部门不可选做教师");
                //        return;
                //    }
                //}
                //if (this.hf_TID.Value.Length <= 0)
                //{
                //    ShowMessage("请选择教师");
                //    return;
                //}
                //model.TID = this.hf_TID.Value;

                if (this.Series.Text == "")
                {
                    ShowMessage("请选择教师");
                    return;
                }
                model.TID = this.Series.Text;

                model.TotelNum = Convert.ToInt32(this.txt_TotelNum.Text);
                model.TPID = TPID;
                int result = journalDAL.Edit(model);
                if (result == 0)
                {
                    int log = TPID == "" ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, (TPID == "" ? "添加" : "修改") + "著作名称为：" + this.txt_RewardName.Text + "的信息", UserID));
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