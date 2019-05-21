using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcWebSite.Base;
using MvcWebSite.Models;
using MvcWebSite.Enums;
using MvcWebSite.Utils;
using Webdiyer.WebControls.Mvc;
using System.Text;
using System.Text.RegularExpressions;

namespace MvcWebSite.Controllers
{
    public class IndexController : Controller
    {
        //
        // GET: /Index/

        public ActionResult Index(int contentcount = 50)
        {
            BuildTitleNav();
            BuildFoot();
            ViewBag.Title = "智慧校园-首页";
            ;
            //幻灯片
            ViewBag.SlideList = new DBUtils().GetFriendLink(2);

            if (Request.Cookies["UserID"] != null && !string.IsNullOrEmpty(Request.Cookies["UserID"].Value))
            {
                SysUser user = new SysUser();
                if (Request.Cookies["SysUserName"] != null && !string.IsNullOrEmpty(Request.Cookies["SysUserName"].Value))
                {
                    if (new DBUtils().IsLoginSuccess(Request.Cookies["SysUserName"].Value, Request.Cookies["SysUserPwd"].Value, out user))
                    {
                        ViewBag.Details = new DBUtils().MainDetails(Request.Cookies["UserID"].Value);
                    }
                }

            }


            //获取首页滚动图片的文章
            List<New> imagenewlist = new DBUtils().GetNew(isimagenew: true, contentcount: contentcount);
            //头条
            List<New> recommandlist = new DBUtils().GetNew(isrecommand: true, contentcount: contentcount);


            //ViewBag.Test = new MvcHtmlString("<div>这个是测试<p style=\"color:red\">红色字体</p></div>");

            ViewBag.ImageNew = imagenewlist;
            ViewBag.Recommand = recommandlist;
            return View();
        }

        public ActionResult Resource(int gid = 0, int cid = 0, int etype = 0, int page = 1, int pagesize = 20)
        {
            BuildTitleNav();
            BuildFoot();
            ViewBag.Title = "智慧校园-校本资源";

            List<EduResource> resourcelist = new DBUtils().GetResource(gid, cid, etype);

            PagedList<EduResource> pList = resourcelist.ToPagedList(page, pagesize);
            pList.PageSize = pagesize;
            pList.TotalItemCount = resourcelist.Count;

            //获取所有学科年级分类
            string coursesql = "select * from [Tb_Course] where [Isdel]=0 and [IsOpen]=1 ";
            ViewBag.CourseList = new DBUtils().GetCourse(coursesql);
            string gradelevelsql = "select * from [Tb_Grade_Level] order by [GradeLever]";
            ViewBag.GradeLevelList = new DBUtils().GetGradeLevel(gradelevelsql);
            List<KeyValuePair<int, string>> etypelist = new List<KeyValuePair<int, string>>();
            foreach (Enums.EType item in Enum.GetValues(typeof(Enums.EType)))
            {
                etypelist.Add(new KeyValuePair<int, string>((int)item, Enum.GetName(typeof(Enums.EType), item)));

            }
            ViewBag.ETypeList = etypelist;

            //获取所选中的信息
            ViewBag.GID = gid == 0 ? "" : gid.ToString();
            ViewBag.CID = cid == 0 ? "" : cid.ToString();
            ViewBag.EType = etype == 0 ? "" : etype.ToString();
            if (gid != 0)
            {
                ViewBag.GradeLevel = new DBUtils().GetGradeLevelByID(gid);
            }
            if (cid != 0)
            {
                ViewBag.Course = new DBUtils().GetCourseByID(cid);
            }
            if (etype != 0)
            {
                ViewBag.ETypeName = Enum.GetName(typeof(Enums.EType), etype);
            }


            return View(pList);
        }


        public ActionResult Search(int menuid = 0, int pagesize = 10, int pageindex = 1, string searchtext = "")
        {
            BuildTitleNav();
            BuildFoot();
            ViewBag.SearchList = new DBUtils().GetNew(menuid: menuid, pagesize: pagesize, pageindex: pageindex, searchtext: searchtext);

            return View();
        }

