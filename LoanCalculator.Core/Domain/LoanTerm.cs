using System;
using System.Collections.Generic;
using System.Text;

namespace LoanCalculator.Core.Domain
{
    public class LoanTerm
    {

        public String Name { get; set; }

        public int Years { get; set; }

        public int TotalPayments { get => Years * 12; }

    }
}
