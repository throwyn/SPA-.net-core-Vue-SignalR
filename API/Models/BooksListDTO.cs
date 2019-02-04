using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class BooksListDTO
    {
        public IEnumerable<BookDTO> Books { get; set; }

        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
    }
}
