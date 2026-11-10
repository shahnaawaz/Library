using AutoMapper;
using Library.BAL.IService;
using Library.DAL;
using Library.DAL.DataModel;
using Library.DTO.DtoModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BAL.Services
{
    public class RoleService: ICusRoleService
    {
        private readonly AppDbContext _context;
        public RoleService(AppDbContext context)
        {
            _context = context;
            
        }

        public async Task<Role> CreateRole(RoleDto roleDto)
        {
            var trimNamed = roleDto.RoleName.Trim();
            var roleExists = await _context.Role.AnyAsync(x => x.RoleName.ToLower() == trimNamed.ToLower());
            if (roleExists) {
                throw new InvalidOperationException($"{trimNamed} role is already exists");
            }
            var mapData = new Role
            {
                RoleName= trimNamed
            };
            
            _context.Role.Add(mapData);
            await _context.SaveChangesAsync();
            return mapData;
        }

        public async Task<Role> UpdateRole(UpdateRoleDto updateRoleDto)
        {
            var existingRole = await _context.Role.FindAsync(updateRoleDto.RoleId);
            if (existingRole == null)
            {
                throw new KeyNotFoundException($"Role with ID {updateRoleDto.RoleId} not found.");
            }

            var nameExists = await _context.Role.AnyAsync(r => r.RoleName.ToLower() == updateRoleDto.RoleName && r.RoleId != updateRoleDto.RoleId);
            if (nameExists)
            {
                throw new InvalidOperationException($"Another role named '{updateRoleDto.RoleName}' already exists.");
            }
            //_mapper.Map<Role>(updateRoleDto);
            await _context.SaveChangesAsync();
            return existingRole;
        }

        public async Task<Permission> CreatePermission(CreatePermissionDto createPermissionDto)
        {
            var trimNamed = createPermissionDto.Name.Trim();
            var permissionExists = await _context.Permission.AnyAsync(x=> x.Name.ToLower() == trimNamed.ToLower());
            if (permissionExists)
            {
                throw new InvalidOperationException($"{trimNamed} is already exists");

            }
            // var mapData = _mapper.Map<Permission>(createPermissionDto);
            //  mapData.Name = trimNamed;
            var mapData = new Permission
            {
                Name = trimNamed
            };

            _context.Permission.Add(mapData);
           await _context.SaveChangesAsync();
            return mapData;
        }
    }
}
