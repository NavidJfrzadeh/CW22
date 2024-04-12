using App.Infra.Database.SQLServer.EF;
using Core.CarEntity;
using Core.LogEntity;
using Core.LogEntity.Contracts;

namespace App.Infra.DataAccess.Repo.EF
{
    public class LogRepository : ILogRepository
    {
        private readonly AppDbContext _context;
        public LogRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Create(string userPhoneNumber, string CarPlateNumber, int CarBrandId, CarBrand Brand, DateOnly CarProduceDate)
        {
            Log newLog = new Log()
            {
                UserPhoneNumber = userPhoneNumber,
                CarPlateNumber = CarPlateNumber,
                CarBrandId = CarBrandId,
                CarBrand = Brand,
                CarProduceDate = CarProduceDate
            };
            _context.Logs.Add(newLog);
            _context.SaveChanges();
        }
    }
}
