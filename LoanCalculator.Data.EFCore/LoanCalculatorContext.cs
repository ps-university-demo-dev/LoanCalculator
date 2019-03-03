using LoanCalculator.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanCalculator.Data.EFCore
{
    public class LoanCalculatorContext : DbContext
    {

        public LoanCalculatorContext(DbContextOptions options) : base(options)
        {

        }


        public DbSet<LoanRate> LoanRates { get; set; }

        public DbSet<LoanApplicationResult> LoanApplicationResults { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //this.ConfigureLoanTerm(modelBuilder);
            this.ConfigureLoanRate(modelBuilder);
            this.ConfigureLoanApplicationResult(modelBuilder);
            this.SeedData(modelBuilder);
        }

        private void ConfigureLoanRate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoanRate>()
                .ToTable("LoanRates")
                .HasKey(lt => lt.LoanRateId);
        }



        private void ConfigureLoanApplicationResult(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoanApplicationResult>()
                .ToTable("LoanApplicationResults")
                .HasKey(r => r.ResultId);
        }


        private void SeedData(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<LoanRate>().HasData(
                new LoanRate() { LoanRateId = 1, LowerCreditScore = 50, UpperCreditScore = 59, InterestRate = 0.085 },
                new LoanRate() { LoanRateId = 2, LowerCreditScore = 60, UpperCreditScore = 69, InterestRate = 0.075 },
                new LoanRate() { LoanRateId = 3, LowerCreditScore = 70, UpperCreditScore = 79, InterestRate = 0.0625 },
                new LoanRate() { LoanRateId = 4, LowerCreditScore = 80, UpperCreditScore = 89, InterestRate = 0.0525 },
                new LoanRate() { LoanRateId = 5, LowerCreditScore = 90, UpperCreditScore = 100, InterestRate = 0.04 }
            );

            modelBuilder.Entity<LoanApplicationResult>().HasData(
                new LoanApplicationResult() { ResultId = 1, FirstName = "John", LastName = "Smith", AnnualIncome = 75_000, CreditScore = 79, Approved = true, InterestRate = 0.0625, LoanAmount = 125_000, MonthlyPayment = 769.65, LoanTerm = 30},
                new LoanApplicationResult() { ResultId = 2, FirstName = "Mary", LastName = "Jones", AnnualIncome = 60_000, CreditScore = 68, Approved = true, InterestRate = 0.075, LoanAmount = 135_000, MonthlyPayment = 934.94, LoanTerm = 30 },
                new LoanApplicationResult() { ResultId = 3, FirstName = "Andy", LastName = "Anderson", AnnualIncome = 100_000, CreditScore = 46, Approved = false, DenialReason = "Credit Score", LoanTerm = 30 },
                new LoanApplicationResult() { ResultId = 4, FirstName = "Sally", LastName = "Johnson", AnnualIncome = 125_000, CreditScore = 88, Approved = true, InterestRate = 0.0525, LoanAmount = 250_000, MonthlyPayment = 1684.61, LoanTerm = 20}


                );
        }

    }
}
