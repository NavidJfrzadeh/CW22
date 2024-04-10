using Core.AdminEntity.Contracts;
using Core.AdminEntity.DTOs;
using Core.UserEnitiy;

namespace App.Domain.Service
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }
        public Admin GetByUserPass(AdminLoginDTO adminLoginDTO)
        {
            return _adminRepository.GetByUserPass(adminLoginDTO);
        }
    }
}
