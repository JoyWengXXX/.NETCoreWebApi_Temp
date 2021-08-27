using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;
        private IGenericRepository<T> _genericRepository;
        private bool _disposed;
        private readonly string _tableName;
        private readonly string _dbConnec;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="dbConnection"></param>
        public UnitOfWork(string tableName, string dbConnection)
        {
            _tableName = tableName;
            _dbConnec = dbConnection;
        }

        /// <summary>
        /// Generate new connection based on connection string
        /// </summary>
        /// <returns></returns>
        private SqlConnection SqlConnection()
        {
            return new SqlConnection(_dbConnec);
        }

        public IGenericRepository<T> GetGenericRepository =>
            _genericRepository ?? (_genericRepository = new GenericRepository<T>(_transaction));

        public void Complete()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
