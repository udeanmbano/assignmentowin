using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SalesmanProductManagement.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace SalesmanProductManagement.Controllers
{
    [Authorize]
    public class Tbl_CategoryController : Controller
    {
        private SalesmanProductManagementDbContext db = new SalesmanProductManagementDbContext();

         // GET: Tbl_Category
        public ActionResult Index()
        {
            var userId=User.Identity.GetUserId();

            return View(db.Categories.ToList().Where(a=>a.IsDelete==false && a.SalesmanUserId.ToString().Equals(userId)));
        }

        // GET: Tbl_Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Category tbl_Category = db.Categories.Find(id);
            if (tbl_Category == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Category);
        }

        // GET: Tbl_Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tbl_Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryId,CategoryName,IsActive,IsDelete")] Tbl_Category tbl_Category)
        {
            if (ModelState.IsValid)
            {
                tbl_Category.IsActive = true;
                tbl_Category.IsDelete = false;
                tbl_Category.SalesmanUserId =User.Identity.GetUserId();
                 db.Categories.Add(tbl_Category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Category);
        }

        // GET: Tbl_Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Category tbl_Category = db.Categories.Find(id);
            if (tbl_Category == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Category);
        }

        // POST: Tbl_Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryId,CategoryName,IsActive,IsDelete")] Tbl_Category tbl_Category)
        {
            if (ModelState.IsValid)
            {
                tbl_Category.IsActive = true;
                tbl_Category.IsDelete = false;
                tbl_Category.SalesmanUserId = User.Identity.GetUserId();
                db.Entry(tbl_Category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Category);
        }

        // GET: Tbl_Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Category tbl_Category = db.Categories.Find(id);
            if (tbl_Category == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Category);
        }

        // POST: Tbl_Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Category tbl_Category = db.Categories.Find(id);
            tbl_Category.IsActive = false;
            tbl_Category.IsDelete = true;
            tbl_Category.SalesmanUserId =User.Identity.GetUserId();
            db.Categories.AddOrUpdate(tbl_Category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
