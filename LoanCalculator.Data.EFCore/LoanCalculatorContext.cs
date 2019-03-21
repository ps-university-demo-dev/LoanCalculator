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
            this.ConfigureLoanType(modelBuilder);
            this.ConfigureLoanRate(modelBuilder);
            this.ConfigureLoanApplicationResult(modelBuilder);
            this.SeedData(modelBuilder);
        }

        private void ConfigureLoanType(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoanType>()
                .ToTable("LoanTypes")
                .HasKey(lt => lt.LoanTypeId);
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
            modelBuilder.Entity<LoanType>().HasData(
                new LoanType() { LoanTypeId = 1, LoanTypeName = "car" },
                new LoanType() { LoanTypeId = 2, LoanTypeName = "school" }
            );

            modelBuilder.Entity<LoanRate>().HasData(
                new LoanRate() { LoanTypeId = 2, LoanRateId = 5, LowerCreditScore = 0, UpperCreditScore = 499, InterestRate = 0.100 },
                new LoanRate() { LoanTypeId = 1, LoanRateId = 1, LowerCreditScore = 500, UpperCreditScore = 599, InterestRate = 0.085 },
                new LoanRate() { LoanTypeId = 1, LoanRateId = 2, LowerCreditScore = 600, UpperCreditScore = 699, InterestRate = 0.075 },
                new LoanRate() { LoanTypeId = 2, LoanRateId = 3, LowerCreditScore = 700, UpperCreditScore = 799, InterestRate = 0.0625 },
                new LoanRate() { LoanTypeId = 2, LoanRateId = 4, LowerCreditScore = 800, UpperCreditScore = 850, InterestRate = 0.05 }
            );

            modelBuilder.Entity<LoanApplicationResult>().HasData(
                new LoanApplicationResult() { ResultId = 1, FirstName = "John", LastName = "Smith", AnnualIncome = 75_000, CreditScore = 79, Approved = true, InterestRate = 0.0625, LoanAmount = 125_000, MonthlyPayment = 769.65, LoanTerm = 30 },
                new LoanApplicationResult() { ResultId = 2, FirstName = "Mary", LastName = "Jones", AnnualIncome = 60_000, CreditScore = 68, Approved = true, InterestRate = 0.075, LoanAmount = 135_000, MonthlyPayment = 934.94, LoanTerm = 30 },
                new LoanApplicationResult() { ResultId = 3, FirstName = "Andy", LastName = "Anderson", AnnualIncome = 100_000, CreditScore = 46, Approved = false, DenialReason = "Credit Score", LoanTerm = 30 },
                new LoanApplicationResult() { ResultId = 4, FirstName = "Sally", LastName = "Johnson", AnnualIncome = 125_000, CreditScore = 88, Approved = true, InterestRate = 0.0525, LoanAmount = 250_000, MonthlyPayment = 1684.61, LoanTerm = 20 },
                new LoanApplicationResult() { ResultId = 5, FirstName = "John", LastName = "Test", AnnualIncome = 75_000, CreditScore = 79, Approved = true, InterestRate = 0.0625, LoanAmount = 125_000, MonthlyPayment = 769.65, LoanTerm = 30 },
                new LoanApplicationResult() { ResultId = 6, FirstName = "Jeff", LastName = "Pral", AnnualIncome = 60_000, CreditScore = 68, Approved = true, InterestRate = 0.075, LoanAmount = 135_000, MonthlyPayment = 934.94, LoanTerm = 30 },
                new LoanApplicationResult() { ResultId = 7, FirstName = "Steve", LastName = "Sun", AnnualIncome = 100_000, CreditScore = 46, Approved = false, DenialReason = "Credit Score", LoanTerm = 30 },
                new LoanApplicationResult() { ResultId = 8, FirstName = "Alan", LastName = "Roll", AnnualIncome = 125_000, CreditScore = 88, Approved = true, InterestRate = 0.0525, LoanAmount = 250_000, MonthlyPayment = 1684.61, LoanTerm = 20 },
                new LoanApplicationResult() { ResultId = 9, FirstName = "Bob", LastName = "Stevens", AnnualIncome = 75_000, CreditScore = 79, Approved = true, InterestRate = 0.0625, LoanAmount = 125_000, MonthlyPayment = 769.65, LoanTerm = 30 },
                new LoanApplicationResult() { ResultId = 10, FirstName = "Phil", LastName = "Tell", AnnualIncome = 60_000, CreditScore = 68, Approved = true, InterestRate = 0.075, LoanAmount = 135_000, MonthlyPayment = 934.94, LoanTerm = 30 },
                new LoanApplicationResult() { ResultId = 11, FirstName = "Joel", LastName = "Tess", AnnualIncome = 100_000, CreditScore = 46, Approved = false, DenialReason = "Credit Score", LoanTerm = 30 },
                new LoanApplicationResult() { ResultId = 12, FirstName = "Teresa", LastName = "Evans", AnnualIncome = 125_000, CreditScore = 88, Approved = true, InterestRate = 0.0525, LoanAmount = 250_000, MonthlyPayment = 1684.61, LoanTerm = 20 }


                );
        }

    }
}
