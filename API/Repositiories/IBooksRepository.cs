using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositiories
{
    public interface IBooksRepository
    {
        IEnumerable<BookDTO> GetBooks();
        void CreateBook(BookDTO item);
    }
}
