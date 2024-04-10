using Core.RequestEntity.DTOs;

namespace Core.RequestEntity.Contracts
{
    public interface IRequestService
    {
        public int CreateRequest(RequestDTO requestDTO);
        public List<CarListDTO> GetList();
        public CarRequest GetById(int id);
        public void DeleteRequest(int id);
        public void AcceptRequest(int id);
        public List<CarListDTO> AllAcceptedRequests();
        public int Capacity(DateOnly date);
    }
}
