using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeutscheBank
{
    internal class Customer
    {
        public string CustomerName { get; set; }

        public long SSN { get; set; }

        public string City { get; set; }

        public double LoanAmount { get; set; }

        public int NoOfYears { get; set; }
    }
}
