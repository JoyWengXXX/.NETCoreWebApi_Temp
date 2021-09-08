using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IGenericRepository<T>
    {
        /// <summary>
        /// 執行單一Table的單一筆資料查詢
        /// </summary>
        /// <param name="entity">實體類別</param>
        /// <param name="whereContext">WHERE條件</param>
        /// <returns></returns>
        public Task<T> QueryAsync(T entity, List<WhereContext> whereContext = null);
        /// <summary>
        /// 執行單一Table的多筆資料查詢
        /// </summary>
        /// <param name="entity">實體類別</param>
        /// <param name="whereContext">WHERE條件</param>
        /// <param name="orderByContext">ORDERBY條件</param>
        /// <returns></returns>
        public Task<IEnumerable<T>> QueryAllAsync(T entity, List<WhereContext> whereContext = null, OrderByContext orderByContext = null);
        /// <summary>
        /// 執行較複雜的資料查詢
        /// </summary>
        /// <param name="entity">實體類別</param>
        /// <param name="sqlQueryStr">要執行的SQL</param>
        /// <returns></returns>
        public Task<IEnumerable<T>> SQLCommandQueryAsync(T entity, string sqlQueryStr);
        /// <summary>
        /// 執行單一Table的資料新增
        /// </summary>
        /// <param name="entity">實體類別</param>
        /// <returns></returns>
        public Task<int> CreateAsync(T entity);
        /// <summary>
        /// 執行單一Table的資料更新
        /// </summary>
        /// <param name="entity">實體類別</param>
        /// <param name="whereContext">WHERE條件</param>
        /// <returns></returns>
        public Task<int> UpdateAsync(T entity, List<WhereContext> whereContext = null);
        /// <summary>
        /// 執行單一Table的資料刪除
        /// </summary>
        /// <param name="entity">實體類別</param>
        /// <param name="whereContext">WHERE條件</param>
        /// <returns></returns>
        public Task<int> DeleteAsync(T entity, List<WhereContext> whereContext = null);
        /// <summary>
        /// 執行較複雜的增刪改指令
        /// </summary>
        /// <param name="entity">實體類別</param>
        /// <param name="sqlExcutedStr">要執行的SQL</param>
        /// <returns></returns>
        public Task<int> SQLCommandExcuteAsync(T entity, string sqlExcutedStr);
    }
}
