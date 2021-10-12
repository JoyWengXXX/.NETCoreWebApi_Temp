using System;

namespace DataAccessLayer.Dapper.Interfaces
{
    public interface IUnitOfWork<T> : IDisposable
    {
        IGenericRepository<T> GetGenericRepository { get; }

        void Complete();
    }
}
