using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using System.Data;
using GK.GKICMP.Entities;

namespace GKICMP.appstu
{
    public partial class CourseDetail : PageBaseApp
    {
        public ECourseDAL eCourseDAL = new ECourseDAL();
        public Electiver_StuDAL electiver_StuDAL = new Electiver_StuDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        
        #region 参数集合
        public int CID
        {
            get
            {
                return GetQueryString<int>("id", 0);
            }
        }
        public int EleID
        {
            get
            {
                return GetQueryString<int>("eleid", 0);
            }
        }
        public int Flag
        {
            get
            {
                return GetQueryString<int>("flag", 0);
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (CID != 0) 
                {
                    InfoBind();
                }
            }
        }
        public void InfoBind() 
        {
            DataTable dt = eCourseDAL.GetTable(CID, UserID, EleID);
            if (dt != null&&dt.Rows.Count>0)
            {
                this.ltl_CourseName.Text = dt.Rows[0]["CourseName"].ToString();
                this.ltl_CourseDesc.Text = dt.Rows[0]["CourseDesc"].ToString();
                if (Flag != 1)
                {
                    if (dt.Rows[0]["ZT"].ToString() == "0")
                    {
                        if (dt.Rows[0]["DY"].ToString() == "0")
                        {
                            int result = electiver_StuDAL.Check(UserID,EleID);
                            if (result > 0)
                                this.btn_Submit.Text = "选课";
                            else
                                this.btn_Submit.Visible = false;
                        }
                        else
                        {
                            //s if (dt.Rows[0]["TD"].ToString() == "0")
                            this.btn_Submit.Text = "退课";
                            //else
                            //    this.btn_Submit.Text = "确认";
                        }
                    }
                    else
                        this.btn_Submit.Visible = false;
                }
                else
                    this.btn_Submit.Visible = false;
            }
           
        }

        protected void btn_CY_Click(object sender, EventArgs e)
        {
            try
            {
                Electiver_StuEntity model = new Electiver_StuEntity();
                model.ESID = 0;
                model.EleID = EleID;
                model.CorseID = CID;
                model.StuID = UserID;
                model.EleDate = DateTime.Now;
                //model.EType = 1;//需修改
                //model.GroupID = 0;
                if (this.btn_Submit.Text == "退课")
                    model.IsBack = 1;
                else
                    model.IsBack = 0;
                int result = electiver_StuDAL.Edit(model);
                if (result > 0)
                {
                    sysLogDAL.Edit(new SysLogEntity((int)CommonEnum.LogType.操作日志_添加, "添加" + (this.btn_Submit.Text == "退课"?"退课":"选课") + "信息", UserID));
                    ClientScript.RegisterStartupScript(GetType(), "Message", "<script>alert('提交成功');window.location='ElectiverStu.aspx?id=" + EleID + "'</script>");
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
    }
}