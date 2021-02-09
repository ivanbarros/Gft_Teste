using Gft.Domain.Entities;
using Gft.Domain.Interfaces.Repository;
using Gft.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gft.Domain.Services
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _logRepository;
        public LogService(ILogRepository logRepository)
        {
            _logRepository = logRepository;

        }


        public async Task<IEnumerable<LogEntity>> GetLog()
        {
            return await _logRepository.GetLog();
        }


        public async Task<LogEntity> InsertLog(LogEntity log)
        {

            return await _logRepository.InsertLog(log);
        }
    }
}
