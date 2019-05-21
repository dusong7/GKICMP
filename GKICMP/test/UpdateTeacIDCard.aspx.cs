using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Transactions;
using GK.GKICMP.Common;
using GK.GKICMP.DAL;

namespace GKICMP.test
{
    public partial class UpdateTeacIDCard : System.Web.UI.Page
    {
        public TeacherDAL teacherDAL = new TeacherDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = teacherDAL.GetTeacherByIsDel((int)CommonEnum.IsorNot.否);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script>alert('" + dt.Rows.Count + "');</script>");
            }
        }


        private void UpdataTIDCard()
        {
            DataTable dt = teacherDAL.GetTeacherByIsDel((int)CommonEnum.IsorNot.否);
            if (dt.Rows.Count > 0)
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    int a = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (teacherDAL.UpdateTeacherIDCard(dr["TID"].ToString(), CommonFunction.Decrypt(dr["IDCardNum"].ToString())) > 0)
                        {
                            a += 0;
                        }
                        else
                        {
                            a += 1;
                        }
                     
                    }

                    if (a == 0)
                    {
                        ts.Complete();
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script>alert('更新完成！');</script>");
                    }
                    else
                    {
                        ts.Dispose(); Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script>alert('更新出错！');</script>");
                        return;
                    }
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script>alert('未找到相关数据！');</script>");
                return;
            }

        }

        protected void btrn_tz_Click(object sender, EventArgs e)
        {
            UpdataTIDCard();
        }
    }
}