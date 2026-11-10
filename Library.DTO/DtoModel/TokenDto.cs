using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DTO.DtoModel
{
    public class TokenDto
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "User Name is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "User Name kam se kam 3 aur zyada se zyada 100 characters ka hona chahiye.")]
        public string UserName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Email sahi format mein nahi hai (e.g., example@domain.com).")]
        [StringLength(150)]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "At least one role is required.")]
        public List<string> Roles { get; set; } = new List<string>();
    }
}
