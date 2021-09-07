using EmployeeMgr.DAL.Dapper;
using EmployeeMgr.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest1
{
    [TestClass]
    public class DapperCrudTest2
    {
        private EmployeeDaoDapper empDao;

        public DapperCrudTest2()
        {
            empDao = new EmployeeDaoDapper();
        }

        [TestMethod]
        public void TestListAll()
        {
            Console.WriteLine("Dapper using stored procedures");

            var employees = empDao.ListAll();

            foreach (var emp in employees) {
                Console.WriteLine($"{emp.EMP_ID} \t {emp.EMAIL}");
            }
        }

        [TestMethod]
        public void TestFindById()
        {
            Employee emp = empDao.FindById(1001);
            Console.WriteLine($"{emp.EMP_ID} \t {emp.EMAIL}");
        }
    }
}
