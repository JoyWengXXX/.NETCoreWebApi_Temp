using Dapper;
using DataAccessLayer.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly string _tableName;
        private readonly string _dbConnec;

        /// <summary>
        /// Extract field names from model object
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

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="dbConnection"></param>
        public GenericRepository(string tableName, string dbConnection)
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

        /// <summary>
        /// Open new connection and return it for use
        /// </summary>
        /// <returns></returns>
        private IDbConnection CreateConnection()
        {
            var conn = SqlConnection();
            conn.Open();
            return conn;
        }

        /// <summary>
        /// Query Data
        /// </summary>
        /// <param name="condition">WHERE Condition</param>
        /// <param name="conditionValue">Condition Value</param>
        /// <returns></returns>
        public async Task<T> QueryAsync(T entity, string condition, string conditionValue)
        {
            using (var connection = CreateConnection())
            {
                StringBuilder querySQL = new StringBuilder($"SELECT ");
                List<string> properties = GenerateListOfProperties(GetProperties);
                properties.ForEach(property =>
                {
                    querySQL.Append($"{property}=@{property},");
                });
                querySQL.Remove(querySQL.Length - 1, 1).Append($" FROM {_tableName} ");
                if (condition != null)
                {
                    querySQL.Append($"WHERE {condition} = @{conditionValue}");
                }
                var result = await connection.QuerySingleOrDefaultAsync<T>(querySQL.ToString(), entity);
                if (result == null)
                    throw new KeyNotFoundException($"{_tableName} with [{condition}] = [{conditionValue}] could not be found.");

                return result;
            }
        }

        /// <summary>
        /// Query Data List
        /// </summary>
        /// <param name="condition">WHERE Condition</param>
        /// <param name="conditionValue">Condition Value</param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> QueryAllAsync(T entity, string condition, string conditionValue)
        {
            using (var connection = CreateConnection())
            {
                StringBuilder querySQL = new StringBuilder($"SELECT ");
                List<string> properties = GenerateListOfProperties(GetProperties);
                properties.ForEach(property =>
                {
                    querySQL.Append($"{property}=@{property},");
                });
                querySQL.Remove(querySQL.Length - 1, 1).Append($" FROM {_tableName} ");
                if (condition != null)
                {
                    querySQL.Append($"WHERE {condition} = @{conditionValue}");
                }
                IEnumerable<T> result = await connection.QueryAsync<T>(querySQL.ToString(), entity);
                if (result == null)
                    throw new KeyNotFoundException($"{_tableName} with [{condition}] = [{conditionValue}] could not be found.");
                return result;
            }
        }

        /// <summary>
        /// Create Data
        /// </summary>
        /// <param name="entity">Input Model</param>
        /// <returns></returns>
        public async Task<int> CreateAsync(T entity)
        {
            var insertSQL = new StringBuilder($"INSERT INTO {_tableName} ");

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

            using (var connection = CreateConnection())
            {
                return await connection.ExecuteAsync(insertSQL.ToString(), entity);
            }
        }

        /// <summary>
        /// Update Data
        /// </summary>
        /// <param name="entity">Input Model</param>
        /// <param name="condition">WHERE Condition</param>
        /// <param name="conditionValue">Condition Value</param>
        /// <returns></returns>
        public async Task<int> UpdateAsync(T entity, string condition, string conditionValue)
        {
            {
                var updateSQL = new StringBuilder($"UPDATE {_tableName} SET ");
                List<string> properties = GenerateListOfProperties(GetProperties);
                properties.ForEach(property =>
                {
                    updateSQL.Append($"{property}=@{property},");
                });

                updateSQL.Remove(updateSQL.Length - 1, 1); //remove last comma

                if (condition != null)
                {
                    updateSQL.Append($" WHERE {condition} = @{conditionValue}");
                }

                using (var connection = CreateConnection())
                {
                    return await connection.ExecuteAsync(updateSQL.ToString(), entity);
                }
            }
        }

        /// <summary>
        /// Delete Data
        /// </summary>
        /// <param name="condition">WHERE Condition</param>
        /// <param name="conditionValue">Condition Value</param>
        /// <returns></returns>
        public async Task<int> DeleteAsync(string condition, string conditionValue)
        {
            using (var connection = CreateConnection())
            {
                StringBuilder deleteSQL = new StringBuilder($"DELETE FROM {_tableName} ");
                if (condition != null)
                {
                    deleteSQL.Append($"WHERE {condition} = @{conditionValue}");
                }
                return await connection.ExecuteAsync(deleteSQL.ToString(), new { conditionValue });
            }
        }

        private IEnumerable<PropertyInfo> GetProperties => typeof(T).GetProperties();






        /// <summary>
        /// Query Data
        /// </summary>
        /// <param name="condition">WHERE Condition</param>
        /// <param name="conditionValue">Condition Value</param>
        /// <returns></returns>
        public async Task<T> QueryAsync2(T entity, string condition, string conditionValue)
        {
            using (var connection = CreateConnection())
            {
                StringBuilder querySQL = new StringBuilder($"SELECT ");
                List<string> properties = GenerateListOfProperties(GetProperties);
                properties.ForEach(property =>
                {
                    querySQL.Append($"{property}=@{property},");
                });
                querySQL.Remove(querySQL.Length - 1, 1).Append($" FROM {_tableName} ");
                if (condition != null)
                {
                    querySQL.Append($"WHERE {condition} = @{conditionValue}");
                }
                var result = await connection.QuerySingleOrDefaultAsync<T>(querySQL.ToString(), entity);
                if (result == null)
                    throw new KeyNotFoundException($"{_tableName} with [{condition}] = [{conditionValue}] could not be found.");

                return result;
            }
        }

        /// <summary>
        /// Query Data List
        /// </summary>
        /// <param name="condition">WHERE Condition</param>
        /// <param name="conditionValue">Condition Value</param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> QueryAllAsync2(T entity, string condition, string conditionValue)
        {
            using (var connection = CreateConnection())
            {
                StringBuilder querySQL = new StringBuilder($"SELECT ");
                List<string> properties = GenerateListOfProperties(GetProperties);
                properties.ForEach(property =>
                {
                    querySQL.Append($"{property}=@{property},");
                });
                querySQL.Remove(querySQL.Length - 1, 1).Append($" FROM {_tableName} ");
                if (condition != null)
                {
                    querySQL.Append($"WHERE {condition} = @{conditionValue}");
                }
                IEnumerable<T> result = await connection.QueryAsync<T>(querySQL.ToString(), entity);
                if (result == null)
                    throw new KeyNotFoundException($"{_tableName} with [{condition}] = [{conditionValue}] could not be found.");
                return result;
            }
        }
    }
}
