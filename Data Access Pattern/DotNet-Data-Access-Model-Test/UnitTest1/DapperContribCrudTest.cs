using EmployeeMgr.DAL.DapperContrib;
using EmployeeMgr.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest1
{
    [TestClass]
    public class DapperContribCrudTest
    {
        private EmployeeDaoDapperContrib employeeDao;

        public DapperContribCrudTest()
        {
            employeeDao = new EmployeeDaoDapperContrib();
        }

        [TestMethod]
        public void TestGetAll()
        {            
            var emps = employeeDao.GetAll();

            foreach (var emp in emps) {
                Console.WriteLine($"{emp.EMP_ID.ToString()} \t {emp.EMAIL}");
            }
        }

        [TestMethod]
        public void TestGet()
        {
            var emp = employeeDao.Get(1001);
            Console.WriteLine($"{emp.EMP_ID.ToString()} \t {emp.EMAIL}");
        }

        [TestMethod]
        public void TestInsert()
        {
            var emp = new Employee
            {
                EMP_ID = 9001,
                AGE = 18,
                GENDER = "Female",
                EMAIL = "test@qq.com",
                NR_OF_CHILDREN = 0
            };

            bool isSuccess = employeeDao.Insert(emp);
            Assert.AreEqual(true, isSuccess);
        }

        [TestMethod]
        public void TestUpdate()
        {
            var emp = new Employee
            {
                EMP_ID = 9001,
                AGE = 19,
                GENDER = "Female",
                EMAIL = "test@qq.com",
                EDUCATION = "Bachelor",
                NR_OF_CHILDREN = 0
            };

            bool isSuccess = employeeDao.Update(emp);
            Assert.AreEqual(true, isSuccess);
        }

        [TestMethod]
        public void TestDelete()
        {
            bool isSuccess = employeeDao.Delete(9001);
            Assert.AreEqual(true, isSuccess);
        }
    }
}
