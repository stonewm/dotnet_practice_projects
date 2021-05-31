using BookstoreOData.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookstoreOData.Controllers
{
    public class BooksController : ODataController
    {
        private BookstoreContext _db;

        public BooksController(BookstoreContext context)
        {
            _db = context;
            if (context.Books.Count() == 0) {
                foreach (var b in DataSource.GetBooks()) {
                    context.Books.Add(b);
                    context.Presses.Add(b.Press);
                }
                context.SaveChanges();
            }
        }

        [EnableQuery]
        public IActionResult GetBooks()
        {
            return Ok(_db.Books);
        }

        [EnableQuery]
        public IActionResult GetBook(int key)
        {
            return Ok(_db.Books.FirstOrDefault(c => c.Id == key));
        }

        [EnableQuery]
        public IActionResult Post([FromBody] Book book)
        {
            _db.Books.Add(book);
            _db.SaveChanges();
            return Created(book);
        }

        [EnableQuery]
        public IActionResult Put([FromODataUri] int key, [FromBody] Book book)
        {
            Book b = _db.Books.FirstOrDefault(c => c.Id == key);
            if (b == null) {
                return NotFound();
            }

            if (key != book.Id) {
                return BadRequest();
            }

            b.Price = book.Price;
            _db.SaveChanges();

            return Updated(book);
        }

        [EnableQuery]
        public IActionResult Delete([FromODataUri] int key)
        {
            Book b = _db.Books.FirstOrDefault(c => c.Id == key);
            if (b == null) {
                return NotFound();
            }

            _db.Books.Remove(b);
            _db.SaveChanges();
            return Ok();
        }
    }
}
