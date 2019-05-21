using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GK.GKICMP.Common;
using System.DirectoryServices;
using GK.GKICMP.Entities;
using System.Data;
using GK.GKICMP.DAL;

namespace GKICMP.test
{
    public partial class ldap : System.Web.UI.Page
    {
        myDirectory A = new myDirectory();
        public SysUserDAL sysUserDAL = new SysUserDAL();
        //LDAPHelper A = new LDAPHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (A.OpenConnection("LDAP://192.168.134.131:389/dc=test,dc=com", "Miumiu", "111111"))
            //{
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script>alert('系统提示：连接陈功！');</script>");
            //}
            //else 
            //{
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script>alert('系统提示：连接失败！');</script>");
            //}
           //AdHerlp.GetDirectoryEntry1();
           // string ERROR="";
           // A.CheckUidAndPwd("", "Miumiu", "111111", ref ERROR);
            //A.check();
            //List<string> s = A.EnumerateOU();
            //AdHerlp.GetDirectoryEntry();
            //bool result=A.UserExists("MiumiuWu");
            //A.SetPsw("LDAP://192.168.134.131:389/dc=test,dc=com", "uid=Miumiu,ou=Tester,dc=test,dc=com", "111111", "888888");
           // A.CreateNewUser("18226530705", "18226530705", "Liufuzhou", "Tester", "888888");
            //A.Delete();
            //A.CreateNewDep("测试","erewrw");
           // LDapEntity model=new LDapEntity();
           // model.DN = "LDAP://192.168.134.132:389/dc=gkdz,dc=com";
           // model.UserName = "cn=manager,dc=gkdz,dc=com";
           // model.Psw = "secret";
           // model.OU = "Tester";
           ////string a= A.CreateNewDep(model,"软件部","软件研发，销售");
           ////if (a == "")
           ////{
           // //    string b = A.CreateNewUser(model, "13365539539", "俞桂宝", "软件部,Tester", "888888", "俞");
           ////    if (b == "")
           ////    {
           // string b = A.CreateNewUser(model, "admin", "系统管理员", "Tester", "123", "刘");
           //      //  string c = A.ModifyUser(model, "13365539539", "俞桂宝11", "Tester", "111111", "俞");
           ////    }
           ////}
        }

        protected void btn__Click(object sender, EventArgs e)
        {
            DataTable dt = sysUserDAL.GetLDAP();
            if (dt != null && dt.Rows.Count > 0)
            {
                LDapEntity lmodel = new LDapEntity();
                lmodel.Path = dt.Rows[0]["Path"].ToString();
                lmodel.DN = dt.Rows[0]["DN"].ToString();
                lmodel.OU = dt.Rows[0]["OU"].ToString();
                lmodel.UserName = dt.Rows[0]["UserName"].ToString();
                lmodel.Psw = dt.Rows[0]["Psw"].ToString();
                string a = A.CreateNewDep(lmodel, this.txt_DName.Text, this.txt_Desc.Text);
            }
            else 
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script>alert('请先配置LDAP服务！');</script>");
            }
        }

        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            DataTable dt = sysUserDAL.GetLDAP();
            if (dt != null && dt.Rows.Count > 0)
            {
                LDapEntity lmodel = new LDapEntity();
                lmodel.Path = dt.Rows[0]["Path"].ToString();
                lmodel.DN = dt.Rows[0]["DN"].ToString();
                lmodel.OU = dt.Rows[0]["OU"].ToString();
                lmodel.UserName = dt.Rows[0]["UserName"].ToString();
                lmodel.Psw = dt.Rows[0]["Psw"].ToString();
                string a = A.DeleteDep(lmodel, this.txt_DName.Text);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script>alert('请先配置LDAP服务！');</script>");
            }
        }

        protected void btn_DeleteU_Click(object sender, EventArgs e)
        {
            DataTable dt = sysUserDAL.GetLDAP();
            if (dt != null && dt.Rows.Count > 0)
            {
                try
                {
                    LDapEntity lmodel = new LDapEntity();
                    lmodel.Path = dt.Rows[0]["Path"].ToString();
                    lmodel.DN = dt.Rows[0]["DN"].ToString();
                    lmodel.OU = dt.Rows[0]["OU"].ToString();
                    lmodel.UserName = dt.Rows[0]["UserName"].ToString();
                    lmodel.Psw = dt.Rows[0]["Psw"].ToString();
                    string Lresult = A.DeleteUser(lmodel, this.txt_DName.Text);
                    if (Lresult != "")
                    {
                        Lresult = Lresult.Replace("'", "");
                        Lresult = Lresult.Replace("\"", "");
                        Lresult = Lresult.Replace("\r\n", "");
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script>alert('111');</script>");
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script>alert('提交成功');</script>");
                    }
                }
                catch (Exception ex)
                {
                    string MS = ex.Message;
                     MS = ex.Message.Replace("'", "");
                     MS = ex.Message.Replace("\"", "");
                     Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script>alert('"+MS+"');</script>");
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Message", "<script>alert('请先配置LDAP服务！');</script>");
            }
        }
       
    }
}