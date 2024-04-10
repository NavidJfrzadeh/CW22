using Core.AdminEntity.DTOs;
using Core.UserEnitiy;

namespace Core.AdminEntity.Contracts
{
    public interface IAdminService
    {
        public Admin GetByUserPass(AdminLoginDTO adminLoginDTO);
    }
}
