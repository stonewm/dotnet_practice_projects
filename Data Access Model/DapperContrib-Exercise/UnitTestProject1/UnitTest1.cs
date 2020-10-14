using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DapperContribExercise;

namespace UnitTestProject1 {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void TestGetAll() {
            var empDao = new EmployeeDao();
            var emps = empDao.GetAll();

            foreach(var emp in emps) {
                Console.WriteLine(emp.EMP_ID.ToString() +"\t" +  emp.EMAIL);
            }
        }

        [TestMethod]
        public void TestFindById() {
            var empDao = new EmployeeDao();
            var emp = empDao.FindByID(1001);            
            Console.WriteLine(String.Format("{0}\t{1})", emp.EMP_ID, emp.EMAIL));
        }

        [TestMethod]
        public void TestInsert() {
            var emp = new EmployeeModel {
                EMP_ID = 9001,
                AGE = 18,
                GENDER = "Female",
                EMAIL = "test@qq.com",
                NR_OF_CHILDREN = 0
            };

            var empDao = new EmployeeDao();
            bool isSuccess = empDao.Insert(emp);
            Assert.AreEqual(true, isSuccess);
        }

        [TestMethod]
        public void TestUpdate() {
            var emp = new EmployeeModel {
                EMP_ID = 9001,
                AGE = 19,
                GENDER = "Female",
                EMAIL = "test@qq.com",
                EDUCATION = "Bachelor",
                NR_OF_CHILDREN = 0
            };

            var empDao = new EmployeeDao();
            bool isUpdated = empDao.Update(emp);
            Assert.AreEqual(true, isUpdated);
        }

        [TestMethod]
        public void TestDelete() {
            int emp_id = 9001;
            var empDao = new EmployeeDao();
            bool deleted = empDao.Delete(emp_id);
            Assert.AreEqual(true, deleted);
        }
    }
}
