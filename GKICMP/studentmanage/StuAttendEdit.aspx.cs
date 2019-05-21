/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年06月12日 09点30分
** 描   述:       晨检申报页面
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System;
using System.Data;
using System.Text;

namespace GKICMP.studentmanage
{
    public partial class StuAttendEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public StuAttendDAL stuAttendDAL = new StuAttendDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();
        public StudentDAL studentDAL = new StudentDAL();


        #region 参数集合
        public int DID
        {
            get
            {
                return GetQueryString<int>("did", -1);
            }
        }
        public int Deep
        {
            get
            {
                return GetQueryString<int>("deep", -1);
            }
        }
        #endregion


        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Deep == -1)
                {
                    DepartmentEntity model = departmentDAL.GetObjbyuid(UserID);
                    if (model != null)
                    {
                        this.lbl_DID.Text = model.OtherName;
                        this.taboperation.Visible = true;
                        this.lbl_xs.Visible = false;
                        this.hf_DID.Value = model.DID.ToString();
                        this.lbl_CreateDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                        this.lbl_AllIns.Text = studentDAL.GetStuByClass(Convert.ToInt32(this.hf_DID.Value)).Rows.Count.ToString();
                        if (this.hf_DID.Value != "-1")
                        {
                            BindInfo();
                        }
                    }
                    else
                    {
                        this.lbl_xs.Visible = true;
                        this.taboperation.Visible = false;
                        this.lbl_xs.Text = "请选择班级";
                    }
                }
                else
                {
                    if (Deep == 0)
                    {
                        this.lbl_xs.Visible = true;
                        this.taboperation.Visible = false;
                        this.lbl_xs.Text = "请选择班级";
                    }
                    else
                    {
                        DepartmentEntity model = departmentDAL.GetObj(DID);
                        if (model != null)
                        {
                            this.lbl_DID.Text = model.OtherName;
                            this.taboperation.Visible = true;
                            this.lbl_xs.Visible = false;
                            this.hf_DID.Value = DID.ToString();
                            this.lbl_CreateDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                            this.lbl_AllIns.Text = studentDAL.GetStuByClass(Convert.ToInt32(this.hf_DID.Value)).Rows.Count.ToString();
                            if (this.hf_DID.Value != "-1")
                            {
                                BindInfo();
                            }
                        }
                    }
                }
            }
        }
        #endregion


        #region 初始化用户数据
        public void BindInfo()
        {
            StuAttendEntity model = stuAttendDAL.GetObjByID(Convert.ToInt32(this.hf_DID.Value), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")));
            if (model != null)
            {
                this.lbl_CreateDate.Text = model.CreateDate.ToString("yyyy-MM-dd");
                this.lbl_AllIns.Text = model.AllIns.ToString();
                this.txt_RealCOunt.Text = model.RealCOunt.ToString();
                this.hf_LeaveUser.Value = model.LeaveUserName.ToString().TrimEnd(',');
                this.hf_Compassionate.Value = model.CompassionateName.ToString().TrimEnd(',');
                this.hf_Infectious.Value = model.InfectiousName.ToString().TrimEnd(',');
                this.hf_Sick.Value = model.SickName.ToString().TrimEnd(',');
                this.hf_STID.Value = model.STID;
            }
        }
        #endregion


        #region 提交
        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                StuAttendEntity model = new StuAttendEntity();
                model.STID = this.hf_STID.Value;
                model.CreateDate = Convert.ToDateTime(this.lbl_CreateDate.Text);
                model.CreateUser = UserID;
                model.AllIns = Convert.ToInt32(this.lbl_AllIns.Text);
                model.RealCOunt = Convert.ToInt32(this.txt_RealCOunt.Text);
                model.DID = Convert.ToInt32(this.hf_DID.Value);
                model.LeaveUserName = this.hf_LeaveUser.Value.TrimEnd(',');
                model.InfectiousName = this.hf_Infectious.Value.TrimEnd(',');
                model.CompassionateName = this.hf_Compassionate.Value.TrimEnd(',');
                model.SickName = this.hf_Sick.Value.TrimEnd(',');
                if (model.AllIns < model.RealCOunt)
                {
                    ShowMessage("实到人数超过应到人数");
                    return;
                }
                int result = stuAttendDAL.Edit(model);
                if (result == 0)
                {
                    int log = this.hf_STID.Value == "" ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, this.hf_STID.Value == "" ? "添加" : "修改" + "班级为" + this.lbl_DID.Text + "晨检申报信息", UserID));
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