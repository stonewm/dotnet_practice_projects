using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperSqliteExercise {
    public class EmployeeDao {
        private DapperUtils dapper;

        public EmployeeDao() {
            dapper = new DapperUtils();
        }

        public IList<Employee> ListAll() {
            var employees = dapper.Query<Employee>("select * from emp_master");

            return employees.ToList();
        }

        public int Insert(Employee emp) {
            String sql = @"INSERT INTO emp_master (
                               EMP_ID,
                               GENDER,
                               AGE,
                               EMAIL,
                               PHONE_NR,
                               EDUCATION,
                               MARITAL_STAT,
                               NR_OF_CHILDREN
                           )
                           VALUES (
                               @EMP_ID,
                               @GENDER,
                               @AGE,
                               @EMAIL,
                               @PHONE_NR,
                               @EDUCATION,
                               @MARITAL_STAT,
                               @NR_OF_CHILDREN
                           );";

            return dapper.Execute(sql, emp);
        }

        public int Update(Employee emp) {
            String sql = @"UPDATE emp_master
                               SET GENDER = @GENDER,
                                   AGE = @AGE,
                                   EMAIL = @EMAIL,
                                   PHONE_NR = @PHONE_NR,
                                   EDUCATION = @EDUCATION,
                                   MARITAL_STAT = @MARITAL_STAT,
                                   NR_OF_CHILDREN = @NR_OF_CHILDREN
                             WHERE EMP_ID = @EMP_ID;";

            return dapper.Execute(sql, emp);
        }

        public int Delete(int emp_id) {
            String sql = @"DELETE from emp_master WHERE EMP_ID=@EMP_ID";
            return dapper.Execute(sql, new { emp_id });
        }
    }
}
