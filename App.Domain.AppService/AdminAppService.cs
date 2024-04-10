using Core.AdminEntity.Contracts;
using Core.AdminEntity.DTOs;
using Core.UserEnitiy;

namespace App.Domain.AppService
{
    public class AdminAppService : IAdminAppService
    {
        private readonly IAdminService _adminService;

        public AdminAppService(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public Admin GetByUserPass(AdminLoginDTO adminLoginDTO)
        {
            return _adminService.GetByUserPass(adminLoginDTO);
        }
    }
}
