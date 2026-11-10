using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.DataModel
{
    public class Permission
    {
        [Key]
        public int PermissionId { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }

        public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
    }
}

