
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
using System.Data;

namespace GKICMP.studentmanage
{
    public partial class StudentElderEdit : PageBase
    {
        public StuElderDAL stuElderDAL = new StuElderDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public StudentDAL studentDAL = new StudentDAL();
        #region 参数集合
        public string StuID
        {
            get
            {
                return GetQueryString<string>("sid", "");
            }
        }
        public string PID
        {
            get
            {
                return GetQueryString<string>("id", "");
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                if (StuID != "") 
                {
                    StudentEntity model = studentDAL.GetObjByID(StuID);
                    this.ltl_RealName.Text = model.RealName;
                }
                if (PID != "")
                {
                    BindInfo();
                }
            }
        }
        public void BindInfo() 
        {
            StuElderEntity model = stuElderDAL.GetObjByID(PID);
            if (model != null)
            {
                this.txt_ElderName.Text = model.ElderName;
                this.txt_CellPhone.Text = model.CellPhone;
                this.txt_PostDep.Text = model.PostDep;
                this.txt_PostName.Text = model.PostName;
                this.txt_ShipName.Text = model.ShipName;
            }
            else
            {
                ShowMessage("查询出错，请稍后再试");
                this.btn_Sumbit.Visible = false;
            }
        }

        protected void btn_Sumbit_Click(object sender, EventArgs e)
        {
            try
            {
                StuElderEntity model = new StuElderEntity();
                model.PID = PID;
                model.StuID = StuID;
                model.ElderName = this.txt_ElderName.Text;
                model.CellPhone = this.txt_CellPhone.Text;
                model.PostDep = this.txt_PostDep.Text;
                model.PostName = this.txt_PostName.Text;
                model.ShipName = this.txt_ShipName.Text;
                model.CreateUser = UserID;
                model.CreateDate = DateTime.Now;
                model.Isdel = (int)CommonEnum.IsorNot.否;
                model.Epwd = CommonFunction.Encrypt("888888");
                int result = stuElderDAL.Edit(model);
                if (result > 0)
                {
                    int log = PID == "" ? (int)CommonEnum.LogType.操作日志_添加 : (int)CommonEnum.LogType.操作日志_修改;
                    sysLogDAL.Edit(new SysLogEntity(log, PID == "" ? "添加" : "修改" + "学生家庭成员信息", UserID));
                    ShowMessage();
                }
                else
                {
                    ShowMessage("提交失败");
                    return;
                }
            }
            catch (Exception ex)
            {
                 sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.系统日志,ex.Message, UserID));
                 ShowMessage(ex.Message);
                 return;
            }
        }
    }
}