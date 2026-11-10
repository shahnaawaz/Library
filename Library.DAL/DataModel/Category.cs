using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.DataModel
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = string.Empty;

        public ICollection<Books> Books { get; set; } = new List<Books>();

    }
}
