using LoanCalculator.Core.DataInterface;
using LoanCalculator.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoanCalculator.Core.Services
{
    public class LoanProcessingService
    {
        private List<ILoanQualificationRule> _loanApprovalRules;
        private List<LoanRate> _loanRates;

        public LoanProcessingService(ILoanRateRepository loanRateRepository, List<ILoanQualificationRule> rules)
            : this(loanRateRepository.GetLoanRates(), rules.ToArray())
        {

        }


        public LoanProcessingService(List<LoanRate> rates, params ILoanQualificationRule[] rules)
        {
            _loanRates = rates;
            _loanApprovalRules = rules.ToList();
        }


        public LoanApplicationResult ProcessLoan(LoanApplication application)
        {
            // Check for loan qualification
            var failingRule = _loanApprovalRules.FirstOrDefault(rule => rule.CheckLoanApprovalRule(application) == false);
            if (failingRule != null)
            {
                var result = LoanApplicationResult.CreateDeniedResult(application, failingRule.RuleName);
                return result;
            }

            // Applicant qualifies for the loan, so figure out the interest rate we can offer and the monthly payment
            double interestRate = DetermineInterestRate(application);
            double monthlyPayment = CalculateLoanPayment(application.LoanAmount, application.Term.Years, interestRate);

            return LoanApplicationResult.CreateApprovedResult(application, interestRate, monthlyPayment);
        }


        private double DetermineInterestRate(LoanApplication application)
        {
            var creditScore = application.CreditScore;
            var rate = _loanRates.First(r => creditScore >= r.LowerCreditScore && creditScore <= r.UpperCreditScore);
            return rate.InterestRate;
        }


        internal double CalculateLoanPayment(double loanAmount, int termYears, double interestRate)
        {
            int totalPayments = termYears * 12;
            double monthlyInterest = interestRate / 12.0;
            double discountFactor = ((Math.Pow((1 + monthlyInterest),  totalPayments)) - 1.0) /
                (monthlyInterest * Math.Pow((1 + monthlyInterest), totalPayments));

            double monthlyPayment = Math.Round(loanAmount / discountFactor, 2);
            return monthlyPayment;
        }


    }
}
