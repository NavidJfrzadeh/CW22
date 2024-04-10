using Core.CarEntity;

namespace Core.LogEntity.Contracts
{
    public interface ILogService
    {
        public void Create(string userPhoneNumber, string CarPlateNumber, int CarBrandId, CarBrand Brand, DateOnly CarProduceDate, DateTime CreatedAt);

    }
}
