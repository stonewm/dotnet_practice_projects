using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPICrud.Models
{
    public class Employee
    {
        [Key]
        public int id { get; set; }
        public String name { get; set; }
        public String gender { get; set; }
        public String phonenumber { get; set; }
        public String city { get; set; }
    }
}
