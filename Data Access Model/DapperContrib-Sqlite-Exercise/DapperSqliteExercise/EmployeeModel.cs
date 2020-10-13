﻿using Dapper.Contrib.Extensions;
using System;

namespace DapperSqliteExercise {
    [Table("emp_master")]
    public class Employee {
        [ExplicitKey]
        public int EMP_ID { get; set; }

        public String GENDER { get; set; }
        public int? AGE { get; set; }
        public String EMAIL { get; set; }
        public String PHONE_NR { get; set; }
        public String EDUCATION { get; set; }
        public String MARITAL_STAT { get; set; }
        public int? NR_OF_CHILDREN { get; set; }
    }
}
