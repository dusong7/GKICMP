/*****************************************************************
** Copyright (c) 芜湖市高科电子有限公司
** 创建人:      yzr
** 创建日期:    2017年02月27日
** 描 述:       选课课程编辑页面
** 修改人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using GK.GKICMP.Common;
using System;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Data;

namespace GKICMP.electiver
{
    public partial class ECourseEdit : PageBase
    {
        public SysDataDAL sysDataDAL = new SysDataDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public ECourseDAL ecourseDAL = new ECourseDAL();
        public BaseDataDAL baseDataDAL = new BaseDataDAL();


        #region 页面参数
        public int CID
        {
            get
            {
                return GetQueryString<int>("id", -1);
            }
        }
        #endregion


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = sysDataDAL.GetList((int)CommonEnum.IsorNot.否, (int)CommonEnum.DataType.课程类别);
                CommonFunction.DDlTypeBind(this.ddl_CourseType, dt, "SDID", "DataName", "-2");
                DataTable dt1 = baseDataDAL.GetList((int)CommonEnum.BaseDataType.课程等级, -1);
                CommonFunction.DDlTypeBind(this.ddl_CourseGrade, dt1, "SDID", "DataName", "-2");
                if (CID != -1)
                {
                    BindInfo();
                }
            }
        }
        #endregion

        #region 初始化用户数据
        public void BindInfo()
        {
            ECourseEntity model = ecourseDAL.GetObjByID(CID);
            if (model != null)
            {
                this.txt_CourseDesc.Text = model.CourseDesc;
                this.txt_CourseName.Text = model.CourseName;
                this.txt_CourseOther.Text = model.CourseOther;
                this.ddl_CourseGrade.SelectedValue = model.CourseGrade.ToString();
                this.ddl_CourseType.SelectedValue = model.CourseType.ToString();
            }
        }
        #endregion


        #region 提交
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                ECourseEntity model = new ECourseEntity();
                model.CourseOther = this.txt_CourseOther.Text.Trim();
                model.CourseName = this.txt_CourseName.Text.Trim();
                model.CourseGrade = Convert.ToInt32(this.ddl_CourseGrade.SelectedValue);
                model.CourseType = Convert.ToInt32(this.ddl_CourseType.SelectedValue);
                model.CourseDesc = this.txt_CourseDesc.Text.Trim();
                model.CID = CID;
                model.Isdel = (int)CommonEnum.IsorNot.否;
                int result = ecourseDAL.Edit(model);
                if (result == 0)
                {
                    int logotype = CID == -1 ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(logotype, CID == -1 ? "添加" : "修改" + "课程编码：" + this.txt_CourseOther.Text, UserID));
                    ShowMessage();
                }
                else if (result == -2)
                {
                    ShowMessage("课程编码已存在");
                    return;
                }
                else if (result == -3)
                {
                    ShowMessage("课程名称和课程等级已存在");
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
                sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志, ex.Message, UserID));
                ShowMessage(ex.Message);
            }
        }
        #endregion
    }
}