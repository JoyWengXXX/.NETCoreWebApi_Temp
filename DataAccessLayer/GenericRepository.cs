using Dapper;
using DataAccessLayer.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using DataAccessLayer.Interfaces.Enum;

namespace DataAccessLayer
{
    class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private IDbConnection _connection;
        private IDbTransaction _dbTransaction;
        private string _tableName;

        public GenericRepository(IDbConnection connection, IDbTransaction dbTransaction)
        {
            _dbTransaction = dbTransaction;
            _connection = connection;

            TableAttribute tAttribute = (TableAttribute)typeof(T).GetCustomAttributes(typeof(TableAttribute), true)[0];
            _tableName = tAttribute.Name;
        }

        /// <summary>
        /// 取出對應類別中的屬性欄位
        /// </summary>
        /// <param name="listOfProperties"></param>
        /// <returns></returns>
        private static List<string> GenerateListOfProperties(IEnumerable<PropertyInfo> listOfProperties)
        {
            return (from prop in listOfProperties
                    let attributes = prop.GetCustomAttributes(typeof(DescriptionAttribute), false)
                    where attributes.Length <= 0 || (attributes[0] as DescriptionAttribute)?.Description != "ignore"
                    select prop.Name).ToList();
        }

        private IEnumerable<PropertyInfo> GetProperties => typeof(T).GetProperties();

        public async Task<T> QueryAsync(T entity, List<WhereContext> whereContext)
        {
            StringBuilder querySQL = new StringBuilder($"SELECT ");
            List<string> properties = GenerateListOfProperties(GetProperties);
            properties.ForEach(property =>
            {
                querySQL.Append($"{property},");
            });
            querySQL.Remove(querySQL.Length - 1, 1).Append($" FROM {_tableName} ");
            querySQL = BuildConditionStr(querySQL, whereContext);
            try
            {
                var result = await _connection.QuerySingleOrDefaultAsync<T>(querySQL.ToString(), entity, _dbTransaction);
                if (result == null)
                    throw new KeyNotFoundException($"Can't find any result after executing SQL [{querySQL.ToString()}]");
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> QueryAllAsync(T entity, List<WhereContext> whereContext, OrderByContext orderByContext)
        {
            StringBuilder querySQL = new StringBuilder($"SELECT ");
            List<string> properties = GenerateListOfProperties(GetProperties);
            properties.ForEach(property =>
            {
                querySQL.Append($"{property},");
            });
            querySQL.Remove(querySQL.Length - 1, 1).Append($" FROM {_tableName} ");
            querySQL = BuildConditionStr(querySQL, whereContext, orderByContext);
            try
            {
                IEnumerable<T> result = await _connection.QueryAsync<T>(querySQL.ToString(), entity, _dbTransaction);
                if (result == null)
                    throw new KeyNotFoundException($"Can't find any result after executing SQL [{querySQL.ToString()}]");
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> CreateAsync(T entity)
        {
            StringBuilder insertSQL = new StringBuilder($"INSERT INTO {_tableName} ");

            insertSQL.Append("(");

            List<string> properties = GenerateListOfProperties(GetProperties);
            properties.ForEach(prop =>
            {
                insertSQL.Append($"[{prop}],");
            });

            insertSQL
                .Remove(insertSQL.Length - 1, 1)
                .Append(") VALUES (");

            properties.ForEach(prop => { insertSQL.Append($"@{prop},"); });

            insertSQL
                .Remove(insertSQL.Length - 1, 1)
                .Append(")");

            try
            {
                int result = await _connection.ExecuteAsync(insertSQL.ToString(), entity, _dbTransaction);
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> UpdateAsync(T entity, List<WhereContext> whereContext)
        {
            StringBuilder updateSQL = new StringBuilder($"UPDATE {_tableName} SET ");
            List<string> properties = GenerateListOfProperties(GetProperties);
            properties.ForEach(property =>
            {
                updateSQL.Append($"{property}=@{property},");
            });
            updateSQL.Remove(updateSQL.Length - 1, 1); //remove last comma
            updateSQL = BuildConditionStr(updateSQL, whereContext);
            try
            {
                int result = await _connection.ExecuteAsync(updateSQL.ToString(), entity, _dbTransaction);
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> DeleteAsync(T entity, List<WhereContext> whereContext)
        {
            StringBuilder deleteSQL = new StringBuilder($"DELETE FROM {_tableName} ");
            deleteSQL = BuildConditionStr(deleteSQL, whereContext);
            try
            {
                return await _connection.ExecuteAsync(deleteSQL.ToString(), entity, _dbTransaction);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> SQLCommandQueryAsync(T entity, string sqlQueryStr)
        {
            string querySQL = sqlQueryStr;
            try
            {
                IEnumerable<T> result = await _connection.QueryAsync<T>(querySQL, entity, _dbTransaction);
                if (result == null)
                    throw new KeyNotFoundException($"Can't find any result after executing SQL [{querySQL}]");

                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> SQLCommandExcuteAsync(T entity, string sqlExcutedStr)
        {
            string excutedSQL = sqlExcutedStr;
            try
            {
                return await _connection.ExecuteAsync(excutedSQL, entity, _dbTransaction);
            }
            catch
            {
                throw;
            }
        }

        private StringBuilder BuildConditionStr(StringBuilder sqlCommand, List<WhereContext> whereContext = null, OrderByContext orderByContext = null)
        {
            if(whereContext != null)
            {
                foreach (WhereContext whereCondition in whereContext)
                {
                    if (whereCondition == whereContext[0])
                    {
                        if(whereCondition.equetion == SQLContextEnum.WhereEnum.NotEqual)
                        {
                            sqlCommand.Append($"WHERE {whereCondition.tableColumn} <> @{whereCondition.tableColumn} ");
                        }
                        else
                        {
                            sqlCommand.Append($"WHERE {whereCondition.tableColumn} = @{whereCondition.tableColumn} ");
                        }
                    }
                    else
                    {
                        if (whereCondition.equetion == SQLContextEnum.WhereEnum.NotEqual)
                        {
                            sqlCommand.Append($"AND {whereCondition.tableColumn} <> @{whereCondition.tableColumn} ");
                        }
                        else
                        {
                            sqlCommand.Append($"AND {whereCondition.tableColumn} = @{whereCondition.tableColumn} ");
                        }
                    }
                }
            }

            if(orderByContext != null)
            {
                if(orderByContext.orderType == SQLContextEnum.OrderByEnum.DESC)
                {
                    sqlCommand.Append($"ORDER BY {orderByContext.tableColumn} DESC ");
                }
                else
                {
                    sqlCommand.Append($"ORDER BY {orderByContext.tableColumn} ");
                }
            }

            return sqlCommand;
        }
    }
}
