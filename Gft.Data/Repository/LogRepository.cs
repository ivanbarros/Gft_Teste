using Gft.Domain.Entities;
using Gft.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gft.Data.Repository
{
    public class LogRepository : ILogRepository
    {
        private IUnitOfWork _unitOfWork;
        public LogRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<LogEntity>> GetLog()
        {
            var query = $@"SELECT log.id,
                        log.NomeMetodo,
                        log.NomeController,
                        log.errorMessage,
                        log.DataLog,
                        log.idUsuario
                        FROM log;";
            return await _unitOfWork.BaseRepository().FindByQuery<LogEntity>(query);
        }

        public async Task<LogEntity> InsertLog(LogEntity log)
        {
            var query = $@"INSERT INTO `db_a5617e_ibaviva`.`log`
                            (
                            `CreateDate`,
                            `nomeMetodo`,
                            `nomeController`,
                            `errorMessage`,
                            `dataLog`)
                            VALUES
                            ( CURRENT_TIMESTAMP,
                            {log.nomeMetodo},
                            {log.NomeController },
                            {log.errorMessage},
                            CURRENT_TIMESTAMP);

                        SELECT LAST_INSERT_ID();";
            //var param = new
            //{
            //    //NomeMetodo = log.nomeMetodo,
            //    //log.NomeController,
            //    log.errorMessage
            //    //,
            //    //DataLog = log.CreatedAt,
            //    //log.idUsuario
            //};

            return await _unitOfWork.BaseRepository().InsertIdentityTable<LogEntity>(query, log);
        }
    }
}
