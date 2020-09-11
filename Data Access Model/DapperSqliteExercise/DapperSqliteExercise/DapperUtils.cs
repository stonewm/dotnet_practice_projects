using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DapperSqliteExercise {
    public class DapperUtils {
        private static String basePath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
        private static String dbPath = Path.Combine(basePath, "employees.db");
        private static string connStr = @"data source=" + dbPath + ";version=3;";

        private static IDbConnection dbConnection = new SQLiteConnection(connStr);

        public IEnumerable<T> Query<T>(String sql, object pms = null) {
            return dbConnection.Query<T>(sql, pms);
        }

        public T QueryFirst<T>(String sql, object pms = null) {
            return dbConnection.QueryFirst<T>(sql, pms);
        }

        public int Execute(String sql, object pms = null) {
            return dbConnection.Execute(sql, pms);
        }
    }
}
