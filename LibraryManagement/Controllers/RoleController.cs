using Library.BAL.IService;
using Library.DTO.DtoModel;
using LibraryManagement.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly ICusRoleService _role;
        public RoleController(ICusRoleService role)
        {
            _role = role;
        }

        [HttpPost]
        [Route("CreateRole")]
        public async Task<IActionResult> CreateRole(RoleDto roleDto)
        {
            if (roleDto == null) return BadRequest(ErrorMessage.InvalidUserData);
            try
            {
                var result = await _role.CreateRole(roleDto);
                if (result != null)
                {
                    return Ok(new
                    {
                        Message = ErrorMessage.RegisterSuccess,
                        Results = result
                    });
                }
                else
                {
                    return BadRequest(ErrorMessage.InvalidUserData);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }


        [HttpPost]
        [Route("CreatePermission")]
        public async Task<IActionResult> CreatePermission(CreatePermissionDto createPermissionDto)
        {
            if (createPermissionDto == null) return BadRequest(ErrorMessage.InvalidUserData);
            try
            {
                var result = await _role.CreatePermission(createPermissionDto);
                if (result != null)
                {
                    return Ok(new
                    {
                        Message = ErrorMessage.RegisterSuccess,
                        Results = result
                    });
                }
                else
                {
                    return BadRequest(ErrorMessage.InvalidUserData);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });

            }


        }



    }
}
