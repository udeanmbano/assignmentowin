using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SalesmanProductManagement.Models;
using System.Data.Entity.Migrations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;


namespace SalesmanProductManagement.Controllers
{
    [Authorize]
    public class Tbl_ProductController : Controller
    {
        private SalesmanProductManagementDbContext db = new SalesmanProductManagementDbContext();

        // GET: Tbl_Product
        public async Task<ActionResult> Index()
        {

            var userId = User.Identity.GetUserId();

            var products = db.Products.Include(t => t.Tbl_Category).Where(a=>a.IsDelete==false && a.SalesmanUserId.ToString().Equals(userId));
            return View(await products.ToListAsync());
        }

        // GET: Tbl_Product/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Product tbl_Product = await db.Products.FindAsync(id);
            if (tbl_Product == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Product);
        }

        // GET: Tbl_Product/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Tbl_Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProductId,ProductName,CategoryId,IsActive,IsDelete,CreatedDate,ModifiedDate,Description,Price")] Tbl_Product tbl_Product)
        {
            if (ModelState.IsValid)
            {
                tbl_Product.IsActive = true;
                tbl_Product.IsDelete = false;
                tbl_Product.CreatedDate = DateTime.Now;
                tbl_Product.ModifiedDate = DateTime.Now;
                tbl_Product.SalesmanUserId = User.Identity.GetUserId();
                db.Products.Add(tbl_Product);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", tbl_Product.CategoryId);
            return View(tbl_Product);
        }

        // GET: Tbl_Product/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Product tbl_Product = await db.Products.FindAsync(id);
            if (tbl_Product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", tbl_Product.CategoryId);
            return View(tbl_Product);
        }

        // POST: Tbl_Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProductId,ProductName,CategoryId,IsActive,IsDelete,CreatedDate,ModifiedDate,Description,Price")] Tbl_Product tbl_Product)
        {
            if (ModelState.IsValid)
            {
                tbl_Product.IsActive = true;
                tbl_Product.IsDelete = false;
                tbl_Product.ModifiedDate = DateTime.Now;
                tbl_Product.SalesmanUserId =User.Identity.GetUserId();
                db.Entry(tbl_Product).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", tbl_Product.CategoryId);
            return View(tbl_Product);
        }

        // GET: Tbl_Product/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Product tbl_Product = await db.Products.FindAsync(id);
            if (tbl_Product == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Product);
        }

        // POST: Tbl_Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Tbl_Product tbl_Product = await db.Products.FindAsync(id);
            tbl_Product.IsDelete = true;
            tbl_Product.IsActive = false;
            tbl_Product.SalesmanUserId = User.Identity.GetUserId();
            db.Products.AddOrUpdate(tbl_Product);
            await db.SaveChangesAsync();
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
