using System;
using System.Collections.Generic;
using System.Text;

namespace LoanCalculator.Core.Domain
{
    public class LoanApplicationResult
    {

        public int ResultId { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public int AnnualIncome { get; set; }

        public int CreditScore { get; set; }

        public double LoanAmount { get; set; }

        public int LoanTerm { get; set; }

        public Boolean Approved { get; private set; }

        public String DenialReason { get; private set; }

        public double? InterestRate { get; private set; }

        public double? MonthlyPayment { get; private set; }



        public static LoanApplicationResult CreateDeniedResult(LoanApplication application, String denialReason)
        {
            return new LoanApplicationResult()
            {
                FirstName = application.Person.FirstName,
                LastName = application.Person.LastName,
                AnnualIncome = application.Person.AnnualIncome,
                CreditScore = application.Person.CreditScore,
                LoanAmount = application.LoanAmount,
                LoanTerm = application.Term.Years,
                Approved = false,
                DenialReason = denialReason
            };
        }


        public static LoanApplicationResult CreateApprovedResult(LoanApplication application, double interestRate, double monthlyPayment)
        {
            return new LoanApplicationResult()
            {
                FirstName = application.Person.FirstName,
                LastName = application.Person.LastName,
                AnnualIncome = application.Person.AnnualIncome,
                CreditScore = application.Person.CreditScore,
                LoanAmount = application.LoanAmount,
                LoanTerm = application.Term.Years,
                Approved = true,
                InterestRate = interestRate,
                MonthlyPayment = monthlyPayment
            };
        }


    }
}
