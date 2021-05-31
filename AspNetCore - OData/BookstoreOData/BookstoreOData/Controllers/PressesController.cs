using BookstoreOData.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookstoreOData.Controllers
{
    public class PressesController : ODataController
    {
        private BookstoreContext _db;

        public PressesController(BookstoreContext context)
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
        public IActionResult Get()
        {
            return Ok(_db.Presses);
        }
    }
}
