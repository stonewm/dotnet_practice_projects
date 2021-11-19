using EmployeeMgr.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMgr.Repository
{
    public interface IEmployeeRepository
    {
        List<Employee> ListAll();
        int Insert(Employee employee);
        int Update(Employee employee);
        int Delete(int id);
    }
}
