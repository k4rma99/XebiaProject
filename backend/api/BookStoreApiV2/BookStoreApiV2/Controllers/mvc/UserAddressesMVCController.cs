using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookStoreApiV2.Models;

namespace BookStoreApiV2.Controllers.mvc
{
    public class UserAddressesMVCController : Controller
    {
        private BookStoreDBEntities db = new BookStoreDBEntities();

        // GET: UserAddressesMVC
        public ActionResult Index()
        {
            var userAddresses = db.UserAddresses.Include(u => u.User);
            return View(userAddresses.ToList());
        }

        // GET: UserAddressesMVC/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAddress userAddress = db.UserAddresses.Find(id);
            if (userAddress == null)
            {
                return HttpNotFound();
            }
            return View(userAddress);
        }

        // GET: UserAddressesMVC/Create
        public ActionResult Create()
        {
            ViewBag.uId = new SelectList(db.Users, "uId", "uFName");
            return View();
        }

        // POST: UserAddressesMVC/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,uId,uAddressLineOne,uAddressLineTwo,uLandMark,uCity,uState,uCountry,uPincode")] UserAddress userAddress)
        {
            if (ModelState.IsValid)
            {
                db.UserAddresses.Add(userAddress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.uId = new SelectList(db.Users, "uId", "uFName", userAddress.uId);
            return View(userAddress);
        }

        // GET: UserAddressesMVC/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAddress userAddress = db.UserAddresses.Find(id);
            if (userAddress == null)
            {
                return HttpNotFound();
            }
            ViewBag.uId = new SelectList(db.Users, "uId", "uFName", userAddress.uId);
            return View(userAddress);
        }

        // POST: UserAddressesMVC/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,uId,uAddressLineOne,uAddressLineTwo,uLandMark,uCity,uState,uCountry,uPincode")] UserAddress userAddress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userAddress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.uId = new SelectList(db.Users, "uId", "uFName", userAddress.uId);
            return View(userAddress);
        }

        // GET: UserAddressesMVC/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAddress userAddress = db.UserAddresses.Find(id);
            if (userAddress == null)
            {
                return HttpNotFound();
            }
            return View(userAddress);
        }

        // POST: UserAddressesMVC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserAddress userAddress = db.UserAddresses.Find(id);
            db.UserAddresses.Remove(userAddress);
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
