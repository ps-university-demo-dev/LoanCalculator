using System;
using System.Collections.Generic;
using System.Text;

namespace LoanCalculator.Core.Domain
{
    public class LoanApplicationResult
    {

        public int ResultId { get; set; }

        public LoanApplication LoanApplication { get; private set; }

        public Boolean Approved { get; private set; }

        public String DenialReason { get; private set; }

        public double? InterestRate { get; private set; }

        public double? MonthlyPayment { get; private set; }



        public static LoanApplicationResult CreateDeniedResult(LoanApplication application, String denialReason)
        {
            return new LoanApplicationResult()
            {
                LoanApplication = application,
                Approved = false,
                DenialReason = denialReason
            };
        }


        public static LoanApplicationResult CreateApprovedResult(LoanApplication application, double interestRate, double monthlyPayment)
        {
            return new LoanApplicationResult()
            {
                LoanApplication = application,
                Approved = true,
                InterestRate = interestRate,
                MonthlyPayment = monthlyPayment
            };
        }


    }
}
