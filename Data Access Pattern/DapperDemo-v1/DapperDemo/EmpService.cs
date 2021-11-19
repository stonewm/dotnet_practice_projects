using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DapperDemo
{
    public class EmpService
    {
        private String connStr = @"Server=localhost\sqlexpress;Database=stonetest;Integrated Security=True;";

        public IList<Employee> ListAll() {

            using (IDbConnection db = new SqlConnection(connStr)) {
                String sql = "select * from employees order by emp_id";
                IEnumerable<Employee> emps = db.Query<Employee>(sql);

                return emps.ToList();
            }
        }

        public IList<Employee> FindByName(String empName)
        {
            using (IDbConnection db = new SqlConnection(connStr)) {
                var parameters = new { Name = empName + "%" };
                String sql = "select * from employees where name like @Name";
                return db.Query<Employee>(sql, parameters).ToList();
            }
        }

        public Employee FindById(int empId)
        {
            using (IDbConnection db = new SqlConnection(connStr)) {
                var parameters = new { EmpId = empId };
                var sql = "select * from employees where emp_id=@EmpId";
                return db.QueryFirst<Employee>(sql, parameters);
            }
        }

        public int Insert(Employee emp)
        {
            using (IDbConnection db = new SqlConnection(connStr)) {
                var sql = "insert into employees(emp_id, name, gender, email, phone_number, city) " +
                          "values(@emp_id,@name,@gender,@email,@phone_number,@city)";

                int rv = db.Execute(sql, emp);
                return rv;
            }
        }

        public int Update(Employee emp)
        {
            using (IDbConnection db = new SqlConnection(connStr)) {                
                var sql = "update employees set name=@name, gender=@gender, email=@email, phone_number=@phone_number, city=@city" +
                          " where emp_id=@emp_id";
                int rv = db.Execute(sql, emp);
                return rv;
            }
        }

        public int Delete(int empId)
        {
            using (IDbConnection db = new SqlConnection(connStr)) {
                var parameters = new { emp_id = empId};
                var sql = "delete from employees where emp_id=@emp_id";
                int rv = db.Execute(sql, parameters);
                return rv;
            }
        }
    }
}
