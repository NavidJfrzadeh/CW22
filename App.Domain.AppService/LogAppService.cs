using Core.LogEntity.Contracts;

namespace App.Domain.AppService
{
    public class LogAppService : ILogAppService
    {
        private readonly ILogService _logService;

        public LogAppService(ILogService logService)
        {
            _logService = logService;
        }
        public void Create(int requestId)
        {
            _logService.Create(requestId);
        }
    }
}
