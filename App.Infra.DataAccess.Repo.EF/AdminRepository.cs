using App.Infra.Database.SQLServer.EF;
using Core.AdminEntity.Contracts;
using Core.AdminEntity.DTOs;
using Core.UserEnitiy;

namespace App.Infra.DataAccess.Repo.EF
{
    public class AdminRepository : IAdminRepository
    {
        private AppDbContext _dbContext;
        public AdminRepository(AppDbContext context)
        {
            _dbContext = context;
        }
        public Admin GetByUserPass(AdminLoginDTO adminLoginDTO)
        {
            return _dbContext.Admins.FirstOrDefault(a => a.Email == adminLoginDTO.Email && a.Password == adminLoginDTO.Password);
        }
    }
}
