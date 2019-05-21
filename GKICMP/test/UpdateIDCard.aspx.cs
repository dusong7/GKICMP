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
    public partial class UpdateIDCard : System.Web.UI.Page
    {
        public TeacherDAL teacherDAL = new TeacherDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public SysUserDAL sysUserDAL = new SysUserDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = sysUserDAL.GetSysUserByType((int)CommonEnum.UserType.老师, (int)CommonEnum.IsorNot.否);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script>alert('" + dt.Rows.Count + "');</script>");
            }
        }


        private void UpdataTIDCard()
        {
            DataTable dt = sysUserDAL.GetSysUserByType((int)CommonEnum.UserType.老师, (int)CommonEnum.IsorNot.否);
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script>alert('" + dt.Rows.Count + "');</script>");
            if (dt.Rows.Count > 0)
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    int a = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        //string aaa = CommonFunction.Decrypt(dr["IDCard"].ToString());
                        //string bbb = dr["UID"].ToString();

                        //if (dr["IDCard"].ToString().Length > 18)
                        //{
                            if (sysUserDAL.UpdateIDCard(dr["UID"].ToString(), CommonFunction.Decrypt(dr["IDCard"].ToString())) > 0)
                            {
                                a += 0;
                            }
                            else
                            {
                                a += 1;
                            }
                        //}

                       
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