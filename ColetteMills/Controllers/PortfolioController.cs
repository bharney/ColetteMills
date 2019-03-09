using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ColetteMills.Models;
using System.IO;
using PagedList;

namespace ColetteMills.Controllers
{
    public class PortfolioController : Controller
    {
        private PortfolioEntities db = new PortfolioEntities();

        //
        // GET: /Portfolio/

        public ActionResult Index()
        {
            return View(db.Portfolios.ToList());
        }

        //
        // GET: /Portfolio/Details/5

        public ActionResult Details(int id = 0)
        {
            Portfolio portfolio = db.Portfolios.Find(id);
            if (portfolio == null)
            {
                return HttpNotFound();
            }
            return View(portfolio);
        }

        //
        // GET: /Portfolio/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Portfolio/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Portfolio portfolio, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                string path = Path.Combine(Server.MapPath("../Images"),
                                    Path.GetFileName(file.FileName));
                file.SaveAs(path);
                portfolio.ImagePath = Path.Combine(("../Images/"), Path.GetFileName(file.FileName));
                ViewBag.Message = "File uploaded successfully";
            }

            if (ModelState.IsValid)
            {
                db.Portfolios.Add(portfolio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(portfolio);
        }

        //
        // GET: /Portfolio/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Portfolio portfolio = db.Portfolios.Find(id);
            if (portfolio == null)
            {
                return HttpNotFound();
            }
            return View(portfolio);
        }

        //
        // POST: /Portfolio/Edit/5

        [HttpPost]
        public ActionResult Edit(Portfolio portfolio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(portfolio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(portfolio);
        }

        //
        // GET: /Portfolio/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Portfolio portfolio = db.Portfolios.Find(id);
            if (portfolio == null)
            {
                return HttpNotFound();
            }
            return View(portfolio);
        }

        //
        // POST: /Portfolio/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Portfolio portfolio = db.Portfolios.Find(id);
            db.Portfolios.Remove(portfolio);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}