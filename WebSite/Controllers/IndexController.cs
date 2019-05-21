using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcWebSite.Base;
using MvcWebSite.Models;
using MvcWebSite.Enums;
using Webdiyer.WebControls.Mvc;

namespace MvcWebSite.Controllers
{
    public class IndexController : Controller
    {
        //
        // GET: /Index/

        public ActionResult Index()
        {
            BuildTitleNav();
            ViewBag.Title = "芜湖县赵桥中心学校-首页";

            //幻灯片
            ViewBag.SlideList = new DBUtils().GetFriendLink(2);

            //获取首页滚动图片的文章
            List<New> imagenewlist = new DBUtils().GetNew(isimagenew: true);
            //头条
            List<New> recommandlist = new DBUtils().GetNew(isrecommand: true);


            ViewBag.ImageNew = imagenewlist;
            ViewBag.Recommand = recommandlist;
            return View();
        }

        public ActionResult List(int id)
        {
            BuildTitleNav();
            Menu menu = new DBUtils().GetMenuByID(id);
            ViewBag.Menu = menu;
            //ViewBag.NewList = new DBUtils().GetNew(menuid: id);


            //获取左侧的文章
            Menu leftmenu = new DBUtils().GetMenuByID(2);
            ViewBag.LeftMenu = leftmenu;
            List<New> leftlist = new DBUtils().GetNew(menuid: 2);
            ViewBag.LeftList = leftlist;

            //不显示相关内容
            ViewBag.LeftType = 1;

            string path = "";
            if (menu.PID == -1)
            {
                path = new DBUtils().GetMenuByID(menu.PID).MName + "-" + menu.MName;
            }
            else
            {
                path = menu.MName;
            }

            ViewBag.Title = "芜湖县赵桥中心学校-" + path;
            return View();
        }

        public ActionResult CommentAdd()
        {
            string title = Request["title"];
            string content = Request["content"];
            string linkuser = Request["linkuser"];
            string linktype = Request["linktype"];
            int nid = Convert.ToInt32(Request["nid"]);
            //评论linktype为2
            new DBUtils().AddComment(nid, title, content, linkuser, linktype);

            return RedirectToAction("Article", new { id = nid });
        }

        public ActionResult Article(int id)
        {
            BuildTitleNav();

            New news = new DBUtils().GetNewByID(id);
            ViewBag.New = news;
            Menu menu = new DBUtils().GetMenuByID(news.MID);
            ViewBag.Menu = menu;
            //ViewBag.NewList = new DBUtils().GetNew(menuid: id);

            //获取左侧的文章
            Menu leftmenu = new DBUtils().GetMenuByID(2);
            ViewBag.LeftMenu = leftmenu;
            List<New> leftlist = new DBUtils().GetNew(menuid: 2);
            ViewBag.LeftList = leftlist;

            //获取评论
            string commentsql = "  select * from [Tb_Web_Comment] where [IsPublish]=1 and [Isdel]=0 and [NID]=" + news.NID + " order by [ComDate] desc";
            List<Comment> commentlist = new DBUtils().GetComment(commentsql);
            ViewBag.CommentList = commentlist;

            //显示相关内容
            ViewBag.LeftType = 2;
            List<New> rellist = new DBUtils().GetNew(menuid: menu.MID).Where(t => t.NID != id).ToList();

            ViewBag.RelList = rellist;



            string path = "";
            if (menu.PID == -1)
            {
                path = new DBUtils().GetMenuByID(menu.PID).MName + "-" + menu.MName;
            }
            else
            {
                path = menu.MName;
            }

            ViewBag.Title = "芜湖县赵桥中心学校-" + path;
            return View();
        }

        public ActionResult Resource(int gid = 0, int cid = 0, int etype = 0, int page = 1, int pagesize = 20)
        {
            BuildTitleNav();
            ViewBag.Title = "芜湖县赵桥中心学校-校本资源";

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


        public ActionResult IndexColumn(int menuid, int left = 0, int pagesize = 7, bool ismore = true, string type = "Column", int width = 1002)
        {
            ViewBag.Menu = new DBUtils().GetMenuByID(menuid);
            ViewBag.NewList = new DBUtils().GetNew(menuid: menuid, pagesize: pagesize);
            ViewBag.IsMore = ismore;
            ViewBag.Left = left + "px";
            ViewBag.MarqueeWidth = width + "px";
            ViewBag.Type = type;
            if (type == "Colmun")
            {
                return View("IndexColumn");
            }
            else if (type == "Marquee")
            {
                return View("IndexMarquee");
            }
            else
            {
                return View();
            }
        }

        public ActionResult ListColumn(int menuid, int page = 1, int pagesize = 20, string type = "Colmun", bool ismore = false)
        {
            Menu menu = new DBUtils().GetMenuByID(menuid);
            
            List<New> newlist = new DBUtils().GetNew(menuid: menuid, pagesize: 9999);
            ViewBag.Menu = menu;
            //ViewBag.NewList = newlist;
            ViewBag.IsMore = ismore;
            ViewBag.Type = type;


            PagedList<New> pList = newlist.ToPagedList(page, pagesize);
            pList.PageSize = pagesize;
            pList.TotalItemCount = newlist.Count;

            return View(pList);
        }

        public ActionResult FriendLink()
        {
            ViewBag.LinkList = new DBUtils().GetFriendLink(1);
            return View();
        }

        public void BuildTitleNav()
        {
            string navsql = "select * from [Tb_Web_Menu] where [Isdel]=0 and [IsNavigation]=1 and [IsOpen]=1 order by [MOrder]";
            List<Menu> menulist = new DBUtils().GetNav(navsql);
            //栏目
            ViewBag.Nav = menulist;
            ///算上首页
            ViewBag.NavCount = menulist.Count + 1;
        }

    }
}
