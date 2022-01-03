using Project5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project5.Controllers
{
    public class HomeController : Controller
    {
        NewNewsEntities db = new NewNewsEntities();
        public ActionResult Index()
        {
            return View();

        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Account()
        {
            return View();
        }



        // GET: Home/GetNewsList
        public ActionResult GetNewsList(string searchCategory, string searchTitle, string searchDesc)
        {
            var news = from n in db.News select n;
            if (!String.IsNullOrEmpty(searchTitle))
            {
                news = news.Where(n => n.Title.Contains(searchTitle));
            }
            if (!String.IsNullOrEmpty(searchDesc))
            {
                news = news.Where(n => n.Description.Contains(searchDesc));
            }
            if (!String.IsNullOrEmpty(searchCategory))
            {
                news = news.Where(n => n.Category.Name.Contains(searchCategory));
            }

            //var categories = from c in db.Categories select c;
            //if (!String.IsNullOrEmpty(searchTitle))
            //{
            //    news = categories.Where(n => n.Name.Contains(searchCategory));
            //}
            //var categories = db.Categories.ToList();
            //SelectList list = new SelectList(categories, "Id", "Name");
            //ViewBag.categoryList = list;


            return View();
        }

        // POST: Home/GetNewsList
        [HttpPost]
        public ActionResult GetNewsList(News news)
        {

            return View();
        }

        [HttpGet]
        public ActionResult GetNewsListPartial()
        {
            List<News> newsList = db.News.ToList();

            return PartialView(newsList);
        }

        [HttpPost]
        public ActionResult GetNewsListPartial(News news, string from, string to)
        {
            List<News> newList = db.News.Where(x => x.Category == news.Category || x.Title == news.Title || 
            x.Description == news.Description || x.DatePosted == news.DatePosted).ToList();

            //return View(db.DateFunction(from, to));
            return PartialView();
        }
    }
}