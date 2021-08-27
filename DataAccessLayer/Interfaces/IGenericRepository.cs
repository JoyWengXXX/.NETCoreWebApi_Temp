using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IGenericRepository<T>
    {
        public Task<T> QueryAsync(T entity, string condition, string conditionValue);
        public Task<IEnumerable<T>> QueryAllAsync(T entity, string condition, string conditionValue);
        public Task<int> CreateAsync(T entity);
        public Task<int> UpdateAsync(T entity, string condition, string conditionValue);
        public Task<int> DeleteAsync(string condition, string conditionValue);
    }
}
