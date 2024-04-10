using Core.CarEntity.Contracts;
using Core.CarEntity.DTOs;

namespace App.Domain.Service
{
    public class CarModelService : ICarModelService
    {
        private readonly ICarModelRepository _carModelRepository;

        public CarModelService(ICarModelRepository carModelRepository)
        {
            _carModelRepository = carModelRepository;
        }
        public List<CarModelDTO> GetCarModel()
        {
           return _carModelRepository.GetAllModels();
        }
    }
}
