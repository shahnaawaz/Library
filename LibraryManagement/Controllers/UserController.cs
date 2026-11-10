using Library.BAL.IService;
using Library.DTO.DtoModel;
using LibraryManagement.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService service;
        public UserController(IUserService service)
        {
            this.service = service;
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> AddUser([FromBody] UserDto userDto)
        {
            if (userDto == null) return BadRequest(ErrorMessage.InvalidUserData);
            try
            {
                var result = await service.CreateUser(userDto);
                return Ok(new
                {
                    Message = ErrorMessage.RegisterSuccess,
                    Results = result
                });
            }
            catch (Exception ex) {
                return BadRequest(new
                {
                    message = ex.Message,
                    innerMessage = ex.InnerException?.Message
                });
            }
           
        }

        [HttpPost]
        [Route("UserLogin")]

        public async Task<IActionResult> LoginUsers(LoginDto login)
        {
            if (login == null) return BadRequest(ErrorMessage.InvalidUserData);
            try
            {
                var result = await service.LoginUser(login);
                return Ok(new
                {
                    Message = ErrorMessage.LoginSuccess,
                    Result=result
                    
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message,
                    innerMessage = ex.InnerException?.Message
                });
            }
        }
    }
}
