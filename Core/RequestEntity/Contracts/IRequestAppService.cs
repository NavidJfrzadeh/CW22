using Core.RequestEntity.DTOs;

namespace Core.RequestEntity.Contracts
{
    public interface IRequestAppService
    {
        public string CreateRequest(RequestDTO requestDTO);
        public List<CarListDTO> GetListByDate(DateOnly date);
        public CarRequest GetById(int id);
        public void DeleteRequest(int id);
        public void AcceptRequest(int id);
        public List<CarListDTO> AllAcceptedRequests();
        public List<DateOnly> GetDates();
    }
}
