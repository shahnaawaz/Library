using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DTO.DtoModel
{
    public class UpdateRoleDto
    {
        [Required(ErrorMessage = "Role ID is required.")]
        public int RoleId { get; set; }
        [Required(ErrorMessage = "New Role Name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Role name must be between 3 and 50 characters.")]
        public required string RoleName { get; set; }
    }
}
