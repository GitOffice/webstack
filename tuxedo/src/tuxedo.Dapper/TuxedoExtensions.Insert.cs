using System.Data;
using Dapper;

namespace tuxedo.Dapper
{
    partial class TuxedoExtensions
    {
        public static T Insert<T>(this IDbConnection connection, T entity, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
        {
            var descriptor = Tuxedo.GetDescriptor<T>();
            var insert = Tuxedo.Insert(entity);
            var sql = insert.Sql;
            if(descriptor.Identity != null)
            {
                sql = string.Concat(sql, "; ", Tuxedo.Identity());
            }
            var result = connection.Execute(sql, Prepare(insert.Parameters), transaction, commandTimeout);
            MapBackId(descriptor, entity, result);
            return entity;
        }
    }
}
