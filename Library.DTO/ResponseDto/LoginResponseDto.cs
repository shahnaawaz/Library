using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DTO.ResponseDto
{
    public class LoginResponseDto
    {
        public required string Token { get; set; }
        public ResiterResponseDto? UserDetails { get; set; }
    }
}
