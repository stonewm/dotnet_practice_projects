using EmployeeMgr.DAL.Dapper;
using EmployeeMgr.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest1
{
    [TestClass]
    public class DapperCrudTest
    {
        private EmployeeDao empDao;

        public DapperCrudTest()
        {
            empDao = new EmployeeDao();
        }

        [TestMethod]
        public void TestListAll()
        {
            var employees = empDao.ListAll();

            foreach (var emp in employees) {
                Console.WriteLine(String.Format("{0}, {1}", emp.EMP_ID, emp.EMAIL));
            }
        }

        [TestMethod]
        public void TestFindByName()
        {
            var employees = empDao.FindByName("Sh");
            foreach (var emp in employees) {
                Console.WriteLine($"{ emp.EMP_ID } { emp.EMAIL }");
            }
        }

        [TestMethod]
        public void TestFindById()
        {
            Employee emp = empDao.FindById(1001);
            Console.WriteLine($"{ emp.EMP_ID } { emp.EMAIL }");
        }

        [TestMethod]
        public void TestInsert()
        {
            var emp = new Employee
            {
                EMP_ID = 9002,
                GENDER = null,
                AGE = 19,
                EMAIL = "test@qq.com",
                PHONE_NR = "13800-138000",
                EDUCATION = "Bachelor",
                MARITAL_STAT = "Single",
                NR_OF_CHILDREN = 0
            };

            int rv = empDao.Insert(emp);
            Console.WriteLine(rv);
        }

        [TestMethod]
        public void TestUpdate()
        {
            var emp = new Employee
            {
                EMP_ID = 9002,
                GENDER = "Male",
                AGE = 21,
                EMAIL = "test@qq.com",
                PHONE_NR = "13800-138000",
                EDUCATION = "Bachelor",
                MARITAL_STAT = "Single",
                NR_OF_CHILDREN = 0
            };

            int rv = empDao.Update(emp);
            Assert.AreEqual(rv, 1);
        }

        [TestMethod]
        public void TestDelete()
        {
            int rv = empDao.Delete(9002);
            Assert.AreEqual(rv, 1);
        }
    }
}
