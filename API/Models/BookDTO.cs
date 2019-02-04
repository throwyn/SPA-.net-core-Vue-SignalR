using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class BookDTO
    {
        public long Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime PublicationDate { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
