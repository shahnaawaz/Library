using Library.DAL.DataModel;
using Library.DTO.DtoModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BAL.IService
{
    public interface ICusRoleService
    {
        Task<Role> CreateRole(RoleDto roleDto);
        Task<Permission> CreatePermission(CreatePermissionDto createPermissionDto);
    }
}
