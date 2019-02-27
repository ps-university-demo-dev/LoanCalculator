using System;
using System.Collections.Generic;
using System.Text;

namespace LoanCalculator.Core.Domain
{
    public class LoanApplication
    {

        public Person Person { get; set; }

        public double LoanAmount { get; set; }

        public LoanTerm Term { get; set; }


    }
}
