using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Data;

namespace DapperContribExercise {
    /// <summary>
    /// 数据库访问基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DaoBase<T> where T : class {

        public DaoBase() { }

        protected IDbConnection Connection {
            get {
                var connection = ConnectionFactory.CreateConnection();
                connection.Open();
                return connection;
            }
        }

        /// <summary>
        /// 返回数据表所有记录
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetAll() {
            using (IDbConnection dbConnection = Connection) {
                return dbConnection.GetAll<T>();
            }
        }
        
        public T FindByID(object id) {
            using (IDbConnection dbConnection = Connection) {
                return dbConnection.Get<T>(id);
            }
        }

       
        public bool Insert(T entity) {
            bool result = false;
            using (IDbConnection dbConnection = Connection) {
                dbConnection.Insert(entity);
                result = true;
            }
            return result;
        }
        
        public bool Insert(IEnumerable<T> list) {
            bool result = false;
            using (IDbConnection dbConnection = Connection) {
                result = dbConnection.Insert(list) > 0;
            }
            return result;
        }
       
        public bool Update(T entity) {
            bool result = false;
            using (IDbConnection dbConnection = Connection) {
                result = dbConnection.Update(entity);
            }
            return result;
        }
       
        public bool Update(IEnumerable<T> list) {
            bool result = false;
            using (IDbConnection dbConnection = Connection) {
                result = dbConnection.Update(list);
            }
            return result;
        }
        
        public bool Delete(T entity) {
            bool result = false;
            using (IDbConnection dbConnection = Connection) {
                result = dbConnection.Delete(entity);
            }
            return result;
        }
       
        public bool Delete(IEnumerable<T> list) {
            bool result = false;
            using (IDbConnection dbConnection = Connection) {
                result = dbConnection.Delete(list);
            }
            return result;
        }
        
        public bool DeleteAll() {
            bool result = false;
            using (IDbConnection dbConnection = Connection) {
                result = dbConnection.DeleteAll<T>();
            }
            return result;
        }
    }
}
