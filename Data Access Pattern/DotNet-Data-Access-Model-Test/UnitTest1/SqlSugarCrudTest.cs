using EmployeeMgr.DAL.SqlSugar;
using EmployeeMgr.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTest1
{
    [TestClass]
    public class SqlSugarCrudTest
    {
        private EmployeeDao empDao;

        public SqlSugarCrudTest()
        {
            empDao = new EmployeeDao();
        }

        [TestMethod]
        public void TestListAll()
        {
            List<Employee> empList = empDao.ListAll();

            foreach (var emp in empList) {
                String item = String.Format("{0},{1}", emp.EMP_ID, emp.EMAIL);
                Console.WriteLine(item);
            }
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

            int count = empDao.Insert(emp);
            Console.WriteLine(count);
        }

        [TestMethod]
        public void TestUpdate()
        {
            var emp = new Employee
            {
                EMP_ID = 9002,
                GENDER = null,
                AGE = 19,
                EMAIL = "test@qq.com",
                PHONE_NR = "13800-138000",
                EDUCATION = "Bachelor",
                MARITAL_STAT = "单身",
                NR_OF_CHILDREN = 0
            };

            int count = empDao.Update(emp);
            Console.WriteLine(count);
        }

        [TestMethod]
        public void TestDelete()
        {
            int count = empDao.Delete(9002);
            Console.WriteLine(count);
        }
    }
}
