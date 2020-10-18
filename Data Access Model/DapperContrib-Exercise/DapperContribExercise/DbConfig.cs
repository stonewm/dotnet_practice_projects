using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DapperContribExercise {
    public static class DbConfig {
        public static String DefaultDatabase = "sqlite";
        public static String ComponentDbType = "sqlite";

        // conection string for sqlite
        private static String basePath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
        private static String dbPath = Path.Combine(basePath, "employees.db");
        // private static string sqliteConnStr = @"data source=" + dbPath + ";version=3;";
        private static string sqliteConnStr = @"data source=D:\My Github Repos\dotnet_practice_projects\Data Access Model\DapperContrib-Exercise\DapperContribExercise\bin\Debug\employees.db;version=3;";

        public static String GetConnectionString(String dbType) {
            String connStr = "";

            switch (dbType.ToLower()) {
                case "sqlserer":
                    connStr = "server=localhost;database=db;uid=sa;pwd=123456;";
                    break;
                case "mysql":
                    connStr = "Server=?Database=?Uid=?Pwd=?;";
                    break;
                case "sqlite":
                    connStr = sqliteConnStr;
                    break;
                default:
                    connStr = "";
                    break;
            }

            return connStr;
        }
    }
}