        public ActionResult IndexColumn(int menuid = 0, string menulist = "", bool ischild = false, int left = 0, int pagesize = 7, bool ismore = true, string type = "Column", string template = null, bool istop = false, bool isrecommand = false, int width = 1002, int contentcount = 20, string searchtext = "")
        {
            ViewBag.Menu = new DBUtils().GetMenuByID(menuid);
            ViewBag.NewList = new DBUtils().GetNew(menuid: menuid, menulist: menulist, ischild: ischild, pagesize: pagesize, istop: istop, isrecommand: isrecommand, contentcount: contentcount, searchtext: searchtext);
            ViewBag.IsMore = ismore;
            ViewBag.Left = left + "px";
            ViewBag.MarqueeWidth = width + "px";
            ViewBag.Type = type;
            //ViewBag.Template = (template == null ? null : "~/Views/Index/" + template + ".cshtml");
            if (template == null)
            {
                return View();
            }
            else
            {
                return View(template);
            }

        }

        public ActionResult MenuShow(int menuid)
        {
            Menu menu = new DBUtils().GetMenuByID(menuid);
            menu.MContent = new BaseUtils().InitContent(menu.MContent);
            ViewBag.Menu = menu;

            return View();
        }


        public ActionResult Marquee(int stype = 0, string template = null)
        {
            ViewBag.SlideList = new DBUtils().GetFriendLink(2, stype);
            if (string.IsNullOrEmpty(template))
            {
                return View();
            }
            else
            {
                return View(template);
            }
        }

        public ActionResult FriendLink()
        {
            ViewBag.LinkList = new DBUtils().GetFriendLink(1);
            return View();
        }

        public ActionResult Slogan(int id = 0)
        {
            ViewBag.SloganList = new DBUtils().GetFriendLink(3, id);
            return View();
        }

        public JsonResult PrinMailbox(string pmcontent, string link, string realname)
        {
            JsonResult result = new JsonResult();

            if (!string.IsNullOrEmpty(pmcontent) && !string.IsNullOrEmpty(link) && !string.IsNullOrEmpty(realname))
            {
                try
                {
                    string linktype = "LinkNum";
                    Regex r = new Regex("^\\s*([A-Za-z0-9_-]+(\\.\\w+)*@(\\w+\\.)+\\w{2,5})\\s*$");
                    if (r.IsMatch(link))
                    {
                        linktype = "MailNum";
                    }

                    //string sql = string.Format("insert into Tb_PrinMailbox ([PMContent],[RealName],[{0}]) values ('{1}','{2}','{3}')", linktype, pmcontent, realname, link);
                    new DBUtils().InsertPrinMailbox(linktype, pmcontent, realname, link);

                    result = new JsonResult
                    {
                        ContentEncoding = Encoding.Default,
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        ContentType = "applicaion/json",
                        Data = "success"
                    };
                }
                catch
                {

                }
            }

            return result;
        }



        public JsonResult GetUserNewsCount()
        {
            JsonResult result = new JsonResult();

            List<KeyValuePair<int, string>> usercountlist = new DBUtils().UserNewCount();

            result = new JsonResult
            {
                ContentEncoding = Encoding.Default,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                ContentType = "applicaion/json",
                Data = usercountlist
            };

            return result;
        }


        public JsonResult GetLogin(string username, string password)
        {
            JsonResult result = new JsonResult();
            SysUser user = new SysUser();
            string message = "failed";
            password = new BaseUtils().Encrypt(password.Trim());
            //登录
            if (new DBUtils().IsLoginSuccess(username, password, out user))
            {
                //成功
                message = "success";

                Response.Cookies["UserType"].Value = user.UserType;
                Response.Cookies["UserID"].Value = new BaseUtils().Encrypt(user.UserID.ToString());
                Response.Cookies["SysUserName"].Value = user.SysUserName;
                Response.Cookies["RealName"].Value = HttpUtility.UrlEncode(user.RealName, Encoding.GetEncoding("UTF-8"));
                Response.Cookies["SysUserPwd"].Value = password;
            }



            result = new JsonResult
            {
                ContentEncoding = Encoding.Default,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                ContentType = "applicaion/json",
                Data = message
            };

            return result;
        }


        public void BuildTitleNav()
        {
            string navsql = "select * from [Tb_Web_Menu] where [Isdel]=0 and [IsNavigation]=1 and [IsOpen]=1 order by [MOrder]";
            List<Menu> menulist = new DBUtils().GetNav(navsql);

            //栏目
            ViewBag.Nav = menulist;
            ///算上首页和智慧校园
            ViewBag.NavCount = menulist.Count + 2;
        }

        public void BuildFoot()
        {
            ViewBag.Site = new DBUtils().GetSite();
        }
    }
}
