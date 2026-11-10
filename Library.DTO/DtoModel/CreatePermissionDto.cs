using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DTO.DtoModel
{
    public class CreatePermissionDto
    {
        [Required(ErrorMessage = "Permission Name zaroori hai.")]
        [MaxLength(100, ErrorMessage = "Permission Name 100 characters se bada nahi ho sakta.")]
        public required string Name { get; set; }
    }
}
