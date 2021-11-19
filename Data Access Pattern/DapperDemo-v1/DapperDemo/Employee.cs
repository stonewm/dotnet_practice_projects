using System;
using System.ComponentModel;

namespace DapperDemo
{
    public class Employee : IEditableObject
    {
        private Employee backupData;

        public int Emp_Id { get; set; }
        public String Name { get; set; }
        public String Gender { get; set; }
        public String Email { get; set; }
        public String Phone_Number { get; set; }
        public String City { get; set; }

        public void BeginEdit()
        {
            backupData = this.MemberwiseClone() as Employee;
        }

        public void CancelEdit()
        {
            this.Emp_Id = backupData.Emp_Id;
            this.Name = backupData.Name;
            this.Gender = backupData.Gender;
            this.Email = backupData.Email;
            this.Phone_Number = backupData.Phone_Number;
            this.City = backupData.City;
        }

        public void EndEdit()
        {
            backupData.Emp_Id = this.Emp_Id;
            backupData.Name = this.Name;
            backupData.Gender = this.Gender;
            backupData.Email = this.Email;
            backupData.Phone_Number = this.Phone_Number;
            backupData.City = this.City;
        }
    }
}
