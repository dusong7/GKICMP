/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      殷志瑞
** 创建日期:      2017年07月3日 09点30分
** 描   述:       作业布置页面
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
using System.Web.UI.WebControls;

namespace GKICMP.office
{
    public partial class HomeWorkEdit : PageBase
    {
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public HomeWorkDAL homeWorkDAL = new HomeWorkDAL();
        public CourseDAL courseDAL = new CourseDAL();
        public DepartmentDAL departmentDAL = new DepartmentDAL();


        #region 参数集合
        public string HWID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        #endregion



        #region 初始化页面
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = courseDAL.GetCourseAll(UserID);
                CommonFunction.DDlTypeBind(this.ddl_CID, dt, "CID", "CourseName", "-2");
                CommonFunction.BindEnum<CommonEnum.IsorNot>(this.rbl_IsorNo);
                this.rbl_IsorNo.SelectedIndex = 0;
                DataTable dt1 = departmentDAL.GetClaIDByTID(UserID);
                CommonFunction.CBLTypeBind(this.chk_ClaID, dt1, "ClaID", "ClaIDName");
                if (HWID != "")
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
                HomeWorkEntity model = new HomeWorkEntity();
                model.CID = Convert.ToInt32(this.ddl_CID.SelectedValue);
                model.HWID = HWID;
                model.IsSend = Convert.ToInt32(this.rbl_IsorNo.SelectedValue);
                model.HomeWork = this.txt_HomeWork.Text.Trim();
                model.CompleteTime = Convert.ToInt32(this.txt_CompleteTime.Text.Trim());
                model.CreateUser = UserID;
                string Claids = "";
                if (chk_ClaID != null && chk_ClaID.Items.Count > 0)
                {
                    for (int i = 0; i < this.chk_ClaID.Items.Count; i++)
                    {
                        if (chk_ClaID.Items[i].Selected)
                        {

                            Claids += chk_ClaID.Items[i].Value + ",";
                            this.hf_ClaidName.Value += chk_ClaID.Items[i].Text + ",";
                        }
                    }
                }
                else
                {
                    ShowMessage(UserRealName + "老师没有班级，请先添加自己所带的班级");
                    return;
                }
                model.ClaName = this.hf_ClaidName.Value.TrimEnd(',');
                model.Claids = Claids.TrimEnd(',');
                if(model .Claids =="")
                {
                    ShowMessage("请选择班级");
                    return;
                }
                int result = homeWorkDAL.Edit(model);
                if (result == 0)
                {
                    int log = HWID == "" ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, HWID == "" ? "添加" : "修改" + "作业布置信息", UserID));
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



        #region 初始化用户数据
        public void BindInfo()
        {
            HomeWorkEntity model = homeWorkDAL.GetObjByID(HWID);
            if (model != null)
            {
                this.txt_CompleteTime.Text = model.CompleteTime.ToString();
                this.txt_HomeWork.Text = model.HomeWork;
                this.rbl_IsorNo.SelectedValue = model.IsSend.ToString();
                this.ddl_CID.SelectedValue = model.CID.ToString();
                string[] arr = model.Claids.TrimEnd(',').Split(',');  
                foreach (string dr in arr)
                {
                    foreach (ListItem li in this.chk_ClaID.Items)
                    {
                        if (dr == li.Value)
                        {
                            li.Selected = true;
                        }
                    }
                }
            }
        }
        #endregion
    }
}