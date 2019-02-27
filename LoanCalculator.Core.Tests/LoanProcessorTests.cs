using LoanCalculator.Core.Domain;
using LoanCalculator.Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LoanCalculator.Core.Tests
{
    [TestClass]
    public class LoanProcessingServiceTests
    {

        #region Test Data

        public readonly List<LoanRate> Rates = new List<LoanRate>()
            {
                new LoanRate() { LowerCreditScore = 50, UpperCreditScore = 59, InterestRate = 0.085 },
                new LoanRate() { LowerCreditScore = 60, UpperCreditScore = 69, InterestRate = 0.075 },
                new LoanRate() { LowerCreditScore = 70, UpperCreditScore = 79, InterestRate = 0.0625 },
                new LoanRate() { LowerCreditScore = 80, UpperCreditScore = 89, InterestRate = 0.0525 },
                new LoanRate() { LowerCreditScore = 90, UpperCreditScore = 100, InterestRate = 0.040 }
            };






        #endregion




        [TestMethod]
        public void TestLoanDeniedForLowCreditScore()
        {
            var loanApprovalRules = new List<ILoanQualificationRule>()
            {
                new CreditScoreLoanApprovalRule(),
                new LoanSizeLoanApprovalRule()
            };

            LoanProcessingService service = new LoanProcessingService(loanApprovalRules, Rates);

            var person = new Person() { PersonId = 1, FirstName = "John", LastName = "Doe", CreditScore = 47, AnnualIncome = 50_000 };
            var application = new LoanApplication() { Person = person, LoanAmount = 250_000, Term = new LoanTerm() { Name = "30 Year", Years = 30 } };

            var result = service.ProcessLoan(application);

            Assert.IsFalse(result.Approved);
        }

        [TestMethod]
        public void TestLoanApprovedForHighCreditScore()
        {
            var loanApprovalRules = new List<ILoanQualificationRule>()
            {
                new CreditScoreLoanApprovalRule(),
                new LoanSizeLoanApprovalRule()
            };

            LoanProcessingService service = new LoanProcessingService(loanApprovalRules, Rates);

            var person = new Person() { PersonId = 1, FirstName = "John", LastName = "Doe", CreditScore = 77, AnnualIncome = 50_000 };
            var application = new LoanApplication() { Person = person, LoanAmount = 250_000, Term = new LoanTerm() { Name = "30 Year", Years = 30 } };

            var result = service.ProcessLoan(application);

            Assert.IsTrue(result.Approved);
        }


        [TestMethod]
        public void TestLoanHasCorrectInterestRate()
        {
            var loanApprovalRules = new List<ILoanQualificationRule>()
            {
                new CreditScoreLoanApprovalRule(),
                new LoanSizeLoanApprovalRule()
            };

            LoanProcessingService service = new LoanProcessingService(loanApprovalRules, Rates);

            var person = new Person() { PersonId = 1, FirstName = "John", LastName = "Doe", CreditScore = 77, AnnualIncome = 50_000 };
            var application = new LoanApplication() { Person = person, LoanAmount = 250_000, Term = new LoanTerm() { Name = "30 Year", Years = 30 } };

            var result = service.ProcessLoan(application);

            Assert.AreEqual(0.0625, result.InterestRate.Value);
        }


        [TestMethod]
        public void TestLoanHasCorrectPaymentCalculated()
        {
            var loanApprovalRules = new List<ILoanQualificationRule>()
            {
                new CreditScoreLoanApprovalRule(),
                new LoanSizeLoanApprovalRule()
            };

            LoanProcessingService service = new LoanProcessingService(loanApprovalRules, Rates);

            var person = new Person() { PersonId = 1, FirstName = "John", LastName = "Doe", CreditScore = 77, AnnualIncome = 50_000 };
            var application = new LoanApplication() { Person = person, LoanAmount = 250_000, Term = new LoanTerm() { Name = "30 Year", Years = 30 } };

            var result = service.ProcessLoan(application);

            Assert.AreEqual(1539.29, Math.Round(result.MonthlyPayment.Value, 2));
        }


    }
}
