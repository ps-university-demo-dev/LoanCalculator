using LoanCalculator.Core.Domain;
using System;
using System.Collections.Generic;

namespace LoanCalculator.Data.InMemory
{
    public class LoanData
    {


        public LoanData()
        {
            LoanRates = InitialLoanRatesData();
            Persons = InitialPersons();
            LoanTerms = InitialLoanTerms();
            LoanApplicationResults = InitialLoanApplicationResults(Persons, LoanTerms);
        }



        public List<LoanRate> LoanRates { get; private set; }

        public List<Person> Persons { get; private set; }

        public List<LoanTerm> LoanTerms { get; private set; }

        public List<LoanApplicationResult> LoanApplicationResults { get; private set; }


        private List<LoanRate> InitialLoanRatesData()
        {
            List<LoanRate> rates = new List<LoanRate>()
            {
                new LoanRate() { LowerCreditScore = 50, UpperCreditScore = 59, InterestRate = 8.5 },
                new LoanRate() { LowerCreditScore = 60, UpperCreditScore = 69, InterestRate = 7.5 },
                new LoanRate() { LowerCreditScore = 70, UpperCreditScore = 79, InterestRate = 6.25 },
                new LoanRate() { LowerCreditScore = 80, UpperCreditScore = 89, InterestRate = 5.25 },
                new LoanRate() { LowerCreditScore = 90, UpperCreditScore = 100, InterestRate = 4.0 }
            };
            return rates;
        }






        private List<Person> InitialPersons()
        {
            List<Person> persons = new List<Person>()
            {
                new Person() { PersonId = 1, FirstName = "Andrew", LastName = "Smith", CreditScore = 89, AnnualIncome = 100000 },
                new Person() { PersonId = 2, FirstName = "Maggie", LastName = "Cohen", CreditScore = 72, AnnualIncome = 80000 },
                new Person() { PersonId = 3, FirstName = "Bryan", LastName = "Boyd", CreditScore = 44, AnnualIncome = 55000 },
                new Person() { PersonId = 4, FirstName = "Martha", LastName = "Fletcher", CreditScore = 87, AnnualIncome = 125000 },
                new Person() { PersonId = 5, FirstName = "Stephen", LastName = "Wright", CreditScore = 65, AnnualIncome = 75000 },
                new Person() { PersonId = 6, FirstName = "Marie", LastName = "Thomas", CreditScore = 58, AnnualIncome = 80000 }
            };
            return persons;
        }


        private List<LoanTerm> InitialLoanTerms()
        {
            List<LoanTerm> terms = new List<LoanTerm>()
            {
                new LoanTerm() { Name = "10 Year", Years = 10},
                new LoanTerm() { Name = "15 Year", Years = 15},
                new LoanTerm() { Name = "25 Year", Years = 20},
                new LoanTerm() { Name = "30 Year", Years = 30}
            };

            return terms;
        }


        private List<LoanApplicationResult> InitialLoanApplicationResults(List<Person> persons, List<LoanTerm> terms)
        {
            List<LoanApplicationResult> loanApplicationResults = new List<LoanApplicationResult>()
            {
                //LoanApplicationResult.CreateApprovedResult(new LoanApplication() { Person = persons[0], Term = terms[1], LoanAmount = 200000), 4.50, 


            };

            return loanApplicationResults;
        }

    }
}
