using API.Models;
using API.Repositiories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBooksRepository _booksRepository;

        public BooksController(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        // GET api/books
        [HttpGet]
        public ActionResult<IEnumerable<BookDTO>> Get(int page = 1)
        {
            var books = _booksRepository.GetBooks();
            int recordCount = books.Count();
            int pageCount = (int)Math.Ceiling((decimal)recordCount / 20);
            books = books.Skip((page - 1) * 20).Take(20);
            BooksListDTO result = new BooksListDTO()
            {
                Books = books,
                CurrentPage = page,
                PageCount = pageCount
            };
            return Ok(result);
        }

        // POST api/books
        [HttpPost]
        public ActionResult Post([FromBody] BookDTO item)
        {
            if (!ModelState.IsValid)
                return BadRequest();
             _booksRepository.CreateBook(item);
            return Ok();
        }
        
    }
}
