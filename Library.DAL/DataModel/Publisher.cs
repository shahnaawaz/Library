using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.DataModel
{
    public class Publisher
    {
        [Key]
        public int PublisherId { get; set; }

        public string PublishName { get; set; } = string.Empty;
        public ICollection<Books> Books { get; set; } = new List<Books>();
    }
}
