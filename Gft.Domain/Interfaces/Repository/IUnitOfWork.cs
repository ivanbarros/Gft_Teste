using System;
using System.Data;

namespace Gft.Domain.Interfaces.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IDbTransaction _dbTransaction { get; }

        IBaseRepository BaseRepository();

        void Begin();
        void Commit();
        void Rollback();
    }
}
