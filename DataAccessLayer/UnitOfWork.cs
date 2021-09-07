using DataAccessLayer.Interfaces;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private IGenericRepository<T> _genericRepository;
        private IDbConnection _connection;
        private IDbTransaction _dbTransaction;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="dbConnection"></param>
        public UnitOfWork(string connecStr)
        {
            _connection = new SqlConnection(connecStr);
            _connection.Open();
            _dbTransaction = _connection.BeginTransaction();
        }

        public IGenericRepository<T> GetGenericRepository =>
            _genericRepository ?? (_genericRepository = new GenericRepository<T>(_connection, _dbTransaction));

        public void Complete()
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
                _dbTransaction.Dispose();
                _dbTransaction = _connection.BeginTransaction();
                ResetRepositories();
            }
        }

        private void ResetRepositories()
        {
            _genericRepository = null;
        }

        public void Dispose()
        {
            if (_dbTransaction != null)
            {
                _dbTransaction.Dispose();
                _dbTransaction = null;
            }
            if (_connection != null)
            {
                _connection.Dispose();
                _connection = null;
            }
            GC.SuppressFinalize(this);
        }
    }
}
