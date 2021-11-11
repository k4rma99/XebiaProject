using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using BookStoreApiV2.Models;

namespace BookStoreApiV2.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class OrdersAPIController : ApiController
    {
        private BookStoreDBEntities db = new BookStoreDBEntities();

        // GET: api/OrdersAPI
        public IQueryable<Order> GetOrders()
        {
            return db.Orders;
        }

        // GET: api/OrdersAPI/5
        [ResponseType(typeof(Order))]
        public IHttpActionResult GetOrder(int id)
        {
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [ResponseType(typeof(List<Order>))]
        public IEnumerable<Order> GetOrdersByUserID(int id)
        {
            List<Order> orders = db.Orders.Where(o => o.uId == id).ToList();
            foreach (Order order in orders)
            {
                order.items = new List<BookOrder>();

                var bookIds = db.OrderDetails.Where(o => o.oId == order.oId).Select(o => o.bId).ToList();
                foreach (var bid in bookIds)
                {
                    BookOrder bookOrder = new BookOrder()
                    {
                        bookId = bid,
                        qty = db.OrderDetails.FirstOrDefault(o => o.bId == bid && o.oId==order.oId).bQuantity
                    };
                    bookOrder.book = db.Books.FirstOrDefault(b => b.bId == bid);
                    order.items.Add(bookOrder);
                }
            }
            return orders;
        }

        // PUT: api/OrdersAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrder(int id, Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != order.oId)
            {
                return BadRequest();
            }

            db.Entry(order).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/OrdersAPI
        [ResponseType(typeof(Order))]
        public IHttpActionResult PostOrder(Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            order.orDateAndTime = DateTime.Now.Date;
            
            db.Orders.Add(order);
            db.SaveChanges();

            int orderId = (db.Orders.OrderByDescending(o => o.oId).Take(1)).First().oId;
            foreach (BookOrder book in order.items)
            {
                Book bk = db.Books.FirstOrDefault(b => b.bId == book.bookId);
                
                OrderDetail orderDetail = new OrderDetail()
                {
                    oId = orderId,
                    uId = order.uId,
                    bId = bk.bId,
                    bISBN = bk.bISBN,
                    bPrice = bk.bPrice,
                    bQuantity = book.qty
                };

                db.OrderDetails.Add(orderDetail);
                db.SaveChanges();
            }

            return CreatedAtRoute("DefaultApi", new { id = order.oId }, order);
        }

        // DELETE: api/OrdersAPI/5
        [ResponseType(typeof(Order))]
        public IHttpActionResult DeleteOrder(int id)
        {
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }

            db.Orders.Remove(order);
            db.SaveChanges();

            return Ok(order);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderExists(int id)
        {
            return db.Orders.Count(e => e.oId == id) > 0;
        }
    }
}