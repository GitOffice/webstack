using System.Collections.Generic;
using System.Linq;
using TableDescriptor;
using tuxedo.Extensions;

namespace tuxedo
{
    partial class Tuxedo
    {
        public const string SetSuffix = "_set";
        
        public static Query Update<T>(T entity)
        {
            var descriptor = GetDescriptor<T>();
            var setClause = DynamicToHash(entity);
            foreach(var id in descriptor.Keys)
            {
                setClause.Remove(id.ColumnName);
            }
            
            string sql;
            var parameters = UpdateSetClause(setClause, descriptor, out sql);
            
            var keys = descriptor.Keys.ToDictionary(id => id.ColumnName, id => id.Property.Get(entity));
            var whereClause = WhereClauseByExample(descriptor, keys);
            
            sql = string.Concat(sql, " WHERE ", whereClause.Sql);
            return new Query(sql, parameters.AddRange(whereClause.Parameters));
        }

        public static Query Update<T>(dynamic set, dynamic @where = null)
        {
            var descriptor = GetDescriptor<T>();
            var setClause = (IDictionary<string, object>)DynamicToHash(set);

            string sql;
            var parameters = UpdateSetClause(setClause, descriptor, out sql);

            if (@where == null)
            {
                return new Query(sql, parameters);
            }

            Query whereClause = WhereClauseByExample(descriptor, @where);
            sql = string.Concat(sql, " WHERE ", whereClause.Sql);
            return new Query(sql, parameters.AddRange(whereClause.Parameters));
        }

        private static IDictionary<string, object> UpdateSetClause(IDictionary<string, object> setClause, Descriptor descriptor, out string sql)
        {
            var parameters = ParametersFromHash(setClause, suffix: SetSuffix);
            var setColumns = ColumnsFromHash(descriptor, setClause);
            sql = string.Concat("UPDATE ", TableName(descriptor), " SET ", ColumnParameterClauses(setColumns, SetSuffix).Concat());
            return parameters;
        }
    }
}
