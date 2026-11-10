using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DTO.DtoModel
{
    public class AssignPermissiontoRoleDto
    {
        [Required(ErrorMessage = "Role ID is required.")]
        public int RoleId { get; set; }
        [Required(ErrorMessage = "Permission ID is required.")]
        public int PermissionId { get; set; }
    }

    public class RolePermissionResponseDto
    {
        public int RoleId { get; set; }
        public required string RoleName { get; set; }
        public int PermissionId { get; set; }
        public required string Name { get; set; }
    }
}
