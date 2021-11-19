using EmployeeMgr.Domain;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMgr.DAL.SqlSugar
{
    public class EmployeeDao
    {
        private SqlSugarClient sugarClient;

        // connection string for sqlite
        private string connStr = @"Server=STONEWM-PC\SQLEXPRESS;Database=stonetest;Integrated Security=False;User ID=sa;Integrated Security=True;";

        // constructor
        public EmployeeDao()
        {
            sugarClient = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = connStr,
                DbType = DbType.SqlServer,
                IsAutoCloseConnection = true
            });
        }

        public List<Employee> ListAll()
        {
            var employees = sugarClient.Queryable<Employee>().ToList();
            return employees;
        }

        public int Insert(Employee emp)
        {           
            return sugarClient.Insertable(emp).ExecuteCommand();
        }

        public int Update(Employee emp)
        {
            return sugarClient.Updateable(emp).WhereColumns(i=>new { i.EMP_ID }).ExecuteCommand();
        }

        public int Delete(int empid)
        {
            return sugarClient.Deleteable<Employee>()
                              .Where(i=>i.EMP_ID == empid)
                              .ExecuteCommand();
        }
    }
}
