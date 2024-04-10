using Core.CarEntity;
using Core.LogEntity.Contracts;

namespace App.Domain.Service
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _logRepository;

        public LogService(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public void Create(string userPhoneNumber, string CarPlateNumber, int CarBrandId, CarBrand Brand, DateOnly CarProduceDate)
        {
            _logRepository.Create(userPhoneNumber, CarPlateNumber, CarBrandId, Brand, CarProduceDate);
        }
    }
}
