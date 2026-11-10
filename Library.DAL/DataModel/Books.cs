using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.DataModel
{
    public class Books
    {
        [Key]
        public int BookId { get; set; }
        public  string Title { get; set; } = string.Empty;
        public int TotalCopies { get; set; }
        public int AvailableCopies { get; set; }

        public int AutherId {  get; set; }
        public int CategoryId { get; set; }
        public int PublisherId { get; set; }

        public Author Author { get; set; } = null!;
        public Category Category { get; set; } = null!;
        public Publisher Publisher { get; set; } = null!;

    }
}
