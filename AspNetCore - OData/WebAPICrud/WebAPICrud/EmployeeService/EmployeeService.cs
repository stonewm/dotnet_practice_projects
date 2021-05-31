using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICrud.Models;

namespace WebAPICrud.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        public EmployeeContext dbContext;

        public EmployeeService(EmployeeContext context)
        {
            dbContext = context;
        }

        public Employee AddEmployee(Employee employee)
        {
            dbContext.Employees.Add(employee);
            dbContext.SaveChanges();

            return employee;
        }

        public void DeleteEmployee(int Id)
        {
            var employee = dbContext.Employees.FirstOrDefault(e => e.id == Id);
            if (employee != null) {
                dbContext.Remove(employee);
                dbContext.SaveChanges();
            }
        }

        public Employee GetEmployee(int Id)
        {
            return dbContext.Employees.FirstOrDefault(e => e.id == Id);
        }

        public List<Employee> GetEmployees()
        {
            return dbContext.Employees.ToList();
        }

        public void UpdateEmployee(Employee employee)
        {
            dbContext.Employees.Update(employee);
            dbContext.SaveChanges();
        }
    }
}
