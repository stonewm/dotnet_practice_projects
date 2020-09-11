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
        public void TestInsert() {
            var emp = new Employee {
                EMP_ID = 9001,
                AGE = 18,
                GENDER = "Female",
                EMAIL = "test@qq.com",
                NR_OF_CHILDREN = 0
            };

            int count = empDao.Insert(emp);
            Assert.AreEqual(1, count);
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

            int count = empDao.Update(emp);
            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void TestDelete() {
            int emp_id = 9001;
            int count = empDao.Delete(emp_id);
            Assert.AreEqual(1, count);
        }
    }
}
