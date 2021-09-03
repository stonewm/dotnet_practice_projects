using Dapper;
using EmployeeMgr.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMgr.DAL.Dapper
{
    public class EmployeeDao
    {
        private String connStr = @"Server=localhost\sqlexpress;Database=stonetest;Integrated Security=True;";

        public List<Employee> ListAll()
        {
            String sql = "select * from emp_master order by emp_id";
            using (IDbConnection db = new SqlConnection(connStr)) {                
                var emps = db.Query<Employee>(sql);
                return emps.ToList();
            }
        }

        public List<Employee> FindByName(String empName)
        {
            String sql = "select * from employees where name like @Name";
            using (IDbConnection db = new SqlConnection(connStr)) {
                var parameters = new { Name = empName + "%" };                
                return db.Query<Employee>(sql, parameters).ToList();
            }
        }

        public Employee FindById(int empId)
        {
            var sql = "select * from employees where emp_id=@EmpId";
            using (IDbConnection db = new SqlConnection(connStr)) {
                var parameters = new { EmpId = empId };                
                return db.QueryFirst<Employee>(sql, parameters);
            }
        }

        public int Insert(Employee emp)
        {
            String sql = $@"insert into emp_master
                                (EMP_ID, GENDER, AGE, EMAIL, EDUCATION, PHONE_NR, MARITAL_STAT, NR_OF_CHILDREN) 
                                values(@EMP_ID, @GENDER, @AGE, @EMAIL, @EDUCATION, 
                                @PHONE_NR, @MARITAL_STAT, @NR_OF_CHILDREN)";
            using (IDbConnection db = new SqlConnection(connStr)) { 
                return db.Execute(sql, emp);
            }
        }

        public int Update(Employee emp)
        {
            String sql = $@"update emp_master 
                                set gender=@gender, 
                                age=@age,
                                email=@email, 
                                education=@education,
                                phone_nr=@phone_nr, 
                                marital_stat=@marital_stat
                                where emp_id=@emp_id";
            using (IDbConnection db = new SqlConnection(connStr)) {                
                return db.Execute(sql, emp);
            }
        }

        public int Delete(int empId)
        {
            var sql = "delete from emp_master where emp_id=@emp_id";
            using (IDbConnection db = new SqlConnection(connStr)) {
                var parameters = new { emp_id = empId };                
                return db.Execute(sql, parameters);
            }
        }
    }
}
