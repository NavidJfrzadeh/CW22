using App.Infra.Database.SQLServer.EF;
using Core.CarEntity.Contracts;
using Core.CarEntity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DataAccess.Repo.EF
{
    public class CarModelRepository : ICarModelRepository
    {
        private AppDbContext _dbContext;
        public CarModelRepository(AppDbContext context)
        {
            _dbContext = context;
        }
        public List<CarModelDTO> GetAllModels()
        {
            var carModels = _dbContext.Brands.Select(m=> new CarModelDTO()
            {
                Id = m.Id,
                brand = m.Brand,
            }
            ).ToList();

            return carModels;
        }
    }
}
