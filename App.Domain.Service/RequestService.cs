using Core.RequestEntity;
using Core.RequestEntity.Contracts;
using Core.RequestEntity.DTOs;

namespace App.Domain.Service
{
    public class RequestService : IRequestService
    {
        private readonly IRequestRepository _requestRepo;

        public RequestService(IRequestRepository requestRepository)
        {
            _requestRepo = requestRepository;
        }

        public void AcceptRequest(int id)
        {
            _requestRepo.AcceptRequest(id);
        }

        public List<CarListDTO> AllAcceptedRequests()
        {
            return _requestRepo.AllAcceptedRequests();
        }

        public int Capacity(DateOnly date)
        {
            return _requestRepo.Capacity(date);
        }

        public void CreateRequest(RequestDTO requestDTO)
        {
           _requestRepo.CreateRequest(requestDTO);
        }

        public void DeleteRequest(int id)
        {
            _requestRepo.DeleteRequest(id);
        }

        public CarRequest GetById(int id)
        {
            return _requestRepo.GetById(id);
        }

        public List<DateOnly> GetDates()
        {
           return _requestRepo.GetDates();
        }

        public List<CarListDTO> GetList(DateOnly date)
        {
            return _requestRepo.GetList(date);
        }

        public bool ValidCarPlateNumber(string carPlateNumber)
            => _requestRepo.ValidCarPlateNumber(carPlateNumber);
    }
}
