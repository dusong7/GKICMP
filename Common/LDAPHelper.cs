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
    public class LDAPHelper
    {
        private DirectoryEntry _objDirectoryEntry;
        /// <summary>
        /// 登录验证
        /// </summary>
        /// <returns></returns>
        public string check()
        {
            //string ldapBaseDnPath = "LDAP://192.168.134.131:389/DC=test,dc=com";
            //// 'LDAP' 这4个字母必须大写  
            //string userName = "Miumiu";
            //string password = "111111";

            //using (DirectoryEntry de = new DirectoryEntry(ldapBaseDnPath, userName, password))
            //{
            //    try
            //    {
            //        object connected = de.NativeObject;
            //        // 认证通过  
            //    }
            //    catch
            //    {
            //        // 认证失败. 找原因  
            //    }
            //}
            //return "";
            DirectoryEntry entry = new DirectoryEntry("LDAP://192.168.134.131:389/dc=test,dc=com", "cn=Manager,dc=test,dc=com", "secret", AuthenticationTypes.None);

            try
            {
                object native = entry.NativeObject;

            }
            catch (System.Exception ex)
            {
                throw new Exception("Error authenticating user." + ex.Message);
            }
            return "";
        }
        /// <summary>
        /// 查找所有用户
        /// </summary>
        /// <returns></returns>
        public List<string> EnumerateOU()
        {
            List<string> lst = new List<string>();
            DirectoryEntry entry = new DirectoryEntry("LDAP://192.168.134.131:389/dc=test,dc=com", "cn=Manager,dc=test,dc=com", "secret", AuthenticationTypes.None);

            try
            {
                object native = entry.NativeObject;
                DirectorySearcher searcher = new DirectorySearcher(entry);
                searcher.Filter = "(objectClass=inetOrgPerson)";
                searcher.PropertiesToLoad.Add("cn");
                SearchResultCollection ret = searcher.FindAll();
                foreach (SearchResult sr in ret)
                {
                    if (sr != null)
                    {
                        lst.Add(sr.Properties["cn"][0].ToString());
                    }
                }
            }
            catch (System.Exception ex)
            {
            }
            return lst;
        }
        /// <summary>
        /// 添加用户到组
        /// </summary>
        /// <param name="de"></param>
        /// <param name="deUser"></param>
        /// <param name="GroupName"></param>
        public static void AddUserToGroup(DirectoryEntry de, DirectoryEntry deUser, string GroupName)
        {
            DirectoryEntry myde = new DirectoryEntry("LDAP://ycinfo.35cn.com/OU=Tester,DC=35cn,DC=com");
            DirectoryEntry user = myde.Children.Add("uid=zhangsan", "inetOrgPerson");  //在用户对象创建zixian用户
            user.UsePropertyCache = true;
            user.Properties["company"].Add("GK");
            user.Properties["department"].Add("Tester");
            user.Properties["samAccountName"].Add("sename");
            user.Properties["userPassWord"].Add("123");
            user.CommitChanges();
            //DirectorySearcher deSearch = new DirectorySearcher();
            //deSearch.SearchRoot = de;
            //deSearch.Filter = "(&(objectClass=group) (cn=" + GroupName + "))";
            //SearchResultCollection results = deSearch.FindAll();

            //bool isGroupMember = false;

            //if (results.Count > 0)
            //{
            //    DirectoryEntry group = AdHerlp.GetDirectoryEntry(results[0].Path);

            //    object members = group.Invoke("Members", null);
            //    foreach (object member in (IEnumerable)members)
            //    {
            //        DirectoryEntry x = new DirectoryEntry(member);
            //        if (x.Name != deUser.Name)
            //        {
            //            isGroupMember = false;
            //        }
            //        else
            //        {
            //            isGroupMember = true;
            //            break;
            //        }
            //    }

            //    if (!isGroupMember)
            //    {
            //        group.Invoke("Add", new object[] { deUser.Path.ToString() });
            //    }
            //    group.Close();
            //}
            //return;
        }












        /// <summary>  
        /// 构造函数  
        /// </summary>  
        /// <param name="LADPath">ldap的地址，例如"LDAP://***.***.48.110:389/dc=***,dc=com"</param>  
        /// <param name="authUserName">连接用户名，例如"cn=root,dc=***,dc=com"</param>  
        /// <param name="authPWD">连接密码</param>  
        public bool OpenConnection(string LADPath, string authUserName, string authPWD)
        {    //创建一个连接   
            _objDirectoryEntry = new DirectoryEntry(LADPath, authUserName, authPWD, AuthenticationTypes.None);


            if (null == _objDirectoryEntry)
            {
                return false;
            }
            else if (_objDirectoryEntry.Properties != null && _objDirectoryEntry.Properties.Count > 0)
            {
                return true;
            }
            return false;
        }


        /// <summary>  
        /// 检测一个用户和密码是否正确  
        /// </summary>  
        /// <param name="strLDAPFilter">(|(uid= {0})(cn={0}))</param>  
        /// <param name="TestUserID">testuserid</param>  
        /// <param name="TestUserPwd">testuserpassword</param>  
        /// <param name="ErrorMessage"></param>  
        /// <returns></returns>  
        public bool CheckUidAndPwd(string strLDAPFilter, string TestUserID, string TestUserPwd, ref string ErrorMessage)
        {
            bool blRet = false;
            try
            {
                //创建一个检索  
                DirectorySearcher deSearch = new DirectorySearcher(_objDirectoryEntry);
                //过滤名称是否存在  
                deSearch.Filter = strLDAPFilter;
                deSearch.SearchScope = SearchScope.Subtree;


                //find the first instance   
                SearchResult objSearResult = deSearch.FindOne();


                //如果用户密码为空  
                if (string.IsNullOrEmpty(TestUserPwd))
                {
                    if (null != objSearResult && null != objSearResult.Properties && objSearResult.Properties.Count > 0)
                    {
                        blRet = true;
                    }
                }
                else if (null != objSearResult && !string.IsNullOrEmpty(objSearResult.Path))
                {
                    //获取用户名路径对应的用户uid  
                    int pos = objSearResult.Path.LastIndexOf('/');
                    string uid = objSearResult.Path.Remove(0, pos + 1);
                    DirectoryEntry objUserEntry = new DirectoryEntry(objSearResult.Path, uid, TestUserPwd, AuthenticationTypes.None);
                    if (null != objUserEntry && objUserEntry.Properties.Count > 0)
                    {
                        blRet = true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (null != _objDirectoryEntry)
                {
                    _objDirectoryEntry.Close();
                }
                ErrorMessage = "检测异常：" + ex.StackTrace;
            }
            return blRet;
        }
        

        /// <summary>  
        /// 关闭连接  
        /// </summary>  
        public void closeConnection()
        {
            if (null != _objDirectoryEntry)
            {
                _objDirectoryEntry.Close();
            }
        }
    }  
}
