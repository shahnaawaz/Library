using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.DataModel
{
    public class User:BaseModel
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [MaxLength(100)]
        public required string UserName { get; set; }
        [Required]
        [MaxLength(150)]
        public required string Email { get; set; }
        [Required]
        public required string PasswordHash { get; set; }
        public bool IsActive { get; set; }

        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
