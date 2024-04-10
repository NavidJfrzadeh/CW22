using Core.CarEntity;

namespace Core.LogEntity.Contracts
{
    public interface ILogRepository
    {
        public void Create(string userPhoneNumber, string CarPlateNumber, int CarBrandId, CarBrand Brand, DateOnly CarProduceDate);
    }
}
