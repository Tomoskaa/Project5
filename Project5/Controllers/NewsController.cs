using Project5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project5.Controllers
{
    public class NewsController : Controller
    {

        NewNewsEntities db = new NewNewsEntities();
        // GET: News
        public ActionResult Index()
        {
            return View(db.News.ToList());
        }

        // POST: News
        [HttpPost]
        public ActionResult Index(DateTime from, DateTime to)
        {
            return View(db.DateFunction(from, to));
        }
    }
}