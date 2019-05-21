/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月07日 09点30分
** 描   述:       统一设置老师
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using System.Data;
using GK.GKICMP.Entities;
using System.Collections.Generic;

namespace GKICMP.educationals
{
    public partial class UnifiedSettingTeacher : PageBase
    {
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public TeacherPlaneDAL teacherPlanDAL = new TeacherPlaneDAL();



        #region 参数集合
        public int GID
        {
            get
            {
                return GetQueryString<int>("gid", -1);
            }
        }
        public int CID
        {
            get
            {
                return GetQueryString<int>("cid", -1);
            }
        }
        public string CIDName
        {
            get
            {
                return GetQueryString<string>("cidname", "");
            }
        }
        #endregion


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt1 = teacherPlanDAL.GetTeacherDetail(GID, CID);
                if (dt1 != null && dt1.Rows.Count > 0)
                {
                    this.lbl_TeacherDetail.Text = dt1.Rows[0]["TeacherDetail"].ToString();
                }
                this.txt_CourseName.Text = CIDName;
                DataTable dt = departmentDAL.GetClass((int)CommonEnum.IsorNot.否, -1, GID);
                CommonFunction.CBLTypeBind(this.ckl_Claid, dt, "DID", "otherName");
            }
        }
        #endregion


        #region 提交
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                string claid = "";
                for (int i = 0; i < ckl_Claid.Items.Count; i++)
                {
                    if (ckl_Claid.Items[i].Selected)
                    {
                        claid += ckl_Claid.Items[i].Value + ",";
                    }
                }
                if (claid == "")
                {
                    ShowMessage("请选择班级");
                    return;
                }
                int result = teacherPlanDAL.Update(claid.TrimEnd(','), CID, this.hf_TID.Value);
                if (result == 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_修改, "修改配置教师信息", UserID));
                    ShowMessage("提交成功");
                    DataTable dt1 = teacherPlanDAL.GetTeacherDetail(GID, CID);
                    if (dt1 != null && dt1.Rows.Count > 0)
                    {
                        this.lbl_TeacherDetail.Text = dt1.Rows[0]["TeacherDetail"].ToString();
                    }
                    this.txt_CourseName.Text = CIDName;
                    DataTable dt = departmentDAL.GetClass((int)CommonEnum.IsorNot.否, -1, GID);
                    CommonFunction.CBLTypeBind(this.ckl_Claid, dt, "DID", "otherName");
                    this.hf_TID.Value = "";
                    // ShowMessage();
                }
                else if (result == -2)
                {
                    ShowMessage("所选班级中有班级已配置过该学科的老师，请检查后重新配置教师");
                    return;
                }
                else
                {
                    ShowMessage("提交失败");
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