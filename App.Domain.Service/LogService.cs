using Core.LogEntity.Contracts;

namespace App.Domain.Service
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _logRepository;

        public LogService(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }
        public void Create(int requestId)
        {
            _logRepository.Create(requestId);
        }
    }
}
