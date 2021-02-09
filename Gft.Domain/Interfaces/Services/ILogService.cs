using Gft.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gft.Domain.Interfaces.Services
{
    public interface ILogService
    {
        Task<IEnumerable<LogEntity>> GetLog();
        Task<LogEntity> InsertLog(LogEntity log);
    }
}
