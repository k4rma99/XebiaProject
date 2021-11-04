using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookStoreApiV2.Models;

namespace BookStoreApiV2.Controllers.mvc
{
    public class CategoriesMVCController : Controller
    {
        private BookStoreDBEntities db = new BookStoreDBEntities();

        // GET: CategoriesMVC
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        // GET: CategoriesMVC/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: CategoriesMVC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriesMVC/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cId,cName,cDescription,cImage,cStatus,cPosition,cCreatedAt,ImageFile")] Category category)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(category.ImageFile.FileName);
                string extension= Path.GetExtension(category.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff")+extension;
                //cImage contains the path for the image
                category.cImage = "~/Images/Category/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images/Category/"),fileName);
                category.ImageFile.SaveAs(fileName);
                using(BookStoreDBEntities db = new BookStoreDBEntities())
                {
                    db.Categories.Add(category);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");

            }
            ModelState.Clear();
            return View(category);
        }

        // GET: CategoriesMVC/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: CategoriesMVC/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cId,cName,cDescription,cImage,cStatus,cPosition,cCreatedAt,ImageFile")] Category category)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(category.ImageFile.FileName);
                string extension = Path.GetExtension(category.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                //cImage contains the path for the image
                category.cImage = "~/Images/Category/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images/Category/"), fileName);
                category.ImageFile.SaveAs(fileName);
                using (BookStoreDBEntities db = new BookStoreDBEntities())
                {
                    db.Entry(category).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");

            }
            ModelState.Clear();
            return View(category);
        }

        // GET: CategoriesMVC/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: CategoriesMVC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
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
