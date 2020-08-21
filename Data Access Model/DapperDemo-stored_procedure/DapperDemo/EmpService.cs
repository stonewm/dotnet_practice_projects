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
            return db.QueryStoredProc<Employee>("sp_list_all_employees").ToList();
        }

        public IList<Employee> FindByName(String empName)
        {
            return db.QueryStoredProc<Employee>(
                "sp_find_employee_by_name",
                new { name = empName }
            ).ToList();           
        }

        public Employee FindById(int empId)
        {
            return db.QueryFirstStoredProc<Employee>(
                "sp_find_employee_by_id", 
                new { emp_id = empId }
            );            
        }

        public int Insert(Employee emp)
        {
            return db.ExecuteStoredProc("sp_create_employee", emp);
        }

        public int Update(Employee emp)
        {
            return db.ExecuteStoredProc("sp_update_employee", emp);
        }

        public int Delete(int empId)
        {
            return db.ExecuteStoredProc("sp_delete_employee", new { emp_id = empId });
        }
    }
}
