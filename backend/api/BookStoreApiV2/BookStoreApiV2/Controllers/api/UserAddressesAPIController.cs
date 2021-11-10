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

namespace BookStoreApiV2.Controllers.api
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserAddressesAPIController : ApiController
    {
        private BookStoreDBEntities db = new BookStoreDBEntities();

        // GET: api/UserAddressesAPI
        public IQueryable<UserAddress> GetUserAddresses()
        {
            return db.UserAddresses;
        }

        // GET: api/UserAddressesAPI/5
        [ResponseType(typeof(UserAddress))]
        public IHttpActionResult GetUserAddress(int id)
        {
            List<UserAddress> userAddress = (from uaddr in db.UserAddresses where uaddr.uId==id select uaddr).ToList();
            if (userAddress == null)
            {
                return NotFound();
            }

            return Ok(userAddress);
        }

        // PUT: api/UserAddressesAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserAddress(int id, UserAddress userAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userAddress.id)
            {
                return BadRequest();
            }

            db.Entry(userAddress).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserAddressExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.OK);
        }

        // POST: api/UserAddressesAPI
        [ResponseType(typeof(UserAddress))]
        public IHttpActionResult PostUserAddress(UserAddress userAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserAddresses.Add(userAddress);
            db.SaveChanges();

            return Ok(userAddress);
        }

        // DELETE: api/UserAddressesAPI/5
        [ResponseType(typeof(UserAddress))]
        public IHttpActionResult DeleteUserAddress(int id)
        {
            UserAddress userAddress = db.UserAddresses.Find(id);
            if (userAddress == null)
            {
                return NotFound();
            }

            db.UserAddresses.Remove(userAddress);
            db.SaveChanges();

            return Ok(userAddress);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserAddressExists(int id)
        {
            return db.UserAddresses.Count(e => e.id == id) > 0;
        }
    }
}