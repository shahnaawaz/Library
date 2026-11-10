using Library.DTO.DtoModel;
using Library.DTO.ResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BAL.IService
{
    public interface IUserService
    {
        Task<ResiterResponseDto> CreateUser(UserDto userDto);
        Task<LoginResponseDto> LoginUser(LoginDto login);
    }
}
