using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DapperDemo;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestListAll()
        {
            var empService = new EmpService();
            var employees = empService.ListAll();

            foreach (var emp in employees) {
                Console.WriteLine(String.Format("{0}, {1}", emp.Emp_Id, emp.Name));
            }
        }

        [TestMethod]
        public void TestFindByName()
        {
            var empService = new EmpService();
            var employees = empService.FindByName("Sh");

            foreach (var emp in employees) {
                Console.WriteLine(String.Format("{0}, {1}", emp.Emp_Id, emp.Name));
            }
        }

        [TestMethod]
        public void TestFindById() {
            var empService = new EmpService();
            Employee emp = empService.FindById(1);
            Console.WriteLine(String.Format("{0}, {1}", emp.Emp_Id, emp.Name));
        }

        [TestMethod]
        public void TestInsert()
        {
            Employee emp = new Employee
            {
                Emp_Id = 1001,
                Name = "Stone",
                Gender = "Male",
                Email = "stone@qq.com",
                Phone_Number = "138",
                City = "WUHAN"
            };

            var empService = new EmpService();
            int rv = empService.Insert(emp);
            Console.WriteLine(rv);
        }

        [TestMethod]
        public void TestUpdate()
        {
            Employee emp = new Employee
            {
                Emp_Id = 1001,
                Name = "Stone",
                Gender = "Male",
                Email = "stone.wang@qq.com",
                Phone_Number = "138",
                City = "WUHAN"
            };

            var empService = new EmpService();
            int rv = empService.Update(emp);
            Assert.AreEqual(rv, 1);
        }

        [TestMethod]
        public void TestDelete() {
            var empService = new EmpService();
            int rv = empService.Delete(1001);
            Assert.AreEqual(rv, 1);
        }

    }
}
