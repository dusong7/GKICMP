using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcWebSite.Base;
using MvcWebSite.Models;
using MvcWebSite.Enums;
using Webdiyer.WebControls.Mvc;
using System.Text;

namespace MvcWebSite.Controllers
{
    public class ListController : Controller
    {
        public ActionResult List(int id, bool istop = false)
        {
            BuildTitleNav();
            BuildFoot();
            Menu menu = new DBUtils().GetMenuByID(id);
            ViewBag.Menu = menu;
            //ViewBag.NewList = new DBUtils().GetNew(menuid: id);

            ViewBag.FullPath = GetFullPath(id);


            if (menu.MType != 1 && menu.MType != 3)
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
            else if (menu.MType == 1)
            {
                return RedirectToAction("Article", new { id = menu.MID, isnavarticle = true });
            }
            else if (menu.MType == 3)
            {
                ViewBag.Url = menu.LinkUrl;
                return RedirectToAction("Article", new { id = menu.MID, isnavarticle = true });
            }

            if (!string.IsNullOrEmpty(menu.MenuTemplate) && System.IO.File.Exists(System.AppDomain.CurrentDomain.BaseDirectory + "Views//List//" + menu.MenuTemplate))
            {
                return View(menu.MenuTemplate.Replace(".cshtml", "").Trim());

            }
            else
            {
                return View();
            }


        }

        public ActionResult CommentAdd()
        {
            string title = Request["title"];
            string content = Request["content"];
            string linkuser = Request["linkuser"];
            string linktype = Request["linktype"];
            int nid = Convert.ToInt32(Request["nid"]);
            //评论linktype为2
            //string sql = string.Format("insert into [Tb_Web_Comment] ([CID],[NID],[ComTitle],[ComContent],[LinkUser],[LinkType],[IsPublish],[ComDate],[Isdel],[CFlag]) values ((SELECT CID=max(CID)+1 FROM [Tb_Web_Comment]),{0},'{1}','{2}','{3}','{4}',1,GETDATE(),0,2)", nid, title, content, linkuser, linktype);

            new DBUtils().InsertComment(nid, title, content, linkuser, linktype);

            return RedirectToAction("Article", new { id = nid });
        }

        public ActionResult MenuGet(int menuid)
        {
            Menu menu = new DBUtils().GetMenuByID(menuid);
            List<Menu> menulist = new DBUtils().GetMenuByParentID(menu.MID);
            if (menulist.Count == 0)
            {
                menulist = new DBUtils().GetMenuByParentID(menu.PID);
            }
            ViewBag.MenuList = menulist;

            return View();
        }


        public ActionResult MenuShow(int menuid)
        {

            BuildTitleNav();
            BuildFoot();

            Menu menu = new DBUtils().GetMenuByID(menuid);

            ViewBag.Menu = menu;

            return View();
        }

        public ActionResult Article(int id, bool isnavarticle = false, bool istop = false)
        {
            BuildTitleNav();
            BuildFoot();
            Menu menu = new Menu();
            if (!isnavarticle)
            {
                New news = new DBUtils().GetNewByID(id);
                ViewBag.New = news;
                menu = new DBUtils().GetMenuByID(news.MID);
                ViewBag.Menu = menu;

                ViewBag.FullPath = GetFullPath(news.MID);

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
                menu = new DBUtils().GetMenuByID(id);

                ViewBag.FullPath = GetFullPath(id);

                New news = new New();
                news.NContent = menu.MContent;
                news.NewsTitle = menu.MName;
                ViewBag.Title = "智慧校园-" + menu.MName;
                ViewBag.Menu = menu;
                ViewBag.New = news;
            }
            ViewBag.IsNavArticle = isnavarticle;

            if (!string.IsNullOrEmpty(menu.DetailTemplate) && System.IO.File.Exists(System.AppDomain.CurrentDomain.BaseDirectory + "Views//List//" + menu.DetailTemplate))
            {
                return View();
            }
            else
            {
                return View(menu.DetailTemplate.Replace(".cshtml", "").Trim());
            }

        }


        public ActionResult ListColumn(int menuid = 0, string menulist = "", bool ischild = false, int page = 1, int pagesize = 20, string type = "Colmun", string template = null, bool istop = false, bool ismore = false, string searchtext = "")
        {
            Menu menu = new DBUtils().GetMenuByID(menuid);

            int count = new DBUtils().GetNewCount(menuid: menuid, menulist: menulist, ischild: ischild, istop: istop, searchtext: searchtext);

            List<New> newlist = new DBUtils().GetNew(menuid: menuid, menulist: menulist, ischild: ischild, istop: istop, pageindex: page, pagesize: pagesize, searchtext: searchtext);
            ViewBag.Menu = menu;
            //ViewBag.NewList = newlist;
            ViewBag.IsMore = ismore;
            ViewBag.Type = type;


            PagedList<New> pList = newlist.ToPagedList(1, pagesize);
            pList.PageSize = pagesize;
            pList.TotalItemCount = count;

            if (string.IsNullOrEmpty(template))
            {
                return View(pList);
            }
            else
            {
                return View(template, pList);
            }

        }



        //public JsonResult GetUserNewsCount(int listid)
        //{
        //    JsonResult result = new JsonResult();



        //    result = new JsonResult
        //    {
        //        ContentEncoding = Encoding.Default,
        //        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
        //        ContentType = "applicaion/json",
        //        Data = usercountlist
        //    };

        //    return result;
        //}

        public string GetFullPath(int mid)
        {
            List<Menu> pathlist = new DBUtils().GetFullPath(mid);
            string fullpath = "";
            foreach (Menu path in pathlist)
            {
                fullpath = "-><a href=\"/List/List/" + path.MID + "\">" + path.MName + "</a>" + fullpath;
            }
            fullpath = "<a href=\"/Index/Index\">首页</a>" + fullpath;

            return fullpath;
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
