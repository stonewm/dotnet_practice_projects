using System;
using System.Collections.Generic;
using System.Linq;

namespace DapperDemo
{
    public class EmpService : DapperHelper
    {
        private DapperHelper db;

        public EmpService()
        {
            db = new DapperHelper();
        }

        public IList<Employee> ListAll()
        {
            String sql = "select * from employees order by emp_id";
            return db.Query<Employee>(sql).ToList();
        }

        public IList<Employee> FindByName(String empName)
        {
            String sql = "select * from employees where name like @Name";
            return db.Query<Employee>(sql, new { Name = empName + "%" }).ToList();
        }

        public Employee FindById(int empId)
        {
            String sql = "select * from employees where emp_id=@EmpId";
            return db.QueryFirst<Employee>(sql, new { EmpId = empId });
        }

        public int Insert(Employee emp)
        {
            String sql = "insert into employees(emp_id, name, gender, email, phone_number, city) " +
                         "values(@emp_id,@name,@gender,@email,@phone_number,@city)";
            return db.Execute(sql, emp);
        }

        public int Update(Employee emp)
        {
            var sql = "update employees set name=@name, gender=@gender, email=@email, " +
                      "phone_number=@phone_number, city=@city " +
                      "where emp_id=@emp_id";
            return db.Execute(sql, emp);
        }

        public int Delete(int empId)
        {
            var sql = "delete from employees where emp_id=@emp_id";
            return db.Execute(sql, new { emp_id = empId });
        }
    }
}
