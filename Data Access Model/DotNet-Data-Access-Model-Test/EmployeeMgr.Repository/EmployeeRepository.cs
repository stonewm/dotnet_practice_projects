using EmployeeMgr.DAL.SqlSugar;
using EmployeeMgr.Domain;
using System.Collections.Generic;

namespace EmployeeMgr.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private EmployeeDao empDao;

        public EmployeeRepository()
        {
            this.empDao = new EmployeeDao();
        }

        public int Delete(int id)
        {
            return empDao.Delete(id);
        }

        public int Insert(Employee employee)
        {
            return empDao.Insert(employee);
        }

        public List<Employee> ListAll()
        {
            return empDao.ListAll();
        }

        public int Update(Employee employee)
        {
            return empDao.Update(employee);
        }
    }
}
