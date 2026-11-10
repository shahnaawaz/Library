using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DTO.ResponseDto
{
    public class ResiterResponseDto
    {
        public int UserId { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;
        public List<string> RoleName { get; set; } = new();

        public List<string> Permissions { get; set; } = new();
    }
}
