using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DTO.DtoModel
{
    public class UserDto
    {

        [Required(ErrorMessage = "User Name is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "User Name kam se kam 3 aur zyada se zyada 100 characters ka hona chahiye.")]
        public required  string UserName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Email sahi format mein nahi hai (e.g., example@domain.com).")]
        [StringLength(150)]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password kam se kam 8 characters ka hona chahiye.")]
        public required string Password { get; set; }
    }
}
