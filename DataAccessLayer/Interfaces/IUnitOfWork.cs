using System;

namespace DataAccessLayer.Interfaces
{
    public interface IUnitOfWork<T> : IDisposable
    {
        IGenericRepository<T> GetGenericRepository { get; }

        void Complete();
    }
}
