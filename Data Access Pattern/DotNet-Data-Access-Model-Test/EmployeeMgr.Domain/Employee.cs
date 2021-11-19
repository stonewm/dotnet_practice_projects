using Dapper.Contrib.Extensions;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EmployeeMgr.Domain
{
    [SugarTable("emp_master")]
    [Table("emp_master")]
    public class Employee
    {
        [ExplicitKey]
        public int EMP_ID { get; set; }
        public String GENDER { get; set; }
        public int AGE { get; set; }
        public String EMAIL { get; set; }
        public String PHONE_NR { get; set; }
        public String EDUCATION { get; set; }
        public String MARITAL_STAT { get; set; }
        public int NR_OF_CHILDREN { get; set; }

        public Employee ShallowCopy()
        {
            return (Employee)this.MemberwiseClone();
        }
    }
}
