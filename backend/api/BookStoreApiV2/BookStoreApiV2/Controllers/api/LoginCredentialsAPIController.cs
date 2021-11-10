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
using RandomDataGenerator.FieldOptions;
using RandomDataGenerator.Randomizers;

namespace BookStoreApiV2.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LoginCredentialsAPIController : ApiController
    {
        private BookStoreDBEntities db = new BookStoreDBEntities();

        [HttpPost]
        // GET: api/LoginCredentialsAPI
        public IQueryable<LoginCredential> GetLoginCredentials()
        {
            return db.LoginCredentials;
        }

        [HttpPost]
        // GET: api/LoginCredentialsAPI/5
        [ResponseType(typeof(LoginResp))]
        public IHttpActionResult VerifyLoginCredential(Login data)
        {
            LoginCredential loginCredential = db.LoginCredentials.FirstOrDefault(o => o.uMailId==data.uMailId && o.uPassword==data.uPassword);
            if (loginCredential == null || (from user in db.Users where user.uMailId==loginCredential.uMailId select user.uAccountStatus).ToString()=="deactivated")
            {
                return NotFound();
            }

            //-- Used to Generate random token. External RandomGenerator package was installed
            var randomizerText = RandomizerFactory.GetRandomizer(new FieldOptionsText { UseNumber = true, UseSpecial = false });

            LoginResp resp = new LoginResp()
            {
                token = randomizerText.Generate(),
                role = loginCredential.uRole,
                id = loginCredential.uId
            };
            return Ok(resp);
        }

        //// PUT: api/LoginCredentialsAPI/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutLoginCredential(string id, LoginCredential loginCredential)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != loginCredential.uMailId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(loginCredential).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!LoginCredentialExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/LoginCredentialsAPI
        //[ResponseType(typeof(LoginCredential))]
        //public IHttpActionResult PostLoginCredential(LoginCredential loginCredential)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.LoginCredentials.Add(loginCredential);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (LoginCredentialExists(loginCredential.uMailId))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtRoute("DefaultApi", new { id = loginCredential.uMailId }, loginCredential);
        //}

        //// DELETE: api/LoginCredentialsAPI/5
        //[ResponseType(typeof(LoginCredential))]
        //public IHttpActionResult DeleteLoginCredential(string id)
        //{
        //    LoginCredential loginCredential = db.LoginCredentials.Find(id);
        //    if (loginCredential == null)
        //    {
        //        return NotFound();
        //    }

        //    db.LoginCredentials.Remove(loginCredential);
        //    db.SaveChanges();

        //    return Ok(loginCredential);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool LoginCredentialExists(string id)
        //{
        //    return db.LoginCredentials.Count(e => e.uMailId == id) > 0;
        //}
    }
}