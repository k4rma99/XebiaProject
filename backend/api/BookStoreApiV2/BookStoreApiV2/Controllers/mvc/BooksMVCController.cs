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
    public class BooksMVCController : Controller
    {
        private BookStoreDBEntities db = new BookStoreDBEntities();

        // GET: BooksMVC
        public ActionResult Index()
        {
            var books = db.Books.Include(b => b.Author).Include(b => b.Category);
            return View(books.ToList());
        }

        // GET: BooksMVC/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: BooksMVC/Create
        public ActionResult Create()
        {
            ViewBag.aId = new SelectList(db.Authors, "aId", "aFName");
            ViewBag.cId = new SelectList(db.Categories, "cId", "cName");
            return View();
        }

        // POST: BooksMVC/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "bId,bName,cId,aId,bISBN,bPrice,bDescription,bPosition,bStatus,bImage,bQuantity,ImageFile")] Book book)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Books.Add(book);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(book.ImageFile.FileName);
                string extension = Path.GetExtension(book.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                //bImage contains the path for the image
                book.bImage = "~/Images/Book/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images/Book/"), fileName);
                book.ImageFile.SaveAs(fileName);
                using (BookStoreDBEntities db = new BookStoreDBEntities())
                {
                    db.Books.Add(book);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");

            }
            
            ViewBag.aId = new SelectList(db.Authors, "aId", "aFName", book.aId);
            ViewBag.cId = new SelectList(db.Categories, "cId", "cName", book.cId);
            ModelState.Clear();
            return View(book);
        }

        // GET: BooksMVC/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.aId = new SelectList(db.Authors, "aId", "aFName", book.aId);
            ViewBag.cId = new SelectList(db.Categories, "cId", "cName", book.cId);
            return View(book);
        }

        // POST: BooksMVC/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "bId,bName,cId,aId,bISBN,bPrice,bDescription,bPosition,bStatus,bImage,bQuantity,ImageFile")] Book book)
        {
           
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(book.ImageFile.FileName);
                string extension = Path.GetExtension(book.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                //bImage contains the path for the image
                book.bImage = "~/Images/Book/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images/Book/"), fileName);
                book.ImageFile.SaveAs(fileName);
                using (BookStoreDBEntities db = new BookStoreDBEntities())
                {
                    db.Entry(book).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");

            }
            
            
            ViewBag.aId = new SelectList(db.Authors, "aId", "aFName", book.aId);
            ViewBag.cId = new SelectList(db.Categories, "cId", "cName", book.cId);
            ModelState.Clear();
            return View(book);
        }

        // GET: BooksMVC/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: BooksMVC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
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
