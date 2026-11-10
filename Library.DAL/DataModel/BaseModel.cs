using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.DataModel
{
    public class BaseModel
    {
        
        public DateTime CreatedOn { get; set; } 
        
        public string? CreatedBy { get; set; }
        
        public DateTime DeletedOn { get; set; }
        
        public string? DeletedBy { get; set; }

        public bool IsDeleted { get; set; }
    }
}
