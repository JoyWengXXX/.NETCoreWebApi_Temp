using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IUnitOfWork<T> : IDisposable
    {
        IGenericRepository<T> GetGenericRepository { get; }

        void Complete();
    }
}
