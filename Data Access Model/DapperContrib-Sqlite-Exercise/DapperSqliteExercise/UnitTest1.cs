using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace DapperSqliteExercise {
    [TestClass]
    public class UnitTest1 {
        private EmployeeDao empDao;

        public UnitTest1() {
            empDao = new EmployeeDao();
        }

        [TestMethod]
        public void TestListAll() {
            var employees = empDao.ListAll();

            foreach (Employee emp in employees) {
                Console.WriteLine(String.Format("{0}\t{1})", emp.EMP_ID, emp.EMAIL));
            }
        }

        [TestMethod]
        public void TestFindById() {
            var emp = empDao.FindById(1001);
            Console.WriteLine(String.Format("{0}\t{1})", emp.EMP_ID, emp.EMAIL));
        }


        [TestMethod]
        public void TestInsert() {
            var emp = new Employee {
                EMP_ID = 9001,
                AGE = 18,
                GENDER = "Female",
                EMAIL = "test@qq.com",
                NR_OF_CHILDREN = 0
            };

            long emp_id = empDao.Insert(emp);
            Assert.AreEqual(9001, emp_id);
        }

        [TestMethod]
        public void TestUpdate() {
            var emp = new Employee {
                EMP_ID = 9001,
                AGE = 19,
                GENDER = "Female",
                EMAIL = "test@qq.com",
                EDUCATION = "Bachelor",
                NR_OF_CHILDREN = 0
            };

            bool isUpdated = empDao.Update(emp);
            Assert.AreEqual(true, isUpdated);
        }

        [TestMethod]
        public void TestDelete() {
            int emp_id = 9001;
            bool deleted = empDao.Delete(emp_id);
            Assert.AreEqual(true, deleted);
        }
    }
}
