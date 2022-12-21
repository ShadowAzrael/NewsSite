using Microsoft.AspNetCore.Mvc;
using NewsSite.Models;
using NewsSite.Models.Database;
using System;
using System.Linq;

namespace NewsSite.Controllers
{
    public class TestController : Controller
    {
        private readonly NewsSiteContext _db;
        public TestController(NewsSiteContext db)
        {
            _db = db;
        }

        [Route("/")]
        [Route("/Index.html")]
        public IActionResult Index(string kind, string search)
        {
            if (search != null)
            {
                ViewData["news"] = _db.News.Where(x => x.Title.Contains(search)).ToList();
            }
            else if (kind == null || kind == "全部")
            {
                ViewData["news"] = _db.News.ToList();
            }
            else
            {
                ViewData["news"] = _db.News.Where(x => x.Kind == kind).ToList();
            }
            return View();
        }

        [Route("/detail.html")]
        public IActionResult detail(int id)
        {
            ViewData["news"] = _db.News.FirstOrDefault(x => x.Id == id);
            return View();
        }

    }
}
