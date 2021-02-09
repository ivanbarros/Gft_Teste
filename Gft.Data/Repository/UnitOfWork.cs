using Gft.Domain.Interfaces.Repository;
using System;
using System.Data;

namespace Gft.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbConnection _dbConnection;
        private readonly IBaseRepository _baseRepository;
        private bool _disposed;

        public IDbTransaction _dbTransaction { get; private set; }

        public UnitOfWork(IDbTransaction dbTransaction, IBaseRepository baseRepository)
        {
            _dbConnection = baseRepository._dbConnection;
            _dbTransaction = dbTransaction;
            _baseRepository = baseRepository;
        }

        public IBaseRepository BaseRepository() =>
            _baseRepository;

        ~UnitOfWork() =>
            dispose(false);

        public void Begin()
        {
            _dbTransaction.Dispose();
            _baseRepository._dbTransaction.Dispose();

            _dbTransaction = _dbConnection.BeginTransaction();
            _baseRepository._dbTransaction = _dbTransaction;
        }

        public void Commit()
        {
            try
            {
                _dbTransaction.Commit();
            }
            catch
            {
                _dbTransaction.Rollback();
                throw;
            }
            finally
            {
                Begin();
            }
        }

        public void Rollback()
        {
            try
            {
                _dbTransaction.Rollback();
            }
            catch
            {
                throw;
            }
            finally
            {
                Begin();
            }
        }

        public void Dispose()
        {
            dispose(true);
            GC.SuppressFinalize(this);
        }

        private void dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_dbTransaction != null)
                    {
                        _dbTransaction.Dispose();
                        _dbTransaction = null;
                    }
                }
                _disposed = true;
            }
        }
    }
}
