using GK.GKICMP.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GK.GKICMP.Common
{
    public static class AdHerlp
    {
        #region 创建AD连接
        /// <summary>  
        /// 创建AD连接  
        /// </summary>  
        /// <returns></returns>  
        public static DirectoryEntry GetDirectoryEntry()
        {
            DirectoryEntry entry = new DirectoryEntry("LDAP://192.168.134.132:389/dc=gkdz,dc=com", "cn=manager,dc=gkdz,dc=com", "secret", AuthenticationTypes.None);

            try
            {
                object native = entry.NativeObject;

            }
            catch (System.Exception ex)
            {
                throw new Exception("Error authenticating user." + ex.Message);
            }
            return entry;

        }
        public static DirectoryEntry GetDirectoryEntry(LDapEntity model)
        {
            DirectoryEntry entry = new DirectoryEntry(model.Path+model.DN, model.UserName, model.Psw, AuthenticationTypes.None);

            try
            {
                object native = entry.NativeObject;

            }
            catch (System.Exception ex)
            {
                throw new Exception( ex.Message);
            }
            return entry;

        }
        #endregion

        #region 获取目录实体集合
        /// <summary>  
        ///  
        /// </summary>  
        /// <param name="DomainReference"></param>  
        /// <returns></returns>  
        public static DirectoryEntry GetDirectoryEntry(string DomainReference)
        {
            DirectoryEntry entry = new DirectoryEntry(DomainReference, "cn=Manager,dc=gkdz,dc=com", "secret", AuthenticationTypes.None);
            return entry;
        }
        public static DirectoryEntry GetDirectoryEntry(string DomainReference, LDapEntity model)
        {
            DirectoryEntry entry = new DirectoryEntry(DomainReference, model.UserName, "secret", AuthenticationTypes.None);
            return entry;
        }
        #endregion
    }  
    public  class myDirectory  
    {
        public string GetDirectoryEntry(LDapEntity model) 
        {
            //DirectorySearcher ds = new DirectorySearcher(model);
            //ds.Filter = "(&(objectClass=inetOrgPerson)(uid=" + uid + "))";
            //ds.SearchScope = SearchScope.Subtree;
            //SearchResult results = ds.FindOne();
            DirectoryEntry entry = new DirectoryEntry(model.Path+model.DN, model.UserName+","+model.OU+","+model.DN, model.Psw, AuthenticationTypes.None);

            try
            {
                object native = entry.NativeObject;
                entry.Close();
            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }
            return "";
        }
        #region 添加部门
        /// <summary>
        /// 添加部门
        /// </summary>
        /// <param name="dname">部门名称</param>
        /// <param name="description">说明</param>
        public string CreateNewDep(LDapEntity model, string dname, string description)
        {
            try
            {
                DirectoryEntry de = AdHerlp.GetDirectoryEntry(model);
                DirectoryEntries users = de.Children;
                DirectoryEntry newEntry = users.Add("ou=" + dname, "organizationalUnit");
                using (newEntry)
                {
                    newEntry.Properties["ou"].Add(dname);
                    newEntry.Properties["objectClass"].Value = new string[] { "organizationalUnit" };
                    newEntry.Properties["description"].Add(description);
                    newEntry.CommitChanges();
                }
                newEntry.Close();
                de.Close();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "";
        }
        #endregion

        #region 创建一个新用户
        /// <summary>
        /// 创建一个新用户
        /// </summary>
        /// <param name="uid">登录名</param>
        /// <param name="cn">姓名</param>
        /// <param name="ou">部门</param>
        /// <param name="psw">密码</param>
        /// <param name="sn">姓</param>
        public string CreateNewUser(LDapEntity model, string uid, string cn, string ou, string psw, string sn)
        {
            try
            {
                DirectoryEntry de = AdHerlp.GetDirectoryEntry(model);
                DirectoryEntries users = de.Children;
                //string[] a = ou.Split(',');
                //string dep = "";
                //if (a.Length > 0) 
                //{
                //    foreach (string o in a) 
                //    {
                //        dep += "ou=" + o + ",";
                //    }
                //    dep = dep.TrimEnd(',');
                //}
                DirectoryEntry newEntry = users.Add("uid=" + uid + "," + model.OU + "", "inetOrgPerson");
                using (newEntry)
                {
                    newEntry.Properties["ou"].Add(ou);//部门
                    newEntry.Properties["uid"].Add(uid);//登录id
                    newEntry.Properties["cn"].Add(cn);//姓名
                    newEntry.Properties["objectClass"].Value = new string[] { "inetOrgPerson" };//objectclass
                    newEntry.Properties["userPassword"].Add(psw);//密码
                    newEntry.Properties["sn"].Add(sn); //姓
                    newEntry.CommitChanges();
                }
                newEntry.Close();
                de.Close();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "";
        }
        #endregion

        #region 修改用户信息
        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <param name="cn">姓名</param>
        /// <param name="ou">部门</param>
        /// <param name="psw">密码</param>
        /// <param name="sn">姓</param>
        /// <returns></returns>
        public string ModifyUser(LDapEntity model,string uid, string cn, string ou, string psw, string sn)
        {
            try
            {
                DirectoryEntry de = AdHerlp.GetDirectoryEntry(model);
                DirectorySearcher ds = new DirectorySearcher(de);
                ds.Filter = "(&(objectClass=inetOrgPerson)(uid=" + uid + "))";
                ds.SearchScope = SearchScope.Subtree;
                SearchResult results = ds.FindOne();

                if (results != null)
                {
                    DirectoryEntry dey = AdHerlp.GetDirectoryEntry(results.Path, model);
                    SetProperty(dey, "ou", ou);
                    SetProperty(dey, "cn", cn);
                    SetProperty(dey, "sn", sn);
                    SetProperty(dey, "userPassword", psw);
                    dey.CommitChanges();
                    dey.Close();
                }
                else 
                {
                    CreateNewUser(model, uid, cn, ou, psw, sn);
                }

                de.Close();
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
            return "";
        }

        #endregion

        #region 删除用户
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="uid">用户登录名</param>
        /// <returns></returns>
        public string DeleteUser(LDapEntity model, string uid)
        {
            try
            {
                DirectoryEntry de = AdHerlp.GetDirectoryEntry(model);
                DirectorySearcher ds = new DirectorySearcher(de);
                ds.Filter = "(&(objectClass=inetOrgPerson)(uid=" + uid + "))";
                ds.SearchScope = SearchScope.Subtree;
                SearchResult results = ds.FindOne();

                if (results != null)
                {
                    DirectoryEntry dey = AdHerlp.GetDirectoryEntry(results.Path,model);
                    DirectoryEntry d = AdHerlp.GetDirectoryEntry(dey.Parent.Path, model);
                    d.Children.Remove(dey);
                    dey.CommitChanges();
                    dey.Close();
                }

                de.Close();
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
            return "";
        }
        #endregion

        #region 删除部门
        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="dep">部门名称</param>
        /// <returns></returns>
        public string DeleteDep(LDapEntity model, string dep)
        {
            try
            {
                DirectoryEntry de = AdHerlp.GetDirectoryEntry(model);
                DirectorySearcher ds = new DirectorySearcher(de);
                ds.Filter = "(&(objectClass=organizationalUnit)(ou=" + dep + "))";
                ds.SearchScope = SearchScope.Subtree;
                SearchResult results = ds.FindOne();

                if (results != null)
                {
                    DirectoryEntry dey = AdHerlp.GetDirectoryEntry(results.Path);
                    de.Children.Remove(dey);
                   // dey.CommitChanges();
                    dey.Close();
                }

                de.Close();
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
            return "";
        }
        #endregion

        /// <summary>  
        /// 判断用户是否存在  
        /// </summary>  
        /// <param name="UserName"></param>  
        /// <returns></returns>  
        public bool UserExists(string UserName)  
        {  
            DirectoryEntry de = AdHerlp.GetDirectoryEntry();  
            DirectorySearcher deSearch = new DirectorySearcher();  
            deSearch.SearchRoot = de;
            deSearch.Filter = "(&(objectClass=inetOrgPerson) (cn=" + UserName + "))";  
            SearchResultCollection results = deSearch.FindAll();  
            if (results.Count == 0)  
            {  
                return false;  
            }  
            else  
            {  
                return true;  
            }  
        }  
        /// <summary>  
        /// 修改用户属性  
        /// </summary>  
        /// <param name="de"></param>  
        /// <param name="PropertyName"></param>  
        /// <param name="PropertyValue"></param>  
        public static void SetProperty(DirectoryEntry de, string PropertyName, string PropertyValue)  
        {  
            if (PropertyValue != null)  
            {  
                if (de.Properties.Contains(PropertyName))  
                {  
                    de.Properties[PropertyName][0] = PropertyValue;  
                }  
                else  
                {  
                    de.Properties[PropertyName].Add(PropertyValue);  
                }  
            }  
        }  
  
        /// <summary>  
        /// 生成随机密码  
        /// </summary>  
        /// <returns></returns>  
        public string SetSecurePassword()  
        {  
            //RandomPassword rp = new RandomPassword();  
            return "888888";  
        }  
  
        /// <summary>  
        /// 设置用户新密码  
        /// </summary>  
        /// <param name="path"></param>  
        public void SetPassword(DirectoryEntry newuser, string npsw)  
        {  
            //DirectoryEntry usr = new DirectoryEntry();  
            //usr.Path = path;  
            //usr.AuthenticationType = AuthenticationTypes.Secure;  
              
            //object[] password = new object[] { SetSecurePassword() };  
            //object ret = usr.Invoke("SetPassword", password);  
            //usr.CommitChanges();  
            //usr.Close();  
  
            //newuser.AuthenticationType = AuthenticationTypes.Secure;  
            //object[] password = new object[] { SetSecurePassword() };  
            //object ret = newuser.Invoke("SetPassword", password);  
            newuser.Properties["userPassword"][0] = npsw;
            newuser.CommitChanges();  
            newuser.Close();  
  
        }
        public void SetPsw(string dnpath,string username,string psw,string npsw )
        {
            DirectoryEntry user = new DirectoryEntry(dnpath, username, psw, AuthenticationTypes.None);
            SetPassword(user, npsw);
        }
        public void Delete()
        {
            DirectoryEntry entry = new DirectoryEntry("LDAP://192.168.134.131:389/dc=test,dc=com", "uid=18226530705,dc=test,dc=com", "888888", AuthenticationTypes.None);
            try
            {
                object native = entry.NativeObject;
                //entry.Properties["userPassWord"].Value = "456";
                //entry.CommitChanges();
                //entry.Dispose();
                //object[] password = new object[] { "123" };
                //object s = entry.InvokeGet("cn");
                //string a = entry.Properties["cn"][0].ToString();
               string a= GetProperty(entry,"cn");
            }
            catch (System.Exception ex)
            {
                throw new Exception("Error authenticating user." + ex.Message);
            }
            
        }
        /// <summary>  
        /// 启用用户帐号  
        /// </summary>  
        /// <param name="de"></param>  
        private static void EnableAccount(DirectoryEntry de)  
        {  
            //UF_DONT_EXPIRE_PASSWD 0x10000  
            int exp = (int)de.Properties["userAccountControl"].Value;  
            de.Properties["userAccountControl"].Value = exp | 0x0001;  
            de.CommitChanges();  
            //UF_ACCOUNTDISABLE 0x0002  
            int val = (int)de.Properties["userAccountControl"].Value;  
            de.Properties["userAccountControl"].Value = val & ~0x0002;  
            de.CommitChanges();
            
        }  
  

        /// <summary>  
        /// 添加用户到组  
        /// </summary>  
        /// <param name="de"></param>  
        /// <param name="deUser"></param>  
        /// <param name="GroupName"></param>  
        public static void AddUserToGroup(DirectoryEntry de, DirectoryEntry deUser, string GroupName)  
        {  
            DirectorySearcher deSearch = new DirectorySearcher();  
            deSearch.SearchRoot = de;  
            deSearch.Filter = "(&(objectClass=group) (cn=" + GroupName + "))";  
            SearchResultCollection results = deSearch.FindAll();  
  
            bool isGroupMember = false;  
  
            if (results.Count > 0)  
            {  
                DirectoryEntry group = AdHerlp.GetDirectoryEntry(results[0].Path);  
  
                object members = group.Invoke("Members", null);  
                foreach (object member in (IEnumerable)members)  
                {  
                    DirectoryEntry x = new DirectoryEntry(member);  
                    if (x.Name != deUser.Name)  
                    {  
                        isGroupMember = false;  
                    }  
                    else  
                    {  
                        isGroupMember = true;  
                        break;  
                    }  
                }  
  
                if (!isGroupMember)  
                {  
                    group.Invoke("Add", new object[] { deUser.Path.ToString() });  
                }  
                group.Close();  
            }  
            return;  
        }

        /// <summary>  
        /// 禁用一个帐号  
        /// </summary>  
        /// <param name="EmployeeID"></param>  
        public void DisableAccount(string EmployeeID)  
        {  
            DirectoryEntry de = AdHerlp.GetDirectoryEntry();  
            DirectorySearcher ds = new DirectorySearcher(de);
            ds.Filter = "(&(objectClass=inetOrgPerson)(uid=" + EmployeeID + "))";  
            ds.SearchScope = SearchScope.Subtree;  
            SearchResult results = ds.FindOne();  
  
            if (results != null)  
            {  
                DirectoryEntry dey = AdHerlp.GetDirectoryEntry(results.Path);  
                int val = (int)dey.Properties["userAccountControl"].Value;  
                dey.Properties["userAccountControl"].Value = val | 0x0002;  
                dey.Properties["msExchHideFromAddressLists"].Value = "TRUE";  
                dey.CommitChanges();  
                dey.Close();  
            }  
  
            de.Close();  
        }  
        /// <summary>  
        /// 修改用户信息  
        /// </summary>  
        /// <param name="employeeID"></param>  
        /// <param name="department"></param>  
        /// <param name="title"></param>  
        /// <param name="company"></param>  
        public void ModifyUser(string employeeID, string department, string title, string company)  
        {  
            DirectoryEntry de = AdHerlp.GetDirectoryEntry();  
            DirectorySearcher ds = new DirectorySearcher(de);  
            ds.Filter = "(&(objectCategory=Person)(objectClass=user)(employeeID=" + employeeID + "))";  
            ds.SearchScope = SearchScope.Subtree;  
            SearchResult results = ds.FindOne();  
  
            if (results != null)  
            {  
                DirectoryEntry dey = AdHerlp.GetDirectoryEntry(results.Path);  
                SetProperty(dey, "department", department);  
                SetProperty(dey, "title", title);  
                SetProperty(dey, "company", company);  
                dey.CommitChanges();  
                dey.Close();  
            }  
  
            de.Close();  
        }
        public string GetProperty(DirectoryEntry oDE, string PropertyName)
        {
            try
            {
                string a = "";
                DirectorySearcher searcher = new DirectorySearcher(oDE);
                searcher.Filter = "(objectClass=inetOrgPerson)";
                searcher.PropertiesToLoad.Add("cn");
                SearchResultCollection ret = searcher.FindAll();
                foreach (SearchResult sr in ret)
                {
                    if (sr != null)
                    {
                       a=  sr.Properties[PropertyName][0].ToString();
                    }
                }
                return a;
                //if (oDE.Properties.Contains(PropertyName))
                //{
                //    return oDE.Properties[PropertyName][0].ToString();
                //}
                //else
                //{
                //    return string.Empty;
                //}
            }
            catch (Exception ee)
            {
                return ee.Message;
            }
        }
        /// <summary>  
        /// 检验Email格式是否正确  
        /// </summary>  
        /// <param name="mail"></param>  
        /// <returns></returns>  
        public bool IsEmail(string mail)  
        {  
            Regex mailPattern = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");  
            return mailPattern.IsMatch(mail);  
        }  
        /// <summary>  
        /// 搜索被修改过的用户  
        /// </summary>  
        /// <param name="fromdate"></param>  
        /// <returns></returns>  
        public DataTable GetModifiedUsers(DateTime fromdate)  
        {  
            DataTable dt = new DataTable();  
            dt.Columns.Add("EmployeeID");  
            dt.Columns.Add("Name");  
            dt.Columns.Add("Email");  
  
            DirectoryEntry de = AdHerlp.GetDirectoryEntry();  
            DirectorySearcher ds = new DirectorySearcher(de);  
  
            StringBuilder filter = new StringBuilder();  
            filter.Append("(&(objectCategory=Person)(objectClass=user)(whenChanged>=");  
            filter.Append(ToADDateString(fromdate));  
            filter.Append("))");  
  
            ds.Filter = filter.ToString();  
            ds.SearchScope = SearchScope.Subtree;  
            SearchResultCollection results = ds.FindAll();  
  
            foreach (SearchResult result in results)  
            {  
                DataRow dr = dt.NewRow();  
                DirectoryEntry dey = AdHerlp.GetDirectoryEntry(result.Path);  
                dr["EmployeeID"] = dey.Properties["employeeID"].Value;  
                dr["Name"] = dey.Properties["givenname"].Value;  
                dr["Email"] = dey.Properties["mail"].Value;  
                dt.Rows.Add(dr);  
                dey.Close();  
            }  
  
            de.Close();  
            return dt;  
        }  
  
        /// <summary>  
        /// 格式化AD的时间  
        /// </summary>  
        /// <param name="date"></param>  
        /// <returns></returns>  
        public string ToADDateString(DateTime date)  
        {  
            string year = date.Year.ToString();  
            int month = date.Month;  
            int day = date.Day;  
  
            StringBuilder sb = new StringBuilder();  
            sb.Append(year);  
            if (month < 10)  
            {  
                sb.Append("0");  
            }  
            sb.Append(month.ToString());  
            if (day < 10)  
            {  
                sb.Append("0");  
            }  
            sb.Append(day.ToString());  
            sb.Append("000000.0Z");  
            return sb.ToString();  
        }  
    }  
}  

