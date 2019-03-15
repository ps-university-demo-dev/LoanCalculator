using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LoanCalculator.Core.Domain
{
    public class LoanApplication
    {
        [DisplayName("First Name")]
        public String FirstName { get; set; }

        [DisplayName("Last Name")]
        public String LastName { get; set; }

        [DisplayName("Annual Income")]
        public int AnnualIncome { get; set; }

        [DisplayName("Years Employed")]
        public int YearsEmployed { get; set; }

        [DisplayName("Credit Score")]
        public int CreditScore { get; set; }

        [DisplayName("Loan Amount")]
        public double LoanAmount { get; set; }

        [DisplayName("Term")]
        public LoanTerm Term { get; set; }


    }
}
