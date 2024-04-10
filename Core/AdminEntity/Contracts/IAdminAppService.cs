using Core.AdminEntity.DTOs;
using Core.UserEnitiy;

namespace Core.AdminEntity.Contracts
{
    public interface IAdminAppService
    {
        public Admin GetByUserPass(AdminLoginDTO adminLoginDTO);
    }
}
