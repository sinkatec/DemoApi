using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DemoApi.Utils
{

    /// <summary>
    /// EntityFrameworkCoreの拡張クラス
    /// </summary>
    public static class EntityFrameworkCoreExtension
    {
        /// <summary>
        /// SELECT SQL検索の拡張メソッド
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="conn"></param>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static List<T> SqlQuery<T>(DbConnection conn, NpgsqlCommand cmd) where T : class, new()
        {
            var dt = SqlQuery(conn, cmd);
            return dt.ToList<T>();
        }

        /// <summary>
        /// SqlQuery(SQL発行)
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="cmd"></param>
        /// <returns></returns>
        private static DataTable SqlQuery(DbConnection conn, NpgsqlCommand cmd)
        {
            cmd.Connection = (NpgsqlConnection)conn;
            conn.Open();
            var reader = cmd.ExecuteReader();
            var dt = new DataTable();
            dt.Load(reader);
            reader.Close();
            conn.Close();
            return dt;
        }

        /// <summary>
        /// 結果をリストにして戻る
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        private static List<T> ToList<T>(this DataTable dt) where T : class, new()
        {
            var propertyInfos = typeof(T).GetProperties();
            var list = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                var t = new T();
                foreach (PropertyInfo p in propertyInfos)
                {
                    if (dt.Columns.IndexOf(p.Name) != -1 && row[p.Name] != DBNull.Value)
                        p.SetValue(t, row[p.Name], null);
                }
                list.Add(t);
            }
            return list;
        }
    }
}