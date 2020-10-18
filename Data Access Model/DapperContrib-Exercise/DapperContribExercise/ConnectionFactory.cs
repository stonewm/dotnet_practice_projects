using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper.Contrib.Extensions;
using System.Data.SQLite;


namespace DapperContribExercise {
    public class ConnectionFactory {
        /// <summary>
        /// 转换数据库类型
        /// </summary>
        /// <param name="databaseType">数据库类型</param>
        /// <returns></returns>
        private static DatabaseType GetDataBaseType(string databaseType) {
            DatabaseType returnValue = DatabaseType.SqlServer;
            foreach (DatabaseType dbType in Enum.GetValues(typeof(DatabaseType))) {
                if (dbType.ToString().Equals(databaseType, StringComparison.OrdinalIgnoreCase)) {
                    returnValue = dbType;
                    break;
                }
            }
            return returnValue;
        }

        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <returns></returns>
        public static IDbConnection CreateConnection() {
            IDbConnection connection = null;

            //获取配置进行转换
            var type = DbConfig.ComponentDbType;
            var dbType = GetDataBaseType(type);

            //DefaultDatabase 根据这个配置项获取对应连接字符串
            var database = DbConfig.DefaultDatabase;            
            if (string.IsNullOrEmpty(database)) {
                database = "sqlserver"; // 默认配置
            }

            var strConn = DbConfig.GetConnectionString(database);


            switch (dbType) {
                case DatabaseType.SqlServer:
                    connection = new System.Data.SqlClient.SqlConnection(strConn);
                    break;
                case DatabaseType.MySql:
                    // todo
                    break;               
                case DatabaseType.Sqlite:
                    connection = new SQLiteConnection(strConn);
                    break; 
            }

            return connection;
        }
    }
}
