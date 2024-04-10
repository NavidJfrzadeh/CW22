using Core.RequestEntity.DTOs;

namespace Core.RequestEntity.Contracts
{
    public interface IRequestRepository
    {
        public void CreateRequest(RequestDTO requestDTO);
        public List<CarListDTO> GetList(DateOnly date);
        public CarRequest GetById(int id);
        public void DeleteRequest(int id);
        public void AcceptRequest(int id);
        public List<CarListDTO> AllAcceptedRequests();
        public int Capacity(DateOnly date);
        public bool ValidCarPlateNumber(string carPlateNumber);
        public List<DateOnly> GetDates();
    }
}
