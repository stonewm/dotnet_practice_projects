using EmployeeMgr.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace EmployeeMgr.DAL.DapperContrib
{
    public class EmployeeDaoDapperContrib
    {
        private String connStr = @"Server=localhost\sqlexpress;Database=stonetest;Integrated Security=True;";
        private IDbConnection dbConnection;

        private IDbConnection GetConnection()
        {
            if (dbConnection == null) {
                dbConnection = new SqlConnection(connStr);               
            }

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

        // Insert() 方法成功返回 0
        public bool Insert(Employee employee)
        {
            long rv = this.GetConnection().Insert(employee);
            return rv == 0;
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
