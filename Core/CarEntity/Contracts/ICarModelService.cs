using Core.CarEntity.DTOs;

namespace Core.CarEntity.Contracts
{
    public interface ICarModelService
    {
        public List<CarModelDTO> GetCarModel();
    }
}
