using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcWebSite.Base;
using MvcWebSite.Models;
using MvcWebSite.Enums;
using Webdiyer.WebControls.Mvc;
using System.Text.RegularExpressions;
using System.Text;

namespace MvcWebSite.Controllers
{
    public class PhoneController : Controller
    {

        public ActionResult Index()
        {
            BuildTitleNav();
            BuildFoot();
            ViewBag.Title = "智慧校园-首页";
            ;
            //幻灯片
            ViewBag.SlideList = new DBUtils().GetFriendLink(2);

            //获取首页滚动图片的文章
            List<New> imagenewlist = new DBUtils().GetNew(isimagenew: true);
            //头条
            List<New> recommandlist = new DBUtils().GetNew(isrecommand: true);


            //ViewBag.Test = new MvcHtmlString("<div>这个是测试<p style=\"color:red\">红色字体</p></div>");

            ViewBag.ImageNew = imagenewlist;
            ViewBag.Recommand = recommandlist;
            return View();
        }



        public ActionResult List(int id, bool istop = false)
        {
            BuildTitleNav();
            BuildFoot();
            Menu menu = new DBUtils().GetMenuByID(id);
            ViewBag.Menu = menu;
            //ViewBag.NewList = new DBUtils().GetNew(menuid: id);

            if (menu.MType == 2)
            {
                string path = "";
                if (menu.PID == -1)
                {
                    path = new DBUtils().GetMenuByID(menu.PID).MName + "-" + menu.MName;
                }
                else
                {
                    path = menu.MName;
                }

                ViewBag.Title = "智慧校园-" + path;
            }
            else
            {
                return RedirectToAction("Article", new { id = menu.MID, isnavarticle = true });
            }
            return View();
        }


        public ActionResult Mailbox()
        {
            BuildTitleNav();
            BuildFoot();

            return View();
        }

        public ActionResult ListColumn(int menuid, int page = 1, int pagesize = 20, string type = "Colmun", bool istop = false, bool ismore = false)
        {
            Menu menu = new DBUtils().GetMenuByID(menuid);

            List<New> newlist = new DBUtils().GetNew(menuid: menuid, istop: istop, pagesize: 9999);
            ViewBag.Menu = menu;
            //ViewBag.NewList = newlist;
            ViewBag.IsMore = ismore;
            ViewBag.Type = type;


            PagedList<New> pList = newlist.ToPagedList(page, pagesize);
            pList.PageSize = pagesize;
            pList.TotalItemCount = newlist.Count;

            return View(pList);
        }


        public ActionResult Article(int id, bool isnavarticle = false, bool istop = false)
        {
            BuildTitleNav();
            BuildFoot();

            if (!isnavarticle)
            {
                New news = new DBUtils().GetNewByID(id);
                ViewBag.New = news;
                Menu menu = new DBUtils().GetMenuByID(news.MID);
                ViewBag.Menu = menu;

                //获取评论
                string commentsql = string.Format("select * from [Tb_Web_Comment] where [IsPublish]=1 and [Isdel]=0 and [NID]={0} order by [ComDate] desc", news.NID);
                List<Comment> commentlist = new DBUtils().GetComment(commentsql);
                ViewBag.CommentList = commentlist;

                string path = "";
                if (menu.PID == -1)
                {
                    path = new DBUtils().GetMenuByID(menu.PID).MName + "-" + menu.MName;
                }
                else
                {
                    path = menu.MName;
                }

                ViewBag.Title = "智慧校园-" + path;
            }
            else
            {
                Menu menu = new DBUtils().GetMenuByID(id);

                New news = new New();
                news.NContent = menu.MContent;
                news.NewsTitle = menu.MName;
                ViewBag.Title = "智慧校园-" + menu.MName;
                ViewBag.Menu = menu;
                ViewBag.New = news;
            }
            ViewBag.IsNavArticle = isnavarticle;
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

        public ActionResult TopNew()
        {
            BuildTitleNav();
            BuildFoot();
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


        public JsonResult GetNews(int menuid = 0, bool istop = false, int pageindex = 1, int pagesize = 20)
        {
            JsonResult result = new JsonResult();

            List<New> newlist = new DBUtils().GetNew(menuid: menuid, istop: istop, pageindex: pageindex, pagesize: pagesize);

            result = new JsonResult
            {
                ContentEncoding = Encoding.Default,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                ContentType = "applicaion/json",
                Data = newlist
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
