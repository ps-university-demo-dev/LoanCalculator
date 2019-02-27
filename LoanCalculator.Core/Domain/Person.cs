using System;
using System.Collections.Generic;
using System.Text;

namespace LoanCalculator.Core.Domain
{
    public class Person
    {

        public int? PersonId { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public int AnnualIncome { get; set; }

        public int CreditScore { get; set; }


    }
}
