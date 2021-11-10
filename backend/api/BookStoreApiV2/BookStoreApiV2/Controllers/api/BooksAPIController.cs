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
    public class BooksAPIController : ApiController
    {
        private BookStoreDBEntities db = new BookStoreDBEntities();

        // GET: api/BooksAPI
        public IEnumerable<Book> GetBooks()
        {
            List<Book> bookList =  (from books in db.Books where books.bStatus == "activated" orderby books.bCreatedAt select books).ToList();
            foreach (Book book in bookList)
            {
                book.Author = db.Authors.FirstOrDefault(a=>a.aId==book.aId);
                book.Category = db.Categories.FirstOrDefault(c=>c.cId==book.cId);
            }
            return bookList;
        }

        public IEnumerable<Book> GetFeaturedBooks()
        {
            List<Book> featuredBooks = (from books in db.Books where books.bStatus == "activated" orderby books.bPosition select books).Take(10).ToList();
            foreach (Book book in featuredBooks)
            {
                book.Author = db.Authors.FirstOrDefault(a => a.aId == book.aId);
                book.Category = db.Categories.FirstOrDefault(c => c.cId == book.cId);
            }
            return featuredBooks;
        }

        // GET: api/BooksAPI/5
        [ResponseType(typeof(Book))]
        public IHttpActionResult GetBook(int id)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // PUT: api/BooksAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBook(int id, Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != book.bId)
            {
                return BadRequest();
            }

            db.Entry(book).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
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

        // POST: api/BooksAPI
        [ResponseType(typeof(Book))]
        public IHttpActionResult PostBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            book.bCreatedAt = DateTime.Now.Date;
            db.Books.Add(book);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = book.bId }, book);
        }

        // DELETE: api/BooksAPI/5
        [ResponseType(typeof(Book))]
        public IHttpActionResult DeleteBook(int id)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            db.Books.Remove(book);
            db.SaveChanges();

            return Ok(book);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookExists(int id)
        {
            return db.Books.Count(e => e.bId == id) > 0;
        }
    }
}