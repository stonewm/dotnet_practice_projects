using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace DapperSqliteExercise {
    public class DapperUtils {
        // Path.GetDirectoryName返回上一级
        private static String basePath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
        private static String dbPath = Path.Combine(basePath, "employees.db");

        private static string connStr = @"data source=" + dbPath + ";version=3;";

        private static IDbConnection _dbConnection = new SQLiteConnection(connStr);

        public static IDbConnection GetConnection() {
            return _dbConnection;
        }       
    }
}
