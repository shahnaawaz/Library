using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DTO.DtoModel
{
    public class AssignRoleToUser
    {
        [Required(ErrorMessage = "User ID is required.")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Role ID is required.")]
        public int RoleId { get; set; }
    }

    public class UserRoleResponseDto
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public required string RoleName { get; set; }
    }
}
