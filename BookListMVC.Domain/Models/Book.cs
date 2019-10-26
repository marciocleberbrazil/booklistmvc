using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookList.Domain.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
    }
}
