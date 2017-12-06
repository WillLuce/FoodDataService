using System.Data;
using Npgsql;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System;
using Dapper;

namespace FoodDataService.Data
{
    public static class Db
    {
        public static IDbConnection FoodDataService()
        {
            var connectionString = Startup.Configuration.GetValue<string>("DBInfo:ConnectionString");
            return new NpgsqlConnection(connectionString);
        }

        public static int Execute(this IDbTransaction tx, string sql, object param)
        {
            int result;

            if (tx == null)
            {
                using (var db = FoodDataService())
                {
                    result = db.Execute(sql, param);
                }
            }
            else
            {
                result = tx.Connection.Execute(sql, param, tx);
            }

            return result;
        }

        public static IEnumerable<T> Query<T>(this IDbTransaction tx, string sql, object param)
        {
            IEnumerable<T> result;

            if (tx == null)
            {
                using (var db = FoodDataService())
                {
                    result = db.Query<T>(sql, param);
                }
            }
            else
            {
                result = tx.Connection.Query<T>(sql, param, tx);
            }

            return result;
        }

        public static bool EnsureProductConnectivity(this IDbConnection connection)
        {
            return connection.EnsureDbConnectivity("SELECT TOP(1) ndb_no FROM food_des");
        }

        private static bool EnsureDbConnectivity(this IDbConnection connection, string query)
        {
            try
            {
                connection.Query(query);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static IEnumerable<TParent> QueryParentChild<TParent, TChild, TParentKey>(this IDbConnection conn, string sql,
            Func<TParent, TParentKey> parentKeySelector, Func<TParent, IList<TChild>> childSelector, dynamic param = null,
            IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null,
            CommandType? commandType = null)
        {
            Dictionary<TParentKey, TParent> cache = new Dictionary<TParentKey, TParent>();

            conn.Query<TParent, TChild, TParent>(sql, (parent, child) =>
            {
                if (!cache.ContainsKey(parentKeySelector(parent)))
                {
                    cache.Add(parentKeySelector(parent), parent);
                }

                TParent cachedParent = cache[parentKeySelector(parent)];
                IList<TChild> children = childSelector(cachedParent);
                if (child != null)
                {
                    children.Add(child);
                }
                return cachedParent;
            }, param as object, transaction, buffered, splitOn, commandTimeout, commandType);

            return cache.Values;
        }
    }
}
