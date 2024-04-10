using Core.CarEntity.DTOs;

namespace Core.CarEntity.Contracts
{
    public interface ICarModelAppService
    {
        public List<CarModelDTO> GetCarModels();
    }
}
