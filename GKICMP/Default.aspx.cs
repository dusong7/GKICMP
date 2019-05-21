using GK.GKICMP.Common;
using GK.GKICMP.DAL;
using GK.GKICMP.Entities;
/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年01月04日 09点24分
** 描   述:      登录页面
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;

namespace GKICMP
{
    public partial class Default : System.Web.UI.Page
    {
        public SysUserDAL sysUsergDAL = new SysUserDAL();
        public SysLogDAL sysLogDAL = new SysLogDAL();
        public myDirectory mDirectory = new myDirectory();
        public IntegralInfoDAL integdal = new IntegralInfoDAL();
        public string corpId = "";
        public string CorpSecret = "";
        public string agentId = "";
        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               // getDate() ;
                // test();
               // Page.ClientScript.RegisterStartupScript(GetType(), "", "alert(" + a + ")", true);
                //string a = hello();
                //string a = CommonFunction.Decrypt("50CC8DA3C9A90E95");
                // string uid = CommonFunction.Decrypt("1A771DC3CD453A7A7BC34BCF53C52D8AB656BC566326482372B48368ECC6A87B1F74DF45297AF653");
                //if (!string.IsNullOrEmpty(HttpContext.Current.Request.Cookies["UserID"].ToString()))
                //{
                //    Page.ClientScript.RegisterStartupScript(GetType(), "", "window.location.href = 'WebMain.aspx'", true);
                //}
                //else { }
                if (Request.Cookies["SysUserName"] != null && Request.Cookies["SysUserPwd"] != null)
                {
                    string message = Login(Request.Cookies["SysUserName"].Value, Request.Cookies["SysUserPwd"].Value);

                    if (message == "")
                    {
                        if (PcOrNot())
                        {
                            if (Request.Cookies["UserType"].ToString() == CommonEnum.UserType.老师.ToString())
                            {
                                Page.ClientScript.RegisterStartupScript(GetType(), "", "window.location.href = 'WebMain.aspx';", true);
                            }
                            else
                            {
                                Page.ClientScript.RegisterStartupScript(GetType(), "", "window.location.href = 'Stu_WebMain.aspx';", true);
                            }
                        }
                        else
                        {
                            if (Request.Cookies["UserType"].ToString() == CommonEnum.UserType.老师.ToString())
                            {
                                Page.ClientScript.RegisterStartupScript(GetType(), "", "window.location.href = 'AppMain.aspx';", true);
                            }
                            else
                            {
                                Page.ClientScript.RegisterStartupScript(GetType(), "", "window.location.href = 'Stu_WebMain.aspx';", true);
                            }
                        }
                    }
                    else
                    {
                        ClearCookies();
                        if (!PcOrNot()) 
                        {
                            //Page.ClientScript.RegisterStartupScript(GetType(), "", "window.location.href = '/app/Login.html';", true);
                            Response.Redirect("app/Login.html", true);
                        }
                    }
                }
                else
                {
                    //ClearCookies();
                    if (!PcOrNot())
                    {
                        Response.Redirect("app/Login.html", true);
                        //Page.ClientScript.RegisterStartupScript(GetType(), "", "window.location.href = '/app/Login.html';", true);
                    }
                }
            }
        }
        #endregion

        public void getDate() 
        {
            WeiXinInfoEntity model = XMLHelper.Get("~/QYWX.xml", "Main", 1);
            corpId = model.CorpID;
            CorpSecret = model.Secret;
            agentId = model.Agent;
        }
        public void test() 
        {
            {
                string path = Server.MapPath("License.dll");
                Assembly asm = Assembly.LoadFrom(path);////我们要调用的dll文件路径
                //加载dll后,需要使用dll中某类.
                Type t = asm.GetType("License.License");//获取类名，必须 命名空间+类名  

                //实例化类型
                object o = Activator.CreateInstance(t);

                //得到要调用的某类型的方法
                MethodInfo method = t.GetMethod("Hello");//functionname:方法名字

                object[] obj = {"hello","world" };
                //对方法进行调用
                var keyData = method.Invoke(o, obj);//param为方法参数object数组
                


                
                    //string path = @"D:\123\mydll\mydll\bin\Debug\mydll.dll";


                    ////Byte[] byte1 = System.IO.File.ReadAllBytes(path);//也是可以的
                    ////Assembly assem = Assembly.Load(byte1);

                    //Assembly assem = Assembly.LoadFile(path);


                    ////string t_class = "mydll.Class1";//理论上已经加载了dll文件，可以通过命名空间加上类名获取类的类型，这里应该修改为如下：

                    ////string t_class = "mydll.Class1,mydll";//如果你想要得到的是被本工程内部的类，可以“命名空间.父类……类名”;如果是外部的，需要在后面加上“,链接库名”;

                    ////再次感谢thy38的帮助。

                    ////Type ty = Type.GetType(t_class);//这儿在调试的时候ty=null，一直不理解，望有高人可以解惑

                    //Type[] tys = assem.GetTypes();//只好得到所有的类型名，然后遍历，通过类型名字来区别了
                    //foreach (Type ty in tys)//huoquleiming
                    //{
                    //    if (ty.Name == "Class1")
                    //    {
                    //        ConstructorInfo magicConstructor = ty.GetConstructor(Type.EmptyTypes);//获取不带参数的构造函数
                    //        object magicClassObject = magicConstructor.Invoke(new object[] { });//这里是获取一个类似于类的实例的东东

                    //        //object magicClassObject = Activator.CreateInstance(t);//获取无参数的构造实例还可以通过这样
                    //        MethodInfo mi = ty.GetMethod("sayhello");
                    //        object aa = mi.Invoke(magicClassObject, null);
                    //    }
                    //    if (ty.Name == "Class2")
                    //    {
                    //        ConstructorInfo magicConstructor = ty.GetConstructor(Type.EmptyTypes);//获取不带参数的构造函数，如果有构造函数且没有不带参数的构造函数时，这儿就不能这样子啦
                    //        object magicClassObject = magicConstructor.Invoke(new object[] { });
                    //        MethodInfo mi = ty.GetMethod("saybeautiful");
                    //    }
                    //}

                

            }
        }

        public bool PcOrNot()
        {
            string u = Request.ServerVariables["HTTP_USER_AGENT"];
            Regex b = new Regex(@"(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|mobile.+firefox|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows ce|xda|xiino", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            Regex v = new Regex(@"1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if ((b.IsMatch(u) || v.IsMatch(u.Substring(0, 4))))
            {
                //手机访问
                return false;
            }
            else
            {
                //电脑访问
                return true;
            }
        }

        public void Test()
        {
            string result = "";
            try
            {
                string token1 = WeixinQYAPI.GetAccess_Token("wxe0b787e4eaa1102c", "hO3Z0iAo9B_S9vh17sL6_QmThmvrvsArrJbW6pn3Ujs");
                string wxurl = " https://qyapi.weixin.qq.com/cgi-bin/media/upload?access_token=" + token1 + "&type=image";
                string filepath = System.Web.HttpContext.Current.Server.MapPath("wximage/3.jpg"); //(本地服务器的地址)
                FileHelper.CreateFileWithContent(System.Web.HttpContext.Current.Server.MapPath("/微信/"), "wx.txt", filepath, false);
                // WriteLog("上传路径:" + filepath);
                WebClient myWebClient = new WebClient();
                myWebClient.Credentials = CredentialCache.DefaultCredentials;

                try
                {
                    byte[] responseArray = myWebClient.UploadFile(wxurl, "POST", filepath);
                    result = System.Text.Encoding.Default.GetString(responseArray, 0, responseArray.Length);
                    FileHelper.CreateFileWithContent(System.Web.HttpContext.Current.Server.MapPath("/微信/"), "wx.txt", result, false);
                    // result = Json(result, "media_id");

                    // WriteLog("上传result:" + result);
                    //UploadMM _mode = JsonHelper.ParseFromJson<UploadMM>(result);
                    //result = _mode.media_id;
                }
                catch (Exception ex)
                {
                    result = "Error:" + ex.Message;
                    FileHelper.CreateFileWithContent(System.Web.HttpContext.Current.Server.MapPath("/微信/"), "wx.txt", result, false);
                }
            }
            catch (Exception err)
            {

                FileHelper.CreateFileWithContent(System.Web.HttpContext.Current.Server.MapPath("/微信/"), "wx.txt", err.Message, false);
            }
        }
        public string UploadMultimedia(string ACCESS_TOKEN, string Type)
        {
            string result = "";
            string wxurl = " https://qyapi.weixin.qq.com/cgi-bin/media/upload?access_token=" + ACCESS_TOKEN + "&type=" + Type + "";
            string filepath = System.Web.HttpContext.Current.Server.MapPath("wximage/1.jpg"); //(本地服务器的地址)
            // WriteLog("上传路径:" + filepath);
            WebClient myWebClient = new WebClient();
            myWebClient.Credentials = CredentialCache.DefaultCredentials;
            try
            {
                byte[] responseArray = myWebClient.UploadFile(wxurl, "POST", filepath);
                result = System.Text.Encoding.Default.GetString(responseArray, 0, responseArray.Length);
                // WriteLog("上传result:" + result);
                //UploadMM _mode = JsonHelper.ParseFromJson<UploadMM>(result);
                //result = _mode.media_id;
            }
            catch (Exception ex)
            {
                result = "Error:" + ex.Message;
            }
            //WriteLog("上传MediaId:" + result);
            return result;
        }

        #region 清理COOkies
        /// <summary>
        /// 清理COOkies
        /// </summary>
        public void ClearCookies()
        {
            Response.Cookies["UserID"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["SysUserName"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["RealName"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["UserType"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["UserFace"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["SysUserPwd"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["IsSeries"].Expires = DateTime.Now.AddDays(-1);
            //Response.Cookies.Remove("UserType");
            //Response.Cookies.Remove("UserID");
            //Response.Cookies.Remove("SysUserName");
            //Response.Cookies.Remove("RealName");
            //Response.Cookies.Remove("UserFace");
            //Response.Cookies.Remove("SysUserPwd");
        }
        #endregion


        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ibtn_Login_Click(object sender, ImageClickEventArgs e)
        {
            #region 注释
            //string pwd = CommonFunction.Encrypt(this.txt_PassWord.Text.Trim());
            //string username = this.txt_UserName.Text.Trim();
            //int result = 0;
            ////SysUserEntity sysuser = sysUsergDAL.UserLogin(username, pwd);
            //SysUserEntity sysuser = sysUsergDAL.UserLoad(username, pwd,ref result);
            //if (sysuser == null )
            //{
            //    Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('用户不存在！');", true);
            //    return;
            //}
            //else if(sysuser.Isdel == 1)
            //{
            //    Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('用户名或密码错误！');", true);
            //    return;
            //}
            //else if (sysuser.UState == -1)
            //{
            //    Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('您的账户已被禁用，请联系系统管理员！');", true);
            //    return;
            //}
            //else
            //{
            //    Response.Cookies["UserType"].Value = sysuser.UserType.ToString();
            //    Response.Cookies["UserID"].Value = CommonFunction.Encrypt(sysuser.UID.ToString());
            //    Response.Cookies["SysUserName"].Value = sysuser.UserName;
            //    Response.Cookies["RealName"].Value = HttpUtility.UrlEncode(sysuser.RealName, Encoding.GetEncoding("UTF-8"));
            //    Response.Cookies["SysUserPwd"].Value = pwd;
            //    //SysLogEntity log = new SysLogEntity((int)CommonEnum.LogType.登录日志, "用户【" + sysuser.UserName + "】于北京时间" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "登录系统",sysuser.UID);
            //    SysLogEntity log = new SysLogEntity((int)CommonEnum.LogType.登录日志, "用户【" + sysuser.RealName + "】于北京时间" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "登录系统", sysuser.UID);
            //    sysLogDAL.Edit(log);
            //    // Context.Cache.Insert("uid", sysuser.UID, null, DateTime.MaxValue, TimeSpan.Zero, CacheItemPriority.Normal, null);
            //    // Page.ClientScript.RegisterStartupScript(GetType(), "", "window.location.href = 'WebMain.aspx'", true);
            //    if (sysuser.UserType == (int)CommonEnum.UserType.老师)
            //    {
            //        Page.ClientScript.RegisterStartupScript(GetType(), "", "window.location.href = 'WebMain.aspx'", true);
            //    }
            //    else
            //    {
            //        Page.ClientScript.RegisterStartupScript(GetType(), "", "window.location.href = 'Stu_WebMain.aspx'", true);
            //    }
            //} 
            #endregion

            string pwd = CommonFunction.Encrypt(this.txt_PassWord.Text.Trim());
            string username = this.txt_UserName.Text.Trim();
            if (ConfigurationManager.AppSettings["LDAP"] == "1")
            {
                DataTable dt = sysUsergDAL.GetLDAP();
                if (dt != null && dt.Rows.Count > 0)
                {
                    LDapEntity model = new LDapEntity();
                    model.Path = dt.Rows[0]["Path"].ToString();
                    model.DN = dt.Rows[0]["DN"].ToString();
                    model.OU = dt.Rows[0]["OU"].ToString();
                    model.UserName = "uid=" + username;
                    model.Psw = pwd;
                    string Lresult = mDirectory.GetDirectoryEntry(model);
                    if (Lresult == "")
                    {
                        SysUserEntity sysuser = sysUsergDAL.GetLogin(username);
                        if (sysuser != null)
                        {
                            Response.Cookies["UserType"].Value = sysuser.UserType.ToString();
                            Response.Cookies["UserID"].Value = CommonFunction.Encrypt(sysuser.UID.ToString());
                            Response.Cookies["SysUserName"].Value = sysuser.UserName;
                            Response.Cookies["RealName"].Value = HttpUtility.UrlEncode(sysuser.RealName, Encoding.GetEncoding("UTF-8"));
                            Response.Cookies["SysUserPwd"].Value = pwd;
                      
                            SysLogEntity log = new SysLogEntity((int)CommonEnum.LogType.登录日志, "用户【" + sysuser.RealName + "】于北京时间" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "登录系统", sysuser.UID);
                            //integdal.Edit(sysuser.UserID, 1);
                            sysLogDAL.Edit(log);
                            if (sysuser.UserType == (int)CommonEnum.UserType.老师)
                            {
                                Page.ClientScript.RegisterStartupScript(GetType(), "", "window.location.href = 'WebMain.aspx'", true);
                            }
                            else
                            {
                                Page.ClientScript.RegisterStartupScript(GetType(), "", "window.location.href = 'Stu_WebMain.aspx'", true);
                            }
                        }
                    }
                    else
                    {
                        Lresult = Lresult.Replace("'", "");
                        Lresult = Lresult.Replace("\"", "");
                        Lresult = Lresult.Replace("\r\n", "");
                        Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('" + Lresult + "');", true);
                        return;
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('请配置LDAP地址！');", true);
                    return;
                }
            }
            Loging(pwd, username);
        }

        private void Loging(string pwd, string username)
        {
            int result = 0;
            SysUserEntity sysuser = sysUsergDAL.UserLoad(username, pwd, ref result);
            if (result == -1)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('用户不存在！');", true);
                return;
            }
            else if (result == -2)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('密码错误！');", true);
                return;
            }
            else if (result == -3)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('您的账户已被禁用，请联系系统管理员！');", true);
                return;
            }
            else
            {
                Response.Cookies["UserType"].Value = sysuser.UserType.ToString();
                Response.Cookies["UserID"].Value = CommonFunction.Encrypt(sysuser.UID.ToString());
                Response.Cookies["SysUserName"].Value = HttpUtility.UrlEncode(sysuser.UserName);
                Response.Cookies["RealName"].Value = HttpUtility.UrlEncode(sysuser.RealName, Encoding.GetEncoding("UTF-8"));
                Response.Cookies["SysUserPwd"].Value = pwd;
                SysLogEntity log = new SysLogEntity((int)CommonEnum.LogType.登录日志, "用户【" + sysuser.RealName + "】于北京时间" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "登录系统", sysuser.UID);
                sysLogDAL.Edit(log);
               if (sysuser.UserType == (int)CommonEnum.UserType.老师)
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "window.location.href = 'WebMain.aspx'", true);
                }
               else if (sysuser.UserType == (int)CommonEnum.UserType.学生)
               {
                   Page.ClientScript.RegisterStartupScript(GetType(), "", "window.location.href = 'Stu_WebMain.aspx'", true);
               }
               else 
               {
                   Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('暂无权限')", true);
                   ClearCookies();
               }
            }
        }


        public string Login(string name, string password)
        {
            SysUserEntity sysuser = sysUsergDAL.UserLogin(name, password);
            if (sysuser == null || sysuser.Isdel == 1)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "alert('用户名或密码错误！');", true);
                return "1";
            }
            else
            {
                Response.Cookies["UserType"].Value = sysuser.UserType.ToString();
                Response.Cookies["UserID"].Value = CommonFunction.Encrypt(sysuser.UID.ToString());
                Response.Cookies["SysUserName"].Value = sysuser.UserName;
                Response.Cookies["RealName"].Value = HttpUtility.UrlEncode(sysuser.RealName, Encoding.GetEncoding("UTF-8"));
                Response.Cookies["SysUserPwd"].Value = password;
                if (sysuser.UserType == (int)CommonEnum.UserType.老师)
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "window.location.href = 'WebMain.aspx'", true);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "window.location.href = 'Stu_WebMain.aspx'", true);
                }
            }
            return "";
        }

       
    }
}