using Core.CarEntity.DTOs;

namespace Core.CarEntity.Contracts
{
    public interface ICarModelRepository
    {
        public List<CarModelDTO> GetAllModels();
    }
}
