using Core.CarEntity.Contracts;
using Core.CarEntity.DTOs;

namespace App.Domain.AppService
{
    public class CarModelAppService : ICarModelAppService
    {
        private readonly ICarModelService _carModelService;

        public CarModelAppService(ICarModelService carModelService)
        {
            _carModelService = carModelService;
        }
        public List<CarModelDTO> GetCarModels()
        {
            return _carModelService.GetCarModel();
        }
    }
}
