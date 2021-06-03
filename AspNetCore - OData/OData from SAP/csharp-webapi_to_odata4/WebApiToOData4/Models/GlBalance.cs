using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiToOData4.Models {
    public class GlBalance {
        [Key]
        public String COMPCODE { get; set; }
        public String FSITEM { get; set; }        
        public String GLACCOUNT { get; set; }
        public String ACCTEXT { get; set; }
        [Key]
        public String FISYEAR { get; set; }
        [Key]
        public String PERIOD { get; set; }
        public double YR_OPENBAL { get; set; }
        public double OEPN_BALANCE { get; set; }
        public double DEBIT_PER { get; set; }
        public double CREDIT_PER { get; set; }
        public double PER_AMT { get; set; }
        public double BALANCE { get; set; }
        public String CURR { get; set; }
    }
}
