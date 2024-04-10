using Core.AdminEntity.DTOs;
using Core.UserEnitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.AdminEntity.Contracts
{
    public interface IAdminRepository
    {
        public Admin GetByUserPass(AdminLoginDTO adminLoginDTO);
    }
}
