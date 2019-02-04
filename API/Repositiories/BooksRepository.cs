using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Data;
using AutoMapper;

namespace API.Repositiories
{
    public class BooksRepository : IBooksRepository
    {
        private LibraryDBContext _context; 

        public BooksRepository(LibraryDBContext context)
        {
            _context = context;
        }

        public void CreateBook(BookDTO item)
        {
            var result = _context.Books.Add(Mapper.Map<BookDTO, Book>(item));
            _context.SaveChanges();
        }

        public IEnumerable<BookDTO> GetBooks() => Mapper.Map<IEnumerable<Book>, IEnumerable<BookDTO>>(_context.Books);

    }
}
