using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ColetteMills.Models;
using PagedList;

namespace ColetteMills.Controllers
{
    public class HomeController : Controller
    {
        private PortfolioEntities db = new PortfolioEntities();
        public ActionResult Index(string currentFilter, int? page)
        {

            int pageSize = 25;
            int pageNumber = (page ?? 1);
            return View(db.Portfolios.OrderByDescending(i => i.ImagePath).ToPagedList(pageNumber, pageSize));

        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }
    }
}
