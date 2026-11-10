using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.DataModel
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        public string AuthorName { get; set; } = string.Empty;

        public ICollection<Books> Books { get; set; } = new List<Books>();
    }
}
