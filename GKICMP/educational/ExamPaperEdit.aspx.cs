/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年01月06日 09时52分17秒
** 描    述:      题目编辑页面
** 修 改 人:      
** 修改日期:    
** 修改说明: 
**-----------------------------------------------------------------
*****************************************************************/
using System;
using System.Data;

using GK.GKICMP.DAL;
using GK.GKICMP.Common;
using GK.GKICMP.Entities;
using System.Text;

namespace GKICMP.educational
{
    public partial class ExamPaperEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public ExamPaperDAL examPaperDAL = new ExamPaperDAL();
        public CourseDAL courseDAL = new CourseDAL();


        #region 参数集合
        public string EPID
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
                CommonFunction.BindEnum<CommonEnum.XQ>(this.ddl_Term, "-99");
                CommonFunction.BindEnum<CommonEnum.NJ>(this.ddl_GradeID, "-99");
                DataTable dtCourse = courseDAL.GetList();
                CommonFunction.DDlTypeBind(this.ddl_CourseName, dtCourse, "CID", "CourseName", "-999");
                if (EPID != "")
                {
                    BindInfo();
                }
            }
        }
        #endregion


        #region 提交
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                ExamPaperEntity model = new ExamPaperEntity();
                model.CID = Convert.ToInt32(this.ddl_CourseName.SelectedValue);
                model.CreateUser = UserID;
                model.EPID = EPID;
                model.GradeID = Convert.ToInt32(this.ddl_GradeID.SelectedValue);
                model.Minutes = Convert.ToInt32(this.txt_Minutes.Text.Trim());
                model.PaperName = this.txt_PaperName.Text.Trim();
                model.Term = Convert.ToInt32(this.ddl_Term.SelectedValue);
                model.EType = EPID == "" ? (int)CommonEnum.SCFS.手动生成 : (int)CommonEnum.SCFS.自动生成;
                int result = examPaperDAL.Edit(model, this.hf_EID.Value);
                if (result == 0)
                {
                    ShowMessage();
                    int log = EPID == "" ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, EPID == "" ? "添加" : "修改" + "试卷名称为：" + this.txt_PaperName.Text + "的信息", UserID));
                }
                else if (result == -2)
                {
                    ShowMessage(this.ddl_GradeID.SelectedItem + this.ddl_Term.SelectedItem.ToString() + this.ddl_CourseName.SelectedItem + this.txt_PaperName.Text + "试卷已存在");
                    return;
                }
                else
                {
                    ShowMessage("保存失败");
                    return;
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
            }
        }
        #endregion


        #region 初始化用户数据
        public void BindInfo()
        {
            ExamPaperEntity model = examPaperDAL.GetObjByID(EPID);
            if (model != null)
            {
                this.txt_Minutes.Text = model.Minutes.ToString();
                this.txt_PaperName.Text = model.PaperName;
                this.ddl_CourseName.SelectedValue = model.CID.ToString();
                this.ddl_GradeID.SelectedValue = model.GradeID.ToString();
                this.ddl_Term.SelectedValue = model.Term.ToString();
                this.tr.Visible = false;
                this.ddl_CourseName.Enabled = false;
                this.ddl_GradeID.Enabled = false;
                this.ddl_Term.Enabled = false;
            }
        }
        #endregion
    }
}