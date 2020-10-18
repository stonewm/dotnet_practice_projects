using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace DapperSqliteExercise {
    public class EmployeeDao {         

        public IList<Employee> ListAll() {

            var dbConnection = DapperUtils.GetConnection();
            System.Console.WriteLine(dbConnection.ConnectionString);
            return dbConnection.GetAll<Employee>().ToList();            
        }

        public Employee FindById(int id) {
            var dbConnection = DapperUtils.GetConnection();
            return dbConnection.Get<Employee>(id);
        }

        public long Insert(Employee emp) {
            var dbConnection = DapperUtils.GetConnection();
            return dbConnection.Insert<Employee>(emp);            
        }

        public bool Update(Employee emp) {
            var dbConnection = DapperUtils.GetConnection();
            return dbConnection.Update<Employee>(emp);
        }

        public bool Delete(int emp_id) {
            var dbConnection = DapperUtils.GetConnection();
            return dbConnection.Delete(new Employee{EMP_ID = emp_id });           
        }
    }
}
