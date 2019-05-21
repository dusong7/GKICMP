/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创 建 人:      樊紫红
** 创建日期:      2017年01月06日 09时52分17秒
** 描    述:      考试科目添加
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
    public partial class SubjectSetEdit : PageBase
    {
        public Exam_SubjectDAL subjectDAL = new Exam_SubjectDAL();
        public CourseDAL courseDAL = new CourseDAL();
        public ExamDAL examDAL = new ExamDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();

        #region 参数集合
        /// <summary>
        /// 考试ID
        /// </summary>
        public int EID
        {
            get
            {
                return GetQueryString<int>("eid", -1);
            }
        }
        public int ESID
        {
            get
            {
                return GetQueryString<int>("esid", -1);
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
                this.hf_EID.Value = EID.ToString();

                ExamEntity model = examDAL.GetObjByID(EID);
                if (model != null)
                {
                    this.hf_begin.Value = model.BeginDate.ToString("yyyy-MM-dd HH:mm:ss");
                    this.hf_end.Value = model.EndDate.ToString("yyyy-MM-dd HH:mm:ss");
                    this.txt_ExamDate.Text = model.BeginDate.ToString("yyyy-MM-dd");
                        DataTable dt = courseDAL.GetList();
                        CommonFunction.DDlTypeBind(this.ddl_CID, dt, "CID", "CourseName", "-2");
                   
                }
                if (ESID != -1) 
                {
                    InfoBind();
                }
            }
        }
        #endregion
        /// <summary>
        /// 考试科目信息绑定（暂未开通，无编辑按钮。后续开发完善。）
        /// </summary>
        public void InfoBind() 
        {
            try
            {
                Exam_SubjectEntity model = subjectDAL.GetObjByID(ESID);
                this.ddl_CID.SelectedValue = model.CID.ToString();
                this.ddl_CID.Enabled = false;
                this.txt_ExamDate.Text = model.BeginDate.ToString("yyyy-MM-dd");
                this.txt_BeginTime.Text = model.BeginDate.ToString("HH:mm");
                this.txt_EndTime.Text = model.EndDate.ToString("HH:mm");
                this.txt_Sorder.Text = model.SOrder.ToString();
            }
            catch (Exception ex)
            {
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志,ex.Message,UserID));
                ShowMessage("数据绑定有误，请稍后再试");
            }
        }
    }
}