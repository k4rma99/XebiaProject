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
    public class OrdersMVCController : Controller
    {
        private BookStoreDBEntities db = new BookStoreDBEntities();

        // GET: OrdersMVC
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Coupon).Include(o => o.User);
            return View(orders.ToList());
        }

        // GET: OrdersMVC/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: OrdersMVC/Create
        public ActionResult Create()
        {
            ViewBag.orCouponId = new SelectList(db.Coupons, "coId", "coCode");
            ViewBag.uId = new SelectList(db.Users, "uId", "uFName");
            return View();
        }

        // POST: OrdersMVC/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "oId,uId,orDateAndTime,orCouponId")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.orCouponId = new SelectList(db.Coupons, "coId", "coCode", order.orCouponId);
            ViewBag.uId = new SelectList(db.Users, "uId", "uFName", order.uId);
            return View(order);
        }

        // GET: OrdersMVC/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.orCouponId = new SelectList(db.Coupons, "coId", "coCode", order.orCouponId);
            ViewBag.uId = new SelectList(db.Users, "uId", "uFName", order.uId);
            return View(order);
        }

        // POST: OrdersMVC/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "oId,uId,orDateAndTime,orCouponId")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.orCouponId = new SelectList(db.Coupons, "coId", "coCode", order.orCouponId);
            ViewBag.uId = new SelectList(db.Users, "uId", "uFName", order.uId);
            return View(order);
        }

        // GET: OrdersMVC/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: OrdersMVC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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
