using EmployeeMgr.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using System.IO;
using System.Data.SQLite;

namespace EmployeeMgr.DAL.DapperContrib
{
    public class EmployeeDaoDapperContrib
    {
        private String connStr = @"Server=localhost\sqlexpress;Database=stonetest;Integrated Security=True;";

        //---------------------------------
        // Connection string for sqlite
        //---------------------------------

        // Path.GetDirectoryName返回上一级
        private static String basePath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
        private static String dbPath = Path.Combine(basePath, "employees.db");
        private static string connStrSqlite = $@"data source= {dbPath}; version=3;";

        private IDbConnection dbConnection;

        private IDbConnection GetConnection()
        {
            if (dbConnection == null) {
                //dbConnection = new SqlConnection(connStr);
                dbConnection = new SQLiteConnection(connStrSqlite);
            }
            System.Console.WriteLine(dbConnection.ConnectionString);
            return dbConnection;
        }

        public IEnumerable<Employee> GetAll()
        {
            return this.GetConnection().GetAll<Employee>();
        }

        public Employee Get(int id)
        {
            return this.GetConnection().Get<Employee>(id);            
        }

        public bool Insert(Employee employee)
        {
            long rv = this.GetConnection().Insert(employee) ; // sqlite返回id号
            return rv != 0; 
        }

        // 返回值为bool
        public bool Update(Employee employee)
        {
            return this.GetConnection().Update(employee);            
        }

        // 返回值为bool
        public bool Delete(int id)
        {
            return this.GetConnection().Delete(new Employee { EMP_ID = id });            
        }

        // 返回值为bool
        public bool DeleteAll()
        {
            return this.GetConnection().DeleteAll<Employee>();            
        }
    }
}
