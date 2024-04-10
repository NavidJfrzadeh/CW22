using Core.RequestEntity.DTOs;

namespace Core.RequestEntity.Contracts
{
    public interface IRequestAppService
    {
        public string CreateRequest(RequestDTO requestDTO);
        public List<CarListDTO> GetList();
        public CarRequest GetById(int id);
        public void DeleteRequest(int id);
        public void AcceptRequest(int id);
        public List<CarListDTO> AllAcceptedRequests();
    }
}
