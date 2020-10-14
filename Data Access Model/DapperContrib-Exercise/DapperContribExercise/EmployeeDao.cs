using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using System.Data;

namespace DapperContribExercise {
    public class EmployeeDao {

        public IDbConnection Connection {
            get {
                var connection = ConnectionFactory.CreateConnection();
                connection.Open();
                return connection;
            }
        }

        public IEnumerable<EmployeeModel> GetAll() {
            using (IDbConnection dbConnection = this.Connection) {
                return dbConnection.GetAll<EmployeeModel>();                
            }
        }

        public EmployeeModel FindByID(int id) {
            using (IDbConnection dbConnection = Connection) {
                return dbConnection.Get<EmployeeModel>(id);               
            }
        }

        public bool Insert(EmployeeModel employee) {
            bool rv = false;
            using (IDbConnection dbConnection = Connection) {
                rv = dbConnection.Insert(employee) > 0;                         
            }

            return rv;
        }

        public bool Update(EmployeeModel employee) {
            bool rv = false;
            using (IDbConnection dbConnection = Connection) {
                rv = dbConnection.Update(employee);               
            }
            return rv;
        }

        public bool Delete(int id) {
            bool rv = false;
            using (IDbConnection dbConnection = Connection) {
                rv = dbConnection.Delete(new EmployeeModel { EMP_ID = id });            
            }
            return rv;
        }

        public bool DeleteAll() {
            bool rv = false;
            using (IDbConnection dbConnection = Connection) {
                rv = dbConnection.DeleteAll<EmployeeModel>();                
            }
            return rv;
        }
    }    
}
