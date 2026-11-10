using AutoMapper;
using BCrypt.Net;
using Library.BAL.IService;
using Library.DAL;
using Library.DAL.DataModel;
using Library.DAL.Migrations;
using Library.DTO.DtoModel;
using Library.DTO.ResponseDto;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Library.BAL.Services
{
    public class UserService:IUserService
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<UserService> _logger;
        private readonly JwtService _jwtService;

        public UserService(AppDbContext context, ILogger<UserService> logger, JwtService jwtService)
        {
            _appDbContext = context;
            _logger = logger;
            _jwtService = jwtService;
        }

        public async Task<ResiterResponseDto> CreateUser(UserDto userDto)
        {
            try
            {


                var ExistsUser = await _appDbContext.User.AnyAsync(x => x.Email.ToLower() == userDto.Email.ToLower());
                if (ExistsUser)
                {
                    throw new InvalidOperationException("User already exists.");
                }

                var ChashPassword = BCrypt.Net.BCrypt.HashPassword(userDto.Password);
                var registerUsers = new User
                {
                    UserName = userDto.UserName,
                    Email = userDto.Email,
                    PasswordHash = ChashPassword
                };
                _appDbContext.User.Add(registerUsers);
                await _appDbContext.SaveChangesAsync();

                var role = await _appDbContext.Role.FirstOrDefaultAsync(x => x.RoleName == "User");
                if (role == null)
                {
                    throw new KeyNotFoundException("Default User role not found.");
                }
                var userRole = new UserRole
                {
                    UserId = registerUsers.UserId,
                    RoleId = role.RoleId,

                };
                _appDbContext.UserRole.Add(userRole);
                await _appDbContext.SaveChangesAsync();


                // 6. Get default permissions
                var permissions = await _appDbContext.Permission
                    .Where(x =>
                        x.Name == "create" ||
                        x.Name == "update")
                    .ToListAsync();

                if (permissions==null)
                {
                    throw new KeyNotFoundException(
                        "Default permissions create/update were not found.");
                }

                foreach (var permission in permissions)
                {
                    var rolePermission = new RolePermission
                    {
                        RoleId = role.RoleId,
                        PermissionId = permission.PermissionId
                    };

                    _appDbContext.RolePermission.Add(rolePermission);
                }

                await _appDbContext.SaveChangesAsync();

                var userPermissions = await _appDbContext.RolePermission
                .Where(x => x.RoleId == role.RoleId)
                .Select(x => x.Permission.Name)
                .ToListAsync();

                var respnseResult = new ResiterResponseDto
                {
                    UserId = registerUsers.UserId,
                    UserName = registerUsers.UserName,
                    Email = registerUsers.Email,
                    Role = role.RoleName,
                    Permissions = userPermissions
                };
                 
                return respnseResult;

            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error while creating user. Error: {Error}",
                    ex.InnerException?.Message ?? ex.Message);

                throw;
            }
        }

        public async Task<LoginResponseDto> LoginUser(LoginDto login)
        {
            try
            {
                
                var exitUser = await _appDbContext.User.FirstOrDefaultAsync(x=>x.Email.ToLower() == login.Email.ToLower());
                if (exitUser == null)
                {
                    throw new UnauthorizedAccessException("Invalid Email or password");
                }

                //bool matchPassword = BCrypt.Net.BCrypt.Verify(login.Password, exitsUser.PasswordHash);
                bool isPasswordValid = BCrypt.Net.BCrypt.Verify(login.Password, exitUser.PasswordHash);
                if (!isPasswordValid) {
                    throw new UnauthorizedAccessException("Invalid Email or password");
                }
                List<string> roleNames = await _appDbContext.UserRole
                    .Where(ur => ur.UserId == exitUser.UserId)
                    .Select(ur => ur.Role.RoleName).ToListAsync();

                var resultToken = new TokenDto()
                {
                    UserId = exitUser.UserId,
                    UserName=exitUser.UserName,
                    Email=exitUser.Email,
                    Roles = roleNames
                };
                var token = _jwtService.GenerateToken(resultToken);
                var responseData = new LoginResponseDto()
                {
                    Token = token,
                    UserDetails = new ResiterResponseDto
                    {
                        UserId = exitUser.UserId,
                        UserName = exitUser.UserName,
                        Email = exitUser.Email,
                        RoleName = roleNames ?? new List<string>() 
                    }
                };
                return responseData;

            }
            catch (Exception ex) {
                _logger.LogError(ex, "Error while creating user. Error:{Error}",
                    ex.InnerException?.Message ?? ex.Message);
                throw;
            }
        }


        
    }
}
