using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.DataModel
{
    public class RolePermission
    {
        [Key]
        public int RolePermissionId { get; set; }
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Role Role { get; set; } = null!;

        public int PermissionId { get; set; }
        [ForeignKey("PermissionId")]
        public Permission Permission { get; set; } = null!;
    }
}
